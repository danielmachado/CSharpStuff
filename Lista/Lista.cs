//Daniel Machado Fernández
using System;

namespace Lista
{

    /// <summary>
    /// Lista simplemente enlazada con un enlace al inicio y otro al final que alberga Objects
    /// </summary>
    public class Lista
    {
       
        public Nodo Cabeza { get; set; }
        public Nodo Fin { get; set; }
        public int numeroElementos { get; set; }

        /// <summary>
        /// Constructor de la clase Lista
        /// </summary>
        public Lista()
        {

            Cabeza = null;
            Fin = null;
            numeroElementos = 0;
            

        }

        /// <summary>
        /// Clase que representa un nodo interno de la lista enlazada simple
        /// </summary>
        public class Nodo
        {
            public Object Info { get; set; }
            public Nodo Sig { get; set; }

        }

        /// <summary>
        /// Agrega un elemento a la lista, comprueba que este vacia o que no para comportarse en función de ello.
        /// </summary>
        /// <param name="info">Object que se insertara en la lista</param>
        /// <returns>True si todo ha ido bien</returns>
        public bool Agregar(Object info)
        {
            Nodo n = new Nodo();
            n.Info = info;
            n.Sig = null;

            if (EsVacia())
            {
                Fin = n;
                Cabeza = n;
               
            }
            else
            {

                Fin.Sig = n;
                Fin = n;
                

            }
            numeroElementos++;
            
            return true;
        }

        /// <summary>
        /// Borra un elemento de la lista (primera ocurrencia)
        /// </summary>
        /// <param name="o">Objeto que se quiera quitar de la lista</param>
        /// <returns>True si se ha podido borrar el elemento</returns>
        public bool Borrar(Object o)
        {
            Nodo aux = Cabeza;
            bool encontrado = false;

            if (!EsVacia())
            {
                if (Cabeza.Info.Equals(o))
                {
                   
                    Cabeza = Cabeza.Sig;
                    numeroElementos--;
                    return true;
                }
                else
                {
                    while (!encontrado && aux.Sig != null)
                    {
                        if (aux.Sig.Info.Equals(o))
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
                            numeroElementos--;
                            return true;
                        }
                        else
                        {
                            
                            aux.Sig = aux.Sig.Sig;
                            numeroElementos--;
                            return true;
                        }
                    }
                }
                
                return false;
            }
            else
            {
              
                throw new ApplicationException("La lista no debe estar vacía");
            }

        }

        /// <summary>
        /// Convierte a una cadena de texto la Lista
        /// </summary>
        /// <returns>Lista convertida en String</returns>
        public override String ToString()
        {
            String rs = "";

            Nodo aux = Cabeza;
            int i = 0;

            while (aux != null)
            {
                rs += "Nodo[" + i + "]:" + aux.Info.ToString() + "\n";
                i++;
                aux = aux.Sig;
            }

            return rs;
        }

        /// <summary>
        /// Inserta un elemento en la posición especificada
        /// </summary>
        /// <param name="index">posición donde se insertará el elemento</param>
        /// <param name="o">elemento a insertar en la posición indicada</param>
        /// <returns>Objeto que estaba en la posición en la que se inserta</returns>
        public Object SetElemento(int index, Object o)
        {
            Object ret;
            if (numeroElementos < index)
            {
              
                throw new ApplicationException("Índice no correcto");
            }

            else
            {
                Nodo aux;
                aux = Cabeza;
                for (int i = 0; i < index; i++)
                {
                    aux = aux.Sig;
                }
                ret = aux.Info;
                aux.Info = o;
            }

            
            return ret;
        }

        /// <summary>
        /// Obtiene un elemento de una posición concreta
        /// </summary>
        /// <param name="index">posición de la lista de la que se quiere obtener el elemento (comienza en 0)</param>
        /// <returns>el elemento de la posición indicada</returns>
        public Object GetElemento(int index)
        {

            Object ret;

            if (numeroElementos < index)
            {
            
                throw new ApplicationException("Índice no correcto");
            }
            else
            {
                Nodo aux;
                aux = Cabeza;
                for (int i = 0; i < index; i++)
                {
                    aux = aux.Sig;
                }
                ret = aux.Info;
            }
            
            return ret;
        }



        /// <summary>
        /// Comprueba que la lista esta vacia
        /// </summary>
        /// <returns>bool true si esta vacia</returns>
        public bool EsVacia()
        {
            return (numeroElementos == 0);
        }

    }
}
