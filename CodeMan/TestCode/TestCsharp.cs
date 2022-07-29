// Test C# source code
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{
    class TestCsharp
    {
        public static string externalVar { get; set; } 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World, from C#!");
            Console.WriteLine(externalVar);
            DoStuff("Internal Call to method");
        }

        public static void DoStuff(string text)
        {
            Console.WriteLine(text);
        }
    }
}
