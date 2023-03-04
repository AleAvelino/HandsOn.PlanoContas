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


        public Task<IEnumerable<ChartAccount>> GetAllPlansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChartAccount>> GetFilterPlansAsync(Func<ChartAccount, ChartAccount, bool> func)
        {
            throw new NotImplementedException();
        }

    }
}
