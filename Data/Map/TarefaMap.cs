using ListagemTarefasEstagio.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ListagemTarefasEstagio.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descrição).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(150);
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Usuario);
        }
    }
}
