
using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    internal interface IChartAccountSearchService
    {
        Task<IEnumerable<ChartAccount>> GetAllPlansAsync(int clientId);
        Task<IEnumerable<ChartAccount>> GetItemsbyNameAsync(int clientId, string name);
        Task<ChartAccount> GetFilterbyCodeAsync(int clientId, string code);
    }
}
