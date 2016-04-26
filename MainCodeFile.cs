
using System;
using System.Threading; // delegate void TimerCallback(Object o); gibi....
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;   // For template collection classes

namespace CSD
{
    class App
    {
        public static void Main()
        {
            Sample<string, int> s;
        }
    }

    class Sample<T, K>
        where T : class     // Primary constraint implies T is a reference type
        where K : struct, IDisposable, IComparable  // Secondary constraints are interfaces
                            // Note third constraint is declaration of default constructor using new() word
    {
        private T m_a;
        private K m_b;

        public Sample()
        {
            m_a = null;
        }
    }
}


/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            int[] a = { 1, 4, 3, 56 };
            double[] d = { 3.14, 47.8 };

            int imax;
            double dmax;

            imax = Sample.GetMax<int>(a);
            dmax = Sample.GetMax<double>(d);

            imax = Sample.GetMax(a);    // bu da geçerli
            dmax = Sample.GetMax(d);

            Console.WriteLine(imax);
            Console.WriteLine(dmax);
        }
    }

    class Sample
    {
        public static T GetMax<T>(T[] a) where T : IComparable
        {
            T max = a[0];
            for (int i = 1; i < a.Length; ++i)
                if (max.CompareTo(a[i]) < 0)
                    max = a[i];
            return max;
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Sample<int> s = new Sample<int>();
        }
    }

    interface IX<T>
    {
        void Foo(T a);
    }

    class Sample<T> : IX<T>
    {
        public void Foo(T a)
        {
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Sample s;
            Console.WriteLine("one");
            s = new Sample();
            Console.WriteLine(Sample.A);
        }
    }

    class Sample 
    {
        private static int m_a;

        public Sample()
        {
            Console.WriteLine("instance constructor");
        }

        static Sample()
        {
            Console.WriteLine("static constructor");
            m_a = 100;
        }

        public static int A
        {
            get { return Sample.m_a; }
            set { Sample.m_a = value; }
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Number a = new Number(3), b = new Number(7), c = new Number(5);
            if (b - a > c)
                Console.WriteLine("evet");
            else
                Console.WriteLine("hayır");
        }
    }

    class Number
    {
        private double m_val;

        public Number()
        { }

        public Number(double val)
        {
            m_val = val;
        }

        public override string ToString()
        {
            return m_val.ToString();
        }

        public static Number operator +(Number x, Number y)
        {
            Number result = new Number();
            result.m_val = x.m_val + y.m_val;
            return result;
        }

        public static Number operator -(Number x, Number y)
        {
            Number result = new Number();
            result.m_val = x.m_val - y.m_val;
            return result;
        }

        public static Number operator *(Number x, Number y)
        {
            Number result = new Number();
            result.m_val = x.m_val * y.m_val;
            return result;
        }

        public static Number operator /(Number x, Number y)
        {
            Number result = new Number();
            result.m_val = x.m_val / y.m_val;
            return result;
        }

        public static bool operator >(Number x, Number y)
        {
            return x.m_val > y.m_val;
        }

        public static bool operator <(Number x, Number y)
        {
            return x.m_val < y.m_val;
        }

        public static bool operator >=(Number x, Number y)
        {
            return x.m_val >= y.m_val;
        }

        public static bool operator <=(Number x, Number y)
        {
            return x.m_val <= y.m_val;
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Complex x = new Complex(3, 2);
            Complex y = new Complex(2, 5);
            Complex z = new Complex(7, 1);
            Complex result;

            result = x + y - z;     // result = x + y
            Console.WriteLine(result);
            Console.WriteLine(x * y * z);
        }
    }

    class Complex
    {
        private double m_real;
        private double m_imag;

        public Complex()
        {
        }

        public Complex(double real, double imag)
        {
            m_real = real;
            m_imag = imag;
        }

        public override string ToString()
        {
            return string.Format("{0}+{1}i", m_real, m_imag);
        }

        public static Complex Add(Complex x, Complex y)
        {
            Complex result = new Complex();

            result.m_real = x.m_real + y.m_real;
            result.m_imag = x.m_imag + y.m_imag;

            return result;
        }

        public static Complex operator+ (Complex x, Complex y)      // public static olması gerekiyor!
        {
            Complex result = new Complex();

            result.m_real = x.m_real + y.m_real;
            result.m_imag = x.m_imag + y.m_imag;

            return result;
        }

        public static Complex operator- (Complex x, Complex y)      // public static olması gerekiyor!
        {
            Complex result = new Complex();

            result.m_real = x.m_real - y.m_real;
            result.m_imag = x.m_imag - y.m_imag;

            return result;
        }

        public static Complex operator* (Complex x, Complex y)      // public static olması gerekiyor!
        {
            Complex result = new Complex();

            result.m_real = x.m_real * y.m_real - x.m_imag * y.m_imag;
            result.m_imag = x.m_real * y.m_imag + x.m_imag * y.m_real;

            return result;
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Sample s = new Sample();
            Sample k = new Sample();
        }
    }

    class Sample
    {
        private int m_a;

        public Sample()
        {
            m_a = 10;
            Console.WriteLine("Constructor");
        }

        ~Sample()
        {
            Console.WriteLine("Destructor");
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Sample s = new Sample();
            s.Foo();
            s.Bar();
        }
    }

    partial class Sample
    {
        private int m_a;
        public void Foo()
        {
        }
    }

    partial class Sample
    {
        public void Bar()
        {
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream("test.text", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs, Encoding.UTF8);

                sw.WriteLine("Bu bir denemedir. Yumaşak Ğ!");

                for (int i = 0; i < 10; ++i)
                {
                    sw.WriteLine(i);

                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            FileStream fs=null;
            BinaryReader bw = null;

            try
            {
                fs = new FileStream("test.dat", FileMode.Open, FileAccess.Read);
                bw = new BinaryReader(fs);
                for (int i = 0; i < 100; i++)
                    Console.Write( bw.ReadInt32() + " ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }

        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            FileStream fs;
            BinaryWriter bw = null;

            try
            {
                fs = new FileStream("test.dat", FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                for (int i = 0; i < 100; i++)
                    bw.Write(i);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }

        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Console.WriteLine(Environment.CurrentDirectory);
            Environment.CurrentDirectory = "c:/windows";
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine(File.Exists("c:/windows/notepad.exe") ? "Var" : "Yok");
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            ArrayList al = new ArrayList();

            for(int i=0;i<10;++i)
                al.Add(i);

            ArrayList al2 = (ArrayList)al.Clone();

            foreach (int x in al2)
                Console.Write("{0} ", x);
            Console.WriteLine();
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Person per1 = new Person("Kaan Arslan", 123);
            Person per2 = (Person)per1.Clone();
            Console.WriteLine(per1.ToString());
            Console.WriteLine(per2.ToString());
        }
    }

    class Person : ICloneable
    {
        private string m_name;
        private int m_no;

        public Person() { }

        public Person(string name, int no)
        {
            m_name = name;
            m_no = no;
        }

        public override string ToString()
        {
            return m_name + " " + m_no;
        }

        public object Clone()
        {
            Person per = new Person();
            per.m_name = m_name;
            per.m_no = m_no;

            return per;
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            IX ix;
            IY iy;
            Sample s = new Sample();
            ix = s;
            iy = (IY)ix;
            iy.Bar();

            ArrayList al = new ArrayList();
            al.Add(new Sample());

            ArrayList a2 = new ArrayList();
            
            foreach ( int a in a2 )
            {
            }
        }
    }

    interface IX
    {
        void Foo();
    }

    interface IY
    {
        void Bar();
    }

    class Sample : IX
    {
        public void Foo()
        {
            Console.WriteLine("sample.foo");
        }

        public void Bar()
        {
            Console.WriteLine("sample.bar");
        }
    }

    class Mample : IX
    {
        public void Foo()
        {
            Console.WriteLine("mample.foo");
        }

        public void Bar()
        {
            Console.WriteLine("mample.bar");
        }
    }
}

/*
namespace CSD
{
    class APP
    {
        public static void Main()
        {
            EventTest et = new EventTest();
            et.E += new Proc(Sample.Foo);
            et.Fire();
        }
    }

    class EventTest
    {
        // private Proc m_e;
        public event Proc E;
        //{
        //    add
        //    {
        //        m_e += value;
        //    }
        //    remove
        //    {
        //        m_e -= value;
        //    }
        //}
        public void Fire()
        {
            E();
        }
    }

    class Sample
    {
        public static void Foo()
        {

            Console.WriteLine("FOO");
        }
    }

    delegate void Proc();
}

/*
namespace CSD
{
    delegate void Proc();

    class App
    {
        public static void Main()
        {
            Proc d = null;
            d += new Proc(Sample.Foo);
            d += new Proc(Sample.Bar);
            
            d();

            Proc[] procs = new Proc[] { new Proc(Sample.Foo), new Proc(Sample.Bar), new Proc(Sample.Tar) };

            foreach (Proc p in procs)
                p();
        }
    }

    class Sample
    {
        public static void Foo()
        {
            Console.WriteLine("Foo");
        }
        public static void Bar()
        {
            Console.WriteLine("Bar");
        }
        public static void Tar()
        {
            Console.WriteLine("Tar");
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Timer timer = new Timer(new TimerCallback(Sample.Print), ".", 2000, 1000);
            Console.ReadLine();
        }
    }

    class Sample
    {
        public static void Print(object o)
        {
            string s = (string)o;
            Console.Write(s);
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            FileSource fs = new FileSource();
            StringSource ss = new StringSource();
            Parser parser = new Parser(ss);
            parser.DoParse();
        }
    }

    class Source
    {
        public virtual char GetChar()
        { return ' '; }
    }

    class FileSource : Source
    {
        public override char GetChar()
        { return 'f'; }
    }

    class StringSource : Source
    {
        public override char GetChar()
        { return 's'; }
    }

    class Parser
    {
        private Source m_source;

        public Parser(Source source)
        {
            m_source = source;
        }

        public void DoParse()
        {
            char ch;
            ch = m_source.GetChar();
            Console.WriteLine(ch);
            ch = m_source.GetChar();
            Console.WriteLine(ch);
            ch = m_source.GetChar();
            Console.WriteLine(ch);
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            object o = new Sample();
            Console.WriteLine(o.ToString());
            Console.WriteLine(o.GetType().ToString());     // GetType is not virtual

            A a;

            a = new A();
            a.Foo(123);

            a = new B();
            a.Foo(123);

            a = new C();
            a.Foo(123);

            a = new D();
            a.Foo(123);

            int b = 123;
            o = b;  // boxing conversion from value type to reference type

            Console.WriteLine(o.ToString());

            System.Collections.ArrayList al = new System.Collections.ArrayList();
            al.Add(123);
            al.Add(23.56);
            al.Add(new Sample());
            al.Add(DateTime.Today);

            foreach (object o2 in al)
            {
                string s = o2.ToString();
                Console.WriteLine(s);
            }
        }
    }

    class Sample
    {
        public override string ToString()
        {
            return "this is a sample";
        }
    }

    class A
    {
        public virtual void Foo(int a)
        {
            Console.WriteLine("A.Foo");
        }
        //...
    }

    class B : A
    {
        public override void Foo(int a)
        {
            Console.WriteLine("B.Foo");
        }
        //...
    }

    class C : A
    {
        //public override void Foo(int a)
        //{
        //    Console.WriteLine("C.Foo");
        //}
        //...
    }

    class D : C
    {
        public override void Foo(int a)
        {
            Console.WriteLine("D.Foo");
        }
        //...
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            B b = new B();
            b.m_val = 10;
            b.Foo();
            b.Foo(12);

            A a = new A();
            a.m_val = 20;
        }
    }

    class A
    {
        public int m_val;

        public void Foo()
        {
        }
    }

    class B : A
    {
        new public int m_val;

        public void Foo(int a)
        {
        }
    }

}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            int a = 123, b;
            object o;

            o = a;
            b = (int)o;
            Console.WriteLine(b);

            object q = 234;
            object[] objs = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < objs.Length; ++i)
            {
                int val = (int)objs[i];
                Console.Write("{0} ", val);
            }
            Console.WriteLine();
            foreach (int x in objs)         // foreach tür dönüştürme operatör her durumda cağrıyormuş
                Console.Write("{0} ", x);
            Console.WriteLine();


        }
    }

    class A
    {
        public int m_a;
    }

    class B : A
    {
        public int m_b;
    }

    class C : B
    {
        public int m_c;
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            B b = new B();
            A a;

            b.m_a = 10;
            b.m_b = 20;
            a = b;
            Console.WriteLine(a.m_a);
            a.m_a = 30;
            Console.WriteLine("{0} {1}", b.m_a, b.m_b);
        }
    }

    class A
    {
        public int m_a;
    }

    class B : A
    {
        public int m_b;
    }

    class C : B
    {
    
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            B b = new B(10,20);
            Console.WriteLine(b.Val+" "+b.ValB);
        }
    }

    class A
    {
        private int m_val;

        public A()
            : this(30)
        {
            Console.WriteLine("A default constructor");
        }

        public A(int a)
        {
            Console.WriteLine("A int constructor");
            m_val = a;
        }

        public int Val
        {
            get { return m_val; }
            set { m_val = value; }
        }
    }

    class B : A
    {
        private int m_valB;

        public int ValB
        {
            get { return m_valB; }
            set { m_valB = value; }
        }

        public B(int a, int b)
            : base(a)
        {
            Console.WriteLine("B int int constructor");
            ValB = b;
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Direction d;
            d = Direction.Left;
            Console.WriteLine(d + "\t" + (int)d + "\t" + (Direction)3);

            Direction d1 = Direction.Down;
            Direction d2 = Direction.Up;
            if (d1 > d2)
                Console.WriteLine("d1>d2");
            else if (d1 < d2)
                Console.WriteLine("d1<d2");
            else
                Console.WriteLine("d1==d2");

            Move(Direction.Right);
            Move(Direction.Left);
        }

        public static void Move(Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    Console.WriteLine("Move Up"); break;
                case Direction.Down:
                    Console.WriteLine("Move Down"); break;
                case Direction.Right:
                    Console.WriteLine("Move Right"); break;
                case Direction.Left:
                    Console.WriteLine("Move Left"); break;
            }
        }
    }

    enum Direction
    {
        Up, Right = 2, Down, Left
    }

    enum Day
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            DateTime dt = new DateTime(1990, 12, 23, 13, 5, 59, 999);
            Console.WriteLine(dt.ToString());
            Console.WriteLine(dt.Millisecond);

            DateTime dt2 = dt.AddHours(15);
            Console.WriteLine(dt2.ToString());

        }
    }
}

// class değişkeni referans tutmasına karşın struct değişkeni value değerdir. Stack de yaratılıyor. Heap de değil.

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Test t;     // bu stack de yaratılıyor

            t = new Test(10, 20);   // new komutu stack de geçici nesne yaratıyor ve bu satır sonrası yok ediliyor! 

            t.Disp();
        }
    }

    struct Test
    {
        public Test(int a, int b)
        {
            m_a = a;
            m_b = b;
        }

        private int m_a; public int A { get { return m_a; } set { m_a = value; } }
        private int m_b; public int B { get { return m_b; } set { m_b = value; } }

        public void Disp()
        {
            Console.WriteLine("{0}, {1}", m_a, B);
        }
    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            int[] a = { 1, 2, 3, 4, 5 };

            foreach (int x in a)
                Console.WriteLine(x);

            foreach (string file in Directory.GetFiles(@"c:\windows"))
            {
                Console.WriteLine(file);
            }
        }
    }
}

/*

namespace CSD
{
    class App
    {
        public static void Main()
        {
            Date date = new Date();

            date.Day = 10;      // uses property Day
            date.SetMonth(12);
            date.SetYear(2012);

            Console.WriteLine("{0}/{1}/{2}", date.Day, date.GetMonth(), date.GetYear());

            Date.A = 1000;
            Console.WriteLine(Date.A);
        }
    }

    class Date
    {
        private int m_day;
        private int m_month;
        private int m_year;

        private static int m_a;

        public static int A         // static property
        {
            set { m_a = value; }
            get { return m_a; }
        }

        public int Day
        {
            set { m_day = value; }
            get { return m_day; }
        }

        public int GetMonth()
        {
            return m_month;
        }

        public int GetYear()
        {
            return m_year;
        }

        public void SetMonth(int month)
        {
            m_month = month;
        }

        public void SetYear(int year)
        {
            m_year = year;
        }

    }
}

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Sample s = new Sample();
            int result;
            s.A = 10;
            result = s.A + 20;
            Console.WriteLine(result);
        }
    }

    class Sample
    {
        private int m_a;

        public int A
        {
            get
            {
                return m_a;
            }
            set
            {
                m_a = value;  // value is a keyword 
            }
        }

    }
}
*/

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            Date date = new Date();

            date.SetDay(10);
            date.SetMonth(12);
            date.SetYear(2012);

            Console.WriteLine("{0}/{1}/{2}", date.GetDay(), date.GetMonth(), date.GetYear());
        }
    }

    class Date
    {
        private int m_day;
        private int m_month;
        private int m_year;

        public int GetDay()
        {
            return m_day;
        }

        public int GetMonth()
        {
            return m_month;
        }

        public int GetYear()
        {
            return m_year;
        }

        public void SetDay(int day)
        {
            m_day = day;
        }

        public void SetMonth(int month)
        {
            m_month=month;
        }

        public void SetYear(int year)
        {
            m_year=year;
        }

    }
}
*/

/*
namespace CSD
{
    class App
    {
        public static void Main()
        {
            string s;
            int val;

            for (; ; )
            {
                val = int.Parse(Console.ReadLine());
                if (val == -1) break;

                s = NumberToText3Digit(val);
                Console.WriteLine(s);
            }

            string[] buyuk = new string[] { "", "bin", "milyon", "milyar", "trilyon", "katrilyar", "kintilyar" };
            int[] triplets = new int[7];
        }

        public static string NumberToText3Digit(long val)
        {
            string[] ones = { "", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
            string[] tens = { "", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };
            string result = "";

            if (val == 0) return "sıfır";

            int one = (int)(val % 10);
            val /= 10;
            int ten = (int)(val % 10);
            val /= 10;
            int hundred = (int)(val % 10);

            if (hundred == 1)
            {
                result += "yuz" + " ";
            }
            else if (hundred > 1)
            {
                result += ones[hundred] + " " + "yuz" + " ";
            }

            result += ten != 0 ? tens[ten] + " " : "";

            result += one != 0 ? ones[one] + " " : "";

            return result;
        }
    }
}
*/
