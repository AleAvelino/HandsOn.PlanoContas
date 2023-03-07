
using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Enums;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    internal interface IChartAccountSearchService
    {
        Task<IEnumerable<ChartAccount>> GetItemsAsync(int clientId, 
            string search = "", 
            ESearchType searchType = ESearchType.ALL, 
            ESearchOrder order = ESearchOrder.CODE, 
            bool searchOrderDesc = false);
    }
}
