using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    internal class ProductItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }

        public ProductItem(int id, string name, double price, int count)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.count = count;
        }
    }
}
    