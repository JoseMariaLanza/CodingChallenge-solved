using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Trapecio : IForma
    {
        public int tipo { get; set; }

        public int cantidadTotal { get; set; }

        public float areaTotal { get; set; }

        public float perimetroTotal { get; set; }

        public float LadoB; // Base menor

        public float LadoC;

        public float LadoD;

        private static Trapecio _Instance = null;

        internal static Trapecio Instance { get => _Instance; set => _Instance = value; }

        public static Trapecio GetInstance()
        {
            if (Instance == null)
                Instance = new Trapecio();
            return Instance;
        }

        public Trapecio()
        {
            tipo = 4;
        }

        public int Sumar()
        {
            cantidadTotal++;
            return cantidadTotal;
        }

        public float CalcularArea(float ladoA)
        {
            // Fórmula de Herón => M = Base mayor - Base menor
            float M = ladoA - LadoB;

            float h = CalcularAltura(M); // h = altura del triángulo => altura del trapecio

            float areaTrapecio = (float)(h * ((ladoA + LadoB) / 2));
            SumarAreas(areaTrapecio);
            return areaTrapecio;
        }

        private float CalcularAltura(float m)
        {
            if (m == 0) // Trapecio Rectángulo => altura = lado que forma 90º con respecto al la Base mayor (ladoA)
                return LadoD;
            else
                return CalcularAlturaTriangulo(m);
        }

        private float CalcularAlturaTriangulo(float m)
        {
            float areaTriangulo;
            float s = (m + LadoC + LadoD) / 2; // s = semiperímetro
            areaTriangulo = (float)Math.Sqrt(s * (s - m) * (s - LadoC) * (s - LadoD)); // Área del triángulo: es necesaria para despejar la altura del triángulo
            return (2 * areaTriangulo) / m;
        }

        public float CalcularPerimetro(float lado)
        {
            return CalcularPerimetro(lado, LadoB, LadoC, LadoD);
        }

        public float CalcularPerimetro(float ladoA, float LadoB, float LadoC, float LadoD)
        {
            float perimetro = ladoA + LadoB + LadoC + LadoD;
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
