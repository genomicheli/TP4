using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Backend
{
    internal class Controlador
    {
        public List<double> VectorEventos { get; }
        public List<Equipo> EquiposActuales { get; }
        public Fila FilaAnterior { get; }

        public void generarDatos(double reloj, int LimInf, int LimSup, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE, int AntesC, int DespuesC)
        {
            //va celda por celda y llama a los metodos responsables de generar sus datos en orden

            cargarSiguienteEvento(reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC);


        }
        private Arreglo seleccionarArreglo(double rnd, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE)
        {
            Arreglo arreglo = new Arreglo();

            //bajo mecanismos misteriosos, decidir el equipo que toca y setear su tiempo

            return arreglo;
        }

        public void cargarSiguienteEvento(Double reloj, int LimInf, int LimSup, Double ProbA, Double tiempoA, Double ProbB, Double tiempoB, Double ProbC, Double tiempoC, Double ProbD, Double tiempoD, Double ProbE, Double tiempoE, int AntesC, int DespuesC)
        {
            int min = VectorEventos.IndexOf(VectorEventos.Min());

            switch (min)
            {
                case 0:
                    cargarLlegadaEquipo(reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC);
                    break;
                case 1:
                    cargarFinalizaciónEvento()
                    break;
                default:
                    for ()

                        break;
            }

        }

        public void cargarLlegadaEquipo(Double reloj, int LimInf, int LimSup, Double ProbA, Double tiempoA, Double ProbB, Double tiempoB, Double ProbC, Double tiempoC, Double ProbD, Double tiempoD, Double ProbE, Double tiempoE, int AntesC, int DespuesC)
        {
            Random generador = new Random();
            GeneradorUniforme generadorUniforme = new GeneradorUniforme();
            Fila FilaActual = new Fila();
            Tecnico tecnico = new Tecnico();
            Equipo equipo = new Equipo();

            FilaActual.Reloj = reloj;

            //Llegada de los equipos

            Double rndLlegada = generador.NextDouble();
            FilaActual.RNDLlegada = rndLlegada;

            Double tiempoLlegada = generadorUniforme.generarRNDUniforme(rndLlegada, 30, 90);
            FilaActual.TiempoLlegada = tiempoLlegada;

            Double proxLlegada = reloj + tiempoLlegada;
            FilaActual.ProxLlegada = proxLlegada;


            //Tipo de Trabajo

            Double rndTipoArreglo = generador.NextDouble();
            FilaActual.RNDTipoArreglo = rndTipoArreglo;

            Arreglo tipoArreglo = seleccionarArreglo(rndTipoArreglo, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE);
            FilaActual.TipoArreglo = tipoArreglo.Tipo;


            //Finalización
            Double rndFinalización = generador.NextDouble();
            FilaActual.RNDFinalizacion = rndFinalización;

            Double finalizacion = tipoArreglo.calcularTiempoFinalización(rndFinalización, LimInf, LimSup);
            FilaActual.TiempoFinalizacion = finalizacion;

            Double tiempoFin = reloj + finalizacion;
            FilaActual.ProxFinalizacion = tiempoFin;

            tecnico.Cola += 1;
            FilaActual.Tecnico = tecnico;

            FilaActual.E1 = FilaAnterior.E1;
            FilaActual.E2 = FilaAnterior.E2;
            FilaActual.E3 = FilaAnterior.E3;
            FilaActual.E4 = FilaAnterior.E4;

            agregarEquipoIngresando(FilaActual);

            calcularEquiposAtendidos();
            calcularAcumPermanencia();
            calcularEquiposSolicitantes();
            calcularEquiposAceptados();

        }

        public void agregarEquipoIngresando(Fila FilaActual)
        {
            int cola = FilaAnterior.Tecnico.Cola;

            if (cola <= 3)
            {
            }
        }

        public void calc

    }
}
