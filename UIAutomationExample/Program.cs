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

            int retries = 10;
            while (p.MainWindowHandle == IntPtr.Zero && retries > 0)
            {
                Thread.Sleep(500);
                retries--;
                p.Refresh();
            }

            AutomationElement targetWindow = AutomationElement.FromHandle(p.MainWindowHandle);

            // txtId
            // txtPw
            // btnIn
            // btnOut
            // Close

            Console.WriteLine("Exit App");
        }
    }
}
