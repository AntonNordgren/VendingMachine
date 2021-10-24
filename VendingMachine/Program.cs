using System;
using VendingMachine.Data;
using VendingMachine.Model;

namespace VendingMachine
{
    public class Program
    {
        public static void Main()
        {
            VendingMachine vendingMachine = new VendingMachine();
            User theUser = new User();
            bool isRunning = true;
            GetUserData getUserData = new GetUserData();

            vendingMachine.InitializeUser(theUser);
            vendingMachine.FillVendingMachine();

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Vending Machine");
                Console.WriteLine("Inserted Money: " + vendingMachine.moneyPool.ToString());
                Console.WriteLine();
                theUser.DisplayUserInfo();
                vendingMachine.ShowAll();
                Console.WriteLine();
                Console.WriteLine("Choose Operation");
                Console.WriteLine("1. Insert Money");
                Console.WriteLine("2. Purchase");
                Console.WriteLine("3. Use Item");
                Console.WriteLine("4. Examine Item");
                Console.WriteLine("5. Exit");
                Console.Write("Enter: ");
                if (vendingMachine.ChooseOperation(getUserData.GetUserInput(Console.ReadLine())))
                {
                    isRunning = false;
                    Console.ReadKey();
                }
            }
        }
    }
}
