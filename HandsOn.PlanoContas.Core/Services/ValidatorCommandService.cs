using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Interfaces;

namespace HandsOn.PlanoContas.Core.Services
{
    public class ValidatorCommandService : IValidatorCommand
    {
        private List<ChartAccount> _items;

        public ValidatorCommandService()
        {
            _items = new List<ChartAccount>();  
        }
        public ValidatorCommandService(IEnumerable<ChartAccount> items)
        {
            _items = new(items);
        }

        public void SetItems(IEnumerable<ChartAccount> lst)
        {
            _items.Clear();
            _items.AddRange(lst);
        }

        public bool CreateItemValidation(ChartAccount item)
        {
            return (IsAcceptHasNotChildren(item) 
                && IsNotAcceptCanHaveChildren(item)
                && CodeCantBeRepeated(item) 
                && ChildrenMustBeSameFathersType(item)
                && CodeCanBeGreaterThanNext(item));
        }


        /* ● A conta que aceita lançamentos não pode ter contas filhas; */
        public bool IsAcceptHasNotChildren(ChartAccount item)
        {
            throw new NotImplementedException();
        }

        /* ● A conta que não aceita lançamentos pode ser pai de outras contas; */
        public bool IsNotAcceptCanHaveChildren(ChartAccount item)
        {
            throw new NotImplementedException();
        }

        /* ● Os códigos não podem se repetir; */
        public bool CodeCantBeRepeated(ChartAccount item)
        {
            throw new NotImplementedException();
        }

        /* ● As contas devem obrigatoriamente ser do mesmo tipo do seu pai (quando este existir); */
        public bool ChildrenMustBeSameFathersType(ChartAccount item)
        {
            throw new NotImplementedException();
        }

        /* ● Deve-se permitir que o usuário inclua uma conta de código "1.2.9", filha da "1.2", mesmo que a maior filha dela seja a "1.2.3"; */
        public bool CodeCanBeGreaterThanNext(ChartAccount item)
        {
            throw new NotImplementedException();
        }







        public bool DeleteItemValidation(int clientId, string code)
        {
            throw new NotImplementedException();
        }





    }
}
