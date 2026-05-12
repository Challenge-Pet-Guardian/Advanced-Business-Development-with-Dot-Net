using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetGuardian.Domain.Entities;

namespace PetGuardian.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuração EF Core para a entidade <see cref="Usuario"/>.
/// Relacionamentos: N:1 com <see cref="Familia"/>, 1:1 com <see cref="Endereco"/>.
/// </summary>
public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("PG_USUARIOS");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("ID_USUARIO");

        builder.Property(u => u.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Senha)
            .HasColumnName("SENHA")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(u => u.Telefone)
            .HasColumnName("TELEFONE")
            .HasMaxLength(11)
            .IsRequired();



        // N:1
        builder.Property(u => u.FamiliaId)
            .HasColumnName("ID_FAMILIA")
            .IsRequired();

        builder.HasOne(u => u.Familia)
            .WithMany(f => f.Usuarios)
            .HasForeignKey(u => u.FamiliaId)
            .OnDelete(DeleteBehavior.Restrict);

        // 1:1
        builder.Property(u => u.EnderecoId)
            .HasColumnName("ID_ENDERECO")
            .IsRequired();

        builder.HasOne(u => u.Endereco)
            .WithOne()
            .HasForeignKey<Usuario>(u => u.EnderecoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(u => u.EnderecoId)
            .IsUnique();

        // 1:N
        builder.HasMany(u => u.Tarefas)
            .WithOne(t => t.Usuario)
            .HasForeignKey(t => t.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}