//Daniel Machado Fernández
using System;

namespace Lista
{
    /// <summary>
    /// Conjunto que basa su implementación en la Lista de Objects pero con IComparables implementada en este proyecto
    /// </summary>
    public class Conjunto
    {
        public Lista L { get; set; }

        public int NumeroElementos { get; set; }
        /// <summary>
        /// Constructor de la clase Conjunto
        /// </summary>
        public Conjunto() {
            L = new Lista();
        }

        /// <summary>
        /// Agrega IComparables a la Lista, también los ordena. Utiliza un flag para poder utilizar SetElemento
        /// </summary>
        /// <param name="obj">Objeto de tipo IComparable para poder tener un Conjunto ordenado</param>
        /// <returns>true si todo va correcto, false si ha sucedido algún problema</returns>
        public bool Agregar (IComparable obj) {

            if(!Existe(obj)){
                L.Agregar(obj);
                NumeroElementos++;
                Ordenar();
                return true;
            }

            return false;

        }

        /// <summary>
        /// Borra un elemento (si existe) del Conjunto
        /// </summary>
        /// <param name="obj">IComparable a borrar</param>
        /// <returns>true si se ha podido borrar, false si no</returns>
        public bool Borrar(IComparable obj) {
            
            for (int i = 0; i < NumeroElementos; i++)
            {
                IComparable ic = (IComparable)L.GetElemento(i);
                if (ic.CompareTo(obj) == 0)
                {
                    L.Borrar(obj);
                    NumeroElementos--;
                    return true;
                }
            }
            
            return false;
        }

        public override String ToString() {
            return L.ToString();
        }

        /// <summary>
        /// Indica si existe un objeto dentro del Conjunto
        /// </summary>
        /// <param name="obj">Objeto a buscar</param>
        /// <returns>true o false si lo encuentra o no</returns>
        public bool Existe(IComparable obj) {

            for (int i = 0; i < NumeroElementos; i++)
            {
                IComparable ic = (IComparable)L.GetElemento(i);
                if (ic.CompareTo(obj) == 0)
                    return true;
            }
            
            return false;
        }
        /// <summary>
        /// Realiza intersección de conjuntos sobre el propio objeto y otro pasado por parámetro
        /// </summary>
        /// <param name="c1">Conjunto con el que se realiza la intersección</param>
        /// <returns>Un nuevo conjunto resultante de la operación</returns>
        public Conjunto Interseccion(Conjunto c1) {

            Conjunto c = new Conjunto();

            for (int i = 0; i < c1.NumeroElementos; i++) {
                IComparable o = (IComparable)c1.L.GetElemento(i);
                if(Existe(o)){
                    c.Agregar(o);
                }
            }

            return c;
        }
        /// <summary>
        /// Realiza la unión de dos conjuntos sobre el propio objeto y otro pasado por parámetro
        /// </summary>
        /// <param name="c1">Conjunto con el que se realizará la unión</param>
        /// <returns>Un nuevo conjunto resultante de la opreación</returns>
        public Conjunto Union(Conjunto c1)
        {
            Conjunto c = new Conjunto();

            for (int i = 0; i < c1.NumeroElementos; i++)
            {
                IComparable o = (IComparable)c1.L.GetElemento(i);
                if (!c.Existe(o))
                {
                    c.Agregar(o);
                }
            }

            for (int i = 0; i < NumeroElementos; i++)
            {
                IComparable o = (IComparable)L.GetElemento(i);
                if (!c.Existe(o))
                {
                    c.Agregar(o);
                }
            }

            return c;
        }
        /// <summary>
        /// Realiza la diferencia de conjuntos entre el propio objeto y uno pasado por parámetro
        /// </summary>
        /// <param name="c1">Conjunto al que se le aplicará la diferencia junto con el propio objeto</param>
        /// <returns>Un nuevo conjunto resultante de la operación</returns>
        public Conjunto Diferencia(Conjunto c1)
        {
            Conjunto c = this;

            for (int i = 0; i < c1.NumeroElementos; i++)
            {
                IComparable o = (IComparable)c1.L.GetElemento(i);
                if (Existe(o))
                {
                    c.Borrar(o);
                }
            }

            return c;
        }

        /// <summary>
        /// Indica si la lista está vacía
        /// </summary>
        /// <returns>true si está vacía, false si no lo está</returns>
        public bool EsVacia() {
            return L.EsVacia();
        }

        /// <summary>
        /// Ordena el conjunto mediante el método de la burbuja.
        /// </summary>
        private void Ordenar() {

            IComparable temp = null;

            for (int i = 1; i < NumeroElementos; i++)
            {

                for (int x = NumeroElementos - 1; x >= i; x--)
                {
                    if (((IComparable)L.GetElemento(x)).CompareTo((IComparable)L.GetElemento(x-1)) < 0)
                    {
                        temp = (IComparable)L.GetElemento(x);
                        L.SetElemento(x,(IComparable)L.GetElemento(x-1));
                        L.SetElemento(x - 1, temp);
                    }
                }
            }

        }

    }
}
