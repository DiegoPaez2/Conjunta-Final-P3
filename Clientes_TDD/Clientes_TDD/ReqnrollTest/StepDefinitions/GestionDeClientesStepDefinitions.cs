using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTest.Utilities;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public class GestionDeClientesStepDefinitions
    {
        private IWebDriver _driver; // Variable de instancia para el WebDriver
        private static ExtentReports _extent; // Variable estática para el reporte
        private ExtentTest _test; // Variable de instancia para el test actual
        private readonly ScenarioContext _scenarioContext;

        public GestionDeClientesStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // Configuración del reporte antes de ejecutar los tests
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        // Inicialización antes de cada escenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriberManager.GetDriver("chrome"); // Inicializa el WebDriver
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title); // Crea el test en el reporte
        }

        // Given: El usuario está en la página de creación de cliente
        [Given("El usuario está en la página de creación de cliente")]
        public void GivenElUsuarioEstaEnLaPaginaDeCreacionDeCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Create");
            _test.Log(Status.Pass, "Usuario navega a la página de creación de cliente");
        }

        // When: El usuario ingresa los datos correctos
        [When("El usuario ingresa los datos correctos")]
        public void WhenElUsuarioIngresaLosDatosCorrectos()
        {
            _driver.FindElement(By.Id("Cedula")).SendKeys("1750343210");
            _driver.FindElement(By.Id("Apellidos")).SendKeys("Paez");
            _driver.FindElement(By.Id("Nombres")).SendKeys("Diego");
            _driver.FindElement(By.Id("FechaNacimiento")).SendKeys("09111999");
            _driver.FindElement(By.Id("Mail")).SendKeys("diegolexx99@gmail.com");
            _driver.FindElement(By.Id("Telefono")).SendKeys("0992060341");
            _driver.FindElement(By.Id("Direccion")).SendKeys("Quito");
            _driver.FindElement(By.Id("Estado")).Click();
            _driver.FindElement(By.Id("BtnCrear")).Click();
            _test.Log(Status.Pass, "Usuario ingresa los datos correctos y hace clic en crear");
        }

        // Then: El cliente es creado exitosamente
        [Then("El cliente es creado exitosamente")]
        public void ThenElClienteEsCreadoExitosamente()
        {
            try
            {
                Assert.Equal("https://localhost:7221/Cliente", _driver.Url);
                _test.Log(Status.Pass, "Cliente creado exitosamente");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
                throw;
            }
        }

        // Given: El usuario está en la página de lista de clientes
        [Given("El usuario está en la página de lista de clientes")]
        public void GivenElUsuarioEstaEnLaPaginaDeListaDeClientes()
        {
            _driver.Navigate().GoToUrl("https://localhost:7221/Cliente");
            _test.Log(Status.Pass, "Usuario navega a la página de lista de clientes");
        }

        // When: El usuario elimina un cliente existente
        [When("El usuario elimina un cliente existente")]
        public void WhenElUsuarioEliminaUnClienteExistente()
        {
            try
            {
                // Seleccionar el cliente a eliminar
                _driver.FindElement(By.Id("btnDelete-1750343210")).Click();
                // Confirmar la eliminación
                _driver.FindElement(By.Id("confirmDeleteButton")).Click();
                _test.Log(Status.Pass, "Usuario elimina un cliente existente");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error al eliminar cliente: {ex.Message}");
                throw;
            }
        }

        // Then: El cliente es eliminado exitosamente
        [Then("El cliente es eliminado exitosamente")]
        public void ThenElClienteEsEliminadoExitosamente()
        {
            try
            {
                Assert.Equal("https://localhost:7221/Cliente", _driver.Url);
                _test.Log(Status.Pass, "Cliente eliminado exitosamente");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
                throw;
            }
        }

        // When: El usuario edita los datos de un cliente existente
        [When("El usuario edita los datos de un cliente existente")]
        public void WhenElUsuarioEditaLosDatosDeUnClienteExistente()
        {
            try
            {
                // Navegar explícitamente a la URL de edición
                _driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Edit?cedula=1750343210");

                // Editar los datos del cliente
                _driver.FindElement(By.Id("Apellidos")).Clear();
                _driver.FindElement(By.Id("Apellidos")).SendKeys("Zapata");
                _driver.FindElement(By.Id("Nombres")).Clear();
                _driver.FindElement(By.Id("Nombres")).SendKeys("Alex");
                _driver.FindElement(By.Id("FechaNacimiento")).Clear();
                _driver.FindElement(By.Id("FechaNacimiento")).SendKeys("09112000");
                _driver.FindElement(By.Id("Mail")).Clear();
                _driver.FindElement(By.Id("Mail")).SendKeys("diegolexx@gmail.com");
                _driver.FindElement(By.Id("Direccion")).Clear();
                _driver.FindElement(By.Id("Direccion")).SendKeys("Guayas");
                _driver.FindElement(By.Id("Estado")).Click();
                _driver.FindElement(By.Id("BtnEdit")).Click(); // Confirmar la edición

                _test.Log(Status.Pass, "Usuario edita los datos de un cliente existente");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error al editar cliente: {ex.Message}");
                throw;
            }
        }

        // Then: Los datos del cliente son actualizados exitosamente
        [Then("Los datos del cliente son actualizados exitosamente")]
        public void ThenLosDatosDelClienteSonActualizadosExitosamente()
        {
            try
            {
                Assert.Equal("https://localhost:7221/Cliente", _driver.Url);
                _test.Log(Status.Pass, "Datos del cliente actualizados exitosamente");
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
                throw;
            }
        }

        // Cleanup: Después de cada escenario
        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Quit(); // Cierra el navegador después de cada escenario
            }
        }
    }
}
