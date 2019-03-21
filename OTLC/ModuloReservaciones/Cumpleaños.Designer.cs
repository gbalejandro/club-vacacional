namespace OTLC
{
    partial class Cumpleaños
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cumpleaños));
            this.cboFechaIni = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblReg = new System.Windows.Forms.Label();
            this.bttnExcel = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.bttnCerrar2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdioSinFecha = new System.Windows.Forms.RadioButton();
            this.rdioFechas = new System.Windows.Forms.RadioButton();
            this.rdioMes = new System.Windows.Forms.RadioButton();
            this.lblMes = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.lblRango = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.cboFechaFin = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboFechaIni
            // 
            this.cboFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cboFechaIni.Location = new System.Drawing.Point(523, 19);
            this.cboFechaIni.Name = "cboFechaIni";
            this.cboFechaIni.Size = new System.Drawing.Size(126, 22);
            this.cboFechaIni.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(855, 571);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblReg);
            this.tabPage1.Controls.Add(this.bttnExcel);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.bttnCerrar2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(847, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cumpleaños de Socios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Location = new System.Drawing.Point(21, 514);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(93, 16);
            this.lblReg.TabIndex = 99;
            this.lblReg.Text = "No. Registros:";
            // 
            // bttnExcel
            // 
            this.bttnExcel.BackColor = System.Drawing.Color.DarkOrange;
            this.bttnExcel.Cursor = System.Windows.Forms.Cursors.Default;
            this.bttnExcel.Location = new System.Drawing.Point(602, 498);
            this.bttnExcel.Name = "bttnExcel";
            this.bttnExcel.Size = new System.Drawing.Size(109, 37);
            this.bttnExcel.TabIndex = 98;
            this.bttnExcel.Text = "EXCEL";
            this.bttnExcel.UseVisualStyleBackColor = false;
            this.bttnExcel.Click += new System.EventHandler(this.bttnExcel_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(20, 80);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(810, 416);
            this.tabControl2.TabIndex = 96;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvSocios);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 387);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Listado de Socios ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.AllowUserToResizeRows = false;
            this.dgvSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSocios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSocios.BackgroundColor = System.Drawing.Color.White;
            this.dgvSocios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSocios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvSocios.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSocios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSocios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSocios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSocios.EnableHeadersVisualStyles = false;
            this.dgvSocios.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvSocios.Location = new System.Drawing.Point(6, 6);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvSocios.RowHeadersVisible = false;
            this.dgvSocios.RowHeadersWidth = 50;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvSocios.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSocios.Size = new System.Drawing.Size(790, 378);
            this.dgvSocios.TabIndex = 88;
            // 
            // bttnCerrar2
            // 
            this.bttnCerrar2.Location = new System.Drawing.Point(717, 498);
            this.bttnCerrar2.Name = "bttnCerrar2";
            this.bttnCerrar2.Size = new System.Drawing.Size(109, 37);
            this.bttnCerrar2.TabIndex = 97;
            this.bttnCerrar2.Text = "CERRAR";
            this.bttnCerrar2.UseVisualStyleBackColor = true;
            this.bttnCerrar2.Click += new System.EventHandler(this.bttnCerrar2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Controls.Add(this.rdioSinFecha);
            this.groupBox1.Controls.Add(this.rdioFechas);
            this.groupBox1.Controls.Add(this.rdioMes);
            this.groupBox1.Controls.Add(this.lblMes);
            this.groupBox1.Controls.Add(this.cboMes);
            this.groupBox1.Controls.Add(this.cboFechaIni);
            this.groupBox1.Controls.Add(this.lblRango);
            this.groupBox1.Controls.Add(this.lblA);
            this.groupBox1.Controls.Add(this.cboFechaFin);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 51);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // rdioSinFecha
            // 
            this.rdioSinFecha.AutoSize = true;
            this.rdioSinFecha.Location = new System.Drawing.Point(228, 19);
            this.rdioSinFecha.Name = "rdioSinFecha";
            this.rdioSinFecha.Size = new System.Drawing.Size(86, 20);
            this.rdioSinFecha.TabIndex = 13;
            this.rdioSinFecha.TabStop = true;
            this.rdioSinFecha.Text = "Sin Fecha";
            this.rdioSinFecha.UseVisualStyleBackColor = true;
            this.rdioSinFecha.CheckedChanged += new System.EventHandler(this.rdioSinFecha_CheckedChanged);
            // 
            // rdioFechas
            // 
            this.rdioFechas.AutoSize = true;
            this.rdioFechas.Location = new System.Drawing.Point(88, 19);
            this.rdioFechas.Name = "rdioFechas";
            this.rdioFechas.Size = new System.Drawing.Size(134, 20);
            this.rdioFechas.TabIndex = 12;
            this.rdioFechas.TabStop = true;
            this.rdioFechas.Text = "Rango de Fechas";
            this.rdioFechas.UseVisualStyleBackColor = true;
            this.rdioFechas.CheckedChanged += new System.EventHandler(this.rdioFechas_CheckedChanged);
            // 
            // rdioMes
            // 
            this.rdioMes.AutoSize = true;
            this.rdioMes.Location = new System.Drawing.Point(6, 19);
            this.rdioMes.Name = "rdioMes";
            this.rdioMes.Size = new System.Drawing.Size(76, 20);
            this.rdioMes.TabIndex = 11;
            this.rdioMes.TabStop = true;
            this.rdioMes.Text = "Por Mes";
            this.rdioMes.UseVisualStyleBackColor = true;
            this.rdioMes.CheckedChanged += new System.EventHandler(this.rdioMes_CheckedChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(327, 21);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(112, 16);
            this.lblMes.TabIndex = 10;
            this.lblMes.Text = "Seleccionar Mes:";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "Seleccionar",
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cboMes.Location = new System.Drawing.Point(445, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(126, 24);
            this.cboMes.TabIndex = 9;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.cboMes_SelectionChangeCommitted);
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(327, 21);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(190, 16);
            this.lblRango.TabIndex = 6;
            this.lblRango.Text = "Rango de Fechas (Dia y Mes):";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(660, 22);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(16, 16);
            this.lblA.TabIndex = 8;
            this.lblA.Text = "a";
            // 
            // cboFechaFin
            // 
            this.cboFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cboFechaFin.Location = new System.Drawing.Point(679, 19);
            this.cboFechaFin.Name = "cboFechaFin";
            this.cboFechaFin.Size = new System.Drawing.Size(126, 22);
            this.cboFechaFin.TabIndex = 7;
            this.cboFechaFin.ValueChanged += new System.EventHandler(this.cboFechaFin_ValueChanged);
            // 
            // Cumpleaños
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 597);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cumpleaños";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OASIS TRAVEL LEISURE CLUB";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker cboFechaIni;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.DateTimePicker cboFechaFin;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Button bttnExcel;
        private System.Windows.Forms.Button bttnCerrar2;
        private System.Windows.Forms.RadioButton rdioFechas;
        private System.Windows.Forms.RadioButton rdioMes;
        private System.Windows.Forms.RadioButton rdioSinFecha;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.Label lblReg;
    }
}