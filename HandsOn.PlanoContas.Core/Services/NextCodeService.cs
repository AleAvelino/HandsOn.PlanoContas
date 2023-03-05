﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var lst = await _searchService.GetAllPlansAsync(clientId);
            NextCodeGeneratorHandler _generatorHandler = new(lst);



            throw new NotImplementedException();
        }







    }
}
