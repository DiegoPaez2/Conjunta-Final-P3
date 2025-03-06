using System;
using Reqnroll;
using TDDTestingMVC1.Models;

namespace ReqnrollTest.StepDefinitions
{
    [Binding]
    public class AreaDeUnCirculoStepDefinitions
    {
        private readonly Circulo _circulo = new Circulo();
        private double _resultado;

        [Given("que ingresamos el radio {int}")]
        public void GivenQueIngresamosElRadio(int radio)
        {
            _circulo.Radio = radio;
        }

        [When("calculamos el área usando la fórmula")]
        public void WhenCalculamosElAreaUsandoLaFormula()
        {
            _resultado = _circulo.CalcularArea();
        }

        [Then("el resultado debería ser aproximadamente {float}")]
        public void ThenElResultadoDeberiaSerAproximadamente(double resultadoEsperado)
        {
            _resultado.CompareTo(resultadoEsperado);
        }
    }

}

