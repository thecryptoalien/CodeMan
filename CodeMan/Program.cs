using CodeManLib.Models;
using CodeManLib.Modules;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMan
{
    class Program
    {
        static void Main(string[] args)
        {
            // check for available compilers
            CheckShizTest("CSharp");
            CheckShizTest("VisualBasic");
            //CheckShizTest("FSharp"); // having troubles
            CheckShizTest("cpp");                  
            CheckShizTest("JavaScript");


            // im crazy but maybe I will start with python
            Console.WriteLine("CodeMan - Started...");
            TestPython();

            // C# is next very integral to make some stuff work going forward
            Console.WriteLine("CodeMan - Next Language...");
            TestCsharp();

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
            Console.WriteLine("Getting Python Sample");
            Console.WriteLine();
            string sourcePy = File.ReadAllText(@"TestCode\TestPython.py");
            Console.WriteLine(sourcePy);
            Console.WriteLine();
            // init code object for testing
            Console.WriteLine("Creating Code Object for test Python execution");
            Code pyCode = new Code { Source = sourcePy };
            // use using to execute code
            Console.WriteLine("Executing Python Sample");
            using (PythonExecution exePy = new PythonExecution(pyCode))
            {
                Console.WriteLine();
                // do the thing 
                exePy.ExecuteCode();
            }
            Console.WriteLine();
            Console.WriteLine("CodeMan - Python Tested...");
            Console.WriteLine();
        }

        public static void TestCsharp()
        {
            Console.WriteLine("Getting C# Sample");
            Console.WriteLine();
            string sourceCs = File.ReadAllText(@"TestCode\TestCsharp.cs");
            Console.WriteLine(sourceCs);
            Console.WriteLine();
            // init code object for testing
            Console.WriteLine("Creating Code Object for test C# execution");
            Code cScode = new Code { Source = sourceCs };
            // use using to execute code
            Console.WriteLine("Executing C# Sample");
            using (CSharpExecution exeCs = new CSharpExecution(cScode))
            {
                Console.WriteLine();
                // do the thing 
                exeCs.ExecuteCode();
            }
            Console.WriteLine();
            Console.WriteLine("CodeMan - C# Tested...");
            Console.WriteLine();
        }

        public static void CheckShizTest(string language)
        {
            CodeDomProvider provider;

            // Check for a provider corresponding to the input language.
            if (CodeDomProvider.IsDefinedLanguage(language))
            {
                provider = CodeDomProvider.CreateProvider(language);

                // Display information about this language provider.

                Console.WriteLine("Language provider:  {0}",
                    provider.ToString());
                Console.WriteLine();
                Console.WriteLine("  Default file extension:  {0}",
                    provider.FileExtension);
                Console.WriteLine();

                // Get the compiler settings for this language.

                CompilerInfo langCompilerInfo = CodeDomProvider.GetCompilerInfo(language);
                CompilerParameters langCompilerConfig = langCompilerInfo.CreateDefaultCompilerParameters();

                Console.WriteLine("  Compiler options:        {0}",
                    langCompilerConfig.CompilerOptions);
                Console.WriteLine("  Compiler warning level:  {0}",
                    langCompilerConfig.WarningLevel);
            }
            else
            {
                // Tell the user that the language provider was not found.
                Console.WriteLine("There is no provider configured for input language \"{0}\".", language);
            }
        }

    }
}
