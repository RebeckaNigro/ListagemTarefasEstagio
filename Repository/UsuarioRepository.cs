using ListagemTarefasEstagio.Data;
using ListagemTarefasEstagio.Models;
using ListagemTarefasEstagio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListagemTarefasEstagio.Repository
{
    public class UsuarioRepository : IUsuarioRepositorio
    {
        private readonly SistemadeTarefasDBContext _context;

        public UsuarioRepository(SistemadeTarefasDBContext context)
        {
            _context = context; // Inicializa o contexto do banco de dados
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            // Retorna todos os usuários do banco de dados
            return await _context.Usuarios.Include(u => u.Tarefas).ToListAsync();
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            // Busca um usuário específico pelo ID, incluindo suas tarefas associadas
            return await _context.Usuarios.Include(u => u.Tarefas)
                                          .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            // Adiciona um novo usuário ao banco de dados
            _context.Usuarios.Add(usuarioModel);
            await _context.SaveChangesAsync(); // Salva as alterações no banco
            return usuarioModel; // Retorna o usuário cadastrado
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id)
        {
            // Atualiza os dados de um usuário existente no banco de dados
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuarioModel.Nome;
                usuarioExistente.Email = usuarioModel.Email;
                await _context.SaveChangesAsync(); // Salva as alterações no banco
            }
            return usuarioExistente; // Retorna o usuário atualizado
        }

        public async Task<bool> Apagar(int id)
        {
            // Apaga um usuário do banco de dados
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync(); // Salva as alterações no banco
                return true; // Retorna true se o usuário foi apagado com sucesso
            }
            return false; // Retorna false se o usuário não foi encontrado
        }
    }
}
