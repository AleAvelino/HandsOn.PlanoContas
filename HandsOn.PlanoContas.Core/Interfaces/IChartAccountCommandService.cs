using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.DTOs;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IChartAccountCommandService
    {
        Task<OperationResultDTO> AddPlanAsync(ChartAccount planoContaDTO);
        Task<OperationResultDTO> RemovePlanAsync(string code);
    }
}
