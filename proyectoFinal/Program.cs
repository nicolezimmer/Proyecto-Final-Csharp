using proyectoFinal.model;
using System.Data.SqlClient;

namespace proyectoFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(traerUsuario(1));

            foreach (var producto in traerProducto(1))
            {
                Console.WriteLine(producto.ToString());
            }

            foreach (var producto in traerProductoVendido(2))
            {
                Console.WriteLine(producto.ToString());
            }
            foreach (var producto in traerVentas(1))
            {
                Console.WriteLine(producto.ToString());
            }
            Console.WriteLine(inicioDeSesion("'eperez'", "'SoyErnestoPerez'"));



            Usuario traerUsuario(long id)
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
            List<Producto> traerProducto(long id)
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
            List<ProductoVenta> traerProductoVendido(long id)
            {
                //Traer ProductosVendidos (recibe el id del usuario y devuelve una lista de productos vendidos por ese usuario)
                string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand comando = new SqlCommand($"select * from ProductoVendido where IdVenta = {id}", connection);
                    List<ProductoVenta> ventas = new List<ProductoVenta>();
                    connection.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // el reader.Read() devuelve true si existen mas filas debajo de la fila de la iteracion  
                        while (reader.Read())
                        {
                            ventas.Add(new ProductoVenta(reader.GetInt64(0), reader.GetInt64(2), reader.GetInt32(1), reader.GetInt64(3)));
                        }
                    }
                    return ventas;
                }
            }

            List<Venta> traerVentas(long id)
            {
                //Traer Ventas (recibe el id del usuario y devuelve un a lista de Ventas realizadas por ese usuario)
                string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand comando = new SqlCommand($"select * from Venta where IdUsuario = {id}", connection);
                    List<Venta> ventas = new List<Venta>();
                    connection.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // el reader.Read() devuelve true si existen mas filas debajo de la fila de la iteracion  
                        while (reader.Read())
                        {
                            ventas.Add(new Venta(reader.GetInt64(0), reader.GetString(1), reader.GetInt64(2)));
                        }
                    }
                    return ventas;
                }
            }
            Usuario inicioDeSesion(string usuario, string contraseña)
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

}

