using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.Services
{
    internal class ChartAccountSearchService : IChartAccountSearchService
    {
        private readonly IChartAccountRepository _repository;

        public ChartAccountSearchService(IChartAccountRepository repository)
        {
            _repository = repository;
        }



        public async Task<IEnumerable<ChartAccount>> GetAllPlansAsync(int clientId)
        {
            return await Task.FromResult(_repository.GetAll(clientId));
        }

        public async Task<ChartAccount> GetFilterbyCodeAsync(int clientId, string code)
        {
            return await Task.FromResult(_repository.GetItemByCode(clientId, code) ?? new());
        }

        public async Task<IEnumerable<ChartAccount>> GetItemsbyNameAsync(int clientId, string name)
        {
            return await Task.FromResult(_repository.GetItemsByName(clientId, name));
        }
    }
}
