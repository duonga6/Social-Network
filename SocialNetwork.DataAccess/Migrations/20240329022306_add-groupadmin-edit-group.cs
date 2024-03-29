using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addgroupadmineditgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "433bb76f-faf6-4a31-9aff-76eebf0ce46d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "69eba43c-fa05-4e64-91aa-35a6e035468c");

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedId",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "OtherCanSee",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrivateGroup",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "GroupAdministrator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSuperAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5249), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5255) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5258), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5258) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5259), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5259) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5758), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5761), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4150), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4154), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4155), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4156), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4157), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4157) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(456), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(459) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(463), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(463) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(465), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(465) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(466), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(467), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(469), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(469) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11519cd8-48bc-43c8-b32c-aa09eb05fec7", "8026134d-37ab-4dd1-a059-626fc9d1bb22", "User", "USER" },
                    { "a4f54938-50d4-45e0-9595-e2561cf8dee1", "690cf795-4b08-4ef8-832e-5568456bd7cd", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatedId",
                table: "Groups",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAdministrator_GroupId",
                table: "GroupAdministrator",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAdministrator_UserId",
                table: "GroupAdministrator",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_CreatedId",
                table: "Groups",
                column: "CreatedId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatedId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "GroupAdministrator");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatedId",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "11519cd8-48bc-43c8-b32c-aa09eb05fec7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a4f54938-50d4-45e0-9595-e2561cf8dee1");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "OtherCanSee",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PrivateGroup",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3060), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3063) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3065), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3066) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3067), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3067) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3403), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3404) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3406), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6486), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6487) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6490), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6491), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6492), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6492) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6493), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6493) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5695), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5697) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5700), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5701), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5701) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5702), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5702) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5703), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5703) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5706), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5706) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "433bb76f-faf6-4a31-9aff-76eebf0ce46d", "34d42acc-059f-4426-8d7d-105815936f8b", "Administrator", "ADMINISTRATOR" },
                    { "69eba43c-fa05-4e64-91aa-35a6e035468c", "456aa9e4-9bd0-4b34-a51c-3e02e0e17438", "User", "USER" }
                });
        }
    }
}
