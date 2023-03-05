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

        public Task<IEnumerable<ChartAccount>> GetFilterPlansAsync(int clientId, Func<ChartAccount, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
