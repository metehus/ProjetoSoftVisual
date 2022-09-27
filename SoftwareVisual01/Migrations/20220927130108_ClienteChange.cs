using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareVisual01.Migrations
{
    public partial class ClienteChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Cliente_clienteid",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Funcionario_funcionarioid",
                table: "Atendimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Atendimentos",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Atendimentos",
                newName: "Atendimento");

            migrationBuilder.RenameColumn(
                name: "numeroCelular",
                table: "Cliente",
                newName: "telefone");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_funcionarioid",
                table: "Atendimento",
                newName: "IX_Atendimento_funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_clienteid",
                table: "Atendimento",
                newName: "IX_Atendimento_clienteid");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataAtendimento",
                table: "Atendimento",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Atendimento",
                table: "Atendimento",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Cliente_clienteid",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Funcionario_funcionarioid",
                table: "Atendimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Atendimento",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "dataAtendimento",
                table: "Atendimento");

            migrationBuilder.RenameTable(
                name: "Atendimento",
                newName: "Atendimentos");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Cliente",
                newName: "numeroCelular");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimento_funcionarioid",
                table: "Atendimentos",
                newName: "IX_Atendimentos_funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimento_clienteid",
                table: "Atendimentos",
                newName: "IX_Atendimentos_clienteid");

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Atendimentos",
                table: "Atendimentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Cliente_clienteid",
                table: "Atendimentos",
                column: "clienteid",
                principalTable: "Cliente",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Funcionario_funcionarioid",
                table: "Atendimentos",
                column: "funcionarioid",
                principalTable: "Funcionario",
                principalColumn: "id");
        }
    }
}
