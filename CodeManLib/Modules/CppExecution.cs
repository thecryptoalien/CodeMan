using CodeManLib.Helpers;
using CodeManLib.Models;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CodeManLib.Modules
{
    /// <summary>
    /// The CppExecution class for running C++
    /// </summary>
    public class CppExecution : IDisposable
    {
        //////////////// All the private parts and the constructor ////////////////

        /// <summary>
        /// Code Object for doing things
        /// </summary>
        private Code code { get; set; }
        public string CppCompilerDir { get; private set; }

        /// <summary>
        /// That dispose boolean
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The CppExecution constructor
        /// </summary>
        /// <param name="code">The Code object to execute</param>
        public CppExecution(Code code, string compilerDir)
        {
            // Set the code mon
            this.code = code;
            this.CppCompilerDir = compilerDir;
        }

        //////////////// All the Methods and shiz ////////////////

        /// <summary>
        /// Run that shiz yo
        /// </summary>
        public void ExecuteCode()
        {
            // do the things to run the code and maybe some other stuff
            // compile the code and test it 
            GenericHelp.DebugBox("Compiling C++ Sample", true, ConsoleColor.Blue);
            Console.ForegroundColor = ConsoleColor.Yellow;

            // write out temp source
            File.WriteAllText("Temp\\TempCpp.cpp", code.Source);
            var prgDir = System.IO.Directory.GetCurrentDirectory();

            // has to do shiz cause microsoft
            var start = new ProcessStartInfo();

            start.FileName = @"cmd.exe";
            start.Arguments = @"/C " + CppCompilerDir + @"\vcvars64.bat && cl /clr:pure " + prgDir + @"\Temp\TempCpp.cpp /o " + prgDir + @"\Temp\TempCpp.dll";

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
                GenericHelp.DebugBox("Executing C++ Sample", true, ConsoleColor.Blue);

                var assemblyBytes = System.IO.File.ReadAllBytes("Temp\\TempCpp.dll");
                Assembly SampleAssembly = Assembly.Load(assemblyBytes);
                Module module = SampleAssembly.GetModules()[0];
                Type mt = null;

                if (module != null)
                {
                    // get type from c++ namespace and class
                    mt = module.GetType("TestCode.TestCpp");
                }

                if (mt != null)
                {
                    // do the things and execute main method
                    var methInfo = mt.GetMethod("Main");
                    dynamic insts = Activator.CreateInstance(methInfo.ReflectedType);
                    insts.setVar("Hello World, from CodeMan!");
                    insts.Main();
                    insts.doStuff("External Call to Method");

                    //// execute doStuff keep here for a lil
                    //var runtimeMethods = module.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                    //var doStuff = runtimeMethods.Where(mi => mi.Name == "TestCode::TestCpp.doStuff").FirstOrDefault();  
                    //doStuff.Invoke(null, new object[] { "External Call to Function" });

                    // need to check a lil into reflection for c++
                    GenericHelp.DebugBox(null, false, null);
                    GenericHelp.DebugBox("Getting Declared Members", false, ConsoleColor.Blue);
                    foreach (var member in mt.GetMembers())
                    {
                        GenericHelp.DebugBox("Name: " + member.Name + " Type: " + member.MemberType, false, ConsoleColor.Green);
                    }
                }

                // remove temp files                
                File.Delete("Temp\\TempCpp.cpp");
                File.Delete("Temp\\TempCpp.dll");
            }
            else
            {
                // compilation error
                GenericHelp.DebugBox("C++ Compilation ERROR!", false, ConsoleColor.Red);
            }

            //GenericHelp.DebugBox(null, false, null);                  
        }

        //////////////// Clean up junk down below ////////////////

        /// <summary>
        /// Public Dispose Yo
        /// </summary>
        public void Dispose()
        {
            // Call that other Dispose
            Dispose(disposing: true);
            // No doit again
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The protected joint
        /// </summary>
        /// <param name="disposing">Is it true or false hmm...</param>
        protected virtual void Dispose(bool disposing)
        {
            // Has this thing already been disposed?
            if (!this.disposed)
            {
                // Check the bool man
                if (disposing)
                {
                    // Dispose any managed stuff                    
                }

                // Dispose the rest man and say you done did it
                code = null;                
                disposed = true;
            }
        }

        /// <summary>
        /// Jus in case finalize it
        /// </summary>
        ~CppExecution()
        {
            // Jus call Dispose
            Dispose(false);
        }
    }
}
