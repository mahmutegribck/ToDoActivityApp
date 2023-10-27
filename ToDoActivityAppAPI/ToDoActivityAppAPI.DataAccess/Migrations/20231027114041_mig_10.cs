using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "Location", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "89103445-90e2-4e2d-a29f-236dd1dfcb17", "", "AQAAAAIAAYagAAAAEKAStx+KEEF9jfz7BvLfe2ksKhtDFGskyMKx3yj0yqnNI6ucSdOSXr5DMeMqdorKKw==", "84be3d9a-9b23-4513-ada6-3b4fa66b4555" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "Location", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d6af0d3-d0d9-4c71-84e9-df2ae42349b1", null, "AQAAAAIAAYagAAAAECGRd+FcHKrw3M94n1jya2REnCCkkjiRmeVCXWd+hDqUFMtK/T8ygwVXa3wxeKfP5Q==", "871385e0-cee3-4b91-bed7-cddfdccde784" });
        }
    }
}
