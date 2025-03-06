Feature: Área de un Círculo

  La fórmula para calcular el área de un círculo es π * r^2.

  @mytag
  Scenario: Calcular el área de un círculo dado un radio
    Given que ingresamos el radio 5
    When calculamos el área usando la fórmula
    Then el resultado debería ser aproximadamente 78.54
