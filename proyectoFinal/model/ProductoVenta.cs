using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal.model
{
    internal class ProductoVenta
    {
        private long id;
        private long idProducto;
        private int stock;
        private long idVenta;

        public ProductoVenta(long id, long idProducto, int stock, long idVenta)
        {
            this.Id = id;
            this.IdProducto = idProducto;
            this.Stock = stock;
            this.IdVenta = idVenta;
        }

        public long Id { get => id; set => id = value; }
        public long IdProducto { get => idProducto; set => idProducto = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdVenta { get => idVenta; set => idVenta = value; }

        public override string ToString()
        {
            return $"id venta: {IdVenta}";
        }
    }
}
