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

        private const string MSG_FAIL = "O Plano não pode ser criado, Por favor verifique os dados e tente novamente";
        private const string MSG_SUCCESS = "Dados Salvos com sucesso!";


        private readonly IChartAccountRepository _repository;
        private readonly IValidatorCommand _validator;
        public ChartAccountCommandService(
            IChartAccountRepository repository, 
            IValidatorCommand validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public OperationResultDTO AddPlanAsync(int clientId, ChartAccount item)
        {

            OperationResultDTO operationResult;

            if (ValidateItemToAdd(clientId, item))
            {
               _repository.Create(clientId, item);
                operationResult = new(false, MSG_SUCCESS);
            }
            else
            {
                operationResult = new(false, MSG_FAIL);
            }
            return operationResult;
        }

        public OperationResultDTO RemovePlanAsync(int clientId, string code)
        {
            OperationResultDTO operationResult;
            if (ValidateItemToRemove(clientId, code))
            {
                _repository.Delete(clientId, code);
                operationResult = new(false, MSG_SUCCESS);
            }
            else
            {
                operationResult = new(false, MSG_FAIL);
            }
            return operationResult;
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
