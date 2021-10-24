using System;
using VendingMachine.Model;
using Xunit;

namespace VendingMachine.Tests
{
    public class UserShould
    {
        VendingMachine sutVendingMachine = new VendingMachine();
        Model.User sutUser = new Model.User();

        [Fact]
        public void UseItemCorrectly()
        {
            sutVendingMachine.InitializeUser(sutUser);
            sutVendingMachine.FillVendingMachine();

            sutUser.inventory.Add(new EnergyDrink(1, "Energydrink", 20));
            sutUser.inventory.Add(new EnergyDrink(2, "Energydrink", 20));
            sutUser.inventory.Add(new EnergyDrink(3, "Energydrink", 20));

            Assert.Equal(3, sutUser.inventory.Count);

            sutUser.UseItem(3);

            Assert.Equal(2, sutUser.inventory.Count);

            sutUser.UseItem(1);

            Assert.Single(sutUser.inventory);

            sutUser.UseItem(2);

            Assert.Empty(sutUser.inventory);

        }
    }
}
