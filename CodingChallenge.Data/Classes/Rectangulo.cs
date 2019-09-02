using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Rectangulo : IForma
    {
        public int tipo { get; set; }

        public int cantidadTotal { get; set; }

        public float areaTotal { get; set; }

        public float perimetroTotal { get; set; }

        public float LadoB;

        private static Rectangulo _Instance = null;

        internal static Rectangulo Instance { get => _Instance; set => _Instance = value; }

        public static Rectangulo GetInstance()
        {
            if (Instance == null)
                Instance = new Rectangulo();
            return Instance;
        }

        public Rectangulo()
        {
            tipo = 5;
        }

        public int Sumar()
        {
            cantidadTotal++;
            return cantidadTotal;
        }

        public float CalcularArea(float lado)
        {
            float area = lado * LadoB;
            SumarAreas(area);
            return area;
        }

        public float CalcularPerimetro(float lado)
        {
            float perimetro = (lado * 2) + (LadoB * 2);
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
