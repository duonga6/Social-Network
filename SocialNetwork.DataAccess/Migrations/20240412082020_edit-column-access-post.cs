using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class editcolumnaccesspost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "171a3752-74f7-4461-8e7e-be994390bf45");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fce0d5fb-e4fe-4fe4-9cbf-7174ad1b34b8");

            migrationBuilder.AlterColumn<int>(
                name: "Access",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8522), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8528), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8529), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9096), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9097) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9100), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9050), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9055), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9056), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9057), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9058), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5070), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5078), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5078) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5080), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5081), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5081) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5082), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5085), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5085) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e2d5989-3cd1-4de1-a355-fb6680a1b5bd", "6f242ceb-1bed-4df5-9493-d0b3157587c4", "Administrator", "ADMINISTRATOR" },
                    { "602877f8-d863-42c1-8ccc-cd2d0c59b596", "f9f549df-36d7-4682-a801-d79731294816", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4e2d5989-3cd1-4de1-a355-fb6680a1b5bd");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "602877f8-d863-42c1-8ccc-cd2d0c59b596");

            migrationBuilder.AlterColumn<int>(
                name: "Access",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

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
    }
}
