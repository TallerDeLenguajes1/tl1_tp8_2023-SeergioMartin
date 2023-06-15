// See https://aka.ms/new-console-template for more information
using EspacioTarea;

internal class Program
{
    private static void Main(string[] args)
    {
        int opcion;
        string? respuesta;

        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();
    
        System.Console.WriteLine("Abriendo programa...");
        do
        {
            System.Console.WriteLine("\n************************Menu************************");
            System.Console.WriteLine("1. Cargar tareas");
            System.Console.WriteLine("2. Mover tareas Pendientes a realizadas");
            System.Console.WriteLine("3. Buscar tareas pendientes por descripcion");
            System.Console.WriteLine("4. Guardar sumario de horas trabajadas");
            System.Console.WriteLine("5. Listado de tareas pendientes");
            System.Console.WriteLine("6. Listado de tareas realizadas");
            System.Console.WriteLine("7. Salir");
            System.Console.WriteLine("****************************************************\n Seleccione una opcion:");
            respuesta = Console.ReadLine();
            int.TryParse(respuesta, out opcion);
            switch (opcion)
            {
                case 1:
                    CargarTareas(5, tareasPendientes); //CARGA ALEATORIA DE TAREAS
                    break;
                case 2:
                    MoverTareas(tareasPendientes, tareasRealizadas);
                    break;
                case 3:
                    string? texto;
                    System.Console.WriteLine("Ingrese descripcion de tareas a buscar:");
                    texto = Console.ReadLine();
                    MostrarListas(BuscarTareaPendiente(tareasPendientes, texto));
                    break;
                case 4:
                        if (tareasRealizadas.Count() != 0){
                            SumarioHorasTrabajadas(tareasRealizadas);
                            System.Console.WriteLine("Sumario guardado correctamente!!");   
                        }else{
                            System.Console.WriteLine("ERROR: No tiene horas trabajas que sumar!!");
                        }
                    break;
                case 5:
                    MostrarListas(tareasPendientes);
                    break;
                case 6:
                    MostrarListas(tareasRealizadas);
                    break;
                case 7:
                    System.Console.WriteLine("Saliendo...");
                    break;
                default:
                    System.Console.WriteLine("Opcion Invalida!!");
                    break;
            }
        } while (opcion != 7);
    }
    public static void CargarTareas(int nTareas, List<Tarea> pendientes){
        for (int i = 0; i < nTareas; i++)
        {
            System.Console.WriteLine("\n*********TAREA["+i+"]*********");
            var nuevaTarea = new Tarea();
            nuevaTarea.TareaId = i;
            System.Console.WriteLine("Ingrese descripcion: ");
            nuevaTarea.Descripcion = Console.ReadLine();
            nuevaTarea.Duracion = new Random().Next(10,100);
            pendientes.Insert(i, nuevaTarea);
        }
    }
    public static void MoverTareas(List<Tarea> pendientes, List<Tarea> realizadas){
        string? realizo;
        foreach (var tarea in pendientes)
        {
            System.Console.WriteLine("Realizo la Tarea["+tarea.TareaId+"]? Si o No");
            realizo = Console.ReadLine();
            if (realizo == "si")
            {
                System.Console.WriteLine("Mover tarea exitoso!!");
                realizadas.Add(tarea);
            }else{
                if (realizo == "no")
                {
                    System.Console.WriteLine("Tarea marcada como no realizada!!");
                }else{
                    System.Console.WriteLine("ERROR: No puede mover la tarea!!");
                }
            }
        }
        foreach (var tareaBorrar in realizadas)
        {
            pendientes.Remove(tareaBorrar);
        }
    }
    public static List<Tarea> BuscarTareaPendiente(List<Tarea> pendientes, string? desc){
        List<Tarea> tareasBuscadas = new List<Tarea>();
        Tarea tareaABuscar = new Tarea();
        foreach (var tareasPendientes in pendientes)
        {
            if (tareasPendientes.Descripcion == desc)
            {
                tareaABuscar = tareasPendientes;
                tareasBuscadas.Add(tareaABuscar);
            }
        }
        return tareasBuscadas;
    }
    public static void MostrarListas(List<Tarea> listaTareas){
        if (listaTareas.Count > 0)
        {
            foreach (var tarea in listaTareas)
            {
                tarea.MostrarTarea();
            }
        }else{
            System.Console.WriteLine("-----------------------------------");
            System.Console.WriteLine("No hay tareas en la lista");
            System.Console.WriteLine("-----------------------------------");

        }
    }
    public static void SumarioHorasTrabajadas(List<Tarea> realizadas){
        int horasTrabajadas = 0;
        StreamWriter archivo = new StreamWriter("sumario.txt", true);
        foreach (var tarea in realizadas)
        {
            horasTrabajadas += tarea.Duracion;
        }
        archivo.WriteLine("Sumario de horas trabajadas: "+horasTrabajadas+"");
        archivo.Close();
    }
}