using System.Security.Cryptography;
using Distribuidora;

const int TAMA = 5;

Tarea[] tareas = new Tarea[TAMA];

var tareasPendientes = new List<Tarea>();

var tareasRealizadas = new List<Tarea>();

crearTareas(TAMA, tareas);

agregarTareas(TAMA, tareas, tareasPendientes);

Console.WriteLine("\nTAREAS PENDIENTES: \n");

mostrarLista(tareasPendientes);

Console.WriteLine("\nIngrese el ID de la tarea realizada a mover: ");
int id = int.Parse(Console.ReadLine());

moverTareas(id, tareasPendientes, tareasRealizadas);

Console.WriteLine("\nTAREAS PENDIENTES: \n");

mostrarLista(tareasPendientes);

Console.WriteLine("\nTAREAS REALIZADAS: \n");

mostrarLista(tareasRealizadas);

static void mostrarLista(List<Tarea> tareasPendientes)
{
    foreach (var tarea in tareasPendientes)
    {
        Console.WriteLine("\n-TAREA " + tarea.TareaID + "-\n");
        Console.WriteLine("Descripcion: " + tarea.Descripcion);
        Console.WriteLine("Duracion: " + tarea.Duracion);
    }
}

static void crearTareas(int TAMA, Tarea[] tareas)
{

    Random dur = new Random();
    string[] desc = { "Bebidas", "Electronica", "Carnes", "Lacteos", "Limpieza" };
    Random rand = new Random();
    int ind;

    for (int i = 0; i < TAMA; i++)
    {
        tareas[i] = new Tarea();
        tareas[i].TareaID = i;
        ind = rand.Next(0, desc.Length);
        tareas[i].Descripcion = desc[ind];
        tareas[i].Duracion = dur.Next(1, 60);

    }
}

static void agregarTareas(int TAMA, Tarea[] tareas, List<Tarea> lista)
{
    for (int i = 0; i < TAMA; i++)
    {
        lista.Add(tareas[i]);
    }
}

static void moverTareas(int idBuscado, List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas)
{
    foreach (var tarea in tareasPendientes)
    {
        if (tarea.TareaID == idBuscado)
        {
            tareasPendientes.Add(tarea);
            tareasRealizadas.Remove(tarea);
            break;
        }
    }
}