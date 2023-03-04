using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.DTOs;

namespace HandsOn.PlanoContas.Core.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly IChartAccountRepository _repository;

        public SuggestionService(IChartAccountRepository repository)
        {
            _repository = repository;
        }




        public Task<NextCodeResponseDTO> GetNextCode(string parentCode)
        {
            throw new NotImplementedException();
        }
    }
}
