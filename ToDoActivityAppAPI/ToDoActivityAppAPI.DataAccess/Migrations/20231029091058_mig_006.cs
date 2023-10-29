using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2b18711-ee55-43e5-a76f-d5539f5f3693", "AQAAAAIAAYagAAAAEJYAkEYh4q5IivAJv4A/sgkfMblYtyQGqmWUvC+hVqx5PQ4VEbZ9u5ujZHHuPEkJJw==", "f4637a95-e5a7-4688-bc5b-c020ad4d76aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed42acf-b36f-4bb5-ad4d-4dcc60509b55", "AQAAAAIAAYagAAAAED3DZmKqZgR0Ea6oNhkrZmXrYVbQjGmnYZJ8ddV3FYe/qg0yVPoVWG0bbdJTzslUFA==", "aca8ddf3-07fc-4372-bbde-7e4e4d3bbc16" });
        }
    }
}
