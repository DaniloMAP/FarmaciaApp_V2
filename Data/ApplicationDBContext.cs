using FarmaciaApp_V2.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<Fabricante> Fabricantes { get; set; }
    public DbSet<ReacaoAdversa> ReacoesAdversas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração das relações entre as entidades Medicamento, Fabricante e ReacaoAdversa
        modelBuilder.Entity<Medicamento>()
            .HasOne(m => m.Fabricante)
            .WithMany()
            .HasForeignKey(m => m.FabricanteId);

        modelBuilder.Entity<Medicamento>()
            .HasMany(m => m.ReacoesAdversas)
            .WithMany(ra => ra.Medicamentos)
            .UsingEntity(j => j.ToTable("MedicamentoReacaoAdversa"));

        // Outras configurações do modelo, como chaves primárias, índices, etc.
    }

    public void Seed()
    {
        if (!Fabricantes.Any())
        {
            // Adicione os Fabricantes desejados aqui
            var fabricante1 = new Fabricante { Nome = "Fabricante 1" };
            var fabricante2 = new Fabricante { Nome = "Fabricante 2" };
            var fabricante3 = new Fabricante { Nome = "Fabricante 3" };

            Fabricantes.AddRange(fabricante1, fabricante2, fabricante3);
            SaveChanges();
        }
    }
}
