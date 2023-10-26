using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d6af0d3-d0d9-4c71-84e9-df2ae42349b1", "AQAAAAIAAYagAAAAECGRd+FcHKrw3M94n1jya2REnCCkkjiRmeVCXWd+hDqUFMtK/T8ygwVXa3wxeKfP5Q==", "871385e0-cee3-4b91-bed7-cddfdccde784" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aceb16ac-8940-4867-814a-dcb23eafe7ea", "AQAAAAIAAYagAAAAEHpBe1lMlDXO3p1c3Vr5a68GtNpHGkkayil959JhJQb3dCHtuZx/sEJeBwQmr8QaRA==", "14911ffd-f398-41c2-b924-4a7a6232163b" });
        }
    }
}
