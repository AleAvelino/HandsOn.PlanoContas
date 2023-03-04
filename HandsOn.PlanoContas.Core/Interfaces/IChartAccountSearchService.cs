
using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    internal interface IChartAccountSearchService
    {
        Task<IEnumerable<ChartAccount>> GetAllPlansAsync();
        Task<IEnumerable<ChartAccount>> GetFilterPlansAsync(Func<ChartAccount, ChartAccount, bool> func);


    }
}
