using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Enums;
using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Handlers;
using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.Validators;
using HandsOn.PlanoContas.Core.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn.PlanoContas.Core.Services
{
    internal class ChartAccountSearchService : IChartAccountSearchService
    {
        private readonly IChartAccountRepository _repository;

        public ChartAccountSearchService(IChartAccountRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<ChartAccount>> GetItemsAsync(int clientId, string search = "", ESearchType searchType = ESearchType.ALL, ESearchOrder order = ESearchOrder.CODE, bool searchOrderDesc = false)
        {
            IEnumerable<ChartAccount> items;

            switch (searchType)
            {
                case ESearchType.CODE:
                    var tmpCode = await GetAllPlansAsync(clientId);
                    items = tmpCode.Where(tmp => tmp.Code.Contains(search));
                    break;
                case ESearchType.NAME:
                    items = await GetItemsbyNameAsync(clientId, search);
                    break;
                case ESearchType.TYPE:
                    if (!Numbers.IsNumeric(search)) throw new Exception(MessageDTO.SEARCH_CODE_IS_NOT_NUMBER);
                    var tmpType = await GetAllPlansAsync(clientId);
                    items = tmpType.Where(tmp => (int)tmp.Type == int.Parse(search));
                    break;
                default:
                    items = await GetAllPlansAsync(clientId);
                    break;
            }

            var accounts = order switch
            {
                ESearchOrder.NAME => (searchOrderDesc) 
                    ? items.OrderByDescending(x => x.Name) 
                    : items.OrderBy(x => x.Name),
                ESearchOrder.DEFAULT => (searchOrderDesc) 
                    ? items.OrderByDescending(x => x.Id) 
                    : items.OrderBy(x => x.Id),
                ESearchOrder.CODE => (searchOrderDesc) 
                    ? items.OrderByDescending(x => x.Code) 
                    : items.OrderBy(x => x.Code),
                ESearchOrder.TYPE => (searchOrderDesc) 
                    ? items.OrderByDescending(x => x.Type) 
                    : items.OrderBy(x => x.Type),
                _ => items
            };

            return accounts;
        }



        public async Task<IEnumerable<ChartAccount>> GetAllPlansAsync(int clientId)
        {
            return await Task.FromResult(_repository.GetAll(clientId));
        }

        public async Task<ChartAccount> GetFilterbyCodeAsync(int clientId, string code)
        {
            return await Task.FromResult(_repository.GetItemByCode(clientId, code) ?? new());
        }

        public async Task<IEnumerable<ChartAccount>> GetItemsbyNameAsync(int clientId, string name)
        {
            return await Task.FromResult(_repository.GetItemsByName(clientId, name));
        }
    }
}
