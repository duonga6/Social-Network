using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addreportactiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "252a3664-1469-40c2-8ac6-659cea6cbbb9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a36485a3-3b91-4bc1-976c-a3c1d7a4419c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c7dde6d7-a135-4006-a425-671b70be06e4");

            migrationBuilder.CreateTable(
                name: "ActionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionReportDids",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionReportId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionReportDids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionReportDids_ActionReports_ActionReportId",
                        column: x => x.ActionReportId,
                        principalTable: "ActionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionReportDids_ReportViolations_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ReportViolations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionReportDids_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ActionReports",
                columns: new[] { "Id", "ActionName", "CreatedAt", "ReportType", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Khóa tài khoản người dùng", new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(131), 1, 1, new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(133) },
                    { 2, "Khóa tài khoản người dùng", new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(138), 0, 1, new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(138) },
                    { 3, "Xóa bài viết", new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(138), 0, 1, new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(139) },
                    { 4, "Khóa tài khoản người dùng", new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(139), 3, 1, new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(140) },
                    { 5, "Xóa nhóm", new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(140), 3, 1, new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(140) }
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3010), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3014), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3015) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3390), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3393), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3393) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2916), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2917) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2921), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2922), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2922) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2923), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2923) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2923), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2024), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2031), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2032), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2033), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2035), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2038), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2038) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e07abea-2b70-43e5-845e-8c9e0630b566", "29c0a33b-f0bc-406d-a9e1-c1ba8882f6d9", "Administrator", "ADMINISTRATOR" },
                    { "1b78caa6-71f6-49d1-9d65-43da7f25dbe4", "843fd906-f280-48d3-9ece-3157a3523b4e", "User", "USER" },
                    { "a95e4b36-c9d8-4848-9cd9-d60677692501", "ec1f94b3-c0ba-4329-9c67-65ee9ee8ce65", "SuperAdministrator", "SUPERADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionReportDids_ActionReportId",
                table: "ActionReportDids",
                column: "ActionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionReportDids_CreatedById",
                table: "ActionReportDids",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActionReportDids_ReportId",
                table: "ActionReportDids",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionReportDids");

            migrationBuilder.DropTable(
                name: "ActionReports");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0e07abea-2b70-43e5-845e-8c9e0630b566");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1b78caa6-71f6-49d1-9d65-43da7f25dbe4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a95e4b36-c9d8-4848-9cd9-d60677692501");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7289), new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7299), new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7791), new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7793) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7796), new DateTime(2024, 5, 20, 12, 26, 42, 725, DateTimeKind.Utc).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6853), new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6855) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6859), new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6859) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6860), new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6861), new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6862), new DateTime(2024, 5, 20, 12, 26, 42, 730, DateTimeKind.Utc).AddTicks(6862) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9752), new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9759), new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9761), new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9761) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9762), new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9763) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9764), new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9764) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9766), new DateTime(2024, 5, 20, 12, 26, 42, 737, DateTimeKind.Utc).AddTicks(9766) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "252a3664-1469-40c2-8ac6-659cea6cbbb9", "9de429b3-1e6a-42b2-9a5e-3b9b145408d6", "SuperAdministrator", "SUPERADMINISTRATOR" },
                    { "a36485a3-3b91-4bc1-976c-a3c1d7a4419c", "8af6f54c-ebca-4a92-95f7-80c3a6e7560a", "User", "USER" },
                    { "c7dde6d7-a135-4006-a425-671b70be06e4", "0b91cd4e-d022-42df-9958-1d33749a1536", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
