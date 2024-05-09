using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CRUD_Productos
{
    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=productos.db";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                InitializeDatabase(connection);

                bool continuar = true;
                while (continuar)
                {
                    MostrarMenu();
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            CrearProducto(connection);
                            break;
                        case "2":
                            ListarProductos(connection);
                            break;
                        case "3":
                            BuscarProductoPorNombre(connection);
                            break;
                        case "4":
                            ActualizarProducto(connection);
                            break;
                        case "5":
                            EliminarProducto(connection);
                            break;
                        case "6":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("\nSeleccione una operación:");
            Console.WriteLine("1 - Agregar un nuevo producto");
            Console.WriteLine("2 - Mostrar todos los productos");
            Console.WriteLine("3 - Buscar un producto por su nombre");
            Console.WriteLine("4 - Actualizar detalles de un producto");
            Console.WriteLine("5 - Eliminar un producto");
            Console.WriteLine("6 - Salir del programa");
            Console.WriteLine("|---------------------------------------|");
            Console.Write("Ingrese el número correspondiente a la operación que desea realizar: ");

        }

        static void InitializeDatabase(SQLiteConnection connection)
        {
            string createTableQuery = "CREATE TABLE IF NOT EXISTS Producto (Id INTEGER PRIMARY KEY, Nombre TEXT, Precio REAL, Cantidad INT)";
            using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
            {
                createTableCommand.ExecuteNonQuery();
            }
        }

        static void CrearProducto(SQLiteConnection connection)
        {
            Console.Write("Nombre ");
            string nombre = Console.ReadLine();

            Console.Write("Precio en euros ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Cantidad ");
            int cantidad = int.Parse(Console.ReadLine());

            string insertQuery = "INSERT INTO Producto (Nombre, Precio, Cantidad) VALUES (@nombre, @precio, @cantidad)";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@nombre", nombre);
                insertCommand.Parameters.AddWithValue("@precio", precio);
                insertCommand.Parameters.AddWithValue("@cantidad", cantidad);
                insertCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Agregado");
        }

        static void ListarProductos(SQLiteConnection connection)
        {
            string selectQuery = "SELECT * FROM Producto";
            ListarProductosDesdeQuery(connection, selectQuery);
        }

        static void BuscarProductoPorNombre(SQLiteConnection connection)
        {
            Console.Write("Nombre ");
            string nombre = Console.ReadLine();

            string selectQuery = "SELECT * FROM Producto WHERE Nombre LIKE @nombre";
            selectQuery = selectQuery.Replace("@nombre", $"'%{nombre}%'");
            ListarProductosDesdeQuery(connection, selectQuery);
        }

        static void ListarProductosDesdeQuery(SQLiteConnection connection, string query)
        {
            using (SQLiteCommand selectCommand = new SQLiteCommand(query, connection))
            using (SQLiteDataReader reader = selectCommand.ExecuteReader())
            {
                Console.WriteLine("\nListado de Productos:");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre {reader["Nombre"]}, Precio {reader["Precio"]}, Cantidad {reader["Cantidad"]}");
                }
            }
        }

        static void ActualizarProducto(SQLiteConnection connection)
        {
            Console.Write("ID del producto ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre ");
            string nombre = Console.ReadLine();

            Console.Write("Nuevo precio ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Nueva cantidad ");
            int cantidad = int.Parse(Console.ReadLine());

            string updateQuery = "UPDATE Producto SET Nombre = @nombre, Precio = @precio, Cantidad = @cantidad WHERE Id = @id";
            using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@nombre", nombre);
                updateCommand.Parameters.AddWithValue("@precio", precio);
                updateCommand.Parameters.AddWithValue("@cantidad", cantidad);
                updateCommand.Parameters.AddWithValue("@id", id);
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualizado");
                }
                else
                {
                    Console.WriteLine("Ese producto no esta registrado");
                }
            }
        }

        static void EliminarProducto(SQLiteConnection connection)
        {
            Console.Write("ID del producto ");
            int id = int.Parse(Console.ReadLine());

            string deleteQuery = "DELETE FROM Producto WHERE Id = @id";
            using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@id", id);
                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Eliminado");
                }
                else
                {
                    Console.WriteLine("Ese producto no esta registrado");
                }
            }
        }
    }
}
