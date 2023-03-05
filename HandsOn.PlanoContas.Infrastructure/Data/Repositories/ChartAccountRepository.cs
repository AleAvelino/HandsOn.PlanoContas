using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Infrastructure.Data.Contexts;

namespace HandsOn.PlanoContas.Infrastructure.Data.Repositories
{
    public class ChartAccountRepository : IChartAccountRepository
    {
        private readonly ApplicationDbContext context;

        public ChartAccountRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ChartAccount> GetAll(int clientId)
        {
            return context.ChartAccounts
                .Where(x => x.ClientId == clientId)
                .ToList();
        }

        public IEnumerable<ChartAccount> GetItemByCode(int clientId, string code)
        {
            return context.ChartAccounts
                .Where(x => x.ClientId == clientId && x.Code == code)
                .ToList();
        }

        public IEnumerable<ChartAccount> GetParentList(int clientId, string code)
        {
            return context.ChartAccounts
                .Where(x => x.ClientId == clientId && x.ParentAccount == code)
                .ToList();

        }
    }
}
