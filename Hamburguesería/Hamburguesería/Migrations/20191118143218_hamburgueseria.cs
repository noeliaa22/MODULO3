using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamburguesería.Migrations
{
    public partial class hamburgueseria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    IngredientesPrincipales = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    IngredientesPrincipales = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Principales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    IngredientesPrincipales = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PrecioTotal = table.Column<double>(nullable: false),
                    PrincipalId = table.Column<int>(nullable: true),
                    EntranteId = table.Column<int>(nullable: true),
                    PostreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Entrantes_EntranteId",
                        column: x => x.EntranteId,
                        principalTable: "Entrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Postres_PostreId",
                        column: x => x.PostreId,
                        principalTable: "Postres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Principales_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "Principales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_EntranteId",
                table: "Menus",
                column: "EntranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PostreId",
                table: "Menus",
                column: "PostreId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PrincipalId",
                table: "Menus",
                column: "PrincipalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Entrantes");

            migrationBuilder.DropTable(
                name: "Postres");

            migrationBuilder.DropTable(
                name: "Principales");
        }
    }
}
