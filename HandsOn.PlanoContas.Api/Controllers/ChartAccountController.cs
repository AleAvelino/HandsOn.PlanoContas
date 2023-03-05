using Microsoft.AspNetCore.Mvc;

using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.Services;
using HandsOn.PlanoContas.Infrastructure.Data.Contexts;
using HandsOn.PlanoContas.Infrastructure.Data.Repositories;


namespace HandsOn.PlanoContas.Api.Controllers
{
    /// <summary>
    /// API REST que fornece consulta e operações do Plano de Contas
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/PlanoContas")]
    [ApiVersion("1.0")]
    public class ChartAccountController : BaseApiController
    {
        private readonly ChartAccountService service;

        public ChartAccountController(IChartAccountService chartAccountService)
        {
            service = (ChartAccountService)chartAccountService;
        }

        /// <summary>
        /// Consulta o Plano de contas do cliente
        /// </summary>
        /// <returns>Retorna a lista do plano de contas</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                int cliId = GetClientId();
                var resp = await service.GetItemsAsync(cliId);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Consulta um plano de contas específico
        /// </summary>
        /// <param name="id">Código do plano de contas</param>
        /// <returns>Retorna o plano de contas</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                int cliId = GetClientId();
                var resp = await service.GetItemsFilterAsync(cliId, x => x.Code == id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Criação de um novo item no Plano de Contas
        /// </summary>
        /// <param name="value">Item do plano de contas criado pelo usuário</param>
        /// <returns>Retorna o sucesso ou falha da operação</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChartAccountDTO value)
        {
            try
            {
                int cliId = GetClientId();
                var resp = await service.AddPlanAsync(cliId, value);    
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclusão de um item existente do Plano de Contas
        /// </summary>
        /// <param name="id">Código do plano a ser apagado</param>
        /// <returns>Retorna o sucesso ou falha da operação</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                int cliId = GetClientId();
                var resp = await service.RemovePlanAsync(cliId, id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
