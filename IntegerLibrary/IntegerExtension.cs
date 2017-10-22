using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IntegerLibrary
{
    public static class IntegerExtension
    {
        private static int maxValueInt = 0x7fffffff;
        private static int quantityOfBits = 31;

        public static int InsertNumber(int first, int second, int startPosition, int finishPosition)
        {
            CheckPosition(startPosition, finishPosition);

            int maskSecondNumber = maxValueInt >> quantityOfBits - (finishPosition - startPosition + 1);
            maskSecondNumber &= second;
            maskSecondNumber <<= startPosition;

            int maskLeft = maxValueInt << (finishPosition + 1);
            maskLeft &= first;

            int maskRight = maxValueInt >> quantityOfBits - startPosition;
            maskRight &= first;

            return maskLeft ^ maskSecondNumber ^ maskRight;
        }

        private static void CheckPosition(int startPosition, int finishPosition)
        {
            if (startPosition < 0 || startPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect input start positions.");
            }
            if (finishPosition < 0 || finishPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Incorrect input finish positions.");
            }
            if (finishPosition < startPosition)
            {
                throw new ArgumentException("Incorrect input positions.");
            }
        }

        public static long NextBiggerNumber(long number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (IsNumberDecrease(number))
            {
                return -1;
            }

            string sNumber = ToSortedString(number);
            long nextNumber = ++number;
            string sNext = ToSortedString(nextNumber);

            while (sNumber != sNext)
            {
                sNext = ToSortedString(++nextNumber);
            }
            return nextNumber;
        }

        public static Tuple<long, double> NextBiggerNumberWithTimeUsingTuple(long number)
        {
            Stopwatch myStopWatch = new Stopwatch();
            myStopWatch.Start();
            NextBiggerNumber(number);
            myStopWatch.Stop();
            double ms = (myStopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency;
            return Tuple.Create(NextBiggerNumber(number), ms);
        }

        private static bool IsNumberDecrease(long number)
        {
            int prevDigit = (int)number % 10;
            int nextDigit = 0;
            number = number / 10;

            while (number != 0)
            {
                nextDigit = (int)number % 10;
                if (prevDigit > nextDigit)
                {
                    return false;
                }
                number = number / 10;
                prevDigit = nextDigit;

            }
            return true;
        }

        private static string ToSortedString(long number)
        {
            char[] array = number.ToString().ToCharArray();
            Array.Sort(array);
            return new String(array);
        }

        public static List<int> FilterDigit(int[] array)
        {
            CheckArrayForFilter(array);
            List<int> filterDigitArray = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                int elementOfArray = array[i];
                while (elementOfArray != 0)
                {
                    int digitOfElement = elementOfArray % 10;
                    elementOfArray = elementOfArray / 10;
                    if (digitOfElement == 7)
                    {
                        filterDigitArray.Add(array[i]);
                        elementOfArray = 0;
                    }
                }
            }
            return filterDigitArray;
        }

        private static void CheckArrayForFilter(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }
        }

        public static double FindNthRoot(double number, double n, double accuracy)
        {
            if ((accuracy < 0) || (n < 0))
            {
                throw new ArgumentOutOfRangeException("Incorrect input accuracy.");
            }

            double x0 = number / n; 
            double x1 = (1 / n) * ((n - 1) * x0 + (number / Math.Pow(x0, n - 1)));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + (number / Math.Pow(x0, n - 1)));
            }
            return x1;
        }
    }
}
