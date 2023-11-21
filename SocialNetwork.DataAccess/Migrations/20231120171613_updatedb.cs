using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("069c04ee-6782-4aca-82f3-e753642f04fa"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("486e400a-aa79-4e90-b2b4-e72ff8f85e56"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("694f6c77-5c05-4966-8804-bf20f4000a03"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("8f5d56ff-1a38-4477-92b2-bcdd853ac6bb"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("d104d4f1-12e5-445c-8798-be37a4b2b561"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("ea97d1a0-4edf-4639-983b-c7a89d28f896"));

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("ad2d5f04-0959-4727-b8e8-62229f0f5b58"), 2, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5843), "Love", 1, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5843) },
                    { new Guid("ad88a430-7540-4ffd-9f71-10f3f336287b"), 6, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5858), "Angry", 1, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5858) },
                    { new Guid("b70ace09-d359-49e0-bde8-fa6f8c565140"), 5, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5857), "Sad", 1, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5857) },
                    { new Guid("c477fdff-7fd3-4906-b1f0-de68b6a50d9e"), 1, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5839), "Like", 1, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5842) },
                    { new Guid("cf74c568-08bd-45f1-9e70-7b10ccfcc188"), 3, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5845), "Haha", 1, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5845) },
                    { new Guid("fdf27bc4-85c1-4d01-aa91-90df48a498b4"), 4, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5855), "Wow", 1, new DateTime(2023, 11, 20, 17, 16, 13, 586, DateTimeKind.Utc).AddTicks(5855) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "004f2b09-f7e1-44e4-94a6-cc3ebd467434", "8491b38a-2a29-44bc-9849-d20b7162cbaa", "User", null },
                    { "9fd924b1-8949-4bba-a86a-8600bf486ec0", "233db0f3-0d33-4be3-adf7-3505a4831a0f", "Administrator", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("ad2d5f04-0959-4727-b8e8-62229f0f5b58"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("ad88a430-7540-4ffd-9f71-10f3f336287b"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("b70ace09-d359-49e0-bde8-fa6f8c565140"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("c477fdff-7fd3-4906-b1f0-de68b6a50d9e"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("cf74c568-08bd-45f1-9e70-7b10ccfcc188"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("fdf27bc4-85c1-4d01-aa91-90df48a498b4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "004f2b09-f7e1-44e4-94a6-cc3ebd467434");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9fd924b1-8949-4bba-a86a-8600bf486ec0");

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("069c04ee-6782-4aca-82f3-e753642f04fa"), 1, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6372), "Like", 1, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6374) },
                    { new Guid("486e400a-aa79-4e90-b2b4-e72ff8f85e56"), 5, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6391), "Sad", 1, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6391) },
                    { new Guid("694f6c77-5c05-4966-8804-bf20f4000a03"), 2, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6376), "Love", 1, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6376) },
                    { new Guid("8f5d56ff-1a38-4477-92b2-bcdd853ac6bb"), 4, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6379), "Wow", 1, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6379) },
                    { new Guid("d104d4f1-12e5-445c-8798-be37a4b2b561"), 3, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6378), "Haha", 1, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6378) },
                    { new Guid("ea97d1a0-4edf-4639-983b-c7a89d28f896"), 6, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6392), "Angry", 1, new DateTime(2023, 11, 20, 4, 1, 53, 988, DateTimeKind.Utc).AddTicks(6393) }
                });
        }
    }
}
