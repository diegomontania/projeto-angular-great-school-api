#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace GreatSchool.API.Migrations
{
    /// <inheritdoc />
    public partial class MelhorandoTelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DddTelefone",
                table: "Alunos",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DddTelefone",
                table: "Alunos");
        }
    }
}
