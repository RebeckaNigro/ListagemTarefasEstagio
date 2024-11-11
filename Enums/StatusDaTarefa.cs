using System.ComponentModel;

namespace ListagemTarefasEstagio.Enums
{
    public enum StatusDaTarefa
    {
        [Description("Pendente")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
