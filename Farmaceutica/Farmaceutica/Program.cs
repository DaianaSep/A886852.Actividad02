using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmaceutica.Clases;

namespace Farmaceutica
{
    class Program
    {
        static void Main(string[] args)
        {
            Producto P = new Producto();

            //Crear catálogo de productos
            P.CrearCatalogo();
            //Crear Pedido
            P.CrearPedido();
            //Crear Entrega
            P.CrearEntrega();
            //Mostrar stock final
            P.MostrarStockFinal();

            Console.ReadKey();
        }
    }
}
