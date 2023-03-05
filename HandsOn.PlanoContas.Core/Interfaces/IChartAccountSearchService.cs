
using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    internal interface IChartAccountSearchService
    {
        Task<IEnumerable<ChartAccount>> GetAllPlansAsync(int clientId);
        Task<IEnumerable<ChartAccount>> GetFilterPlansAsync(int clientId, Func<int, bool, ChartAccount> func);


    }
}
