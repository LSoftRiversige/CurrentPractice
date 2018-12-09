using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class SequenceN: IEnumerator, IEnumerable
    {
        private int currentNum;
        private readonly int num;

        public SequenceN(int n)
        {
            num = n;
        }

        public bool MoveNext()
        {
            if (currentNum >= num)
            {
                return false;
            }
            return ++currentNum <= num;
        }

        public void Reset()
        {
            currentNum = -1;
        }

        public object Current {
            get
            {
                if (currentNum > num) throw new Exception("out of range");
                if (currentNum == -1) throw new Exception("not started");
                return currentNum;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
