namespace Aggregation
{

    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal amount, int period) : base(amount, period) {}

        public override decimal Income()
        {
            decimal income = 0;
            decimal currentAmount = Amount;
            for (int i=0; i < base.Period; i++)
            {
                income += currentAmount * (decimal) 0.05;
                currentAmount += currentAmount * (decimal) 0.05;
            }

            return income;
        }
        
    }
}