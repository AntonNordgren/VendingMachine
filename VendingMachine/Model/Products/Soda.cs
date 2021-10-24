using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Soda : Product
    {
        public Soda(double productId, string name, double price)
           : base(productId, name, price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override void Use()
        {
            Console.WriteLine("You drank upp all the soda.");
        }

        public override void Examine()
        {
            Console.WriteLine($"Sodacan with cola flavor, price {Price}");
        }
    }
}
