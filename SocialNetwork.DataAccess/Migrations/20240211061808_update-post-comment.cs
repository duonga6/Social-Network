using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatepostcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b622ccea-2e5f-4c43-b0e7-bef932d0bdb3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e979a8bc-efed-4912-ad9e-9b40c9a1d188");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCommentId",
                table: "PostComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9878), new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9886), new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9886), new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(166), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(202), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(203) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(475), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(476) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(479), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(479) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(480), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(481), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(482), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(482) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6553), "https://i.ibb.co/BNNPTgp/like.png", new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6560), "https://i.ibb.co/wJ8H9wy/love.png", new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6561), "https://i.ibb.co/BKBGxqr/haha.png", new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6561) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6562), "https://i.ibb.co/hX0ktCf/wow.png", new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6562) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6563), "https://i.ibb.co/9vgHgc4/sad.png", new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6565), "https://i.ibb.co/dp2vn3Z/angry.png", new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6566) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "355f426e-0a3b-468c-b55f-9c63a9d363f8", "fa051a0a-428b-4430-9612-b87af99b2c8d", "Administrator", "ADMINISTRATOR" },
                    { "8820405d-d9d9-4ebf-af2c-dc5e62b5f9ee", "3c360a0f-823e-464d-90d0-40dcd3d5c0ba", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_ParentCommentId",
                table: "PostComments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_ParentCommentId",
                table: "PostComments",
                column: "ParentCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_ParentCommentId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_ParentCommentId",
                table: "PostComments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "355f426e-0a3b-468c-b55f-9c63a9d363f8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8820405d-d9d9-4ebf-af2c-dc5e62b5f9ee");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "PostComments");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1820), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1827), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1828), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(1828) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2177), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2178) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2181), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2182) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2446), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2446) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2449), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2450), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2450) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2451), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2452), new DateTime(2024, 2, 1, 16, 31, 30, 405, DateTimeKind.Utc).AddTicks(2452) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5889), "https://ibb.co/QddcY6g", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5896), "https://ibb.co/vsf57Q1", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5896) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5897), "https://ibb.co/FqzXMg0", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5898), "https://ibb.co/mvpmMS8", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5898) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5899), "https://ibb.co/W35v5Gz", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IconUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5901), "https://ibb.co/FYw1Gfp", new DateTime(2024, 2, 1, 16, 31, 30, 411, DateTimeKind.Utc).AddTicks(5902) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b622ccea-2e5f-4c43-b0e7-bef932d0bdb3", "c5449915-64ed-430a-96a8-faede493916b", "Administrator", "ADMINISTRATOR" },
                    { "e979a8bc-efed-4912-ad9e-9b40c9a1d188", "43c1c208-f846-43f5-80da-187a55357619", "User", "USER" }
                });
        }
    }
}
