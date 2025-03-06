using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Data
{
    public class ClienteDataAccessLayer
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Server=MSI;Database=dbproductos;User ID=sa;Password=091199;TrustServerCertificate=true;MultipleActiveResultSets=true";

        // Obtener todos los clientes
        public List<Cliente> GetClientes()
        {
            List<Cliente> lst = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.cliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(reader["Codigo"]);
                    cliente.Cedula = reader["Cedula"].ToString();
                    cliente.Apellidos = reader["Apellidos"].ToString();
                    cliente.Nombres = reader["Nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    cliente.Mail = reader["Mail"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Direccion = reader["Direccion"].ToString();
                    cliente.Estado = Convert.ToBoolean(reader["Estado"]);
                    lst.Add(cliente);
                }
                con.Close();
            }
            return lst;
        }

        // Obtener un cliente por su cédula
        public Cliente GetClienteByCedula(string cedula)
        {
            Cliente cliente = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectById", con); // Cambié el nombre del SP a 'cliente_SelectByCedula'
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", cedula);  // Usamos 'Cedula' como parámetro
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(reader["Codigo"]);
                    cliente.Cedula = reader["Cedula"].ToString();
                    cliente.Apellidos = reader["Apellidos"].ToString();
                    cliente.Nombres = reader["Nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    cliente.Mail = reader["Mail"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Direccion = reader["Direccion"].ToString();
                    cliente.Estado = Convert.ToBoolean(reader["Estado"]);
                }
                con.Close();
            }
            return cliente;
        }

        // Agregar un cliente
        public void AddCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);  // Cambié el nombre del SP a 'cliente_Insert'
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Actualizar un cliente
        public void UpdateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);  // Llamar al SP 'cliente_Update'
                cmd.CommandType = CommandType.StoredProcedure;

                // Asegúrate de pasar el parámetro adecuado
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);  // Usar Cedula en lugar de Codigo
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool DeleteCliente(string cedula)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);  // Llamar al SP 'cliente_Delete'
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", cedula);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                return rowsAffected > 0;  // Devuelve true si se eliminó al menos un cliente
            }
        }

        // Crear un pedido
        public void CrearPedido(int clienteCodigo, decimal monto, string estado = "Pendiente")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado
                cmd.Parameters.AddWithValue("@ClienteCodigo", clienteCodigo);
                cmd.Parameters.AddWithValue("@Monto", monto);
                cmd.Parameters.AddWithValue("@Estado", estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Obtener un pedido por su ID
        public Pedido ObtenerPedido(int pedidoID)
        {
            Pedido pedido = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", pedidoID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pedido = new Pedido
                    {
                        PedidoID = Convert.ToInt32(reader["PedidoID"]),
                        FechaPedido = Convert.ToDateTime(reader["FechaPedido"]),
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        Estado = reader["Estado"].ToString()
                    };
                }
                con.Close();
            }
            return pedido;
        }

        // Actualizar un pedido
        public void ActualizarPedido(int pedidoID, int clienteCodigo, decimal monto, string estado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado
                cmd.Parameters.AddWithValue("@PedidoID", pedidoID);
                cmd.Parameters.AddWithValue("@ClienteCodigo", clienteCodigo);
                cmd.Parameters.AddWithValue("@Monto", monto);
                cmd.Parameters.AddWithValue("@Estado", estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Eliminar un pedido
        public bool EliminarPedido(int pedidoID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", pedidoID);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                return rowsAffected > 0; // Devuelve true si se eliminó al menos un pedido
            }



        }

        }
}
