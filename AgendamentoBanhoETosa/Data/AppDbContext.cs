using AgendamentoBanhoETosa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace AgendamentoBanhoETosa.Data
{
    public class AppDbContext : DbContext
    {

        //Puxando informações de configuração do JSON
        protected readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        //como o EntityFramework vai se comunicar com o Sql
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("AivenDB"));
            }
        }


        //dizendo basicamente que minha Classe de Clientes no Model vai ser uma tabela do sistema -> no banco de dados
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        // Configuração dos enums para inteiros
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura os enums TipoPet, RacaGato e RacaCachorro para serem armazenados como inteiros
            modelBuilder.Entity<Pet>()
                .Property(p => p.Tipo)
                .HasConversion<int>();

            modelBuilder.Entity<Pet>()
                .Property(p => p.RacaGato)
                .HasConversion<int>();

            modelBuilder.Entity<Pet>()
                .Property(p => p.RacaCachorro)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
