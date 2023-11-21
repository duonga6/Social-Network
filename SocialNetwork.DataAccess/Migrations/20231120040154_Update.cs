using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
