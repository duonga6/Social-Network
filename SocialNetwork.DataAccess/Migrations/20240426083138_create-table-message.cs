using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class createtablemessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CreatedAt",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "59f4b7ed-ebf5-4058-b45e-b83d4decf4aa");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c6bfb902-7d9c-4783-9c58-bcb6353e2beb");

            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "MediaTypeId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MessageType",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadedAt",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReplyId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RevokedAt",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Users_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrangeMessageBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrangeMessageBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrangeMessageBlocks_Users_FromId",
                        column: x => x.FromId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrangeMessageBlocks_Users_ToId",
                        column: x => x.ToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConversationMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId2 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationMembers_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConversationMembers_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConversationMembers_Users_UserId2",
                        column: x => x.UserId2,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessageMemberReadeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageMemberReadeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageMemberReadeds_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageMemberReadeds_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageMemberReadeds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReplyId",
                table: "Messages",
                column: "ReplyId",
                unique: true,
                filter: "[ReplyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMembers_ConversationId",
                table: "ConversationMembers",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMembers_UserId1",
                table: "ConversationMembers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMembers_UserId2",
                table: "ConversationMembers",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_CreatedId",
                table: "Conversations",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageMemberReadeds_ConversationId",
                table: "MessageMemberReadeds",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageMemberReadeds_MessageId",
                table: "MessageMemberReadeds",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageMemberReadeds_UserId",
                table: "MessageMemberReadeds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StrangeMessageBlocks_FromId",
                table: "StrangeMessageBlocks",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_StrangeMessageBlocks_ToId",
                table: "StrangeMessageBlocks",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Conversations_ConversationId",
                table: "Messages",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_ReplyId",
                table: "Messages",
                column: "ReplyId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Conversations_ConversationId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_ReplyId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "ConversationMembers");

            migrationBuilder.DropTable(
                name: "MessageMemberReadeds");

            migrationBuilder.DropTable(
                name: "StrangeMessageBlocks");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReplyId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1401771a-bbbe-4423-a0da-928342d21097");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "887bcde1-a4cf-4d85-8ea2-461d5d7a6dca");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageType",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReadedAt",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RevokedAt",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "MediaTypeId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8368), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8369) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8375), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8787), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9407), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9409) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9413), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9413) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9415), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9415) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9416), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9417), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8699), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8708), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8708) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8710), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8711), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8712), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8713) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8716), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8717) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59f4b7ed-ebf5-4058-b45e-b83d4decf4aa", "4bc5c642-b908-4f73-b444-59648d272825", "User", "USER" },
                    { "c6bfb902-7d9c-4783-9c58-bcb6353e2beb", "93d78ecf-f8da-4c42-a4c6-1da1488739db", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreatedAt",
                table: "Messages",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
