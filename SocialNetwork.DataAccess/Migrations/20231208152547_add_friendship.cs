using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class add_friendship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "088de2eb-26a2-49d0-945f-f85472e7752d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9ee648c6-0f35-4fb8-a8cf-2b66f153e70a");

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId2 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FriendStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friendships_Users_UserId2",
                        column: x => x.UserId2,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2950), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2952), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2952) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2953), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2953) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2954), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2954) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2955), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2956), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17a1064b-1e56-4c73-847e-8742b6b6068d", "cfda828f-0136-41ff-af5f-c4cd5163e1cb", "User", "USER" },
                    { "8557ab77-fc9f-4355-8a95-870c4b879aa5", "95d5b6e8-53cf-4ec9-ad67-ff84cb49ffaf", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserId1",
                table: "Friendships",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserId2",
                table: "Friendships",
                column: "UserId2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "17a1064b-1e56-4c73-847e-8742b6b6068d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8557ab77-fc9f-4355-8a95-870c4b879aa5");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9136), new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9134) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9138), new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9138) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9139), new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9138) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9139), new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9140), new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9141), new DateTime(2023, 11, 27, 14, 10, 31, 864, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "088de2eb-26a2-49d0-945f-f85472e7752d", "fbd2a443-ea5c-480a-a856-910900f0e530", "Administrator", "ADMINISTRATOR" },
                    { "9ee648c6-0f35-4fb8-a8cf-2b66f153e70a", "55031e76-a283-47d4-8916-63f3c003cc9f", "User", "USER" }
                });
        }
    }
}
