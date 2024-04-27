namespace Aggregation
{
    public class Client
    {
        private Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }

            return false;
        }

        public decimal TotalIncome()
        {
            decimal totalIncome = 0;
            foreach (Deposit deposit in deposits)
            {
                if (deposit != null)
                {
                    totalIncome += deposit.Income();
                }
            }

            return totalIncome;
        }

        public decimal MaxIncome()
        {
            decimal maxIncome = 0;
            foreach (Deposit deposit in deposits)
            {
                if (deposit != null && deposit.Income() > maxIncome)
                {
                    maxIncome = deposit.Income();
                }
            }

            return maxIncome;
        }

        public decimal GetIncomeByNumber(int number)
        {
            if (deposits[number - 1] != null)
            {
                return deposits[number - 1].Income();
            }

            return 0;
        }
    }
}