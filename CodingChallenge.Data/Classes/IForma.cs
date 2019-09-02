using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public interface IForma
    {
        int cantidadTotal { get; set; }

        int tipo { get; set; }

        float areaTotal { get; set; }

        float perimetroTotal { get; set; }

        int Sumar();

        float CalcularArea(float lado);

        float CalcularPerimetro(float lado);

        void Dispose();
    }
}
