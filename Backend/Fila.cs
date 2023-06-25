using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Backend
{
    internal class Fila
    {
        public Double Reloj { get; set; }
        public Double RNDLlegada { get; set; }
        public Double TiempoLlegada { get; set; }
        public Double ProxLlegada { get; set; }
        public Double RNDTipoArreglo { get; set; }
        public string TipoArreglo { get; set; }
        public Double RNDFinalizacion { get; set; }
        public Double TiempoFinalizacion { get; set; }
        public Double ProxFinalizacion { get; set; }
        public Tecnico Tecnico { get; set; }
        public Equipo E1 { get; set; }
        public Equipo E2 { get; set; }
        public Equipo E3 { get; set; }
        public Equipo E4 { get; set; }
        public Double EquiposAtendidos { get; set; }
        public Double AcumPermanencia { get; set; }
        public Double EquiposSolicitantes { get; set; }
        public Double EquiposAceptados { get; set; }
    }
}
