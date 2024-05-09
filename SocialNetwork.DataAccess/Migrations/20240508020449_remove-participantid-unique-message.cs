using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class removeparticipantiduniquemessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_ParticipantId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c960b222-983f-407d-83c5-8373640b8688");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f34eee13-5c08-4eb2-a63d-ffc5839733ca");

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

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(945), new DateTime(2024, 5, 8, 2, 4, 48, 969, DateTimeKind.Utc).AddTicks(946) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ParticipantId",
                table: "Messages",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_ParticipantId",
                table: "Messages");

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
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2478), new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2484), new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2484) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2485), new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2828), new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2831), new DateTime(2024, 5, 8, 0, 57, 20, 746, DateTimeKind.Utc).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5811), new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5812) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5815), new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5817), new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5817) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5818), new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5819), new DateTime(2024, 5, 8, 0, 57, 20, 750, DateTimeKind.Utc).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6652), new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6660), new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6662), new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6662) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6663), new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6663) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6664), new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6664) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6666), new DateTime(2024, 5, 8, 0, 57, 20, 756, DateTimeKind.Utc).AddTicks(6666) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c960b222-983f-407d-83c5-8373640b8688", "e63326b8-f2e8-401d-a917-badd847d7244", "User", "USER" },
                    { "f34eee13-5c08-4eb2-a63d-ffc5839733ca", "b57376e4-53c7-48d3-b799-15b922115a66", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ParticipantId",
                table: "Messages",
                column: "ParticipantId",
                unique: true);
        }
    }
}
