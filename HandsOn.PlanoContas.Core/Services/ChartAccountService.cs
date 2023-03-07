using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Enums;
using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Handlers;
using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.Validators;
using HandsOn.PlanoContas.Core.Helpers;

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


        public async Task<OperationResultDTO> AddPlanAsync(int clientId, ChartAccountDTO chartAccountDTO)
        {
            var item = MapHandler.GetChartAccount(clientId, chartAccountDTO);
            return await Task.FromResult(_commandService.AddPlanAsync(clientId, item));
        }

        public async Task<OperationResultDTO> RemovePlanAsync(int clientId, string code)
        {
            return await Task.FromResult(_commandService.RemovePlanAsync(clientId, code));
        }


        public async Task<IEnumerable<ChartAccountDTO>> GetItemsAsync(
            int clientId, 
            string search = "", 
            ESearchType searchType = ESearchType.ALL, 
            ESearchOrder order = ESearchOrder.CODE, 
            bool searchOrderDesc = false)
        {
            IEnumerable<ChartAccount> items =
                await _searchService.GetItemsAsync(clientId, search, searchType, order, searchOrderDesc);

            return items
                .Select(i => MapHandler.GetDTO(i))
                .ToList();                
        }

        public async Task<ChartAccount> GetItembyCodeAsync(int clientId, string code)
        {
            var item =  await _searchService.GetItemsAsync(clientId, code, ESearchType.CODE);
            return item.First();
        }






    }
}
