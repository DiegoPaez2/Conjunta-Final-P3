using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace ReqnrollTest.Reports
{
    public class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        // Ruta modificada para guardar el reporte en la carpeta que indicaste
        private static string _reportpath =
            Path.Combine(@"C:\Users\diego\Downloads\TDD\TDD\ReqnrollProject1\bin\Debug\net8.0", "ExtentReport.html");

        public static void InitReport()
        {
            var spartReport = new ExtentSparkReporter(_reportpath);
            _extent = new ExtentReports();
            _extent.AttachReporter(spartReport);
        }

        public static void StartTest(string testname)
        {
            _test = _extent.CreateTest(testname);
        }

        public static void LogStep(bool isSuccess, string stepDetails)
        {
            if (isSuccess)
                _test.Log(Status.Pass, stepDetails);
            else
                _test.Log(Status.Fail, stepDetails);
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
