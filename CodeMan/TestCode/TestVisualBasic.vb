'Test VisualBasic source code 
Imports System

Module TestVb
    Public externalVar As String = ""
    Sub Main(args As String())
        Console.WriteLine("Hello World, from VisualBasic!")
        Console.WriteLine(externalVar)
        DoStuff("Internal Call to Method")
    End Sub
    Sub DoStuff(msg As String)
        Console.WriteLine(msg)
    End Sub
End Module