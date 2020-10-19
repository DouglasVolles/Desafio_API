using Api2.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
namespace Api2.Unit.Test
{
    public class calculajuros
    {
        [Fact]
        public void CalculaJuros105com10()
        {
            // setup
            var controller = new calculajurosController();

            // a��o
            var resultado = (controller.Get(100,5).Result as ObjectResult).Value;

            // valida��es
            Assert.Equal(105.10m, Convert.ToDecimal(resultado));
        }
    }
}
