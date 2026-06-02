using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // cualquier clase que implemente esta interfaz puede ser buscada en el sistema
    public interface IBuscable
    {
        // devuelve un string con los datos que se usan para buscar
        string ObtenerCriterioBusqueda();
    }
}
