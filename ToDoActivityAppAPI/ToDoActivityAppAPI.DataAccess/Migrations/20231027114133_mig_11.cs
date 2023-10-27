using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoActivityAppAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2023, 10, 27, 14, 41, 32, 852, DateTimeKind.Local).AddTicks(1040), "354b6a14-2b94-4888-80f2-9f1d3089b1c4", "AQAAAAIAAYagAAAAEFGbyi2cxUldyO00MTycFzvmJBjkIB1lvIYkEVzANWBEfTbniS2WCd6yy+fMWeVQSw==", "9311fd4b-9eb2-48c5-b73d-a503083deef4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "89103445-90e2-4e2d-a29f-236dd1dfcb17", "AQAAAAIAAYagAAAAEKAStx+KEEF9jfz7BvLfe2ksKhtDFGskyMKx3yj0yqnNI6ucSdOSXr5DMeMqdorKKw==", "84be3d9a-9b23-4513-ada6-3b4fa66b4555" });
        }
    }
}
