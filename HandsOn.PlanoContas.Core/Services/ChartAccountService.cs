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


        public async Task<OperationResultDTO> AddPlanAsync(int clientId, ChartAccountDTO chartAccountDTO)
        {
            ValidateItem(chartAccountDTO);
            var item = MapHandler.GetChartAccount(clientId, chartAccountDTO);
            return await Task.FromResult(_commandService.AddPlanAsync(clientId, item));
        }

        public async Task<OperationResultDTO> RemovePlanAsync(int clientId, string code)
        {
            return await Task.FromResult(_commandService.RemovePlanAsync(clientId, code));
        }

        public void ValidateItem(ChartAccountDTO item)
        {
            if (item == null)
                throw new Exception("Item deve ser preenchido");
            if (item.Codigo.Trim().Length < 1)
                throw new Exception("Item deve ter código");
            if (String.IsNullOrEmpty(item.Nome))
                throw new Exception("Item deve ter nome");
            if (String.IsNullOrEmpty(item.Tipo))
                throw new Exception("Item deve possuir um tipo");

        }

        public async Task<IEnumerable<ChartAccountDTO>> GetItemsAsync(int clientId)
        {
            var items = await _searchService
                .GetAllPlansAsync(clientId);
            return items
                .Select(i => MapHandler.GetDTO(i))
                .ToList();
                
        }

        public async Task<IEnumerable<ChartAccountDTO>> GetItemsbyNameAsync(int clientId, string name)
        {
            var lst = await _searchService.GetItemsbyNameAsync(clientId, name);
            return lst
                .Select(x => MapHandler.GetDTO(x))
                .ToList();
        }

        public async Task<ChartAccountDTO> GetItembyCodeAsync(int clientId, string code)
        {
            var item = await _searchService.GetFilterbyCodeAsync(clientId, code);
            return MapHandler.GetDTO(item);
        }






    }
}
