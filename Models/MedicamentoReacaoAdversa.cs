using FarmaciaApp_V2.Models;

public class MedicamentoReacaoAdversa
{
    public int MedicamentosId { get; set; }
    public Medicamento Medicamento { get; set; }

    public int ReacoesAdversasId { get; set; }
    public ReacaoAdversa ReacaoAdversa { get; set; }
}