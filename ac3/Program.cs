using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Persona> personas = new List<Persona> 
        { 
            new Persona("Juan", 30), 
            new Persona("Pedro", 31), 
            new Persona("Miguel", 25), 
            new Persona("Luís", 36), 
            new Persona("José", 25), 
        }; 

        // Encuentra el nombre de la persona más joven en la lista personas.
        string nombrePersonaMasJoven = personas.OrderBy(p => p.Edad).First().Nombre;
        Console.WriteLine("Nombre de la persona más joven: " + nombrePersonaMasJoven);
        // No se como hacer que salga jose y miguel

        // Calcula la edad promedio de todas las personas en la lista personas.
        double edadPromedio = personas.Average(p => p.Edad);
        Console.WriteLine("Edad promedio de las personas: " + edadPromedio);

        // Encuentra todas las personas mayores de 25 años en la lista personas y ordénalas alfabéticamente por nombre.
        var personasMayoresDe25 = personas.Where(p => p.Edad > 25).OrderBy(p => p.Nombre);
        Console.WriteLine("Personas mayores de 25 años:");
        foreach (var persona in personasMayoresDe25)
        {
            Console.WriteLine(persona.Nombre);
        }

        // Encuentra todas las personas cuyo nombre comienza con la letra "M" en la lista personas y ordénalas por edad de forma descendente.
        var personasConNombreM = personas.Where(p => p.Nombre.StartsWith("M")).OrderByDescending(p => p.Edad);
        Console.WriteLine("Personas cuyo nombre comienza con 'M', ordenadas por edad descendente:");
        foreach (var persona in personasConNombreM)
        {
            Console.WriteLine(persona.Nombre);
        }

        // Verifica si todas las personas en la lista personas son mayores de 18 años.
        bool todasMayoresDe18 = personas.All(p => p.Edad > 18);
        Console.WriteLine("Todas las personas son mayores de 18 años: " + todasMayoresDe18);

        // Encuentra la persona más joven en la lista personas que tenga un nombre que contenga la letra "a".
        var personaMasJovenConA = personas.Where(p => p.Nombre.Contains("a")).OrderBy(p => p.Edad).First();
        Console.WriteLine("Nombre de la persona más joven cuyo nombre contiene la letra 'a': " + personaMasJovenConA.Nombre);

        // Agrupa las personas en la lista personas por su primera letra de nombre y muestra cuántas personas hay en cada grupo.
        // He echo uso de chat para hacer esta.
        var gruposPorLetra = personas.GroupBy(p => p.Nombre[0]).Select(g => new { Letra = g.Key, Cantidad = g.Count() });
        Console.WriteLine("Cantidad de personas por inicial de nombre:");
        foreach (var grupo in gruposPorLetra)
        {
            Console.WriteLine($"{grupo.Letra}: {grupo.Cantidad}");
        }

        // Encuentra el nombre de la persona más joven que tenga una edad impar en la lista personas.
        string nombrePersonaMasJovenEdadImpar = personas.Where(p => p.Edad % 2 != 0).OrderBy(p => p.Edad).First().Nombre;
        Console.WriteLine("Nombre de la persona más joven con edad impar: " + nombrePersonaMasJovenEdadImpar);

        // Elimina a todas las personas cuyas edades sean múltiplos de 5 de la lista personas y muestra la lista resultante.
        personas = personas.Where(p => p.Edad % 5 != 0).ToList();
        Console.WriteLine("Lista de personas después de eliminar las edades múltiplos de 5:");
        foreach (var persona in personas)
        {
            Console.WriteLine(persona.Nombre);
        }

        // Calcula la diferencia de edad entre la persona más joven y la persona más vieja en la lista personas.
        // No he conseguido hacer esta
    }
}

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}
