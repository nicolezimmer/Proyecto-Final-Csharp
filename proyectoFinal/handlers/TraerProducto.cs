using proyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal.handlers
{
    internal static class TraerProducto
    {
        public static List<Producto> traerProducto(long id)
        {
            //Traer Productos (recibe un id de usuario y, devuelve una lista con todos los productos cargado por ese usuario)
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from Producto where IdUsuario = {id}", connection);
                List<Producto> productos = new List<Producto>();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto(reader.GetInt64(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5)));


                    }
                }
                return productos;
            }
        }
    }
}
