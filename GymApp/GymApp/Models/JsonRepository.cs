using System.Text.Json;
using GymApp.Models;

namespace GymApp.Models
{
    // clase que implementa IRepository, la T es el tipo de dato (Socio, Entrenador, etc)
    public class JsonRepository<T> : IRepository<T> where T : IEntidad
    {
        // guardo la ruta del archivo json donde se van a guardar los datos
        private readonly string _rutaArchivo;

        // constructor que recibe la ruta del archivo json
        public JsonRepository(string ruta)
        {
            _rutaArchivo = ruta;
        }

        // lee el archivo json y devuelve la lista completa, si no existe devuelve lista vacia
        public List<T> LeerTodos()
        {
            if (!File.Exists(_rutaArchivo)) return new List<T>();
            string json = File.ReadAllText(_rutaArchivo);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        // escribe toda la lista en el archivo json, se usa internamente despues de cada operacion
        public void GuardarTodos(List<T> items)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(items, opciones);
            File.WriteAllText(_rutaArchivo, json);
        }

        // lee la lista, agrega el item nuevo y guarda
        public void Agregar(T item)
        {
            List<T> lista = LeerTodos();
            lista.Add(item);
            GuardarTodos(lista);
        }

        // lee la lista, busca por id y devuelve el item, si no lo encuentra devuelve null
        public T BuscarPorId(int id)
        {
            List<T> lista = LeerTodos();
            foreach (T item in lista)
            {
                if (item.Id == id)
                    return item;
            }
            return default;
        }

        // lee la lista, reemplaza el item con el mismo id y guarda
        public void Actualizar(T item)
        {
            List<T> lista = LeerTodos();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Id == item.Id)
                {
                    lista[i] = item;
                    break;
                }
            }
            GuardarTodos(lista);
        }

        // lee la lista, elimina el item con ese id y guarda
        public void Eliminar(int id)
        {
            List<T> lista = LeerTodos();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Id == id)
                {
                    lista.RemoveAt(i);
                    break;
                }
            }
            GuardarTodos(lista);
        }
    }
}