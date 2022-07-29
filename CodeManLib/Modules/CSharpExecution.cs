using CodeManLib.Models;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace CodeManLib.Modules
{
    /// <summary>
    /// The ExecutionTemplate for ease dow the line ya know
    /// </summary>
    public class CSharpExecution : IDisposable
    {
        //////////////// All the private parts and the constructor ////////////////

        /// <summary>
        /// Code Object for doing things
        /// </summary>
        private Code code { get; set; }

        /// <summary>
        /// That dispose boolean
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The ExecutionTemplate constructor
        /// </summary>
        /// <param name="code">The Code object to execute</param>
        public CSharpExecution(Code code)
        {
            // Set the code mon
            this.code = code;
        }

        //////////////// All the Methods and shiz ////////////////

        /// <summary>
        /// Run that shiz yo
        /// </summary>
        public void ExecuteCode()
        {
            // do the things to run the code and maybe some other stuff
            // compile the code and test it 
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");


            Console.WriteLine("Compiling C# Sample");
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            string[] references = { "System.dll", "System.Linq.dll", "System.Threading.Tasks.dll" };
            parameters.ReferencedAssemblies.AddRange(references);

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code.Source);

            if (results.Errors.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (CompilerError CompErr in results.Errors)
                {
                    Console.WriteLine("Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                // Successful Compile                
                Console.WriteLine("Compilation Success!");                
                Console.WriteLine();
                Module module = results.CompiledAssembly.GetModules()[0];
                Type mt = null;
                MethodInfo methInfo = null;
                MethodInfo methInfo2 = null;


                if (module != null)
                {
                    mt = module.GetType("TestCode.TestCsharp");
                }

                if (mt != null)
                {
                    var prop = mt.GetProperty("externalVar");
                    prop.SetValue(mt, "Hello World, from CodeMan!");

                    methInfo = mt.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                    if (methInfo != null)
                    {
                        try
                        {
                            methInfo.Invoke(null, new object[] { null });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }


                    methInfo2 = mt.GetMethod("DoStuff");
                    if (methInfo2 != null)
                    {
                        try
                        {
                            methInfo2.Invoke(null, new object[] { "External Call to Method" });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Declared Members");
                    foreach(var member in mt.GetMembers())
                    {
                        Console.WriteLine(member.Name + " " + member.MemberType);
                    }


                }
            }
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
        ~CSharpExecution()
        {
            // Jus call Dispose
            Dispose(false);
        }
    }
}
