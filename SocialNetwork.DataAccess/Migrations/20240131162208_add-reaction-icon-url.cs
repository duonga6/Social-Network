using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addreactioniconurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "973e465d-053f-45ae-9a4b-346ec6af4a7c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "99ce695d-439f-4c11-8015-c596bdeb113e");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Reactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7626), "https://ibb.co/QddcY6g", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7632), "https://ibb.co/vsf57Q1", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7632) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7633), "https://ibb.co/FqzXMg0", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7634), "https://ibb.co/mvpmMS8", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7634) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7635), "https://ibb.co/W35v5Gz", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7637), "https://ibb.co/FYw1Gfp", new DateTime(2024, 1, 31, 16, 22, 7, 797, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b971846b-4fcc-45bf-b2b5-6d9627433c64", "cb1b3539-e119-48a3-8ed2-8655e78ce94a", "User", "USER" },
                    { "d893ce77-f6dd-4308-9f63-c5a71bf169a3", "0045a8cf-c6b0-4cf6-87a5-303c09f35188", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b971846b-4fcc-45bf-b2b5-6d9627433c64");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d893ce77-f6dd-4308-9f63-c5a71bf169a3");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Reactions");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7035), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7041), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7041) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7042), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7042) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7411), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7414), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7414) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7846), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7849), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7850), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7851), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7851) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7851), new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7852) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4273), new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4280), new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4281), new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4281) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4281), new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4282), new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4285), new DateTime(2024, 1, 28, 10, 44, 12, 622, DateTimeKind.Utc).AddTicks(4285) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "973e465d-053f-45ae-9a4b-346ec6af4a7c", "7b1f5643-67e5-49dd-bc3e-37e0597f89df", "User", "USER" },
                    { "99ce695d-439f-4c11-8015-c596bdeb113e", "1fd0281f-f7b0-401c-b05a-fd6b6593cf4a", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
