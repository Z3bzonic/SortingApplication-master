using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingApplication
{
    class SortingAlgorithmTester
    {
        enum SortingAlgorithm
        {
            BubbleSort,
            ShakerSort,
            QuickSort
        }

        private int swapped = 0;

        void Swap(int index1, int index2, int[] array)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            swapped++;
        }

        void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        void QuickSort(int[] array, int Left, int Right)
        {
            int L = Left;
            int R = Right;
            int pivotValue = array[(Left + Right) / 2];

            do
            {
                while (array[L] < pivotValue)
                {
                    L++;
                }
                while (pivotValue < array[R])
                {
                    R--;
                }

                if (L <= R)
                {
                    Swap(L, R, array);
                    L++;
                    R--;
                }
            } while (L < R);

            if (Left < R)
            {
                QuickSort(array, Left, R);
            }
            if (L < Right)
            {
                QuickSort(array, L, Right);
            }
        }

        void ShakerSort(int[] array)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        swapped = true;
                        Swap(i, i + 1, array);
                    }
                }

                if (!swapped) break;

                for (int i = array.Length - 2; i >= 0; --i)
                {
                    if (array[i] > array[i + 1])
                    {
                        swapped = true;
                        Swap(i, i + 1, array);
                    }
                }
            }
        }

        void BubbleSort(int[] array)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        swapped = true;
                        Swap(i, i + 1, array);
                    }
                }
            }
        }

        void Sort(SortingAlgorithm algorithm, int[] array)
        {
            switch (algorithm)
            {
                case SortingAlgorithm.BubbleSort:
                    BubbleSort(array);
                    break;
                case SortingAlgorithm.ShakerSort:
                    ShakerSort(array);
                    break;
                case SortingAlgorithm.QuickSort:
                    QuickSort(array);
                    break;
            }
        }

        public void Test()
        {
            var values = (SortingAlgorithm[])Enum.GetValues(typeof(SortingAlgorithm));
            foreach (var algorithm in values)
            {
                swapped = 0;
                int[] array = { 88, 12, 55, 105, 48, 84, 66, 35, 57, 89, 74, 106, 200, 541, 1, 9, 7, 55, 405, 13 };
                Sort(algorithm, array);
                Console.WriteLine($"sorting done using {algorithm}, needed {swapped} swaps to sort the array");
            }

            Console.ReadKey();
        }
    }
}
