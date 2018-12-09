using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    public class MyLinkedList<T>
    {
        MyLinkedListNode first;
        MyLinkedListNode last;

        public static void SelfTest()
        {
            var listForTest = new MyLinkedList<string>();
            TestAdding(listForTest);
            TestRemoving(listForTest);
            TestForEach(listForTest);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void TestRemoving(MyLinkedList<string> listForTest)
        {
            listForTest.Remove("zero");

            listForTest.Remove("777");

            listForTest.Print();

            listForTest.RemoveFirst();

            listForTest.Print();

            listForTest.RemoveLast();

            listForTest.Print();
        }

        private static void TestAdding(MyLinkedList<string> listForTest)
        {
            var firstNode = listForTest.AddFirst("first");

            var secondNode = listForTest.AddLast("second");

            listForTest.AddLast("third");

            listForTest.AddLast("fourth");

            listForTest.AddFirst("zero");

            listForTest.AddBefore(firstNode, "before first");

            listForTest.AddBefore(secondNode, "before second");

            listForTest.AddAfter(firstNode, "after first");

            listForTest.AddLast("new last");

            listForTest.AddLast("777");
        }

        private static void TestForEach(MyLinkedList<string> listForTest)
        {
            Console.WriteLine($"test foreach:");
            foreach (var node in listForTest)
            {
                Console.WriteLine(node);
            }
        }

        public class MyLinkedListNode
        {
            public MyLinkedListNode prev;
            public MyLinkedListNode next;
            private readonly T value;

            public MyLinkedListNode(MyLinkedListNode prev, MyLinkedListNode next, T value)
            {
                this.prev = prev;
                this.next = next;
                this.value = value;
            }

            public MyLinkedListNode Next { get => next; }
            public MyLinkedListNode Previous { get => prev; }
            public T Value { get => value; }

            public void LinkAfter(MyLinkedListNode node)
            {
                MyLinkedListNode oldNext = node.next;
                next = oldNext;
                prev = node;
                node.next = this;
                if (oldNext != null) oldNext.prev = this;
            }

            public void LinkBefore(MyLinkedListNode node)
            {
                MyLinkedListNode oldPrev = node.prev;
                prev = oldPrev;
                next = node;
                node.prev = this;
                if (oldPrev != null) oldPrev.next = this;
            }

            public void Clear()
            {
                if (prev != null)
                {
                    prev.next = next;
                }
                if (next != null)
                {
                    next.prev = prev;
                }
                prev = null;
                next = null;
            }

            public void MakeFirst(ref MyLinkedListNode first)
            {
                prev = null;
                first = this;
            }

            public void MakeLast(ref MyLinkedListNode last)
            {
                next = null;
                last = this;
            }

            public void Print()
            {
                Console.WriteLine(Value);
            }

            internal void LinkToLast(MyLinkedListNode last)
            {
                prev = last;
                last.next = this;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public MyLinkedListNode Last => last;
        public MyLinkedListNode First => first;
        
        public int Count
        {
            get
            {
                return CalcCount();
            }
        }

        private int CalcCount()
        {
            MyLinkedListNode curr = First;
            int counter = 0;
            while (curr != null)
            {
                counter++;
                curr = curr.Next;
            };
            return counter;
        }

        public MyLinkedListNode AddAfter(MyLinkedListNode node, T value)
        {
            if (node != null)
            {
                var newNode = new MyLinkedListNode(null, null, value);

                newNode.LinkAfter(node);
                if (last == node) last = newNode;
                return newNode;
            }
            return null;
        }

        public MyLinkedListNode AddBefore(MyLinkedListNode node, T value)
        {
            if (node != null)
            {
                var newNode = new MyLinkedListNode(null, null, value);
                newNode.LinkBefore(node);
                if (first == node) first = newNode;
                return newNode;
            }
            return null;
        }

        public MyLinkedListNode AddFirst(T value)
        {
            if (first == null)
            {
                first = new MyLinkedListNode(null, null, value);
                last = first;
            }
            else
            {
                MyLinkedListNode newNode = new MyLinkedListNode(null, first, value)
                {
                    next = first
                };
                first.prev = newNode;
                first = newNode;
                return newNode;
            }
            return first;
        }

        public MyLinkedListNode AddLast(T value)
        {
            MyLinkedListNode newNode = new MyLinkedListNode(null, null, value);
            newNode.LinkToLast(last);
            last = newNode;
            return newNode;
        }

        public void Clear()
        {
            MyLinkedListNode curr = First;
            while (curr != null)
            {
                MyLinkedListNode toClearNode = curr;
                curr = curr.Next;
                toClearNode.Clear();
            }
            first = null;
            last = null;
        }

        public bool Contains(T value)
        {
            MyLinkedListNode curr = First;
            while (curr != null)
            {
                if (curr.Value.Equals(value))
                {
                    return true;
                }
                curr = curr.Next;
            }
            return false;
        }

        public void Print()
        {
            Console.WriteLine($"\nПечать списка узлов:");
            MyLinkedListNode curr = First;
            while (curr !=null)
            {
                curr.Print();
                curr = curr.Next;
            }
            Console.WriteLine($"-------------\nCount={Count}");
        }

        public MyLinkedListNode Find(T value)
        {
            MyLinkedListNode curr = First;
            while (curr != null)
            {
                if (curr.Value.Equals(value))
                {
                    return curr;
                }
                curr = curr.Next;
            }
            return null;
        }

        public MyLinkedListNode FindLast(T value)
        {
            MyLinkedListNode curr = First;
            MyLinkedListNode found = null;
            while (curr != null)
            {
                if (curr.Value.Equals(value))
                {
                    found = curr;
                }
                curr = curr.Next;
            }
            return found;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(first);
        }

        public class Enumerator: IEnumerator
        {
            private MyLinkedListNode current;
            private readonly MyLinkedListNode first;

            public Enumerator(MyLinkedListNode start)
            {
                current = null;
                first = start;
            }

            public bool MoveNext()
            {
                if (current != null) current = current.Next;
                else current = first;
                return current != null;
            }

            public void Reset()
            {
                current = first;
            }

            public object Current => current;
        }

        public bool Remove(T value)
        {
            MyLinkedListNode foundNode = Find(value);
            if (foundNode != null)
            {
                if (first == foundNode) first = foundNode.Next;
                if (last == foundNode) last = foundNode.Previous;
                foundNode.Clear();
                return true;
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (first != null)
            {
                first.Next.MakeFirst(ref first);
            }
        }

        public void RemoveLast()
        {
            if (last != null)
            {
                last.Previous.MakeLast(ref last);
            }
        }

    }
}
