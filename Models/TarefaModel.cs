namespace ListagemTarefasEstagio.Models
{
    public class TarefaModel
    {
        public int Id { get; set; } // Identificador único da tarefa
        public string Nome { get; set; } // Nome ou título da tarefa
        public string Descricao { get; set; } // Descrição detalhada da tarefa
        public bool Concluido { get; set; } // Indica se a tarefa está concluída ou não
        public int UsuarioId { get; set; } // Identificador do usuário associado à tarefa
        public UsuarioModel Usuario { get; set; } // Referência ao usuário associado à tarefa
    }
}
