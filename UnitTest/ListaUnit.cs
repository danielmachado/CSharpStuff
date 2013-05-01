//Daniel Machado Fernández
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class ListaUnit
    {
        Lista.Lista l;

        [TestInitialize]
        public void setUp()
        {
            l = new Lista.Lista();
        }

        [TestMethod]
        public void TestSimpleAgregarInt()
        {
            int n = 23;
            l.Agregar(n);
            Assert.IsFalse(l.EsVacia());
            l.Agregar(56);
            Assert.IsFalse(l.EsVacia());
        }

        [TestMethod]
        public void TestSimpleAgregarString()
        {
            String n = "Hola Que Tal";
            l.Agregar(n);
            Assert.IsFalse(l.EsVacia());
        }

        [TestMethod]
        public void TestSimpleAgregarDouble()
        {
            double n = 2345.342342;
            l.Agregar(n);
            Assert.IsFalse(l.EsVacia());
        }

        [TestMethod]
        public void TestSimpleAgregarAngulo()
        {
            Angulo n = new Angulo(35.22);
            l.Agregar(n);
            Assert.IsFalse(l.EsVacia());
        }

        [TestMethod]
        public void TestSimpleBorrarInt()
        {
            int n = 45;
            l.Agregar(n);
            n = 23;
            Assert.IsFalse(l.Borrar(n));
            n = 43;
            Assert.IsFalse(l.Borrar(n));
            n = 98;
            Assert.IsFalse(l.Borrar(n));
            Assert.IsFalse(l.EsVacia());

            n = 45;
            Assert.IsTrue(l.Borrar(n));
            Assert.IsTrue(l.EsVacia());

            try
            {
                n = 39;
                Assert.IsTrue(l.Borrar(n));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestSimpleBorrarDouble()
        {
            double d = -45.23;
            l.Agregar(d);

            d = 23.45;
            Assert.IsFalse(l.Borrar(d));
            d = 43.11;
            Assert.IsFalse(l.Borrar(d));
            d = 98.12;
            Assert.IsFalse(l.Borrar(d));
            d = -45.23;
            Assert.IsFalse(l.EsVacia());

            Assert.IsTrue(l.Borrar(d));
            Assert.IsTrue(l.EsVacia());

            try
            {
                d = 39.01;
                Assert.IsTrue(l.Borrar(d));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestSimpleBorrarString()
        {
            String r = "Hola";

            l.Agregar(r);
            r = "Que Tal";
            Assert.IsFalse(l.Borrar(r));
            r = "Como estas";
            Assert.IsFalse(l.Borrar(r));
            r = "Adios";
            Assert.IsFalse(l.Borrar(r));
            Assert.IsFalse(l.EsVacia());
            r = "Hola";
            Assert.IsTrue(l.Borrar(r));
            Assert.IsTrue(l.EsVacia());

            try
            {
                Assert.IsTrue(l.Borrar("Yo no estoy"));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestSimpleBorrarAngulo()
        {
            Angulo r = new Angulo(45);
            l.Agregar(r);
            Angulo b = new Angulo(23);
            Assert.IsFalse(l.Borrar(b));
            Angulo c = new Angulo(43);
            Assert.IsFalse(l.Borrar(c));
            Angulo d = new Angulo(98);
            Assert.IsFalse(l.Borrar(d));
            Assert.IsFalse(l.EsVacia());
            Assert.IsTrue(l.Borrar(r));
            Assert.IsTrue(l.EsVacia());

            try
            {
                r = new Angulo(39);
                Assert.IsTrue(l.Borrar(r));
            }
            catch (ApplicationException a)
            {
                Assert.IsNotNull(a);
            }
        }

        [TestMethod]
        public void TestSimpleGetElementoInt()
        {
            int a = 34;

            l.Agregar(a);
            a = 43;
            l.Agregar(a);
            a = 89;
            l.Agregar(a);

            Console.WriteLine(l.ToString());
            a = 43;
            Assert.AreEqual(l.GetElemento(1),a);
            a = 89;
            Assert.AreNotEqual(l.GetElemento(0), a);

        }

        [TestMethod]
        public void TestSimpleGetElementoDouble()
        {
            double a = 34.23;
            l.Agregar(a);
            a = 43.22;
            l.Agregar(a);
            a = 89.34;
            l.Agregar(a);

            Console.WriteLine(l.ToString());

            a = 43.22;
            Assert.AreEqual(l.GetElemento(1), a);
            a = 89.3432;
            Assert.AreNotEqual(l.GetElemento(0), a);

        }

        [TestMethod]
        public void TestSimpleGetElementoString()
        {
            String a = "hola";

            l.Agregar(a);
            a = "que tal";
            l.Agregar(a);
            a = "bien";
            l.Agregar(a);

            Console.WriteLine(l.ToString());

            a = "que tal";
            Assert.AreEqual(l.GetElemento(1), a);
            a = "bien, y tu";
            Assert.AreNotEqual(l.GetElemento(0), a);

        }

        [TestMethod]
        public void TestSimpleGetElementoAngulo()
        {
            Angulo a = new Angulo(34);
            Angulo b = new Angulo(43);
            Angulo c = new Angulo(89);

            l.Agregar(a);
            l.Agregar(b);
            l.Agregar(c);

            Console.WriteLine(l.ToString());

            Assert.AreEqual(l.GetElemento(1), b);
            Assert.AreNotEqual(l.GetElemento(0), c);

        }

        [TestMethod]
        public void TestSimpleSetElementoInt()
        {
            int a = 34;
            l.Agregar(a);
            a = 43;
            l.Agregar(a);
            a = 89;
            l.Agregar(a);
            Console.WriteLine(l.ToString());
            a = 99;
            l.SetElemento(2, a);
            Console.WriteLine(l.ToString());
            Assert.IsTrue((int)l.GetElemento(2)==a);
        }

        [TestMethod]
        public void TestSimpleSetElementoDouble()
        {
            double a = 34.23;
            l.Agregar(a);
            a = 43.22;
            l.Agregar(a);
            a = 89.221;
            l.Agregar(a);
            Console.WriteLine(l.ToString());
            a = 99.99;
            l.SetElemento(2, a);
            Console.WriteLine(l.ToString());
            Assert.IsTrue((double)l.GetElemento(2) == a);
        }

        [TestMethod]
        public void TestSimpleSetElementoString()
        {
            String s = "Hola";
            l.Agregar(s);
            s = "Que tal";
            l.Agregar(s);
            s = "Bien";
            l.Agregar(s);
            Console.WriteLine(l.ToString());
            s = "y tu";
            l.SetElemento(2, s);
            Console.WriteLine(l.ToString());
            Assert.IsTrue((String)l.GetElemento(2) == s);
        }

        [TestMethod]
        public void TestSimpleSetElementoAngulo()
        {
            Angulo a = new Angulo(34);
            Angulo b = new Angulo(43);
            Angulo c = new Angulo(89);
            l.Agregar(a);
            l.Agregar(b);
            l.Agregar(c);
            Console.WriteLine(l.ToString());
            Angulo d = new Angulo(99);
            l.SetElemento(2, d);
            Console.WriteLine(l.ToString());
            Assert.IsTrue((Angulo)l.GetElemento(2) == d);
        }

        [TestMethod]
        public void TestSimpleToString()
        {
            l.Agregar(34);
            l.Agregar(43);
            l.Agregar(89);
            Assert.IsNotNull(l.ToString());
            Console.WriteLine(l.ToString());
        }

    }
}
