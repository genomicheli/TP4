using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Backend.Euler
{
    internal class Euler
    { 
        public FilaEuler generarFilaEuler(double h, double S_inicial) { 

            FilaEuler Fila = new FilaEuler();

            double condInicialX = 0;
            double condInicialY = S_inicial;
            double fx = -68 - ((condInicialY * condInicialY) / condInicialY);
            double S_siguiente = condInicialY + (fx * h);

            Fila.Tiempo = condInicialX;
            Fila.Sectores = condInicialY;
            Fila.fx = fx;
            Fila.S_siguiente = S_siguiente;
            
            return Fila;
        }

        public FilaEuler generarFilaEuler(double h, double S_inicial, FilaEuler? FilaAnterior)
        {
            FilaEuler Fila = new FilaEuler();

                double tiempo = FilaAnterior.Tiempo + h;
                double sector = FilaAnterior.S_siguiente;
                double fx = -68 - ((sector * sector) / S_inicial);
                double S_siguiente = sector + (fx * h);

                Fila.Tiempo = tiempo;
                Fila.Sectores = sector;
                Fila.fx = fx;
                Fila.S_siguiente = S_siguiente;


            return Fila;
        }

        public double calcularTiempo(double h, double S_inicial)
        {
            FilaEuler fila = new FilaEuler();

            fila = generarFilaEuler(h, S_inicial);

            while (fila.Sectores > 0)
            {
                fila = generarFilaEuler(h, S_inicial, fila);
            }

            double tiempo = fila.Tiempo;

            return tiempo;
        }

        public double[] calcularTiempos(double h)
        {
            double[] tiempos = new double[3];

            tiempos[0] = calcularTiempo(h, 1000);
            tiempos[1] = calcularTiempo(h, 1500);
            tiempos[2] = calcularTiempo(h, 2000);

            return tiempos;
        }



    }
}
