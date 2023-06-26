using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Backend.Objetos;

namespace TP4.Backend
{
    internal class Fila
    {
        public double Reloj { get; set; } = 0;
        public double? RNDLlegada { get; set; }
        public double? TiempoLlegada { get; set; }
        public double? ProxLlegada { get; set; }
        public double? RNDTipoArreglo { get; set; }
        public string? TipoArreglo { get; set; }
        public double? RNDFinalizacion { get; set; }
        public double? TiempoFinalizacion { get; set; }
        public double? ProxFinalizacion { get; set; }
        public Tecnico Tecnico { get; set; } = new Tecnico();
        public Equipo? E1 { get; set; }
        public Equipo? E2 { get; set; }
        public Equipo? E3 { get; set; }
        public Equipo? E4 { get; set; }
        public double EquiposAtendidos { get; set; } = 0;
        public double AcumPermanencia { get; set; } = 0;
        public double EquiposSolicitantes { get; set; } = 0;
        public double EquiposAceptados { get; set; } = 0;
    }
}
