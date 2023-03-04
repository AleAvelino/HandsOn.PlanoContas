using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.Services
{
    internal class ChartAccountCommandService : IChartAccountCommandService
    {

        private readonly IChartAccountRepository _repository;
        public ChartAccountCommandService(IChartAccountRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResultDTO> AddPlanAsync(ChartAccount item)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResultDTO> RemovePlanAsync(string code)
        {
            throw new NotImplementedException();
        }

        private void ValidateItemToAdd(ChartAccount item)
        {

        }

        private void ValidateItemToRemove(ChartAccount item)
        {

        }


    }
}
