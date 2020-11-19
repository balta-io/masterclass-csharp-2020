using Microsoft.AspNetCore.Mvc;
using StrongPasswordGenerator.Core;

namespace StrongPasswordGenerator.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/password")]
    public class PasswordController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
            [FromQuery] int len,
            [FromQuery] bool includeSpecialChars,
            [FromQuery] bool onlyUpperCase
        )
        {
            var password = Password.Generate(len, includeSpecialChars, onlyUpperCase);
            return Ok(new {password});
        }
    }
}