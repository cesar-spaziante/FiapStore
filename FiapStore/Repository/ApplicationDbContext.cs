using FiapStore.Configurations;
using FiapStore.Controllers.Entity;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                _configuration.GetValue<string>("ConnectionStrings:ConnectionString"),
                new MySqlServerVersion( new Version(8, 0, 33)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
