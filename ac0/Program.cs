// Las partes que e usado Chat estan marcadas con comentarios en el codigo
class Program
{
   public  LinkedList<Videojuego> videojuegos = new LinkedList<Videojuego>();
    public  LinkedList<Cliente> clientes = new LinkedList<Cliente>();
    public  LinkedList<Empleado> empleados = new LinkedList<Empleado>();
    public void Main(string[] args)
    {
         Program programa = new Program(); //He echo uso de chat para crear una instancia de la clase Program pero no e podido ni con el chat
        bool opcion = true;
        while (opcion)
        {
            Console.WriteLine("|-----------------------------------------------|");
            Console.WriteLine("Elije una opcion");
            Console.WriteLine("(1) Alta Usuarios");
            Console.WriteLine("(2) Baja Usuarios");
            Console.WriteLine("(3) Alta Empleados");
            Console.WriteLine("(4) Baja Empleados");
            Console.WriteLine("(5) Alta Videojuegos");
            Console.WriteLine("(6) Baja Videojuegos");
            Console.WriteLine("(7) Listar Videojuegos Disponibles");
            Console.WriteLine("(8) Listar Videojuegos Alquilados");
            Console.WriteLine("(9) Listar Videojuegos Usuario");
            Console.WriteLine("(10) Listar Usuarios con Videojuegos Prestados");
            Console.WriteLine("(11) Listar Usuarios con Penalización");
            Console.WriteLine("(12) Salir");
            Console.WriteLine("|-----------------------------------------------|");
           
            try
            {
                int opciones = Convert.ToInt32(Console.ReadLine());

                switch (opciones)
                {
                    case 1:
                        AltaUsuarios();
                        break;

                    case 2:
                        BajaUsuarios();
                        break;

                    case 3:
                        AltaEmpleados();
                        break;

                    case 4:
                        BajaEmpleados();
                        break;

                    case 5:
                        AltaVideojuegos();
                        break;

                    case 6:
                        BajaVideojuegos();
                        break;

                    case 7:
                        ListarVideojuegosDisponibles();
                        break;

                    case 8:
                        ListarVideojuegosAlquilados();
                        break;

                    case 9:
                        ListarVideojuegosUsuarios();
                        break;

                    case 10:
                        ListarUsuariosJuegos();
                        break;

                    case 11:
                        UsuariosPenalizados();
                        break;

                    case 12:
                            Console.WriteLine("Saliendo del programa...");
                            opcion = false;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
        }
    }

    public void AltaUsuarios()
    {
        Console.Write("Nombre");
        string nombreUsuario = Console.ReadLine();
        Console.Write("Apellido");
        string apellidoUsuario = Console.ReadLine();
        Console.Write("Edad");
        int edadUsuario = Convert.ToInt32(Console.ReadLine());
        Console.Write("Dirección");
        string direccionUsuario = Console.ReadLine();
        Console.Write("Telefono");
        string telefonoUsuario = Console.ReadLine();
        Cliente nuevoCliente = new Cliente(nombreUsuario, apellidoUsuario, edadUsuario, direccionUsuario, telefonoUsuario);
        clientes.AddLast(nuevoCliente);
        Console.WriteLine("Cliente añadido");
    }
    public void BajaUsuarios()
{
    Console.Write("Nombre ");
    string nombreUsuario = Console.ReadLine();
    Cliente clienteAEliminar = BuscarClientePorNombre(nombreUsuario);
    if (clienteAEliminar != null)
    {
        clientes.Remove(clienteAEliminar);
        Console.WriteLine($"El usuario {nombreUsuario} ha sido eliminadi");
    }
    else
    {
        Console.WriteLine($"No se encontro un usuario con el nombre {nombreUsuario}");
    }
}

    public Cliente BuscarClientePorNombre(string nombre)

{
    foreach (Cliente cliente in clientes)
    {
        if (cliente.Nombre.ToLower() == nombre.ToLower())
        {
            return cliente;
        }
    }
    return null;  }

public void AltaEmpleados()
{
    Console.Write("Nombre: ");
    string nombreEmpleado = Console.ReadLine();
    Console.Write("Apellido: ");
    string apellidoEmpleado = Console.ReadLine();
    Console.Write("Edad: ");
    int edadEmpleado = Convert.ToInt32(Console.ReadLine());
    Console.Write("Dirección: ");
    string direccionEmpleado = Console.ReadLine();
    Console.Write("Categoría: ");
    string categoriaEmpleado = Console.ReadLine();
    Console.Write("Salario: ");
    int salarioEmpleado = Convert.ToInt32(Console.ReadLine());
    Empleado nuevoEmpleado = new Empleado(nombreEmpleado, apellidoEmpleado, edadEmpleado, direccionEmpleado, null, categoriaEmpleado, salarioEmpleado);
    empleados.AddLast(nuevoEmpleado);
    Console.WriteLine("Empleado añadido con éxito.");
}

    public void BajaEmpleados()
    {
    Console.Write("Nombre: ");
    string nombreEmpleado = Console.ReadLine().ToLower();  
    Empleado empleadoAEliminar = null;
    foreach (Empleado empleado in empleados)
    {
        if (empleado.Nombre.ToLower() == nombreEmpleado)
        {
            empleadoAEliminar = empleado;
            break;  
        }
    }
    if (empleadoAEliminar != null)
    {
        empleados.Remove(empleadoAEliminar);
        Console.WriteLine($"El empleado {nombreEmpleado} ha sido eliminado");
    }
    else
    {
        Console.WriteLine($"No se encontro un empleado con el nombre {nombreEmpleado}");
    }
}

    public void AltaVideojuegos()
    {
        Console.Write("Título");
        string titulo = Console.ReadLine();
        Console.Write("Año de lanzamiento");
        int fechaLanzamiento = Convert.ToInt32(Console.ReadLine());
        Console.Write("Género");
        string genero = Console.ReadLine();
        Console.Write("Compañía fundadora");
        string compania = Console.ReadLine();
        Videojuego nuevoVideojuego = new Videojuego(titulo, fechaLanzamiento, genero, compania);
        videojuegos.AddLast(nuevoVideojuego);
        Console.WriteLine("Videojuego añadido");
    }
    public void BajaVideojuegos()
    {
        Console.Write("Título");
        string tituloVideojuego = Console.ReadLine();

    Videojuego videojuegoAEliminar = BuscarVideojuegoPorTitulo(tituloVideojuego);
    if (videojuegoAEliminar != null)
    {
        videojuegos.Remove(videojuegoAEliminar);
        Console.WriteLine($"El videojuego '{tituloVideojuego}' ha sido eliminado");
    }
    }
    // BuscarVideojuegoPorTitulo esta echo con chat 
    public Videojuego BuscarVideojuegoPorTitulo(string titulo)
{
    foreach (Videojuego videojuego in videojuegos)
    {
        if (videojuego.Titulo.Equals(titulo))
        {
            return videojuego;
        }
    }
    return null;  
}
    public void ListarVideojuegosDisponibles()
    {
    Console.WriteLine("Videojuegos disponibles:");
    foreach (Videojuego videojuego in videojuegos)
    {
        if (!EstaAlquilado(videojuego))
        {
            Console.WriteLine($"Título: {videojuego.Titulo}, Año de lanzamiento: {videojuego.FechaLanzamiento}, Género: {videojuego.Genero}, Compañía fundadora: {videojuego.Compania}");
        }
    }
}
public bool EstaAlquilado(Videojuego videojuego)
{
    foreach (Cliente cliente in clientes)
    {
        if (cliente.Videojuegos.Contains(videojuego))
        {
            return true;  
        }
    }
    return false;  
}
    public void ListarVideojuegosAlquilados()
   {
    Console.WriteLine("Videojuegos alquilados:");

    foreach (Cliente cliente in clientes)
    {
        foreach (Videojuego videojuego in cliente.Videojuegos)
        {
            Console.WriteLine($"Cliente: {cliente.Nombre} {cliente.Apellido}, Título: {videojuego.Titulo}, Año de lanzamiento: {videojuego.FechaLanzamiento}, Género: {videojuego.Genero}, Compañía fundadora: {videojuego.Compania}");
        }
    }
    }
    public void ListarVideojuegosUsuarios()
    {
        Console.Write("Nombre");
        string nombreUsuario = Console.ReadLine();
        bool usuarioEncontrado = false;
        foreach (Cliente cliente in clientes)
    {
        if (cliente.Nombre.Equals(nombreUsuario))
        {
            usuarioEncontrado = true;
            Console.WriteLine($"Videojuegos de {cliente.Nombre} {cliente.Apellido}:");
            foreach (Videojuego videojuego in cliente.Videojuegos)
            {
                Console.WriteLine($"Título: {videojuego.Titulo}, Año de lanzamiento: {videojuego.FechaLanzamiento}, Género: {videojuego.Genero}, Compañía fundadora: {videojuego.Compania}");
            }

            break;  
        }
    }

    if (!usuarioEncontrado)
    {
        Console.WriteLine($"No encontramos a {nombreUsuario}.");
    }
}

    public void ListarUsuariosJuegos()
    {
    Console.WriteLine("Usuarios con videojuegos prestados:");
    foreach (Cliente cliente in clientes)
    {
        if (cliente.Videojuegos.Count > 0)
        {
            Console.WriteLine($"{cliente.Nombre} {cliente.Apellido} tiene estos:");

            foreach (Videojuego videojuego in cliente.Videojuegos)
            {
                Console.WriteLine($"Título: {videojuego.Titulo}, Año de lanzamiento: {videojuego.FechaLanzamiento}, Género: {videojuego.Genero}, Compañía fundadora: {videojuego.Compania}");
            }

            Console.WriteLine();
        }
    }
    }
    public void UsuariosPenalizados()
    {
    Console.WriteLine("Usuarios con penalización");

    foreach (Cliente cliente in clientes)
    {
        if (cliente.TienePenalizacion())
        {
            Console.WriteLine($"{cliente.Nombre} {cliente.Apellido} tiene penalizacion");
        }
    }
    }
}
class Videojuego
{
    public string Titulo { get; set; }
    public int FechaLanzamiento { get; set; }
    public string Genero { get; set; }
    public string Compania { get; set; }
    public DateTime FechaAlquiler { get; set; }
    public Videojuego(string titulo, int fechaLanzamiento, string genero, string compania)
    {
        Titulo = titulo;
        FechaLanzamiento = fechaLanzamiento;
        Genero = genero;
        Compania = compania;
        FechaAlquiler = DateTime.Now;
    }
    public int DiasAlquilados()
    {
        TimeSpan diferencia = DateTime.Now - FechaAlquiler;
        return diferencia.Days;
    }
   public int DiasTranscurridos()
    {
    DateTime fechaActual = DateTime.Now;
    TimeSpan diferencia = fechaActual - FechaAlquiler;
    return diferencia.Days;
    }
}
class Cliente
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Videojuego> Videojuegos { get; set; }
    public Cliente(string nombre, string apellido, int edad, string direccion, string telefono)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Direccion = direccion;
        Telefono = telefono;
        Videojuegos = new List<Videojuego>();
    }
    public void AddGame(Videojuego juego)
    {
        Videojuegos.Add(juego);
        Console.WriteLine($"El juego '{juego.Titulo}' se ha correctamente añadido a la coleccion de {Nombre}");
    }
    public bool TienePenalizacion()
    {
    foreach (Videojuego videojuego in Videojuegos)
    {
        if (videojuego.DiasTranscurridos() > 15)
        {
            return true;
        }
    }
    return false;
    }
}
class Empleado
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Categoria { get; set; }
    public int Salario { get; set; }

    public Empleado(string nombre, string apellido, int edad, string direccion, string telefono, string categoria, int salario)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Direccion = direccion;
        Telefono = telefono;
        Categoria = categoria;
        Salario = salario;
    }
}
// Las partes que e usado Chat estan marcadas con comentarios en el codigo