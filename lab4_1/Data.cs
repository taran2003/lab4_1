using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;


namespace lab4_1
{
    class Data
    {
        public List<String> name = new List<string>();
        public List<List<List<String>>> product = new List<List<List<string>>>() {  };
        public Data(string FileName)
        {
            XmlDocument xDoc = new XmlDocument();
            for (int i = 0; i < product.Count; i++)
            {
                product[i] = new List<List<string>>();
            }
            xDoc.Load(FileName);
            name = GetName(xDoc);
            product = GetInfo(xDoc);
        }
        List<string> GetName(XmlDocument xDoc)
        {
            List<string> rez = new List<string>();
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                    rez.Add(attr.Value);
                }
            }
            return rez;
        }
        public List<List<List<string>>> GetInfo(XmlDocument xDoc)
        {
            List<List<List<String>>> rez = new List<List<List<string>>>();

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                List<List<string>> buf = new List<List<string>>();
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    List<String> c = new List<string>();
                    foreach (XmlNode b in childnode) c.Add(b.InnerText);
                    buf.Add(c);
                }
                rez.Add(buf);
            }
            return rez;
        }
    }
}
