using System;

namespace Functions
{
    public enum SortOrder { Ascending, Descending }
    public static class DemoFunction
    {
        public static bool IsSorted(int[] array, SortOrder order)
        {
            if (array == null || array.Length <= 1){
                return true;
            }
    
            int lastElement = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (order == SortOrder.Ascending)
                {
                    if (array[i] < lastElement)
                    {
                        return false;
                    }
                }
                else if (order == SortOrder.Descending)
                {
                    if (array[i] > lastElement)
                    {
                        return false;
                    }
                } lastElement = array[i];
            } return true;
        }

        public static void Transform(int[] array, SortOrder order)
        {
            if (IsSorted(array, order))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] += i;
                }
            }
        }

        public static double MultArithmeticElements(double a, double t, double n)
        {
            double an = a;
            double result = 1.0;

            for (double i = 0; i < n; i++)
            {
                result *= an;
                an += t;
            } return result;
        }

        public static double SumGeometricElements(double a, double t, double alim)
        {
            double sum = 0;
            double an = a;

            while (an > alim)
            {
                sum += an;
                an *= t;
            }

            return sum;
        }
        
    }
}
