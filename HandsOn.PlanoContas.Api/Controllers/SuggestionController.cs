using Microsoft.AspNetCore.Mvc;

using HandsOn.PlanoContas.Core.DTOs;
using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.Services;

namespace HandsOn.PlanoContas.Api.Controllers;


/// <summary>
/// API REST que sugere o novo código do Plano de Contas
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/Sugestao")]
[ApiVersion("1.0")]

public class SuggestionController : BaseApiController
{
    private readonly NextCodeService service;

    public SuggestionController(INextCodeService nextCodeService)
    {
        service = (NextCodeService)nextCodeService;
    }

    /// <summary>
    /// Consulta o Plano de contas do cliente e sugere um código novo de acordo com o pai
    /// </summary>
    /// <returns>Retorna a sugestão de um novo código</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            string codigo = GetQueryValue("codigo");
            if (codigo == null)
                return BadRequest("Código não informado");

            var resp = await GetSuggestion(codigo);
            return Ok(resp);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Consulta o Plano de contas do cliente e sugere um código novo de acordo com o pai
    /// </summary>
    /// <returns>Retorna a sugestão de um novo código</returns>
    [HttpGet("{codigo}")]
    public async Task<IActionResult> Get(string codigo)
    {
        try
        {
            var resp = await GetSuggestion(codigo);
            return Ok(resp);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private async Task<NextCodeResponseDTO> GetSuggestion(string parent)
    {
        return await service.GetNextCode(GetClientId(), parent);
    }


}
