namespace TP4
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            lbl_Titulo = new Label();
            lbl_Trabajos = new Label();
            panel_Info = new Panel();
            gb_Parametros = new GroupBox();
            num_Tiempo_2 = new NumericUpDown();
            lbl_Probabilidad = new Label();
            lbl_Tipo_A = new Label();
            lbl_Variacion = new Label();
            lbl_Tipo_B = new Label();
            lbl_Tipo_E = new Label();
            num_Tiempo_1 = new NumericUpDown();
            lbl_Tipo_C = new Label();
            num_Inf = new NumericUpDown();
            lbl_Tipo_D = new Label();
            num_Tiempo_E = new NumericUpDown();
            lbl_Tiempo_2 = new Label();
            num_Probabilidad_E = new NumericUpDown();
            num_Probabilidad_A = new NumericUpDown();
            num_Sup = new NumericUpDown();
            lbl_Tiempo_1 = new Label();
            num_Tiempo_D = new NumericUpDown();
            num_Tiempo_A = new NumericUpDown();
            lbl_Inf = new Label();
            lbl_Explicacion_2 = new Label();
            num_Probabilidad_D = new NumericUpDown();
            num_Probabilidad_B = new NumericUpDown();
            lbl_Explicacion_1 = new Label();
            lbl_Condicion = new Label();
            num_Tiempo_C = new NumericUpDown();
            num_Tiempo_B = new NumericUpDown();
            lbl_Sup = new Label();
            label1 = new Label();
            num_Probabilidad_C = new NumericUpDown();
            btn_Limpiar = new Button();
            btn_Exportar = new Button();
            btn_Simular = new Button();
            dgvColas = new DataGridView();
            groupBox1 = new GroupBox();
            lbl_Tiempo_Simulacion = new Label();
            lbl_Minuto_Inicial = new Label();
            lbl_Cantidad_Iteraciones = new Label();
            num_Minuto = new NumericUpDown();
            num_Iteraciones = new NumericUpDown();
            num_Tiempo_Simular = new NumericUpDown();
            panel_Info.SuspendLayout();
            gb_Parametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Inf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_E).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_E).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_A).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Sup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_D).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_A).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_D).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_B).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_C).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_B).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_C).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvColas).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_Minuto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Iteraciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_Simular).BeginInit();
            SuspendLayout();
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Font = new Font("Monotype Corsiva", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Titulo.Location = new Point(12, 11);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(500, 98);
            lbl_Titulo.TabIndex = 0;
            lbl_Titulo.Text = "Laboratorio de reparación \r\nde dispositivos de computación ";
            lbl_Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Trabajos
            // 
            lbl_Trabajos.AutoSize = true;
            lbl_Trabajos.Location = new Point(85, 123);
            lbl_Trabajos.Name = "lbl_Trabajos";
            lbl_Trabajos.Size = new Size(344, 120);
            lbl_Trabajos.TabIndex = 1;
            lbl_Trabajos.Text = "Arreglos ofrecidos a nuestros distinguidos clientes:\r\nA - Cambio de placa.\r\nB - Ampliación de memoria.\r\nC - Formateo de disco.\r\nD - Agregar CD o DVD.\r\nE - Cambio de memoria.";
            lbl_Trabajos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Info
            // 
            panel_Info.BackColor = SystemColors.ActiveCaption;
            panel_Info.Controls.Add(lbl_Titulo);
            panel_Info.Controls.Add(lbl_Trabajos);
            panel_Info.Location = new Point(12, 13);
            panel_Info.Name = "panel_Info";
            panel_Info.Size = new Size(524, 262);
            panel_Info.TabIndex = 2;
            // 
            // gb_Parametros
            // 
            gb_Parametros.BackColor = SystemColors.Control;
            gb_Parametros.Controls.Add(num_Tiempo_2);
            gb_Parametros.Controls.Add(lbl_Probabilidad);
            gb_Parametros.Controls.Add(lbl_Tipo_A);
            gb_Parametros.Controls.Add(lbl_Variacion);
            gb_Parametros.Controls.Add(lbl_Tipo_B);
            gb_Parametros.Controls.Add(lbl_Tipo_E);
            gb_Parametros.Controls.Add(num_Tiempo_1);
            gb_Parametros.Controls.Add(lbl_Tipo_C);
            gb_Parametros.Controls.Add(num_Inf);
            gb_Parametros.Controls.Add(lbl_Tipo_D);
            gb_Parametros.Controls.Add(num_Tiempo_E);
            gb_Parametros.Controls.Add(lbl_Tiempo_2);
            gb_Parametros.Controls.Add(num_Probabilidad_E);
            gb_Parametros.Controls.Add(num_Probabilidad_A);
            gb_Parametros.Controls.Add(num_Sup);
            gb_Parametros.Controls.Add(lbl_Tiempo_1);
            gb_Parametros.Controls.Add(num_Tiempo_D);
            gb_Parametros.Controls.Add(num_Tiempo_A);
            gb_Parametros.Controls.Add(lbl_Inf);
            gb_Parametros.Controls.Add(lbl_Explicacion_2);
            gb_Parametros.Controls.Add(num_Probabilidad_D);
            gb_Parametros.Controls.Add(num_Probabilidad_B);
            gb_Parametros.Controls.Add(lbl_Explicacion_1);
            gb_Parametros.Controls.Add(lbl_Condicion);
            gb_Parametros.Controls.Add(num_Tiempo_C);
            gb_Parametros.Controls.Add(num_Tiempo_B);
            gb_Parametros.Controls.Add(lbl_Sup);
            gb_Parametros.Controls.Add(label1);
            gb_Parametros.Controls.Add(num_Probabilidad_C);
            gb_Parametros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gb_Parametros.Location = new Point(552, 13);
            gb_Parametros.Name = "gb_Parametros";
            gb_Parametros.Size = new Size(558, 429);
            gb_Parametros.TabIndex = 3;
            gb_Parametros.TabStop = false;
            gb_Parametros.Text = "Parametros de tipo de arreglo";
            // 
            // num_Tiempo_2
            // 
            num_Tiempo_2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_2.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            num_Tiempo_2.Location = new Point(409, 360);
            num_Tiempo_2.Name = "num_Tiempo_2";
            num_Tiempo_2.Size = new Size(99, 27);
            num_Tiempo_2.TabIndex = 27;
            num_Tiempo_2.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lbl_Probabilidad
            // 
            lbl_Probabilidad.AutoSize = true;
            lbl_Probabilidad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Probabilidad.Location = new Point(61, 38);
            lbl_Probabilidad.Name = "lbl_Probabilidad";
            lbl_Probabilidad.Size = new Size(95, 20);
            lbl_Probabilidad.TabIndex = 21;
            lbl_Probabilidad.Text = "Probabilidad";
            // 
            // lbl_Tipo_A
            // 
            lbl_Tipo_A.AutoSize = true;
            lbl_Tipo_A.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tipo_A.Location = new Point(19, 68);
            lbl_Tipo_A.Name = "lbl_Tipo_A";
            lbl_Tipo_A.Size = new Size(19, 20);
            lbl_Tipo_A.TabIndex = 16;
            lbl_Tipo_A.Text = "A";
            // 
            // lbl_Variacion
            // 
            lbl_Variacion.AutoSize = true;
            lbl_Variacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Variacion.Location = new Point(359, 38);
            lbl_Variacion.Name = "lbl_Variacion";
            lbl_Variacion.Size = new Size(148, 20);
            lbl_Variacion.TabIndex = 4;
            lbl_Variacion.Text = "Variación de tiempo";
            // 
            // lbl_Tipo_B
            // 
            lbl_Tipo_B.AutoSize = true;
            lbl_Tipo_B.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tipo_B.Location = new Point(19, 101);
            lbl_Tipo_B.Name = "lbl_Tipo_B";
            lbl_Tipo_B.Size = new Size(18, 20);
            lbl_Tipo_B.TabIndex = 17;
            lbl_Tipo_B.Text = "B";
            // 
            // lbl_Tipo_E
            // 
            lbl_Tipo_E.AutoSize = true;
            lbl_Tipo_E.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tipo_E.Location = new Point(19, 200);
            lbl_Tipo_E.Name = "lbl_Tipo_E";
            lbl_Tipo_E.Size = new Size(17, 20);
            lbl_Tipo_E.TabIndex = 20;
            lbl_Tipo_E.Text = "E";
            // 
            // num_Tiempo_1
            // 
            num_Tiempo_1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_1.Increment = new decimal(new int[] { 15, 0, 0, 0 });
            num_Tiempo_1.Location = new Point(409, 302);
            num_Tiempo_1.Name = "num_Tiempo_1";
            num_Tiempo_1.Size = new Size(99, 27);
            num_Tiempo_1.TabIndex = 26;
            num_Tiempo_1.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lbl_Tipo_C
            // 
            lbl_Tipo_C.AutoSize = true;
            lbl_Tipo_C.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tipo_C.Location = new Point(19, 134);
            lbl_Tipo_C.Name = "lbl_Tipo_C";
            lbl_Tipo_C.Size = new Size(18, 20);
            lbl_Tipo_C.TabIndex = 18;
            lbl_Tipo_C.Text = "C";
            // 
            // num_Inf
            // 
            num_Inf.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Inf.Location = new Point(437, 165);
            num_Inf.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Inf.Name = "num_Inf";
            num_Inf.Size = new Size(99, 27);
            num_Inf.TabIndex = 0;
            num_Inf.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lbl_Tipo_D
            // 
            lbl_Tipo_D.AutoSize = true;
            lbl_Tipo_D.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tipo_D.Location = new Point(19, 167);
            lbl_Tipo_D.Name = "lbl_Tipo_D";
            lbl_Tipo_D.Size = new Size(20, 20);
            lbl_Tipo_D.TabIndex = 19;
            lbl_Tipo_D.Text = "D";
            // 
            // num_Tiempo_E
            // 
            num_Tiempo_E.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_E.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            num_Tiempo_E.Location = new Point(177, 198);
            num_Tiempo_E.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Tiempo_E.Name = "num_Tiempo_E";
            num_Tiempo_E.Size = new Size(119, 27);
            num_Tiempo_E.TabIndex = 15;
            num_Tiempo_E.Value = new decimal(new int[] { 90, 0, 0, 0 });
            // 
            // lbl_Tiempo_2
            // 
            lbl_Tiempo_2.AutoSize = true;
            lbl_Tiempo_2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tiempo_2.Location = new Point(423, 334);
            lbl_Tiempo_2.Name = "lbl_Tiempo_2";
            lbl_Tiempo_2.Size = new Size(72, 20);
            lbl_Tiempo_2.TabIndex = 25;
            lbl_Tiempo_2.Text = "Tiempo 2";
            // 
            // num_Probabilidad_E
            // 
            num_Probabilidad_E.DecimalPlaces = 2;
            num_Probabilidad_E.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Probabilidad_E.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            num_Probabilidad_E.Location = new Point(52, 198);
            num_Probabilidad_E.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Probabilidad_E.Name = "num_Probabilidad_E";
            num_Probabilidad_E.Size = new Size(119, 27);
            num_Probabilidad_E.TabIndex = 14;
            num_Probabilidad_E.Value = new decimal(new int[] { 2, 0, 0, 65536 });
            // 
            // num_Probabilidad_A
            // 
            num_Probabilidad_A.DecimalPlaces = 2;
            num_Probabilidad_A.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Probabilidad_A.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            num_Probabilidad_A.Location = new Point(52, 66);
            num_Probabilidad_A.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Probabilidad_A.Name = "num_Probabilidad_A";
            num_Probabilidad_A.Size = new Size(119, 27);
            num_Probabilidad_A.TabIndex = 6;
            num_Probabilidad_A.Value = new decimal(new int[] { 3, 0, 0, 65536 });
            // 
            // num_Sup
            // 
            num_Sup.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Sup.Location = new Point(437, 198);
            num_Sup.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Sup.Name = "num_Sup";
            num_Sup.Size = new Size(99, 27);
            num_Sup.TabIndex = 1;
            num_Sup.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lbl_Tiempo_1
            // 
            lbl_Tiempo_1.AutoSize = true;
            lbl_Tiempo_1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tiempo_1.Location = new Point(423, 276);
            lbl_Tiempo_1.Name = "lbl_Tiempo_1";
            lbl_Tiempo_1.Size = new Size(72, 20);
            lbl_Tiempo_1.TabIndex = 24;
            lbl_Tiempo_1.Text = "Tiempo 1";
            // 
            // num_Tiempo_D
            // 
            num_Tiempo_D.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_D.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            num_Tiempo_D.Location = new Point(177, 165);
            num_Tiempo_D.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Tiempo_D.Name = "num_Tiempo_D";
            num_Tiempo_D.Size = new Size(119, 27);
            num_Tiempo_D.TabIndex = 13;
            num_Tiempo_D.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // num_Tiempo_A
            // 
            num_Tiempo_A.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_A.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            num_Tiempo_A.Location = new Point(177, 66);
            num_Tiempo_A.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Tiempo_A.Name = "num_Tiempo_A";
            num_Tiempo_A.Size = new Size(119, 27);
            num_Tiempo_A.TabIndex = 7;
            num_Tiempo_A.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // lbl_Inf
            // 
            lbl_Inf.AutoSize = true;
            lbl_Inf.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Inf.Location = new Point(340, 168);
            lbl_Inf.Name = "lbl_Inf";
            lbl_Inf.Size = new Size(88, 20);
            lbl_Inf.TabIndex = 2;
            lbl_Inf.Text = "Lim. Inferior";
            // 
            // lbl_Explicacion_2
            // 
            lbl_Explicacion_2.AutoSize = true;
            lbl_Explicacion_2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Explicacion_2.Location = new Point(42, 302);
            lbl_Explicacion_2.Name = "lbl_Explicacion_2";
            lbl_Explicacion_2.Size = new Size(343, 100);
            lbl_Explicacion_2.TabIndex = 23;
            lbl_Explicacion_2.Text = resources.GetString("lbl_Explicacion_2.Text");
            lbl_Explicacion_2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // num_Probabilidad_D
            // 
            num_Probabilidad_D.DecimalPlaces = 2;
            num_Probabilidad_D.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Probabilidad_D.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            num_Probabilidad_D.Location = new Point(52, 165);
            num_Probabilidad_D.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Probabilidad_D.Name = "num_Probabilidad_D";
            num_Probabilidad_D.Size = new Size(119, 27);
            num_Probabilidad_D.TabIndex = 12;
            num_Probabilidad_D.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // num_Probabilidad_B
            // 
            num_Probabilidad_B.DecimalPlaces = 2;
            num_Probabilidad_B.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Probabilidad_B.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            num_Probabilidad_B.Location = new Point(52, 99);
            num_Probabilidad_B.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Probabilidad_B.Name = "num_Probabilidad_B";
            num_Probabilidad_B.Size = new Size(119, 27);
            num_Probabilidad_B.TabIndex = 8;
            num_Probabilidad_B.Value = new decimal(new int[] { 25, 0, 0, 131072 });
            // 
            // lbl_Explicacion_1
            // 
            lbl_Explicacion_1.AutoSize = true;
            lbl_Explicacion_1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Explicacion_1.Location = new Point(318, 69);
            lbl_Explicacion_1.Name = "lbl_Explicacion_1";
            lbl_Explicacion_1.Size = new Size(226, 80);
            lbl_Explicacion_1.TabIndex = 5;
            lbl_Explicacion_1.Text = "Los tiempos indicados para\r\nlos tiempos de arreglo varian\r\nsegun una distribución uniforme \r\n(en minutos)";
            lbl_Explicacion_1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Condicion
            // 
            lbl_Condicion.AutoSize = true;
            lbl_Condicion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Condicion.Location = new Point(144, 252);
            lbl_Condicion.Name = "lbl_Condicion";
            lbl_Condicion.Size = new Size(137, 40);
            lbl_Condicion.TabIndex = 7;
            lbl_Condicion.Text = "Condición especial\r\npara arreglo C";
            lbl_Condicion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // num_Tiempo_C
            // 
            num_Tiempo_C.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_C.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            num_Tiempo_C.Location = new Point(177, 132);
            num_Tiempo_C.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Tiempo_C.Name = "num_Tiempo_C";
            num_Tiempo_C.Size = new Size(119, 27);
            num_Tiempo_C.TabIndex = 11;
            num_Tiempo_C.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // num_Tiempo_B
            // 
            num_Tiempo_B.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_B.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            num_Tiempo_B.Location = new Point(177, 99);
            num_Tiempo_B.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Tiempo_B.Name = "num_Tiempo_B";
            num_Tiempo_B.Size = new Size(119, 27);
            num_Tiempo_B.TabIndex = 9;
            num_Tiempo_B.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // lbl_Sup
            // 
            lbl_Sup.AutoSize = true;
            lbl_Sup.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Sup.Location = new Point(332, 201);
            lbl_Sup.Name = "lbl_Sup";
            lbl_Sup.Size = new Size(96, 20);
            lbl_Sup.TabIndex = 3;
            lbl_Sup.Text = "Lim. Superior";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(203, 38);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 22;
            label1.Text = "Tiempo";
            // 
            // num_Probabilidad_C
            // 
            num_Probabilidad_C.DecimalPlaces = 2;
            num_Probabilidad_C.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Probabilidad_C.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            num_Probabilidad_C.Location = new Point(52, 132);
            num_Probabilidad_C.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Probabilidad_C.Name = "num_Probabilidad_C";
            num_Probabilidad_C.Size = new Size(119, 27);
            num_Probabilidad_C.TabIndex = 10;
            num_Probabilidad_C.Value = new decimal(new int[] { 15, 0, 0, 131072 });
            // 
            // btn_Limpiar
            // 
            btn_Limpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Limpiar.Location = new Point(334, 289);
            btn_Limpiar.Name = "btn_Limpiar";
            btn_Limpiar.Size = new Size(202, 43);
            btn_Limpiar.TabIndex = 4;
            btn_Limpiar.Text = "Limpiar";
            btn_Limpiar.UseVisualStyleBackColor = true;
            btn_Limpiar.Click += btn_Limpiar_Click;
            // 
            // btn_Exportar
            // 
            btn_Exportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Exportar.Location = new Point(334, 344);
            btn_Exportar.Name = "btn_Exportar";
            btn_Exportar.Size = new Size(202, 43);
            btn_Exportar.TabIndex = 5;
            btn_Exportar.Text = "Exportar";
            btn_Exportar.UseVisualStyleBackColor = true;
            // 
            // btn_Simular
            // 
            btn_Simular.BackColor = Color.LightGreen;
            btn_Simular.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Simular.Location = new Point(334, 401);
            btn_Simular.Name = "btn_Simular";
            btn_Simular.Size = new Size(202, 41);
            btn_Simular.TabIndex = 6;
            btn_Simular.Text = "Simular";
            btn_Simular.UseVisualStyleBackColor = false;
            btn_Simular.Click += btn_Simular_Click;
            // 
            // dgvColas
            // 
            dgvColas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColas.Location = new Point(12, 459);
            dgvColas.Name = "dgvColas";
            dgvColas.RowHeadersWidth = 51;
            dgvColas.RowTemplate.Height = 29;
            dgvColas.Size = new Size(1098, 323);
            dgvColas.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbl_Tiempo_Simulacion);
            groupBox1.Controls.Add(lbl_Minuto_Inicial);
            groupBox1.Controls.Add(lbl_Cantidad_Iteraciones);
            groupBox1.Controls.Add(num_Minuto);
            groupBox1.Controls.Add(num_Iteraciones);
            groupBox1.Controls.Add(num_Tiempo_Simular);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 281);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(316, 161);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parametros de simulación";
            // 
            // lbl_Tiempo_Simulacion
            // 
            lbl_Tiempo_Simulacion.AutoSize = true;
            lbl_Tiempo_Simulacion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Tiempo_Simulacion.Location = new Point(54, 42);
            lbl_Tiempo_Simulacion.Name = "lbl_Tiempo_Simulacion";
            lbl_Tiempo_Simulacion.Size = new Size(124, 20);
            lbl_Tiempo_Simulacion.TabIndex = 7;
            lbl_Tiempo_Simulacion.Text = "Tiempo a simular";
            // 
            // lbl_Minuto_Inicial
            // 
            lbl_Minuto_Inicial.AutoSize = true;
            lbl_Minuto_Inicial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Minuto_Inicial.Location = new Point(79, 106);
            lbl_Minuto_Inicial.Name = "lbl_Minuto_Inicial";
            lbl_Minuto_Inicial.Size = new Size(99, 20);
            lbl_Minuto_Inicial.TabIndex = 5;
            lbl_Minuto_Inicial.Text = "Minuto Inicial";
            // 
            // lbl_Cantidad_Iteraciones
            // 
            lbl_Cantidad_Iteraciones.AutoSize = true;
            lbl_Cantidad_Iteraciones.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Cantidad_Iteraciones.Location = new Point(12, 74);
            lbl_Cantidad_Iteraciones.Name = "lbl_Cantidad_Iteraciones";
            lbl_Cantidad_Iteraciones.Size = new Size(166, 20);
            lbl_Cantidad_Iteraciones.TabIndex = 4;
            lbl_Cantidad_Iteraciones.Text = "Cantidad de iteraciones";
            // 
            // num_Minuto
            // 
            num_Minuto.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Minuto.Location = new Point(190, 104);
            num_Minuto.Name = "num_Minuto";
            num_Minuto.Size = new Size(95, 27);
            num_Minuto.TabIndex = 3;
            num_Minuto.ValueChanged += Parametros_ValueChanged;
            // 
            // num_Iteraciones
            // 
            num_Iteraciones.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Iteraciones.Location = new Point(190, 71);
            num_Iteraciones.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            num_Iteraciones.Name = "num_Iteraciones";
            num_Iteraciones.Size = new Size(95, 27);
            num_Iteraciones.TabIndex = 2;
            num_Iteraciones.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // num_Tiempo_Simular
            // 
            num_Tiempo_Simular.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            num_Tiempo_Simular.Location = new Point(190, 39);
            num_Tiempo_Simular.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            num_Tiempo_Simular.Name = "num_Tiempo_Simular";
            num_Tiempo_Simular.Size = new Size(95, 27);
            num_Tiempo_Simular.TabIndex = 0;
            num_Tiempo_Simular.Value = new decimal(new int[] { 2500, 0, 0, 0 });
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 794);
            Controls.Add(groupBox1);
            Controls.Add(dgvColas);
            Controls.Add(btn_Simular);
            Controls.Add(btn_Exportar);
            Controls.Add(btn_Limpiar);
            Controls.Add(gb_Parametros);
            Controls.Add(panel_Info);
            Name = "MainScreen";
            Text = "MainScreen";
            panel_Info.ResumeLayout(false);
            panel_Info.PerformLayout();
            gb_Parametros.ResumeLayout(false);
            gb_Parametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Inf).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_E).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_E).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_A).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Sup).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_D).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_A).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_D).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_B).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_C).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_B).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Probabilidad_C).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvColas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_Minuto).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Iteraciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Tiempo_Simular).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Titulo;
        private Label lbl_Trabajos;
        private Panel panel_Info;
        private GroupBox gb_Parametros;
        private Label lbl_Explicacion_1;
        private Label lbl_Variacion;
        private Label lbl_Sup;
        private Label lbl_Inf;
        private NumericUpDown num_Sup;
        private NumericUpDown num_Inf;
        private Label label1;
        private Label lbl_Probabilidad;
        private Label lbl_Tipo_E;
        private Label lbl_Tipo_D;
        private Label lbl_Tipo_C;
        private Label lbl_Tipo_B;
        private Label lbl_Tipo_A;
        private NumericUpDown num_Tiempo_E;
        private NumericUpDown num_Probabilidad_E;
        private NumericUpDown num_Tiempo_D;
        private NumericUpDown num_Probabilidad_D;
        private NumericUpDown num_Tiempo_C;
        private NumericUpDown num_Probabilidad_C;
        private NumericUpDown num_Tiempo_B;
        private NumericUpDown num_Probabilidad_B;
        private NumericUpDown num_Tiempo_A;
        private NumericUpDown num_Probabilidad_A;
        private Label lbl_Condicion;
        private NumericUpDown num_Tiempo_2;
        private NumericUpDown num_Tiempo_1;
        private Label lbl_Tiempo_2;
        private Label lbl_Tiempo_1;
        private Label lbl_Explicacion_2;
        private Button btn_Limpiar;
        private Button btn_Exportar;
        private Button btn_Simular;
        private DataGridView dgvColas;
        private GroupBox groupBox1;
        private NumericUpDown num_Minuto;
        private NumericUpDown num_Iteraciones;
        private NumericUpDown num_Tiempo_Simular;
        private Label lbl_Tiempo_Simulacion;
        private Label lbl_Minuto_Inicial;
        private Label lbl_Cantidad_Iteraciones;
    }
}