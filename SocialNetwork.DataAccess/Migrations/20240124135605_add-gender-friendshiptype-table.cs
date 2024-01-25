using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addgenderfriendshiptypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_Post",
                table: "CommentReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_Reaction",
                table: "CommentReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_User",
                table: "CommentReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComment_User",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostImage_Image",
                table: "PostImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReaction_Post",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReaction_Reaction",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReaction_User",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4fbeab8d-c6e2-41d4-9309-b967115bad10");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8a1f7449-b8d2-4992-8fe2-874ff293927d");

            migrationBuilder.RenameColumn(
                name: "FriendStatus",
                table: "Friendships",
                newName: "FriendshipTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PostReactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CommentReactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FriendshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FriendshipTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4127), "Pending", 1, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4130) },
                    { 2, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4137), "Accepted", 1, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4137) },
                    { 3, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4138), "Blocked", 1, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4138) }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4541), "Female", 1, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4541) },
                    { 2, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4544), "Male", 1, new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4545) }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(64), "Text", 1, new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(64) },
                    { 2, new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(68), "Video", 1, new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(68) },
                    { 3, new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(69), "Image", 1, new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(69) }
                });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2495), new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2495) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2498), new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2498) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2499), new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2500), new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2500), new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2501) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2503), new DateTime(2024, 1, 24, 13, 56, 4, 888, DateTimeKind.Utc).AddTicks(2503) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ef525b7-118e-43fd-8fc8-0017f29ec5e8", "4bbd7863-de37-48ac-8eec-c1c882c7af8a", "Administrator", "ADMINISTRATOR" },
                    { "d56b1a3e-4c46-46af-af27-173dfd995725", "6fb797bb-d2b1-4611-b9b8-b997da2fd69f", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Gender",
                table: "Users",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_PostId_UserId",
                table: "PostReactions",
                columns: new[] { "PostId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendshipTypeId",
                table: "Friendships",
                column: "FriendshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_UserId_CommentId",
                table: "CommentReactions",
                columns: new[] { "UserId", "CommentId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReactions_PostComments_CommentId",
                table: "CommentReactions",
                column: "CommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReactions_Reactions_ReactionId",
                table: "CommentReactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReactions_Users_UserId",
                table: "CommentReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_FriendshipTypes_FriendshipTypeId",
                table: "Friendships",
                column: "FriendshipTypeId",
                principalTable: "FriendshipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Users_UserId",
                table: "PostComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Posts_PostId",
                table: "PostReactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Reactions_ReactionId",
                table: "PostReactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Users_UserId",
                table: "PostReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_Gender",
                table: "Users",
                column: "Gender",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReactions_PostComments_CommentId",
                table: "CommentReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReactions_Reactions_ReactionId",
                table: "CommentReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReactions_Users_UserId",
                table: "CommentReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_FriendshipTypes_FriendshipTypeId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Users_UserId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Posts_PostId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Reactions_ReactionId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Users_UserId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_Gender",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FriendshipTypes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Users_Gender",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions");

            migrationBuilder.DropIndex(
                name: "IX_PostReactions_PostId_UserId",
                table: "PostReactions");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_FriendshipTypeId",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_CommentReactions_UserId_CommentId",
                table: "CommentReactions");

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5ef525b7-118e-43fd-8fc8-0017f29ec5e8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d56b1a3e-4c46-46af-af27-173dfd995725");

            migrationBuilder.RenameColumn(
                name: "FriendshipTypeId",
                table: "Friendships",
                newName: "FriendStatus");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PostReactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CommentReactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions",
                columns: new[] { "UserId", "CommentId" });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5553), new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5556) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5562), new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5563) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5630), new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5630) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5632), new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5634), new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5635) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5639), new DateTime(2024, 1, 22, 16, 0, 30, 666, DateTimeKind.Utc).AddTicks(5639) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fbeab8d-c6e2-41d4-9309-b967115bad10", "b963d637-6402-48f6-950c-5be8387395cb", "User", "USER" },
                    { "8a1f7449-b8d2-4992-8fe2-874ff293927d", "9d10d7ed-f882-4df9-94bc-7fd77a7fc45a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_Post",
                table: "CommentReactions",
                column: "CommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_Reaction",
                table: "CommentReactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_User",
                table: "CommentReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_User",
                table: "PostComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImage_Image",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReaction_Post",
                table: "PostReactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReaction_Reaction",
                table: "PostReactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReaction_User",
                table: "PostReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
