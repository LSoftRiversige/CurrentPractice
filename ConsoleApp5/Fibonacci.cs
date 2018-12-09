using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    /// <summary>
    /// последовательность, в которой первые два числа равны либо 1 и 1, либо 0 и 1, а каждое последующее число равно сумме двух предыдущих чисел
    /// </summary>
    class Fibonacci : IEnumerator<int>, IEnumerable
    {
        int curr, prev;

        public Fibonacci()
        {
            Reset();
        }

        public bool MoveNext()
        {
            try
            {
                checked { int checkSum = curr+(curr + prev); }
            }
            catch (Exception)
            {
                return false;
            }

            if (prev < 0)
            {
                return true;
            }

            int currOld = curr;
            int currNew = prev + curr;
            prev = currOld;
            curr = currNew;
            
            return currNew < int.MaxValue;
        }

        public void Reset()
        {
            prev = -1;
            curr = 0;
        }

        object IEnumerator.Current { get => this.Current; } 

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public int Current {
            get
            {
                checked
                {
                    if (prev == -1 && curr == 0)
                    {
                        prev = 0;
                        return 0;
                    }
                    if (prev == 0 && curr == 0)
                    {
                        curr = 1;
                        return 1;
                    }
                    return prev + curr;
                }
            }
        }

        public void Dispose()
        {
            
        }
        
    }
}
