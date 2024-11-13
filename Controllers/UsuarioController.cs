using ListagemTarefasEstagio.Models;
using ListagemTarefasEstagio.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListagemTarefasEstagio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio; // Inicializa a dependência do repositório de usuário
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            // Busca todos os usuários através do repositório
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios); // Retorna a lista de usuários com status 200 OK
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarporId(int id)
        {
            // Busca um usuário específico pelo ID
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario); // Retorna o usuário encontrado com status 200 OK
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            // Adiciona um novo usuário ao banco de dados
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario); // Retorna o usuário cadastrado com status 200 OK
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id; // Atribui o ID ao modelo de usuário
            // Atualiza o usuário existente no banco de dados
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario); // Retorna o usuário atualizado com status 200 OK
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            // Apaga um usuário específico pelo ID
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado); // Retorna o resultado da operação de exclusão com status 200 OK
        }
    }
}
