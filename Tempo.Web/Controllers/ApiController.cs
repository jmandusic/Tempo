using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tempo.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class ApiController : ControllerBase
    {
    }
}
