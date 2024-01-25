namespace FarmaciaApp_V2.Models;

public class ReacaoAdversa
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public ICollection<Medicamento> Medicamentos { get; set; }

     public ICollection<MedicamentoReacaoAdversa> MedicamentoReacoesAdversas { get; set; }
}
