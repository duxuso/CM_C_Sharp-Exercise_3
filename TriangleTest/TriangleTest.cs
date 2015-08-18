using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle;

namespace TriangleTest
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Area_SampleResult()
        {
            // arrange
            double expected, actual;
            
            int s_three = 3;
            int s_four = 4;
            int s_five = 5;

            expected = 6.0;

            TriangleArea ta = new TriangleArea();

            // act
            actual = ta.Area(s_three, s_four, s_five);

            // assert
            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void InputIsLessThanZero_ShouldThrowInvalidTriangleException()
        {
            // arrange

            int s_three = -3;
            int s_four = 4;
            int s_five = 5;

            TriangleArea ta = new TriangleArea();

            // act
            try
            {
                ta.Area(s_three,s_four,s_five);
            }
            catch (InvalidTriangleException e)
            {
                // assert
                StringAssert.Contains(e.Message, TriangleArea.InputIsLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void InputsAreNotValid_ShouldThrowInvalidTriangleException()
        {
            // arrange

            int s_three = 1;
            int s_four = 2;
            int s_five = 3;

            TriangleArea ta = new TriangleArea();

            // act
            try
            {
                ta.Area(s_three, s_four, s_five);
            }
            catch (InvalidTriangleException e)
            {
                // assert
                StringAssert.Contains(e.Message, TriangleArea.InputsAreNotValidMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
