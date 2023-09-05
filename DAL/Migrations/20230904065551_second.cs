using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1361), "isroilovravshan42@gmail.com", "Ravshan", "Isroilov", "1234", "+998902528196", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1364), "oybabd@gmail.com", "Oybek", "Abdurahmonov", "1234", "+998998721027", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1365), "Majidov@gmail.com", "Akbarali", "Majidov", "1234", "+998902528196", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1366), "buni@gmail.com", "Bunyod", "Toshmatov", "1234", "+998900207228", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1367), "otkir@gmail.com", "O'tkirbek", "Hamidov", "1234", "+998995629737", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
