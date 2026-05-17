using Microsoft.EntityFrameworkCore;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence;

/// <summary>
/// Contexto EF Core do projeto PetGuardian (Oracle).
/// </summary>
public class PetGuardianContext(DbContextOptions<PetGuardianContext> options) : DbContext(options)
{
    // Hierarquia de endereço
    public DbSet<Estado>   Estados   { get; set; }
    public DbSet<Cidade>   Cidades   { get; set; }
    public DbSet<Bairro>   Bairros   { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    // Lookup
    public DbSet<Raca>     Racas     { get; set; }
    public DbSet<Status>   Status    { get; set; }
    public DbSet<TipoAtend> TipoAtend { get; set; }
    public DbSet<Telefone> Telefones { get; set; }

    // Core
    public DbSet<Familia>    Familias    { get; set; }
    public DbSet<Usuario>    Usuarios    { get; set; }
    public DbSet<Pet>        Pets        { get; set; }
    public DbSet<Veterinaria> Veterinarias { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Tarefa>     Tarefas     { get; set; }

    // Gamificação / join
    public DbSet<UsuarioPet>     UsuarioPets     { get; set; }
    public DbSet<HistoricoPontos> HistoricoPontos { get; set; }
    public DbSet<PontosTotais>   PontosTotais    { get; set; }
    public DbSet<Sequencia>      Sequencias      { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioPet>()
            .HasKey(up => new { up.UsuarioId, up.PetId });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetGuardianContext).Assembly);
    }
}