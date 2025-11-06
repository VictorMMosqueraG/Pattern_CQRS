using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace PatternCQRS.Api
{
    // Startup class to centralize service registration and middleware configuration
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Register application services, ports and adapters
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PatternCQRS.Domain.Ports.ITodoRepository, PatternCQRS.Infrastructure.Adapters.InMemoryTodoRepository>();
            services.AddScoped<PatternCQRS.Application.UseCases.GetTodosUseCase>();

            // Add minimal API support (if you later want controllers, add AddControllers())
            services.AddEndpointsApiExplorer();
        }

        // Configure request pipeline and endpoints
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/todos", async (PatternCQRS.Application.UseCases.GetTodosUseCase useCase) =>
            {
                var todos = await useCase.HandleAsync();
                return Results.Ok(todos);
            });
        }
    }
}
