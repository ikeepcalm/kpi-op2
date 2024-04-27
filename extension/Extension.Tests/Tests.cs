using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Extension.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(1274, 14)]
        [TestCase(-56789, 35)]
        [TestCase(0, 0)]
        [TestCase(02, 2)]
        [TestCase(333333, 18)]
        public void SummaDigitWithIntegerValueReturntSumOfDigits(int n, int expected)
        {           
                //Act 
                var actualResult = n.SummaDigit();

                //Assert 
                Assert.AreEqual(expected, actualResult, message: "SummaDigit method works incorrect ");
        }

        [TestCase((uint)132, (ulong)363)]
        [TestCase((uint)9, (ulong)18)]
        [TestCase((uint)0, (ulong)0)]
        [TestCase((uint)178411, (ulong)293282)]
        [TestCase((uint)55, (ulong)110)]
        public void SummaWithReverseWithUintValueReturnSum(uint n, ulong expected)
        { 
                //Act 
                var actualResult = n.SummaWithReverse();
                //Assert
                Assert.AreEqual(expected, actualResult, message: "SummaWithReverse works incorrect");
        }

        [TestCase("I like C#", 3)]
        [TestCase("Hello мир", 4)]
        [TestCase("", 0)]
        [TestCase("Проб5ел", 7)]
        [TestCase("Helloworld", 0)]
        [TestCase("quer51ty6i", 3)]
        [TestCase("@8/-1=", 6)]   

        public void CountNotLetterWithStringValueReturnAmountOfNonAlphabet(string str,int expected)
        {
                //Act
                var actualResult = str.CountNotLetter();
                //Assert
                Assert.AreEqual(expected, actualResult, message: "CountNotLetter works incorrect ");
        }

        [TestCase(DayOfWeek.Monday, false)]
        [TestCase(DayOfWeek.Tuesday, false)]
        [TestCase(DayOfWeek.Wednesday, false)]
        [TestCase(DayOfWeek.Thursday, false)]
        [TestCase(DayOfWeek.Friday, false)]
        [TestCase(DayOfWeek.Saturday, true)]
        [TestCase(DayOfWeek.Sunday, true)]
        public void IsDayOffWithDayOfWeekValueReturnCorrectValue(DayOfWeek day ,bool expected)
        {
           
                //Act
                var actualResult = day.IsDayOff();
                //Assert
                Assert.AreEqual(expected, actualResult, message: "IsDayOff works incorrect");

            
        }


        [Test,TestCaseSource("Collection")]
        public void EvenPositiveElementsWithCollectionParameterReturnEvenNumbers(IEnumerable<int> numbers, IEnumerable<int> expected)
        { 
                //Act
                var actualResult = numbers.EvenPositiveElements();
                //Assert
                CollectionAssert.AreEqual(expected, actualResult, message: "EvenPositiveElements works incorrect ");            
        }

        static readonly object[] Collection =
       {
            new object []{new int[] { 5, 1, 8, 24 }, new int[] { 8, 24 } },
            new object []{new List<int>() { 2,2,2,5,47,18}, new List<int>() { 2, 2, 2, 18 } },
            new object[]{ new List<int>() { 0, 0, 0, 5 }, new List<int>() },
            new object[]{ new int[] { 2, -2, 3, 4, 0, 6, 1, 9 }, new int[] { 2, 4, 6 } },
            new object[]{ new List<int> { 2, 3, -4, 8, 5, 4 }, new List<int>() { 2, 8, 4 } }

        };
    }
}
