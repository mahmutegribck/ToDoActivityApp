using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0c6948f-9fa9-4e1f-9a4f-bf823b7ace39", "AQAAAAIAAYagAAAAEEneb4htcdD1DzBhElDMbcBuj8CJI/v+2HUj2dLx2ungtbsGXrmPHe5q2xL1IsHpqQ==", "b9a9479d-2c2e-442d-90d2-247c96da98f9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae61023d-d606-4187-97f7-554e2c4f63ac", "AQAAAAIAAYagAAAAEKbz4HLN7ppxGZVTdczKDTeun/9vcmFYFy+AE7ixvgn5XrXMxlfQbln8hVhaeTkbzQ==", "9832094d-66e8-4197-a3a9-edbf2cff98a4" });
        }
    }
}
