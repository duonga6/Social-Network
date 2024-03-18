using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updategroupname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b45a160d-70d9-42bc-93ed-4e74ef87d7ec");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bd9952f2-7706-4ddd-8076-0f532a105762");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c9f63e91-f64d-431b-818d-d1e2fae85f84");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f277f64e-c35b-4b45-9594-4e9a06e408df");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
