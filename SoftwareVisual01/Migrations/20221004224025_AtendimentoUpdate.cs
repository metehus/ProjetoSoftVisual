using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareVisual01.Migrations
{
    public partial class AtendimentoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Cliente_clienteid",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Funcionario_funcionarioid",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_clienteid",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_funcionarioid",
                table: "Atendimento");

            migrationBuilder.RenameColumn(
                name: "funcionarioid",
                table: "Atendimento",
                newName: "funcionario");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "Atendimento",
                newName: "cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "funcionario",
                table: "Atendimento",
                newName: "funcionarioid");

            migrationBuilder.RenameColumn(
                name: "cliente",
                table: "Atendimento",
                newName: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_clienteid",
                table: "Atendimento",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_funcionarioid",
                table: "Atendimento",
                column: "funcionarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Cliente_clienteid",
                table: "Atendimento",
                column: "clienteid",
                principalTable: "Cliente",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Funcionario_funcionarioid",
                table: "Atendimento",
                column: "funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id");
        }
    }
}
