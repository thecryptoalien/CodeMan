using CodeManLib.Helpers;
using CodeManLib.Models;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;

namespace CodeManLib.Modules
{
    /// <summary>
    /// The ExecutionTemplate for ease dow the line ya know
    /// </summary>
    public class PythonExecution : IDisposable
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
        public PythonExecution(Code code)
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

            // create python engine and set script
            ScriptEngine pythonEngine = IronPython.Hosting.Python.CreateEngine();
            ScriptSource pythonScript = pythonEngine.CreateScriptSourceFromString(code.Source);

            // init scope and object operations
            ScriptScope scope = pythonEngine.CreateScope();
            ObjectOperations ops = pythonEngine.CreateOperations();

            // set var from c#
            scope.SetVariable("externalString", "Hello World, from CodeMan!");

            // execute script
            GenericHelp.DebugBox("Executing Python Sample", true, ConsoleColor.Blue);
            pythonScript.Execute(scope);

            // get function from scope
            var f = scope.GetVariable("doSomething");
            // call python method again from c#
            ops.CreateInstance(f, new object[1] { "External Call to Function" });
            //var __func__ = ops.GetMember(pythonScript, "doSomething"); // for class functions?? for reflection

            GenericHelp.DebugBox(null, false, null);
            GenericHelp.DebugBox("Getting variables in the scope...", false, ConsoleColor.Blue);

            // get list of vars and loop for now
            var pyhtonVars = scope.GetItems();
            foreach (KeyValuePair<string, dynamic> keyPair in pyhtonVars)
            {
                GenericHelp.DebugBox("Key: " + keyPair.Key + " Value: " + keyPair.Value, false, ConsoleColor.Green);
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
        ~PythonExecution()
        {
            // Jus call Dispose
            Dispose(false);
        }
    }
}
