using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IChartAccountRepository
    {
        IEnumerable<ChartAccount> GetAll(int clientId);
        IEnumerable<ChartAccount> GetItemsByName(int clientId, string name);
        ChartAccount? GetItemByCode(int clientId, string code);
        IEnumerable<ChartAccount> GetParentList(int clientId, string code);

        void Create(int clientId, ChartAccount item);
        void Delete(int clientId, string code);

    }
}
