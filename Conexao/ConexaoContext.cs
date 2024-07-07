using apicrud.Models;
using Microsoft.EntityFrameworkCore;

namespace apicrud.Conexao
{
    public class ConexaoContext : DbContext
    {
        public DbSet<Funcionarios> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                    "server=localhost;" +
                    "Port=5432;Database=postgres;" +
                    "User Id=postgres;" +
                    "Password=root"
                );
    }
}
