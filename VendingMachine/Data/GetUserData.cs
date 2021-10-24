using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Data
{
    public class GetUserData
    {
        public double GetUserInput(string input)
        {
            double result;

            try
            {
                result = double.Parse(input);
            }
            catch
            {
                result = double.NaN;
            }

            return result;
        }
    }
}
