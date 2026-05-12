using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF Core para a entidade <see cref="Familia"/>.
/// </summary>
public sealed class FamiliaConfiguration : IEntityTypeConfiguration<Familia>
{
    public void Configure(EntityTypeBuilder<Familia> builder)
    {
        builder.ToTable("PG_FAMILIAS");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .HasColumnName("ID_FAMILIA");

        builder.Property(f => f.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(30)
            .IsRequired();
    }
}