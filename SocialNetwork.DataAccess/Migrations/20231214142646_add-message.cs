using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addmessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0d463e9c-7f56-486f-a574-f9c657094855");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9878da52-b772-4ae3-9a0e-b4b77c817156");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6745), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6747), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6748), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6748) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6749), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6750), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6750), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c9405156-0ce4-4198-9a37-cd8a2574ea8d", "452422fc-b571-4b34-9002-ba3b68886fc8", "Administrator", "ADMINISTRATOR" },
                    { "ee704529-f52c-4d0c-a106-9573b9a3790e", "4f4f478d-f2aa-4e55-8a80-6c012fa6f947", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c9405156-0ce4-4198-9a37-cd8a2574ea8d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ee704529-f52c-4d0c-a106-9573b9a3790e");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8916), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8917), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8918), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8919), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8919) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8920), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8919) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8920), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8920) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d463e9c-7f56-486f-a574-f9c657094855", "d86c0866-c570-4292-aadf-789227eb6c5f", "User", "USER" },
                    { "9878da52-b772-4ae3-9a0e-b4b77c817156", "2da30d1f-ce15-410c-8fbc-d91e66fbb4d9", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
