using HandsOn.PlanoContas.Core.Entities;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IValidatorCommand
    {
        void SetItems(IEnumerable<ChartAccount> list);
        bool CreateItemValidation(ChartAccount item);
        bool DeleteItemValidation(int clientId, string code);
    }
}
