/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Frances = 3;

        #endregion

        // Default
        static IForma formaGeometrica = new Cuadrado();

        public readonly float _lado;

        public readonly float _ladoB;

        // Campos Nullable<T> para poder llamar a la sobrecarga del constructor
        // y calcular area y perímetro de un rectángulo
        public readonly float? _ladoC;

        public readonly float? _ladoD;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, float ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        public FormaGeometrica(int tipo, float ladoA, float ladoB, float? ladoC, float? ladoD)
        {
            Tipo = tipo;
            _lado = ladoA;
            _ladoB = ladoB;
            _ladoC = ladoC;
            _ladoD = ladoD;
        }
        
        public static bool ValidarLista(List<FormaGeometrica> formas)
        {
            if (!formas.Any())
                return false;
            else
                return true;
        }

        public static int EstablecerIdioma(int idioma)
        {
            switch (idioma)
            {
                case 1: // Castellano
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                    break;
                case 2: // Ingles
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case 3: // Frances
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                    break;
                default: // Ingles
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
            }
            return idioma;
        }

        public static List<IForma> ObtenerFormas(List<FormaGeometrica> formas, ref float areaFormas, ref float perimetroFormas)
        {
            List<IForma> tiposFormas = new List<IForma>();
            foreach (FormaGeometrica forma in formas)
            {
                switch (forma.Tipo)
                {
                    case 1:
                        formaGeometrica = Classes.Cuadrado.GetInstance();
                        break;
                    case 2:
                        formaGeometrica = Classes.TrianguloEquilatero.GetInstance();
                        break;
                    case 3:
                        formaGeometrica = Classes.Circulo.GetInstance();
                        break;
                    case 4:
                        Classes.Trapecio trapecio = Classes.Trapecio.GetInstance();
                        trapecio.LadoB = forma._ladoB;
                        trapecio.LadoC = (float)forma._ladoC;
                        trapecio.LadoD = (float)forma._ladoD;
                        formaGeometrica = Classes.Trapecio.GetInstance();
                        break;
                    case 5:
                        Classes.Rectangulo rectangulo = Classes.Rectangulo.GetInstance();
                        rectangulo.LadoB = forma._ladoB;
                        formaGeometrica = Classes.Rectangulo.GetInstance();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(@"Forma desconocida");
                }
                if (!ComprobarForma(formas, tiposFormas))
                    tiposFormas.Add(formaGeometrica);

                formaGeometrica.Sumar();
                SumarAreas(ref areaFormas, forma._lado);
                SumarPerimetros(ref perimetroFormas, forma._lado);
            }
            return tiposFormas;
        }

        public static bool ComprobarForma(List<FormaGeometrica> formas, List<IForma> tiposFormas)
        {
            bool existe = false;
            foreach (FormaGeometrica forma in formas)
            {
                foreach (IForma tipoForma in tiposFormas)
                {
                    if (forma.Tipo == tipoForma.tipo)
                        existe = true;
                    else
                        existe = false;
                }
            }
            return existe;
        }

        public static void SumarAreas(ref float areaFormas, float lado)
        {
            areaFormas += formaGeometrica.CalcularArea(lado);
        }

        public static void SumarPerimetros(ref float perimetroFormas, float lado)
        {
            perimetroFormas += formaGeometrica.CalcularPerimetro(lado);
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            EstablecerIdioma(idioma);

            if (!ValidarLista(formas))
            {
                return Idioma.ListaVacia;
            }
            else
            {
                sb.Append(Idioma.Header);

                List<IForma> formasSinRepeticion = new List<IForma>();
                var areaFormas = 0F;
                var perimetroFormas = 0F;

                formasSinRepeticion = ObtenerFormas(formas ,ref areaFormas, ref perimetroFormas);

                foreach (IForma forma in formasSinRepeticion)
                {
                    sb.Append(ObtenerLinea(forma.cantidadTotal, forma.areaTotal, forma.perimetroTotal, forma.tipo));
                    forma.Dispose();
                }

                sb.Append(Idioma.Footer);
                sb.Append($"{formas.Count} {Idioma.Formas} ");
                sb.Append($"{Idioma.Perimetro} {(perimetroFormas).ToString("#.##")} ");
                sb.Append($"{Idioma.Area} {(areaFormas).ToString("#.##")}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, float area, float perimetro, int tipo)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad)} | {Idioma.Area} {area:#.##} | {Idioma.Perimetro} {perimetro:#.##} <br/>";
            }
            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad)
        {
            switch (tipo)
            {
                case Cuadrado:
                    return cantidad == 1 ? Idioma.Cuadrado : Idioma.Cuadrados;
                case Circulo:
                    return cantidad == 1 ? Idioma.Circulo : Idioma.Circulos;
                case TrianguloEquilatero:
                    return cantidad == 1 ? Idioma.Triangulo : Idioma.Triangulos;
                case Trapecio:
                    return cantidad == 1 ? Idioma.Trapecio : Idioma.Trapecios;
                case Rectangulo:
                    return cantidad == 1 ? Idioma.Rectangulo : Idioma.Rectangulos;
            }

            return string.Empty;
        }
    }
}
