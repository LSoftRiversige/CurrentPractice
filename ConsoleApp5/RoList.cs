using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class RoList: IReadOnlyList<int>
    {
        List<int> list;

        public RoList(List<int> list)
        {
            this.list = list ?? throw new ArgumentNullException(nameof(list));
        }

        public int this[int index] { get => list[index]; }

        public int Count { get => list.Count; }

        public IEnumerator<int> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
