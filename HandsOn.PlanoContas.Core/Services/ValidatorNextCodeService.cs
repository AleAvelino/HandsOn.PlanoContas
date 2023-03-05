using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Interfaces;

namespace HandsOn.PlanoContas.Core.Services
{
    public class ValidatorNextCodeService : IValidatorNextCode
    {

        private readonly List<ChartAccount> _items;

        public ValidatorNextCodeService()
        {
            _items = new List<ChartAccount>();
        }
        public ValidatorNextCodeService(IEnumerable<ChartAccount> items)
        {
            _items = new(items);
        }

        public void SetItems(IEnumerable<ChartAccount> lst)
        {
            _items.Clear();
            _items.AddRange(lst);
        }


        public string NextCodeValidation(string code, IEnumerable<ChartAccount> list)
        {
            throw new NotImplementedException();
        }


/*
● Para o cenário em que o usuário está criando uma conta filha da conta 
    “2.2”, a API deve sugerir o código “2.2.8” se a maior filha já cadastrada 
    for a “2.2.7”. (Sempre use a lógica do maior + 1);

● O maior código possível é “999” independente do nível que você está. 
    Então o código “1.2.999” é um código válido e “1.2.1000” não;

● Se a conta “1.2.999” já existe e a API foi chamada para sugerir o 
    próximo código para o pai “1.2”ela deve: 
    ○ Retornar que o pai agora deve ser o “1”;
    ○ Retornar o código do próximo filho deste novo pai.

● Se atente para criar uma lógica que consiga sugerir o novo pai "9" com 
    o próximo filho "9.11" caso você tente buscar um código para o pai 
    “9.9.999.999” em um plano de contas que já tenha os seguintes 
    registros:
        ...
        9.9.999.999.998 Conta X
        9.9.999.999.999 Conta Y
        9.10 Conta Z
         
         
*/


        public string NextCodePlus(string code)
        {

            throw new NotImplementedException();
        }

        public bool IsValidMaxCode(string code)
        {
            throw new NotImplementedException();
        }

        public string HasToUpgradeLevel(string code)
        {
            throw new NotImplementedException();
        }

        public string IsNeededToUpLevel(string code)
        {
            throw new NotImplementedException();
        }







    }
}
