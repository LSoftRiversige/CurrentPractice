using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp5
{

    //стек и очередь


    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<string>.SelfTest();

            MyList<int>.SelfTest();

            Brackets.SelfTest();

            FindExamples.SelfTest();
        }
    }
}



