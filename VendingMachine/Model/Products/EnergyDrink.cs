using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class EnergyDrink : Product
    {
        public EnergyDrink(double productId, string name, double price)
           : base(productId, name, price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override void Use()
        {
            Console.WriteLine("You drank up the energidrink.");
        }

        public override void Examine()
        {
            Console.WriteLine($"Energidrink with pear flavor, price {Price}");
        }
    }
}
