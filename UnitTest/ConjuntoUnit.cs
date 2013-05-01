//Daniel Machado Fernández
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lista;

namespace UnitTest
{
    /// <summary>
    /// Descripción resumida de ConjuntoUnit
    /// </summary>
    [TestClass]
    public class ConjuntoUnit
    {

        Conjunto c;

        [TestInitialize]
        public void setUp()
        {
            c = new Conjunto();
        }

        [TestMethod]
        public void TestConjuntoAgregarInt()
        {
            int n = 23;
            c.Agregar(n);
            c.Agregar(n);
            Assert.IsFalse(c.EsVacia());
            c.Agregar(56);
            Assert.IsFalse(c.EsVacia());
            Assert.IsTrue(c.NumeroElementos==2);
            Console.WriteLine(c.ToString());
       
        }

        [TestMethod]
        public void TestConjuntoAgregarString()
        {
            String n = "Hola Que Tal";
            c.Agregar(n);
            c.Agregar(n);
            Assert.IsFalse(c.EsVacia());
            Assert.IsTrue(c.NumeroElementos == 1);
        }

        [TestMethod]
        public void TestConjuntoAgregarDouble()
        {
            double n = 2345.342342;
            c.Agregar(n);
            c.Agregar(n);
            Assert.IsTrue(c.NumeroElementos == 1);
            Assert.IsFalse(c.EsVacia());
        }

        [TestMethod]
        public void TestConjuntoAgregarAngulo()
        {
            Angulo n = new Angulo(35.22);
            c.Agregar(n);
            c.Agregar(n);
            Assert.IsTrue(c.NumeroElementos == 1);
            Assert.IsFalse(c.EsVacia());
        }

        [TestMethod]
        public void TestConjuntoBorrarInt()
        {
            int n = 45;
            c.Agregar(n);
            n = 23;
            Assert.IsFalse(c.Borrar(n));
            n = 43;
            Assert.IsFalse(c.Borrar(n));
            n = 98;
            Assert.IsFalse(c.Borrar(n));
            Assert.IsFalse(c.EsVacia());

            n = 45;
            Assert.IsTrue(c.Borrar(n));
            Assert.IsTrue(c.EsVacia());

            try
            {
                n = 39;
                Assert.IsFalse(c.Borrar(n));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestConjuntoBorrarDouble()
        {
            double d = -45.23;
            c.Agregar(d);

            d = 23.45;
            Assert.IsFalse(c.Borrar(d));
            d = 43.11;
            Assert.IsFalse(c.Borrar(d));
            d = 98.12;
            Assert.IsFalse(c.Borrar(d));
            d = -45.23;
            Assert.IsFalse(c.EsVacia());

            Assert.IsTrue(c.Borrar(d));
            Assert.IsTrue(c.EsVacia());

            try
            {
                d = 39.01;
                Assert.IsFalse(c.Borrar(d));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestConjuntoBorrarString()
        {
            String r = "Hola";

            c.Agregar(r);
            r = "Que Tal";
            Assert.IsFalse(c.Borrar(r));
            r = "Como estas";
            Assert.IsFalse(c.Borrar(r));
            r = "Adios";
            Assert.IsFalse(c.Borrar(r));
            Assert.IsFalse(c.EsVacia());
            r = "Hola";
            Assert.IsTrue(c.Borrar(r));
            Assert.IsTrue(c.EsVacia());

            try
            {
                Assert.IsFalse(c.Borrar("Yo no estoy"));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestConjuntoBorrarAngulo()
        {
            Angulo r = new Angulo(45);
            c.Agregar(r);
            Angulo b = new Angulo(23);
            Assert.IsFalse(c.Borrar(b));
            Angulo e = new Angulo(43);
            Assert.IsFalse(c.Borrar(e));
            Angulo d = new Angulo(98);
            Assert.IsFalse(c.Borrar(d));
            Assert.IsFalse(c.EsVacia());
            Assert.IsTrue(c.Borrar(r));
            Assert.IsTrue(c.EsVacia());

            try
            {
                r = new Angulo(39);
                Assert.IsFalse(c.Borrar(r));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestConjuntoUnionInt() { 
            int[] a = {1,2,3,4,5,6,7,8,9};

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Union(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));
            Assert.IsTrue(r.Existe(a[5]));
            Assert.IsTrue(r.Existe(a[6]));
            Assert.IsTrue(r.Existe(a[7]));
            Assert.IsTrue(r.Existe(a[8]));

            Console.WriteLine(r.ToString());

        }

        [TestMethod]
        public void TestConjuntoInterseccionInt()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Interseccion(c2);
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoDiferenciaInt()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);
            
            Conjunto r = c.Diferencia(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoUnionDouble()
        {

            double[] a = { 1.12, 2.23, 3.56, 4.45, 5.58, 6.31, 7.41, 8.36, 9.14};

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Union(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));
            Assert.IsTrue(r.Existe(a[5]));
            Assert.IsTrue(r.Existe(a[6]));
            Assert.IsTrue(r.Existe(a[7]));
            Assert.IsTrue(r.Existe(a[8]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoInterseccionDouble()
        {
            double[] a = { 1.25, 2.12, 3.36, 4.98, 5.78, 6.98, 7.55, 8.333, 9.456};

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Interseccion(c2);
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoDiferenciaDouble()
        {
            double[] a = { 1.25, 2.12, 3.36, 4.98, 5.78, 6.98, 7.55, 8.333, 9.456};

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Diferencia(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoUnionString()
        {
            String[] a = { "Hola", "de", "a", "Adios", "como", "que" , "Java", "CSharp", "JUnit", "NUnit" };

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[9]);
            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Union(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));
            Assert.IsTrue(r.Existe(a[5]));
            Assert.IsTrue(r.Existe(a[6]));
            Assert.IsTrue(r.Existe(a[7]));
            Assert.IsTrue(r.Existe(a[8]));
            Assert.IsTrue(r.Existe(a[9]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoInterseccionString()
        {
            String[] a = { "Hola", "de", "a", "Adios", "como", "que", "Java", "CSharp", "JUnit", "NUnit" };

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[9]);
            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Interseccion(c2);
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoDiferenciaString()
        {
            String[] a = { "Hola", "de", "a", "Adios", "como", "que", "Java", "CSharp", "JUnit", "NUnit" };

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[9]);
            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Diferencia(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoUnionAngulo()
        {
            Angulo[] a = { new Angulo(1.12),new Angulo(2.34), new Angulo(3.56), new Angulo(4.56), new Angulo(5.39), new Angulo(6.09), new Angulo(7.77), new Angulo(8.65), new Angulo(9.90), new Angulo(10.12) };

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[9]);
            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Union(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));
            Assert.IsTrue(r.Existe(a[5]));
            Assert.IsTrue(r.Existe(a[6]));
            Assert.IsTrue(r.Existe(a[7]));
            Assert.IsTrue(r.Existe(a[8]));
            Assert.IsTrue(r.Existe(a[9]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoInterseccionAngulo()
        {
            Angulo[] a = { new Angulo(1.12), new Angulo(2.34), new Angulo(3.56), new Angulo(4.56), new Angulo(5.39), new Angulo(6.09), new Angulo(7.77), new Angulo(8.65), new Angulo(9.90), new Angulo(10.12) };

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();

            c2.Agregar(a[9]);
            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Interseccion(c2);
            Assert.IsTrue(r.Existe(a[3]));
            Assert.IsTrue(r.Existe(a[4]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoDiferenciaAngulo()
        {
            Angulo[] a = { new Angulo(1.12), new Angulo(2.34), new Angulo(3.56), new Angulo(4.56), new Angulo(5.39), new Angulo(6.09), new Angulo(7.77), new Angulo(8.65), new Angulo(9.90), new Angulo(10.12) };

            c.Agregar(a[4]);
            c.Agregar(a[3]);
            c.Agregar(a[2]);
            c.Agregar(a[1]);
            c.Agregar(a[0]);

            Conjunto c2 = new Conjunto();
            
            c2.Agregar(a[9]);
            c2.Agregar(a[8]);
            c2.Agregar(a[7]);
            c2.Agregar(a[6]);
            c2.Agregar(a[5]);
            c2.Agregar(a[4]);
            c2.Agregar(a[3]);

            Conjunto r = c.Diferencia(c2);

            Assert.IsTrue(r.Existe(a[0]));
            Assert.IsTrue(r.Existe(a[1]));
            Assert.IsTrue(r.Existe(a[2]));

            Console.WriteLine(r.ToString());
        }

        [TestMethod]
        public void TestConjuntoToString()
        {
            c.Agregar(34);
            c.Agregar(89);
            c.Agregar(70);
            Assert.IsNotNull(c.ToString());
            Console.WriteLine(c.ToString());
        }

    }
}
