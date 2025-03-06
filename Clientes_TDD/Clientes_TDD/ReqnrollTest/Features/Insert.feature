Feature: Insert

Ingreso de un nuevo cliente a al bd
  
  
 @tag1
 Scenario: Insertar un nuevo cliente exitosamente
    Given el usuario llena el formulario con los siguientes datos:
     | Cédula      | Apellidos | Nombres | FechaNacimiento | Mail              | Teléfono   | Dirección              | Estado  |
     | 1750342210  | Paez      | Juan    | 09111999        | dapaez2@espe.com  | 0991234567 | Av. Siempre Viva 123   | TRUE  |
    When Registros ingrersado en la BD
     | Cédula      | Apellidos | Nombres | FechaNacimiento | Mail              | Teléfono   | Dirección              | Estado  |
     | 1750342210  | Paez      | Juan    | 09111999        | dapaez2@espe.com  | 0991234567 | Av. Siempre Viva 123   | TRUE  |
    Then Resultado del ingreso a la BD 
     | Cédula      | Apellidos | Nombres | FechaNacimiento | Mail              | Teléfono   | Dirección              | Estado  |
     | 1750342210  | Paez      | Juan    | 09111999        | dapaez2@espe.com  | 0991234567 | Av. Siempre Viva 123   | TRUE  |
    