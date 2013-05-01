//Daniel Machado Fernández
using System;
using System.Diagnostics;

namespace ListaGenerica
{
    /// <summary>
    /// Lista similar a la implementada en el otro proyecto, esta vez con genericidad y doblemente enlazada
    /// </summary>
    /// <typeparam name="T">Genérico, puede ser de cualquier tipo menos Null</typeparam>
    public class ListaGenerica<T> where T : IComparable
    {
        public Nodo Cabeza { get; set; }
        public Nodo Fin { get; set; }
        public int NumeroElementos { get; set; }
        private bool flag;

        /// <summary>
        /// Constructor de la clase ListaGenerica
        /// </summary>
        public ListaGenerica()
        {
            Cabeza = null;
            NumeroElementos = 0;
            flag = false;

        }
        /// <summary>
        /// Nodo interno de la clase para realizar asignación de memoria dinámica
        /// </summary>
        public class Nodo
        {
            public T Info { get; set; }
            public Nodo Sig { get; set; }
            public Nodo Ant { get; set; }
        }

        /// <summary>
        /// Agrega un elemento a la Lista
        /// </summary>
        /// <param name="obj">Objeto genérico a agregar</param>
        /// <returns>true si ha podido añadirse, false si no</returns>
        public bool Agregar(T obj)
        {

            if (obj == null)
                throw new ArgumentException("No se puede agregar Null por que en caso de agregarse, no se podría ordenar");

            Nodo n = new Nodo();
            n.Info = obj;
            n.Sig = null;
            n.Ant = null;

            if (EsVacia())
            {
                Fin = n;
                Cabeza = n;
            }
            else
            {

                Fin.Sig = n;
                n.Ant = Fin;
                Fin = n;

            }
            NumeroElementos++;

            Ordenar();

            Debug.Assert(!EsVacia(), "Después de insertar, la lista no tendría que estar vacía");
            //No se puede comprobar el número de elementos debido a que se modificaría la estructura original.
            Debug.Assert(EstaOrdenada(), "La lista debe quedar ordenada");

            return true;
        }
        /// <summary>
        /// Busca un objeto dentro de la ListaGenerica
        /// </summary>
        /// <param name="obj">Objeto a buscar</param>
        /// <returns>Posición en la que se ha encontrado, -1 si no se ha encontrado</returns>
        public int Buscar(T obj)
        {
            if (EsVacia())
                throw new InvalidOperationException("La lista esta vacía, no hay nada que buscar");
            if (obj == null)
                throw new ArgumentException("El elemento a buscar no puede ser null ya que no se permiten este tipo de objetos");

            Nodo Aux = Cabeza;

            for (int i = 0; i < NumeroElementos; i++)
            {
                if (Aux.Info.CompareTo(obj) == 0)
                {
                    Debug.Assert(i > 0 && i <= NumeroElementos, "Se está devolviendo un índice que no es correcto");
                    return i;
                }
                else
                    Aux = Aux.Sig;
            }
            //Sería absurdo comprobar esta postcondición puesto que se retorna el valor sin más.
            return -1;
            //Para comprobar la última postcondición, sería una unión de los dos anteriores.
        }
        /// <summary>
        /// Borra un elemento (Si existe) de la ListaGenerica
        /// </summary>
        /// <param name="obj">Objeto a borrar</param>
        /// <returns>true si se ha podido borrar, false si no</returns>
        public bool Borrar(T obj)
        {
            if (EsVacia())
                throw new InvalidOperationException("La lista no puede estar vacía, no habría nada que borrar");
            if (obj == null)
                throw new ArgumentException("No se pueden utilizar null en esta lista");

            Nodo aux = Cabeza;
            bool encontrado = false;


            if (Cabeza.Info.CompareTo(obj) == 0)
            {
                Cabeza.Ant = null;
                Cabeza = Cabeza.Sig;
                NumeroElementos--;

                return true;
            }
            else
            {
                while (!encontrado && aux.Sig != null)
                {
                    if (aux.Sig.Info.CompareTo(obj) == 0)
                        encontrado = true;
                    else
                        aux = aux.Sig;
                }

                if (encontrado)
                {
                    if (aux.Sig.Sig == null)
                    {
                        Fin = aux;
                        Fin.Sig = null;
                        NumeroElementos--;
                        return true;
                    }
                    else
                    {
                        aux.Sig.Ant = null;
                        aux.Sig = aux.Sig.Sig;
                        NumeroElementos--;
                        //No se debería de comprobar la postcondición de numero de elementos debido a que se modificaría el programa
                        return true;
                    }
                }
            }
            //Pasa lo mismo que con la postcondición anterior.
            return false;

        }

        public override String ToString()
        {
            if (EsVacia())
                throw new InvalidOperationException("La lista está vacía, no es necesario realizar un ToString");

            String rs = "";

            Nodo aux = Cabeza;
            int i = 0;

            while (aux != null)
            {
                rs += "Nodo[" + i + "]:" + aux.Info.ToString() + "\n";
                i++;
                aux = aux.Sig;
            }
            Debug.Assert(rs.Length > 0, "La lista estaba vacía y se intentó realizar un ToString");
            //Debería de comprobarse el número de elementos, pero se modificaría la estructura del programa.
            return rs;
        }
        /// <summary>
        /// Obtiene un elemento de una posición concreta de la ListaGenerica
        /// </summary>
        /// <param name="index">índice de la lista (comienza en 0)</param>
        /// <returns>el elemento encontrado o null si no se ha podido encontrar</returns>
        public T GetElemento(int index)
        {
            T ret;

            if (NumeroElementos < index || index < 0)
                throw new ArgumentException("Índice no correcto");
            if (EsVacia())
                throw new InvalidOperationException("No se puede obtener un elemento de una lista vacía");

            Nodo aux;
            aux = Cabeza;
            for (int i = 0; i < index; i++)
            {
                aux = aux.Sig;
            }
            ret = aux.Info;

            Debug.Assert(ret != null, "Se está devolviendo null, algo no ha como debería.");

            return ret;
        }

        /// <summary>
        /// Reemplaza un elemento de la ListaGenerica por otro pasado por parámetro en un índice concreto
        /// </summary>
        /// <param name="index">posición concreta donde se quiere hacer la inserción (comienza en 0)</param>
        /// <param name="o">Objeto a insertar</param>
        /// <returns>Objeto que se encontraba en la posición antes de la inserción</returns>
        public T SetElemento(int index, T o)
        {
            T ret;
            if (NumeroElementos < index || index < 0)
                throw new ArgumentException("Índice no correcto");

            if (o == null)
                throw new ArgumentException("El objeto a insertar no puede ser null");
            if (EsVacia())
                throw new InvalidOperationException("La lista está vacía, no se puede realizar esta operación");
                Nodo aux;
                aux = Cabeza;
                for (int i = 0; i < index; i++)
                {
                    aux = aux.Sig;
                }
                ret = aux.Info;
                aux.Info = o;
            
            if (!flag)
                Ordenar();
            Debug.Assert(ret != null, "La lista estaba en estado inconsistente");
            //Se tendría que comprobar el número de elementos y la alteración de la lista, pero se modificaría el programa
            return ret;
        }
        /// <summary>
        /// Comprueba si la lista está vacía
        /// </summary>
        /// <returns>true si está vacía, false si no</returns>
        public bool EsVacia() { return (NumeroElementos == 0); }
        /// <summary>
        /// Comprueba si la ListaGenérica está ordenada (para comprobar Contratos)
        /// </summary>
        /// <returns>true si está ordenada, false si no</returns>
        private bool EstaOrdenada()
        {

            for (int i = 1; i < NumeroElementos; i++)
            {
                if (GetElemento(i).CompareTo(GetElemento(i - 1)) <= 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Ordena la ListaGenerica mediante el método de la burbuja
        /// </summary>
        private void Ordenar()
        {

            T temp = default(T);

            for (int i = 1; i < NumeroElementos; i++)
            {

                for (int x = NumeroElementos - 1; x >= i; x--)
                {
                    if (((T)GetElemento(x)).CompareTo((T)GetElemento(x - 1)) < 0)
                    {
                        temp = GetElemento(x);
                        flag = true;
                        SetElemento(x, GetElemento(x - 1));
                        SetElemento(x - 1, temp);
                    }
                }
            }
            flag = false;

        }

    }
}
