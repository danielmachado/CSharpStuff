//Daniel Machado Fernández
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Hay que destacar que las propias pruebas, realizadas con assertos, en gran medida sirven para comprobar el funcionamiento correcto de los objetos de tipo ListaGenerica y pudiendo considerarse como invariantes.
//Los Invariantes de que siempre los elementos de la lista deben ser IComparables es un invariante que se comprueba mediante la propia compilación del código ya que no dejaría compilar la clase el propio IDE.
//En cambio el del correcto funcionamiento, se comprueba mediante los propios test de esta clase.
namespace UnitTest
{
    [TestClass]
    public class ListaGenericaUnit
    {
        ListaGenerica.ListaGenerica<int> lint;
        ListaGenerica.ListaGenerica<double> ldob;
        ListaGenerica.ListaGenerica<String> ls;
        ListaGenerica.ListaGenerica<Angulo> lang;

        [TestInitialize]
        public void setUp()
        {
            lint = new ListaGenerica.ListaGenerica<int>();
            ldob = new ListaGenerica.ListaGenerica<double>();
            ls = new ListaGenerica.ListaGenerica<String>();
            lang = new ListaGenerica.ListaGenerica<Angulo>();
        }

        [TestMethod]
        public void TestGenericaAgregarInt()
        {
            int n = 56;
            lint.Agregar(n);
            Assert.IsFalse(lint.EsVacia());
            lint.Agregar(23);
            Assert.IsFalse(lint.EsVacia());

            
            //Invariante de clase, el número de elemtnos no es negativo
            Assert.IsTrue(lint.NumeroElementos > 0);
            Console.WriteLine(lint.ToString());
            //Invariante de clase, número de nodos = número de elementos
            Assert.IsTrue(CuentaElementos());
        }

        [TestMethod]
        public void TestGenericaAgregarString()
        {
            String n = "Hola Que Tal";
            ls.Agregar(n);
            n = "Como estamos";
            ls.Agregar(n);
            Assert.IsFalse(ls.EsVacia());
            Console.WriteLine(ls.ToString());
        }

        [TestMethod]
        public void TestGenericaAgregarDouble()
        {
            double n = 2345.342342;
            ldob.Agregar(n);
            n = 890.76;
            ldob.Agregar(n);
            Assert.IsFalse(ldob.EsVacia());
            Console.WriteLine(ldob.ToString());
        }

        [TestMethod]
        public void TestGenericaAgregarAngulo()
        {
            Angulo n = new Angulo(35.22);
            lang.Agregar(n);
            n = new Angulo(20.34);
            lang.Agregar(n);
            Assert.IsFalse(lang.EsVacia());
            //Invariante de clase, elementos son distintos de null
            Assert.IsTrue(EsConsistente());
            Console.WriteLine(lang.ToString());
        }

        [TestMethod]
        public void TestGenericaBorrarInt()
        {
            int n = 45;
            lint.Agregar(n);
            n = 23;
            Assert.IsFalse(lint.Borrar(n));
            n = 43;
            Assert.IsFalse(lint.Borrar(n));
            n = 98;
            Assert.IsFalse(lint.Borrar(n));
            Assert.IsFalse(lint.EsVacia());

            n = 45;
            Assert.IsTrue(lint.Borrar(n));
            Assert.IsTrue(lint.EsVacia());

            try
            {
                n = 39;
                Assert.IsFalse(lint.Borrar(n));
            }
            catch (InvalidOperationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestGenericaBorrarDouble()
        {
            double d = -45.23;
            ldob.Agregar(d);

            d = 23.45;
            Assert.IsFalse(ldob.Borrar(d));
            d = 43.11;
            Assert.IsFalse(ldob.Borrar(d));
            d = 98.12;
            Assert.IsFalse(ldob.Borrar(d));
            d = -45.23;
            Assert.IsFalse(ldob.EsVacia());

            Assert.IsTrue(ldob.Borrar(d));
            Assert.IsTrue(ldob.EsVacia());

            try
            {
                d = 39.01;
                Assert.IsTrue(ldob.Borrar(d));
            }
            catch (InvalidOperationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestGenericaBorrarString()
        {
            String r = "Hola";

            ls.Agregar(r);
            r = "Que Tal";
            Assert.IsFalse(ls.Borrar(r));
            r = "Como estas";
            Assert.IsFalse(ls.Borrar(r));
            r = "Adios";
            Assert.IsFalse(ls.Borrar(r));
            Assert.IsFalse(ls.EsVacia());
            r = "Hola";
            Assert.IsTrue(ls.Borrar(r));
            Assert.IsTrue(ls.EsVacia());

            try
            {
                Assert.IsTrue(ls.Borrar("Yo no estoy"));
            }
            catch (InvalidOperationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestGenericaBorrarAngulo()
        {
            Angulo r = new Angulo(45);
            lang.Agregar(r);
            Angulo b = new Angulo(23);
            Assert.IsFalse(lang.Borrar(b));
            Angulo c = new Angulo(43);
            Assert.IsFalse(lang.Borrar(c));
            Angulo d = new Angulo(98);
            Assert.IsFalse(lang.Borrar(d));
            Assert.IsFalse(lang.EsVacia());
            Assert.IsTrue(lang.Borrar(r));
            Assert.IsTrue(lang.EsVacia());

            try
            {
                r = new Angulo(39);
                Assert.IsTrue(lang.Borrar(r));
            }
            catch (InvalidOperationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestGenericaGetElementoInt()
        {
            int a = 34;

            lint.Agregar(a);
            a = 43;
            lint.Agregar(a);
            a = 89;
            lint.Agregar(a);

            Console.WriteLine(lint.ToString());
            a = 43;
            Assert.AreEqual(lint.GetElemento(1), a);
            a = 89;
            Assert.AreNotEqual(lint.GetElemento(0), a);

        }

        [TestMethod]
        public void TestGenericaGetElementoDouble()
        {
            double a = 34.23;
            ldob.Agregar(a);
            a = 43.22;
            ldob.Agregar(a);
            a = 89.34;
            ldob.Agregar(a);

            Console.WriteLine(ldob.ToString());

            a = 43.22;
            Assert.AreEqual(ldob.GetElemento(1), a);
            a = 89.3432;
            Assert.AreNotEqual(ldob.GetElemento(0), a);

        }

        [TestMethod]
        public void TestGenericaGetElementoString()
        {
            String a = "hola";

            ls.Agregar(a);
            a = "que tal";
            ls.Agregar(a);
            a = "bien";
            ls.Agregar(a);

            Console.WriteLine(ls.ToString());

            a = "hola";
            Assert.AreEqual(ls.GetElemento(1), a);
            a = "bien, y tu";
            Assert.AreNotEqual(ls.GetElemento(0), a);

        }

        [TestMethod]
        public void TestGenericaGetElementoAngulo()
        {
            Angulo a = new Angulo(34);
            Angulo b = new Angulo(43);
            Angulo c = new Angulo(89);

            lang.Agregar(a);
            lang.Agregar(b);
            lang.Agregar(c);

            Console.WriteLine(lang.ToString());

            Assert.AreEqual(lang.GetElemento(1), b);
            Assert.AreNotEqual(lang.GetElemento(0), c);

        }

        [TestMethod]
        public void TestGenericaSetElementoInt()
        {
            int a = 34;
            lint.Agregar(a);
            a = 43;
            lint.Agregar(a);
            a = 89;
            lint.Agregar(a);
            Console.WriteLine(lint.ToString());
            a = 99;
            lint.SetElemento(2, a);
            Console.WriteLine(lint.ToString());
            Assert.IsTrue((int)lint.GetElemento(2) == a);
        }

        [TestMethod]
        public void TestGenericaSetElementoDouble()
        {
            double a = 34.23;
            ldob.Agregar(a);
            a = 43.22;
            ldob.Agregar(a);
            a = 89.221;
            ldob.Agregar(a);
            Console.WriteLine(ldob.ToString());
            a = 99.99;
            ldob.SetElemento(2, a);
            Console.WriteLine(ldob.ToString());
            Assert.IsTrue((double)ldob.GetElemento(2) == a);
        }

        [TestMethod]
        public void TestGenericaSetElementoString()
        {
            String s = "Hola";
            ls.Agregar(s);
            s = "Que tal";
            ls.Agregar(s);
            s = "Bien";
            ls.Agregar(s);
            Console.WriteLine(ls.ToString());
            s = "y tu";
            ls.SetElemento(2, s);
            Console.WriteLine(ls.ToString());
            Assert.IsTrue((String)ls.GetElemento(2) == s);
        }

        [TestMethod]
        public void TestGenericaSetElementoAngulo()
        {
            Angulo a = new Angulo(34);
            Angulo b = new Angulo(43);
            Angulo c = new Angulo(89);
            lang.Agregar(a);
            lang.Agregar(b);
            lang.Agregar(c);
            Console.WriteLine(lang.ToString());
            Angulo d = new Angulo(99);
            lang.SetElemento(2, d);
            Console.WriteLine(lang.ToString());
            Assert.IsTrue((Angulo)lang.GetElemento(2) == d);
        }

        [TestMethod]
        public void TestGenericaBuscarInt()
        {
            int a = 34;
            lint.Agregar(a);
            a = 43;
            lint.Agregar(a);
            a = 89;
            lint.Agregar(a);
            Console.WriteLine(lint.ToString());
            
            Assert.IsTrue(lint.Buscar(a)==2);
            Console.WriteLine(lint.ToString());
            
        }

        [TestMethod]
        public void TestGenericaBuscarDouble()
        {
            double a = 34.23;
            ldob.Agregar(a);
            a = 43.22;
            ldob.Agregar(a);
            a = 89.221;
            ldob.Agregar(a);
            Console.WriteLine(ldob.ToString());
            
            Assert.IsTrue(ldob.Buscar(a) == 2);
            Console.WriteLine(ldob.ToString());
           
        }

        [TestMethod]
        public void TestGenericaBuscarString()
        {
            String s = "Hola";
            ls.Agregar(s);
            s = "Que tal";
            ls.Agregar(s);
            s = "Bien";
            ls.Agregar(s);
            Console.WriteLine(ls.ToString());
            
            Assert.IsTrue(ls.Buscar(s) == 0);
            Console.WriteLine(ls.ToString());
            
        }

        [TestMethod]
        public void TestGenericaBuscarAngulo()
        {
            Angulo a = new Angulo(34);
            Angulo b = new Angulo(43);
            Angulo c = new Angulo(89);
            lang.Agregar(a);
            lang.Agregar(b);
            lang.Agregar(c);
            Console.WriteLine(lang.ToString());
            
            Assert.IsTrue(lang.Buscar(c) == 2);
            Console.WriteLine(lang.ToString());
            
        }

        [TestMethod]
        public void TestGenericaToString()
        {
            lint.Agregar(34);
            lint.Agregar(43);
            lint.Agregar(89);
            Assert.IsNotNull(lint.ToString());
            Console.WriteLine(lint.ToString());
        }

        /// <summary>
        /// Se realiza este método para comprobar el invariante de clase: El número de elementos debe ser el mismo que el de nodos
        /// </summary>
        /// <returns></returns>
        private bool CuentaElementos() {
            int cont = 0;
            int ant = lint.NumeroElementos;
            while (!lint.EsVacia()) {
                lint.Borrar(lint.GetElemento(0));
                cont++;

            }

            return cont == ant;
        }

        /// <summary>
        /// Se comprueba que no existen elementos de tipo Null
        /// </summary>
        /// <returns></returns>
        private bool EsConsistente() {
            for (int i = 0;i < lang.NumeroElementos; i++) {
                if (lang.GetElemento(i) == null)
                    return false;
            }
            return true;
        }

    }
}
