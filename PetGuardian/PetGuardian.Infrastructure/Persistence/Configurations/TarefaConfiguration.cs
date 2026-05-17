using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

public sealed class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("PG_TAREFAS");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("ID_TAREFA");

        builder.Property(t => t.Titulo).HasColumnName("TITULO").HasMaxLength(30).IsRequired();
        builder.Property(t => t.PontosTarefa).HasColumnName("PONTOS_TAREFA").HasColumnType("NUMBER(3)").IsRequired();
        builder.Property(t => t.Descricao).HasColumnName("DESCRICAO").HasMaxLength(200).IsRequired();
        builder.Property(t => t.Criacao).HasColumnName("CRIACAO").IsRequired();
        builder.Property(t => t.Prazo).HasColumnName("PRAZO").IsRequired();

        builder.Property(t => t.PetId).HasColumnName("ID_PET").IsRequired();
        builder.Property(t => t.UsuarioId).HasColumnName("ID_USUARIO").IsRequired();

        builder.Property(t => t.StatusId).HasColumnName("ID_STATUS").IsRequired();
        builder.HasOne(t => t.Status)
            .WithMany(s => s.Tarefas)
            .HasForeignKey(t => t.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(t => t.StatusId).IsUnique();

        builder.HasMany(t => t.HistoricoPontos)
            .WithOne(h => h.Tarefa)
            .HasForeignKey(h => h.TarefaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}