using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TP4.Backend.Objetos;

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

            cargarSiguienteEvento(LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC);


        }
        private Arreglo seleccionarArreglo(double rnd, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE)
        {
            Arreglo arreglo = new Arreglo();
            string tipoArreglo = "";
            double tiempo = 0;

            //bajo mecanismos misteriosos, decidir el equipo que toca y setear su tiempo
            //hello como carajo hago esto??

            arreglo.Tipo = tipoArreglo;
            arreglo.Tiempo = tiempo;

            return arreglo;
        }

        public void cargarSiguienteEvento(int LimInf, int LimSup, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE, int AntesC, int DespuesC)
        {
            double reloj = VectorEventos.Min();
            int minIndice = VectorEventos.IndexOf(reloj); //cuando paso el indice tengo que restar 2!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Fila FilaActual = new Fila();

            switch (minIndice)
            {
                case 0:
                    FilaActual = cargarLlegadaEquipo(reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC);
                    break;
                case 1:
                    if (FilaAnterior.TipoArreglo == "C") { FilaActual = cargarSuspensión(reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC); }
                    else { FilaActual = cargarFinalizacionEvento(reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC); };
                    break;
                default:
                    FilaActual = cargarReactivación(minIndice-2, reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC);
                    break;
            }

        }

        //todos los metodos se deberian llamar igual y diferenciarse unicamente por sus parametros???

        public Fila cargarLlegadaEquipo(double reloj, int LimInf, int LimSup, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE, int AntesC, int DespuesC)
        {
            Random generador = new Random();
            GeneradorRNDDistribución generadorUniforme = new GeneradorRNDDistribución();
            Fila FilaActual = new Fila();
            Tecnico tecnico = FilaAnterior.Tecnico;
            Equipo equipo = new Equipo();

            FilaActual.Reloj = reloj;

            //Llegada de los equipos

            Double rndLlegada = generador.NextDouble();
            FilaActual.RNDLlegada = rndLlegada;

            Double tiempoLlegada = generadorUniforme.generarRNDUniforme(rndLlegada, 30, 90);
            FilaActual.TiempoLlegada = tiempoLlegada;

            Double proxLlegada = reloj + tiempoLlegada;
            FilaActual.ProxLlegada = proxLlegada;

            int cola = FilaAnterior.Tecnico.Cola;

            if (FilaAnterior.Tecnico.Estado == "Ocupado") {

                FilaActual.ProxFinalizacion = FilaAnterior.ProxFinalizacion;

                if (cola <= 2)
                {
                    tecnico.Cola += 1;

                    equipo.Estado = "EA";
                    equipo.Hora = reloj;

                    EquiposActuales.Add(equipo);

                    FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados + 1;
                }
                else
                {
                    FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;
                }

            }
            else
            {
                //llamar a cargarFinalizacion

                tecnico.Estado = "Ocupado";
                equipo.Estado = "SA";
                equipo.Hora = reloj;
                EquiposActuales.Add(equipo);

                FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados + 1;
            }

            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E2 = EquiposActuales[2];
            FilaActual.E3 = EquiposActuales[3];

            FilaActual.Tecnico = tecnico;
            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia;
            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes + 1;

            return FilaActual;
        }
        public Fila cargarFinalizacionEvento(double reloj, int LimInf, int LimSup, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE, int AntesC, int DespuesC)
        {
            //Se fija en el vector de equipos, si uno esa esperando, cambio el estado a SA y llamo al metodo generar tiempo de finalizacion

            Tecnico tecnico = new Tecnico();
            Fila FilaActual = new Fila();

            double menor = 0;
            int indice = -1;
            double permanencia = reloj;

            for (int i = 0; i < 4; i++)
            {
                if (EquiposActuales[i].Estado == "SA")
                {
                    permanencia += EquiposActuales[i].Hora;
                    EquiposActuales.Remove(EquiposActuales[i]);
                }

                if (EquiposActuales[i].Estado=="EA") {
                    if(menor == 0 || EquiposActuales[i].Hora < menor)
                    {
                        menor = EquiposActuales[i].Hora;
                        indice = i;
                    }
                }  
            }

            if (indice > -1) {
                EquiposActuales[indice].Estado = "SA";
                generarFinalización(indice, reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC, FilaActual);
                tecnico.Cola -= 1;
            }
            else
            {
                tecnico.Estado = "Libre";
            }


            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E2 = EquiposActuales[2];
            FilaActual.E3 = EquiposActuales[3];

            FilaActual.Tecnico = tecnico;
            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos + 1;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia + permanencia;

            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes;
            FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;

            return FilaActual;
        }

        public Fila cargarSuspensión(double reloj, int LimInf, int LimSup, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE, int AntesC, int DespuesC) {

            Tecnico tecnico = new Tecnico();
            Fila FilaActual = new Fila();

            double menor = 0;
            int indice = 0;

            EquiposActuales[indice].Estado = "T";

            for (int i = 0; i < 4; i++)
            {
                if (EquiposActuales[i].Estado == "EA")
                {
                    if (menor == 0 || EquiposActuales[i].Hora < menor)
                    {
                        menor = EquiposActuales[i].Hora;
                        indice = i;
                    }
                }
            }

            if (indice > -1)
            {
                EquiposActuales[indice].Estado = "SA";
                generarFinalización(indice, reloj, LimInf, LimSup, ProbA, tiempoA, ProbB, tiempoB, ProbC, tiempoC, ProbD, tiempoD, ProbE, tiempoE, AntesC, DespuesC, FilaActual);
            }
            else
            {
                tecnico.Estado = "Libre";
            }

            FilaActual.Tecnico = tecnico;

            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E2 = EquiposActuales[2];
            FilaActual.E3 = EquiposActuales[3];


            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia;
            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes;
            FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;

            return FilaActual;

        }

        public Fila cargarReactivación(int indice, double reloj, int LimInf, int LimSup, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE, int AntesC, int DespuesC)
        {
            Tecnico tecnico = new Tecnico();
            tecnico.Cola = FilaAnterior.Tecnico.Cola;

            Fila FilaActual = new Fila();

            FilaActual.Reloj = reloj;

            FilaActual.ProxLlegada = FilaAnterior.ProxLlegada;

            if (FilaAnterior.Tecnico.Estado == "Ocupado")
            {
                EquiposActuales[indice].Estado = "D";
                EquiposActuales[indice].Cambio = FilaAnterior.ProxFinalizacion;
                FilaActual.ProxFinalizacion = FilaAnterior.ProxFinalizacion;
            }
            else
            {
                EquiposActuales[indice].Estado = "SA";
                FilaActual.ProxFinalizacion = EquiposActuales[indice].Cambio + DespuesC;
                tecnico.Estado = "Ocupado";
            }

            FilaActual.Tecnico = tecnico;

            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E2 = EquiposActuales[2];
            FilaActual.E3 = EquiposActuales[3];

            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia;
            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes;
            FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;

            return FilaActual;
        }

        public void generarFinalización(int indice, double reloj, int LimInf, int LimSup, double ProbA, double tiempoA, double ProbB, double tiempoB, double ProbC, double tiempoC, double ProbD, double tiempoD, double ProbE, double tiempoE, int AntesC, int DespuesC, Fila FilaActual)
        {
            Random generador = new Random();
            //Tipo Arreglo

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

            if (tipoArreglo.Tipo != "C")
            {
                FilaActual.ProxFinalizacion = tiempoFin;
            }
            else
            {
                FilaActual.ProxFinalizacion += reloj + AntesC;
                EquiposActuales[indice].Hora = finalizacion - DespuesC;
            }
            
        }
    }

}
