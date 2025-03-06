using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.Threading;
using Xunit;


namespace TestProject
{
    public class TestDemoqa : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public TestDemoqa()
        {
            _driver = new EdgeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        // Prueba 1
        [Fact]
        public void FormularioVacio()
        {
           
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(2000);

            ScrollDown(600);

            _driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);


            Assert.Equal("https://demoqa.com/automation-practice-form", _driver.Url);
            Thread.Sleep(10000);
        }

        // Prueba 2
        [Fact]
        public void FormularioLleno()
        {

            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(1000);

            ScrollDown(300);

            _driver.FindElement(By.Id("firstName")).SendKeys("Diego");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("lastName")).SendKeys("Paez");
            Thread.Sleep(2000);
 

            _driver.FindElement(By.Id("userEmail")).SendKeys("dapaez@gmail.com");
            Thread.Sleep(2000);

            _driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("userNumber")).SendKeys("0992060341");
            Thread.Sleep(2000);

            var dateInput = _driver.FindElement(By.Id("dateOfBirthInput"));
            dateInput.Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.ClassName("react-datepicker__year-select")).SendKeys("1998");
            _driver.FindElement(By.ClassName("react-datepicker__month-select")).SendKeys("March");
            Thread.Sleep(2000);
            _driver.FindElement(By.ClassName("react-datepicker__day--001")).Click();

            Thread.Sleep(2000);

            ScrollDown(200);
             
            var subjectsInput = _driver.FindElement(By.Id("subjectsInput"));
            subjectsInput.SendKeys("Maths");
            Thread.Sleep(2000);
            subjectsInput.SendKeys(Keys.Enter);
           subjectsInput.SendKeys("English");
            subjectsInput.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("currentAddress")).SendKeys("Quito-Ecuador");
            Thread.Sleep(2000);

            ScrollDown(200);

            var state = _driver.FindElement(By.Id("react-select-3-input"));
            state.SendKeys("NCR");
            state.SendKeys(Keys.Enter);
            Thread.Sleep(500);

            var city = _driver.FindElement(By.Id("react-select-4-input"));
            city.SendKeys("Delhi");
            city.SendKeys(Keys.Enter);

            _driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);


            var modal = _driver.FindElement(By.ClassName("modal-content"));
            Assert.NotNull(modal);

            _driver.Quit();


        }

    
        // Prueba 3

        [Fact]
        public void FormularioDatosDiferentes()
        {

            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            ScrollDown(300);

            _driver.FindElement(By.Id("firstName")).SendKeys("123468");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("lastName")).SendKeys("123546");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("userEmail")).SendKeys("dapaezgmail.com");
            Thread.Sleep(1000);

            _driver.FindElement(By.CssSelector("label[for='gender-radio-3']")).Click();
            Thread.Sleep(1000);


            _driver.FindElement(By.Id("userNumber")).SendKeys("abcder");
            Thread.Sleep(1000);


            var dateInput = _driver.FindElement(By.Id("dateOfBirthInput"));
            dateInput.Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.ClassName("react-datepicker__year-select")).SendKeys("1998");
            Thread.Sleep(1000);
            _driver.FindElement(By.ClassName("react-datepicker__month-select")).SendKeys("Enero");
            Thread.Sleep(1000);
            _driver.FindElement(By.ClassName("react-datepicker__day--001")).Click();
            Thread.Sleep(1000);

            ScrollDown(200);

            var subjectsInput = _driver.FindElement(By.Id("subjectsInput"));
            subjectsInput.SendKeys("Maths");
            Thread.Sleep(1000);
            subjectsInput.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            subjectsInput.SendKeys("English");
            subjectsInput.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("currentAddress")).SendKeys("Quito-Ecuador");
            Thread.Sleep(2000);

            ScrollDown(200);

            var state = _driver.FindElement(By.Id("react-select-3-input"));
            state.SendKeys("NCR");
            state.SendKeys(Keys.Enter);
            Thread.Sleep(500);

            var city = _driver.FindElement(By.Id("react-select-4-input"));
            city.SendKeys("Delhi");
            city.SendKeys(Keys.Enter);

            _driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(30000);
        }






        public void ScrollDown(int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"window.scrollBy(0, {pixels});");
            Thread.Sleep(1000);
        }
        
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
