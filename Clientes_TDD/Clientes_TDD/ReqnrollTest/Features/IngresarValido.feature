Feature: IngresarValido

A short summary of the feature

@tag1
Scenario: Insertar un nuevo cliente exitosamente
	Given El usuario ingresa los datos validos 
	
     | Cédula      | Apellidos | Nombres | FechaNacimiento | Mail              | Teléfono   | Dirección              | Estado  |
     | 1750342210  | Paez      | Juan    | 09111999        | dapaez2@espe.com  | 0991234567 | Av. Siempre Viva 123   | TRUE  |
    
	 When Registros ingrersado en la BD
     | Cédula      | Apellidos | Nombres | FechaNacimiento | Mail              | Teléfono   | Dirección              | Estado  |
     | 1750342210  | Paez      | Juan    | 09111999        | dapaez2@espe.com  | 0991234567 | Av. Siempre Viva 123   | TRUE  |
    Then Resultado del ingreso a la BD 
     | Cédula      | Apellidos | Nombres | FechaNacimiento | Mail              | Teléfono   | Dirección              | Estado  |
     | 1750342210  | Paez      | Juan    | 09111999        | dapaez2@espe.com  | 0991234567 | Av. Siempre Viva 123   | TRUE  |
    