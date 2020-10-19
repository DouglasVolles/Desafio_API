using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api1.Models;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns>O retorno é sempre uma taxa de 1%</returns>
        [HttpGet]
        public ActionResult<IEnumerable<decimal>> Get()
        {
            try
            {
                var taxa = new TaxaJuros() { Valor = 0.01m };
                return StatusCode(200, taxa.Valor);
            }
            catch (Exception erro)
            {
                return StatusCode(500, string.Format("Erro ao buscar a taxa: {0}", erro.Message));
            }
        }
    }
}
