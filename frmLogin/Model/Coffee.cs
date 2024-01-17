using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProjectOOP.Model
{
    public class Coffee
    {
        private string name;

        private double price;

        public Coffee(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public string ToString()
        {
            return Name;
        }
    }
}
