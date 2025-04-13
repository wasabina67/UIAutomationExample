using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace UIAutomationExample
{
    internal class Program
    {
        private static string appPath = @"C:\Users\wasab\source\repos\UIAutomationExample\WindowsFormsApp\bin\Debug\WindowsFormsApp.exe";
        private static string yourId = "yourId";
        private static string yourPw = "yourPw";

        static void Main(string[] args)
        {
            Console.WriteLine("Start App");

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

            Thread.Sleep(5000);

            var close = targetWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "Close"));
            if (close != null && close.TryGetCurrentPattern(InvokePattern.Pattern, out object closePatternObj))
            {
                InvokePattern closePattern = (InvokePattern)closePatternObj;
                closePattern.Invoke();
            }

            Console.WriteLine("Exit App");
        }
    }
}
