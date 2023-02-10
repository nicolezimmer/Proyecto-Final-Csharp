using proyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal.handlers
{
    internal static class InicioDeSesion
    {
        public static Usuario inicioDeSesion(string usuario, string contraseña)
        {
            //Inicio de sesión (recibe un usuario y contraseña y devuelve un objeto Usuario)
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from Usuario where NombreUsuario= {usuario} and Contraseña = {contraseña}", connection);
                Usuario buscado = new Usuario();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        buscado = new Usuario(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));

                    }
                }
                return buscado;
            }
        }
    }
}
