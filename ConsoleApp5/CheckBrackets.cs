using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    //Написать метод который проверяет корректность строки со скобками, пример строки "()()()()()((()))". Использовать стек.
    public static class Brackets
    {
        public static bool Check(string s, char open = '(', char close = ')')
        {
            var ts = new Stack<char>();
            foreach (var c in s)
            {
                if (c == open) ts.Push(c);
                else
                {
                    if (c == close)
                    {
                        if (ts.Count > 0) ts.Pop();
                        else return false;
                    }
                }
            }
            return ts.Count == 0;
        }

        public static void SelfTest()
        {
            const string br = "{{{{{{{{{{{{}}}}}}}}}}}}";
            Console.WriteLine($"{br} check result = {Check(br, '{', '}')}");

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
