package TestCode
{
    class TestJs
    {
        var externalVar = "stuff";
        var WshShell = new ActiveXObject("WScript.Shell");
        //console.log("Hello World, from JavaScript");
        //console.log(externalVar);
        function Main() {
            WshShell.WriteLine("Hello World, from JavaScript");
            DoStuff("Call")
        }
        function DoStuff(name) { WshShell.WriteLine(name); }
    }
}