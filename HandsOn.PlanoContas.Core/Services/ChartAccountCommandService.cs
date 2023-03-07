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

        public OperationResultDTO AddPlanAsync(int clientId, ChartAccount item)
        {

            OperationResultDTO operationResult;
            string msgValidate = ValidateItemToAdd(clientId, item);

            if (string.IsNullOrEmpty(msgValidate))
            {
               _repository.Create(clientId, item);
                operationResult = new(true, MessageDTO.COMMAND_SUCCESS);
            }
            else
            {
                operationResult = new(false, msgValidate);
            }


            return operationResult;
        }

        public OperationResultDTO RemovePlanAsync(int clientId, string code)
        {
            OperationResultDTO operationResult;

            string msgValidate = ValidateItemToRemove(clientId, code);

            if (string.IsNullOrEmpty(msgValidate))
            {
                _repository.Delete(clientId, code);
                operationResult = new(true, MessageDTO.COMMAND_SUCCESS);
            }
            else
            {
                operationResult = new(false, msgValidate);
            }
            return operationResult;
        }

        private string ValidateItemToAdd(int clientId, ChartAccount item)
        {
            string msgValidate = string.Empty;
            var lst = _repository.GetAll(clientId);
            _validator.SetItems(lst);
            try
            {
                _validator.CreateItemValidation(item);
            }catch(Exception ex)
            {
                msgValidate = ex.Message;
            }            
            return msgValidate;
        }

        private string ValidateItemToRemove(int clientId, string code)
        {
            string msgValidate = string.Empty;
            var lst = _repository.GetAll(clientId);
            _validator.SetItems(lst);
            try
            {
                _validator.DeleteItemValidation(clientId, code);
            }
            catch (Exception ex)
            {
                msgValidate = ex.Message;
            }
            return msgValidate;
        }


    }
}
