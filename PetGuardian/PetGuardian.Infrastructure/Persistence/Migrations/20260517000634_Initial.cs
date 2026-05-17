using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGuardian.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PG_PETS_PG_FAMILIAS_ID_FAMILIA",
                table: "PG_PETS");

            migrationBuilder.DropForeignKey(
                name: "FK_PG_TAREFAS_PG_FAMILIAS_ID_FAMILIA",
                table: "PG_TAREFAS");

            migrationBuilder.DropColumn(
                name: "TELEFONE",
                table: "PG_USUARIOS");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "PG_TAREFAS");

            migrationBuilder.DropColumn(
                name: "RACA",
                table: "PG_PETS");

            migrationBuilder.DropColumn(
                name: "BAIRRO",
                table: "PG_ENDERECOS");

            migrationBuilder.DropColumn(
                name: "CIDADE",
                table: "PG_ENDERECOS");

            migrationBuilder.DropColumn(
                name: "ESTADO",
                table: "PG_ENDERECOS");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.DropColumn(
                name: "TIPO_ATENDIMENTO",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.RenameColumn(
                name: "ID_FAMILIA",
                table: "PG_TAREFAS",
                newName: "ID_STATUS");

            migrationBuilder.RenameIndex(
                name: "IX_PG_TAREFAS_ID_FAMILIA",
                table: "PG_TAREFAS",
                newName: "IX_PG_TAREFAS_ID_STATUS");

            migrationBuilder.RenameColumn(
                name: "ID_FAMILIA",
                table: "PG_PETS",
                newName: "ID_RACA");

            migrationBuilder.RenameIndex(
                name: "IX_PG_PETS_ID_FAMILIA",
                table: "PG_PETS",
                newName: "IX_PG_PETS_ID_RACA");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "PG_FAMILIAS",
                newName: "NOME_FAMILIA");

            migrationBuilder.AddColumn<Guid>(
                name: "ID_TELEFONE",
                table: "PG_VETERINARIAS",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_TELEFONE",
                table: "PG_USUARIOS",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte>(
                name: "PONTOS_TAREFA",
                table: "PG_TAREFAS",
                type: "NUMBER(3)",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "SEXO",
                table: "PG_PETS",
                type: "NVARCHAR2(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "PORTE",
                table: "PG_PETS",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "CASTRADO",
                table: "PG_PETS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "RUA",
                table: "PG_ENDERECOS",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "PG_ENDERECOS",
                type: "NVARCHAR2(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ID_BAIRRO",
                table: "PG_ENDERECOS",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_STATUS",
                table: "PG_ATENDIMENTOS",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_TIPO_ATEND",
                table: "PG_ATENDIMENTOS",
                type: "RAW(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NomeEstado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoPontos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    PontosGanhos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TarefaId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoPontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoPontos_PG_TAREFAS_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "PG_TAREFAS",
                        principalColumn: "ID_TAREFA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoPontos_PG_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "PG_USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontosTotais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    QtdPontos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosTotais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontosTotais_PG_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "PG_USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NomeRaca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sequencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SequenciaAtual = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SequenciaMaxima = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataUltimaAcao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FamiliaId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sequencias_PG_FAMILIAS_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "PG_FAMILIAS",
                        principalColumn: "ID_FAMILIA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NumDdd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumTel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAtend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAtend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPets",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    PetId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ResponPrinc = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPets", x => new { x.UsuarioId, x.PetId });
                    table.ForeignKey(
                        name: "FK_UsuarioPets_PG_PETS_PetId",
                        column: x => x.PetId,
                        principalTable: "PG_PETS",
                        principalColumn: "ID_PET",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPets_PG_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "PG_USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NomeCidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EstadoId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bairros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NomeBairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CidadeId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bairros_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PG_VETERINARIAS_ID_TELEFONE",
                table: "PG_VETERINARIAS",
                column: "ID_TELEFONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PG_USUARIOS_ID_TELEFONE",
                table: "PG_USUARIOS",
                column: "ID_TELEFONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PG_ENDERECOS_ID_BAIRRO",
                table: "PG_ENDERECOS",
                column: "ID_BAIRRO");

            migrationBuilder.CreateIndex(
                name: "IX_PG_ATENDIMENTOS_ID_STATUS",
                table: "PG_ATENDIMENTOS",
                column: "ID_STATUS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PG_ATENDIMENTOS_ID_TIPO_ATEND",
                table: "PG_ATENDIMENTOS",
                column: "ID_TIPO_ATEND",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_CidadeId",
                table: "Bairros",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoPontos_TarefaId",
                table: "HistoricoPontos",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoPontos_UsuarioId",
                table: "HistoricoPontos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosTotais_UsuarioId",
                table: "PontosTotais",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sequencias_FamiliaId",
                table: "Sequencias",
                column: "FamiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPets_PetId",
                table: "UsuarioPets",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PG_ATENDIMENTOS_Status_ID_STATUS",
                table: "PG_ATENDIMENTOS",
                column: "ID_STATUS",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PG_ATENDIMENTOS_TipoAtend_ID_TIPO_ATEND",
                table: "PG_ATENDIMENTOS",
                column: "ID_TIPO_ATEND",
                principalTable: "TipoAtend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PG_ENDERECOS_Bairros_ID_BAIRRO",
                table: "PG_ENDERECOS",
                column: "ID_BAIRRO",
                principalTable: "Bairros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PG_PETS_Racas_ID_RACA",
                table: "PG_PETS",
                column: "ID_RACA",
                principalTable: "Racas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PG_TAREFAS_Status_ID_STATUS",
                table: "PG_TAREFAS",
                column: "ID_STATUS",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PG_USUARIOS_Telefones_ID_TELEFONE",
                table: "PG_USUARIOS",
                column: "ID_TELEFONE",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PG_VETERINARIAS_Telefones_ID_TELEFONE",
                table: "PG_VETERINARIAS",
                column: "ID_TELEFONE",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PG_ATENDIMENTOS_Status_ID_STATUS",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PG_ATENDIMENTOS_TipoAtend_ID_TIPO_ATEND",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PG_ENDERECOS_Bairros_ID_BAIRRO",
                table: "PG_ENDERECOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PG_PETS_Racas_ID_RACA",
                table: "PG_PETS");

            migrationBuilder.DropForeignKey(
                name: "FK_PG_TAREFAS_Status_ID_STATUS",
                table: "PG_TAREFAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PG_USUARIOS_Telefones_ID_TELEFONE",
                table: "PG_USUARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PG_VETERINARIAS_Telefones_ID_TELEFONE",
                table: "PG_VETERINARIAS");

            migrationBuilder.DropTable(
                name: "Bairros");

            migrationBuilder.DropTable(
                name: "HistoricoPontos");

            migrationBuilder.DropTable(
                name: "PontosTotais");

            migrationBuilder.DropTable(
                name: "Racas");

            migrationBuilder.DropTable(
                name: "Sequencias");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "TipoAtend");

            migrationBuilder.DropTable(
                name: "UsuarioPets");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_PG_VETERINARIAS_ID_TELEFONE",
                table: "PG_VETERINARIAS");

            migrationBuilder.DropIndex(
                name: "IX_PG_USUARIOS_ID_TELEFONE",
                table: "PG_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_PG_ENDERECOS_ID_BAIRRO",
                table: "PG_ENDERECOS");

            migrationBuilder.DropIndex(
                name: "IX_PG_ATENDIMENTOS_ID_STATUS",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.DropIndex(
                name: "IX_PG_ATENDIMENTOS_ID_TIPO_ATEND",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.DropColumn(
                name: "ID_TELEFONE",
                table: "PG_VETERINARIAS");

            migrationBuilder.DropColumn(
                name: "ID_TELEFONE",
                table: "PG_USUARIOS");

            migrationBuilder.DropColumn(
                name: "PONTOS_TAREFA",
                table: "PG_TAREFAS");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "PG_ENDERECOS");

            migrationBuilder.DropColumn(
                name: "ID_BAIRRO",
                table: "PG_ENDERECOS");

            migrationBuilder.DropColumn(
                name: "ID_STATUS",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.DropColumn(
                name: "ID_TIPO_ATEND",
                table: "PG_ATENDIMENTOS");

            migrationBuilder.RenameColumn(
                name: "ID_STATUS",
                table: "PG_TAREFAS",
                newName: "ID_FAMILIA");

            migrationBuilder.RenameIndex(
                name: "IX_PG_TAREFAS_ID_STATUS",
                table: "PG_TAREFAS",
                newName: "IX_PG_TAREFAS_ID_FAMILIA");

            migrationBuilder.RenameColumn(
                name: "ID_RACA",
                table: "PG_PETS",
                newName: "ID_FAMILIA");

            migrationBuilder.RenameIndex(
                name: "IX_PG_PETS_ID_RACA",
                table: "PG_PETS",
                newName: "IX_PG_PETS_ID_FAMILIA");

            migrationBuilder.RenameColumn(
                name: "NOME_FAMILIA",
                table: "PG_FAMILIAS",
                newName: "NOME");

            migrationBuilder.AddColumn<string>(
                name: "TELEFONE",
                table: "PG_USUARIOS",
                type: "NVARCHAR2(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "PG_TAREFAS",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SEXO",
                table: "PG_PETS",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "PORTE",
                table: "PG_PETS",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "CASTRADO",
                table: "PG_PETS",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER");

            migrationBuilder.AddColumn<string>(
                name: "RACA",
                table: "PG_PETS",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RUA",
                table: "PG_ENDERECOS",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "BAIRRO",
                table: "PG_ENDERECOS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CIDADE",
                table: "PG_ENDERECOS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ESTADO",
                table: "PG_ENDERECOS",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "PG_ATENDIMENTOS",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TIPO_ATENDIMENTO",
                table: "PG_ATENDIMENTOS",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PG_PETS_PG_FAMILIAS_ID_FAMILIA",
                table: "PG_PETS",
                column: "ID_FAMILIA",
                principalTable: "PG_FAMILIAS",
                principalColumn: "ID_FAMILIA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PG_TAREFAS_PG_FAMILIAS_ID_FAMILIA",
                table: "PG_TAREFAS",
                column: "ID_FAMILIA",
                principalTable: "PG_FAMILIAS",
                principalColumn: "ID_FAMILIA",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
