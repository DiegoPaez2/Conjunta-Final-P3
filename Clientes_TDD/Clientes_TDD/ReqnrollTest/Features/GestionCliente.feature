Feature: Gestión de Clientes

@crear
Scenario: Crear un nuevo cliente
    Given El usuario está en la página de creación de cliente
    When El usuario ingresa los datos correctos
    Then El cliente es creado exitosamente

@editar
Scenario: Editar un cliente existente
    Given El usuario está en la página de lista de clientes
    When El usuario edita los datos de un cliente existente
    Then Los datos del cliente son actualizados exitosamente

@eliminar
Scenario: Eliminar un cliente existente
    Given El usuario está en la página de lista de clientes
    When El usuario elimina un cliente existente
    Then El cliente es eliminado exitosamente