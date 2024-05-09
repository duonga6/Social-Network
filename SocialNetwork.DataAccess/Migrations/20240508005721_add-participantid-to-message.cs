using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addparticipantidtomessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cf2613c4-1d19-471a-962b-8b8056e71e2b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e27e5090-0dda-4136-a5a8-592624e6f0c1");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ConversationParticipants_ParticipantId",
                table: "Messages",
                column: "ParticipantId",
                principalTable: "ConversationParticipants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ConversationParticipants_ParticipantId",
                table: "Messages");

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

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4726), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4732), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4733), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5067), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5067) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5070), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2158), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2163), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2163) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2164), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2164) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2164), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2165), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8387), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8388), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8390), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8392), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf2613c4-1d19-471a-962b-8b8056e71e2b", "b925b9ba-8aee-444d-8378-2626a42aab60", "Administrator", "ADMINISTRATOR" },
                    { "e27e5090-0dda-4136-a5a8-592624e6f0c1", "f851a0b5-63db-4a20-b0a2-d9269e11cfe1", "User", "USER" }
                });
        }
    }
}
