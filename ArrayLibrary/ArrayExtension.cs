using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    public class ArrayExtension
    {
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
    }
}
