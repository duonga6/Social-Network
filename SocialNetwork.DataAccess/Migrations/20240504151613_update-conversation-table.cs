using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updateconversationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMembers_Conversations_ConversationId",
                table: "ConversationMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMembers_Users_UserId1",
                table: "ConversationMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMembers_Users_UserId2",
                table: "ConversationMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversationMembers",
                table: "ConversationMembers");

            migrationBuilder.DropIndex(
                name: "IX_ConversationMembers_UserId1",
                table: "ConversationMembers");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1401771a-bbbe-4423-a0da-928342d21097");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "887bcde1-a4cf-4d85-8ea2-461d5d7a6dca");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ConversationMembers");

            migrationBuilder.RenameTable(
                name: "ConversationMembers",
                newName: "ConversationParticipants");

            migrationBuilder.RenameColumn(
                name: "UserId2",
                table: "ConversationParticipants",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationMembers_UserId2",
                table: "ConversationParticipants",
                newName: "IX_ConversationParticipants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationMembers_ConversationId",
                table: "ConversationParticipants",
                newName: "IX_ConversationParticipants_ConversationId");

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Conversations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperAdmin",
                table: "ConversationParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversationParticipants",
                table: "ConversationParticipants",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(479), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(484), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(485), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(485) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(836), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(838), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(839) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2054), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2063), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2063) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2064), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2065), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2065) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2065), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8955), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8961), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8962), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8963), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8964), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8967), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8967) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33740a4e-aeec-4de6-a633-129605d8894b", "35b588a6-8a91-41e1-88f1-6f7c3f13ac51", "User", "USER" },
                    { "862881fc-e626-40d2-a683-0069b6fed762", "aabc8c9b-4189-497a-adba-a7eb801a0e64", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreatedAt",
                table: "Messages",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_UpdatedAt",
                table: "Conversations",
                column: "UpdatedAt");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationParticipants_Conversations_ConversationId",
                table: "ConversationParticipants",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationParticipants_Users_UserId",
                table: "ConversationParticipants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationParticipants_Conversations_ConversationId",
                table: "ConversationParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationParticipants_Users_UserId",
                table: "ConversationParticipants");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CreatedAt",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_UpdatedAt",
                table: "Conversations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversationParticipants",
                table: "ConversationParticipants");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "33740a4e-aeec-4de6-a633-129605d8894b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "862881fc-e626-40d2-a683-0069b6fed762");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "IsSuperAdmin",
                table: "ConversationParticipants");

            migrationBuilder.RenameTable(
                name: "ConversationParticipants",
                newName: "ConversationMembers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ConversationMembers",
                newName: "UserId2");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationParticipants_UserId",
                table: "ConversationMembers",
                newName: "IX_ConversationMembers_UserId2");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationParticipants_ConversationId",
                table: "ConversationMembers",
                newName: "IX_ConversationMembers_ConversationId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ConversationMembers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversationMembers",
                table: "ConversationMembers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(5841), new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(5847), new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(5848), new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(6265), new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(6265) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(6268), new DateTime(2024, 4, 26, 8, 31, 37, 667, DateTimeKind.Utc).AddTicks(6268) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7421), new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7428), new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7429), new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7430), new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7430), new DateTime(2024, 4, 26, 8, 31, 37, 672, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3039), new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3047), new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3048), new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3048) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3049), new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3049) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3050), new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3053), new DateTime(2024, 4, 26, 8, 31, 37, 679, DateTimeKind.Utc).AddTicks(3053) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1401771a-bbbe-4423-a0da-928342d21097", "d445cee4-8928-433b-8ebf-1c5d8bc495c4", "Administrator", "ADMINISTRATOR" },
                    { "887bcde1-a4cf-4d85-8ea2-461d5d7a6dca", "01e4fb49-f720-4759-8ab6-f8880f144ff3", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMembers_UserId1",
                table: "ConversationMembers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMembers_Conversations_ConversationId",
                table: "ConversationMembers",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMembers_Users_UserId1",
                table: "ConversationMembers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMembers_Users_UserId2",
                table: "ConversationMembers",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
