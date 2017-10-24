using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ArrayLibrary.ArrayExtension;
using System.Collections.Generic;

namespace ArrayLibrary.Tests
{
    [TestClass]
    public class ArrayExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_For_Null_Array_Throw_ArgumentNullException()
        {
            int[] array = null;
            FilterDigit(7, array);
        }

        [TestMethod]
        public void FilterDigit_For_Array_With_Digits7()
        {
            int[] array = { 1, 2, 7, 17, 45, 7777, 325, 671 };
            int[] expected = { 7, 17, 7777, 671 };
            CollectionAssert.AreEqual(expected, FilterDigit(7, array));
        }

        [TestMethod]
        public void FilterDigit_For_Array_Without_Digits7()
        {
            int[] array = { 1, 2, 45, 325 };
            int[] expected = { };
            CollectionAssert.AreEqual(expected, FilterDigit(7, array));
        }
    }
}
