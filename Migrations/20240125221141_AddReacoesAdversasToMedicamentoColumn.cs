using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApp_V2.Migrations
{
    public partial class AddReacoesAdversasToMedicamentoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReacoesAdversas",
                table: "Medicamentos",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReacoesAdversas",
                table: "Medicamentos");
        }
    }
}
