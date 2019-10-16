using System.Collections.Generic;
using GieldaL2.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GieldaL2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SharesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<ShareViewModel>> Get()
        {
            return null;
        }
    }
}