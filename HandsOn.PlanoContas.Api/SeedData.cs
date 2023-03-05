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
                new ChartAccount(0, "1", "Receitas",1,"Não" ,""),
                new ChartAccount(0, "1.1","Taxa condominial",1, "Sim" ,"1"),
                new ChartAccount(0, "2", "Despesas", 2,"Não" ,"" ),
                new ChartAccount(0, "2.1", "Com pessoal", 2,"Não" ,"2"),
                new ChartAccount(0, "2.2","Mensais", 2,"Não" ,"2"),
                new ChartAccount(0, "2.3","Manutenção", 2,"Não" ,"2"),
                new ChartAccount(0, "2.4","Diversas", 2,"Não" ,"2"),
                new ChartAccount(0, "3","Despesas bancárias", 2,"Não" ,""),
                new ChartAccount(0, "3.1","Registro de boletos", 2, "Sim" ,"3"),
                new ChartAccount(0, "4","Outras receitas",1,"Não" ,""),
                new ChartAccount(0, "4.1","Rendimento de poupança",1, "Sim" ,"4"),
                new ChartAccount(0, "4.2","Rendimento de investimentos",1, "Sim" ,"4")
            };

            dbContext.ChartAccounts.AddRange(lst);
            dbContext.SaveChanges();
        }


    }
}
