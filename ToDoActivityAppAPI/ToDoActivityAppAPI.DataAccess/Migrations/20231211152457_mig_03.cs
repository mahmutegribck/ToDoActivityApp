using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cdbe457-2e05-4abc-94a8-38f1b7950784", "AQAAAAIAAYagAAAAEAoeeyAWP3FtTerMtOFu9CTksnKq5rBMCanpzB5hD/CVzffOvY31ean7EwplyC6Jcg==", "c8b8a9d7-0c30-4eca-9b42-b46961d6685a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dac14a5-f937-474c-accc-3a6d86769828", "AQAAAAIAAYagAAAAECFr5uyfItRYI1HUJaVhRflsTGl/gSqa9+AehckVZqep1QNk6l+qA4JlsB/qT3d7hw==", "7b3aa911-1bb3-4a40-8e75-daad58728424" });
        }
    }
}
