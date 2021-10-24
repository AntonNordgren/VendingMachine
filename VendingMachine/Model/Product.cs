using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public abstract class Product
    {
        private double productId;
        public double ProductId
        {
            get { return productId; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Product Id can not be less than 1");
                }

                productId = value;
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be empty or null.");
                }

                name = value;
            }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Price can not be less than 1.");
                }

                price = value;
            }

        }
        

        public Product(double productId, string name, double price)
        {
        }

        public virtual void Use()
        {
            Console.WriteLine("Used Item");
        }

        public virtual void Examine()
        {
            Console.WriteLine("Examined Item");
        }
    }
}
