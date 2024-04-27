namespace Aggregation
{
    
    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal amount, int period) : base(amount, period) {}

        public override decimal Income()
        {
            {
                decimal income = 0;
                decimal currentAmount = Amount;
                for (int i=0; i < base.Period-6; i++)
                {
                    income += currentAmount * (decimal) 0.15;
                    currentAmount += currentAmount * (decimal) 0.15;
                }

                return income;
                
            }
        }
    }
    
}