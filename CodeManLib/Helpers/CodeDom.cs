using System;
using System.CodeDom.Compiler;

namespace CodeManLib.Helpers
{
    /// <summary>
    /// CodeDom Helpers 
    /// </summary>
    public class CodeDomHelp
    {
        public static bool CheckForProvider(string language)
        {
            // Init code dom provider
            CodeDomProvider provider;
            GenericHelp.DebugBox("Checking If CodeDom/External Provider exists for " + language, false, ConsoleColor.Blue);

            // Check to see if It exists
            if (CodeDomProvider.IsDefinedLanguage(language))
            {
                // check for hybrid languages
                string extPro = string.Empty;
                string extComp = string.Empty;
                switch (language)
                {
                    case "cpp":
                        extPro = "/External";
                        extComp = "/MSCV"; 
                        break;
                }


                // Create the CodeDom provider
                provider = CodeDomProvider.CreateProvider(language);

                // Display stuff about the language provider.
                GenericHelp.DebugBox("CodeDom" + extPro + " Provider found!", false, ConsoleColor.Green);
                GenericHelp.DebugBox("Language provider: " + provider.ToString() + extComp, false, ConsoleColor.Green);
                GenericHelp.DebugBox("Default file extension: " + provider.FileExtension, true, ConsoleColor.Green);
                return true;
            }
            else
            {
                // No CodeDom provider found check for non CodeDom working language 
                switch (language)
                {
                    case "Python":
                        GenericHelp.DebugBox("External Provider found!", false, ConsoleColor.Green);
                        GenericHelp.DebugBox("Language provider: IronPython", false, ConsoleColor.Green); // get ver of python later
                        GenericHelp.DebugBox("Default file extension: py", true, ConsoleColor.Green);
                        return true;
                    default:
                        GenericHelp.DebugBox("There is no provider configured for " + language, true, ConsoleColor.Red);
                        return false;
                }

                
            }
        }
    }
}
