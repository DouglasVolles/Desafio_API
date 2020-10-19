using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api2.Regras;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class calculajurosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<decimal>> Get(decimal valorInicial, int meses)
        {
            try
            {
                var calcular = new CalculaJuros();

                return StatusCode(200, calcular.Calcular(valorInicial,meses));
            }
            catch (Exception erro)
            {
                return StatusCode(500, string.Format("Erro ao buscar a taxa: {0}", erro.Message));
            }
        }

    }
}
