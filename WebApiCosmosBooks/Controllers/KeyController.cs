using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCosmosBooks.DTOs;

namespace WebApiCosmosBooks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KeyController (IConfiguration config): ControllerBase
    {
        [HttpGet]
        public ActionResult GetKeys()
        {
            var keys = new KeysDto()
            {
                ClientId = config["AzureAd:ClientId"],
                TenantId = config["AzureAd:TenantId"],
                Scopes = config.GetSection("ScopesAd:Scopes").Get<string[]>()
            };

            return Ok(keys);
        }
    }
}
