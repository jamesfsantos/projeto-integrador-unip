using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class StatusPedidoConfiguration : IEntityTypeConfiguration<StatusPedido>
    {
        public void Configure(EntityTypeBuilder<StatusPedido> builder)
        {
            builder.ToTable("status_pedido");
            builder.HasKey(builder => builder.Id);
            builder.Property(x => x.Id).HasColumnType("int(11)").HasColumnName("id");
            builder.Property(x => x.StatusAtual).HasColumnType("varchar(30)").HasColumnName("status_atual");
        }
    }
}
