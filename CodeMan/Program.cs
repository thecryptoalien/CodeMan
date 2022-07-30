using CodeManLib.Helpers;
using CodeManLib.Models;
using CodeManLib.Modules;
using Microsoft.JScript;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace CodeMan
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start the thing
            GenericHelp.DebugBox("Main Program Started...", true, ConsoleColor.Green);

            // check for available compilers
            GenericHelp.DebugBox("Checking for available CodeDom providers", true, ConsoleColor.Blue);
            CodeDomHelp.CheckForProvider("CSharp");
            CodeDomHelp.CheckForProvider("VisualBasic");
            //CodeDomHelp.CheckForProvider("FSharp"); // having troubles
            CodeDomHelp.CheckForProvider("cpp");
            CodeDomHelp.CheckForProvider("JavaScript");


            // im crazy but maybe I will start with python
            GenericHelp.DebugBox("Testing Python...", true, ConsoleColor.Blue);
            TestPython();

            // C# is next very integral to make some stuff work going forward
            GenericHelp.DebugBox("Testing C#...", true, ConsoleColor.Blue);
            TestCsharp();

            // Added VisualBasic cause compiler available 
            GenericHelp.DebugBox("Testing VisualBasic...", true, ConsoleColor.Blue);
            TestVb();

            // Added JavaScript cause compiler available 
            GenericHelp.DebugBox("Testing JavaScript...", true, ConsoleColor.Blue);
            TestJs();

            // why not c++ and c

            // got c++ done why not java with c++ wrapper lmao

            // what's next fortran or perl

            // why not try cobol

            // All OF THE LANGUAGES LMAO


            // hold up key
            Console.ReadKey();
        }    
        
        // Test the python code yo
        public static void TestPython()
        {
            GenericHelp.DebugBox("Getting Python Sample", true, ConsoleColor.Blue);            
            string sourcePy = File.ReadAllText(@"TestCode\TestPython.py");
            GenericHelp.DebugBox("\n" + sourcePy, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test Python execution", false, ConsoleColor.Blue);
            Code pyCode = new Code { Source = sourcePy };
            // use using to execute code
            GenericHelp.DebugBox("Executing Python Sample", true, ConsoleColor.Blue);
            using (PythonExecution exePy = new PythonExecution(pyCode))
            {
                // do the thing 
                exePy.ExecuteCode();
            }
            GenericHelp.DebugBox("Python Tested...",true, ConsoleColor.Green);
        }

        public static void TestCsharp()
        {
            GenericHelp.DebugBox("Getting C# Sample", true, ConsoleColor.Blue);
            string sourceCs = File.ReadAllText(@"TestCode\TestCsharp.cs");
            GenericHelp.DebugBox("\n" + sourceCs, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test C# execution", false, ConsoleColor.Blue);
            Code cScode = new Code { Source = sourceCs };
            // use using to execute code
            GenericHelp.DebugBox("Executing C# Sample", true, ConsoleColor.Blue);
            using (CSharpExecution exeCs = new CSharpExecution(cScode))
            {
                // do the thing 
                exeCs.ExecuteCode();
            }
            GenericHelp.DebugBox("C# Tested...", true, ConsoleColor.Green);
        }

        public static void TestVb()
        {
            GenericHelp.DebugBox("Getting VisualBasic Sample", true, ConsoleColor.Blue);
            string sourceVb = File.ReadAllText(@"TestCode\TestVisualBasic.vb");
            GenericHelp.DebugBox("\n" + sourceVb, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test VisualBasic execution", false, ConsoleColor.Blue);
            Code vBcode = new Code { Source = sourceVb };
            // use using to execute code
            GenericHelp.DebugBox("Executing VisualBasic Sample", true, ConsoleColor.Blue);
            using (VbExecution exeCs = new VbExecution(vBcode))
            {
                // do the thing 
                exeCs.ExecuteCode();
            }
            GenericHelp.DebugBox("VisualBasic Tested...", true, ConsoleColor.Green);
        }

        public static void TestJs()
        {
            GenericHelp.DebugBox("Getting JavaScript Sample", true, ConsoleColor.Blue);
            string sourceJs = File.ReadAllText(@"TestCode\TestJavaScript.js");
            GenericHelp.DebugBox("\n" + sourceJs, true, ConsoleColor.Green);
            //// init code object for testing
            //GenericHelp.DebugBox("Creating Code Object for test VisualBasic execution", false, ConsoleColor.Blue);
            //Code vBcode = new Code { Source = sourceVb };
            //// use using to execute code
            //GenericHelp.DebugBox("Executing VisualBasic Sample", true, ConsoleColor.Blue);
            //using (VbExecution exeCs = new VbExecution(vBcode))
            //{
            //    // do the thing 
            //    exeCs.ExecuteCode();
            //}

            // for testing
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("JavaScript");
            //var codeCompiler = codeProvider.CreateCompiler();
            var parameters = new CompilerParameters { GenerateInMemory = true, GenerateExecutable = true, TreatWarningsAsErrors = false };
            try
            {
                var results = codeProvider.CompileAssemblyFromSource(parameters, sourceJs);
                if (results.Errors.HasErrors)
                {
                    Console.WriteLine("shit");
                    foreach(var error in results.Errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                }
                var assembly = results.CompiledAssembly;
                Module module = results.CompiledAssembly.GetModules()[0];
                dynamic instance = Activator.CreateInstance(assembly.GetType("TestCode.TestJs"));
                var mt = module.GetType("TestCode.TestJs");

                var prop = mt.GetField("externalVar");

                //var mtt = TypedReference.MakeTypedReference(mt, new FieldInfo[1] { prop });

                //prop.SetValue(mt, "Hello World, from CodeMan!");

                
            }
            catch(Exception ex)
            {

            }



            GenericHelp.DebugBox("JavaScript Tested...", true, ConsoleColor.Green);
        }

    }
}
