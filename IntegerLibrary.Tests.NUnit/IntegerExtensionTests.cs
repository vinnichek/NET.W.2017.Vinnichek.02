using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegerLibrary.IntegerExtension;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace IntegerLibrary.Tests
{
    [TestClass]
    public class IntegerExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextBiggerNumber_For_Negative_Number_Throw_ArgumentNullException()
        {
            long number = -20;
            long actual = NextBiggerNumber(number);
        }

        [TestMethod]
        public void NextBiggerNumber_For__NotDecreased_Number_123()
        {
            long number = 123;
            long actual = NextBiggerNumber(number);
            long expected = 132;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void NextBiggerNumber_For_Decreased_Number_100()
        {
            long number = 100;
            long actual = NextBiggerNumber(number);
            long expected = -1;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FindNthRoot_For_Correct_Numbers()
        {
            double actual = FindNthRoot(1, 5, 0.0001);
            double expected = 1;
            Assert.AreEqual(actual, expected, 0.00001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_For_Negative_Accuracy_Throw_ArgumentOutOfRangeException()
        {
            double actual = FindNthRoot(1, 5, -0.0001);
        }

        [TestMethod]
        public void InsertNumber_For_Correct_Input_Values()
        {
            int expected = 9;
            int actual = InsertNumber(8, 15, 0, 0);
            Assert.AreEqual(expected, actual);
        }
    }   
}
