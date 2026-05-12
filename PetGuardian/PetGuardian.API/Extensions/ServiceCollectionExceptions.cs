using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Implementations;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;
using PetGuardian.Infrastructure.Persistence;
using PetGuardian.Infrastructure.Persistence.Repositories;

namespace PetGuardian.API.Extensions;

/// <summary>
/// Extensões para registrar persistência, repositórios e serviços na injeção de dependências.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registra o <see cref="PetGuardianContext"/> com Oracle (padrão).
    /// </summary>
    /// <exception cref="InvalidOperationException">Quando a connection string não for encontrada.</exception>
    public static IServiceCollection AddPetGuardianDbContext(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName = "PetGuardianOracle")
    {
        var connectionString = configuration.GetConnectionString(connectionStringName)
            ?? throw new InvalidOperationException(
                $"Connection string '{connectionStringName}' não encontrada. Configure em appsettings.json.");

        services.AddDbContext<PetGuardianContext>(options =>
            options.UseOracle(connectionString));

        return services;
    }

    /// <summary>
    /// Registra todas as implementações de repositório como Scoped (um por requisição HTTP).
    /// </summary>
    public static IServiceCollection AddPetGuardianRepositories(this IServiceCollection services)
    {
        // Repositórios especializados
        services.AddScoped<IUsuarioRepository,     UsuarioRepository>();
        services.AddScoped<IPetRepository,         PetRepository>();
        services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
        services.AddScoped<ITarefaRepository,      TarefaRepository>();

        // Repositórios genéricos (Endereco, Familia, Veterinaria)
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }

    /// <summary>
    /// Registra todos os serviços de aplicação como Scoped.
    /// </summary>
    public static IServiceCollection AddPetGuardianServices(this IServiceCollection services)
    {
        services.AddScoped<IEnderecoService,   EnderecoService>();
        services.AddScoped<IFamiliaService,    FamiliaService>();
        services.AddScoped<IPetService,        PetService>();
        services.AddScoped<IUsuarioService,    UsuarioService>();
        services.AddScoped<IVeterinariaService,VeterinariaService>();
        services.AddScoped<IAtendimentoService,AtendimentoService>();
        services.AddScoped<ITarefaService,     TarefaService>();

        return services;
    }
}