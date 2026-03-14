using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using ByTech_API.Models;

namespace ByTech_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<PedidosVenda> PedidosVenda { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<ServicoManutencao> ServicosManutencoes { get; set; }
        public DbSet<ItensVendas> ItensVendas { get; set; }
        public DbSet<CampanhaEmail> CampanhasEmails { get; set; }
        public DbSet<MensagensContato> MensagensContatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CampanhaEmail>(e =>
            {
                e.ToTable("Campanhas_Email");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Assunto).HasColumnName("assunto");
                e.Property(x => x.CorpoMensagem).HasColumnName("corpo_mensagem");
                e.Property(x => x.Data_Disparo).HasColumnName("data_disparo");

                e.HasOne(x => x.UsuarioAdmin)
                .WithMany()
                .HasForeignKey(x => x.AdminId);

                e.Property(x => x.AdminId).HasColumnName("id_admin");
            });

            modelBuilder.Entity<ItensVendas>(e =>
            {
                e.ToTable("Itens_Venda");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Quantidade).HasColumnName("quantidade");
                e.Property(x => x.PrecoUnitarioPago).HasColumnName("preco_unitario_pago");

                e.HasOne(x => x.Venda)
                .WithMany()
                .HasForeignKey(x => x.VendaId);

                e.HasOne(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.ProdutoId);

                e.Property(x => x.VendaId).HasColumnName("id_venda");
                e.Property(x => x.ProdutoId).HasColumnName("id_produto");
            });

            modelBuilder.Entity<MensagensContato>(e =>
            {
                e.ToTable("Mensagens_Contato");
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Nome).HasColumnName("nome_visitante");
                e.Property(x => x.Email).HasColumnName("email");
                e.Property(x => x.Celular).HasColumnName("celular");
                e.Property(x => x.Mensagem).HasColumnName("mensagem");
                e.Property(x => x.Data_Envio).HasColumnName("data_envio");

                e.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

                e.Property(x => x.UsuarioId).HasColumnName("id_usuario");
            });
        }
    }
}
