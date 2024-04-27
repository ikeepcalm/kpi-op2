namespace Aggregation
{
    
    public abstract class Deposit
    {
        protected decimal Amount { get; }
        protected int Period { get; }

        protected Deposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }

        public abstract decimal Income();
    }
}