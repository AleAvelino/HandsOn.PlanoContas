using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IChartAccountRepository
    {
        Task<IEnumerable<ChartAccount>> GetAll();
        Task<IEnumerable<ChartAccount>> GetItemByCode(string code);

        Task<IEnumerable<ChartAccount>> GetParentList(string code);

    }
}
