using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objClienteDal = new ClienteDataAccessLayer();

        // Acción Index: Mostrar todos los clientes
        public IActionResult Index()
        {
            List<Cliente> listCliente = objClienteDal.GetClientes().ToList();
            return View(listCliente);
        }




        // Acción Create: Vista de creación de cliente
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción Create (Guardar cliente)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente objCliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si la cédula ya está registrada
                    bool existeCedula = objClienteDal.GetClientes().Any(c => c.Cedula == objCliente.Cedula);
                    if (existeCedula)
                    {
                        ModelState.AddModelError("Cedula", "La cédula ingresada ya está en uso.");
                    }

                    // Verificar si el correo ya está registrado
                    bool existeCorreo = objClienteDal.GetClientes().Any(c => c.Mail == objCliente.Mail);
                    if (existeCorreo)
                    {
                        ModelState.AddModelError("Mail", "El correo electrónico ingresado ya está en uso.");
                    }

                    // Si hay errores, regresar la vista con los mensajes de error
                    if (existeCedula || existeCorreo)
                    {
                        return View(objCliente);
                    }

                    // Si la cédula y el correo no están en uso, guardar el cliente
                    objClienteDal.AddCliente(objCliente);
                    return RedirectToAction("Index");
                }
                catch (SqlException ex)
                {
                    // Si hay un error de clave duplicada, capturamos el error y mostramos un mensaje
                    if (ex.Message.Contains("UQ__Cliente"))
                    {
                        ModelState.AddModelError("", "La cédula o correo electrónico ya está en uso.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error inesperado. Por favor intente de nuevo.");
                    }
                    return View(objCliente);
                }
            }

            return View(objCliente);
        }








        // Acción Edit: Vista de edición de cliente
        [HttpGet]
        public IActionResult Edit(string cedula)  // Usando 'Cedula' como parámetro
        {
            var cliente = objClienteDal.GetClienteByCedula(cedula);  // Usamos 'Cedula' para buscar al cliente
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // Acción Edit (Actualizar cliente)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string cedula, Cliente objCliente)  // Cambié el 'id' a 'cedula'
        {
            if (cedula != objCliente.Cedula)  // Compara usando 'Cedula' en vez de 'id'
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                objClienteDal.UpdateCliente(objCliente);
                return RedirectToAction("Index");
            }
            return View(objCliente);
        }

        // Acción Delete (Eliminar cliente)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string cedula)
        {
            bool result = objClienteDal.DeleteCliente(cedula);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
