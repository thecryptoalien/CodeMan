using CodeManLib.Helpers;
using CodeManLib.Models;
using CodeManLib.Modules;
using Microsoft.JScript;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CodeMan
{
    class Program
    {
        // List of "WorkingLanguages" -> all possible in order of done and desire lol (not all lister yet)
        private static List<string> WorkingLanguages = new List<string>() { "Python", "CSharp", "VisualBasic", "JavaScript", "cpp", "C", "Java", "Php" }; 
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
                        default:
                            GenericHelp.DebugBox("No Test available for " + language + " yet...", true, ConsoleColor.Red);
                            break;
                    }
                }
            }
            
            // why not c++ and c

            // got c++ done why not java with c++ wrapper lmao

            // what's next fortran or perl

            // why not try cobol

            // All OF THE LANGUAGES LMAO


            // hold up key
            Console.ReadKey();
        }    
        
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
            GenericHelp.DebugBox("Python Tested...",true, ConsoleColor.Green);
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

    }
}
