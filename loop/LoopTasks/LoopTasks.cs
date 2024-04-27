namespace LoopTasks
{
    public static class LoopTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
            public static int SumOfOddDigits(int n)
            {
                int result = 0;
                string numberString = n.ToString();

                foreach (char c in numberString)
                {
                    int digit = c - '0';
                    if (digit % 2 != 0)
                    {
                        result += digit;
                    }
                }

                return result;
            }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int NumberOfUnitsInBinaryRecord(int n)
        {
            int result = 0;
            while (n > 0)
            {
                result += n & 1;
                n >>= 1;
            }
            return result;
        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static int SumOfFirstNFibonacciNumbers(int n)
        {
            int result = 0;
            int n1 = 0;
            int n2 = 1;

            for (int i = 0; i < n; i++)
            {
                result += n1;
                int temp = n1;
                n1 = n2;
                n2 = temp + n2;
            } return result;
        }
    }
}