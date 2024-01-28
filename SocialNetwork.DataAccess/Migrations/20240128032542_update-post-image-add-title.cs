using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatepostimageaddtitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5ef525b7-118e-43fd-8fc8-0017f29ec5e8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d56b1a3e-4c46-46af-af27-173dfd995725");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PostImages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8754), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8760), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8761), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9136), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9137) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9139), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9533), new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9538), new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9539), new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(947), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(953), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(954), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(956), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(957), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2407510a-9d32-42b8-a419-987b0274f10f", "62ced3ab-11f8-4c56-89a8-bc3beeccb992", "User", "USER" },
                    { "fd34a429-fc8b-4772-9a29-735d4dc3b001", "c878fe12-2a31-4f8e-8da1-0aa5ef3e3bc6", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2407510a-9d32-42b8-a419-987b0274f10f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fd34a429-fc8b-4772-9a29-735d4dc3b001");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PostImages");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4127), new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4137), new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4138), new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4138) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4541), new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4541) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4544), new DateTime(2024, 1, 24, 13, 56, 4, 882, DateTimeKind.Utc).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(64), new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(64) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(68), new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(68) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(69), new DateTime(2024, 1, 24, 13, 56, 4, 885, DateTimeKind.Utc).AddTicks(69) });

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
        }
    }
}
