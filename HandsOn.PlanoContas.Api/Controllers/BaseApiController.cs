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


        protected string GetQueryValue(string name)
        {
            string ret = "";
            if (Request.Query.Keys.Contains(name))
            {
                Request.Query.TryGetValue(name, out var key);
                ret = string.IsNullOrEmpty(key) ? "" : key;
            }
            return ret;
        }


    }
}
