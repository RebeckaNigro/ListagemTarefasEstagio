//CONFIGURANDO TABELAS E CONFIGURAÇÕES GERAIS DO BANCO DE DADOS 

using ListagemTarefasEstagio.Data.Map;
using ListagemTarefasEstagio.Models;
using Microsoft.EntityFrameworkCore;

namespace ListagemTarefasEstagio.Data
{
    public class SistemadeTarefasDBContext : DbContext
    {
        public SistemadeTarefasDBContext(DbContextOptions<SistemadeTarefasDBContext> options)
            : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
       
    
}
