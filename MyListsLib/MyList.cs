using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class MyList<T>: IList<T>
    {
        private T[] array;

        public MyList(T[] array)
        {
            this.array = array ?? throw new ArgumentNullException(nameof(array));
        }

        public static void SelfTest()
        {
            var l = new MyList<int>(new int[] { 1, 2, 3, 4, 5, 45, 6, 88 });
            l.Print();
            l.Add(6);
            l.Insert(2, 777);
            l.Remove(88);
            l.RemoveAt(2);
            l.Print();

            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine(l[i]);
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();

            if (l.Contains(3)) Console.WriteLine("Содержит 3");
            if (!l.Contains(8)) Console.WriteLine("Не содержит 8");

            int[] newArr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            l.CopyTo(newArr, 2);

            foreach (var val in newArr)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine($"l.IndexOf(5)={l.IndexOf(5)}");

            l.Clear();
            l.Print();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(array, item);
        }

        public void Insert(int index, T item)
        {
            int newSize = array.Length + 1;
            T[] temp = new T[newSize];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < index) temp[i] = array[i];
                else if (i == index)
                {
                    temp[i] = item;
                    temp[i + 1] = array[i];
                }
                else temp[i + 1] = array[i];
            }
            Array.Resize(ref array, newSize);
            for (int i = 0; i < temp.Length; i++)
            {
                array[i] = temp[i];
            }
        }

        public void RemoveAt(int index)
        {
            int newSize = array.Length - 1;
            T[] temp = new T[newSize];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < index) temp[i] = array[i];
                else if (i > index) temp[i-1] = array[i];
            }
            Array.Resize(ref array, newSize);
            for (int i = 0; i < temp.Length; i++)
            {
                array[i] = temp[i];
            }
        }

        public T this[int index] { get => array[index]; set => array[index] = value; }

        public void Add(T item)
        {
            int newSize = array.Length + 1;
            Array.Resize(ref array, newSize);
            array[newSize - 1] = item;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
        }

        public bool Contains(T item)
        {
            foreach (var value in array)
            {
                if (item.Equals(value)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1) throw new ArgumentException("The destination array must has rank = 1");
            if (array.Length - arrayIndex < this.array.Length)
            {
                throw new ArgumentException(@"The number of elements in the source "+
                "System.Collections.Generic.List`1 is greater than the number of elements +" +
                "that the destination array can contain.");
            }

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = this.array[i];
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public int Count { get => array.Length; }
        public bool IsReadOnly { get => false; }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Print()
        {
            foreach (var value in array)
            {
                Console.WriteLine(value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}
