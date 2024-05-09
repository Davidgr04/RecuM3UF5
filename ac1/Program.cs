using System;
using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        RobotManager<Robot> robotManager = new RobotManager<Robot>("robots.db");
        RobotManager<Androide> androideManager = new RobotManager<Androide>("robots.db");

        int opcion;
        do
        {
            MostrarMenu();
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    robotManager.GenerarNuevoObjeto();
                    break;
                case 2:
                    robotManager.ReestablecerObjeto();
                    break;
                case 3:
                    robotManager.VerInformacionObjeto();
                    break;
                case 4:
                    robotManager.EliminarObjeto();
                    break;
                case 5:
                    robotManager.ListarObjetos();
                    break;
                case 6:
                    androideManager.GenerarNuevoObjeto();
                    break;
                case 7:
                    androideManager.ReestablecerObjeto();
                    break;
                case 8:
                    androideManager.VerInformacionObjeto();
                    break;
                case 9:
                    androideManager.EliminarObjeto();
                    break;
                case 10:
                    androideManager.ListarObjetos();
                    break;
                case 11:
                    Console.WriteLine("Deu");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 11);
    }

    static void MostrarMenu()
    {
        
        Console.WriteLine("Por favor, elija una opción:");
        Console.WriteLine("1. Fabricar un nuevo robot");
        Console.WriteLine("2. Restablecer un robot a su estado de fábrica");
        Console.WriteLine("3. Consultar información de un robot específico");
        Console.WriteLine("4. Eliminar un robot de la base de datos");
        Console.WriteLine("5. Mostrar todos los robots fabricados");
        Console.WriteLine("6. Fabricar un nuevo androide");
        Console.WriteLine("7. Restablecer un androide a su estado de fábrica");
        Console.WriteLine("8. Consultar información de un androide específico");
        Console.WriteLine("9. Eliminar un androide de la base de datos");
        Console.WriteLine("10. Mostrar todos los androides fabricados");
        Console.WriteLine("11. Salir del programa");
    }
}

class Robot
{
    public string Nombre { get; set; }
    public string Modelo { get; set; }

    public Robot(string nombre, string modelo)
    {
        Nombre = nombre;
        Modelo = modelo;
    }
}

class Androide
{
    public string Nombre { get; set; }
    public string Modelo { get; set; }

    public Androide(string nombre, string modelo)
    {
        Nombre = nombre;
        Modelo = modelo;
    }
}

class RobotManager<T>
{
    private readonly string connectionString;

    public RobotManager(string dbPath)
    {
        connectionString = $"Data Source={dbPath};Version=3;";
        CreateDatabase();
    }

    private void CreateDatabase()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "CREATE TABLE IF NOT EXISTS Robots (Nombre TEXT PRIMARY KEY, Modelo TEXT)";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void GenerarNuevoObjeto()
    {
        string nombre = GenerarNombreUnico();
        string[] modelos = { "R2D2", "C3PO", "BBB" };
        Random random = new Random();
        string modelo = modelos[random.Next(0, modelos.Length)];

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Robots (Nombre, Modelo) VALUES (@Nombre, @Modelo)";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Modelo", modelo);
                command.ExecuteNonQuery();
            }
        }

        Console.WriteLine($"Robot con nombre: {nombre} y modelo {modelo} creado");
    }

    public void ReestablecerObjeto()
    {
        Console.Write("Nombre");
        string nombre = Console.ReadLine();

        if (ExisteObjeto(nombre))
        {
            string nuevoNombre = GenerarNombreUnico();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Robots SET Nombre = @NuevoNombre WHERE Nombre = @Nombre";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"{nombre} a sido cambiado a: {nuevoNombre}");
        }
        else
        {
            Console.WriteLine($"{nombre} no existe");
        }
    }

    public void VerInformacionObjeto()
    {
        Console.Write("Nombre");
        string nombre = Console.ReadLine();

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT Nombre, Modelo FROM Robots WHERE Nombre = @Nombre";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string modelo = reader["Modelo"].ToString();
                        Console.WriteLine($"Nombre: {nombre} Modelo: {modelo}");
                    }
                    else
                    {
                        Console.WriteLine($"{nombre} no existe.");
                    }
                }
            }
        }
    }

    public void EliminarObjeto()
    {
        Console.Write("Nombre");
        string nombre = Console.ReadLine();

        if (ExisteObjeto(nombre))
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Robots WHERE Nombre = @Nombre";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"{nombre} eliminado");
        }
        else
        {
            Console.WriteLine($"{nombre} no existe.");
        }
    }

    public void ListarObjetos()
    {
        Console.WriteLine("Lista de objetos fabricados:");
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT Nombre, Modelo FROM Robots";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        string modelo = reader["Modelo"].ToString();
                        Console.WriteLine($"Nombre: {nombre}, Modelo: {modelo}");
                    }
                }
            }
        }
    }
    private bool ExisteObjeto(string nombre)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT COUNT(*) FROM Robots WHERE Nombre = @Nombre";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }
    private string GenerarNombreUnico()
    {
        Random random = new Random();
        string prefix;
        string number = random.Next(100, 999).ToString();

        if (typeof(T) == typeof(Robot))
        {
            string[] modelos = { "A", "B", "C", "D" };
            prefix = modelos[random.Next(0, modelos.Length)];
        }
        else if (typeof(T) == typeof(Androide))
        {
            string[] modelos = { "RR", "BB", "CC" };
            prefix = modelos[random.Next(0, modelos.Length)];
        }
        else
        {
            throw new InvalidOperationException("Tipo de objeto no válido");
        }

        return prefix + number;
    }
}
