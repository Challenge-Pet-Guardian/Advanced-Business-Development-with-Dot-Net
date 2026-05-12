using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Usuário do sistema. Pertence a uma <see cref="Familia"/>, possui um
/// <see cref="Endereco"/> exclusivo (1:1) e pode ser responsável por tarefas de cuidado.
/// </summary>
/// <remarks>
/// A senha é armazenada como texto no banco (restrição do modelo Oracle: VARCHAR2(20)).
/// Em ambiente produtivo recomenda-se ampliar o campo e aplicar hash (ex.: BCrypt).
/// </remarks>
public sealed class Usuario : BaseEntity
{
    public string Nome        { get; private set; } = string.Empty;
    public string Email       { get; private set; } = string.Empty;
    public string Senha       { get; private set; } = string.Empty;
    public string Telefone    { get; private set; } = string.Empty;
    
    // N:1
    public Guid     FamiliaId { get; private set; }
    public Familia? Familia   { get; private set; }

    // 1:1
    public Guid      EnderecoId { get; private set; }
    public Endereco? Endereco   { get; private set; }

    // 1:N
    public List<Tarefa> Tarefas { get; private set; } = [];

    // EF Core
    private Usuario()
    {
    }

    public Usuario(
        string nome,
        string email,
        string senha,
        string telefone,
        Guid   familiaId,
        Guid   enderecoId)
    {
        AtualizarNome(nome);
        AtualizarEmail(email);
        AtualizarSenha(senha);
        AtualizarTelefone(telefone);

        if (familiaId == Guid.Empty)
            throw new DomainException("O usuário deve pertencer a uma família válida.");

        if (enderecoId == Guid.Empty)
            throw new DomainException("O usuário deve ter um endereço válido associado.");

        FamiliaId  = familiaId;
        EnderecoId = enderecoId;
    }

    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new DomainException("O nome do usuário não pode ser vazio.");

        novoNome = novoNome.Trim();

        if (novoNome.Length > 100)
            throw new DomainException("O nome deve ter no máximo 100 caracteres.");

        Nome = novoNome;
    }

    public void AtualizarEmail(string novoEmail)
    {
        if (string.IsNullOrWhiteSpace(novoEmail))
            throw new DomainException("O e-mail não pode ser vazio.");

        novoEmail = novoEmail.Trim();

        if (!novoEmail.Contains('@'))
            throw new DomainException("O e-mail informado é inválido.");

        if (novoEmail.Length > 50)
            throw new DomainException("O e-mail deve ter no máximo 50 caracteres.");

        Email = novoEmail;
    }

    public void AtualizarSenha(string novaSenha)
    {
        if (string.IsNullOrWhiteSpace(novaSenha))
            throw new DomainException("A senha não pode ser vazia.");

        if (novaSenha.Length < 6)
            throw new DomainException("A senha deve ter pelo menos 6 caracteres.");

        // Restrição do modelo Oracle: VARCHAR2(20)
        if (novaSenha.Length > 20)
            throw new DomainException("A senha deve ter no máximo 20 caracteres.");

        Senha = novaSenha;
    }

    public void AtualizarTelefone(string novoTelefone)
    {
        if (string.IsNullOrWhiteSpace(novoTelefone))
            throw new DomainException("O telefone não pode ser vazio.");

        novoTelefone = novoTelefone.Trim();

        if (novoTelefone.Length > 11)
            throw new DomainException("O telefone deve ter no máximo 11 dígitos.");

        Telefone = novoTelefone;
    }
}