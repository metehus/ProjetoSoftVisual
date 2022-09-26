using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareVisual01.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    numeroCelular = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    numeroCelular = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clienteid = table.Column<uint>(type: "INTEGER", nullable: true),
                    funcionarioid = table.Column<uint>(type: "INTEGER", nullable: true),
                    tipo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Atendimentos_Funcionario_funcionarioid",
                        column: x => x.funcionarioid,
                        principalTable: "Funcionario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_clienteid",
                table: "Atendimentos",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_funcionarioid",
                table: "Atendimentos",
                column: "funcionarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
