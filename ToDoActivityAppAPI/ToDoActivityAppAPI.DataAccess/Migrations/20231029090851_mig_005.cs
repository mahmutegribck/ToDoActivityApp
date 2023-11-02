using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed42acf-b36f-4bb5-ad4d-4dcc60509b55", "AQAAAAIAAYagAAAAED3DZmKqZgR0Ea6oNhkrZmXrYVbQjGmnYZJ8ddV3FYe/qg0yVPoVWG0bbdJTzslUFA==", "aca8ddf3-07fc-4372-bbde-7e4e4d3bbc16" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0c6948f-9fa9-4e1f-9a4f-bf823b7ace39", "AQAAAAIAAYagAAAAEEneb4htcdD1DzBhElDMbcBuj8CJI/v+2HUj2dLx2ungtbsGXrmPHe5q2xL1IsHpqQ==", "b9a9479d-2c2e-442d-90d2-247c96da98f9" });
        }
    }
}
