using System;
using System.CodeDom.Compiler;

namespace CodeManLib.Helpers
{
    /// <summary>
    /// CodeDom Helpers 
    /// </summary>
    public class CodeDomHelp
    {
        public static void CheckForProvider(string language)
        {
            // Init code dom provider
            CodeDomProvider provider;
            GenericHelp.DebugBox("Checking If CodeDom provider exists for " + language, false, ConsoleColor.Blue);

            // Check to see if It exists
            if (CodeDomProvider.IsDefinedLanguage(language))
            {
                // Create the CodeDom provider
                provider = CodeDomProvider.CreateProvider(language);

                // Display stuff about the language provider.
                GenericHelp.DebugBox("CodeDom Provider found!", false, ConsoleColor.Green);
                GenericHelp.DebugBox("Language provider: " + provider.ToString(), false, ConsoleColor.Green);
                GenericHelp.DebugBox("Default file extension: " + provider.FileExtension, true, ConsoleColor.Green);
            }
            else
            {
                // No CodeDom provider found
                GenericHelp.DebugBox("There is no provider configured for " + language, true, ConsoleColor.Red);
            }
        }
    }
}
