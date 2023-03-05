using Microsoft.EntityFrameworkCore;
using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Infrastructure.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChartAccount> ChartAccounts { get; set; }

    }
}
