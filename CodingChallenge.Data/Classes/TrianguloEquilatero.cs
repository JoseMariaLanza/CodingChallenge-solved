using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class TrianguloEquilatero : IForma
    {
        public int tipo { get; set; }

        public int cantidadTotal { get; set; }

        public float areaTotal { get; set; }

        public float perimetroTotal { get; set; }

        private static TrianguloEquilatero _Instance = null;

        internal static TrianguloEquilatero Instance { get => _Instance; set => _Instance = value; }

        public static TrianguloEquilatero GetInstance()
        {
            if (Instance == null)
                Instance = new TrianguloEquilatero();
            return Instance;
        }

        public TrianguloEquilatero()
        {
            tipo = 2;
        }

        public int Sumar()
        {
            cantidadTotal++;
            return cantidadTotal;
        }

        public float CalcularArea(float lado)
        {
            float area = ((float)Math.Sqrt(3) / 4) * lado * lado;
            SumarAreas(area);
            return area;
        }

        public float CalcularPerimetro(float lado)
        {
            float perimetro = lado * 3;
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
