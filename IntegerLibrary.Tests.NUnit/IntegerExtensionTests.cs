using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using IntegerLibrary;
using static IntegerLibrary.IntegerExtension;

namespace IntegerLibrary.Tests.NUnit
{
    [TestFixture]
    public class IntegerExtensionTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15 )]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]

        public long InsertNumber(int first, int second, int startPosition, int finishPosition)
        {
            return InsertNumber(first, second, startPosition, finishPosition);
        }

        [TestCase(8, 15, 5, -1)]
        [TestCase(8, 15, 32, 5)]
        public void Insertion_For_Values_Greater31_Or_Less0_ThrowsArgumentOutOfRangeException(int first, int second, int startPosition, int finishPosition)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumber(first, second, startPosition, finishPosition));
        }
        
        [TestCase(3, 7, 7, 5)]
        [TestCase(7, 2, 1, 0)]
        public void Insertion_For_endPosition_Greater_Then_startPosition_ThrowsArgumentException(int first, int second, int startPosition, int finishPosition)
        {
            Assert.Throws<ArgumentException>(() => InsertNumber(first, second, startPosition, finishPosition));
        }


        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]

        public long NextBiggerNumber(long number)
        {
            return NextBiggerNumber(number);
        }

        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]

        public double NewtonMethod_CorrectInputValues_PositiveTest(double number, double n, double accuracy, double ExpectedResult)
        {
            return  FindNthRoot(number, n, accuracy);
        }
    }
}
