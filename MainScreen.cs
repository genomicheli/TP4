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
                    MessageBox.Show("Los tiempos de ejecución de los trabajos no pueden ser nulos. Por favor, Revise.", "¡Cuidado señor tecnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EstaTodoBien = false;
                    return;
                }
            }
            foreach (NumericUpDown tiempo in VariacionC)
            {
                if (tiempo.Value == 0)
                {
                    MessageBox.Show("Los tiempos invlucrados en el trabajo C no pueden ser nulos. Revise.", "¡Cuidado señor tecnico!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public int[] NumericUpDownsToInt(NumericUpDown[] Arreglo)
        {
            int[] ArregloToInt = new int[Arreglo.Length];
            for (int i = 0; i < Arreglo.Length; i++)
            {
                ArregloToInt[i] = Convert.ToInt32(Arreglo[i].Value);
            }
            return ArregloToInt;
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
                List<Fila>? Iteraciones = new List<Fila>();
                dgvColas.DataSource = Iteraciones;
                double Reloj = 0;
                int CantidadIteraciones = 0;

                double[] TiemposToDouble = NumericUpDownsToDouble(Tiempos);
                double[] ProbabilidadesToDouble = NumericUpDownsToDouble(Probabilidades);
                double[] UniformeToDouble = NumericUpDownsToDouble(DistribucionUniforme);
                double[] VariacionToDouble = NumericUpDownsToDouble(VariacionC);

                double TiempoSimulación = Convert.ToDouble(num_Tiempo_Simular.Value);
                double MinutoInicial = Convert.ToDouble(num_Minuto.Value);

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

                    if ((Reloj >= MinutoInicial && CantidadIteraciones <= num_Iteraciones.Value) || Reloj >= TiempoSimulación)
                    {
                        Iteraciones.Add(FilaActual);
                    }
                    CantidadIteraciones++;

                }
                MessageBox.Show("Acabe!");
            }


        }
    }
}
