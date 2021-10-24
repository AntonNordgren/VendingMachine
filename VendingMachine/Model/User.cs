using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Model
{
    public class User
    {
        public List<Product> inventory = new List<Product>();

        public void DisplayUserInfo()
        {
            Console.WriteLine("Inventory: ");
            foreach (Product product in inventory)
            {
                Console.WriteLine($"{product.ProductId}. {product.Name}");
            }
        }

        public void UseItem(double input)
        {
            Product foundProduct = inventory.Find(product => product.ProductId == input);
            if (foundProduct != null)
            {
                foundProduct.Use();
                inventory.Remove(foundProduct);
            }
            else
            {
                Console.WriteLine("No Item found");
            }
        }
    }
}
