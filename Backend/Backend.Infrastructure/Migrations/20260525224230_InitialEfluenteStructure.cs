using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialEfluenteStructure : Migration
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
                    SYNC_ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SYNC_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOME_CONTRATADA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    NUMERO_CONTRATO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    SIGLA_DEPTO_MA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    AREA_GESTORA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DIRETORIA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PROGRAMA_AMBIENTAL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    NATUREZA_PGA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    MUNICIPIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    LINHA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    VIA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TRECHO_SENTIDO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    ESTACAO_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    COORDENADA_GEO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TIPO_ATIVIDADE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TIPO_DRA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TIPO_ATIVIDADE_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    NM_LOCAL_ATIVIDADE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    ORIGEM_EFLUENTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    FONTE_GERADORA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TIPO_DESTINACAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TIPO_VEICULO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    STATUS_DESVIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    STATUS_REGISTRO_BD = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    OBSERVACAO = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IS_DELETED = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_EFLUENTE", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PT_EFLUENTE_SYNC_ID",
                table: "PT_EFLUENTE",
                column: "SYNC_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PT_EFLUENTE");
        }
    }
}
