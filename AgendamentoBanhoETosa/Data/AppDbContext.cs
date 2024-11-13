using AgendamentoBanhoETosa.Model;
using Microsoft.EntityFrameworkCore;
namespace AgendamentoBanhoETosa.Data
{
    public class AppDbContext : DbContext
    {
        //dizendo basicamente que minha Classe de Clientes no Model vai ser uma tabela do sistema -> no banco de dados
        DbSet<Cliente> Clientes { get; set; }

        //como o EntityFramework vai se comunicar com o Sql
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;\r\n");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
