using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

public sealed class VeterinariaConfiguration : IEntityTypeConfiguration<Veterinaria>
{
    public void Configure(EntityTypeBuilder<Veterinaria> builder)
    {
        builder.ToTable("PG_VETERINARIAS");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).HasColumnName("ID_VETERINARIA");
        builder.Property(v => v.Nome).HasColumnName("NOME").HasMaxLength(30).IsRequired();

        builder.Property(v => v.EnderecoId).HasColumnName("ID_ENDERECO").IsRequired();
        builder.HasOne(v => v.Endereco)
            .WithOne()
            .HasForeignKey<Veterinaria>(v => v.EnderecoId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(v => v.EnderecoId).IsUnique();

        builder.Property(v => v.TelefoneId).HasColumnName("ID_TELEFONE").IsRequired();
        builder.HasOne(v => v.Telefone)
            .WithOne()
            .HasForeignKey<Veterinaria>(v => v.TelefoneId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(v => v.TelefoneId).IsUnique();

        builder.HasMany(v => v.Atendimentos)
            .WithOne(a => a.Veterinaria)
            .HasForeignKey(a => a.VeterinariaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}