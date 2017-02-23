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
        private static string language;

        public static Dictionary<string, string> LanguageItems;
        
        public static string Language
        {
            set
            {
                language = value;

                LanguageItems.Clear();

                XmlElement xRoot = xmlMenus.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("leng");
                        if (attr != null && attr.InnerText == value)
                        {
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                LanguageItems.Add(childnode.Name, childnode.InnerText);
                            }
                        }
                    }
                }
            }
            get
            {
                return language;
            }

        }

        private Menu()
        {
            xmlMenus = new XmlDocument();
            xmlMenus.Load(xmlRoot);
            LanguageItems = new Dictionary<string, string>();
        }

        public static Menu Instance
        {
            get
            {
                return instance;
            }
        }
        public static string GetParamText(string param)
        {
            return LanguageItems[param];
        }
        public static Dictionary<string, string> DisplayContent()
        {
            foreach(var item in LanguageItems)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            return new Dictionary<string, string>(LanguageItems);
        }

    }
}
