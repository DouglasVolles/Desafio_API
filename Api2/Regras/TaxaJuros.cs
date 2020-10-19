using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api2.Regras.Interfaces;

namespace Api2.Regras
{
    public class TaxaJuros: ITaxaJuros
    {
        public decimal GetTaxaJuros()
        {
            WebRequest request = WebRequest.Create("https://localhost:44386/api/TaxaJuros");
            WebResponse response = request.GetResponse();
            decimal taxa = 0;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                taxa = Convert.ToDecimal(reader.ReadToEnd(), CultureInfo.InvariantCulture);
            }

            // Close the response.
            response.Close();
            return taxa;
        }
    }
}
