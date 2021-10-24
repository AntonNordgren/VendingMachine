using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class Chocolate : Product
    {
        public Chocolate(double productId, string name, double price)
           : base(productId, name, price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override void Use()
        {
            Console.WriteLine("You ate up the chocolatebar.");
        }

        public override void Examine()
        {
            Console.WriteLine($"Simple chocolatebar, price {Price}");
        }
    }
}
