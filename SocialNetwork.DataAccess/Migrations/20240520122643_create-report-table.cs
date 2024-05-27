using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class createreporttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "39808c24-ffab-429c-8d99-98e1aad3689b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "95d5bb41-2f60-445b-b2d9-83e6c0fc4e16");

            migrationBuilder.CreateTable(
                name: "ReportViolations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JsonDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    SolvedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RelatedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportViolations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportViolations_Users_SolvedById",
                        column: x => x.SolvedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportViolations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ReportViolations_SolvedById",
                table: "ReportViolations",
                column: "SolvedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportViolations_UserId",
                table: "ReportViolations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportViolations");

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

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(5881), new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(5889), new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(5889) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(6403), new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(6404) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(6408), new DateTime(2024, 5, 13, 15, 28, 6, 765, DateTimeKind.Utc).AddTicks(6409) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7433), new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7436) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7441), new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7441) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7442), new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7443) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7443), new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7445), new DateTime(2024, 5, 13, 15, 28, 6, 771, DateTimeKind.Utc).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1089), new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1099), new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1101), new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1101) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1102), new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1104), new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1108), new DateTime(2024, 5, 13, 15, 28, 6, 785, DateTimeKind.Utc).AddTicks(1109) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39808c24-ffab-429c-8d99-98e1aad3689b", "ffee6c39-6a94-4424-bc54-351ff0e8fae6", "Administrator", "ADMINISTRATOR" },
                    { "95d5bb41-2f60-445b-b2d9-83e6c0fc4e16", "cdf87d18-e525-4698-8275-24427d420949", "User", "USER" }
                });
        }
    }
}
