using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using ByTech_API.Models;

namespace ByTech_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoVenda> PedidosVenda { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<ServicoManutencao> ServicosManutencaos { get; set; }
        public DbSet<ItemVenda> ItensVendas { get; set; }
        public DbSet<CampanhaEmail> CampanhasEmails { get; set; }
        public DbSet<MensagemContato> MensagensContatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServicoManutencao>()
                .HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServicoManutencao>()
                .HasOne(x => x.Tecnico)
                .WithMany()
                .HasForeignKey(x => x.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
