using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class editimagecolumeconversation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "33740a4e-aeec-4de6-a633-129605d8894b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "862881fc-e626-40d2-a683-0069b6fed762");

            migrationBuilder.RenameColumn(
                name: "CoverImage",
                table: "Conversations",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4726), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4732), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4733), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5067), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5067) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5070), new DateTime(2024, 5, 4, 16, 8, 45, 667, DateTimeKind.Utc).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2158), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2163), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2163) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2164), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2164) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2164), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2165), new DateTime(2024, 5, 4, 16, 8, 45, 671, DateTimeKind.Utc).AddTicks(2165) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8383), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8387), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8388), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8390), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8392), new DateTime(2024, 5, 4, 16, 8, 45, 676, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf2613c4-1d19-471a-962b-8b8056e71e2b", "b925b9ba-8aee-444d-8378-2626a42aab60", "Administrator", "ADMINISTRATOR" },
                    { "e27e5090-0dda-4136-a5a8-592624e6f0c1", "f851a0b5-63db-4a20-b0a2-d9269e11cfe1", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cf2613c4-1d19-471a-962b-8b8056e71e2b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e27e5090-0dda-4136-a5a8-592624e6f0c1");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Conversations",
                newName: "CoverImage");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(479), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(484), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(485), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(485) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(836), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(838), new DateTime(2024, 5, 4, 15, 16, 12, 634, DateTimeKind.Utc).AddTicks(839) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2054), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2063), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2063) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2064), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2065), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2065) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2065), new DateTime(2024, 5, 4, 15, 16, 12, 638, DateTimeKind.Utc).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8955), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8961), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8962), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8963), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8964), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8967), new DateTime(2024, 5, 4, 15, 16, 12, 643, DateTimeKind.Utc).AddTicks(8967) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33740a4e-aeec-4de6-a633-129605d8894b", "35b588a6-8a91-41e1-88f1-6f7c3f13ac51", "User", "USER" },
                    { "862881fc-e626-40d2-a683-0069b6fed762", "aabc8c9b-4189-497a-adba-a7eb801a0e64", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
