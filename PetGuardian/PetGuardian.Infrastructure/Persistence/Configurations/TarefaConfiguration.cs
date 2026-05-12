using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF Core para a entidade <see cref="Tarefa"/>.
/// <see cref="StatusTarefa"/> é persistido como VARCHAR2 para legibilidade no Oracle.
/// </summary>
public sealed class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("PG_TAREFAS");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("ID_TAREFA");

        builder.Property(t => t.Titulo)
            .HasColumnName("TITULO")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(t => t.Descricao)
            .HasColumnName("DESCRICAO")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Criacao)
            .HasColumnName("CRIACAO")
            .IsRequired();

        builder.Property(t => t.Prazo)
            .HasColumnName("PRAZO")
            .IsRequired();

        builder.Property(t => t.Status)
            .HasColumnName("STATUS")
            .HasMaxLength(20)
            .HasConversion<string>()
            .IsRequired();



        // N:1
        builder.Property(t => t.UsuarioId)
            .HasColumnName("ID_USUARIO")
            .IsRequired();

        // N:1 
        builder.Property(t => t.PetId)
            .HasColumnName("ID_PET")
            .IsRequired();

        builder.HasOne(t => t.Pet)
            .WithMany(p => p.Tarefas)
            .HasForeignKey(t => t.PetId)
            .OnDelete(DeleteBehavior.Cascade);

        // N:1 
        builder.Property(t => t.FamiliaId)
            .HasColumnName("ID_FAMILIA")
            .IsRequired();

        builder.HasOne(t => t.Familia)
            .WithOne()
            .HasForeignKey<Tarefa>(t => t.FamiliaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}