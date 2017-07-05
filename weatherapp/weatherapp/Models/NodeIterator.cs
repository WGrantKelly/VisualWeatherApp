using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSharpPractice
{
    class NodeIterator
    {
        XmlDocument doc;
        public NodeIterator(XmlDocument doc)
        {
            this.doc = doc;
        }
        public static XmlNode dive(XmlNode currentNode)
        {
            if (currentNode.HasChildNodes)
            {
                return currentNode.FirstChild;
            }
            else return null;
        }
        public static XmlNode slide(XmlNode currentNode)
        {
            if (currentNode.NextSibling != null)
            {
                return currentNode.NextSibling;
            }
            else return null;
        }
    }
}
