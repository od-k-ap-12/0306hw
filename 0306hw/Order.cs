using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0306hw
{
    class Order
    {
        public LinkedList<Item> items;
        public string client { get; set; }
        public Order(string _name,double _price, string _client)
        {
            items = new LinkedList<Item>();
            items.AddLast(new Item(_name, _price));
            client = _client;
        }
        public void AddItem(string _name,double _price)
        {
            items.AddLast(new Item(_name, _price));
        }
    }
}
