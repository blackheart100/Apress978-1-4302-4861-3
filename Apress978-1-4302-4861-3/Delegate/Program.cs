using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    class Program
    {
        /* declare a delegate type. */
        delegate int DelegateOfTheCalculator(int a, int b);

        //互斥执行
        static void Main(string[] args)
        {
            //DelegateHandler();
            InternalWorkOfFunc();
        }
        static void DelegateHandler()
        {
            StandardCalculator standardCalculator = new StandardCalculator();
            DelegateOfTheCalculator delegateOfTheCalculator = new DelegateOfTheCalculator(standardCalculator.Add); 
            delegateOfTheCalculator += standardCalculator.Sub; 
            delegateOfTheCalculator -= standardCalculator.Sub;
            /* Execute the Add method */
            Console.WriteLine("Sum of a and b is:{0}", delegateOfTheCalculator(10, 10));
        }
        static void InternalWorkOfFunc()
        {
            ExampleOfFunc exampleOfFunc = new ExampleOfFunc();
            Console.WriteLine("{0}", exampleOfFunc.Addition(exampleOfFunc.Add)); 
            Console.WriteLine("{0}", exampleOfFunc.Addition(() => { return 100 + 100; }));
        }
    }
    public class StandardCalculator { 
        public int Add(int a, int b) { return a + b; } 
        public int Sub(int a, int b) { return a > b ? a - b : 0; } 
        public int Mul(int a, int b) { return a * b; } 
    }
    public class ExampleOfFunc
    {
        public int Addition(Func<int> additionImplementor) { 
            if (additionImplementor != null)                
            return additionImplementor(); return default(int); 
        }
        public int Add() { return 1 + 1; }
    } 
}
