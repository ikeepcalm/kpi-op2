namespace Interfaces
{
    public class LongDeposit : Deposit, IProlongable
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

        public override decimal GeneralSum()
        {
            return Amount + Income();
        }

        public bool CanToProlong()
        {
            return Period <= 36;
        }
    }
}
