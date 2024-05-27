using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updateactionreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "056a4ae4-d7fe-4d13-9d5a-5b75b3776cc3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3ced53c4-44fc-45ce-86ad-6ca9b9b5c9de");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "96b08fd2-9b47-4679-8596-0b374c1793b9");

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7211), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7213) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7223), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7225), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7226), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7227), new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.InsertData(
                table: "ActionReports",
                columns: new[] { "Id", "ActionName", "CreatedAt", "ReportType", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, "Xóa bình luận", new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7232), 2, 1, new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7232) },
                    { 7, "Khóa tài khoản người dùng", new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7233), 2, 1, new DateTime(2024, 5, 27, 2, 32, 2, 256, DateTimeKind.Utc).AddTicks(7233) }
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9173), new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9181), new DateTime(2024, 5, 27, 2, 32, 2, 262, DateTimeKind.Utc).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(144), new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(149), new DateTime(2024, 5, 27, 2, 32, 2, 263, DateTimeKind.Utc).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9629), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9637), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9638), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9639), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9639) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9640), new DateTime(2024, 5, 27, 2, 32, 2, 267, DateTimeKind.Utc).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5832), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5839), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5841), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5842), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5844), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5847), new DateTime(2024, 5, 27, 2, 32, 2, 274, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06e2cdd0-d781-42ed-b080-d23d9729c296", "0e92bfdb-7f73-4af6-9556-2e6d12b50281", "Administrator", "ADMINISTRATOR" },
                    { "334617c3-d923-442a-86e6-c4f877681484", "f2128ade-9df1-4e10-b156-7850b014b655", "User", "USER" },
                    { "e42fd790-7cd2-4b05-ba4b-38fbe28f0786", "1449674d-e1ff-4e34-baa4-6f80625bdcec", "SuperAdministrator", "SUPERADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "06e2cdd0-d781-42ed-b080-d23d9729c296");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "334617c3-d923-442a-86e6-c4f877681484");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e42fd790-7cd2-4b05-ba4b-38fbe28f0786");

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9680), new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9683) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9689), new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9689) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9690), new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9691), new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9691) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9691), new DateTime(2024, 5, 26, 1, 27, 48, 566, DateTimeKind.Utc).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(2882), new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(2883) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(2887), new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(2888) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(3159), new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(3159) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(3163), new DateTime(2024, 5, 26, 1, 27, 48, 571, DateTimeKind.Utc).AddTicks(3163) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3929), new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3935), new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3935) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3936), new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3936) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3937), new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3937), new DateTime(2024, 5, 26, 1, 27, 48, 575, DateTimeKind.Utc).AddTicks(3938) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7855), new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7858) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7862), new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7863), new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7864) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7865), new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7865) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7866), new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7866) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7868), new DateTime(2024, 5, 26, 1, 27, 48, 581, DateTimeKind.Utc).AddTicks(7868) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "056a4ae4-d7fe-4d13-9d5a-5b75b3776cc3", "6b2d9952-3217-4e26-981b-c7cced9cbfb0", "User", "USER" },
                    { "3ced53c4-44fc-45ce-86ad-6ca9b9b5c9de", "cb06145d-207e-4d03-9630-be91e64f4741", "Administrator", "ADMINISTRATOR" },
                    { "96b08fd2-9b47-4679-8596-0b374c1793b9", "9b4ed197-0ff7-488b-9e2b-618e86dc0b80", "SuperAdministrator", "SUPERADMINISTRATOR" }
                });
        }
    }
}
