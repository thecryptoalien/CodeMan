// Test JScript source code
import System;

package TestCode
{
    class TestJs
    {        
        var externalVar;
    
        function Main() {
            System.Console.WriteLine("Hello World, from JavaScript!");
            System.Console.WriteLine(externalVar);
            DoStuff("Internal Call to Function");
        }

        function DoStuff(name) { 
            System.Console.WriteLine(name);
        }
    }

}