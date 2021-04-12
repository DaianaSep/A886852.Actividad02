using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmaceutica.Clases;

namespace Farmaceutica.Clases
{
    public class Producto
    {
        public string Nombre { get; set; }
        public int Id_Producto { get; set; }
        public int Stock { get; set; }
        Validaciones V = new Validaciones();
        List<Producto> ListaProductos = new List<Producto>();

        public Producto() { }

        public Producto(string nombre, int id_producto, int stock)
        {
            this.Nombre = nombre;
            this.Id_Producto = id_producto;
            this.Stock = stock;
        }

        public Producto CrearProducto()
        {
            string Nombre;
            string Id_Producto;
            int Salida_Id_Producto = 0;
            int Salida_Stock_Inicial = 0;
            string stock;
            bool Flag = true;

            do
            {
                Console.Write("Ingrese el nombre del producto: ");
                Nombre = Console.ReadLine();
                Flag = V.ValidarTexto(Nombre, "Nombre");

            } while (!Flag);

            do
            {
                Console.Write("Ingrese el número del producto: ");
                Id_Producto = Console.ReadLine();
                Flag = V.ValidarEntero(Id_Producto, ref Salida_Id_Producto);

            } while (!Flag);

            do
            {
                Console.Write("Ingrese el stock inicial del producto: ");
                stock = Console.ReadLine();
                Flag = V.ValidarEntero(stock, ref Salida_Stock_Inicial);

            } while (!Flag);

            Producto P = new Producto(
                Nombre,
                Convert.ToInt32(Id_Producto),
                Convert.ToInt32(stock));

            return P;
        }

        public override string ToString()
        {
            return string.Format(
                $"Nombre: {Nombre} " + System.Environment.NewLine +
                $"Número de Producto: {Id_Producto}" + System.Environment.NewLine +
                $"Stock: {Stock}"
                );
        }

        public void CrearCatalogo()
        {
            string Salida = "";

            do
            {
                Producto P = CrearProducto();
                ListaProductos.Add(P);
                Console.WriteLine("Presione 1 para finalizar o Enter para continuar");
                Salida = Console.ReadLine();

            } while (Salida != "1");

            foreach (Producto P in ListaProductos)
            {
                Console.WriteLine($"Producto {ListaProductos.IndexOf(P) + 1}: " + System.Environment.NewLine + P.ToString());
            }
        }

        public void CrearPedido()
        {
            bool Flag = false;
            int Salida_Num_Prod = 0;

            do
            {
                do
                {
                    Console.Write("Ingrese el número del producto a pedir: ");
                    string Num_Prod = Console.ReadLine();
                    Flag = V.ValidarEntero(Num_Prod, ref Salida_Num_Prod);
                } while (!Flag);

                Producto Pedido_Prod = ListaProductos.Find(P => P.Id_Producto == Salida_Num_Prod);

                if (Pedido_Prod == null)
                {
                    Console.WriteLine("No se encontró el producto con el número ingresado");
                    Flag = false;
                }
                else if (Pedido_Prod.Stock <= 0)
                {
                    Console.WriteLine("No hay más stock del producto seleccionado");
                    Flag = false;
                }
                else
                {
                    Pedido_Prod.Stock--;
                    Console.WriteLine($"El pedido se ha realizado exitosamente! El producto pedido es: {Pedido_Prod.Nombre}");

                    if (Pedido_Prod.Stock <= 0)
                    {
                        Console.WriteLine("Advertencia! El producto se ha quedado sin stock");
                    }
                    Flag = true;
                }
            } while (!Flag);
        }

        public void CrearEntrega()
        {
            bool Flag = false;
            int Salida_Num_Prod = 0;

            do
            {
                do
                {
                    Console.Write("Ingrese el número del producto a entregar: ");
                    string Num_Prod = Console.ReadLine();
                    Flag = V.ValidarEntero(Num_Prod, ref Salida_Num_Prod);
                } while (!Flag);

                Producto Entrega_Prod = ListaProductos.Find(P => P.Id_Producto == Salida_Num_Prod);
                if (Entrega_Prod == null)
                {
                    Console.WriteLine("No se encontró el producto con el número ingresado");
                    Flag = false;
                }
                else
                {
                    Entrega_Prod.Stock++;
                    Console.WriteLine($"La entrega se ha realizado exitosamente! El producto entregado es: {Entrega_Prod.Nombre}");
                    Flag = true;
                }
            } while (!Flag);
        }

        public void MostrarStockFinal()
        {
            foreach (Producto P in ListaProductos)
            {
                Console.WriteLine("Listado final de prductos:" + System.Environment.NewLine + $"Número de producto: {P.Id_Producto} - Nombre: {P.Nombre} - El stock final es: {P.Stock}");
            }
        }
    }
}
