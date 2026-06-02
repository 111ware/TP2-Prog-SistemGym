using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    // cualquier clase que implemente esta interfaz puede registrar pagos
    public interface IPagable
    {
        // recibe el monto y se encarga de registrar el pago correspondiente
        void RegistrarPago(decimal monto);
    }
}