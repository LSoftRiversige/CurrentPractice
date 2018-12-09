using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var (h, _, m, _) = Params();//отбрасывание

            Console.WriteLine($"Hello World! h={h}, m={m}");

            (string s, int i) p;

            

            string userinput = Console.ReadLine();
        }

        public static (int H, int W, int M, int D) Params()
        {
            return (1, 2, 3, 4);
        }
    }
}
