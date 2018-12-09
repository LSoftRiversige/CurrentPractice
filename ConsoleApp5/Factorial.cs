using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class Factorial: IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new FactorialEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class FactorialEnumerator : IEnumerator<int>
        {
            int index;

            public int Current {
                get {
                    return FactorialOf(index);
                }
            }

            private int FactorialOf(int index)
            {
                if (index == 0) {
                    return 1;
                }

                int result=1;

                for (int i = 1; i < index; i++)
                {
                    result *= i;
                }

                return result;
            }

            public bool MoveNext()
            {
                index++;
                return index <=17;
            }

            public void Reset()
            {
                index = -1;
            }

            object IEnumerator.Current { get => Current; }

            public void Dispose()
            {
                
            }
        }
    }
}
