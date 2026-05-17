using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

public sealed class FamiliaConfiguration : IEntityTypeConfiguration<Familia>
{
    public void Configure(EntityTypeBuilder<Familia> builder)
    {
        builder.ToTable("PG_FAMILIAS");
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).HasColumnName("ID_FAMILIA");
        builder.Property(f => f.NomeFamilia).HasColumnName("NOME_FAMILIA").HasMaxLength(30).IsRequired();

        builder.HasOne(f => f.Sequencia)
            .WithOne(s => s.Familia)
            .HasForeignKey<Sequencia>(s => s.FamiliaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}