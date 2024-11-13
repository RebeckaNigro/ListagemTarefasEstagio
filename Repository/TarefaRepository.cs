using ListagemTarefasEstagio.Data;
using ListagemTarefasEstagio.Models;
using ListagemTarefasEstagio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListagemTarefasEstagio.Repository
{
    public class TarefaRepository : ITarefaRepositorio
    {
        private readonly SistemadeTarefasDBContext _context;

        public TarefaRepository(SistemadeTarefasDBContext context)
        {
            _context = context; // Inicializa o contexto do banco de dados
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            // Retorna todas as tarefas associadas a um usuário (incluindo o nome do usuário)
            return await _context.Tarefas.Include(t => t.Usuario).ToListAsync();
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            // Busca uma tarefa pelo ID, incluindo o usuário associado
            return await _context.Tarefas.Include(t => t.Usuario).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefaModel)
        {
            // Adiciona uma nova tarefa no banco de dados
            _context.Tarefas.Add(tarefaModel);
            await _context.SaveChangesAsync(); // Salva as alterações no banco
            return tarefaModel; // Retorna a tarefa adicionada
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefaModel, int id)
        {
            // Atualiza uma tarefa existente com novos dados
            var tarefaExistente = await _context.Tarefas.FindAsync(id);
            if (tarefaExistente != null)
            {
                tarefaExistente.Nome = tarefaModel.Nome;
                tarefaExistente.Descricao = tarefaModel.Descricao;
                tarefaExistente.Concluido = tarefaModel.Concluido;
                tarefaExistente.UsuarioId = tarefaModel.UsuarioId;
                await _context.SaveChangesAsync(); // Salva as alterações no banco
            }
            return tarefaExistente; // Retorna a tarefa atualizada
        }

        public async Task<bool> Apagar(int id)
        {
            // Apaga uma tarefa do banco de dados
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync(); // Salva as alterações no banco
                return true; // Retorna true se a tarefa foi apagada com sucesso
            }
            return false; // Retorna false se a tarefa não foi encontrada
        }
    }
}
