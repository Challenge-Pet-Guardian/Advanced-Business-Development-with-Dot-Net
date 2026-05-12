using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF Core para a entidade <see cref="Atendimento"/>.
/// <see cref="TipoAtendimento"/> e <see cref="StatusAtendimento"/> são persistidos
/// como VARCHAR2 para legibilidade no Oracle.
/// </summary>
public sealed class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder.ToTable("PG_ATENDIMENTOS");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("ID_ATENDIMENTO");

        builder.Property(a => a.TipoAtendimento)
            .HasColumnName("TIPO_ATENDIMENTO")
            .HasMaxLength(30)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.Data)
            .HasColumnName("DATA")
            .IsRequired();

        builder.Property(a => a.Anotacoes)
            .HasColumnName("ANOTACOES")
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(a => a.Status)
            .HasColumnName("STATUS")
            .HasMaxLength(30)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.Valor)
            .HasColumnName("VALOR")
            .HasColumnType("NUMBER(10,2)")
            .IsRequired();



        // N:1
        builder.Property(a => a.VeterinariaId)
            .HasColumnName("ID_VETERINARIA")
            .IsRequired();

        // N:1 
        builder.Property(a => a.PetId)
            .HasColumnName("ID_PET")
            .IsRequired();

        builder.HasOne(a => a.Pet)
            .WithMany(p => p.Atendimentos)
            .HasForeignKey(a => a.PetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}