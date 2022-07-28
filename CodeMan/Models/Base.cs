using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMan.Models
{
    public class Code
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }

        // classes

        // methods

        // variables

        public CodeType Type { get; set; }
    }

    /// <summary>
    /// Type of code - Language
    /// </summary>
    public enum CodeType
    {
        csharp,
        cpp,
        c,
        python,
        perl,
        fortran
    }

}
