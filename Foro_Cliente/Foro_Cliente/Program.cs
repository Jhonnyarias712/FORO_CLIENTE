using Foro_Cliente.models;
using NodaTime;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        agregarEstudiante();
        consultarEstudiantes();
        //consultarEstudiante();
        //modificarEstudiante();
        //eliminarEstudiante();
        //consultarEstudiantesFunciones();
    }

    //agregar estudiante
    public static void agregarEstudiante()
    {
        Console.WriteLine("Metodo agregar estudiante");
        //Conexion_bd context = new Conexion_bd();
        using (var context = new Conexion_bd())
        {

            Cliente std = new Cliente();
            //std.Id = 1;
            std.Nombre = "Jhonny";
            std.Apellido = "Arias";
            std.Direccion = "GYE";
            std.Telefono = "0989754898";
            std.FechaNacimiento = new DateTime(2000, 02, 11);
            std.Estado = true;
            context.Clientes.Add(std);
            context.SaveChanges();
            Console.WriteLine("Agregado");

            Console.WriteLine("Codigo: " + std.Id + " Nombre: " + std.Nombre);
        }
    }

    public static void consultarEstudiantes()
    {
        Console.WriteLine("Metodo consultar estudiantes");
        Conexion_bd context = new Conexion_bd();
        List<Cliente> listEstudiantes = context.Clientes.ToList();

        foreach (var item in listEstudiantes)
        {
            Console.WriteLine("Id: " + item.Id + " Nombre: " + item.Nombre+ "Apellida"+ item.Apellido
                + "Direccion="+ item.Direccion + "Telefono="+ item.Telefono + "FechaNacimiento="+ item.FechaNacimiento
                + "Estado"+ item.Estado);
        }
        Console.WriteLine("Consulta de datos del cliente completada.\n");
    }

    public static void consultarEstudiante()
    {
        Console.WriteLine("Metodo consultar estudiante por Id");
        Conexion_bd context = new Conexion_bd();
        Cliente std = new Cliente();
        std = context.Clientes.Find(1);

        Console.WriteLine("Codigo: " + std.Id + " Nombre: " + std.Nombre);

    }

    public static void modificarEstudiante()
    {
        Console.WriteLine("Metodo modificar estudiante");
        Conexion_bd context = new Conexion_bd();
        Cliente std = new Cliente();
        std = context.Clientes.Find(1);

        std.Nombre = "Danilo";
        context.SaveChanges();
        Console.WriteLine("Codigo: " + std.Id + " Nombre: " + std.Nombre);

    }

    public static void eliminarEstudiante()
    {
        Console.WriteLine("Metodo eliminar estudiante");
        Conexion_bd context = new Conexion_bd();
        Cliente std = new Cliente();
        std = context.Clientes.Find(1);
        context.Remove(std);
        context.SaveChanges();
        Console.WriteLine("Codigo: " + std.Id + " Nombre: " + std.Nombre);

    }
    public static void consultarEstudiantesFunciones()
    {
        Console.WriteLine("Metodo consultar estudiantes con el uso de funciones");
        Conexion_bd context = new Conexion_bd();
        List<Cliente> listEstudiantes;
        Console.WriteLine("Cantidad de registros: " + context.Clientes.Count());
        Cliente std = context.Clientes.First();

        Console.WriteLine("Primer elemento de la tabla:" + std.Id + "-" + std.Nombre);

        //listEstudiantes = context.Clientes.Where(s => s.ClienteId > 2 && s.Name == "Anita").ToList();

        //listEstudiantes = context.Clientes.Where(s => s.Name == "Patty" || s.Name == "Anita").ToList();

        listEstudiantes = context.Clientes.Where(s => s.Nombre.StartsWith("J")).ToList();

        /*
        var query = context.Clientes.GroupBy( s => s.Name) 
        .Select(g => new
        {
            Nombre = g.Key,
            Cantidad = g.Count()
        }). ToList();

        foreach (var result in query)
        {
            Console.WriteLine($"Nombre: {result.Nombre}, Cantidad: {result.Cantidad}");
        }
        */


        foreach (var item in listEstudiantes)
        {
            Console.WriteLine("Codigo: " + item.Id + " Nombre: " + item.Nombre);
        }


    }
}