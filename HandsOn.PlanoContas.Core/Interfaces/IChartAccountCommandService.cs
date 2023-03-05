using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.DTOs;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IChartAccountCommandService
    {
        Task<OperationResultDTO> AddPlanAsync(int clientId, ChartAccount planoContaDTO);
        Task<OperationResultDTO> RemovePlanAsync(int clientId, string code);
    }
}
