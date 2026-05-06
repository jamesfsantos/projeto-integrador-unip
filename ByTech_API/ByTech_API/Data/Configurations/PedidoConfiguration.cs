using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.DataPedido).HasColumnName("data_pedido");
            builder.Property(x => x.ValorTotalPedido).HasColumnName("valor_total_pedido").IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasColumnType("varchar(14)");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)");
            builder.Property(x => x.Celular).HasColumnName("celular").HasColumnType("varchar(20)");
            builder.Property(x => x.UsuarioId).HasColumnName("id_usuario");
            builder.Property(x => x.Endereco).HasColumnName("endereco").HasColumnType("varchar(255)");
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasColumnType("varchar(150)");
            builder.Property(x => x.Cidade).HasColumnName("cidade").HasColumnType("varchar(100)");
            builder.Property(x => x.Cep).HasColumnName("cep").HasColumnType("varchar(20)");
            builder.Property(x => x.StatusPedidoId).HasColumnName("id_status_pedido").HasColumnType("int(11)");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);
            builder.HasOne(x => x.StatusPedido)
                .WithMany()
                .HasForeignKey(x => x.StatusPedidoId);
        }
    }
}
