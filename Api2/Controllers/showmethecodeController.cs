using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class showmethecodeController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return StatusCode(200, "https://github.com/DouglasVolles/Desafio_API");
        }
    }
}
