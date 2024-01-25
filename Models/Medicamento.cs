namespace FarmaciaApp_V2.Models;

public class Medicamento

{
    public int Id { get; set; }
    public string NumeroRegistroAnvisa { get; set; }
    public string Nome { get; set; }
    public DateTime DataValidade { get; set; }
    public string TelefoneSAC { get; set; }
    public decimal PrecoReais { get; set; }
    public int QuantidadeComprimidos { get; set; }

    // Relacionamento com Fabricante
    public int FabricanteId { get; set; }
    public Fabricante Fabricante { get; set; }

    // Propriedade de navegação para ReacoesAdversas
    public ICollection<ReacaoAdversa> ReacoesAdversas { get; set; }
}
