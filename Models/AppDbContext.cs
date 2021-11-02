using Microsoft.EntityFrameworkCore;

namespace primeira_api_aspnet.Models
{
    public class AppDbContext : DbContext {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Pessoa> Pessoas { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Pessoa>()
                    .HasData(
                        new Pessoa { id = 1, nome = "Maicon", cpf = "366.325.325-65",
                                     endereco = 1 },
                        new Pessoa { id = 2, nome = "Micon", cpf = "355.265.888-15",
                                     endereco = 2 });
        }

    }
}