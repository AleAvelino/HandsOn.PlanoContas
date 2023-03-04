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

        public ChartAccountService(
            IChartAccountRepository repository
            )
        {
            _commandService = new ChartAccountCommandService(repository);
            _searchService = new ChartAccountSearchService(repository); 
        }


        public Task<OperationResultDTO> AddPlanAsync(ChartAccountDTO chartAccountDTO)
        {
            var item = MapHandler.GetChartAccount(chartAccountDTO);
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
                .GetAllPlansAsync();
            return items
                .Select(i => MapHandler.GetDTO(i))
                .ToList();
                
        }

        public Task<IEnumerable<ChartAccountDTO>> GetItemsFilterAsync(Func<ChartAccountDTO, ChartAccountDTO> func)
        {
            throw new NotImplementedException();
        }



  



    }
}
