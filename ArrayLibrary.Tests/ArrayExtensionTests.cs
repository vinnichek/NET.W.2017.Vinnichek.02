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
            FilterDigit(array);
        }

        [TestMethod]
        public void FilterDigit_For_Array_With_Digits7()
        {
            int[] array = { 1, 2, 7, 17, 45, 7777, 325, 671 };
            List<int> expected = new List<int> { 7, 17, 7777, 671 };
            CollectionAssert.AreEqual(expected, FilterDigit(array));
        }

        [TestMethod]
        public void FilterDigit_For_Array_Without_Digits7()
        {
            int[] array = { 1, 2, 45, 325 };
            List<int> expected = new List<int> { };
            CollectionAssert.AreEqual(expected, FilterDigit(array));
        }
    }
}
