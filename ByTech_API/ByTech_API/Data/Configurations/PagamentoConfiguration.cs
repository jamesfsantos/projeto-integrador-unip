using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByTech_API.Data.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("pagamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Metodo).HasConversion<string>().HasColumnName("metodo").IsRequired();
            builder.Property(x => x.Status).HasConversion<string>().HasColumnName("status").IsRequired();
            builder.Property(x => x.DataConfirmacao).HasColumnName("data_confirmacao");
            builder.Property(x => x.PedidoId).HasColumnName("id_pedido");

            builder.HasOne(x => x.Pedido)
            .WithOne()
            .HasForeignKey<Pagamento>(x => x.PedidoId);

            
        }
    }
}
