using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

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

            AutomationElement targetWindow = AutomationElement.FromHandle(p.MainWindowHandle);

            Console.WriteLine("Exit App");
        }
    }
}
