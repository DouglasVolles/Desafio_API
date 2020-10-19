using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Api2.Regras.Interfaces;
using Api2.Regras;

namespace Api2.Regras
{
    public class CalculaJuros : ICalculaJuros
    {
        public decimal Calcular(decimal valorInicial, int meses)
        {
            double valorConvertido = Convert.ToDouble(valorInicial);
            var taxaJuros = new TaxaJuros();
            double juros = Convert.ToDouble(taxaJuros.GetTaxaJuros() + 1);
            double ValorFinal = (Math.Pow(juros, meses) * valorConvertido);

            ValorFinal *= 100;
            ValorFinal = Math.Truncate(ValorFinal);
            ValorFinal /= 100;
            return Convert.ToDecimal(ValorFinal);
        }
    }
}
