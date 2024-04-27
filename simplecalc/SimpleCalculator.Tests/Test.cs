using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class Test
    {
        [TestCase(0,0,0)]
        [TestCase(1, 11, 12)]
        [TestCase(-7, -4, -11)]        
        public void AddWithParametersShouldReturnCorrectSum(int a, int b, int expectedSum)
        {
            int actualSum = SimpleCalculator.Add(a, b);
            Assert.AreEqual(expectedSum, actualSum, message: "Add method works incorrectly");
        }

        [TestCase(0, 0, 0)]
        [TestCase(5, 3, 2)]
        [TestCase(-16, -7, -9)]
        public void SubWithParametersShouldReturnCorrectSubstraction(int a, int b, int expectedSub)
        {
            int actualSub = SimpleCalculator.Sub(a, b);
            Assert.AreEqual(expectedSub, actualSub, message: "Sun method works incorrectly");
        }
    }
}
