using CodeManLib.Models;
using System;

namespace CodeManLib.Modules
{
    /// <summary>
    /// The ReflectionTemplate for ease dow the line ya know
    /// </summary>
    public class PythonReflection : IDisposable
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
        /// The ReflectionTemplate constructor
        /// </summary>
        /// <param name="code">The Code object to reflect on</param>
        public PythonReflection(Code code)
        {
            // Set the code mon
            this.code = code;
        }

        //////////////// All the Methods and shiz ////////////////

        /// <summary>
        /// Do the reflection
        /// </summary>
        public void ReflectOnCode()
        {
            // set the goodies in the code object a.k.a. look at life I mean the code
        }

        /// <summary>
        /// To Get the reflection duh...
        /// </summary>
        public Code Code { get { return code; } }

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
        ~PythonReflection()
        {
            // Jus call Dispose
            Dispose(false);
        }
    }
}
