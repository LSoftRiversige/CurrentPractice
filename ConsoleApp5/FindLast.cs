using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace ConsoleApp5
{
    class FindExamples
    {
        public static void SelfTest()
        {
            var ex = new FindExamples();
            int[] myArr = new int[] { 1, 2, 3, 4, 20, 45, 60, 69, 200 };

            int[] selArr = ex.FindAll(myArr, p => p > 20 && p < 60);

            foreach (var item in selArr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();

            var example = new FindExamples();
            int[] myArr1 = new int[] { 1, 2, 3, 4, 20, 45, 60, 69, 200 };

            int ixTest = example.BinarySearch(myArr1, 4);
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            ixTest = example.BinarySearch(myArr1, 3);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            ixTest = example.BinarySearch(myArr1, 4);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            ixTest = example.BinarySearch(myArr1, 20);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            ixTest = example.BinarySearch(myArr1, 45);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            ixTest = example.BinarySearch(myArr1, 60);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            ixTest = example.BinarySearch(myArr1, 69);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            ixTest = example.BinarySearch(myArr1, 200);
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            foreach (var value in myArr1)
            {
                int ix = example.BinarySearch(myArr1, value);
                Console.WriteLine($"Found index for value {value} is {ix}");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }

        public T[] FindAll<T>(T[] array, Predicate<T> match)
        {
            T[] retArr = new T[array.Length];
            int index = 0;
            foreach (var item in array)
            {
                if (match(item))
                {
                    retArr[index++] = item;
                }
            }
            Array.Resize(ref retArr, index);
            return retArr;
        }

        public int BinarySearch(int[] array, int value)
        {
            bool found = false;
            int index = -1;
            int max = array.Length;
            int min = 0;
            int iterationCount = 0;
            while (!found)
            {
                int delta = (max - min) / 2;
                if (delta <= 1)
                {
                    for (int i = min; i < max; i++)
                    {
                        AddIteration(ref iterationCount);
                        if (value == array[i]) return i;
                    }
                }
                index = min + delta;
                found = value == array[index];
                AddIteration(ref iterationCount);
                if (!found)
                {
                    bool isLeftSide = value < array[index];
                    if (isLeftSide)
                    {
                        if (min > max) min = 0;
                        max = index;
                    }
                    else
                    {
                        min = index+1;
                        max = array.Length;
                    }
                }
            }
            if (found) return index;
            return -1;
        }

        private static void AddIteration(ref int iterationCount)
        {
            iterationCount++;
            Console.WriteLine($"iteration {iterationCount}");
        }

        public T Find<T>(T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public T FindLast<T>(T[] array, Predicate<T> predicate)
        {
            for (int i = array.Length-1; i <= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public int FindLastIndex<T>(T[] array, Predicate<T> predicate)
        {
            for (int i = array.Length - 1; i <= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool TrueForAll<T>(T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!predicate(array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Exists<T>(T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}