using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _0306hw
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order("name", 5, "client"));
            XmlTextWriter xmlwriter = new XmlTextWriter("../../Orders.xml", Encoding.UTF8);
            xmlwriter.WriteStartDocument();
            xmlwriter.Formatting = Formatting.Indented; 
            xmlwriter.IndentChar = '\t'; 
            xmlwriter.Indentation = 1;
            xmlwriter.WriteStartElement("orders");
            xmlwriter.WriteComment("Orders");
            xmlwriter.WriteStartElement("order");
            foreach(Order order in orders)
            {
                foreach(Item item in order.items)
                {
                    xmlwriter.WriteStartAttribute("name", null);
                    xmlwriter.WriteString(item.name);
                    xmlwriter.WriteEndAttribute();
                    xmlwriter.WriteStartAttribute("price", null);
                    xmlwriter.WriteString(Convert.ToString(item.price));
                    xmlwriter.WriteEndAttribute();
                }
                xmlwriter.WriteStartAttribute("client", null);
                xmlwriter.WriteString(order.client);
            }
            xmlwriter.WriteEndElement();
            xmlwriter.WriteEndElement();
            Console.WriteLine("Данные сохранены в XML-файл");
            xmlwriter.Close();

            XmlTextReader reader = new XmlTextReader("../../Orders.xml");
            string str = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                    str += reader.Value + "\n";

                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            str += reader.Value + "\n";
                        }
                    }
                }
            }
            Console.WriteLine(str);
            reader.Close();
        }
    }
}
