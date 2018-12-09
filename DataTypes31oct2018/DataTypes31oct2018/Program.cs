using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes31oct2018
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "123";
            int parseInt = Int32.Parse(s);


            Console.WriteLine("{0}"+ parseInt +"dddd");

            //новый синтаксис
            Console.WriteLine($"dddd {parseInt}");

            //делениена ноль
            double d = 5 / 0.00;
            Console.WriteLine($"{d}");

            //double d1 = 1000;

            Console.WriteLine($"{double.MinValue}");
            Console.WriteLine($"{double.MaxValue}");
            Console.WriteLine($"byte.max={byte.MaxValue}");
            Console.WriteLine($"sbyte.max={sbyte.MaxValue}");
            Console.WriteLine($"decimal.max={decimal.MaxValue}");

            //работа со строками
            Console.WriteLine("символ + в 16 коде \x2B");

            //string str = Console.ReadLine();

            //объявление значимых типов, которые могут содержать null
            System.Nullable<int> iii = null;
            int? int1 = null;

            if (char.IsDigit('x')) { Console.WriteLine("это цифра"); }
            { Console.WriteLine("это Не цифра"); }

            Console.WriteLine("9.GetHashCode={0}", 9.GetHashCode());
            Console.WriteLine("9.Equals(9)={0}", 9.Equals(9));
            Console.WriteLine("9.GetType()={0}", 9.GetType());
            Console.WriteLine("9.GetTypeCode()={0}", 9.GetTypeCode());

            decimal int777 = 7M;

            //перенос строки @
            string sss = @" ds dsfds dsf dsf 
sdfdsfdsf sdf dsf dsf sd
 ds
fds 
fsd
 fsd
f sd
f sd";
            Console.WriteLine(sss);

            var V1 = 5M;

            Console.WriteLine("var {0}", V1);

            //Immediate Window; найти в оболочке

            //константы
            const int min_hour = 60;
            //const min_hour1 = 60;

            object someObj = 23; //неявное приведение типа
            int someInt = (int)someObj; //явное приведение типа object к int

            //контроль переполнения
            //checked
            //{
            //    int intByte = 256;
            //    byte bbb = (byte)intByte; //переполнение
            //}

            //контроль переполнения по-умолчанию
            unchecked
            {
                int intByte = 256;
                byte bbb = (byte)intByte; //переполнение
            }

            //унарные и бинарные операторы: a+b; i++, i--
            int int000 = 8;
            int int999 = int000--; //7


            //замена if
            string R = int999 < 100 ? "Да" : "Нет";

            Console.WriteLine(7 % 3);
            Console.WriteLine(7.0m % 3.0m);

            //префиксный и посфиксный инкремент
            int999 = 1;
            Console.WriteLine(int999++);
            int999 = 1;
            Console.WriteLine(++int999);

            object objNull = new object();
            object objNull1 = objNull ?? new object(); //если первый нал, то новый

            bool Result = Object.ReferenceEquals(objNull, objNull1);
            Console.WriteLine(Result);

            //for (int i = 0; i <= 5; i++) { Result = i & Console.Write("{0}\t", Result); }

            //Array.Sort();
            //Array.Copy();

            1 и 2 лабораторные скинуть. 3 дополнительно будет задана.

            Console.ReadLine();
        }
    }
}
