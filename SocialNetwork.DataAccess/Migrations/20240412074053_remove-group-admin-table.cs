using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class removegroupadmintable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupAdministrator");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "08aaad91-3138-4e2e-b4de-9121841f7631");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0d12d49f-93c1-4fe3-b045-d0b2f8567772");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "GroupMembers");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "GroupMembers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperAdmin",
                table: "GroupMembers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3875), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3877) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3880), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3881), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4392), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4392) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4395), new DateTime(2024, 4, 12, 7, 40, 53, 307, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1840), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1844), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1844) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1845), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1845) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1846), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1847), new DateTime(2024, 4, 12, 7, 40, 53, 308, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1736), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1742), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1743) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1744), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1745), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1745) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1746), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1746) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1748), new DateTime(2024, 4, 12, 7, 40, 53, 315, DateTimeKind.Utc).AddTicks(1748) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52572ed0-5d04-411a-8455-dfd477c712d1", "7076ced0-07c1-43a9-b2bc-c32736b2b888", "User", "USER" },
                    { "782b3a2b-66b9-41fb-afca-7a2d4bd97082", "ba0961ed-4dd8-4e34-98a7-f9ff4a457381", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "52572ed0-5d04-411a-8455-dfd477c712d1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "782b3a2b-66b9-41fb-afca-7a2d4bd97082");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "IsSuperAdmin",
                table: "GroupMembers");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "GroupMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupAdministrator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuperAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAdministrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupAdministrator_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupAdministrator_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1338), new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1344), new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1344) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1345), new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1950), new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1952), new DateTime(2024, 4, 2, 1, 21, 57, 278, DateTimeKind.Utc).AddTicks(1953) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2167), new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2171), new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2172), new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2172) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2173), new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2174), new DateTime(2024, 4, 2, 1, 21, 57, 279, DateTimeKind.Utc).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9593), new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9597), new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9599), new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9599) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9601), new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9602), new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9604), new DateTime(2024, 4, 2, 1, 21, 57, 285, DateTimeKind.Utc).AddTicks(9604) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08aaad91-3138-4e2e-b4de-9121841f7631", "52b876c6-beea-4716-b9f3-a2acba1cb71e", "Administrator", "ADMINISTRATOR" },
                    { "0d12d49f-93c1-4fe3-b045-d0b2f8567772", "a2ef41d5-9216-4d03-bb7f-1847adcb4f31", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupAdministrator_GroupId",
                table: "GroupAdministrator",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAdministrator_UserId",
                table: "GroupAdministrator",
                column: "UserId");
        }
    }
}
