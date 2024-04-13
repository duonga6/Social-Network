using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addprecensoredcolumngroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9a8d4d98-9884-49b8-afe5-ce4863017c86");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c1203678-656a-423d-8b02-5be4e3b5fffc");

            migrationBuilder.AddColumn<bool>(
                name: "PreCensored",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7569), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7571) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7574), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7575), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7575) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7900), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7901) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7904), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7904) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6178), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6183), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6183), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6184) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6184), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6185) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6185), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6185) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5380), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5381) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5385), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5386) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5387), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5387) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5388), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5389) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5389), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5389) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5392), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5392) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dc448ed5-c0b6-4232-8499-72321ab8a0e5", "a0c8bb6c-83e7-4250-b121-587be92633de", "Administrator", "ADMINISTRATOR" },
                    { "e0aeb98a-1ddf-470d-9591-fb9df0732347", "1d6d80a5-ae05-4f32-b0a2-899e8671898a", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dc448ed5-c0b6-4232-8499-72321ab8a0e5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e0aeb98a-1ddf-470d-9591-fb9df0732347");

            migrationBuilder.DropColumn(
                name: "PreCensored",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5144), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5152), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5153), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5604), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5607), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4362), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4363) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4366), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4366) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4367), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4367) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4368), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4369), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5328), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5335), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5336), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5336) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5337), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5338), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5340), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5340) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a8d4d98-9884-49b8-afe5-ce4863017c86", "6282aef9-9caf-4129-9df6-eec45df3f4a1", "User", "USER" },
                    { "c1203678-656a-423d-8b02-5be4e3b5fffc", "c667cf6e-f3c9-4040-acbd-abcf4c223f76", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
