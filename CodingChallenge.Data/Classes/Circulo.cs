using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Circulo : IForma
    {
        public int tipo { get; set; }

        public int cantidadTotal { get; set; }

        public float areaTotal { get; set; }

        public float perimetroTotal { get; set; }

        private static Circulo _Instance = null;

        internal static Circulo Instance { get => _Instance; set => _Instance = value; }

        public static Circulo GetInstance()
        {
            if (Instance == null)
                Instance = new Circulo();
            return Instance;
        }

        public Circulo()
        {
            tipo = 3;
        }

        public int Sumar()
        {
            cantidadTotal++;
            return cantidadTotal;
        }

        public float CalcularArea(float lado)
        {
            float area = (float)Math.PI * (lado / 2) * (lado / 2);
            SumarAreas(area);
            return area;
        }

        public float CalcularPerimetro(float lado)
        {
            float perimetro = (float)Math.PI * lado;
            SumarPerimetros(perimetro);
            return perimetro;
        }

        public void SumarAreas(float area)
        {
            areaTotal += area;
        }

        public void SumarPerimetros(float perimetro)
        {
            perimetroTotal += perimetro;
        }

        public void Dispose()
        {
            Instance = null;
        }
    }
}
