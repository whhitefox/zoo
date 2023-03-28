using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    internal class ComboItem
    {
        public int id;
        public string value;

        public ComboItem(int id, string value)
        {
            this.id = id;
            this.value = value;
        }

        override public string ToString()
        {
            return value;
        }
    }
}
