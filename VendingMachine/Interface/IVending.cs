using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    interface IVending
    {
        void Purchase(double input);
        void ShowAll();
        double InsertMoney(double input);
        void EndTransaction();
    }
}
