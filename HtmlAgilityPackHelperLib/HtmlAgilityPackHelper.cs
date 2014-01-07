using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HtmlAgilityPackHelperLib
{
    public static class HtmlAgilityPackHelper
    {
        public static HtmlDocument CreateHtmlDocument()
        {
            return new HtmlDocument();
        }

        public static string ParseString(this HtmlDocument doc)
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }

        public static List<HtmlNode> GetEntireNodes(this HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes("*");
            Stack<HtmlNode> execStack = new Stack<HtmlNode>();      
            List<HtmlNode> res = new List<HtmlNode>();
            foreach (var node in nodes)
            {
                execStack.Push(node);
                while (execStack.Count > 0)
                {
                    var node1 = execStack.Pop();
                    res.Add(node1);
                    var tempNodes = node1.ChildNodes;
                    if (tempNodes != null && tempNodes.Count > 0)
                    {
                        foreach (var tempNode in tempNodes)
                        {
                            execStack.Push(tempNode);
                        }
                    }
                }
            }
            
           
            return res;
        }
    }


}
