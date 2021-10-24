using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Data;
using VendingMachine.Model;
using VendingMachine.Model.Products;

namespace VendingMachine
{
    public class VendingMachine : IVending
    {
        public List<Product> productsAvailable = new List<Product>();
        public readonly int[] denominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public double moneyPool = 0;
        readonly GetUserData getUserData = new GetUserData();
        User currentUser;

        public void InitializeUser(User currentUser)
        {
            this.currentUser = currentUser;
        }

        public void FillVendingMachine()
        {
            productsAvailable.Add(new Chips(1, "Chips", 19));
            productsAvailable.Add(new Chocolate(2, "Chocolatebar", 15));
            productsAvailable.Add(new EnergyDrink(3, "Energydrink", 20));
            productsAvailable.Add(new ProteinBar(4, "Proteinbar", 25));
            productsAvailable.Add(new Water(5, "Water", 9));
            productsAvailable.Add(new Soda(6, "Soda", 15));
        }

        public void Purchase(double input)
        {

            if (ProductExist(input))
            {
                Product productFound = productsAvailable.Find(product => product.ProductId == input);
                if (moneyPool - productFound.Price < 0)
                {
                    Console.WriteLine("You haven't added enough money for that.");
                    Console.ReadKey();
                }
                else
                {
                    moneyPool -= productFound.Price;
                    currentUser.inventory.Add(productFound);
                }
            }
        }

        public bool ProductExist(double productId)
        {
            if(productId == double.NaN)
            {
                return false;
            }

            foreach(Product product in productsAvailable)
            {
                if(product.ProductId == productId)
                {
                    return true;
                }
            }

            return false;
        }

        public void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("Available Products");
            Console.WriteLine();
            foreach (Product product in productsAvailable)
            {
                Console.WriteLine($"{product.ProductId}. {product.Name} Price: {product.Price}kr");
            }
        }

        public double InsertMoney(double input)
        {
            var result = input switch
            {
                1 => denominations[0],
                2 => denominations[1],
                3 => denominations[2],
                4 => denominations[3],
                5 => denominations[4],
                6 => denominations[5],
                7 => denominations[6],
                8 => denominations[7],
                _ => 0,
            };
            return result;
        }

        public void EndTransaction()
        {
            Console.WriteLine($"You got {moneyPool}kr back");
            moneyPool = 0;
        }

        public void ExamineItem(double input)
        {
            Product foundProduct = productsAvailable.Find(product => product.ProductId == input);
            if (foundProduct != null)
            {
                foundProduct.Examine();
            }
            else
            {
                Console.WriteLine("No Item found");
            }

            Console.ReadKey();
        }


        public bool ChooseOperation(double input)
        {
            bool exit = false;

            switch (input)
            {
                case 1:
                    Console.Clear();
                    currentUser.DisplayUserInfo();
                    Console.WriteLine("How much money do you want to insert?");
                    Console.WriteLine();
                    Console.WriteLine("1. 1kr");
                    Console.WriteLine("2. 5kr");
                    Console.WriteLine("3. 10kr");
                    Console.WriteLine("4. 20kr");
                    Console.WriteLine("5. 50kr");
                    Console.WriteLine("6. 100kr");
                    Console.WriteLine("7. 500kr");
                    Console.WriteLine("8. 1000kr");
                    Console.WriteLine();
                    Console.Write("Enter here: ");
                    moneyPool += InsertMoney(getUserData.GetUserInput(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("What do you want to buy?");
                    Console.Write("Enter number: ");
                    Purchase(getUserData.GetUserInput(Console.ReadLine()));
                    break;
                case 3:
                    if (currentUser.inventory.Count != 0)
                    {
                        Console.Write("Enter: ");
                        currentUser.UseItem(getUserData.GetUserInput(Console.ReadLine()));
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("You have no Items. ");
                        Console.ReadKey();
                    }
                    break;
                case 4:
                    Console.Write("Enter: ");
                    ExamineItem(getUserData.GetUserInput(Console.ReadLine()));
                    break;
                case 5:
                    EndTransaction();
                    exit = true;
                    break;
                default:
                    break;
            }

            return exit;
        }
    }
}
