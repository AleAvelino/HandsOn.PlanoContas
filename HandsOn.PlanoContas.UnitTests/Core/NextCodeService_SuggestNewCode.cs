using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Handlers;

namespace HandsOn.PlanoContas.UnitTests.Core
{
    public class NextCodeService_SuggestNewCode
    {
        private readonly FakeDomainMockList _mockList;
        private readonly NextCodeGeneratorHandler _generator;

        public NextCodeService_SuggestNewCode()
        {
            _mockList = new FakeDomainMockList();
            _generator = new NextCodeGeneratorHandler(_mockList);
        }



        /* ● Para o cenário em que o usuário está criando uma conta filha da conta 
            “2.2”, a API deve sugerir o código “2.2.8” se a maior filha já cadastrada 
            for a “2.2.7”. (Sempre use a lógica do maior + 1);
        */
        [Theory]
        [InlineData("2", "2.5")]
        [InlineData("2.3", "2.3.4")]
        [InlineData("4", "4.3")]
        [InlineData("2.1", "2.1.16")]
        [InlineData("3", "3.5")]
        public void NextCodePlus_SimpleValues_ReturnCodeExpected(string value, string expected)
        {
            string result = _generator.NextCodePlus(value);
            Assert.Equal(result, expected);
        }


        /* ● O maior código possível é “999” independente do nível que você está. 
            Então o código “1.2.999” é um código válido e “1.2.1000” não; */
        [Theory]
        [InlineData("2.5")]
        [InlineData("2.3.4")]
        [InlineData("4.3")]
        public void IsValidMaxCode_ValidValues_ReturnTrue(string value)
        {
            var result = _generator.IsValidMaxCode(value);
            Assert.True(result, $"O código {value} é valido");
        }
        [Theory]
        [InlineData("2.1000")]
        [InlineData("3.3333")]
        [InlineData("4.3.1099.998")]
        public void IsValidMaxCode_InvalidValues_ReturnFalse(string value)
        {
            var result = _generator.IsValidMaxCode(value);
            Assert.False(result, $"O Código {value} não é válido");
        }


        /*
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

        [Theory]
        [InlineData("2.1000", 0)]
        [InlineData("3.323.3333", 1)]
        [InlineData("4.3.1099.998", 1)]
        [InlineData("4.3999.999.999.999", 0)]
        public void HasToUpgradeLevel_InvalidValues_ReturnEqual(string value, int expectedPosition)
        {
            var result = _generator.HasToUpgradeLevel(value);
            Assert.Equal(result, expectedPosition);
        }

        [Theory]
        [InlineData("2.999", "2.5")]
        [InlineData("9.9.999.999.999", "9.11")]
        [InlineData("9.9.999.999.1000", "9.11")]
        public void GetHigherlevel_ComplexValues_ReturnEqual(string value, string expected)
        {
            _mockList.Add(new ChartAccount(101, "9.9.999.999.998", "Teste de Nivel 9...998", true, PlanoContas.Core.Enums.EPlanType.Expense, "9.9.999.999", 0));
            _mockList.Add(new ChartAccount(102, "9.9.999.999.999", "Teste de Nivel 9...999", true, PlanoContas.Core.Enums.EPlanType.Expense, "9.9.999.999", 0));
            _mockList.Add(new ChartAccount(103, "9.10", "Teste de Nivel 9.10", true, PlanoContas.Core.Enums.EPlanType.Expense, "9", 0));
            _generator.Items = _mockList;

            string result = _generator.GetHigherlevel(value);
            Assert.Equal(result, expected);

        }
        [Theory]
        [InlineData("4.2.999", "4.2.999")]
        [InlineData("9.9.999.999.998", "9.13")]
        public void GetHigherlevel_WrongValues_ReturnTrue(string value, string expected)
        {
            _mockList.Add(new ChartAccount(103, "4.2.998", "Teste de Nivel 4", true, PlanoContas.Core.Enums.EPlanType.Revenue, "4", 0));
            _mockList.Add(new ChartAccount(101, "9.9.999.999.998", "Teste de Nivel 9...998", true, PlanoContas.Core.Enums.EPlanType.Expense, "9.9.999.999", 0));
            _mockList.Add(new ChartAccount(102, "9.9.999.999.999", "Teste de Nivel 9...999", true, PlanoContas.Core.Enums.EPlanType.Expense, "9.9.999.999", 0));
            _mockList.Add(new ChartAccount(103, "9.10", "Teste de Nivel 9.10", true, PlanoContas.Core.Enums.EPlanType.Expense, "9", 0));
            _mockList.Add(new ChartAccount(103, "9.12", "Teste de Nivel 9.10", true, PlanoContas.Core.Enums.EPlanType.Expense, "9", 0));
            _generator.Items = _mockList;

            string suggested = _generator.GetHigherlevel(value);
            bool result = suggested == expected;
            Assert.True(result, $"O Código {value} retornou {suggested} e não {expected}");
        }

    }
}
