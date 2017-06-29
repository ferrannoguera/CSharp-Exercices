using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace Ex2.Test
{
    [TestClass]
    public class Ex2Test
    {
        static string dir = Directory.GetCurrentDirectory();
        static string xml = "main.xml";
        static string xml2 = "main2.xml";
        Ex2 ex2 = new Ex2(dir, xml);
        Ex2 ex2_2 = new Ex2(dir, xml2);
        [TestMethod]
        public void TestMethod1()
        {
            ex2.ParseandGenerateXML();
            Assert.IsTrue(File.Exists("archivo1.xml"));
            Assert.IsTrue(File.Exists("archivo2.xml"));
            Assert.IsTrue(File.Exists("archivo3.xml"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            ex2_2.ParseandGenerateXML();
            Assert.IsTrue(File.Exists("archivo1.xml"));
            Assert.IsTrue(File.Exists("archivo2.xml"));
            Assert.IsTrue(File.Exists("archivo3.xml"));
        }
    }
}
