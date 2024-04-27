using System;

namespace Interfaces
{
    
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }
        public int Period { get; }

        protected Deposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }

        public abstract decimal Income();
        public abstract decimal GeneralSum();

        public int CompareTo(Deposit other)
        {
            if (GeneralSum() > other.GeneralSum())
            {
                return 1;
            }
            else if (GeneralSum() < other.GeneralSum())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
        public static bool operator ==(Deposit left, Deposit right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            } 
            
            if (ReferenceEquals(right, null))
            {
                return false;
            }
            
            return left.GeneralSum() == right.GeneralSum();
        }
        
        public static bool operator !=(Deposit left, Deposit right)
        {
            if (ReferenceEquals(left, null))
            {
                return !ReferenceEquals(right, null);
            }
            
            if (ReferenceEquals(right, null))
            {
                return true;
            }
            
            return left.GeneralSum() != right.GeneralSum();
        }
        
        public static bool operator >(Deposit left, Deposit right)
        {
            if (left.GeneralSum() > right.GeneralSum())
            {
                return true;
            } return false;
        }
        
        public static bool operator <(Deposit left, Deposit right)
        {
            if (left.GeneralSum() < right.GeneralSum())
            {
                return true;
            } return false;
        }
        public static bool operator >=(Deposit left, Deposit right)
        {
            if (left.GeneralSum() >= right.GeneralSum())
            {
                return true;
            } return false;
        }
        
        public static bool operator <=(Deposit left, Deposit right)
        {
            if (left.GeneralSum() <= right.GeneralSum())
            {
                return true;
            } return false;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            
            Deposit deposit = (Deposit) obj;
            return this.GeneralSum() == deposit.GeneralSum();
        }

        public override int GetHashCode()
        {
            return GeneralSum().GetHashCode();
        }
    }

}
