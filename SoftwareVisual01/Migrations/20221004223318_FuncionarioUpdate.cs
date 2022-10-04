using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareVisual01.Migrations
{
    public partial class FuncionarioUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpf",
                table: "Funcionario");

            migrationBuilder.RenameColumn(
                name: "numeroCelular",
                table: "Funcionario",
                newName: "telefone");

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "Atendimento",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Funcionario",
                newName: "numeroCelular");

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "Funcionario",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tipo",
                table: "Atendimento",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
