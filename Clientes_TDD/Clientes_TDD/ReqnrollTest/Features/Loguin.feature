Feature: Login

Test de la pagina de Login del sitio https://www.automationexercise.com/login

@tag1
Scenario: Usuario inicia sesion incorrectamente
	Given Que el usuario esta en la pagina de Login
	When Ingresar las credenciales correo "testuser@gmail.com" y la contraseña "pass123"
	And Hacer click en el boton de Login
	Then Deberia mostrar un mensaje de error