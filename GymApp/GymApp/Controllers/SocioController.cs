using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Models;


namespace GymApp.Controllers
{
    // controla todo el ABM (dar de alta, baja o modificaciones) de los socios
    public class SocioController
    {
        private List<Socio> members;

        // preparo la lista para ir guardando a la gente que se anota
        public SocioController()
        {
            members = new List<Socio>();
        }

        // meto un socio nuevo a la lista y aviso que salio todo bien
        public void Agregar(Socio socio)
        {
            members.Add(socio);
            Console.WriteLine("Socio agregado correctamente.");
        }

        // recorro y muestro la info de todos los socios, si no hay nadie tiro un aviso
        public void Listar()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No hay socios registrados.");
                return;
            }
            foreach (Socio socio in members)
            {
                Console.WriteLine(socio.MostrarDatos());
            }
        }

        // busco al socio usando el criterio pasandolo a minusculas
        public Socio Buscar(string criterio)
        {
            foreach (Socio s in members)
            {
                if (s.ObtenerCriterioBusqueda().ToLower().Contains(criterio.ToLower()))
                {
                    return s;
                }
            }
            Console.WriteLine("Socio no encontrado.");
            return null;
        }

        // encuentro al socio por criterio y pido ver el estado de su pase
        public void VerMembresia(string criterio)
        {
            Socio member = Buscar(criterio);
            if (member != null)
            {
                member.VerMembresia();
            }
        }

        // busco al socio en la lista y si esta le agrego el pago del mes
        public void RegistrarPago(string criterio, decimal monto)
        {
            Socio member = Buscar(criterio);
            if (member != null)
            {
                member.RegistrarPago(monto);
            }
        }

        // registro la asistencia del socio buscando por criterio, si esta le agrega la asistencia del dia
        public void RegistrarAsistencia(string criteria)
        {
            Socio member = Buscar(criteria);
            if (member != null)
                member.RegistrarAsistencia();
        }
    }
}