using ListagemTarefasEstagio.Enums;

namespace ListagemTarefasEstagio.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descrição { get; set; }
        public StatusDaTarefa Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
                
    }
}
