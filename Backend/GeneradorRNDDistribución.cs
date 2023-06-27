using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace TP4.Backend
{
    internal class GeneradorRNDDistribución
    {
        public double generarRNDUniforme(double seed, double LimInf, double LimSup)
        {
            return LimInf + (seed * (LimSup - LimInf));
        }



        public string seleccionarOpcion(double rnd, double[] probabilidades, string[] opciones) {

            List<double> acumuladas =new List<double>();

            acumuladas.Clear();
            double acumulada = 0.0;

            foreach (var probabilidad in probabilidades)
            {
                acumulada += probabilidad;
                acumuladas.Add(acumulada);
            }

            for (int i = 0; i < acumuladas.Count; i++)
            {
                if (rnd < acumuladas[i])
                    return opciones[i];
            }
            return opciones[opciones.Length - 1];

        }
    }
}
