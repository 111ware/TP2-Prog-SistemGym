using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public interface IRepository<T> //Interfaz del repo con sus metodos
    {
        List<T> LeerTodos();
        void GuardarTodos(List<T> items);
    }
}
