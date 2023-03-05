using Microsoft.EntityFrameworkCore;
using HandsOn.PlanoContas.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace HandsOn.PlanoContas.Infrastructure.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<ChartAccount> ChartAccounts { get; set; }


    }
}
