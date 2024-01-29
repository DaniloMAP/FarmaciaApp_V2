using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApp_V2.Migrations
{
    /// <inheritdoc />
    public partial class AddReacoesAdversasToMedicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicamentoId",
                table: "MedicamentoReacaoAdversa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReacaoAdversaId",
                table: "MedicamentoReacaoAdversa",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoReacaoAdversa_MedicamentoId",
                table: "MedicamentoReacaoAdversa",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoReacaoAdversa_ReacaoAdversaId",
                table: "MedicamentoReacaoAdversa",
                column: "ReacaoAdversaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentoReacaoAdversa_Medicamentos_MedicamentoId",
                table: "MedicamentoReacaoAdversa",
                column: "MedicamentoId",
                principalTable: "Medicamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentoReacaoAdversa_ReacoesAdversas_ReacaoAdversaId",
                table: "MedicamentoReacaoAdversa",
                column: "ReacaoAdversaId",
                principalTable: "ReacoesAdversas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentoReacaoAdversa_Medicamentos_MedicamentoId",
                table: "MedicamentoReacaoAdversa");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentoReacaoAdversa_ReacoesAdversas_ReacaoAdversaId",
                table: "MedicamentoReacaoAdversa");

            migrationBuilder.DropIndex(
                name: "IX_MedicamentoReacaoAdversa_MedicamentoId",
                table: "MedicamentoReacaoAdversa");

            migrationBuilder.DropIndex(
                name: "IX_MedicamentoReacaoAdversa_ReacaoAdversaId",
                table: "MedicamentoReacaoAdversa");

            migrationBuilder.DropColumn(
                name: "MedicamentoId",
                table: "MedicamentoReacaoAdversa");

            migrationBuilder.DropColumn(
                name: "ReacaoAdversaId",
                table: "MedicamentoReacaoAdversa");
        }
    }
}
