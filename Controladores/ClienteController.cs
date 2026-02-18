using MantWebClientes.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MantWebClientes.Controladores
{
    public class ClienteController
    {
        private string connectionString;

        public ClienteController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public List<ClienteClass> ObtenerClientes()
        {
            List<ClienteClass> clientes = new List<ClienteClass>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerClientes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clientes.Add(new ClienteClass
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Email = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        FechaCreacion = reader.GetDateTime(4),
                        UsuarioCreacion = reader.GetString(5),
                        FechaModificacion = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),  
                        UsuarioModificacion = reader.IsDBNull(7) ? null : reader.GetString(7)
                    });
                }
            }

            return clientes;
        }

        public void AgregarCliente(string nombre, string email, string telefono, string usuarioCreacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@UsuarioCreacion", usuarioCreacion);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ClienteClass ObtenerClientePorId(int id)
        {
            ClienteClass cliente = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerClientePorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new ClienteClass
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Email = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        FechaCreacion = reader.GetDateTime(4),
                        UsuarioCreacion = reader.GetString(5),
                        FechaModificacion = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),  
                        UsuarioModificacion = reader.IsDBNull(7) ? null : reader.GetString(7)
                    };
                }
            }

            return cliente;
        }

        public void ActualizarCliente(int id, string nombre, string email, string telefono, string usuarioModificacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@UsuarioModificacion", usuarioModificacion);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}