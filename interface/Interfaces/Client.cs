using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;

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
        
        public void SortDeposits()
        {
            int n = deposits.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (deposits[j] == null || deposits[j + 1] == null)
                        continue;
                    
                    if (deposits[j].GeneralSum() < deposits[j + 1].GeneralSum())
                    {
                        (deposits[j], deposits[j + 1]) = (deposits[j + 1], deposits[j]);
                    }
                }
            }
        }
        
        public int CountPossibleToProlongDeposit()
        {
            int count = 0;
            foreach (Deposit deposit in deposits)
            {
                if (deposit is IProlongable && ((IProlongable)deposit).CanToProlong())
                {
                    count++;
                }
            }

            return count;
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            foreach (Deposit deposit in deposits)
            {
                if (deposit != null)
                {
                    yield return deposit;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    

}
