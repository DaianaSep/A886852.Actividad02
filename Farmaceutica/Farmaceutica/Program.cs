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
            Validaciones V = new Validaciones();
            bool Flag = false;
            int SalidaMenu = 0;

            do
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Seleccione una de las siguientes opciones del menú: " + System.Environment.NewLine +
                        "1 - Crear catálogo" + System.Environment.NewLine +
                        "2 - Crear pedido" + System.Environment.NewLine +
                        "3 - Crear entrega" + System.Environment.NewLine +
                        "4 - Mostrar stock final" + System.Environment.NewLine +
                        "0 - Salir");

                    string IngresoMenu = Console.ReadLine();
                    Flag = V.ValidarEntero(IngresoMenu, ref SalidaMenu);
                } while (!Flag);

                switch (SalidaMenu)
                {
                    case 1:
                        P.CrearCatalogo();
                        break;
                    case 2:
                        P.CrearPedido();
                        break;
                    case 3:
                        P.CrearEntrega();
                        break;
                    case 4:
                        P.MostrarStockFinal();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No ingresó una opción válida");
                        break;
                }
            } while (SalidaMenu != 0);

            Console.ReadKey();
        }
    }
}
