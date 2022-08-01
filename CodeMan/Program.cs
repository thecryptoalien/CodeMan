using CodeManLib.Helpers;
using CodeManLib.Models;
using CodeManLib.Modules;
using Microsoft.JScript;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CodeMan
{
    class Program
    {
        // List of "WorkingLanguages" -> all possible in order of done and desire lol (not all lister yet)
        private static List<string> WorkingLanguages = new List<string>() { "Python", "CSharp", "VisualBasic", "JavaScript", "cpp", "C", "Java", "Php" };
        private static string CppCompilerDir = @"T:\Compilers\VC\amd64";
        static void Main(string[] args)
        {
            // Start the thing
            GenericHelp.DebugBox("Main Program Started...", true, ConsoleColor.Green);

            // check for available compilers
            GenericHelp.DebugBox("Checking for available CodeDom/External Providers", true, ConsoleColor.Blue);

            //CodeDomHelp.CheckForProvider("FSharp"); // having troubles lol

            // Check for provider and Test Samples for working languages
            foreach (string language in WorkingLanguages)
            {
                // check for provider
                if (CodeDomHelp.CheckForProvider(language))
                {
                    // provider exists test it mon
                    GenericHelp.DebugBox("Testing " + language + "...", false, ConsoleColor.Blue);
                    switch (language)
                    {
                        case "Python":
                            TestPython();
                            break;
                        case "CSharp":
                            TestCsharp();
                            break;
                        case "VisualBasic":
                            TestVb();
                            break;
                        case "JavaScript":
                            TestJs();
                            break;
                        case "cpp":
                            TestCpp();
                            break;
                        default:
                            GenericHelp.DebugBox("No Test available for " + language + " yet...", true, ConsoleColor.Red);
                            break;
                    }
                }
            }

            // got c++ done why not java with c++ wrapper lmao

            // what's next fortran or perl

            // why not try cobol

            // All OF THE LANGUAGES LMAO


            // hold up key
            Console.ReadKey();
        }


        // make generic Test method man
        // ===================== here rite here =======================

        // Test the Python code yo
        public static void TestPython()
        {
            GenericHelp.DebugBox("Getting Python Sample", true, ConsoleColor.Blue);
            string sourcePy = File.ReadAllText(@"TestCode\TestPython.py");
            GenericHelp.DebugBox("\n" + sourcePy, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test Python execution", false, ConsoleColor.Blue);
            Code pyCode = new Code { Source = sourcePy };
            // use using to execute code            
            using (PythonExecution exePy = new PythonExecution(pyCode))
            {
                // do the thing 
                exePy.ExecuteCode();
            }
            GenericHelp.DebugBox("Python Tested...", true, ConsoleColor.Green);
        }

        // Test the C# code yo
        public static void TestCsharp()
        {
            GenericHelp.DebugBox("Getting C# Sample", true, ConsoleColor.Blue);
            string sourceCs = File.ReadAllText(@"TestCode\TestCsharp.cs");
            GenericHelp.DebugBox("\n" + sourceCs, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test C# execution", false, ConsoleColor.Blue);
            Code cScode = new Code { Source = sourceCs };
            // use using to execute code
            using (CSharpExecution exeCs = new CSharpExecution(cScode))
            {
                // do the thing 
                exeCs.ExecuteCode();
            }
            GenericHelp.DebugBox("C# Tested...", true, ConsoleColor.Green);
        }

        // Test the VisualBasic code yo
        public static void TestVb()
        {
            GenericHelp.DebugBox("Getting VisualBasic Sample", true, ConsoleColor.Blue);
            string sourceVb = File.ReadAllText(@"TestCode\TestVisualBasic.vb");
            GenericHelp.DebugBox("\n" + sourceVb, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test VisualBasic execution", false, ConsoleColor.Blue);
            Code vBcode = new Code { Source = sourceVb };
            // use using to execute code
            using (VbExecution exeVb = new VbExecution(vBcode))
            {
                // do the thing 
                exeVb.ExecuteCode();
            }
            GenericHelp.DebugBox("VisualBasic Tested...", true, ConsoleColor.Green);
        }

        // Test the JavaScript code yo
        public static void TestJs()
        {
            GenericHelp.DebugBox("Getting J(ava)Script Sample", true, ConsoleColor.Blue);
            string sourceJs = File.ReadAllText(@"TestCode\TestJavaScript.js");
            GenericHelp.DebugBox("\n" + sourceJs, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test J(ava)Script execution", false, ConsoleColor.Blue);
            Code jScode = new Code { Source = sourceJs };
            // use using to execute code
            using (JsExecution exeJs = new JsExecution(jScode))
            {
                // do the thing 
                exeJs.ExecuteCode();
            }
            GenericHelp.DebugBox("J(ava)Script Tested...", true, ConsoleColor.Green);
        }


        // Test the C++ code yo
        public static void TestCpp()
        {
            GenericHelp.DebugBox("Getting C++ Sample", true, ConsoleColor.Blue);
            string sourceCpp = File.ReadAllText(@"TestCode\TestCpp.cpp");
            GenericHelp.DebugBox("\n" + sourceCpp, true, ConsoleColor.Green);
            // init code object for testing
            GenericHelp.DebugBox("Creating Code Object for test C++ execution", false, ConsoleColor.Blue);
            Code cpPcode = new Code { Source = sourceCpp };
            //// use using to execute code
            //using (JsExecution exeJs = new JsExecution(cpPcode))
            //{
            //    // do the thing 
            //    exeJs.ExecuteCode();
            //}

            /// for test man
            // compile the code and test it 
            GenericHelp.DebugBox("Compiling C++ Sample", false, ConsoleColor.Blue);
            Console.ForegroundColor = ConsoleColor.Yellow;

            // write out temp source
            File.WriteAllText("Temp\\TempCpp.cpp", cpPcode.Source);
            var prgDir = System.IO.Directory.GetCurrentDirectory();

            // has to do shiz cause microsoft
            var start = new ProcessStartInfo();

            start.FileName = @"cmd.exe";
            start.Arguments = @"/C "+ CppCompilerDir + @"\vcvars64.bat && cl /clr:pure " + prgDir + @"\Temp\TempCpp.cpp /o " + prgDir + @"\Temp\TempCpp.dll";

            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (var process = Process.Start(start))
            {
                // Could be useful to eventually track error
                using (var reader = process?.StandardOutput)
                {
                    Console.WriteLine(reader?.ReadToEnd());
                }
            }
            
            GenericHelp.DebugBox(null, false, null);
            
            // check if new dll exists            
            if (File.Exists("Temp\\TempCpp.dll"))
            {
                // Successful Compile                
                GenericHelp.DebugBox("Compilation Success!", true, ConsoleColor.Green);

                Assembly SampleAssembly = Assembly.LoadFrom("Temp\\TempCpp.dll");
                Module module = SampleAssembly.GetModules()[0];                

                var runtimeType = module.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                var runtimeFields = module.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                GenericHelp.DebugBox("Executing C++ Sample", true, ConsoleColor.Blue);

                // set var from here
                var setVar = runtimeType.Where(mi => mi.Name == "setVar").FirstOrDefault();
                setVar.Invoke(null, new object [] { "Hello World, From CodeMan!" });

                // execute main method
                var mainMethod = runtimeType.Where(mi => mi.Name == "main").FirstOrDefault();
                mainMethod.Invoke(null, null);

                // execute doStuff 
                var doStuff = runtimeType.Where(mi => mi.Name == "doStuff").FirstOrDefault();  
                doStuff.Invoke(null, new object[] { "External Call to Function" });

                 
                // need to check a lil into reflection for c++
                //var types = module.GetType("Module");             


            }
            else
            {
                // compilation error
                GenericHelp.DebugBox("C++ Compilation ERROR!", false, ConsoleColor.Red);
            }


            GenericHelp.DebugBox(null, false, null);
            GenericHelp.DebugBox("C++ Tested...", true, ConsoleColor.Green);
        }


    }
}
