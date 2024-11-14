using AgendamentoBanhoETosa.Model;
using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("ApiDatabase"));
            base.OnConfiguring(optionsBuilder);
        }

        //dizendo basicamente que minha Classe de Clientes no Model vai ser uma tabela do sistema -> no banco de dados
        DbSet<Cliente> Clientes { get; set; }
    }
}
