using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EjercicioVideoclub.Migrations
{
    public partial class fechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRental",
                table: "UsersFilms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "UsersFilms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRental",
                table: "UsersFilms");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "UsersFilms");
        }
    }
}
