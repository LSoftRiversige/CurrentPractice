using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class MyStack<T>: IEnumerable<T>
    {
        private T[] stack;
        private readonly int capacity;
        private int topIndex = -1;

        private bool IsEmpty()
        {
            return topIndex == -1;
        }

        private delegate void ApplyAllAction(T value, out bool end);

        public MyStack(int capacity)
        {
            this.capacity = capacity;
            stack = new T[capacity];
        }

        private void TryExpandStack()
        {
            if (topIndex == stack.Length)
            {
                int capacityCount = stack.Length / capacity;
                Array.Resize(ref stack, ++capacityCount * capacity);
            }
        }

        private bool ApplyAll(ApplyAllAction action)
        {
            int top = topIndex;
            if (top < 0)
            {
                top = 0;
            }

            for (int i = 0; i <= top; i++)
            {
                action(stack[i], out bool endOfIteration);
                if (endOfIteration)
                {
                    return true;
                }
            }
            return false;
        }

        public int Count { get => topIndex+1; }

        public void Clear()
        {
            for (int i = 0; i <= topIndex; i++)
            {
                stack[i] = default(T);
            }
            topIndex = -1;
        }

        public bool Contains(T item)
        {
            void Check(T val, out bool end)
            {
                end = item.Equals(val);
            };
            return ApplyAll(Check);
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }
            
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index is less than zero");
            }

            if (array.Rank > 1 || array.Length - arrayIndex <= topIndex)
            {
                const string errorMessage = "Array is multidimensional. -or- The number of " +
                    "elements in the source System.Collections.Stack is greater than the available space " +
                    "from index to the end of the destination array.";
                throw new ArgumentException(nameof(array), errorMessage);
            }

            int counter = 0;
            void DoCopy(T val, out bool e)
            {
                e = false;
                array.SetValue(val, arrayIndex+counter++);
            };
            ApplyAll(DoCopy);
        }

        //public Enumerator GetEnumerator();

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return stack[topIndex];
        }

        public T Pop()
        {
            T result = Peek();
            stack[topIndex] = default(T);
            topIndex--;
            return result;
        }

        public void Push(T item)
        {
            topIndex++;
            TryExpandStack();
            stack[topIndex] = item;
        }

        public T[] ToArray()
        {
            var result = new T[topIndex+1];
            if (result.Length > 0)
            {
                int index = 0;
                void DoCopy(T val, out bool stop)
                {
                    result[index++] = val;
                    stop = false;
                };
                ApplyAll(DoCopy);
            }
            return result;
        }

        public bool TryPeek(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }
            result = Peek();
            return true;
        }

        public bool TryPop(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }
            result = Pop();
            return true;
        }

        public struct Enumerator : IEnumerator<T>
        {
            MyStack<T> stack;
            private int index;
            

            public Enumerator(MyStack<T> stack) : this()
            {
                this.stack = stack;
                index = -1;
            }

            public T Current { get => stack.stack[index]; }


            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                index++;
                return index <=  stack.topIndex;
            }

            public void Reset()
            {
                index = 0;
            }

            object IEnumerator.Current { get => Current; }
        }

        private void Display(bool showArray)
        {
            Console.WriteLine("Состояние стека:");
            if (!showArray)
            {
                foreach (var val in this)
                {
                    
                    Console.WriteLine(val);
                }
            }
            else
            {
                for (int i = 0; i < stack.Length; i++)
                {
                    string s;
                    T val = stack[i];
                    if (val==null) s = "...";
                    else s = val.ToString();
                    Console.WriteLine(s);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static void SelfTest()
        {
            MyStack<string> stack = new MyStack<string>(10);
            stack.Push("Item1");
            stack.Push("Item2");
            stack.Push("Item3");
            stack.Push("Item4");
            stack.Push("Item5");
            stack.Display(true);
            //stack.Clear();
            //stack.Display(true);

            //Console.WriteLine("Testing Pop()");
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //stack.Display(true);

            //string[] strArr = stack.ToArray();
            //Console.WriteLine("ToArray()");
            //foreach (var s in strArr)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("CopyTo()");
            //string[] strCopy = new string[10];
            //stack.CopyTo(strCopy, 5);
            //foreach (var s in strCopy)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("Contains()");
            //if (stack.Contains("Item2"))
            //{
            //    Console.WriteLine("Yes");
            //}

            //Console.WriteLine("TryPeek()");
            //Console.WriteLine(stack.TryPeek(out string res));
            //Console.WriteLine(res);
            //Console.WriteLine(stack.TryPeek(out res));
            //Console.WriteLine(res);
            //Console.WriteLine(stack.TryPeek(out res));
            //Console.WriteLine(res);
            //Console.WriteLine(stack.TryPeek(out res));
            //Console.WriteLine(res);
            //Console.WriteLine(stack.TryPeek(out res));
            //Console.WriteLine(res);
            //Console.WriteLine(stack.TryPeek(out res));
            //Console.WriteLine(res);
            //Console.WriteLine(stack.TryPeek(out res));
            //Console.WriteLine(res);

            Console.WriteLine("TryPop()");
            Console.WriteLine(stack.TryPop(out string res));
            Console.WriteLine(res);     
            Console.WriteLine(stack.TryPop(out res));
            Console.WriteLine(res);     
            Console.WriteLine(stack.TryPop(out res));
            Console.WriteLine(res);     
            Console.WriteLine(stack.TryPop(out res));
            Console.WriteLine(res);     
            Console.WriteLine(stack.TryPop(out res));
            Console.WriteLine(res);     
            Console.WriteLine(stack.TryPop(out res));
            Console.WriteLine(res);     
            Console.WriteLine(stack.TryPop(out res));
            Console.WriteLine(res);

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}

