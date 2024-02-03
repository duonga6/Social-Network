using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addcolorreaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b971846b-4fcc-45bf-b2b5-6d9627433c64");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d893ce77-f6dd-4308-9f63-c5a71bf169a3");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "Reactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1820), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1827), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1828), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1828) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2177), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2178) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2181), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2182) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2446), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2446) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2449), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2450), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2450) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2451), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2452), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2452) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorCode", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "#0561F2", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5889), "Thích", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColorCode", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "#f33e58", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5896), "Yêu thích", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5896) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColorCode", "CreatedAt", "UpdatedAt" },
                values: new object[] { "#F7B125", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5897), new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ColorCode", "CreatedAt", "UpdatedAt" },
                values: new object[] { "#F7B125", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5898), new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5898) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ColorCode", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "#F7B125", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5899), "Buồn", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ColorCode", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "#E9710F", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5901), "Phẫn nộ", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5902) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b622ccea-2e5f-4c43-b0e7-bef932d0bdb3", "c5449915-64ed-430a-96a8-faede493916b", "Administrator", "ADMINISTRATOR" },
                    { "e979a8bc-efed-4912-ad9e-9b40c9a1d188", "43c1c208-f846-43f5-80da-187a55357619", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b622ccea-2e5f-4c43-b0e7-bef932d0bdb3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e979a8bc-efed-4912-ad9e-9b40c9a1d188");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "Reactions");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(6884), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(6886) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(6891), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7321), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7321) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7325), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7720), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7724), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7725), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7726), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7727), new DateTime(2024, 1, 31, 16, 22, 7, 791, DateTimeKind.Utc).AddTicks(7727) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7626), "Like", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7632), "Love", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7632) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7633), new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7634), new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7634) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7635), "Sad", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7637), "Angry", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b971846b-4fcc-45bf-b2b5-6d9627433c64", "cb1b3539-e119-48a3-8ed2-8655e78ce94a", "User", "USER" },
                    { "d893ce77-f6dd-4308-9f63-c5a71bf169a3", "0045a8cf-c6b0-4cf6-87a5-303c09f35188", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
