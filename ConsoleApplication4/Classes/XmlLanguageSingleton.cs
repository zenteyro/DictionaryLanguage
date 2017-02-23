using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication4
{
    public class Menu
    {
        private static readonly Menu instance = new Menu();
        private string xmlRoot = "menu.xml";
        private static XmlDocument xmlMenus;
        private static Dictionary<string, string> LangDictionary = new Dictionary<string, string>();

        private Menu()
        {
            xmlMenus = new XmlDocument();
            xmlMenus.Load(xmlRoot);
        }

        public static Menu Instance
        {
            get
            {
                return instance;
            }
        }
        public static void SetLanguage(string language)
        {
            LangDictionary.Clear();

            XmlElement xRoot = xmlMenus.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("leng");
                    if (attr != null && attr.InnerText == language)
                    {
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            LangDictionary.Add(childnode.Name, childnode.InnerText);
                        }
                    }
                }
            }
        }

        public static string GetParamText(string param)
        {
            return LangDictionary[param];
        }

    }
}
