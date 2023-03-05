using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Infrastructure.Data;
using HandsOn.PlanoContas.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HandsOn.PlanoContas.Api
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any TODO items.
                if (dbContext.ChartAccounts.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }

        public static void PopulateTestData(ApplicationDbContext dbContext)
        {
            foreach (var item in dbContext.ChartAccounts)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            var lst = new List<ChartAccount>()
            {
                new ChartAccount(1 , "1", "Receitas",1,"Não" ,""),
                new ChartAccount(2 , "1.1","Taxa condominial",1, "Sim" ,"1"),
                new ChartAccount(21, "2", "Despesas", 2,"Não" ,"" ),
                new ChartAccount(22, "2.1", "Com pessoal", 2,"Não" ,"2"),
                new ChartAccount(38, "2.2","Mensais", 2,"Não" ,"2"),
                new ChartAccount(46, "2.3","Manutenção", 2,"Não" ,"2"),
                new ChartAccount(50, "2.4","Diversas", 2,"Não" ,"2"),
                new ChartAccount(58, "3","Despesas bancárias", 2,"Não" ,""),
                new ChartAccount(59, "3.1","Registro de boletos", 2, "Sim" ,"3"),
                new ChartAccount(63, "4","Outras receitas",1,"Não" ,""),
                new ChartAccount(64, "4.1","Rendimento de poupança",1, "Sim" ,"4"),
                new ChartAccount(65, "4.2","Rendimento de investimentos",1, "Sim" ,"4")
            };

            dbContext.ChartAccounts.AddRange(lst);
            dbContext.SaveChanges();
        }


    }
}
