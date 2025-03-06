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
    public class TestCliente : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public TestCliente()
        {
            _driver = new EdgeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }


        // Prueba 1
        [Fact]
        public void FormularioVacio()
        {

            _driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Create");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("BtnCrear")).Click();
            Thread.Sleep(2000);


            Assert.Equal("https://localhost:7221/Cliente/Create", _driver.Url);
            Thread.Sleep(10000);
        }



        [Fact]
        public void FormularioCorrecto()
        {

            _driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Create");
            Thread.Sleep(2000);


            _driver.FindElement(By.Id("Cedula")).SendKeys("1750343210");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Apellidos")).SendKeys("Paez");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Nombres")).SendKeys("Diego");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("FechaNacimiento")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("FechaNacimiento")).SendKeys("09111999");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Mail")).SendKeys("diegolexx99@gmail.com");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Telefono")).SendKeys("0992060341");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Direccion")).SendKeys("Quito");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Estado")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("BtnCrear")).Click();
            Thread.Sleep(2000);

            Assert.Equal("https://localhost:7221/Cliente", _driver.Url);
            Thread.Sleep(10000);
        }

        [Fact]
        public void FormularioIncorrecto()
        {

            _driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Create");
            Thread.Sleep(2000);


            _driver.FindElement(By.Id("Cedula")).SendKeys("1750343211");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Apellidos")).SendKeys("Paez");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Nombres")).SendKeys("Diego");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("FechaNacimiento")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("FechaNacimiento")).SendKeys("78415");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Mail")).SendKeys("diegolexx99@gmail.com");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Telefono")).SendKeys("sdfasd1");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Direccion")).SendKeys("Quito");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Estado")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("BtnCrear")).Click();
            Thread.Sleep(2000);

            Assert.Equal("https://localhost:7221/Cliente/Create", _driver.Url);
            Thread.Sleep(10000);
        }


        [Fact]
        public void Eliminar()
        {

            _driver.Navigate().GoToUrl("https://localhost:7221/Cliente");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("btnDelete-1750343210")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("confirmDeleteButton")).Click();
            Thread.Sleep(2000);

            Assert.Equal("https://localhost:7221/Cliente", _driver.Url);
            Thread.Sleep(10000);
        }

        [Fact]
        public void EditarCliente()
        {

            _driver.Navigate().GoToUrl("https://localhost:7221/Cliente");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("editButton_1750343210")).Click();
            Thread.Sleep(2000);

          
            _driver.FindElement(By.Id("Apellidos")).Clear();
            _driver.FindElement(By.Id("Apellidos")).SendKeys("Zapata");
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("Nombres")).Clear();
            _driver.FindElement(By.Id("Nombres")).SendKeys("Alex");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("FechaNacimiento")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("FechaNacimiento")).Clear();
            _driver.FindElement(By.Id("FechaNacimiento")).SendKeys("09112000");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Mail")).Clear();
            _driver.FindElement(By.Id("Mail")).SendKeys("diegolexx@gmail.com");
            Thread.Sleep(2000);

            

            Thread.Sleep(2000);
            _driver.FindElement(By.Id("Direccion")).Clear();
            _driver.FindElement(By.Id("Direccion")).SendKeys("Guayas");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("Estado")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("BtnEdit")).Click();
            Thread.Sleep(2000);

            Assert.Equal("https://localhost:7221/Cliente", _driver.Url);
            Thread.Sleep(10000);

        }


        public void Dispose()
        {
            _driver.Quit();
        }

    }
}
