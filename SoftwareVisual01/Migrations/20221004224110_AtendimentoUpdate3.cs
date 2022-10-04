using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareVisual01.Migrations
{
    public partial class AtendimentoUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Atendimento",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "funcionario",
                table: "Atendimento",
                newName: "idFuncionario");

            migrationBuilder.RenameColumn(
                name: "cliente",
                table: "Atendimento",
                newName: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Atendimento",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "idFuncionario",
                table: "Atendimento",
                newName: "funcionario");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Atendimento",
                newName: "cliente");
        }
    }
}
