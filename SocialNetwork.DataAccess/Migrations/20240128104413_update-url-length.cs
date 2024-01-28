using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updateurllength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "514982c2-52c8-4ba2-98b7-c6f49b57e5d6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b30763c5-dd0c-4c91-a9d6-ec86ca7d9c10");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PostMedias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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

            migrationBuilder.InsertData(
                table: "MediaTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7851), "Hyper link", 1, new DateTime(2024, 1, 28, 10, 44, 12, 615, DateTimeKind.Utc).AddTicks(7852) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "973e465d-053f-45ae-9a4b-346ec6af4a7c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "99ce695d-439f-4c11-8015-c596bdeb113e");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PostMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5044), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5050), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5051), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5574), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6003), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6004) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6008), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6009), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6010), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6859), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6863), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6864), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6865), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6865), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6868), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6868) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "514982c2-52c8-4ba2-98b7-c6f49b57e5d6", "20539327-09b3-46bf-ad61-7bcb3725b435", "User", "USER" },
                    { "b30763c5-dd0c-4c91-a9d6-ec86ca7d9c10", "c240dcea-ed27-41e6-b52e-af2125a58041", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
