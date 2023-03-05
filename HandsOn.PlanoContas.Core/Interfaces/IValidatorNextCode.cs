
namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IValidatorNextCode
    {
        void SetItems(IEnumerable<Entities.ChartAccount> list);
        string NextCodeValidation(string code, IEnumerable<Entities.ChartAccount> list);

    }
}
