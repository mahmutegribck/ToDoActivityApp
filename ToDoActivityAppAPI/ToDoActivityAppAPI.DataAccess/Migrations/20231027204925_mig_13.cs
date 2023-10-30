using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Activities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7bf1a2b-4fcd-47e9-b8ad-e9d86c71335b", "AQAAAAIAAYagAAAAECA8gPmGHdQK4sSjr4vp++Zqn0Fa9WP1skxtaIHvoYDl6bgOvx64zjFmvkSh5+e7XA==", "ced74dbd-8d90-4027-8c24-ad9acd709853" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebafb324-3bb4-479a-bd18-b4f73178812b", "AQAAAAIAAYagAAAAEKxD9qEmNdf1L/nhPgBYclhysAxDYjNNm71WyLk1KhzlbUpd6GZf2MYQSM4PlqOixw==", "1bebc3f8-9f9b-448d-8a35-ee38942075a5" });
        }
    }
}
