using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model.Products
{
    public class Chips : Product
    {

        public Chips(double productId, string name, double price)
            : base(productId, name, price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override void Use()
        {
            Console.WriteLine("You ate up all the chips");
        }

        public override void Examine()
        {
            Console.WriteLine($"Chips with flavor of sourcream and onion, price {Price}");
        }
    }
}
