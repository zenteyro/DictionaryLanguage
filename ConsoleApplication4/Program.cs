using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Language = "en";
            Console.WriteLine(Menu.GetParamText("menuOpenWinIndex"));

            Dictionary<string, string> myDic = Menu.DisplayContent();
            
        }
    }
}
