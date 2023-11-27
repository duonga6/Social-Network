using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_CommentReactions_UserId",
                table: "CommentReactions");

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: new Guid("233d6190-06bd-4a23-bb14-07b50e228f43"));

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: new Guid("24613ada-36ea-4fe0-a0be-46510d957e48"));

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: new Guid("6ca517dd-7772-4958-abec-013986ab1729"));

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: new Guid("70e558cf-44ec-47b0-8cdf-6db4663232a2"));

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: new Guid("815598c7-4633-4b06-9954-e349da888a0f"));

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: new Guid("cb892953-2bca-437b-b4a5-62cdfe34ebb8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "460fa2e4-4a3f-4ff7-b2d9-4a7aea04b2a5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4ed177a7-032d-4574-8147-f2f561b89c04");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reactions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reactions",
                type: "int"
                );

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ReactionId",
                table: "PostReactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PostReactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PostReactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ReactionId",
                table: "CommentReactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CommentReactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CommentReactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions",
                columns: new[] { "UserId", "CommentId" });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2541), "Like", new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2538) },
                    { 2, new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2543), "Love", new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2543) },
                    { 3, new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2545), "Haha", new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2544) },
                    { 4, new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2546), "Wow", new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2546) },
                    { 5, new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2547), "Sad", new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2547) },
                    { 6, new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2548), "Angry", new DateTime(2023, 11, 27, 14, 7, 57, 318, DateTimeKind.Utc).AddTicks(2548) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4837d268-d500-4796-91a1-6439a609f94a", "6a4d5b26-7482-4249-b6d2-5a968b6c356a", "Administrator", "ADMINISTRATOR" },
                    { "d043fec9-e9ca-4d74-a068-f704c41ea915", "52c7694d-e0d2-49c4-a00d-8fe45cdd05e0", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_ReactionId",
                table: "CommentReactions",
                column: "ReactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_CommentReactions_ReactionId",
                table: "CommentReactions");

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4837d268-d500-4796-91a1-6439a609f94a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d043fec9-e9ca-4d74-a068-f704c41ea915");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostReactions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PostReactions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CommentReactions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CommentReactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Reactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReactionId",
                table: "PostReactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReactionId",
                table: "CommentReactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions",
                columns: new[] { "PostId", "ReactionId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentReactions",
                table: "CommentReactions",
                columns: new[] { "ReactionId", "UserId", "CommentId" });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("233d6190-06bd-4a23-bb14-07b50e228f43"), 1, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4084), "Like", 1, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4087) },
                    { new Guid("24613ada-36ea-4fe0-a0be-46510d957e48"), 2, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4089), "Love", 1, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4090) },
                    { new Guid("6ca517dd-7772-4958-abec-013986ab1729"), 4, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4092), "Wow", 1, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4092) },
                    { new Guid("70e558cf-44ec-47b0-8cdf-6db4663232a2"), 5, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4093), "Sad", 1, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4094) },
                    { new Guid("815598c7-4633-4b06-9954-e349da888a0f"), 6, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4095), "Angry", 1, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4095) },
                    { new Guid("cb892953-2bca-437b-b4a5-62cdfe34ebb8"), 3, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4091), "Haha", 1, new DateTime(2023, 11, 23, 3, 1, 21, 173, DateTimeKind.Utc).AddTicks(4091) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "460fa2e4-4a3f-4ff7-b2d9-4a7aea04b2a5", "2e65256c-4be0-4aa5-9454-8e4eb97949aa", "Administrator", "ADMINISTRATOR" },
                    { "4ed177a7-032d-4574-8147-f2f561b89c04", "5fd0ced7-37ce-4eb0-813d-084cf064db55", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_UserId",
                table: "CommentReactions",
                column: "UserId");
        }
    }
}
