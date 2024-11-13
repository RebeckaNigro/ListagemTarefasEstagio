namespace ListagemTarefasEstagio.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; } // Identificador único do usuário
        public string Nome { get; set; } // Nome completo do usuário
        public string Email { get; set; } // Endereço de e-mail do usuário
        public List<TarefaModel> Tarefas { get; set; } // Lista de tarefas associadas ao usuário
    }
}
