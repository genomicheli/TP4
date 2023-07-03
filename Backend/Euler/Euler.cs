using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Backend.Euler
{
    internal class Euler
    { 

        public static FilaEuler generarFilaEuler(double h, double S_inicial) { 

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

        public static FilaEuler generarFilaEuler(double h, double S_inicial, FilaEuler? FilaAnterior)
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

        public static DataTable GenerarDataTable(double h, double S_inicial)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Tiempo", typeof(double));
            dataTable.Columns.Add("Sectores", typeof(double));
            dataTable.Columns.Add("fx", typeof(double));
            dataTable.Columns.Add("S_siguiente", typeof(double));

            FilaEuler filaActual = generarFilaEuler(h, S_inicial);
            dataTable.Rows.Add(filaActual.Tiempo, filaActual.Sectores, filaActual.fx, filaActual.S_siguiente);

            while (filaActual.Sectores > 0)
            {
                filaActual = generarFilaEuler(h, filaActual.S_siguiente, filaActual);
                dataTable.Rows.Add(filaActual.Tiempo, filaActual.Sectores, filaActual.fx, filaActual.S_siguiente);
            }

            return dataTable;
        }

        public static double ObtenerTiempo(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                DataRow ultimaFila = dataTable.Rows[dataTable.Rows.Count - 1];
                double tiempo = Convert.ToDouble(ultimaFila["Tiempo"]);
                return tiempo;
            }
            else
            {
                throw new Exception("El DataTable está vacío. No se puede obtener el tiempo de la última fila.");
            }
        }




    }
}
