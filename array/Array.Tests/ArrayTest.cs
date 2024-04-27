using NUnit.Framework;
using ArrayObject;
using System.Collections.Generic;

namespace Array.Tests
{
    [TestFixture]
    public class ArrayTasksTest
    {
        [TestCase(new int[] { 10, 5, -35, 0 }, new int[] { 0, 5, -35, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 4, 3, 2, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 1, 5 }, new int[] { 1, 2, 3, 4, 1, 5 })]
        [TestCase(new int[] { 2, 4, -6, 8, 10, -12 }, new int[] { -12, 10, 8, -6, 4, 2 })]
        [TestCase(new int[] { 1, 3, 5, 7 }, new int[] { 1, 3, 5, 7 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ChangeElementsInArrayArraySwapedArray(int[] nums, int[] expectedResult)
        {
             ArrayTasks.ChangeElementsInArray(nums);
             Assert.AreEqual(expectedResult, nums, 
                 "ChangeElementsInArray worked incorrectly. Check your solution and change it.");
         }

        [TestCase(new int[] { 4, 100, 3, 4 }, 0)]
        [TestCase(new int[] { -5, 50, 50, 4, -5 }, 1)]
        [TestCase(new int[] { 100, 350, 350, 100, 350 }, 3)]
        [TestCase(new int[] { 10, 10, 10, 10, 10 }, 4)]
        [TestCase(new int[] { -70, -50, -30, -10, -5 }, 0)]
        [TestCase(new int[] { 13 }, 0)]
        [TestCase(new int[] { }, 0)]

        public void DistanceBetweenFirstAndLastOccurrenceOfMaxValueArrayResult(int[] nums, int expectedResult)
        {
            int actualResult = ArrayTasks.DistanceBetweenFirstAndLastOccurrenceOfMaxValue(nums);
            Assert.AreEqual(expectedResult, actualResult, 
                "DistanceBetweenFirstAndLastOccurrenceOfMaxValue worked incorrectly. Check your solution and change it.");

        }

        [TestCaseSource(nameof(GetMatrixForTesting))]

        public void ChangeMatrixDiagonallyTwoDimensionalArrayTwoDimensionalArrayWith0And1(int[,] matrix, int[,] expectedResult)
        {
            ArrayTasks.ChangeMatrixDiagonally(matrix);
            Assert.AreEqual(expectedResult, matrix,  
                "ChangeMatrixDiagonally worked incorrectly. Check your solution and change it.");
        }
 
        private static IEnumerable<object[]> GetMatrixForTesting()
        {
            yield return new object[] 
            {
                new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 1, 1, 1 } },
                new int[,] { { 1, 1, 1 }, { 0, 1, 1 }, { 0, 0, 1 } } 
            };
            yield return new object[] 
            {
                new int[,] { { 2, 4, 3, 3 }, { 5, 7, 8, 5 }, { 2, 4, 3, 3 }, { 5, 7, 8, 5 } },
                new int[,] { { 2, 1, 1, 1 }, { 0, 7, 1, 1 }, { 0, 0, 3, 1 }, { 0, 0, 0, 5 } }
            };
            yield return new object[] 
            {
                new int[,] { { 10, -5 }, { -5, -15 } }, 
                new int[,] { { 10, 1 }, { 0, -15 } }
            };
        }
    }
}
