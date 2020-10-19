using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Regras.Interfaces
{
    interface ICalculaJuros
    {
        public decimal Calcular(decimal valorInicial, int meses);
    }
}
