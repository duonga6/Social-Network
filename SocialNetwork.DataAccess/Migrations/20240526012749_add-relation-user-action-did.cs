using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addrelationuseractiondid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "02da6001-8dd8-4891-9da3-17e441ab60ce");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2ea08341-a424-4787-a855-00fd272410f3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b39b6d60-64f3-40e4-a382-78b82b667235");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6658), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6661) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6673), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6674) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6675), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6676) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6677), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6677) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6679), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6679) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(6999), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7005), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7332), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7332) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7336), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3948), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3956), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3957), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3958), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3959) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3960), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(504), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(511), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(511) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(512), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(514), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(515), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(515) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(518), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(518) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02da6001-8dd8-4891-9da3-17e441ab60ce", "9aae8c01-81c9-4cf5-8175-bc40747555cf", "Administrator", "ADMINISTRATOR" },
                    { "2ea08341-a424-4787-a855-00fd272410f3", "21a8c2fb-4bf0-4391-ad56-c4fbb677d3c3", "User", "USER" },
                    { "b39b6d60-64f3-40e4-a382-78b82b667235", "532831fa-b35e-4992-8af7-80e2c2340859", "SuperAdministrator", "SUPERADMINISTRATOR" }
                });
        }
    }
}
