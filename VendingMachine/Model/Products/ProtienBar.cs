using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model.Products
{
    public class ProteinBar : Product
    {
        public ProteinBar(double productId, string name, double price)
           : base(productId, name, price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override void Use()
        {
            Console.WriteLine("Used Item");
        }

        public override void Examine()
        {
            Console.WriteLine($"Proteinbar with the flavor of caramel, {Price}");
        }
    }
}
