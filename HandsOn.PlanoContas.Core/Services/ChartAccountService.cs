using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Handlers;
using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.Validators;


namespace HandsOn.PlanoContas.Core.Services
{
    public class ChartAccountService : IChartAccountService
    {
        private readonly IChartAccountCommandService _commandService;
        private readonly IChartAccountSearchService _searchService;

        public ChartAccountService(
            IChartAccountRepository repository
            )
        {
            _commandService = new ChartAccountCommandService(
                repository, 
                new ValidatorCommandService());

            _searchService = new ChartAccountSearchService(repository); 
        }


        public Task<OperationResultDTO> AddPlanAsync(int clientId, ChartAccountDTO chartAccountDTO)
        {
            var item = MapHandler.GetChartAccount(clientId, chartAccountDTO);
            return _commandService.AddPlanAsync(clientId, item);
        }

        public Task<OperationResultDTO> RemovePlanAsync(int clientId, string code)
        {
            // Validate Operation


            return _commandService.RemovePlanAsync(clientId, code);
        }

        public void ValidateItem(ChartAccountDTO item)
        {
            throw new NotImplementedException();
        }
        public void ValidateItemToRemove(ChartAccountDTO dto, ChartAccount chartAccount)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<ChartAccountDTO>> GetItemsAsync(int clientId)
        {
            var items = await _searchService
                .GetAllPlansAsync(clientId);
            return items
                .Select(i => MapHandler.GetDTO(i))
                .ToList();
                
        }

        public async Task<IEnumerable<ChartAccountDTO>> GetItemsFilterAsync(int clientId, Func<ChartAccount, bool> func)
        {
            var lst = await _searchService.GetFilterPlansAsync(clientId, func);
            return lst
                .Select(x => MapHandler.GetDTO(x))
                .ToList();
        }



  



    }
}
