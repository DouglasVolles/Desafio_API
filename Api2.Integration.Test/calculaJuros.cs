using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Api2.Controllers;
using Xunit;
using System;
using System.Globalization;

namespace Api2.Integration.Test
{
    public class calculaJuros : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public calculaJuros(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        public async Task CalculoJurosSiteOnLine(string url)
        {
            // Client
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/calculajuros?valorinicial=100&meses=5")]
        public async Task CalculaJuros105com10(string url)
        {
            // client
            var client = _factory.CreateClient();

            // ação
            HttpResponseMessage result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                Assert.Equal(105.10m, Convert.ToDecimal(response,CultureInfo.InvariantCulture));
            }
            else
            {
                Assert.True(false, "Não foi possível efetuar o cálculo de juros.");
            }
        }
    }
}
