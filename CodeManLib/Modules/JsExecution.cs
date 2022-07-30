using CodeManLib.Helpers;
using CodeManLib.Models;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace CodeManLib.Modules
{
    /// <summary>
    /// The JsExecution class for running JavaScript
    /// </summary>
    public class JsExecution : IDisposable
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
        /// The JsExecution constructor
        /// </summary>
        /// <param name="code">The Code object to execute</param>
        public JsExecution(Code code)
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
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("JavaScript");
            GenericHelp.DebugBox("Compiling JavaScript Sample", false, ConsoleColor.Blue);
            var parameters = new CompilerParameters { GenerateInMemory = true, GenerateExecutable = true, TreatWarningsAsErrors = false };
            try
            {
                var results = codeProvider.CompileAssemblyFromSource(parameters, code.Source);
                if (results.Errors.HasErrors)
                {
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        GenericHelp.DebugBox("Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText, false, ConsoleColor.Red);
                    }
                }
                else
                {
                    // Successful Compile                
                    GenericHelp.DebugBox("Compilation Success!", true, ConsoleColor.Green);
                    var assembly = results.CompiledAssembly;
                    Module module = assembly.GetModules()[0];
                    Type mt = null;

                    // Make instance of class and execute
                    GenericHelp.DebugBox("Executing J(ava)Script Sample", true, ConsoleColor.Blue);
                    dynamic instance = Activator.CreateInstance(assembly.GetType("TestCode.TestJs"));
                    instance.externalVar = "Hello World, from CodeMan!";
                    instance.Main();
                    instance.DoStuff("External Call to Function");

                    if (module != null)
                    {
                        mt = module.GetType("TestCode.TestJs");
                    }

                    if (mt != null)
                    {
                        // Get members and display
                        GenericHelp.DebugBox(null, false, null);
                        GenericHelp.DebugBox("Getting Declared Members", false, ConsoleColor.Blue);
                        foreach (var member in mt.GetMembers())
                        {
                            GenericHelp.DebugBox("Name: " + member.Name + " Type: " + member.MemberType, false, ConsoleColor.Green);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GenericHelp.DebugBox("Exception:\n" + ex.ToString(), true, ConsoleColor.Red);
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
        ~JsExecution()
        {
            // Jus call Dispose
            Dispose(false);
        }
    }
}
