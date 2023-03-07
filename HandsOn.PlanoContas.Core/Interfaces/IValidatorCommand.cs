using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IValidatorCommand
    {
        void SetItems(IEnumerable<ChartAccount> list);
        void CreateItemValidation(ChartAccount item);
        void DeleteItemValidation(int clientId, string code);
    }
}
