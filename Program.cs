using ListagemTarefasEstagio.Data;
using ListagemTarefasEstagio.Repository;
using ListagemTarefasEstagio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ListagemTarefasEstagio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao contêiner.

            builder.Services.AddControllers(); // Adiciona suporte a controladores para a API
            builder.Services.AddEndpointsApiExplorer(); // Configura a API para explorar endpoints
            builder.Services.AddSwaggerGen(); // Adiciona suporte ao Swagger para documentação da API

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<SistemadeTarefasDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
                ); // Configura o Entity Framework com o banco de dados PostgreSQL

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepository>(); // Registra a injeção de dependência para IUsuarioRepositorio
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepository>(); // Registra a injeção de dependência para ITarefaRepositorio

            var app = builder.Build(); // Constroi a aplicação com as configurações especificadas

            // Configura o pipeline de requisições HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Habilita o Swagger no ambiente de desenvolvimento
                app.UseSwaggerUI(); // Habilita a interface do Swagger para visualização da documentação
            }

            app.UseHttpsRedirection(); // Redireciona para HTTPS

            app.UseAuthorization(); // Configura a autorização para a aplicação

            app.MapControllers(); // Mapeia os controladores para os endpoints da API

            app.Run(); // Inicia a aplicação
        }
    }
}
