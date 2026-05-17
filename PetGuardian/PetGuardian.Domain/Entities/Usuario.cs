using PetGuardian.Domain.Common;
using PetGuardian.Domain.Exceptions;

namespace PetGuardian.Domain.Entities;

/// <summary>
/// Usuário do sistema. Pertence a uma <see cref="Familia"/>, possui endereço e telefone exclusivos (1:1).
/// Relacionamento N:N com <see cref="Pet"/> via <see cref="UsuarioPet"/>.
/// </summary>
public sealed class Usuario : BaseEntity
{
    public string Nome  { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Senha { get; private set; } = string.Empty;

    public Guid      EnderecoId { get; private set; }
    public Endereco? Endereco   { get; private set; }

    public Guid      FamiliaId { get; private set; }
    public Familia?  Familia   { get; private set; }

    public Guid      TelefoneId { get; private set; }
    public Telefone? Telefone   { get; private set; }

    // Navegações
    public List<UsuarioPet>      PetsVinculados { get; private set; } = [];
    public List<Tarefa>          Tarefas        { get; private set; } = [];
    public List<HistoricoPontos> Historico      { get; private set; } = [];
    public PontosTotais?         PontosTotais   { get; private set; }

    private Usuario() { }

    public Usuario(string nome, string email, string senha, Guid enderecoId, Guid familiaId, Guid telefoneId)
    {
        AtualizarNome(nome);
        AtualizarEmail(email);
        AtualizarSenha(senha);

        if (enderecoId == Guid.Empty)
            throw new DomainException("O usuário deve ter um endereço válido.");

        if (familiaId == Guid.Empty)
            throw new DomainException("O usuário deve pertencer a uma família válida.");

        if (telefoneId == Guid.Empty)
            throw new DomainException("O usuário deve ter um telefone válido.");

        EnderecoId = enderecoId;
        FamiliaId  = familiaId;
        TelefoneId = telefoneId;
    }

    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new DomainException("O nome não pode ser vazio.");

        novoNome = novoNome.Trim();

        if (novoNome.Length > 100)
            throw new DomainException("O nome deve ter no máximo 100 caracteres.");

        Nome = novoNome;
    }

    public void AtualizarEmail(string novoEmail)
    {
        if (string.IsNullOrWhiteSpace(novoEmail) || !novoEmail.Contains('@'))
            throw new DomainException("O e-mail informado é inválido.");

        novoEmail = novoEmail.Trim();

        if (novoEmail.Length > 50)
            throw new DomainException("O e-mail deve ter no máximo 50 caracteres.");

        Email = novoEmail;
    }

    public void AtualizarSenha(string novaSenha)
    {
        if (string.IsNullOrWhiteSpace(novaSenha) || novaSenha.Length < 6)
            throw new DomainException("A senha deve ter pelo menos 6 caracteres.");

        if (novaSenha.Length > 20)
            throw new DomainException("A senha deve ter no máximo 20 caracteres.");

        Senha = novaSenha;
    }
}