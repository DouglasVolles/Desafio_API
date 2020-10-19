using Api1.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Api1.Unit.Test
{
    public class TaxaJuros
    {
        [Fact]
        public void TaxaJurosRetona1Porcento()
        {
            // setup
            var controller = new TaxaJurosController();

            // ação
            var resultado = (controller.Get().Result as ObjectResult).Value;

            // validações
            Assert.Equal(0.01m,Convert.ToDecimal(resultado));

        }
    }
    
}
