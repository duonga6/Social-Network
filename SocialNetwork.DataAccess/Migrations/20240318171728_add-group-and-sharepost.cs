using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addgroupandsharepost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7097bb45-a3f3-4650-aece-60ca9368e24b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7abf4b13-5374-4d5a-88f9-b9a479f8c4f1");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Privacy",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SharePosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(5755), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(5761), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(5762) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(5763), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(6301), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(6301) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(6304), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(6305) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9576), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9577) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9580), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9581) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9581), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9582) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9582), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9582) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9622), new DateTime(2024, 3, 18, 17, 17, 28, 441, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4167), new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4178), new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4179), new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4180), new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4183), new DateTime(2024, 3, 18, 17, 17, 28, 446, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b45a160d-70d9-42bc-93ed-4e74ef87d7ec", "f816dfc8-9dbe-4e37-9ed2-d556d827ac12", "Administrator", "ADMINISTRATOR" },
                    { "bd9952f2-7706-4ddd-8076-0f532a105762", "0e9a34cf-2e5d-4973-824a-9b728c4990e5", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GroupId",
                table: "Posts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_UserId",
                table: "GroupMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_PostId",
                table: "SharePosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SharePosts_UserId",
                table: "SharePosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Groups_GroupId",
                table: "Posts",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Groups_GroupId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "SharePosts");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GroupId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b45a160d-70d9-42bc-93ed-4e74ef87d7ec");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bd9952f2-7706-4ddd-8076-0f532a105762");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4638), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4642) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4647), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4648), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4649) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5151), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5155), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5156) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5624), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5628), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5628) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5629), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5630) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5630), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4856), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4859) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4866), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4866) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4868), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4869), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4871), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4871) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4874), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4875) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7097bb45-a3f3-4650-aece-60ca9368e24b", "af8ae957-362e-447b-badb-7c657dab9879", "Administrator", "ADMINISTRATOR" },
                    { "7abf4b13-5374-4d5a-88f9-b9a479f8c4f1", "368309e3-31e6-4ebb-89b2-e4eb94fac030", "User", "USER" }
                });
        }
    }
}
