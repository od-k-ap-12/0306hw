using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0306hw
{
    class Item
    {
        public string name { get; set; }
        public double price { get; set; }
        public Item(string _name,double _price)
        {
            name = _name;
            price = _price;
        }
    }
}
