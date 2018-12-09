using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


//включение контроля CLS совместимости
[assembly: CLSCompliant(true)]

namespace ConsoleApp2
{

    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int z = 0, a1 = 0;

            Console.WriteLine(++z);
            Console.WriteLine(a1++);

            WaitEnter();



            Console.WriteLine(++z);

            int[] a = new int[5] { 1, 2, 3, 4, 5 };
            for (int i = 0; i <= a.Length - 1; ++i)
            {
                Console.WriteLine(a[i]);
            }

            WaitEnter();

            int currentValue = 0;

            Console.WriteLine("Test 1: ++x");
            TestMethod(++currentValue, currentValue);

            Console.WriteLine("\nTest 2: x++");
            TestMethod(currentValue++, currentValue);


            Console.ReadKey();

            double posValue = 1234;
            double negValue = -1234;
            double zeroValue = 0;

            string fmt2 = "##;(##)";
            string fmt3 = "##;(##);**Zero**";

            Console.WriteLine(posValue.ToString(fmt2));
            Console.WriteLine(String.Format("{0:" + fmt2 + "}", posValue));
            // Displays 1234

            Console.WriteLine(negValue.ToString(fmt2));
            Console.WriteLine(String.Format("{0:" + fmt2 + "}", negValue));
            // Displays (1234)

            Console.WriteLine(zeroValue.ToString(fmt3));
            Console.WriteLine(String.Format("{0:" + fmt3 + "}", zeroValue));
            // Displays **Zero**

            double n = 9.3;
            Console.WriteLine($@"{n:##.0\%}");
            Console.WriteLine($@"{n:\'##\'}");
            Console.WriteLine($@"{n:\\##\\}");
            Console.WriteLine();
            Console.WriteLine($"{n:##.0'%'}");
            Console.WriteLine($@"{n:'\'##'\'}");




            WaitEnter();

            //NullableVar();
            //EnumEx();
            //перегрузка методов
            //RunEx();
            //Console.WriteLine(SumOf(1, 2, 3, 3.9));
            //WaitEnter();
            //SwitchExample();
            //Env();
            //WaitEnter();
            //WriteArgs(args);
            //WaitEnter();


        }

        private static void TestMethod(int passedInValue, int currentValue)
        {
            Console.WriteLine("Current:{0} Passed-in:{1}",
                currentValue,
                passedInValue
            );
        }

        private static void NullableVar()
        {
            int? iNum = 2;

            int j = iNum ?? 1;

            Console.WriteLine(j);
        }

        private static void RunEx()
        {
            Run(1);
            Run("eqwerwrqwtrqwtrqwt");

            //метод с именованными параметрами
            //RunCalc(message: "Hello");
            //RunCalc();
        }

        private static void EnumEx()
        {
            MyEnum e = MyEnum.Q1;

            switch (e)
            {
                case MyEnum.Q1:
                    break;
                case MyEnum.Q2:
                    break;
                default:
                    break;
            }
        }

        private static void Run(int i)
        {
            Console.WriteLine(i);
        }

        private static void Run(string s)
        {
            Console.WriteLine(s);
        }

        private static void RunCalc(double sum = 0.546, int count = 1, string message = "Hi")
        {
            Console.WriteLine(message);
        }

        private static double SumOf(params double[] d)
        {
            double Buf = 0;
            foreach (double i in d)
            {
                Buf = Buf + i;
            }
            return Buf;
        }

        private static void SwitchExample()
        {
            string ss = Console.ReadLine();


            switch (ss)
            {
                case "q": Console.WriteLine("q"); break;

                case "1": Console.WriteLine("2"); break;


                default: Console.WriteLine("Default"); break;
            }

            int N = int.Parse(Console.ReadLine());


            switch (N)
            {
                case 1: Console.WriteLine("1"); break;

                case 2: Console.WriteLine("2"); break;


                default: Console.WriteLine("Default"); break;
            }

            BigInteger biggy = BigInteger.Parse("958723598237520398723098572309587235982375923875");
            Console.WriteLine(biggy);
            WaitEnter();

            Console.WriteLine("{0:c}", 923423234234);
            Console.WriteLine("{0:n} грн.", 923423234234);
            Console.WriteLine("{0:d9}", 9);

            Console.WriteLine(DateTime.DaysInMonth(2018, 11));


            WaitEnter();
        }

        private static void WaitEnter()
        {
            Console.ReadLine(); Console.Clear();
        }

        /// <summary>
        /// получение информации об ОС
        /// </summary>
        private static void Env()
        {
            Console.WriteLine("Число процессоров: {0}", Environment.ProcessorCount);
            Console.WriteLine("OS Ver: {0}", Environment.OSVersion);
            Console.WriteLine(".Net Ver: {0}", Environment.Version);
            Console.WriteLine("CurrentManagedThreadId: {0}", Environment.CurrentManagedThreadId);
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод на консоль списка аргументов приложения
        /// </summary>
        /// <param name="args">аргументы</param>
        private static void WriteArgs(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
        }

        private static void All()
        {
            UInt32 V = Method1();

            //наследование простых типов
            InheritanceTypesExample();

            //математические операции
            MathOperationExample();

            //установка размеров окна вывода консоли
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(86, 20);
            Console.SetWindowPosition(0, 0);

            //взаимодействие с консолью
            GetInformationFromConsole();

            //проверка цикла, использование табуляции в строке для форматирования вывода информации
            CicleExample(10000);

            //проверка типа "объект"
            ObjectExample();

            int iCount = 500;

            //вызов первого примера
            Example1(iCount);

            //вызов второго примера
            Example2();

            //пример использования параметров, передаваемых по ссылке и по значению

            string sFirmName = "Рога и копыта", sPersonName = "Бурбулькин Б.Б.";

            ParamExample(ref sFirmName, sPersonName);

            Console.WriteLine("Значения строковых параметров после выхода из метода");
            Console.WriteLine();
            Console.WriteLine("{0}, {1}", sPersonName, sFirmName);
        }

        private static UInt32 Method1()
        {
            return 0;
        }

        struct Firm
        {
            public int Id;
            public string Name;
            internal string Caption() { return "Компания №" + Convert.ToString(Id) + " - " + Name; }
        }

        private static void InheritanceTypesExample()
        {
            //инициализатор структуры
            Firm f = new Firm { Name = "Nike", Id = 0 };
            Console.WriteLine("Описание компании: {0}", f.Caption());
            f = DefineFirm(f);
            Console.WriteLine("Описание компании: {0}", f.Caption());
        }

        private static Firm DefineFirm(Firm f)
        {

            f.Id = 1;
            f.Name = "Vad";
            return f;
        }

        private static void MathOperationExample()
        {
            WCons("Введите целое число:");
            bool Repeat = false;
            int i = RCons(ref Repeat);

            //квадратный корень
            double sqrt = Math.Sqrt(i);
            WCons(sqrt.ToString(""));

            Console.ReadKey();
        }

        private static void GetInformationFromConsole()
        {
        again:
            //сделать запрос пользователю и получить от него информацию
            WCons("Введите число от 1 до 100");

            bool repeat = false;

            //запрашиваем ввод числа от пользователя
            int iNum = RCons(ref repeat);

            //если ввод не корректен, повторяем снова
            if (repeat) { goto again; }

            //проверяем введенный результат
            if (iNum > 100 || iNum < 1)
            {
                WCons("Число больше 100 или меньше 1, повторить ввод");
                goto again;
            }
        }

        private static int RCons(ref bool repeat)
        {
            repeat = false;

            object s = null;
            //читаем строку, введенную пользователем
            s = Console.ReadLine();


            try

            { return Convert.ToInt32(s); }

            catch

            {
                WCons("Да это вообще не число!!!. Повторить!!!");
                repeat = true;
                return 0;
            }

        }

        private static void WCons(string v)
        {
            Console.WriteLine(v);
        }

        private static void CicleExample(int totalLimit)
        {
            int i, dSum = 100, dTotalSum = 0;

            for (i = 0; dTotalSum < totalLimit; i++)
            {
                dTotalSum = dTotalSum + dSum;
                Console.WriteLine("i={0}\tTotal={1}\t{2}\t{3}", i, dTotalSum, dSum, totalLimit);
            }

            dTotalSum = 0;

            //запись цикла еще раз
            for (i = 1; i <= 1000; i++)
            {
                dTotalSum = dTotalSum + i;
                Console.WriteLine("Total={0}", dTotalSum);
                //char c= Console.ReadKey();
                //if ()


            }
            Console.WriteLine("Total={0}", dTotalSum);
            Console.ReadKey();
        }

        private static void ObjectExample()
        {
            object anyValue = "строка";
            Console.WriteLine("anyValue={0}", anyValue);
            anyValue = 777.777;
            Console.WriteLine("anyValue={0}", anyValue);
            Console.ReadLine();
        }

        private static void ParamExample(ref string sFirmName, string sPersonName)
        {
            Console.WriteLine("Использование служебных символов для управления строками");
            Console.WriteLine("{1} работает в \n '{0}', которая является \t основателем компании \n \"Микки Маус и партнеры\" ", sFirmName, sPersonName);

            Console.WriteLine("");
            Console.WriteLine("Изменение значений параметров внутри метода");

            sFirmName = "Microsoft";
            sPersonName = "Bill Gates";

            Console.WriteLine("{0}, {1}", sPersonName, sFirmName);

        }

        private static void Example2()
        {
            //int? i = null; i = null;
            //i = 0;
            int i1 = new int();

            WCons("Собираем строку из кусочков");
            string sOut = "i1=" + Convert.ToString(i1);
            WCons(sOut);
            Console.ReadLine();


            i1 = 50;

            //string s = "Моя новая строка";

            LearnMinMax();

            decimal pay, credit;
            pay = 12.1M;
            credit = pay + 100.000053M;

            Console.WriteLine("credit={0}, pay={1}", credit, pay);

            char c = 'c';

            Console.WriteLine("{0}", char.MaxValue);
            Console.WriteLine("{0}", char.MinValue);

            c = '1';

            WriteChar(c);

            c = '-';

            Console.WriteLine("IsSeparator={0}", char.IsSeparator(c));

            if (!char.IsSeparator(c))
            {
                Console.WriteLine("Это не сепар");
            }

            c = '1';

            Console.WriteLine("Parse={0}", char.Parse("s"));


            Console.WriteLine("GetHashCode={0}", 9.GetHashCode());
            Console.WriteLine("GetType={0}", 9.GetType());
            Console.WriteLine("GetTypeCode={0}", 9.GetTypeCode());

        }

        private static void WriteChar(char c)
        {
            Console.WriteLine("IsDigit={0}", char.IsDigit(c));
        }

        private static void LearnMinMax()
        {
            Console.WriteLine("{0}", int.MaxValue);
            Console.WriteLine("{0}", int.MinValue);

            Console.WriteLine("PositiveInfinity={0}", double.PositiveInfinity);
            Console.WriteLine("NegativeInfinity={0}", double.NegativeInfinity);
            Console.WriteLine("Epsilon={0}", double.Epsilon);
        }

        static void Example1(int i)
        {
            Console.WriteLine("i = {0}", i);
            //Console.ReadLine();
        }

        static void Example()
        {
            //int i = 0;
            //Console.WriteLine("Hello");
            //Console.ReadLine();

            //DoSmth(i);

            Learn1();

            Console.WriteLine("Проверка строк");

            string stringForCoping = "Hello";
            string stringForContainCoping = stringForCoping;

            Console.WriteLine("stringForCoping {0}", stringForCoping);
            Console.WriteLine("stringForContainCoping {0}", stringForContainCoping);

            Console.WriteLine("изменение оригинальной строки");

            stringForCoping = "Hello+cat";

            Console.WriteLine("stringForCoping {0}", stringForCoping);
            Console.WriteLine("stringForContainCoping {0}", stringForContainCoping);
        }

        private static void Learn1()
        {
            Console.WriteLine("Variable declaration");

            int ValueForCoping = 4;
            int ValueForContainCoping = ValueForCoping;

            Console.WriteLine("ValueForCoping {0}", ValueForCoping);
            Console.WriteLine("ValueForContainCoping {0}", ValueForContainCoping);


            Console.WriteLine("Change --ValueForCoping value");

            ValueForCoping = 5;

            Console.WriteLine("ValueForCoping {0}", ValueForCoping);
            Console.WriteLine("ValueForContainCoping {0}", ValueForContainCoping);
        }
    }
}
