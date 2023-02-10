using proyectoFinal.handlers;
using proyectoFinal.model;
using System.Data.SqlClient;

namespace proyectoFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TraerUsuario.traerUsuario(1));

            foreach (var producto in TraerProducto.traerProducto(1))
            {
                Console.WriteLine(producto.ToString());
            }

            foreach (var producto in TraerProductoVendido.traerProductoVendido(2))
            {
                Console.WriteLine(producto.ToString());
            }
            foreach (var producto in TraerVentas.traerVentas(1))
            {
                Console.WriteLine(producto.ToString());
            }
            Console.WriteLine(InicioDeSesion.inicioDeSesion("'eperez'", "'SoyErnestoPerez'"));

        }

    }

}

