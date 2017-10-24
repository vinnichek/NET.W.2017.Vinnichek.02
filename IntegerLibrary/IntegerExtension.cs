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

        public static double FindNthRoot(double number, double n, double accuracy)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect input N.");
            }

            if ((accuracy < 0) || (accuracy > 1))
            {
                throw new ArgumentOutOfRangeException("Incorrect input accuracy.");
            }

            double previous = number / n; 
            double next = (1 / n) * ((n - 1) * previous + (number / Math.Pow(previous, n - 1)));

            while (Math.Abs(next - previous) > accuracy)
            {
                previous = next;
                next = (1 / n) * ((n - 1) * previous + (number / Math.Pow(previous, n - 1)));
            }
            return next;
        }
    }
}
