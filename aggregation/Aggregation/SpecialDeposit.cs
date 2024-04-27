namespace Aggregation
{
    
    public class SpecialDeposit : Deposit
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

        
    }
}