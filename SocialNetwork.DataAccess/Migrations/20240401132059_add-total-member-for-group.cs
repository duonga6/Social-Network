using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addtotalmemberforgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1aa7c567-9021-4910-9501-3f5dd5b9facb");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "58c19c5a-cfad-4b23-be26-4bb2d5e8f76c");

            migrationBuilder.AddColumn<int>(
                name: "TotalMember",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2099), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2103) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2106), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2108), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2711), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2712) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2714), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4663), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4666) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4669), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4669) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4670), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4671), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4672), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4673) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(440), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(441) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(446), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(447) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(448), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(450), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(451), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(451) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(453), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(453) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d74b0dd-8588-46a5-921b-d3ccb45ca090", "5527da85-09b2-4d10-947c-247724d70223", "User", "USER" },
                    { "585e975c-fec3-4100-9a67-29d4493c0ad0", "d5f39d90-c038-42f4-881b-25f51e196a22", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1d74b0dd-8588-46a5-921b-d3ccb45ca090");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "585e975c-fec3-4100-9a67-29d4493c0ad0");

            migrationBuilder.DropColumn(
                name: "TotalMember",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6885), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6891), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7390), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7391) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7394), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5932), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5936), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5937), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5937) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5938), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5938) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5939), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3639), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3644), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3646), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3647), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3647) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3648), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1aa7c567-9021-4910-9501-3f5dd5b9facb", "ea6d67d6-15d4-4e87-8a8e-1bc7a3f82d15", "Administrator", "ADMINISTRATOR" },
                    { "58c19c5a-cfad-4b23-be26-4bb2d5e8f76c", "e511da72-6ecd-4c73-a2c4-9577d9c76a75", "User", "USER" }
                });
        }
    }
}
