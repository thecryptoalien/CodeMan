using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeManLib.Helpers
{
    public class GenericHelp
    {
        public static void DebugBox(string dBugMsg, bool newLine, ConsoleColor? consoleColor)
        {
            // set default
            Console.ForegroundColor = ConsoleColor.White;
            // get timestamp formatted
            string TimeStamp = DateTime.Now.ToString("@-MM-dd-yyyy-hh:mm:ss-> ");
            Console.Write("CodeMan" + TimeStamp);
            // check console color
            if (consoleColor != null)
            {
                // set it
                Console.ForegroundColor = (ConsoleColor)consoleColor;
            }
            Console.WriteLine(dBugMsg);
            // check nelLine
            if (newLine)
            {
                // set back to default
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("CodeMan" + TimeStamp + "-------------------------------------------------------------------------------");
            }
        }

    }
}
