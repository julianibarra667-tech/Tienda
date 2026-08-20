using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniTienda
{
    // Definimos una clase para representar los productos
    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; } // Usamos decimal, que es la mejor práctica para dinero en C#
    }

    class Program
    {
        // Lista de productos en memoria
        static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Camiseta", Precio = 25.00m },
            new Producto { Id = 2, Nombre = "Pantalón", Precio = 45.00m },
            new Producto { Id = 3, Nombre = "Zapatos", Precio = 80.00m },
            new Producto { Id = 4, Nombre = "Gorra", Precio = 15.00m }
        };

        // Lista para el carrito de compras
        static List<Producto> carrito = new List<Producto>();

        static void Main(string[] args)
        {
            bool ejecutando = true;

            while (ejecutando)
            {
                MostrarMenu();
                Console.Write("\nSelecciona una opción (1-5): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarProductos();
                        break;
                    case "2":
                        AgregarAlCarrito();
                        break;
                    case "3":
                        VerCarrito();
                        break;
                    case "4":
                        FinalizarCompra();
                        break;
                    case "5":
                        Console.WriteLine("\n👋 ¡Gracias por visitar la Mini Tienda! Vuelve pronto.\n");
                        ejecutando = false;
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción no válida. Por favor, intenta de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n=== MINI TIENDA ===");
            Console.WriteLine("1. Ver productos");
            Console.WriteLine("2. Agregar producto al carrito");
            Console.WriteLine("3. Ver carrito");
            Console.WriteLine("4. Finalizar compra");
            Console.WriteLine("5. Salir");
        }

        static void MostrarProductos()
        {
            Console.WriteLine("\n--- CATÁLOGO DE PRODUCTOS ---");
            foreach (var p in productos)
            {
                Console.WriteLine($"ID: {p.Id} | {p.Nombre} - ${p.Precio:0.00}");
            }
        }

        static void AgregarAlCarrito()
        {
            Console.Write("\nIngresa el ID del producto que deseas agregar: ");

            // Validamos que la entrada sea un número
            if (int.TryParse(Console.ReadLine(), out int idProducto))
            {
                // Buscamos el producto usando LINQ
                var productoEncontrado = productos.FirstOrDefault(p => p.Id == idProducto);

                if (productoEncontrado != null)
                {
                    carrito.Add(productoEncontrado);
                    Console.WriteLine($" ¡'{productoEncontrado.Nombre}' agregado al carrito!");
                }
                else
                {
                    Console.WriteLine(" Producto no encontrado. Verifica el ID.");
                }
            }
            else
            {
                Console.WriteLine(" Por favor, ingresa un número de ID válido.");
            }
        }

        static void VerCarrito()
        {
            Console.WriteLine("\n--- TU CARRITO ---");
            if (carrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                for (int i = 0; i < carrito.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {carrito[i].Nombre} - ${carrito[i].Precio:0.00}");
                }
                Console.WriteLine(new string('-', 20));

                // Sumamos el total usando LINQ
                Console.WriteLine($"TOTAL: ${carrito.Sum(p => p.Precio):0.00}");
            }
        }

        static void FinalizarCompra()
        {
            if (carrito.Count == 0)
            {
                Console.WriteLine("\n No puedes finalizar la compra porque tu carrito está vacío.");
            }
            else
            {
                decimal total = carrito.Sum(p => p.Precio);
                Console.WriteLine($"\n ¡Compra finalizada con éxito!");
                Console.WriteLine($"Has pagado un total de: ${total:0.00}");
                Console.WriteLine("¡Gracias por tu compra!");

                // Vaciamos el carrito
                carrito.Clear();
            }
        }
    }
}