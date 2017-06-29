using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Ex3.Test
{
    [TestClass]
    public class Ex3Test
    {
        string taula = "<table style=\"width:100%\">< tr >< th > Firstname </ th >< th > Lastname </ th >< th > Age </ th ></ tr >< tr >< td > Jill </ td >< td > Smith </ td >< td > 50 </ td ></ tr >< tr >< td > Eve </ td >< td > Jackson </ td >< td > 94 </ td ></ tr ></ table >";
        string llista = "<ul>< li > Coffee </ li >< li > Tea </ li >< li > Milk </ li ></ ul > ";
        string paragraf = "<h1 align=\"center\"><b><u>Esto es un test</u></b></h1>";
        string direccio = "<a href=\"https://www.voxelgroup.net/es/index_es.html\">CLICA AQUI!</a>";
       
        string taula_css = "<table class=\"setting\">< tr class=\"light_row\">< th class=\"default_th\"> Firstname </ th >< th class=\"default_th\"> Lastname </ th >< th class=\"default_th\"> Age </ th ></ tr >< tr class=\"dark_row\">< td class=\"default_td\"> Jill </ td >< td class=\"default_td\"> Smith </ td >< td class=\"default_td\"> 50 </ td ></ tr >< tr class=\"light_row\">< td class=\"default_td\"> Eve </ td >< td class=\"default_td\"> Jackson </ td >< td class=\"default_td\"> 94 </ td ></ tr ></ table >";
        string llista_css = "<ul class=\"green\">< li > Coffee </ li >< li > Tea </ li >< li > Milk </ li ></ ul > ";
        string paragraf_css = "<p class=\"setting\">Esto es un test</p>";
        string direccio_css = "<a class=\"red\" href=\"https://www.voxelgroup.net/es/index_es.html\">CLICA AQUI!</a>";
        [TestMethod]
        public void TestMethod1()
        {
            Ex3 ex3 = new Ex3();
            string html = paragraf + "<br/>" + taula + "<br/>" + llista+ "<br/>" + direccio;
            ex3.Label2Pdf1(html, Directory.GetCurrentDirectory());
            Assert.IsTrue(File.Exists("test1.pdf"));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Ex3 ex3 = new Ex3();
            string html = paragraf_css + "<br/>" + taula_css + "<br/>" + llista_css + "<br/>" + direccio_css;
            string css = ".green{color:green;font-family:times;font-size:20px;text-align:right;}.red{color:red;font-family: courier;font-size:24px}.setting{font-family: verdana;font-size: 24px;background-color: #F0F0F0;text-align:Center}.light_row{background - color: #F2F6FC;font - size: 13px;}.dark_row{background - color: #DADEEE;font - size: 13px;}.default_td{border: 1px solid #7F8FA9;font - size: 13px;}.default_th{background - color: #7F8FAD;border: 1px solid #000010;font - size: 13px;}";
            ex3.Label2Pdf2(html, css, Directory.GetCurrentDirectory());
            Assert.IsTrue(File.Exists("test2.pdf"));
        }
    }
}
