using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_5_and_3_results_8()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(5, 3);

            //Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Sum_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MinValue, -1));

        }

        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(4, 5, 9)]
        [DataRow(-5, -3, -8)]
        [DataRow(-3, 5, 2)]
        public void Sum_test(int a, int b, int expected)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsWeekend()
        {
            var calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 7, 12);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 7, 13);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 7, 14);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 7, 15);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 7, 16);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 7, 17);
                Assert.IsTrue(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 7, 18);
                Assert.IsTrue(calc.IsWeekend());
            }
        }

    }
}
