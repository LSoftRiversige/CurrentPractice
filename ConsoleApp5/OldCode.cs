
//class PositiveEnumerator : IEnumerator, IEnumerable
//{
//    int[] array;
//    int currentIndex;

//    public PositiveEnumerator(int[] array)
//    {
//        this.array = array;
//        currentIndex = -1;
//    }

//    public object Current
//    {
//        get
//        {
//            if (currentIndex == -1) throw new Exception("not started");
//            if (currentIndex >= array.Length) throw new Exception("out of range");
//            return array[currentIndex];
//        }
//    }

//    public bool MoveNext()
//    {
//        if (currentIndex >= array.Length - 1)
//        {
//            return false;
//        }
//        for (int i = currentIndex + 1; i < array.Length; i++)
//        {
//            if (array[i] > 0)
//            {
//                currentIndex = i;
//                return currentIndex < array.Length;
//            }
//        }
//        return false;
//    }

//    public void Reset()
//    {
//        currentIndex = -1;
//    }

//    public IEnumerator GetEnumerator()
//    {
//        return this;
//    }
//}


//class PositiveEnumerator : IEnumerator
//{
//    int[] array;
//    int current;

//    public PositiveEnumerator(int[] array)
//    {
//        this.array = array;
//    }

//    public object Current
//    {
//        get
//        {
//            if (current >= array.Length) throw new Exception("out of range (more Length)");
//            if (current < 0) throw new Exception("out of range (less 0)");
//            return array[current];
//        }
//    }

//    public bool MoveNext()
//    {
//        for (int i = current; i < array.Length; i++)
//        {
//            if (array[i] > 0)
//            {
//                current = i;
//                return true;
//            }
//        }
//        return false;
//    }

//    public void Reset()
//    {
//        current = -1;
//    }
//}

//class MyEvenEnumerable : IEnumerable
//{
//    readonly int[] array;

//    public MyEvenEnumerable(int[] array)
//    {
//        this.array = array;
//    }

//    public IEnumerator GetEnumerator()
//    {
//        foreach (var item in array)
//        {
//            if (item % 2 == 0) yield return item;
//        }

//    }
//}




//Console.WriteLine("Press any key...");
//Console.ReadKey();
//List<int> lst = new List<int> { 1, 2, 3, 4, 5,6 , 7, 8 };
//int capacity=lst.Capacity;
//for (int i = 0; i < 100000000; i++)
//{
//    lst.Add(1);
//    if (capacity != lst.Capacity)
//    {
//        Console.WriteLine($"{lst.Capacity}");
//        capacity = lst.Capacity;
//    }

//}
//Console.WriteLine($"Удаление {lst.Capacity}");

//lst.TrimExcess();

//Console.WriteLine($" trim {lst.Capacity}");

//Console.WriteLine("Press any key...");
//Console.ReadKey();

//for (int i = 0; i < 1000; i++)
//{
//    lst.RemoveAt(0);
//    Console.WriteLine($"Удалил первый элемент");
//    Console.WriteLine($"{lst.Capacity}");
//    if (capacity != lst.Capacity)
//    {
//        Console.WriteLine($"{lst.Capacity}");
//        capacity = lst.Capacity;
//    }

//}


//Console.WriteLine("Press any key...");
//Console.ReadKey();

//PositiveEnumerator en = new PositiveEnumerator(new int[] { 1, -1, 2, -4, -6, 45, -2, -5, -4, 0, 2, 1 });

//foreach (var positiveInt in en)
//{
//    Console.WriteLine($"{positiveInt}");
//}

//SequenceN sq = new SequenceN(12);

//while (sq.MoveNext())
//{
//    Console.WriteLine(sq.Current);
//}

//sq.Reset();

//foreach (var ss in sq)
//{
//    Console.WriteLine($"{ss}");
//}

//    var test = new ThisTest(new int[] { 1, 2, 3, 4, 5, 6,7 ,8 , 9 , 0});


//    Console.WriteLine(test[0]);
//    Console.WriteLine(test[1]);
//    Console.WriteLine(test[2]);
//    Console.WriteLine(test[3]);


//    var enumer = new YieldTest();
//    foreach (var item in enumer)
//    {
//        Console.WriteLine(item);
//    }
//    Console.WriteLine("Press any key...");
//    Console.ReadKey();

//    var factorial = new Factorial();

//    IEnumerable<int> factSel = factorial.Where(p => p > 2000);

//    foreach (var item in factSel)
//    {
//        Console.WriteLine($"{item}");
//    }

//    int counter = 0;
//    foreach (var fa in factorial)
//    {

//        Console.WriteLine($"{counter++}!={fa}");
//        //Console.WriteLine("Press any key...");
//        //Console.ReadKey();
//    }

//    Console.WriteLine("Press any key...");
//    Console.ReadKey();

//    var fibo = new Fibonacci();

//    foreach (var f in fibo)
//    {
//        Console.WriteLine(f);
//        //Console.WriteLine("Press any key...");
//        //Console.ReadKey();
//    }

//    Console.WriteLine("Press any key...");
//    Console.ReadKey();

//    //int i = 3;
//    //Console.WriteLine($"{i++ + ++i}"); //3+5;

//    //Console.WriteLine($"{IsPolindrom(1)}");
//    //Console.WriteLine($"{IsPolindrom(11)}");
//    //Console.WriteLine($"{IsPolindrom(111)}");
//    //Console.WriteLine($"{IsPolindrom(2222)}");
//    //Console.WriteLine($"{IsPolindrom(2442)}");

//    int[] a = { 5 };

//    Console.WriteLine($"{MinimalIntegerNotIn(a)}");

//    Console.WriteLine("Press any key...");
//    Console.ReadKey();
//}

//    public static bool IsPolindrom(int a)
//{
//    string s = a.ToString();
//    IEnumerable<char> rev = s.Reverse();
//    return s.SequenceEqual(rev);
//}

//public static bool HasDuplicates(string s)
//{
//    return s.Distinct().Count() < s.Length;
//}

////Напишите функцию MinimalIntegerNotIn, которая принимает массив A и возвращает минимальное положительное число(больше 0) которого нет в А.
////Например, для А = [1, 3, 6, 4, 1, 2] функция должна возвратить 5.
////Для A = [1, 2, 3] функция возвращает 4.
////Для A = [−1, −3], функция возвращает 1.
////Напишите эффективный (ну ладно, хоть какой-то) алгоритм удовлетворяющий следующие правила:
////N - целое число от 1 до 100,000;
////каждый элемент массива А - число в диапазоне от −1,000,000 до 1,000,000
//static int MinimalIntegerNotIn(int[] a)
//{
//    int max = a.Max() + 1;
//    if (max <= 0) max = 1;

//    int min = 1;

//    for (int i = 1; i <= max; i++)
//    {
//        if (!a.Contains(i) && i > 0)
//        {
//            return i;
//        }
//    }
//    return 0;