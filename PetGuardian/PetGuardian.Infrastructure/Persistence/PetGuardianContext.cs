using Microsoft.EntityFrameworkCore;
using PetGuardian.Domain.Entities;
using PetGuardian.Infrastructure.Persistence.Configurations;

namespace PetGuardian.Infrastructure.Persistence;

/// <summary>
/// Contexto EF Core do projeto PetGuardian.
/// Usa Oracle como banco de dados (Oracle.EntityFrameworkCore).
/// </summary>
public class PetGuardianContext(DbContextOptions<PetGuardianContext> options) : DbContext(options)
{
    public DbSet<Endereco>    Enderecos    { get; set; }
    public DbSet<Familia>     Familias     { get; set; }
    public DbSet<Pet>         Pets         { get; set; }
    public DbSet<Usuario>     Usuarios     { get; set; }
    public DbSet<Veterinaria> Veterinarias { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Tarefa>      Tarefas      { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetGuardianContext).Assembly);
    }
}