using Microsoft.EntityFrameworkCore;
using PetGuardian.Application.Repositories;
using PetGuardian.Application.Services.Implementations;
using PetGuardian.Application.Services.Interfaces;
using PetGuardian.Domain.Entities;
using PetGuardian.Infrastructure.Persistence;
using PetGuardian.Infrastructure.Persistence.Repositories;

namespace PetGuardian.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPetGuardianDbContext(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName = "PetGuardianOracle")
    {
        var connectionString = configuration.GetConnectionString(connectionStringName)
            ?? throw new InvalidOperationException(
                $"Connection string '{connectionStringName}' não encontrada.");

        services.AddDbContext<PetGuardianContext>(options =>
            options.UseOracle(connectionString));

        return services;
    }

    public static IServiceCollection AddPetGuardianRepositories(this IServiceCollection services)
    {
        // Especializados
        services.AddScoped<IUsuarioRepository,         UsuarioRepository>();
        services.AddScoped<IPetRepository,             PetRepository>();
        services.AddScoped<IAtendimentoRepository,     AtendimentoRepository>();
        services.AddScoped<ITarefaRepository,          TarefaRepository>();
        services.AddScoped<IHistoricoPontosRepository, HistoricoPontosRepository>();
        services.AddScoped<IPontosTotaisRepository,    PontosTotaisRepository>();
        services.AddScoped<ISequenciaRepository,       SequenciaRepository>();
        services.AddScoped<IUsuarioPetRepository,      UsuarioPetRepository>();

        // Genéricos (Endereco, Bairro, Cidade, Estado, Familia,
        //            Raca, Status, TipoAtend, Telefone, Veterinaria)
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }

    public static IServiceCollection AddPetGuardianServices(this IServiceCollection services)
    {
        // Hierarquia de endereço
        services.AddScoped<IEstadoService,   EstadoService>();
        services.AddScoped<ICidadeService,   CidadeService>();
        services.AddScoped<IBairroService,   BairroService>();
        services.AddScoped<IEnderecoService, EnderecoService>();

        // Lookup
        services.AddScoped<IRacaService,      RacaService>();
        services.AddScoped<IStatusService,    StatusService>();
        services.AddScoped<ITipoAtendService, TipoAtendService>();
        services.AddScoped<ITelefoneService,  TelefoneService>();

        // Core
        services.AddScoped<IFamiliaService,    FamiliaService>();
        services.AddScoped<IUsuarioService,    UsuarioService>();
        services.AddScoped<IPetService,        PetService>();
        services.AddScoped<IVeterinariaService,VeterinariaService>();
        services.AddScoped<IAtendimentoService,AtendimentoService>();
        services.AddScoped<ITarefaService,     TarefaService>();

        // Gamificação / join
        services.AddScoped<IUsuarioPetService,      UsuarioPetService>();
        services.AddScoped<IHistoricoPontosService, HistoricoPontosService>();
        services.AddScoped<IPontosTotaisService,    PontosTotaisService>();
        services.AddScoped<ISequenciaService,       SequenciaService>();

        return services;
    }
}