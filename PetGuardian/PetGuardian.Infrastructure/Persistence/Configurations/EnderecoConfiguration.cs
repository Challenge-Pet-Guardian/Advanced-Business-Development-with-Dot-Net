using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF Core para a entidade <see cref="Endereco"/>.
/// Usada tanto por <see cref="Usuario"/> quanto por <see cref="Veterinaria"/> via FK exclusiva (1:1).
/// </summary>
public sealed class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("PG_ENDERECOS");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID_ENDERECO");

        builder.Property(e => e.Rua)
            .HasColumnName("RUA")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Bairro)
            .HasColumnName("BAIRRO")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Cidade)
            .HasColumnName("CIDADE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Estado)
            .HasColumnName("ESTADO")
            .HasMaxLength(50)
            .IsRequired();
        
    }
}