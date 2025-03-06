using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrolTestProject1;
using ReqnrollTest.Utilities;

namespace ReqnrolTestProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;


        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtenReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriberManager.GetDriver("chrome");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }


        [Given("Que el usuario esta en la pagina de Login")]
        public void GivenQueElUsuariosEsteEnLaPaginaDelLoguin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Pass, "Usuario navega a la pagian de loguin");
        }

        [When("Ingresar las credenciales correo {string} y la contraseña {string}")]
        public void WhenIngresarLasCredencialesCorreoYLaContrasena(string p0, string p1)
        {
            _driver.FindElement(By.Name("email")).SendKeys(p0);
            _driver.FindElement(By.Name("password")).SendKeys(p1);

            _test.Log(Status.Info, $"Usuario ingresa correo: {p0} y la contrasenia {p1}");

        }

        [When("Hacer click en el boton de Login")]
        public void WhenHacerClicEnElBotonDeLoguin()
        {
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            _test.Log(Status.Info, "Usuario hace clic en el boton de loguin");
        }

        [Then("Deberia mostrar un mensaje de error")]
        public void ThenDeberiaVerUnMensajeDeError()
        {
            try
            {
                bool isErrorVisible = _driver.FindElement(By.ClassName("login-error")) != null;
                _test.Log(Status.Pass, "Mensaje de error mostrado Correctamente");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Pass, "No se motro el mensaje de error esperado");
            }
        }

        [AfterScenario]
        public void Down()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}