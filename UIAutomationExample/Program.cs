using System;
using System.Diagnostics;
using System.Threading;

namespace UIAutomationExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start App");

            string appPath = @"C:\Users\wasab\source\repos\UIAutomationExample\WindowsFormsApp\bin\Debug\WindowsFormsApp.exe";
            Process p = Process.Start(appPath);
            p.WaitForInputIdle();

            Thread.Sleep(5000);

            Console.WriteLine("Exit App");
        }
    }
}
