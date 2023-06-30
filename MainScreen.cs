using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4.Backend;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TP4
{
    public partial class MainScreen : Form
    {

        private NumericUpDown[] Probabilidades;
        private NumericUpDown[] Tiempos;
        private NumericUpDown[] DistribucionUniforme;
        private NumericUpDown[] VariacionC;
        bool EstaTodoBien = true;
        public MainScreen()
        {

            InitializeComponent();
            Probabilidades = new NumericUpDown[] { num_Probabilidad_A, num_Probabilidad_B, num_Probabilidad_C, num_Probabilidad_D, num_Probabilidad_E };
            Tiempos = new NumericUpDown[] { num_Tiempo_A, num_Tiempo_B, num_Tiempo_C, num_Tiempo_D, num_Tiempo_E };
            DistribucionUniforme = new NumericUpDown[] { num_Inf, num_Sup };
            VariacionC = new NumericUpDown[] { num_Tiempo_1, num_Tiempo_2 };

        }

        // Método para establecer el valor predeterminado en los NumericUpDown dentro de un GroupBox
        private void LimpiarNumericUpDowns()
        {
            var groupBoxes = Controls.OfType<System.Windows.Forms.GroupBox>();

            foreach (var groupBox in groupBoxes)
            {
                var numericUpDowns = groupBox.Controls.OfType<NumericUpDown>();

                foreach (var numericUpDown in numericUpDowns)
                {
                    numericUpDown.Value = default; // Establece el valor predeterminado
                }
            }
        }

        public bool EsProbabilidadAcumuladaCorrecta()
        {
            decimal Acumulada = 0;

            // Itera sobre el arreglo de probabilidades
            for (int i = 0; i < Probabilidades.Length; i++)
            {
                // Suma el valor de cada probabilidad al acumulador
                Acumulada += Probabilidades[i].Value;
            }

            // Comprueba si la suma acumulada es igual a 1 (probabilidad total)
            return Acumulada == 1;
        }

        public bool SonTiemposCorrectos()
        {
            // Obtiene los valores de los tiempos desde los controles NumericUpDown
            decimal TiempoTrabajoC = num_Tiempo_C.Value;
            decimal TiempoHastaAutomatización = num_Tiempo_1.Value;
            decimal UltimoPeriodoDeTrabajo = num_Tiempo_2.Value;

            // Comprueba la condición: TiempoTrabajoC > UltimoPeriodoDeTrabajo + TiempoHastaAutomatización
            return TiempoTrabajoC > UltimoPeriodoDeTrabajo + TiempoHastaAutomatización;
        }

        public void CheckearErrores()
        {
            // Verifica si la probabilidad acumulada es correcta
            if (!EsProbabilidadAcumuladaCorrecta())
            {
                // Muestra un MessageBox de error indicando que las probabilidades no son adecuadas
                MessageBox.Show("Las probabilidades ingresadas no forman una probabilidad acumulada apropiada. Por favor, reviselas.", "¡Cuidado señor tecnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EstaTodoBien = false;
                return; // Sale del método después de mostrar el MessageBox
            }
            else
            {
                // Si la probabilidad acumulada es correcta, verifica si los tiempos son lógicos
                if (!SonTiemposCorrectos())
                {
                    // Muestra un MessageBox de error indicando que los tiempos no son lógicos
                    MessageBox.Show("Los tiempos definidos para el trabajo C no son lógicos. Por favor, reviselos.", "¡Cuidado señor tecnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EstaTodoBien = false;
                    return; // Sale del método después de mostrar el MessageBox
                }
            }
        }

        public void CheckearTiemposNulos()
        {
            foreach (NumericUpDown tiempo in Tiempos)
            {
                if (tiempo.Value == 0)
                {
                    MessageBox.Show("Los tiempos de ejecución de los trabajos no pueden ser nulos. Por favor, reviselos.", "¡Cuidado señor tecnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EstaTodoBien = false;
                    return;
                }
            }
            foreach (NumericUpDown tiempo in VariacionC)
            {
                if (tiempo.Value == 0)
                {
                    MessageBox.Show("Los tiempos invlucrados en el trabajo C no pueden ser nulos. Por favor, reviselos.", "¡Cuidado señor tecnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EstaTodoBien = false;
                    return;
                }
            }
        }

        public double[] NumericUpDownsToDouble(NumericUpDown[] Arreglo)
        {
            double[] ArregloToDouble = new double[Arreglo.Length];
            for (int i = 0; i < Arreglo.Length; i++)
            {
                ArregloToDouble[i] = Convert.ToDouble(Arreglo[i].Value);
            }
            return ArregloToDouble;
        }

        private void CrearCabeceras()
        {
            dgvColas.Columns.Clear();

            // Agregar las cabeceras principales
            dgvColas.Columns.Add("RelojColumn", "Reloj");
            dgvColas.Columns.Add("RNDLlegadaColumn", "RND Llegada");
            dgvColas.Columns.Add("TiempoLlegadaColumn", "Tiempo Llegada");
            dgvColas.Columns.Add("ProxLlegadaColumn", "Próxima Llegada");
            dgvColas.Columns.Add("RNDTipoArregloColumn", "RND Tipo Arreglo");
            dgvColas.Columns.Add("TipoArregloColumn", "Tipo Arreglo");
            dgvColas.Columns.Add("RNDFinalizacionColumn", "RND Finalización");
            dgvColas.Columns.Add("TiempoFinalizacionColumn", "Tiempo Finalización");
            dgvColas.Columns.Add("ProxFinalizacionColumn", "Próxima Finalización");
            dgvColas.Columns.Add("EstadoColumn", "Estado");
            dgvColas.Columns.Add("ColaColumn", "Cola");

            // Agregar las columnas iterativas
            for (int i = 1; i <= 4; i++)
            {
                dgvColas.Columns.Add("Estado" + i + "Column", "Estado " + i);
                dgvColas.Columns.Add("Hora" + i + "Column", "Hora " + i);
                dgvColas.Columns.Add("Cambio" + i + "Column", "Cambio " + i);
            }

            // Agregar las cabeceras restantes
            dgvColas.Columns.Add("EquiposAtendidosColumn", "Equipos Atendidos");
            dgvColas.Columns.Add("AcumPermanenciaColumn", "Acumulador Permanencia");
            dgvColas.Columns.Add("EquiposSolicitantesColumn", "Equipos Solicitantes");
            dgvColas.Columns.Add("EquiposAceptadosColumn", "Equipos Aceptados");
        }

        private void CrearCaceberasSecundarias()
        {
            dgvCabeceras.Columns.Clear();

            // Columna Reloj 
            DataGridViewColumn relojColumn = new DataGridViewTextBoxColumn();
            relojColumn.Name = "RelojColumn";
            relojColumn.HeaderText = "Reloj";
            relojColumn.Width = 125;
            relojColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            relojColumn.HeaderCell.Style.Font = new Font(dgvCabeceras.Font, FontStyle.Bold);
            dgvCabeceras.Columns.Add(relojColumn);

            // Columna Próxima Llegada 
            DataGridViewColumn proximaLlegadaColumn = new DataGridViewTextBoxColumn();
            proximaLlegadaColumn.Name = "ProximaLlegadaColumn";
            proximaLlegadaColumn.HeaderText = "Próxima Llegada";
            proximaLlegadaColumn.Width = 375;
            proximaLlegadaColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            proximaLlegadaColumn.HeaderCell.Style.Font = new Font(dgvCabeceras.Font, FontStyle.Bold);
            dgvCabeceras.Columns.Add(proximaLlegadaColumn);

            // Columna Fin Atención 
            DataGridViewColumn finAtencionColumn = new DataGridViewTextBoxColumn();
            finAtencionColumn.Name = "FinAtencionColumn";
            finAtencionColumn.HeaderText = "Fin Atención";
            finAtencionColumn.Width = 625;
            finAtencionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            finAtencionColumn.HeaderCell.Style.Font = new Font(dgvCabeceras.Font, FontStyle.Bold);
            dgvCabeceras.Columns.Add(finAtencionColumn);

            // Columna Técnico 
            DataGridViewColumn tecnicoColumn = new DataGridViewTextBoxColumn();
            tecnicoColumn.Name = "TecnicoColumn";
            tecnicoColumn.HeaderText = "Técnico";
            tecnicoColumn.Width = 250;
            tecnicoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tecnicoColumn.HeaderCell.Style.Font = new Font(dgvCabeceras.Font, FontStyle.Bold);
            dgvCabeceras.Columns.Add(tecnicoColumn);

            // Columnas Equipo 1 a 4 
            for (int i = 1; i <= 4; i++)
            {
                DataGridViewColumn equipoColumn = new DataGridViewTextBoxColumn();
                equipoColumn.Name = "Equipo" + i + "Column";
                equipoColumn.HeaderText = "Equipo " + i;
                equipoColumn.Width = 250;
                equipoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                equipoColumn.HeaderCell.Style.Font = new Font(dgvCabeceras.Font, FontStyle.Bold);
                dgvCabeceras.Columns.Add(equipoColumn);
            }

            // Columna Acumuladores 
            DataGridViewColumn acumuladoresColumn = new DataGridViewTextBoxColumn();
            acumuladoresColumn.Name = "AcumuladoresColumn";
            acumuladoresColumn.HeaderText = "Acumuladores";
            acumuladoresColumn.Width = 500;
            acumuladoresColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acumuladoresColumn.HeaderCell.Style.Font = new Font(dgvCabeceras.Font, FontStyle.Bold);
            dgvCabeceras.Columns.Add(acumuladoresColumn);
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Al hacer clic en el botón "btn_Limpiar"

            LimpiarNumericUpDowns(); // Llama a la función LimpiarNumericUpDowns para limpiar los NumericUpDown dentro del GroupBox.

            dgvColas.Rows.Clear(); // Borra todas las filas en el control DataGridView llamado dgvColas.
        }

        private void Parametros_ValueChanged(object sender, EventArgs e)
        {
            if (num_Minuto.Value > num_Tiempo_Simular.Value)
            {
                num_Tiempo_Simular.Value = num_Minuto.Value;
            }
        }

        private void btn_Simular_Click(object sender, EventArgs e)
        {

            CheckearTiemposNulos();
            CheckearErrores();

            if (EstaTodoBien)
            {
                Controlador Controlador = new Controlador();
                //BindingList<Fila>? Iteraciones = new BindingList<Fila>();
                //dgvColas.DataSource = Iteraciones;
                double Reloj = 0;
                int CantidadIteraciones = 0;

                double[] TiemposToDouble = NumericUpDownsToDouble(Tiempos);
                double[] ProbabilidadesToDouble = NumericUpDownsToDouble(Probabilidades);
                double[] UniformeToDouble = NumericUpDownsToDouble(DistribucionUniforme);
                double[] VariacionToDouble = NumericUpDownsToDouble(VariacionC);

                double TiempoSimulación = Convert.ToDouble(num_Tiempo_Simular.Value);
                double MinutoInicial = Convert.ToDouble(num_Minuto.Value);

                CrearCabeceras();
                CrearCaceberasSecundarias();

                while (Reloj <= TiempoSimulación)
                {
                    Fila FilaActual = new Fila();
                    FilaActual = Controlador.generarFila(Reloj, UniformeToDouble[0], UniformeToDouble[1], ProbabilidadesToDouble, TiemposToDouble, VariacionToDouble[0], VariacionToDouble[1]);
                    if (Reloj == 0)
                    {
                        Reloj = FilaActual.ProxLlegada;
                    }
                    else
                    {
                        Reloj = FilaActual.Reloj;
                    }
                    if (Reloj >= MinutoInicial && CantidadIteraciones <= num_Iteraciones.Value)
                    {
                        //Iteraciones.Add(FilaActual);
                        dgvColas.Rows.Add(CrearDataGridViewRow(FilaActual));
                    }
                    CantidadIteraciones++;
                }
            }


        }

        private DataGridViewRow CrearDataGridViewRow(Fila fila)
        {
            DataGridViewRow row = new DataGridViewRow();

            // Columna Reloj
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.Reloj });

            // Columna RND Llegada
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.RNDLlegada });

            // Columna Tiempo Llegada
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.TiempoLlegada });

            // Columna Proxima Llegada
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.ProxLlegada });

            // Columna RND Tipo Arreglo
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.RNDTipoArreglo });

            // Columna Tipo Arreglo
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.TipoArreglo });

            // Columna RND Finalizacion
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.RNDFinalizacion });

            // Columna Tiempo Finalizacion
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.TiempoFinalizacion });

            // Columna Proxima Finalizacion
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.ProxFinalizacion });

            // Columna Estado del Técnico
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.Tecnico.Estado });

            // Columna Cola del Técnico
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.Tecnico.Cola });

            // Columnas Equipo (Estado, Hora, Cambio)
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E1?.Estado });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E1?.Hora });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E1?.Cambio });

            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E2?.Estado });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E2?.Hora });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E2?.Cambio });

            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E3?.Estado });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E3?.Hora });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E3?.Cambio });

            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E4?.Estado });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E4?.Hora });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.E4?.Cambio });

            // Columna Equipos Atendidos
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.EquiposAtendidos });

            // Columna Acumulador Permanencia
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.AcumPermanencia });

            // Columna Equipos Solicitantes
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.EquiposSolicitantes });

            // Columna Equipos Aceptados
            row.Cells.Add(new DataGridViewTextBoxCell { Value = fila.EquiposAceptados });

            return row;
        }


        private void Tabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is double && (e.ColumnIndex <= 22 || e.ColumnIndex == 24))
            {
                e.Value = ((double)e.Value).ToString("0.00"); // Aquí se especifica el formato deseado, en este caso "0.00" para dos decimales
                e.FormattingApplied = true;
            }
        }

        private void dgvColas_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                // Obtener la posición de desplazamiento horizontal de la primera DataGridView
                int horizontalScrollValue = e.NewValue;

                // Establecer la misma posición de desplazamiento horizontal en la segunda DataGridView
                dgvCabeceras.HorizontalScrollingOffset = horizontalScrollValue;
            }
        }


    }
}
