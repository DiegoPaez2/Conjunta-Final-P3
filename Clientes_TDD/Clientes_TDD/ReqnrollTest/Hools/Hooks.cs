using Reqnroll;
using ReqnrollTest.Reports;


namespace ReqnrolTestProject1.Hools
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitReport();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ExtentReportManager.StartTest(scenarioContext.ScenarioInfo.Title);

        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepInfo = scenarioContext.StepContext.StepInfo.Text;
            bool isSuccess = scenarioContext.TestError == null;

            ExtentReportManager.LogStep(isSuccess, isSuccess ? $"Paso exitoso: {stepInfo}" : $"Error: {scenarioContext.TestError.Message}");
        }

        [AfterTestRun]

        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReport();
        }



    }
}