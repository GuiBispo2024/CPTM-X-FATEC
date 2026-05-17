using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateEfluente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PT_EFLUENTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TX_NOME_CONTRATADA = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    TX_NUMERO_CONTRATO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TX_PROGRAMA_AMBIENTAL = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    TX_NATUREZA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TX_LINHA_CPTM = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TX_VIA_CPTM = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TX_MUNICIPIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TX_ENDERECO = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false),
                    TX_COORDENADA_GEOGRAFICA = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    TX_TIPO_EFLUENTE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TX_STATUS_DESVIO_AMBIENTAL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TX_OBSERVACAO = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: false),
                    DT_DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_EFLUENTE", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PT_EFLUENTE");
        }
    }
}
