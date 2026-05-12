using System.Reflection;
using Microsoft.OpenApi;
using PetGuardian.API.Exceptions;
using PetGuardian.API.Extensions;

namespace PetGuardian.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddPetGuardianDbContext(builder.Configuration);

        builder.Services.AddPetGuardianRepositories();
        
        builder.Services.AddPetGuardianServices();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
        
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title       = "🐾 PetGuardian API",
                Version     = "v1",
                Description = "API REST para gerenciamento de pets, famílias, usuários, veterinárias, atendimentos e tarefas de cuidado.",
                Contact     = new OpenApiContact
                {
                    Name  = "Equipe PetGuardian",
                    Email = "contato@petguardian.com"
                }
            });

            // Comentários XML para documentação dos endpoints no Swagger
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        });
        
        var app = builder.Build();

        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PetGuardian API v1");
                options.RoutePrefix = "";
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}