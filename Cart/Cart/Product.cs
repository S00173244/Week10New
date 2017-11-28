using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart
{
    class Product
    {
        string id;
        string name;
        double price;
        double tax;

        public Product(string i,string n, double p)
        {
            id = i;
            name = n;
            price = p;
        }

        public override string ToString()
        {
            if(tax!=0) return id + "\t" + name + "\t" + "€"+price + "\t" + tax;
            else return id + "\t" + name + "\t" + "€" + price;
        }

        public void AddTax(double taxRate)
        {



            tax = price * taxRate;
            
        }
    }
}
