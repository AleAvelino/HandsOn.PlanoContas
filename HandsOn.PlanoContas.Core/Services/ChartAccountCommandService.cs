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
        public ChartAccountCommandService(
            IChartAccountRepository repository, 
            IValidatorCommand validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<OperationResultDTO> AddPlanAsync(int clientId, ChartAccount item)
        {
            ValidateItemToAdd(clientId, item);

            throw new NotImplementedException();
        }

        public async Task<OperationResultDTO> RemovePlanAsync(int clientId, string code)
        {
            ValidateItemToRemove(clientId, code);

            throw new NotImplementedException();
        }

        private bool ValidateItemToAdd(int clientId, ChartAccount item)
        {
            var lst = _repository.GetAll(clientId);
            _validator.SetItems(lst);
            return _validator.CreateItemValidation(item);
        }

        private bool ValidateItemToRemove(int clientId, string code)
        {
            var lst = _repository.GetAll(clientId);
            _validator.SetItems(lst);
            return _validator.DeleteItemValidation(clientId, code);
        }


    }
}
