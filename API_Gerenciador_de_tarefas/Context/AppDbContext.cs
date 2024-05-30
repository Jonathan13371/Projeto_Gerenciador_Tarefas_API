using API_Gerenciador_de_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Gerenciador_de_tarefas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options) 
        {}
        
        public DbSet<Gerenciador>?Gerenciador{ get; set;}
        public DbSet<Status>?Status{ get; set; }
    }
}
