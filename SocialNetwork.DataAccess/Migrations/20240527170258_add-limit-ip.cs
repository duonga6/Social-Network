using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addlimitip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "06e2cdd0-d781-42ed-b080-d23d9729c296");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "334617c3-d923-442a-86e6-c4f877681484");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e42fd790-7cd2-4b05-ba4b-38fbe28f0786");

            migrationBuilder.CreateTable(
                name: "IPLimits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPLimits", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1309), new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1313) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1329), new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1331), new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1332) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1333), new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1334) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1335), new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1342), new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1343) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1344), new DateTime(2024, 5, 27, 17, 2, 57, 374, DateTimeKind.Utc).AddTicks(1344) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(8701), new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(8705) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(8710), new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(8711) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(9224), new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(9228), new DateTime(2024, 5, 27, 17, 2, 57, 383, DateTimeKind.Utc).AddTicks(9229) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3608), new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3620), new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3622), new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3622) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3624), new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3625) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3626), new DateTime(2024, 5, 27, 17, 2, 57, 393, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5636), new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5639) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5646), new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5646) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5649), new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5649) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5651), new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5651) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5653), new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5654) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5658), new DateTime(2024, 5, 27, 17, 2, 57, 409, DateTimeKind.Utc).AddTicks(5658) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2900fc13-cb84-49fc-8958-383367cb0fbf", "c82dc96f-8b3b-4298-8ceb-24a105f4f884", "User", "USER" },
                    { "774c946d-8823-4281-bf0f-3a3e60f788f1", "8360fcc5-0055-49fe-95f4-b7540730418c", "SuperAdministrator", "SUPERADMINISTRATOR" },
                    { "ccc72ba5-277d-49e3-94d5-a4d4539bef21", "f81697b6-b2e5-4d00-9cd2-fd6c749ed778", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPLimits_IpAddress",
                table: "IPLimits",
                column: "IpAddress",
                unique: true,
                filter: "[IpAddress] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPLimits");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2900fc13-cb84-49fc-8958-383367cb0fbf");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "774c946d-8823-4281-bf0f-3a3e60f788f1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ccc72ba5-277d-49e3-94d5-a4d4539bef21");

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7211), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7213) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7223), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7225), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7226), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7227), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7232), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7232) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7233), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9173), new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9181), new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(144), new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(149), new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9629), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9637), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9638), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9639), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9639) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9640), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5832), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5839), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5841), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5842), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5844), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5847), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06e2cdd0-d781-42ed-b080-d23d9729c296", "0e92bfdb-7f73-4af6-9556-2e6d12b50281", "Administrator", "ADMINISTRATOR" },
                    { "334617c3-d923-442a-86e6-c4f877681484", "f2128ade-9df1-4e10-b156-7850b014b655", "User", "USER" },
                    { "e42fd790-7cd2-4b05-ba4b-38fbe28f0786", "1449674d-e1ff-4e34-baa4-6f80625bdcec", "SuperAdministrator", "SUPERADMINISTRATOR" }
                });
        }
    }
}
