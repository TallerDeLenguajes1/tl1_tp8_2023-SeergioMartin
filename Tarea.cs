namespace EspacioTarea
{
    public class Tarea
    {
        private int tareaId;
        private string? descripcion;
        private int duracion;

        public int TareaId{
            get => tareaId;
            set => tareaId = value;
        }
        public string? Descripcion { 
            get => descripcion; 
            set => descripcion = value; 
        }
        public int Duracion { 
            get => duracion; 
            set => duracion = value; 
        }

        public void MostrarTarea(){
            System.Console.WriteLine(">>>>>>>>>>>>>>");
            Console.WriteLine($"---ID de la tarea: {TareaId}");
            Console.WriteLine($"---Descripción: {descripcion}");
            Console.WriteLine($"---Duración: {duracion}\n");
        }
    }
}