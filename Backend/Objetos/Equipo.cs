using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Backend.Objetos
{
    internal class Equipo
    {
        public string Estado { get; set; }
        public Double Hora { get; set; }
        public Double Cambio { get; set; }
        public void siguienteEvento()
        {

            string evento = "";

            switch (Estado)
            {
                case "SA":
                    evento = "En Segundo Plano";
                    break;
                case "T":
                    evento = "Reactivar";
                    break;

            }

        }

    }
}
