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
            var txtId = targetWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtId"));
            if (txtId != null && txtId.TryGetCurrentPattern(ValuePattern.Pattern, out object idPatternObj))
            {
                ValuePattern idPattern = (ValuePattern)idPatternObj;
                idPattern.SetValue(yourId);
            }

            var txtPw = targetWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtPw"));
            if (txtPw != null && txtPw.TryGetCurrentPattern(ValuePattern.Pattern, out object pwPatternObj))
            {
                ValuePattern pwPattern = (ValuePattern)pwPatternObj;
                pwPattern.SetValue(yourPw);
            }

            Thread.Sleep(5000);

            const bool flag = true;
            if (flag)
            {
                var btnIn = targetWindow.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "btnIn"));
                if (btnIn != null && btnIn.TryGetCurrentPattern(InvokePattern.Pattern, out object inPatternObj))
                {
                    InvokePattern inPattern = (InvokePattern)inPatternObj;
                    inPattern.Invoke();
                }
            }
            else
            {
                var btnOut = targetWindow.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "btnOut"));
                if (btnOut != null && btnOut.TryGetCurrentPattern(InvokePattern.Pattern, out object outPatternObj))
                {
                    InvokePattern outPattern = (InvokePattern)outPatternObj;
                    outPattern.Invoke();
                }
            }

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
