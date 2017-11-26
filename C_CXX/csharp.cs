//------------------------------------------------- 
// StringProperties.cs (c) 2006 by Charles Petzold 
//------------------------------------------------- 
using System; 
using System.Collections;
using System.Diagnostics;
 
namespace CShartTester
{ 
    class BaseTest
    { 
        public int ObjTypeTest()
        {
            int num = 11;
            Object obj = num;
            int num2 = (int)obj;
            num2 = 33;
            num = 22;
            Console.WriteLine("num2 is: " + num2);
            Console.WriteLine("obj is: " + obj);
            Console.WriteLine("num is: " + num);

            string str = "hello";
            Object obj2 = str;
            string str2 = (string)obj2;
            str2 = "world";
            str = "I'm hr";
            Console.WriteLine("str is: " + str);
            Console.WriteLine("obj2 is: " + obj2);
            Console.WriteLine("str2 is: " + str2);

            int[] arr = {23,32,45,12,33};
            Object obj3 = arr;
            int[] arr2 = (int[])obj3;
            arr2[0] = 65;
            Console.WriteLine("arr[0] is: " + arr[0]);
            //Console.WriteLine("obj[0] is: " + obj[0]);
            Console.WriteLine("arr2[0] is: " + arr2[0]);

            return 0;
        } 

        static void ArrayChange(ref int[] arr)
        {
            arr[0] = 66;
            arr = new int[5];
        }

        static void ValueChange(ref int num)
        {
            num = 77;
        }
    }


    class Publisher
    {
        private int count;
        public delegate void NumChangeEventHandler(int count);
        public event NumChangeEventHandler NumberChanged;

        public void DoSomething()
        {
            if(NumberChanged != null)
            {
                count ++;
                NumberChanged(count++);
            }
        }
    }

    class Subscriber
    {
        public void OnNumChanged(int count)
        {
            Console.WriteLine("Subscriber notified: cout = {0}", count);
        }
    }


    public class DaysOfTheWeek: IEnumerable
    {
        private string[] days = {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < days.Length; index++)
            {
                yield return days[index];
            }

        }
    }


    class MainTester
    {
        delegate int NumCount(int n);

        static void Main()
        {
            //BaseTest bt = new BaseTest();
            //bt.ObjTypeTest();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Publisher pb = new Publisher();
            Subscriber sb = new Subscriber();
            pb.NumberChanged += sb.OnNumChanged;
            pb.DoSomething();

            NumCount nc = delegate(int x){ Console.WriteLine("x is {0} ", x); return 0;};
            NumCount nc1 = x => { Console.WriteLine("x1 is {0} ", x); return 0;};
            NumCount nc2 = x => x * x;
            nc(5);
            nc1(10);
            Console.WriteLine("nc2 result is {0}", nc2(20));

            formatNumericalValue(9999);

            DaysOfTheWeek days = new DaysOfTheWeek();
            foreach(string day in days)
                Console.Write(day + " ");
            Console.Write("\n\r");
            watch.Stop();
            Console.WriteLine("watch time is " + watch.ElapsedMilliseconds);
        }

        static void formatNumericalValue(Int32 nValue)
        {
            Console.WriteLine("format output: {0}", nValue);
            Console.WriteLine("cash output: {0:c}", nValue);
            Console.WriteLine("d9 format output: {0:d9}", nValue);
            Console.WriteLine("e format output: {0:e}", nValue);
            Console.WriteLine("f format output: {0:f}", nValue);
            Console.WriteLine("n format output: {0:n3}", nValue);
            Console.WriteLine("x format output: {0:x}", nValue);
            Console.WriteLine("g format output: {0:g}", nValue);
            Console.WriteLine("g1 format output: {0:g1}", nValue);
        }
    }

} 
