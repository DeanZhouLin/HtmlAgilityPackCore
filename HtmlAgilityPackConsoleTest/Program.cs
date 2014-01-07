using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPackHelperLib;

namespace HtmlAgilityPackConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var htmlDocument = HtmlAgilityPackHelper.CreateHtmlDocument();
            var html = "<a src=\"http://www.1juhao.com/descpics/images/1102880001/1.jpg\"></a><iframe src=\"http://www.1juhao.com/descpics/images/1102940001/2.jpg\"><p rowspan=\"3\" colspan=\"2\" >Your browser does not support iframes.</p></iframe>";
            htmlDocument.LoadHtml(html);

            var res = htmlDocument.GetEntireNodes();

            res.Where(c=>c.na)
            var nodes = htmlDocument.DocumentNode.SelectNodes("*");
            foreach (var node in nodes)
            {
                foreach (var attr in node.Attributes)
                {
                    
                    Console.WriteLine(node.Name + "|" + attr.Name + "|" + attr.Value);
                }

                node.Attributes.Add(node.Attributes[0].Name + "1", node.Attributes[0].Value);

            }

            Console.WriteLine(nodes.Count);
            Console.WriteLine(htmlDocument.ParseString());
            Console.ReadLine();
        }
    }
}
