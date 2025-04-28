using BookCatalogApi.Repositories;
using BookCatalogApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookCatalogApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configura os serviços (injeção de dependências)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Registrando o repositório e serviço de livros
            services.AddSingleton<IBookRepository>(provider => new BookRepository("books.json"));
            services.AddScoped<IBookService, BookService>();

            // Swagger para facilitar testes (opcional)
            services.AddSwaggerGen();
        }

        // Configura o pipeline HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Habilita Swagger no ambiente de desenvolvimento
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Catalog API v1");
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
