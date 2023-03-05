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
        private readonly IValidatorCommand _validator;
        private readonly int _clientId;
        public ChartAccountCommandService(int clientId,
            IChartAccountRepository repository, 
            IValidatorCommand validator)
        {
            _clientId = clientId;
            _repository = repository;
            _validator = validator;
        }

        public async Task<OperationResultDTO> AddPlanAsync(ChartAccount item)
        {
            await ValidateItemToAdd(item);

            throw new NotImplementedException();
        }

        public async Task<OperationResultDTO> RemovePlanAsync(string code)
        {
            await ValidateItemToRemove(code);

            throw new NotImplementedException();
        }

        private async Task<bool> ValidateItemToAdd(ChartAccount item)
        {
            var lst = await _repository.GetAll(_clientId);
            _validator.SetItems(lst);
            return _validator.CreateItemValidation(item);
        }

        private async Task<bool> ValidateItemToRemove(string code)
        {
            var lst = await _repository.GetAll(_clientId);
            _validator.SetItems(lst);
            return _validator.DeleteItemValidation(_clientId, code);
        }


    }
}
