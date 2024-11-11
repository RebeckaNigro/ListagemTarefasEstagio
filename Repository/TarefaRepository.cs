using ListagemTarefasEstagio.Data;
using ListagemTarefasEstagio.Models;
using ListagemTarefasEstagio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListagemTarefasEstagio.Repository
{
    public class TarefaRepository : ITarefaRepositorio
    {
        private readonly SistemadeTarefasDBContext _dbContext;
        public TarefaRepository(SistemadeTarefasDBContext sistemadeTarefasDBContext)
        {
            _dbContext = sistemadeTarefasDBContext;
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID:{id} Não foi encontrado no banco de dados.");
            }
            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID:{id} Não foi encontrado no banco de dados.");
            }
            tarefaPorId.Titulo = tarefa.Titulo;
            tarefaPorId.Descrição = tarefa.Descrição;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;

        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).ToListAsync();
        }
    }
}
