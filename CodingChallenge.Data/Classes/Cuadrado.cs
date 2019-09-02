using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Cuadrado : IForma
    {
        public int tipo { get; set; }

        public int cantidadTotal { get; set; }

        public float areaTotal { get; set; }

        public float perimetroTotal { get; set; }

        private static Cuadrado _Instance = null;

        internal static Cuadrado Instance { get => _Instance; set => _Instance = value; }

        public static Cuadrado GetInstance()
        {
            if (Instance == null)
                Instance = new Cuadrado();
            return Instance;
        }

        public Cuadrado()
        {
            tipo = 1;
        }

        public int Sumar()
        {
            cantidadTotal++;
            return cantidadTotal;
        }

        public float CalcularArea(float lado)
        {
            float area = lado * lado;
            SumarAreas(area);
            return area;
        }

        public float CalcularPerimetro(float lado)
        {
            float perimetro = lado * 4;
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
