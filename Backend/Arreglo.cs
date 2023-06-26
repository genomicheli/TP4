using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Backend
{
    internal class Arreglo
    {
        public string Tipo { get; set; }
        public double Tiempo { get; set; }

        public double calcularTiempoFinalización(double rndFinalizacion, int LimInf, int LimSup)
        {
            double minutos = new double();
            GeneradorRNDDistribución generador = new GeneradorRNDDistribución();
            //minutos = generador.generarRNDUniforme(rndFinalizacion, Tiempo - LimInf, Tiempo + LimSup);
            return minutos;
        }
    }
}
