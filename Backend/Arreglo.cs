using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Backend
{
    internal class Arreglo
    {
        public string Tipo { get; private set; }
        public double Tiempo { get; private set; }

        public void generarTipo(double rnd, double[] probabilidades, string[] opciones, double[] tiempos) {

            GeneradorRNDDistribución generadorDistribución = new GeneradorRNDDistribución();
            string tipo = generadorDistribución.seleccionarOpcion(rnd, probabilidades, opciones);

            this.Tipo = tipo;
            switch (tipo)
            {
                case "A":
                    Tiempo = tiempos[0];
                    break;
                case "B":
                    Tiempo = tiempos[1];
                    break;
                case "C":
                    Tiempo = tiempos[2];
                    break;
                case "D":
                    Tiempo = tiempos[3];
                    break;
                default:
                    Tiempo = tiempos[4];
                    break;

            }
        }
        public double calcularTiempoFinalización(double rndFinalizacion, double LimInf, double LimSup)
        {

            double minutos = new double();
            GeneradorRNDDistribución generador = new GeneradorRNDDistribución();
            minutos = generador.generarRNDUniforme(rndFinalizacion, Tiempo - LimInf, Tiempo + LimSup);

            return minutos;
        }
    }
}
