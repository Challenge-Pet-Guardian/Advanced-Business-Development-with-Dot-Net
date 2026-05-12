using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;
using PetGuardian.Domain.Enums;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF Core para a entidade <see cref="Pet"/>.
/// <see cref="PortePet"/> e <see cref="SexoPet"/> são persistidos como VARCHAR2 para legibilidade no Oracle.
/// </summary>
public sealed class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("PG_PETS");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("ID_PET");

        builder.Property(p => p.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(p => p.Raca)
            .HasColumnName("RACA")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Porte)
            .HasColumnName("PORTE")
            .HasMaxLength(20)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(p => p.Sexo)
            .HasColumnName("SEXO")
            .HasMaxLength(10)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(p => p.Idade)
            .HasColumnName("IDADE")
            .HasColumnType("NUMBER(2)")
            .IsRequired();

        builder.Property(p => p.Castrado)
            .HasColumnName("CASTRADO")
            .HasColumnType("NUMBER(1)")
            .IsRequired();

        // N:1
        builder.Property(p => p.FamiliaId)
            .HasColumnName("ID_FAMILIA")
            .IsRequired();

        builder.HasOne(p => p.Familia)
            .WithMany(f => f.Pets)
            .HasForeignKey(p => p.FamiliaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}