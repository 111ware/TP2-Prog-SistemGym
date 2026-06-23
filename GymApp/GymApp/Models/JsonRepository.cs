using System.Text.Json;
using GymApp.Models;

namespace GymApp.Models  
{
    // clase generica que implementa IRepository, la T es el tipo de dato (Socio, Entrenador, etc)
    public class JsonRepository<T> : IRepository<T>
    {
        // guardo la ruta del archivo json donde se van a guardar los datos
        private readonly string _rutaArchivo;

        // constructor que recibe la ruta del archivo json
        public JsonRepository(string ruta)
        {
            _rutaArchivo = ruta;
        }

        // lee el archivo json y devuelve la lista de objetos, si no existe el archivo devuelve una lista vacia
        public List<T> LeerTodos()
        {
            if (!File.Exists(_rutaArchivo)) return new List<T>();
            string json = File.ReadAllText(_rutaArchivo);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        // convierte la lista a json y la escribe en el archivo
        public void GuardarTodos(List<T> items)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true }; // WriteIndented, no WriteIntendented
            string json = JsonSerializer.Serialize(items, opciones);
            File.WriteAllText(_rutaArchivo, json); // WriteAllText, no WritellText
        }
    }
}