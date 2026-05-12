using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGuardian.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PG_ENDERECOS",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    RUA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    BAIRRO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CIDADE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ESTADO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG_ENDERECOS", x => x.ID_ENDERECO);
                });

            migrationBuilder.CreateTable(
                name: "PG_FAMILIAS",
                columns: table => new
                {
                    ID_FAMILIA = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG_FAMILIAS", x => x.ID_FAMILIA);
                });

            migrationBuilder.CreateTable(
                name: "PG_VETERINARIAS",
                columns: table => new
                {
                    ID_VETERINARIA = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ID_ENDERECO = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG_VETERINARIAS", x => x.ID_VETERINARIA);
                    table.ForeignKey(
                        name: "FK_PG_VETERINARIAS_PG_ENDERECOS_ID_ENDERECO",
                        column: x => x.ID_ENDERECO,
                        principalTable: "PG_ENDERECOS",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PG_PETS",
                columns: table => new
                {
                    ID_PET = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    RACA = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    PORTE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    SEXO = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    IDADE = table.Column<byte>(type: "NUMBER(2)", nullable: false),
                    CASTRADO = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ID_FAMILIA = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG_PETS", x => x.ID_PET);
                    table.ForeignKey(
                        name: "FK_PG_PETS_PG_FAMILIAS_ID_FAMILIA",
                        column: x => x.ID_FAMILIA,
                        principalTable: "PG_FAMILIAS",
                        principalColumn: "ID_FAMILIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PG_USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    SENHA = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    ID_FAMILIA = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ID_ENDERECO = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG_USUARIOS", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK_PG_USUARIOS_PG_ENDERECOS_ID_ENDERECO",
                        column: x => x.ID_ENDERECO,
                        principalTable: "PG_ENDERECOS",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PG_USUARIOS_PG_FAMILIAS_ID_FAMILIA",
                        column: x => x.ID_FAMILIA,
                        principalTable: "PG_FAMILIAS",
                        principalColumn: "ID_FAMILIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PG_ATENDIMENTOS",
                columns: table => new
                {
                    ID_ATENDIMENTO = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TIPO_ATENDIMENTO = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DATA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ANOTACOES = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    VALOR = table.Column<decimal>(type: "NUMBER(10,2)", nullable: false),
                    ID_VETERINARIA = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ID_PET = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG_ATENDIMENTOS", x => x.ID_ATENDIMENTO);
                    table.ForeignKey(
                        name: "FK_PG_ATENDIMENTOS_PG_PETS_ID_PET",
                        column: x => x.ID_PET,
                        principalTable: "PG_PETS",
                        principalColumn: "ID_PET",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PG_ATENDIMENTOS_PG_VETERINARIAS_ID_VETERINARIA",
                        column: x => x.ID_VETERINARIA,
                        principalTable: "PG_VETERINARIAS",
                        principalColumn: "ID_VETERINARIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PG_TAREFAS",
                columns: table => new
                {
                    ID_TAREFA = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PRAZO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ID_USUARIO = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ID_PET = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ID_FAMILIA = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PG_TAREFAS", x => x.ID_TAREFA);
                    table.ForeignKey(
                        name: "FK_PG_TAREFAS_PG_FAMILIAS_ID_FAMILIA",
                        column: x => x.ID_FAMILIA,
                        principalTable: "PG_FAMILIAS",
                        principalColumn: "ID_FAMILIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PG_TAREFAS_PG_PETS_ID_PET",
                        column: x => x.ID_PET,
                        principalTable: "PG_PETS",
                        principalColumn: "ID_PET",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PG_TAREFAS_PG_USUARIOS_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "PG_USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PG_ATENDIMENTOS_ID_PET",
                table: "PG_ATENDIMENTOS",
                column: "ID_PET");

            migrationBuilder.CreateIndex(
                name: "IX_PG_ATENDIMENTOS_ID_VETERINARIA",
                table: "PG_ATENDIMENTOS",
                column: "ID_VETERINARIA");

            migrationBuilder.CreateIndex(
                name: "IX_PG_PETS_ID_FAMILIA",
                table: "PG_PETS",
                column: "ID_FAMILIA");

            migrationBuilder.CreateIndex(
                name: "IX_PG_TAREFAS_ID_FAMILIA",
                table: "PG_TAREFAS",
                column: "ID_FAMILIA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PG_TAREFAS_ID_PET",
                table: "PG_TAREFAS",
                column: "ID_PET");

            migrationBuilder.CreateIndex(
                name: "IX_PG_TAREFAS_ID_USUARIO",
                table: "PG_TAREFAS",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_PG_USUARIOS_EMAIL",
                table: "PG_USUARIOS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PG_USUARIOS_ID_ENDERECO",
                table: "PG_USUARIOS",
                column: "ID_ENDERECO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PG_USUARIOS_ID_FAMILIA",
                table: "PG_USUARIOS",
                column: "ID_FAMILIA");

            migrationBuilder.CreateIndex(
                name: "IX_PG_VETERINARIAS_ID_ENDERECO",
                table: "PG_VETERINARIAS",
                column: "ID_ENDERECO",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PG_ATENDIMENTOS");

            migrationBuilder.DropTable(
                name: "PG_TAREFAS");

            migrationBuilder.DropTable(
                name: "PG_VETERINARIAS");

            migrationBuilder.DropTable(
                name: "PG_PETS");

            migrationBuilder.DropTable(
                name: "PG_USUARIOS");

            migrationBuilder.DropTable(
                name: "PG_ENDERECOS");

            migrationBuilder.DropTable(
                name: "PG_FAMILIAS");
        }
    }
}
