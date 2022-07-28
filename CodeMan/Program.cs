using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMan
{
    class Program
    {
        static void Main(string[] args)
        {
            // im crazy but maybe I will start with python
            TempPythonMethod(); // works so far
            // why not c++ and c

            // got c++ done why not java with c++ wrapper lmao

            // what's next fortran or perl

            // why not try cobol

            // All OF THE LANGUAGES LMAO


            // hold up key
            Console.ReadKey();
        }

        // test python method
        public static void TempPythonMethod()
        {
            // create python engine and set script
            Microsoft.Scripting.Hosting.ScriptEngine pythonEngine = IronPython.Hosting.Python.CreateEngine();
            Microsoft.Scripting.Hosting.ScriptSource pythonScript = pythonEngine.CreateScriptSourceFromString(
                "def doSomething(stuff):\n" +
                "     print stuff\n" +
                "helloWorldString = 'Hello World!'\n" +
                "print helloWorldString\n" +
                "print externalString\n" +
                "doSomething('things')"
                );

            // init scope and object operations
            Microsoft.Scripting.Hosting.ScriptScope scope = pythonEngine.CreateScope();
            Microsoft.Scripting.Hosting.ObjectOperations ops = pythonEngine.CreateOperations();

            // set var from c#
            scope.SetVariable("externalString", "CodeMan here...");

            // execute script
            pythonScript.Execute(scope);

            // get function from scope
            var f = scope.GetVariable("doSomething");
            // call python method again from c#
            ops.CreateInstance(f, new object[1] { "Junky" });
            //var __func__ = ops.GetMember(f, "__func__"); // for class functions?? for reflection

            System.Console.Out.WriteLine();
            System.Console.Out.WriteLine("Variables in the scope:");            
            System.Console.Out.WriteLine();

            // get list of vars
            var pyhtonVars = scope.GetItems();

            foreach(KeyValuePair<string,dynamic> keyPair in pyhtonVars)
            {
                System.Console.Out.WriteLine(keyPair.Key + " : " + keyPair.Value);
            }
            

            
        }
    }
}
