using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addgroupinvitetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1d74b0dd-8588-46a5-921b-d3ccb45ca090");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "585e975c-fec3-4100-9a67-29d4493c0ad0");

            migrationBuilder.CreateTable(
                name: "GroupInvites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupInvites_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupInvites_Users_UserId",
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
                name: "IX_GroupInvites_GroupId",
                table: "GroupInvites",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupInvites_UserId",
                table: "GroupInvites",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupInvites");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "08aaad91-3138-4e2e-b4de-9121841f7631");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0d12d49f-93c1-4fe3-b045-d0b2f8567772");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2099), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2103) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2106), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2108), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2711), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2712) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2714), new DateTime(2024, 4, 1, 13, 20, 58, 815, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4663), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4666) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4669), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4669) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4670), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4671), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4672), new DateTime(2024, 4, 1, 13, 20, 58, 816, DateTimeKind.Utc).AddTicks(4673) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(440), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(441) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(446), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(447) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(448), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(450), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(451), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(451) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(453), new DateTime(2024, 4, 1, 13, 20, 58, 826, DateTimeKind.Utc).AddTicks(453) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d74b0dd-8588-46a5-921b-d3ccb45ca090", "5527da85-09b2-4d10-947c-247724d70223", "User", "USER" },
                    { "585e975c-fec3-4100-9a67-29d4493c0ad0", "d5f39d90-c038-42f4-881b-25f51e196a22", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
