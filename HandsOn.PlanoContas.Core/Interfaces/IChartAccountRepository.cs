using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IChartAccountRepository
    {
        IEnumerable<ChartAccount> GetAll(int clientId);
        IEnumerable<ChartAccount> GetItemByCode(int clientId, string code);
        IEnumerable<ChartAccount> GetParentList(int clientId, string code);

    }
}
