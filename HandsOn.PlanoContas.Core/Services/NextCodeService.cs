using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.DTOs;

namespace HandsOn.PlanoContas.Core.Services
{
    public class NextCodeService : INextCodeService
    {
        private readonly IChartAccountSearchService _searchService;
        private readonly IValidatorNextCode _validator;
        private readonly int _clientId;

        public NextCodeService(
            int clientId,
            IChartAccountRepository repository
            )
        {
            _clientId = clientId;
            _searchService = new ChartAccountSearchService(repository);
            _validator = new ValidatorNextCodeService(); 
        }



        public Task<NextCodeResponseDTO> GetNextCode(string parentCode)
        {
            throw new NotImplementedException();
        }







    }
}
