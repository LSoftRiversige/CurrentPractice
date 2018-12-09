using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class ThisTest
    {
        int[] arr;

        public ThisTest(int[] arr)
        {
            this.arr = arr ?? throw new ArgumentNullException(nameof(arr));
        }

        public int this[int index] { get=>arr[index]; set => arr[index]=value; }
    }
}
