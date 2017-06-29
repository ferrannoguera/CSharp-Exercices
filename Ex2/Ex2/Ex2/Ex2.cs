using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Ex2
{
    public class Ex2
    {
        private string direccio;
        private string xml;

        public Ex2(string direccio, string xml)
        {
            this.direccio = direccio;
            this.xml = xml;
        }


        public void esc_attr(XmlReader prod, XmlWriter esc)
        {
            while (prod.MoveToNextAttribute())
            {
                esc.WriteAttributeString(prod.Name, prod.Value);
            }
        }

        public void escriure(XmlReader prod, string i)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter esc = XmlWriter.Create(@direccio + @"\archivo" + i + ".xml", settings);
                esc.WriteProcessingInstruction("xml", "version=\"1.0\"");
                esc.WriteStartElement("line");
                esc.WriteStartElement("Product");
                esc_attr(prod, esc);
                bool stop = false;
                while (prod.Read() && !stop)
                {
                    switch (prod.NodeType)
                    {
                        case XmlNodeType.Element:
                            esc.WriteStartElement(prod.Name);
                            bool sese_tagfinal = prod.IsEmptyElement;
                            esc_attr(prod, esc);
                            if (sese_tagfinal) esc.WriteEndElement();
                            break;

                        case XmlNodeType.EndElement:
                            if (prod.Name == "Product") stop = true;
                            esc.WriteEndElement();
                            break;

                        default: break;
                    }
                }
                esc.WriteEndElement();
                esc.WriteEndDocument();
                esc.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public bool enoughsize(XmlReader parser, int i)
        {
            DriveInfo d = new DriveInfo(@direccio + @"\" + xml);
            int bytes_necesaris = 0;
            int j = 1;
            while (parser.Read())
            {
                if (parser.NodeType == XmlNodeType.Element && parser.Name == "Product")
                {
                    if (j >= i)
                    {
                        bytes_necesaris += UnicodeEncoding.Default.GetByteCount("<?xml version=\"1.0\"?>\n");
                        bytes_necesaris += UnicodeEncoding.Default.GetByteCount("<line>\n");
                        bytes_necesaris += UnicodeEncoding.Default.GetByteCount(parser.ReadOuterXml());
                        bytes_necesaris += UnicodeEncoding.Default.GetByteCount("</line>\n");
                    }
                    ++j;
                }
            }
            return (d.AvailableFreeSpace >= bytes_necesaris);
        }

        public void ParseandGenerateXML()
        {
            try
            {
                int i = 1;
                while (File.Exists(@direccio+@"\archivo" + i + ".xml")) ++i;
                XmlReader parser = XmlReader.Create(@direccio + @"\" +xml);
                if (enoughsize(parser, i))
                {
                    int j = 1;
                    parser = XmlReader.Create(@direccio + @"\" + xml);
                    while (parser.Read())
                    {
                        if (parser.NodeType == XmlNodeType.Element && parser.Name == "Product")
                        {
                            if (j >= i)
                            {
                                escriure(parser, i.ToString());
                                ++i;
                            }
                            ++j;
                        }
                    }
                }
                parser.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
