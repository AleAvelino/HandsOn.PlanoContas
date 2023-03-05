using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Interfaces;

namespace HandsOn.PlanoContas.Core.Validators
{
    public class ValidatorCommandService : IValidatorCommand
    {
        private readonly List<ChartAccount> _items;

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
            return ParentCanHaveChildren(item)
                && !CodeAlreadyExists(item)
                && ChildrenMustBeSameParentType(item)
                && CodeCanBeGreaterThanNext(item);
        }


        /* ● A conta que aceita lançamentos não pode ter contas filhas; */
        /* ● A conta que não aceita lançamentos pode ser pai de outras contas; */
        public bool ParentCanHaveChildren(ChartAccount item)
        {
            var parent = _items.FirstOrDefault(x => x.Code == item.ParentAccount);
            return parent == null || parent.Code == item.Code || !parent.AcceptInclusion;
        }

        /* ● Os códigos não podem se repetir; */
        public bool CodeAlreadyExists(ChartAccount item)
        {
            return _items.Any(x => x.Code == item.Code);
        }

        /* ● As contas devem obrigatoriamente ser do mesmo tipo do seu pai (quando este existir); */
        public bool ChildrenMustBeSameParentType(ChartAccount item)
        {
            var parent = _items.FirstOrDefault(x => x.Code == item.ParentAccount);
            return parent == null || parent.Code == item.Code
                || parent.Type == item.Type;
        }

        /* ● Deve-se permitir que o usuário inclua uma conta de código "1.2.9", filha da "1.2", mesmo que a maior filha dela seja a "1.2.3"; */
        public bool CodeCanBeGreaterThanNext(ChartAccount item)
        {
            var sisters = _items
                .Where(x => x.ParentAccount == item.ParentAccount)
                .OrderByDescending(o => o.Code)
                .ToList();
            return sisters == null
                || Math.Abs(string.Compare(item.Code, sisters.Max(x => x.Code), comparisonType: StringComparison.OrdinalIgnoreCase)) > 0;
        }



        public bool DeleteItemValidation(int clientId, string code)
        {
            return _items.Any(x => x.ClientId == clientId && x.Code == code);
        }


    }
}
