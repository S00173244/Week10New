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
        Variation variation;

        internal Variation Variation
        {
            get
            {
                return variation;
            }

            set
            {
                variation = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public double Tax
        {
            get
            {
                return tax;
            }

            set
            {
                tax = value;
            }
        }

        public Product(string i,string n, double p, Variation v)
        {
            id = i;
            name = n;
            price = p;
            Variation = v;
            
        }

        public override string ToString()
        {
            if(tax!=0) return id + "\t" + name + "\t" + "€"+price + "\t" + tax.ToString("00.00") + "\t" +variation.Type;
            else return id + "\t" + name + "\t" + "€" + price + "\t" + variation.Type;
        }

        public void AddTax(double taxRate)
        {
            tax = price * taxRate;
            
        }
    }
}
