
namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IValidatorNextCode
    {
        string NextCodeValidation(string code, IEnumerable<Entities.ChartAccount> list);

    }
}
