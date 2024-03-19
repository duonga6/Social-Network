using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatesharepostrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SharePosts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c9f63e91-f64d-431b-818d-d1e2fae85f84");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f277f64e-c35b-4b45-9594-4e9a06e408df");

            migrationBuilder.AddColumn<Guid>(
                name: "SharePostId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3324), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3330), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3331), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3663), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3663) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3666), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3666) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6714), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6717), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6718), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6725), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6725) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6726), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6726) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1307), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1314), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1315), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1316), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1317), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1318) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1319), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ce6aebd-5511-4a91-9875-311b757cfbb1", "f7c65ff7-ba4e-4c2c-99b1-5a55768e3711", "Administrator", "ADMINISTRATOR" },
                    { "4d5ab5a0-5c73-4b44-a884-15a09601f478", "e9e08d41-a5da-441d-8380-195b8a4198d0", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SharePostId",
                table: "Posts",
                column: "SharePostId",
                unique: true,
                filter: "[SharePostId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_SharePostId",
                table: "Posts",
                column: "SharePostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_SharePostId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SharePostId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4ce6aebd-5511-4a91-9875-311b757cfbb1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4d5ab5a0-5c73-4b44-a884-15a09601f478");

            migrationBuilder.DropColumn(
                name: "SharePostId",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "SharePosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Privacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharePosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SharePosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 319, DateTimeKind.Utc).AddTicks(8812), new DateTime(2024, 3, 18, 17, 24, 50, 319, DateTimeKind.Utc).AddTicks(8815) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 319, DateTimeKind.Utc).AddTicks(8824), new DateTime(2024, 3, 18, 17, 24, 50, 319, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 319, DateTimeKind.Utc).AddTicks(8825), new DateTime(2024, 3, 18, 17, 24, 50, 319, DateTimeKind.Utc).AddTicks(8825) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(178), new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(183) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(188), new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(188) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6324), new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6326) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6329), new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6330), new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6331), new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6332), new DateTime(2024, 3, 18, 17, 24, 50, 320, DateTimeKind.Utc).AddTicks(6333) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2036), new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2039) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2042), new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2042) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2043), new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2044) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2044), new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2045), new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2047), new DateTime(2024, 3, 18, 17, 24, 50, 325, DateTimeKind.Utc).AddTicks(2048) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c9f63e91-f64d-431b-818d-d1e2fae85f84", "fbd95940-1027-4166-a223-6b9d67792d5f", "User", "USER" },
                    { "f277f64e-c35b-4b45-9594-4e9a06e408df", "957faab7-fb03-4e43-83d3-3970a288985f", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_PostId",
                table: "SharePosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_UserId",
                table: "SharePosts",
                column: "UserId");
        }
    }
}
