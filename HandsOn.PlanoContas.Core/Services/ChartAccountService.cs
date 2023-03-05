using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Handlers;
using HandsOn.PlanoContas.Core.Interfaces;


namespace HandsOn.PlanoContas.Core.Services
{
    public class ChartAccountService : IChartAccountService
    {
        private readonly IChartAccountCommandService _commandService;
        private readonly IChartAccountSearchService _searchService;
        private readonly int _clientId;

        public ChartAccountService(
            int clientId,
            IChartAccountRepository repository
            )
        {
            _clientId = clientId;
            _commandService = new ChartAccountCommandService(_clientId, 
                repository, 
                new ValidatorCommandService());

            _searchService = new ChartAccountSearchService(repository); 
        }


        public Task<OperationResultDTO> AddPlanAsync(ChartAccountDTO chartAccountDTO)
        {
            var item = MapHandler.GetChartAccount(_clientId, chartAccountDTO);
            return _commandService.AddPlanAsync(item);
        }

        public Task<OperationResultDTO> RemovePlanAsync(string code)
        {
            // Validate Operation


            return _commandService.RemovePlanAsync(code);
        }

        public void ValidateItem(ChartAccountDTO item)
        {
            throw new NotImplementedException();
        }
        public void ValidateItemToRemove(ChartAccountDTO dto, ChartAccount chartAccount)
        {
            throw new NotImplementedException();
        }


        private async Task<IEnumerable<ChartAccountDTO>> GetItemsAsync()
        {
            var items = await _searchService
                .GetAllPlansAsync(_clientId);
            return items
                .Select(i => MapHandler.GetDTO(i))
                .ToList();
                
        }

        public async Task<IEnumerable<ChartAccountDTO>> GetItemsFilterAsync(Func<int, bool, ChartAccount> func)
        {
            var lst = await _searchService.GetFilterPlansAsync(_clientId, func);
            return lst
                .Select(x => MapHandler.GetDTO(x))
                .ToList();
        }



  



    }
}
