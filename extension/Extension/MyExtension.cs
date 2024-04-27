using System;
using System.Collections.Generic;

namespace Extension
{
    public static class MyExtension
    {
        /// <summary>
        /// Mehod that return sum of  'n' digit
        /// </summary>        
        /// <param name="n">Element parameter</param>
        /// <returns>Integer value</returns>
        public static int SummaDigit(this int n)
        {
            int sum = 0;
            n = Math.Abs(n);
            
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            
            return sum;
        }
       
        /// <summary>
        /// Method that return sum of 'n' element and reverse of 'n'
        /// </summary>
        /// <param name="n">Element parameter</param>
        /// <returns>Ulong value</returns>
        public static ulong SummaWithReverse(this uint n)
        {
            uint reverseNumber = ReverseDigits(n);
            return n + reverseNumber;
        }
       
        /// <summary>
        /// Method that count amount of elements in string , which are not letters of the latin alphabet.
        /// </summary>
        /// <param name="str">String parameter</param>
        /// <returns>Integer value</returns>
        public static int CountNotLetter(this string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (IsNotLatinChar(c))
                {
                    count++;
                }
            }
            return count;
        }
        


      
        /// <summary>
        /// Method that checks whether day is weekend or not 
        /// </summary>
        /// <param name="day">DayOfWeek parameter</param>
        /// <returns>Bool value</returns>
        public static bool IsDayOff(this DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
            {
                return true;
            }

            return false;
        }

       
        /// <summary>
        /// Method that return positive ,even  element from collection 
        /// </summary>
        /// <param name="numbers">Collection of elements</param>
        /// <returns>IEnumerable -int collection  </returns>
        public static IEnumerable<int> EvenPositiveElements(this IEnumerable<int> numbers)
        {
            foreach (var VARIABLE in numbers)
            {
                if (VARIABLE > 0 && VARIABLE % 2 == 0)
                {
                    yield return VARIABLE;
                }
            }
        }
        
        private static uint ReverseDigits(uint number)
        {
            uint reverse = 0;
            while (number > 0)
            {
                uint digit = number % 10;
                reverse = reverse * 10 + digit;
                number /= 10;
            }
            return reverse;
        }
        
        public static bool IsNotLatinChar(char c)
        {
            return !(c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z') || c == ' ';
        }
    }
}
