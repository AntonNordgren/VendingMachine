using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Model;
using VendingMachine.Model.Products;
using Xunit;

namespace VendingMachine.Tests
{
    public class VendingMachineShould
    {
        VendingMachine sut = new VendingMachine();
        User sutUser = new User();

        [Fact]
        public void FillCorrectly()
        {
            sut.productsAvailable.Clear();
            sut.FillVendingMachine();
            sut.InitializeUser(sutUser);
            Chips chips = new Chips(1, "Chips", 19);
            Chocolate chocolate = new Chocolate(2, "Chocolatebar", 15);
            EnergyDrink energydrink = new EnergyDrink(3, "Energydrink", 20);
            ProteinBar protienbar = new ProteinBar(4, "Proteinbar", 25);
            Water water = new Water(5, "Water", 9);
            Soda soda = new Soda(6, "Soda", 15);

            Assert.Equal(chips.ProductId, sut.productsAvailable[0].ProductId);
            Assert.Equal(chips.Name, sut.productsAvailable[0].Name);
            Assert.Equal(chips.Price, sut.productsAvailable[0].Price);

            Assert.Equal(chocolate.ProductId, sut.productsAvailable[1].ProductId);
            Assert.Equal(chocolate.Name, sut.productsAvailable[1].Name);
            Assert.Equal(chocolate.Price, sut.productsAvailable[1].Price);

            Assert.Equal(energydrink.ProductId, sut.productsAvailable[2].ProductId);
            Assert.Equal(energydrink.Name, sut.productsAvailable[2].Name);
            Assert.Equal(energydrink.Price, sut.productsAvailable[2].Price);

            Assert.Equal(protienbar.ProductId, sut.productsAvailable[3].ProductId);
            Assert.Equal(protienbar.Name, sut.productsAvailable[3].Name);
            Assert.Equal(protienbar.Price, sut.productsAvailable[3].Price);

            Assert.Equal(water.ProductId, sut.productsAvailable[4].ProductId);
            Assert.Equal(water.Name, sut.productsAvailable[4].Name);
            Assert.Equal(water.Price, sut.productsAvailable[4].Price);

            Assert.Equal(soda.ProductId, sut.productsAvailable[5].ProductId);
            Assert.Equal(soda.Name, sut.productsAvailable[5].Name);
            Assert.Equal(soda.Price, sut.productsAvailable[5].Price);

        }

        [Fact]
        public void PurchaseCorrectly()
        {
            sut.productsAvailable.Clear();
            sut.FillVendingMachine();
            sut.InitializeUser(sutUser);

            sut.moneyPool = 100;

            sut.Purchase(1);
            Assert.Equal(81, sut.moneyPool);

            sut.Purchase(3);
            Assert.Equal(61, sut.moneyPool);

        }

        [Fact]
        public void ProductExist()
        {
            sut.productsAvailable.Clear();
            sut.FillVendingMachine();

            Assert.False(sut.ProductExist(1999));
            Assert.True(sut.ProductExist(1));
        }

        [Fact]
        public void InsertMoney()
        {
            Assert.Equal(5, sut.InsertMoney(2));
            Assert.Equal(1, sut.InsertMoney(1));
            Assert.Equal(100, sut.InsertMoney(6));
            Assert.Equal(0, sut.InsertMoney(123));
        }

        [Fact]
        public void ChoooseOperationExit()
        {
           Assert.True(sut.ChooseOperation(5));
        }
    }
}
