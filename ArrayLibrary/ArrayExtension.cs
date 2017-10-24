using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    public class ArrayExtension
    {
        public static int[] FilterDigit(int digit, params int[] array)
        {
            CheckArrayForFilter(array);
            List<int> filterDigitArray = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                int elementOfArray = array[i];
                if (IsContainDigit(elementOfArray, digit))
                {
                    filterDigitArray.Add(array[i]);
                    elementOfArray = 0;
                }
            }
            return filterDigitArray.ToArray();
        }

        public static bool IsContainDigit(int elementOfArray, int digit)
        {
            while (elementOfArray != 0)
            {
                if (elementOfArray % 10 == digit) return true;
                elementOfArray = elementOfArray / 10;
            }
            return false;
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
    }
}
