using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Water : Product
    {
        public Water(double productId, string name, double price)
           : base(productId, name, price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override void Use()
        {
            Console.WriteLine("You drank up the carbonated water.");
        }

        public override void Examine()
        {
            Console.WriteLine($"Carbonated Water, price {Price}");
        }
    }
}
