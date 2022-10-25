using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace curso_APICore_01.Migrations
{
    public partial class AdicionaGerenteaoCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_GerenteId",
                table: "Cinemas",
                column: "GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerente_GerenteId",
                table: "Cinemas",
                column: "GerenteId",
                principalTable: "Gerente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerente_GerenteId",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_GerenteId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "GerenteId",
                table: "Cinemas");
        }
    }
}
