using proyectoFinal.model;
using System.Data.SqlClient;

namespace proyectoFinal
{
    public static class TraerUsuario
    {
        public static Usuario traerUsuario(long id)
            {
                //Traer Usuario (recibe un int)
                string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand comando = new SqlCommand($"select * from Usuario where id = {id}", connection);
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





