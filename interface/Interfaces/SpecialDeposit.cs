using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period) {}

        public override decimal Income()
        {
            decimal income = 0;
            decimal currentAmount = Amount;
            for (int i = 1; i <= base.Period; i++)
            {
                decimal monthlyIncome = currentAmount * i * (decimal)0.01;
                income += monthlyIncome;
                currentAmount += monthlyIncome;
            }

            return income;
        }

        public override decimal GeneralSum()
        {
            return Amount + Income();
        }


        public bool CanToProlong()
        {
            return Amount > 1000;
        }
        
        
        
    }

}
