//Daniel Machado Fernández
using System;

namespace UnitTest
{
    /// <summary>
    /// Ejemplo de clase que ofrece primitivas de ángulos
    /// </summary>
    class Angulo : IComparable
    {
        /// <summary>
        /// Radianes del ángulo
        /// </summary>
        private double Radianes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radianes">Ángulo en radianes</param>
        public Angulo(double radianes) {
            this.Radianes = radianes;
        }

        int IComparable.CompareTo(object o)
        {
            Angulo ang = (Angulo)o;
            return Radianes.CompareTo(ang.Radianes);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="grados">Grados sexasegimales</param>
        public Angulo(int grados) {
            Radianes = grados / 180.0 * Math.PI;
        }

        /// <summary>
        /// Prueba de un destructor
        /// </summary>
        ~Angulo() {
            Console.WriteLine("Ejecutando el destructor de un ángulo de {0} radianes.", Radianes);
         }

        /// <summary>
        /// Calcula el seno de un ángulo
        /// </summary>
        /// <returns>El seno del objeto implícito</returns>
        public double Seno() {
            return Math.Sin(Radianes);
        }

        /// <summary>
        /// Calcula el coseno de un ángulo
        /// </summary>
        /// <returns>El coseno del ángulo</returns>
        public double Coseno() {
            return Math.Cos(Radianes);
        }

        /// <summary>
        /// Calcula la tangente de un ángulo
        /// </summary>
        /// <returns>La tangente del objeto implícito</returns>
        public double Tangente() {
            return Seno() / Coseno();
        }

        public override String ToString() {
            String res = "";
            res = "Radianes: " + Radianes;
            return res;
        }

        
    }

}
