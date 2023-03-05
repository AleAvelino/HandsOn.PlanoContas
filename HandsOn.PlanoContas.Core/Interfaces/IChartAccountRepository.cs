using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IChartAccountRepository
    {
        Task<IEnumerable<ChartAccount>> GetAll(int clientId);
        Task<IEnumerable<ChartAccount>> GetItemByCode(int clientId, string code);
        Task<IEnumerable<ChartAccount>> GetParentList(int clientId, string code);

    }
}
