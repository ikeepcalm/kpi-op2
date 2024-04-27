using System;
using System.Linq;

namespace ArrayObject
{
    public static class ArrayTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
        public static void ChangeElementsInArray(int[] nums)
        {
            int length = nums.Length - 1;
            for (int i = 0; i < nums.Length / 2; i++)
            {
                int start = nums[i];
                int end = nums[length - i];

                if (start % 2 == 0 && end % 2 == 0)
                {
                    nums[length - i] = start;
                    nums[i] = end;
                }
            }
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int DistanceBetweenFirstAndLastOccurrenceOfMaxValue(int[] nums)
        {
            if (nums.Length != 0)
            {
                int maxValue = nums.Max();
                int firstIndex = Array.IndexOf(nums, maxValue);
                int secondIndex = Array.LastIndexOf(nums, maxValue);

                return secondIndex - firstIndex;
            } return 0;
        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static void ChangeMatrixDiagonally(int[,] matrix)
        {
            int dimensionality = matrix.GetLength(0);
            
            for (int i = 0; i < dimensionality; i++) {
                
                for (int j = 0; j < dimensionality; j++) {
                    if (j < i) {
                        matrix[i, j] = 0;
                    }
                    else if (j > i) {
                        matrix[i, j] = 1;
                    }
                }
                
            }
        }
    }
}