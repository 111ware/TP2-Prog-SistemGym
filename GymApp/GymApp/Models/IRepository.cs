namespace GymApp.Models
{
    
    public interface IRepository<T> where T : IEntidad
    {
        
        List<T> LeerTodos();

        
        void GuardarTodos(List<T> items);

        
        void Agregar(T item);

        
        T BuscarPorId(int id);

        
        void Actualizar(T item);

        
        void Eliminar(int id);
    }
}