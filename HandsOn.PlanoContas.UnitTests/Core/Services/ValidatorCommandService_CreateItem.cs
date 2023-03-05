
using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Services;

namespace HandsOn.PlanoContas.UnitTests.Core.Services
{
    public class ValidatorCommandService_CreateItem
    {
        private readonly FakeDomainMockList _mockList;
        private readonly ValidatorCommandService _validatorCommandService;

        public ValidatorCommandService_CreateItem()
        {
            _mockList = new FakeDomainMockList();
            _validatorCommandService = new ValidatorCommandService(_mockList);   
        }


        // ● A conta que aceita lançamentos não pode ter contas filhas;
        [Fact]
        public void IsAcceptHasNotChildren_InputIsTrue_ReturnFalse()
        {
            ChartAccount item = new(0, "2.3.3.1", "Corte de grama", true, PlanoContas.Core.Enums.EPlanType.Expense, "2.3.3", 0);
            bool result = _validatorCommandService.IsAcceptHasNotChildren(item);

            Assert.False(result, "A conta que aceita lançamentos não pode ter contas filhas");
        }
        [Fact]
        public void IsAcceptHasNotChildren_InputIsFalse_ReturnTrue()
        {
            ChartAccount item = new(0, "2.3.4", "Corte de grama", true, PlanoContas.Core.Enums.EPlanType.Expense, "2.3", 0);
            bool result = _validatorCommandService.IsAcceptHasNotChildren(item);

            Assert.True(result, "A conta que aceita lançamentos não pode ter contas filhas");
        }

        // ● A conta que não aceita lançamentos pode ser pai de outras contas;
        [Fact]
        public void IsNotAcceptCanHaveChildren_InputIsTrue_ReturnTrue()
        {
            ChartAccount item = new(0, "2.3.4", "Corte de grama", true, PlanoContas.Core.Enums.EPlanType.Expense, "2.3", 0);
            bool result = _validatorCommandService.IsNotAcceptCanHaveChildren(item);

            Assert.True(result, "A conta que não aceita lançamentos pode ser pai de outras contas");
        }

        // ● Os códigos não podem se repetir;
        [Theory]
        [InlineData("2")]
        [InlineData("2.3")]
        [InlineData("4.1")]
        public void CodeCantBeRepeated_ValuesRepeated_ReturnFalse(string value)
        {
            ChartAccount item = new(0, value, $"Testes de Repetição de código {value}", true, PlanoContas.Core.Enums.EPlanType.Expense, "2.3", 0);
            bool result = _validatorCommandService.CodeCantBeRepeated(item);

            Assert.False(result, $"O Código {value} não pode se repetir");
        }
        [Theory]
        [InlineData("2.5")]
        [InlineData("3.9")]
        [InlineData("5")]
        public void CodeCantBeRepeated_ValuesNotRepeated_ReturnTrue(string value)
        {
            ChartAccount item = new(0, value, $"Testes de Repetição de código {value}", true, PlanoContas.Core.Enums.EPlanType.Expense, "2.3", 0);
            bool result = _validatorCommandService.CodeCantBeRepeated(item);

            Assert.True(result, $"O Código {value} não se repetiu");
        }

        // ● As contas devem obrigatoriamente ser do mesmo tipo do seu pai (quando este existir);
        [Theory]
        [InlineData("4.3", "4", PlanoContas.Core.Enums.EPlanType.Expense)]
        [InlineData("2.34", "2", PlanoContas.Core.Enums.EPlanType.Revenue)]
        [InlineData("2.4.8", "2.4", PlanoContas.Core.Enums.EPlanType.Unknown)]
        public void ChildrenMustBeSameFathersType_DifferentValues_ReturnFalse(string code, string fatherCode, PlanoContas.Core.Enums.EPlanType value)
        {
            ChartAccount item = new(0, code, $"Testes de tipo do pai {value}", true, value, fatherCode, 0);
            bool result = _validatorCommandService.ChildrenMustBeSameFathersType(item);

            Assert.False(result, $"O Tipo {value} não pode ser diferente");
        }
        [Theory]
        [InlineData("4.3", "4", PlanoContas.Core.Enums.EPlanType.Revenue)]
        [InlineData("2.34", "2", PlanoContas.Core.Enums.EPlanType.Expense)]
        public void ChildrenMustBeSameFathersType_SamesValues_ReturnTrue(string code, string fatherCode, PlanoContas.Core.Enums.EPlanType value)
        {
            ChartAccount item = new(0, code, $"Testes de tipo do pai {value}", true, value, fatherCode, 0);
            bool result = _validatorCommandService.CodeCantBeRepeated(item);

            Assert.True(result, $"O Tipo {value} é igual à conta pai");
        }

        /*  ● Deve-se permitir que o usuário inclua uma conta de código "1.2.9", filha da "1.2", mesmo que a maior filha dela seja a "1.2.3"; */
        [Theory]
        [InlineData("4.99", "4", PlanoContas.Core.Enums.EPlanType.Revenue)]
        [InlineData("2.4.66", "2.4", PlanoContas.Core.Enums.EPlanType.Expense)]
        public void CodeCanBeGreaterThanNext_ValuesBigger_ReturnTrue(string value, string fatherCode, PlanoContas.Core.Enums.EPlanType type)
        {
            ChartAccount item = new(0, value, $"Código {value} maior que o próximo", true, type, fatherCode, 0);
            bool result = _validatorCommandService.CodeCanBeGreaterThanNext(item);

            Assert.True(result, $"O Código {value} é igual à conta pai");
        }


    }
}
