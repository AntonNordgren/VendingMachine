using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Data;
using Xunit;

namespace VendingMachine.Tests
{
    public class GetDataShould
    {
        [Fact]
        public void GetDataCorrectly()
        {
            GetUserData getUserData = new GetUserData();
            double result = getUserData.GetUserInput("1");

            Assert.Equal(1, result);

            result = getUserData.GetUserInput("a");

            Assert.Equal(double.NaN, result);
        }
    }
}
