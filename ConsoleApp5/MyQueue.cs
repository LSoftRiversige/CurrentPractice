using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class MyQueue<T> 
    {
        private T[] buf;
        private readonly int capacity;
        private int index = -1;
        private int lastIndex = -1;

        public MyQueue(int capacity)
        {
            this.capacity = capacity;
            buf = new T[capacity];
        }

        public virtual void Clear()
        {
            index = -1;
            lastIndex = -1;
        }

        private int Size()
        {
            return buf.Length;
        }

        private delegate void ActionOfIteration(T value, out bool end);

        public virtual bool Contains(T value)
        {
            void Check(T v, out bool e)
            {
                e = v.Equals(value);
            }
            return Iterator(Check);
        }

        public virtual void CopyTo(Array array, int index)
        {
            int counter = 0;
            void DoCopy(T val, out bool e)
            {
                e = false;
                array.SetValue(val, index+counter++);
            };
            Iterator(DoCopy);
        }

        public virtual object Dequeue()
        {
            index++;
            if (index > lastIndex) return null;
            object result = buf[index];
            buf[index] = default(T);
            if (index == lastIndex)
            {
                Clear();
            }
            return result;
        }

        public virtual void Enqueue(T value)
        {
            lastIndex++;
            TryAddCapacity();
            buf[lastIndex] = value;
        }

        private void TryAddCapacity()
        {
            if (buf.Length <= lastIndex)
            {
                int capacityCount = buf.Length / capacity;
                Array.Resize(ref buf, ++capacityCount * capacity);
            }
        }

        public virtual IEnumerator GetEnumerator()
        {
            T[] temp = ToArray();
            foreach (var val in temp)
            {
                yield return val;
            }
        }
        
        public virtual object Peek()
        {
            if (index > lastIndex) return null;
            if (index == -1)
            {
                if (lastIndex == -1) return null;
                else return buf[0];
            }
            return buf[index];
        }

        public virtual T[] ToArray()
        {
            T[] arr = new T[Count()];

            int counter = 0;

            void SaveToArray(T v, out bool e)
            {
                arr[counter++] = v;
                e = false;
            }

            Iterator(SaveToArray);

            return arr;
        }

        private int Count()
        {
            int startIndex = index == -1 ? 0 : index;
            return lastIndex - startIndex + 1;
        }

        public static void SelfTest()
        {
            var myQueue = new MyQueue<int>(5);
            myQueue.Enqueue(1);
            //Console.WriteLine($"Peek={myQueue.Peek()}");
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            //Console.WriteLine($"Peek={myQueue.Peek()}");
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Enqueue(7);
            //myQueue.Display();

            foreach (var val in myQueue)
            {
                Console.WriteLine(val);
            }

            //int[] a = myQueue.ToArray();
            //foreach (var val in a)
            //{
            //    Console.WriteLine(val);
            //}

            //int[] b = new int[15];
            //myQueue.CopyTo(b, 4);

            //foreach (var val in b)
            //{
            //    Console.WriteLine(val);
            //}

            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //myQueue.Display();
            //Console.WriteLine($"Peek={myQueue.Peek()}");
            //myQueue.Enqueue(20);
            //myQueue.Enqueue(30);
            //myQueue.Enqueue(40);
            //myQueue.Display();
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //Console.WriteLine($"извлечение {myQueue.Dequeue()}");
            //myQueue.Display();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private bool Iterator(ActionOfIteration action)
        {
            int start = index;
            if (start < 0)
            {
                start = 0;
            }

            for (int i = start; i <= lastIndex; i++)
            {
                action(buf[i], out bool endOfIteration);
                if (endOfIteration)
                {
                    return true;
                }
            }
            return false;
        }

        private void Display(bool showBuff = false)
        {
            Console.WriteLine("Содержание очереди");
            if (showBuff)
            {
                foreach (var value in buf)
                {
                    Console.WriteLine(value);
                }
            }
            else
            {
                void WriteToScreen(T val, out bool e)
                {
                    Console.WriteLine(val);
                    e = false;
                };
                Iterator(WriteToScreen);
            }
            Console.WriteLine($"index={index} lastIndex={lastIndex}");
        }
    }
}
