using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addindexforcreatedAtcolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupInvites_UserId",
                table: "GroupInvites");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d26388c9-62e6-497a-b686-5e5d83a0ce4b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "edf1f3a4-a04d-415e-b12d-06ef5491b831");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8368), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8369) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8374), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8375), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8787), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8790), new DateTime(2024, 4, 24, 14, 27, 12, 780, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9407), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9409) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9413), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9413) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9415), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9415) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9416), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9417), new DateTime(2024, 4, 24, 14, 27, 12, 786, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8699), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8708), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8708) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8710), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8711), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8712), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8713) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8716), new DateTime(2024, 4, 24, 14, 27, 12, 796, DateTimeKind.Utc).AddTicks(8717) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59f4b7ed-ebf5-4058-b45e-b83d4decf4aa", "4bc5c642-b908-4f73-b444-59648d272825", "User", "USER" },
                    { "c6bfb902-7d9c-4783-9c58-bcb6353e2beb", "93d78ecf-f8da-4c42-a4c6-1da1488739db", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedAt",
                table: "Posts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_CreatedAt",
                table: "PostComments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedAt",
                table: "Notifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreatedAt",
                table: "Messages",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatedAt",
                table: "Groups",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_CreatedAt",
                table: "GroupMembers",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId_UserId",
                table: "GroupMembers",
                columns: new[] { "GroupId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupInvites_UserId_GroupId",
                table: "GroupInvites",
                columns: new[] { "UserId", "GroupId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_CreatedAt",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_CreatedAt",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CreatedAt",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CreatedAt",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatedAt",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_CreatedAt",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_GroupId_UserId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupInvites_UserId_GroupId",
                table: "GroupInvites");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "59f4b7ed-ebf5-4058-b45e-b83d4decf4aa");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c6bfb902-7d9c-4783-9c58-bcb6353e2beb");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4188), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4197), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4198), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5291), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5296), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5297) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2574), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2581), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2582) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2583), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2584), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2584) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2585), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2585) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3541), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3551), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3553), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3553) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3554), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3555) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3556), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3558), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3558) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d26388c9-62e6-497a-b686-5e5d83a0ce4b", "4cf8b535-8e4a-4bc0-8be0-d5e9fee904ef", "User", "USER" },
                    { "edf1f3a4-a04d-415e-b12d-06ef5491b831", "0138ed82-c970-41bc-b3cd-dc5edba42243", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupInvites_UserId",
                table: "GroupInvites",
                column: "UserId");
        }
    }
}
