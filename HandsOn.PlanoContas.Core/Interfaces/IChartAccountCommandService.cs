using HandsOn.PlanoContas.Core.Entities;
using HandsOn.PlanoContas.Core.DTOs;

namespace HandsOn.PlanoContas.Core.Interfaces
{
    public interface IChartAccountCommandService
    {
        OperationResultDTO AddPlanAsync(int clientId, ChartAccount planoContaDTO);
        OperationResultDTO RemovePlanAsync(int clientId, string code);
    }
}
