using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Handlers;

namespace HandsOn.PlanoContas.Core.Services
{
    public class NextCodeService : INextCodeService
    {
        private readonly IChartAccountSearchService _searchService;
        
        public NextCodeService(IChartAccountRepository repository)
        {
            _searchService = new ChartAccountSearchService(repository);
        }


        public async Task<NextCodeResponseDTO> GetNextCode(int clientId, string parentCode)
        {
            var lst = await _searchService.GetItemsAsync(clientId);
            NextCodeGeneratorHandler generator = new(lst);

            var newCode = generator.Generate(parentCode);
            return newCode;
        }

    }
}
