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
        public double?[]? VectorEventos { get; } = new double?[6];
        public Equipo?[]? EquiposActuales { get; } = new Equipo?[4];
        public List<int> posiciones { get; } = new List<int> { 0, 1, 2, 3 };
        public Fila FilaAnterior { get; set; } = new Fila();

        public Fila generarFila(double reloj, double LimInf, double LimSup, double[] Prob, double[] tiempo, double AntesC, double DespuesC)
        {
            //va celda por celda y llama a los metodos responsables de generar sus datos en orden

            Fila FilaActual = new Fila();

            if (reloj != 0) { FilaActual = cargarSiguienteEvento(LimInf, LimSup, Prob, tiempo, AntesC, DespuesC); }
            else { generarLlegada(FilaActual, reloj);}

            FilaAnterior = FilaActual;

            return FilaActual;
        }

        public Fila cargarSiguienteEvento(double LimInf, double LimSup, double[] Prob, double[] tiempo, double AntesC, double DespuesC)
        {
            double reloj = (double)VectorEventos[0];
            int minIndice = 0;
            for (int i = 0; i < 6; i++)
            {
                if (VectorEventos[i] is not null && VectorEventos[i] < reloj)
                {
                        reloj = (double)VectorEventos[i];
                        minIndice = i;
                }
            }
            Fila FilaActual;

            switch (minIndice)
            {
                case 0:
                    FilaActual = cargarLlegadaEquipo(reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC);
                    break;
                case 1:

                    double menor = 0;
                    int indice = -1;

                    for (int i = 0; i < 4; i++)
                    {
                        if (EquiposActuales[i] is not null && EquiposActuales[i].Cambio is not null)
                        {
                            if (menor == 0 || EquiposActuales[i].Hora < menor)
                            {
                                menor = (double)EquiposActuales[i].Hora;
                                indice = i;
                            }
                        }
                    }

                    if (indice != -1) { FilaActual = cargarSuspensión(indice, reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC); }
                    else { FilaActual = cargarFinalizacionEvento(reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC); };
                    break;

                default:
                    //y que si no esta listo?? what then <- entonce no entra por aca??? whats not cliking here queen
                    //tiene que estar Diponible Y SER EL MENOR HORA DE TODO EL ARREGLO <- this is a made up problem. no importa en que orden decida ponerlo listo, solo en que orden los atiende
                    FilaActual = cargarReactivación(minIndice - 2, reloj, DespuesC);
                    break;
            }

            return FilaActual;
        }

        public Fila cargarLlegadaEquipo(double reloj, double LimInf, double LimSup, double[] Prob, double[] tiempo, double AntesC, double DespuesC)
        {
            GeneradorRNDDistribución generadorUniforme = new GeneradorRNDDistribución();
            Fila FilaActual = new Fila();
            Tecnico tecnico = FilaAnterior.Tecnico;
            Equipo equipo = new Equipo();

            FilaActual.Reloj = reloj;

            //Llegada de los equipos

            generarLlegada(FilaActual, reloj);

            int cola = FilaAnterior.Tecnico.Cola;

            // finalizacion

            if (FilaAnterior.Tecnico.Estado == "Ocupado") {

                FilaActual.ProxFinalizacion = FilaAnterior.ProxFinalizacion;

                // acepta el equipo
                if (cola < 3)
                {
                    tecnico.Cola = cola + 1;

                    equipo.Estado = "EA";
                    equipo.Hora = reloj;
                    int aux = posiciones[0];
                    EquiposActuales[aux] = equipo;
                    posiciones.RemoveAt(0);

                    FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados + 1;
                }
                else //no acepta el equipo
                {
                    FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;
                }
            }
            else //el tecnico estaba libre
            {
                equipo.Estado = "SA";
                equipo.Hora = reloj;

                EquiposActuales[posiciones[0]] = equipo;
                generarFinalización(posiciones[0], reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC, FilaActual);
                posiciones.RemoveAt(0);

                FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados + 1;
            }

            // si tan solo pudieras usar reflection para obtener una propiedad de cierto nombre y actualizarla... oh well
            tecnico.Estado = "Ocupado";

            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E3 = EquiposActuales[2];
            FilaActual.E4 = EquiposActuales[3];

            FilaActual.Tecnico = tecnico;
            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia;
            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes + 1;

            return FilaActual;
        }

        public Fila cargarFinalizacionEvento(double reloj, double LimInf, double LimSup, double[] Prob, double[] tiempo, double AntesC, double DespuesC)
        {
            //Se fija en el vector de equipos, si uno esa esperando, cambio el estado a SA y llamo al metodo generar tiempo de finalizacion

            Tecnico tecnico = new Tecnico();
            Fila FilaActual = new Fila();

            double menor = 0;
            int indice = -1;
            Equipo EquipoAAtender = null;
            double permanencia = 0;

            FilaActual.Reloj = reloj;

            FilaActual.ProxLlegada = FilaAnterior.ProxLlegada;

            tecnico.Estado = "Ocupado";
            int cola = FilaAnterior.Tecnico.Cola;

            for (int i = 0; i < 4; i++)
            {
                if(EquiposActuales[i] != null) {

                    if ((EquiposActuales[i].Estado == "EA" && EquipoAAtender?.Estado != "D") || EquiposActuales[i].Estado == "D")
                    {
                        if (menor == 0 || EquiposActuales[i].Hora < menor)
                        {
                            menor = (double)EquiposActuales[i].Hora;
                            indice = i;
                            EquipoAAtender = EquiposActuales[i];
                        }
                    }

                    if (EquiposActuales[i].Estado == "SA")
                    {
                        permanencia = (double)(reloj - EquiposActuales[i].Hora);
                        EquiposActuales[i] = null;
                        posiciones.Add(i);
                        VectorEventos[indice + 2] = null;
                    }
                }
            }

            if (indice != -1) {
                EquipoAAtender.Estado = "SA";
                generarFinalización(indice, reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC, FilaActual);
                tecnico.Cola = cola - 1;
            }
            else
            {
                tecnico.Estado = "Libre";
            }

            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E3 = EquiposActuales[2];
            FilaActual.E4 = EquiposActuales[3];

            FilaActual.Tecnico = tecnico;
            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos + 1;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia + permanencia;

            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes;
            FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;

            return FilaActual;
        }

        public Fila cargarSuspensión(int indice, double reloj, double LimInf, double LimSup, double[] Prob, double[] tiempo, double AntesC, double DespuesC) {

            Tecnico tecnico = new Tecnico();
            Fila FilaActual = new Fila();
            Equipo EquipoAAtender = new Equipo();

            double menor = 0;

            FilaActual.Reloj = reloj;

            FilaActual.ProxLlegada = FilaAnterior.ProxLlegada;

            int cola = FilaAnterior.Tecnico.Cola;

            EquiposActuales[indice].Estado = "T";

            for (int i = 0; i < 4; i++)
            {
                if (EquiposActuales[i] != null)
                {
                    if (((EquiposActuales[i].Estado == "EA" && EquipoAAtender?.Estado != "D") || EquiposActuales[i].Estado == "D"))
                    {
                        if (menor == 0 || EquiposActuales[i].Hora < menor)
                        {
                            menor = (double)EquiposActuales[i].Hora;
                            indice = i;
                            EquipoAAtender = EquiposActuales[i];
                        }
                    }
                }
            }
            

            if (indice > -1)
            {
                EquiposActuales[indice].Estado = "SA";
                generarFinalización(indice, reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC, FilaActual);
                tecnico.Cola = cola - 1;
                tecnico.Estado = "Ocupado";
            }
            else
            {
                tecnico.Estado = "Libre";
            }

            FilaActual.Tecnico = tecnico;

            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E3 = EquiposActuales[2];
            FilaActual.E4 = EquiposActuales[3];


            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia;
            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes;
            FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;

            return FilaActual;
        }

        public Fila cargarReactivación(int indice, double reloj, double DespuesC)
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
            }
            tecnico.Estado = "Ocupado";
            FilaActual.Tecnico = tecnico;

            FilaActual.E1 = EquiposActuales[0];
            FilaActual.E2 = EquiposActuales[1];
            FilaActual.E3 = EquiposActuales[2];
            FilaActual.E4 = EquiposActuales[3];

            FilaActual.EquiposAtendidos = FilaAnterior.EquiposAtendidos;
            FilaActual.AcumPermanencia = FilaAnterior.AcumPermanencia;
            FilaActual.EquiposSolicitantes = FilaAnterior.EquiposSolicitantes;
            FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados;

            return FilaActual;
        }

        public void generarFinalización(int indice, double reloj, double LimInf, double LimSup, double[] Prob, double[] tiempo, double AntesC, double DespuesC, Fila FilaActual)
        {

            Random generador = new Random();

            //Tipo Arreglo

            double rndTipoArreglo = generador.NextDouble();
            FilaActual.RNDTipoArreglo = rndTipoArreglo;

            string[] opciones = { "A", "B", "C", "E", "D" };
            Arreglo tipoArreglo = new Arreglo();
            tipoArreglo.generarTipo(rndTipoArreglo, Prob, opciones, tiempo);

            FilaActual.TipoArreglo = tipoArreglo.Tipo;

            //Finalización

            double rndFinalización = generador.NextDouble();
            FilaActual.RNDFinalizacion = rndFinalización;

            double finalizacion = tipoArreglo.calcularTiempoFinalización(rndFinalización, LimInf, LimSup);
            FilaActual.TiempoFinalizacion = finalizacion;

            double tiempoFin = reloj + finalizacion;

            if (tipoArreglo.Tipo == "C")
            {
                FilaActual.ProxFinalizacion = reloj + AntesC;
                EquiposActuales[indice].Cambio = tiempoFin - DespuesC;
                VectorEventos[indice + 2] = tiempoFin - DespuesC;
            }
            else
            {
                FilaActual.ProxFinalizacion = tiempoFin;
            }

            VectorEventos[1] = FilaActual.ProxFinalizacion;
        }

        public void generarLlegada(Fila FilaActual, double reloj)
        {
            Random generador = new Random();
            GeneradorRNDDistribución generadorDistribución = new GeneradorRNDDistribución();

            double rndLlegada = generador.NextDouble();
            FilaActual.RNDLlegada = rndLlegada;

            double tiempoLlegada = generadorDistribución.generarRNDUniforme(rndLlegada, 30, 90);
            FilaActual.TiempoLlegada = tiempoLlegada;

            double proxLlegada = reloj + tiempoLlegada;
            FilaActual.ProxLlegada = proxLlegada;

            VectorEventos[0] = FilaActual.ProxLlegada;
        }
    }

}
