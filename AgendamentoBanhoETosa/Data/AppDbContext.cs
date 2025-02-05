using AgendamentoBanhoETosa.Model.Entities;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AgendamentoBanhoETosa.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Env.Load(); // Carrega automaticamente o .env
                var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

                var connectionString = Configuration.GetConnectionString("AivenDB")
                                                     .Replace("{DB_PASSWORD}", password);

                optionsBuilder.UseNpgsql(connectionString)
                              .EnableSensitiveDataLogging()
                              .LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(a => a.EspecieAnimal)
                .HasConversion<string>(); // Armazena Especie como string.

            modelBuilder.Entity<Animal>()
                .Property(a => a.RacaCachorro)
                .HasConversion<string>(); // Armazena RacaCachorro como string.

            modelBuilder.Entity<Animal>()
                .Property(a => a.RacaGato)
                .HasConversion<string>(); // Armazena RacaGato como string.

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}
