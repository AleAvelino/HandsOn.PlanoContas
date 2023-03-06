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

        public ChartAccount? GetItemByCode(int clientId, string code)
        {
            return context.ChartAccounts
                .Where(x => x.ClientId == clientId && x.Code == code)
                .FirstOrDefault();
        }

        public IEnumerable<ChartAccount> GetParentList(int clientId, string code)
        {
            return context.ChartAccounts
                .Where(x => x.ClientId == clientId && x.ParentAccount == code)
                .ToList();

        }

        public void Create(int clientId, ChartAccount item)
        {
            item.ClientId = clientId;
            context.ChartAccounts.Add(item);
            context.SaveChanges();
        }
        public void Delete(int clientId,  string code)
        {
            var item = GetItemByCode(clientId, code);
            if (item == null)
                throw new Exception("Item não existe");

            context.ChartAccounts.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<ChartAccount> GetItemsByName(int clientId, string name)
        {
            return context.ChartAccounts
                .Where(x => x.ClientId == clientId &&  x.Name.Contains(name))
                .ToList();

        }
    }
}
