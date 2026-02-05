using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesignPattern
{
	class Program
	{
		static void Main(string[] args)
		{
            // If run with --api argument, start web server
            // Otherwise, run interactive console menu
            if (args.Length > 0 && args[0] == "--api")
            {
                RunWebApi(args);
            }
            else
            {
                InteractiveMenu.Run();
            }
        }

        static void RunWebApi(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Design Patterns API",
                    Version = "v1",
                    Description = @"REST API for exploring and testing 15 design patterns with before/after comparisons.

**Features:**
- Interactive demos for all 15 patterns
- Before/After comparisons
- Grouped by category (Creational, Structural, Behavioral)
- Real-time console output capture

**Pattern Categories:**
- **Creational:** Singleton, Factory, Builder
- **Structural:** Adapter, Decorator, Facade, Proxy
- **Behavioral:** Strategy, Observer, Command, Template, State, Chain, Iterator, Visitor",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Design Patterns Demo",
                        Url = new Uri("https://github.com/hanyarafaosman/DesignPatterns")
                    }
                });

                // Include XML comments
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (System.IO.File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            // Configure CORS for development
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure middleware - Enable Swagger in all environments for demo purposes
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Design Patterns API v1");
                c.RoutePrefix = string.Empty; // Swagger at root
                c.DocumentTitle = "Design Patterns API";
                c.DefaultModelsExpandDepth(2);
                c.DisplayRequestDuration();
            });

            app.UseCors();
            app.MapControllers();

            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      🚀 Design Patterns API is running!                  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("📖 Swagger UI:    http://localhost:5000");
            Console.WriteLine("🔗 API Base URL:  http://localhost:5000/api/patterns");
            Console.WriteLine();
            Console.WriteLine("Quick Test:");
            Console.WriteLine("  curl http://localhost:5000/api/patterns");
            Console.WriteLine("  curl http://localhost:5000/api/patterns/singleton/compare");
            Console.WriteLine();
            Console.WriteLine("Press Ctrl+C to stop");
            Console.WriteLine();

            app.Run("http://localhost:5000");
        }
    }
}
