using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    public class Ex3
    {
        public void Label2Pdf1(String label, String directori)
        {
            try
            {
                MemoryStream msOutput = new MemoryStream();
                TextReader reader = new StringReader(label);
                Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                //creem un listener perque escrigui en format pdf
                PdfWriter writer = PdfWriter.GetInstance(document, msOutput);
                document.Open();
                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(label));
                
                document.Close();
                //iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(label), new StringReader(css));
                //ho guardem al path corresponent
                String testFile = Path.Combine(@directori, "test1.pdf");
                System.IO.File.WriteAllBytes(testFile, msOutput.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }

        public void Label2Pdf2(String label, String css, String directori)
        {
            try
            {
                MemoryStream msOutput = new MemoryStream();
                TextReader reader = new StringReader(label);
                Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                //creem un listener perque escrigui en format pdf
                PdfWriter writer = PdfWriter.GetInstance(document, msOutput);
                document.Open();
                var mslabel = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(label));
                var mscss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(css));
                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, mslabel,mscss);
                document.Close();
                //ho guardem al path corresponent
                String testFile = Path.Combine(@directori, "test2.pdf");
                System.IO.File.WriteAllBytes(testFile, msOutput.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }
    }
}
