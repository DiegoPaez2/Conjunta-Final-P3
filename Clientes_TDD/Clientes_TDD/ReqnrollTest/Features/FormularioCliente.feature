Feature: Formulario de Cliente

  Scenario: Llenar formulario de cliente con datos válidos
    Given El usuario está en la página de creación de cliente
    When El usuario ingresa los siguientes datos:
      | Campo           | Valor              |
      | Cedula          | 1750343210         |
      | Apellidos       | Paez               |
      | Nombres         | Diego              |
      | FechaNacimiento | 09/11/1999         |
      | Mail            | diegolexx99@gmail.com |
      | Telefono        | 0992060341         |
      | Direccion       | Quito              |
      | Estado          | Activo             |
    And El usuario hace clic en el botón "Crear"
    Then El usuario debería ser redirigido a la página de lista de clientes