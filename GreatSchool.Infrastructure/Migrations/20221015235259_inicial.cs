using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreatSchool.API.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    SobreNome = table.Column<string>(maxLength: 50, nullable: true),
                    Disciplina = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Turno = table.Column<string>(maxLength: 10, nullable: true),
                    Ano = table.Column<int>(maxLength: 4, nullable: false),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 2, nullable: true),
                    DataMatricula = table.Column<DateTime>(type: "Date", nullable: false),
                    TurmaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
