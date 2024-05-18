using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class createrelationpostcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

            migrationBuilder.DeleteData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "24f48ce8-7206-4a2c-92c1-426801521cbc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "78827f95-1560-4c41-a8b1-bdef8bd321f6");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "39808c24-ffab-429c-8d99-98e1aad3689b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "95d5bb41-2f60-445b-b2d9-83e6c0fc4e16");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(938), new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(944), new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.InsertData(
                table: "FriendshipTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(945), "Blocked", 1, new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(1354), new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(1355) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(1358), new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(1359) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6548), new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6553), new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6554), new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6554) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6555), new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6555) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6556), new DateTime(2024, 5, 8, 2, 4, 48, 973, DateTimeKind.Utc).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7431), new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7432) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7436), new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7436) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7437), new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7437) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7438), new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7438) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7441), new DateTime(2024, 5, 8, 2, 4, 48, 979, DateTimeKind.Utc).AddTicks(7442) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24f48ce8-7206-4a2c-92c1-426801521cbc", "1ac22065-773d-4744-8a60-9ac5b478db67", "Administrator", "ADMINISTRATOR" },
                    { "78827f95-1560-4c41-a8b1-bdef8bd321f6", "7e14d144-af6e-4f0e-b0ae-a854c5dbd860", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
