// using System.Security.Cryptography;
// using Distribuidora;

// const int TAMA = 5;

// Tarea[] tareas = new Tarea[TAMA];

// var tareasPendientes = new List<Tarea>();

// var tareasRealizadas = new List<Tarea>();

// // 1.Crear Tareas

// crearTareas(TAMA, tareas);

// agregarTareas(TAMA, tareas, tareasPendientes);

// Console.WriteLine("\nTAREAS PENDIENTES: \n");

// mostrarLista(tareasPendientes);

// // 2.Mover tareas

// int seguirM = 0;
// do
// {
//     Console.WriteLine("\nIngrese el ID de la tarea realizada a mover: ");
//     int id = int.Parse(Console.ReadLine());

//     moverTareas(id, tareasPendientes, tareasRealizadas);

//     Console.WriteLine("\n\nQuiere mover otra tarea?      1.SI   |   2.NO  : ");
//     seguirM = int.Parse(Console.ReadLine());
// } while (seguirM == 1);


// Console.WriteLine("\nTAREAS PENDIENTES: \n");

// mostrarLista(tareasPendientes);

// Console.WriteLine("\nTAREAS REALIZADAS: \n");

// mostrarLista(tareasRealizadas);

// // 3.Buscar tareas

// Console.WriteLine("\n.Buscar tareas pendientes\n");
// int seguirB = 0;
// do
// {
//     Console.WriteLine("Ingrese la palabra de la tarea pendiente a buscar: ");
//     string palabra = Console.ReadLine();

//     if (buscarPalabraTarea(tareasPendientes, palabra).Count > 0)
//     {
//         Console.WriteLine("\nLa tarea se encuentra en Pendientes");
//         Console.WriteLine("\nTAREAS ENCONTRADAS: \n");
//         mostrarLista(buscarPalabraTarea(tareasPendientes, palabra));
//     }
//     else
//     {
//         Console.WriteLine("\nNo se encuentra la tarea en pendientes");
//     }

//     Console.WriteLine("\nQuiere buscar otra tarea?      1.SI   |   2.NO  : ");
//     seguirB = int.Parse(Console.ReadLine());

// } while (seguirB == 1);

// static void mostrarLista(List<Tarea> tareasPendientes)
// {
//     foreach (var tarea in tareasPendientes)
//     {
//         Console.WriteLine("\n-TAREA " + tarea.TareaID + "-\n");
//         Console.WriteLine("Descripcion: " + tarea.Descripcion);
//         Console.WriteLine("Duracion: " + tarea.Duracion);
//     }
// }

// static void crearTareas(int TAMA, Tarea[] tareas)
// {

//     Random dur = new Random();
//     string[] desc = { "tomar pedido", "reponer stock", "vender", "limpiar", "ordenar" };
//     Random rand = new Random();
//     int ind;

//     for (int i = 0; i < TAMA; i++)
//     {
//         tareas[i] = new Tarea();
//         tareas[i].TareaID = i;
//         ind = rand.Next(0, desc.Length);
//         tareas[i].Descripcion = desc[ind];
//         tareas[i].Duracion = dur.Next(1, 60);

//     }
// }

// static void agregarTareas(int TAMA, Tarea[] tareas, List<Tarea> lista)
// {
//     for (int i = 0; i < TAMA; i++)
//     {
//         lista.Add(tareas[i]);
//     }
// }

// static void moverTareas(int idBuscado, List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas)
// {
//     foreach (var tarea in tareasPendientes)
//     {
//         if (tarea.TareaID == idBuscado)
//         {
//             tareasRealizadas.Add(tarea);
//             tareasPendientes.Remove(tarea);
//             break;
//         }
//     }
// }

// static List<Tarea> buscarPalabraTarea(List<Tarea> lista, string palabra)
// {
//     var buscadas = new List<Tarea>();
//     palabra = palabra.ToLower();

//     foreach (var tarea in lista)
//     {
//         string[] palabras = tarea.Descripcion.Split(' ');
//         foreach (var pal in palabras)
//         {
//             if (pal == palabra)
//             {
//                 buscadas.Add(tarea);
//             }

//         }
//     }

//     return buscadas;
// }

// Ejercicio 2

using EspacioCalculadora;

Calculadora miCalculadora = new Calculadora(0);

var historial = new List<Operacion>();

int seguir = 0;

do
{
    Console.WriteLine("Elija la opcion:");
    Console.WriteLine("\n1.Sumar");
    Console.WriteLine("2.Restar");
    Console.WriteLine("3.Multiplicar");
    Console.WriteLine("4.Dividir");
    Console.WriteLine("5.Limpiar");
    int opcion = int.Parse(Console.ReadLine());

    double numero = 0;

    if (opcion != 5)
    {
        Console.WriteLine("\nIngrese un numero");
        numero = double.Parse(Console.ReadLine());
    }

    double resultadoAnterior = miCalculadora.Resultado;

    switch (opcion)
    {
        case 1:
            miCalculadora.Sumar(numero);
            historial.Add(new Operacion(resultadoAnterior, numero, Operacion.TipoOperacion.Suma, miCalculadora.Resultado));
            break;
        case 2:
            miCalculadora.Restar(numero);
            historial.Add(new Operacion(resultadoAnterior, numero, Operacion.TipoOperacion.Resta, miCalculadora.Resultado));
            break;
        case 3:
            miCalculadora.Multiplicar(numero);
            historial.Add(new Operacion(resultadoAnterior, numero, Operacion.TipoOperacion.Multiplicacion, miCalculadora.Resultado));
            break;
        case 4:
            miCalculadora.Dividir(numero);
            historial.Add(new Operacion(resultadoAnterior, numero, Operacion.TipoOperacion.Division, miCalculadora.Resultado));
            break;
        case 5:
            miCalculadora.Limpiar();
            historial.Clear();
            break;
        default:
            Console.WriteLine("\nOpcion incorrecta");
            break;
    }

    double rParcial = miCalculadora.Resultado;
    Console.WriteLine("\nResultado parcial: " + rParcial);

    Console.WriteLine("\nRealizar otra operacion? :  1. Si  2. No");
    seguir = int.Parse(Console.ReadLine());


} while (seguir == 1);

double resultado = miCalculadora.Resultado;

Console.WriteLine("\nRESULTADO: " + resultado);

// Mostrar historial

if (historial.Count() > 0)
{
    Console.WriteLine("\nHistorial de operaciones:");
    int i = 0;
    foreach (var operacion in historial)
    {
        Console.WriteLine("\nOPERACION " + (i + 1) + ": " + operacion.Tipo + " " + operacion.NuevoValor);
        Console.WriteLine("RESULTADO: " + operacion.Resultado);
        i++;
    }
}