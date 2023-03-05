using Microsoft.AspNetCore.Mvc;


namespace HandsOn.PlanoContas.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BaseApiController : ControllerBase
    {


        protected int GetClientId()
        {
           dynamic client = Request.HttpContext.Items["Client"];
            return client?.Id ?? -1;
        }


    }
}
