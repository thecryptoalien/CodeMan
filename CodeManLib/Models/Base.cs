using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeManLib.Models
{
    /// <summary>
    /// The Main object for this thing
    /// </summary>
    public class Code
    {
        /// <summary>
        /// Short name of source code maybe even filename
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short Description of what it do
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The source code itself
        /// </summary>
        public string Source { get; set; }

        // classes still not sure yet

        // methods still not sure yet

        // variables still not sure yet

        /// <summary>
        /// The code type e.g. C#, C, C++, Java, etc...
        /// </summary>
        public CodeType Type { get; set; }
    }

    /// <summary>
    /// Type of code - Language
    /// </summary>
    public enum CodeType
    {
        csharp, // C# - Fun times - INPROGRESS
        cpp, // C++ - For more fun times - STARTED
        c, // C - Cause I wanna feel even older
        python, // Python - I guess I should have a 2 and a 3 lol - INPROGRESS
        perl, // Perl - Again I am old inside
        fortran, // Fortran - Well why not
        lisp, // Lisp - Cause Eric suggested it
        cobol, // COBOL - I think I may be loosing it...
        java, // Java - Coffee sucks but I don't mind the code
        prolog, // Prolog - Eric says it's the best
        php, // Php - Casue I can, and I like it
        matlab, // MATLAB - A Bradman suggestion
        vb, // VisualBasic - Cause the compiler was there - INPROGRESS
        js // JavaScript - Well, I guess... - INPROGRESS
    }

    ////////////////////////////////
    ///  The Legend For Status   ///
    ////////////////////////////////
    /// STARTED - What it says   ///
    /// INPROGRESS - Sample works///
    /// DONE - Not sure if true  ///
    ////////////////////////////////
}
