using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addaccesscolumnposttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "52572ed0-5d04-411a-8455-dfd477c712d1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "782b3a2b-66b9-41fb-afca-7a2d4bd97082");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "Access",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(5770), new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(5773) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(5776), new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(5776) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(5777), new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(5778) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(6384), new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(6385) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(6389), new DateTime(2024, 4, 12, 8, 18, 6, 839, DateTimeKind.Utc).AddTicks(6389) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5347), new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5347) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5351), new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5351) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5352), new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5352) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5353), new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5353) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5354), new DateTime(2024, 4, 12, 8, 18, 6, 840, DateTimeKind.Utc).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7908), new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7914), new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7914) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7916), new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7917), new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7918), new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7918) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7920), new DateTime(2024, 4, 12, 8, 18, 6, 848, DateTimeKind.Utc).AddTicks(7921) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "171a3752-74f7-4461-8e7e-be994390bf45", "6dee6dc3-b675-4360-ad1a-85281a9d5495", "Administrator", "ADMINISTRATOR" },
                    { "fce0d5fb-e4fe-4fe4-9cbf-7174ad1b34b8", "1a3e9a6d-b853-4254-bf9d-dcf7ba848562", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "171a3752-74f7-4461-8e7e-be994390bf45");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fce0d5fb-e4fe-4fe4-9cbf-7174ad1b34b8");

            migrationBuilder.DropColumn(
                name: "Access",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Privacy",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3875), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3877) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3880), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3881), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4392), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4392) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4395), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1840), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1844), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1844) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1845), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1845) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1846), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1847), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1736), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1742), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1743) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1744), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1745), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1745) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1746), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1746) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1748), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1748) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52572ed0-5d04-411a-8455-dfd477c712d1", "7076ced0-07c1-43a9-b2bc-c32736b2b888", "User", "USER" },
                    { "782b3a2b-66b9-41fb-afca-7a2d4bd97082", "ba0961ed-4dd8-4e34-98a7-f9ff4a457381", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
