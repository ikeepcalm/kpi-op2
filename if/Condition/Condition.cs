using System;
using System.Linq;

namespace Condition
{
    public static class Condition
    {
        /// <summary>
        /// Implement code according to description of  task 1
        /// </summary>        
        public static int Task1(int n)
        {
            return n switch
            {
                > 0 => (int)Math.Pow(n, 2),
                < 0 => Math.Abs(n),
                _ => 0
            };
        }

        /// <summary>
        /// Implement code according to description of  task 2
        /// </summary>  
        public static int Task2(int n)
        {
            return Convert.ToInt32(String.Join("", n.ToString().ToCharArray().OrderByDescending(x => x)));
        }
    }
}
