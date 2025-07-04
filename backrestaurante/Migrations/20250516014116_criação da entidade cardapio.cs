﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoRestaurante.Migrations
{
    /// <inheritdoc />
    public partial class criaçãodaentidadecardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Misturas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guarnicoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cardapios");
        }
    }
}
