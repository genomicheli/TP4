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
        public Equipo?[]? EquiposActuales { get; }
        public List<int> posiciones { get; }
        public Fila FilaAnterior { get; }

        public void generarDatos(double reloj, int LimInf, int LimSup, double[] Prob, double[] tiempo, int AntesC, int DespuesC)
        {
            //va celda por celda y llama a los metodos responsables de generar sus datos en orden

            cargarSiguienteEvento(LimInf, LimSup, Prob, tiempo, AntesC, DespuesC);


        }

        public void cargarSiguienteEvento(int LimInf, int LimSup, double[] Prob, double[] tiempo, int AntesC, int DespuesC)
        {
            double reloj = VectorEventos.Min();
            int minIndice = VectorEventos.IndexOf(reloj); //cuando paso el indice tengo que restar 2!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Fila FilaActual = new Fila();

            switch (minIndice)
            {
                case 0:
                    FilaActual = cargarLlegadaEquipo(reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC);
                    break;
                case 1:
                    if (FilaAnterior.TipoArreglo == "C") { FilaActual = cargarSuspensión(reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC); }
                    else { FilaActual = cargarFinalizacionEvento(reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC); };
                    break;
                default:
                    //y que si no esta listo?? what then <- entonce no entra por aca??? whats not cliking here queen
                    //tiene que estar Diponible Y SER EL MENOR HORA DE TODO EL ARREGLO <- this is a made up problem. no importa en que orden decida ponerlo listo, solo en que orden los atiende
                    FilaActual = cargarReactivación(minIndice - 2, reloj, DespuesC);
                    break;
            }

        }

        //todos los metodos se deberian llamar igual y diferenciarse unicamente por sus parametros???

        public Fila cargarLlegadaEquipo(double reloj, int LimInf, int LimSup, double[] Prob, double[] tiempo, int AntesC, int DespuesC)
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

                    EquiposActuales[posiciones[0]] = equipo;
                    posiciones.RemoveAt(0);

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
                generarFinalización(posiciones[0], reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC, FilaActual);
                tecnico.Estado = "Ocupado";
                equipo.Estado = "SA";
                equipo.Hora = reloj;
                EquiposActuales[posiciones[0]] = equipo;
                posiciones.RemoveAt(0);

                FilaActual.EquiposAceptados = FilaAnterior.EquiposAceptados + 1;
            }

            // si tan solo pudieras usar reflection para obtener una propiedad de cierto nombre y actualizarla... oh well

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
        public Fila cargarFinalizacionEvento(double reloj, int LimInf, int LimSup, double[] Prob, double[] tiempo, int AntesC, int DespuesC)
        {
            //Se fija en el vector de equipos, si uno esa esperando, cambio el estado a SA y llamo al metodo generar tiempo de finalizacion

            Tecnico tecnico = new Tecnico();
            Fila FilaActual = new Fila();

            double menor = 0;
            int indice = -1;
            double permanencia = reloj;

            for (int i = 0; i < 4; i++)
            {
                if(EquiposActuales[i] is not null) {
                    if (EquiposActuales[i].Estado == "SA")
                    {
                        permanencia += EquiposActuales[i].Hora;
                        EquiposActuales[i] = null;
                        posiciones.Add(i);
                    }
                    //si tan solo hubiera un objeto queue FIFO que resolviera esto... oh well.
                    //las D deberian tener prioridad... i will kill mysefl
                    if (((EquiposActuales[i].Estado == "EA" && EquiposActuales[indice].Estado == "D") || EquiposActuales[i].Estado == "D"))
                    {
                        if (menor == 0 || EquiposActuales[i].Hora < menor)
                        {
                            menor = EquiposActuales[i].Hora;
                            indice = i;
                        }
                    }
                }

            }

            if (indice > -1) {
                EquiposActuales[indice].Estado = "SA";
                generarFinalización(indice, reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC, FilaActual);
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

        public Fila cargarSuspensión(double reloj, int LimInf, int LimSup, double[] Prob, double[] tiempo, int AntesC, int DespuesC) {

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
                generarFinalización(indice, reloj, LimInf, LimSup, Prob, tiempo, AntesC, DespuesC, FilaActual);
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

        public Fila cargarReactivación(int indice, double reloj, int DespuesC)
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

        public void generarFinalización(int indice, double reloj, int LimInf, int LimSup, double[] Prob, double[] tiempo, int AntesC, int DespuesC, Fila FilaActual)
        {

            Random generador = new Random();
            GeneradorRNDDistribución generadorDistribución = new GeneradorRNDDistribución();

            //Tipo Arreglo

            Double rndTipoArreglo = generador.NextDouble(); // No dejarias que se genere un numero fuera del rango entre 0 y 1... cierto?
            FilaActual.RNDTipoArreglo = rndTipoArreglo;

            string[] opciones = { "A", "B", "C", "E", "D" };
            Arreglo tipoArreglo = new Arreglo();
            tipoArreglo.generarTipo(rndTipoArreglo, Prob, opciones, tiempo);
                
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
