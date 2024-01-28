using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addmediatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageTypes_MessageTypeId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "54f9c606-52d1-4de4-91ea-9e3e1dd34065");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "57e17f85-6e4f-4c1d-862b-3b0b52b4c2e6");

            migrationBuilder.RenameColumn(
                name: "MessageTypeId",
                table: "Messages",
                newName: "MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages",
                newName: "IX_Messages_MediaTypeId");

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostMedias_MediaTypes_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "MediaTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostMedias_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5044), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5050), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5051), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5570), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5574), new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(5575) });

            migrationBuilder.InsertData(
                table: "MediaTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6003), "Text", 1, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6004) },
                    { 2, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6008), "Image", 1, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6008) },
                    { 3, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6009), "Video", 1, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6009) },
                    { 4, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6010), "File", 1, new DateTime(2024, 1, 28, 10, 1, 1, 84, DateTimeKind.Utc).AddTicks(6010) }
                });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6859), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6863), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6864), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6865), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6865), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6868), new DateTime(2024, 1, 28, 10, 1, 1, 90, DateTimeKind.Utc).AddTicks(6868) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "514982c2-52c8-4ba2-98b7-c6f49b57e5d6", "20539327-09b3-46bf-ad61-7bcb3725b435", "User", "USER" },
                    { "b30763c5-dd0c-4c91-a9d6-ec86ca7d9c10", "c240dcea-ed27-41e6-b52e-af2125a58041", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostMedias_MediaTypeId",
                table: "PostMedias",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedias_PostId",
                table: "PostMedias",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MediaTypes_MediaTypeId",
                table: "Messages",
                column: "MediaTypeId",
                principalTable: "MediaTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MediaTypes_MediaTypeId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "PostMedias");

            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "514982c2-52c8-4ba2-98b7-c6f49b57e5d6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b30763c5-dd0c-4c91-a9d6-ec86ca7d9c10");

            migrationBuilder.RenameColumn(
                name: "MediaTypeId",
                table: "Messages",
                newName: "MessageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MediaTypeId",
                table: "Messages",
                newName: "IX_Messages_MessageTypeId");

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4060), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4063) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4067), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4067) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4068), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4653), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4657), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4657) });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7060), "Text", 1, new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7063) },
                    { 2, new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7067), "Video", 1, new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7068) },
                    { 3, new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7069), "Image", 1, new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7069) }
                });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8490), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8493) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8497), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8497) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8498), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8499), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8499) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8500), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8503), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8503) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54f9c606-52d1-4de4-91ea-9e3e1dd34065", "06839c9c-3d7d-42ec-b0f3-582f9d02139b", "User", "USER" },
                    { "57e17f85-6e4f-4c1d-862b-3b0b52b4c2e6", "255e2137-bb85-4638-94c7-e63b7891e56d", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageTypes_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId",
                principalTable: "MessageTypes",
                principalColumn: "Id");
        }
    }
}
