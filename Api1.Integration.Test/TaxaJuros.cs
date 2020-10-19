using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Api1.Controllers;
using Xunit;
using System;

namespace Api1.Integration.Test
{
    public class TaxaJuros : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public TaxaJuros(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        public async Task TaxaJurosSiteOnLine(string url)
        {
            // Client
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/TaxaJuros")]
        public async Task TaxaJuros1Porcento(string url)
        {
            // client
            var client = _factory.CreateClient();

            // ação
            HttpResponseMessage result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            { 
                string response = await result.Content.ReadAsStringAsync();
                Assert.Equal(0.01m, Convert.ToDecimal(response, System.Globalization.CultureInfo.InvariantCulture));
            }
            else
            {
                Assert.True(false, "Não retorna taxa de juros.");
            }
        }
    }
}