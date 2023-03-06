using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.Validators;

namespace HandsOn.PlanoContas.UnitTests.Core
{
    public class ValidatorCommandService_DeleteItem
    {
        private readonly FakeDomainMockList _mockList;
        private readonly ValidatorCommandService _validatorCommandService;

        public ValidatorCommandService_DeleteItem()
        {
            _mockList = new FakeDomainMockList();
            _validatorCommandService = new ValidatorCommandService(_mockList);
        }


        [Theory]
        [InlineData(1, "1.16")]
        [InlineData(123, "2.2.5")]
        public void DeleteItemValidation_InvalidInput_ReturnFalse(int clientId, string code)
        {
            bool result = _validatorCommandService.DeleteItemValidation(clientId, code);

            Assert.False(result, $"A conta {code} só pode ser apagada pelo proprietário");
        }
        [Theory]
        [InlineData(0, "1.16")]
        [InlineData(0, "2.2.5")]
        public void DeleteItemValidation_InputIsFalse_ReturnTrue(int clientId, string code)
        {
            bool result = _validatorCommandService.DeleteItemValidation(clientId, code);

            Assert.True(result, $"A conta {code} foi apagada com sucesso");
        }

    }
}

