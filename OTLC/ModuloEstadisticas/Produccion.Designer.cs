namespace OTLC
{
    partial class Produccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion));
            this.FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblAl = new System.Windows.Forms.Label();
            this.FechaFin = new System.Windows.Forms.DateTimePicker();
            this.bttnConsultar = new System.Windows.Forms.Button();
            this.lblFiltroCto = new System.Windows.Forms.Label();
            this.cboTipoCon = new System.Windows.Forms.ComboBox();
            this.dgvTabGral = new System.Windows.Forms.DataGridView();
            this.bttnExcel = new System.Windows.Forms.Button();
            this.bttnCerrar = new System.Windows.Forms.Button();
            this.lblReg = new System.Windows.Forms.Label();
            this.lblTabGralCto = new System.Windows.Forms.Label();
            this.chPorcentaje = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabGral)).BeginInit();
            this.SuspendLayout();
            // 
            // FechaInicio
            // 
            this.FechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaInicio.Location = new System.Drawing.Point(85, 14);
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Size = new System.Drawing.Size(126, 22);
            this.FechaInicio.TabIndex = 5;
            this.FechaInicio.ValueChanged += new System.EventHandler(this.FechaInicio_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(30, 18);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(49, 16);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblAl
            // 
            this.lblAl.AutoSize = true;
            this.lblAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAl.Location = new System.Drawing.Point(217, 18);
            this.lblAl.Name = "lblAl";
            this.lblAl.Size = new System.Drawing.Size(19, 16);
            this.lblAl.TabIndex = 7;
            this.lblAl.Text = "al";
            // 
            // FechaFin
            // 
            this.FechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFin.Location = new System.Drawing.Point(244, 14);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Size = new System.Drawing.Size(126, 22);
            this.FechaFin.TabIndex = 8;
            this.FechaFin.ValueChanged += new System.EventHandler(this.FechaFin_ValueChanged);
            // 
            // bttnConsultar
            // 
            this.bttnConsultar.BackColor = System.Drawing.Color.DarkOrange;
            this.bttnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnConsultar.Location = new System.Drawing.Point(376, 12);
            this.bttnConsultar.Name = "bttnConsultar";
            this.bttnConsultar.Size = new System.Drawing.Size(101, 26);
            this.bttnConsultar.TabIndex = 9;
            this.bttnConsultar.Text = "Consultar";
            this.bttnConsultar.UseVisualStyleBackColor = false;
            this.bttnConsultar.Click += new System.EventHandler(this.bttnConsultar_Click);
            // 
            // lblFiltroCto
            // 
            this.lblFiltroCto.AutoSize = true;
            this.lblFiltroCto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCto.Location = new System.Drawing.Point(605, 18);
            this.lblFiltroCto.Name = "lblFiltroCto";
            this.lblFiltroCto.Size = new System.Drawing.Size(100, 16);
            this.lblFiltroCto.TabIndex = 10;
            this.lblFiltroCto.Text = "Filtro Contratos:";
            this.lblFiltroCto.Visible = false;
            // 
            // cboTipoCon
            // 
            this.cboTipoCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCon.Enabled = false;
            this.cboTipoCon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTipoCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCon.FormattingEnabled = true;
            this.cboTipoCon.Location = new System.Drawing.Point(711, 14);
            this.cboTipoCon.Name = "cboTipoCon";
            this.cboTipoCon.Size = new System.Drawing.Size(139, 24);
            this.cboTipoCon.TabIndex = 11;
            this.cboTipoCon.Visible = false;
            this.cboTipoCon.SelectionChangeCommitted += new System.EventHandler(this.cboTipoCon_SelectionChangeCommitted);
            // 
            // dgvTabGral
            // 
            this.dgvTabGral.AllowUserToAddRows = false;
            this.dgvTabGral.AllowUserToDeleteRows = false;
            this.dgvTabGral.AllowUserToResizeColumns = false;
            this.dgvTabGral.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabGral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabGral.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTabGral.BackgroundColor = System.Drawing.Color.White;
            this.dgvTabGral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvTabGral.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabGral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabGral.ColumnHeadersHeight = 60;
            this.dgvTabGral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTabGral.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabGral.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTabGral.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTabGral.Location = new System.Drawing.Point(12, 70);
            this.dgvTabGral.MultiSelect = false;
            this.dgvTabGral.Name = "dgvTabGral";
            this.dgvTabGral.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabGral.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTabGral.RowHeadersVisible = false;
            this.dgvTabGral.RowHeadersWidth = 60;
            this.dgvTabGral.RowTemplate.Height = 50;
            this.dgvTabGral.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabGral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabGral.ShowCellToolTips = false;
            this.dgvTabGral.ShowEditingIcon = false;
            this.dgvTabGral.ShowRowErrors = false;
            this.dgvTabGral.Size = new System.Drawing.Size(1599, 672);
            this.dgvTabGral.TabIndex = 12;
            // 
            // bttnExcel
            // 
            this.bttnExcel.BackColor = System.Drawing.Color.DarkOrange;
            this.bttnExcel.Cursor = System.Windows.Forms.Cursors.Default;
            this.bttnExcel.Enabled = false;
            this.bttnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnExcel.Location = new System.Drawing.Point(1387, 748);
            this.bttnExcel.Name = "bttnExcel";
            this.bttnExcel.Size = new System.Drawing.Size(109, 37);
            this.bttnExcel.TabIndex = 92;
            this.bttnExcel.Text = "EXCEL";
            this.bttnExcel.UseVisualStyleBackColor = false;
            this.bttnExcel.Click += new System.EventHandler(this.bttnExcel_Click);
            // 
            // bttnCerrar
            // 
            this.bttnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnCerrar.Location = new System.Drawing.Point(1502, 748);
            this.bttnCerrar.Name = "bttnCerrar";
            this.bttnCerrar.Size = new System.Drawing.Size(109, 37);
            this.bttnCerrar.TabIndex = 91;
            this.bttnCerrar.Text = "CERRAR";
            this.bttnCerrar.UseVisualStyleBackColor = true;
            this.bttnCerrar.Click += new System.EventHandler(this.bttnCerrar_Click);
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReg.Location = new System.Drawing.Point(12, 758);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(93, 16);
            this.lblReg.TabIndex = 100;
            this.lblReg.Text = "No. Registros:";
            // 
            // lblTabGralCto
            // 
            this.lblTabGralCto.AutoSize = true;
            this.lblTabGralCto.BackColor = System.Drawing.Color.Transparent;
            this.lblTabGralCto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabGralCto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTabGralCto.Location = new System.Drawing.Point(587, 51);
            this.lblTabGralCto.Name = "lblTabGralCto";
            this.lblTabGralCto.Size = new System.Drawing.Size(200, 16);
            this.lblTabGralCto.TabIndex = 101;
            this.lblTabGralCto.Text = "Tabla General de Contratos";
            this.lblTabGralCto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chPorcentaje
            // 
            this.chPorcentaje.AutoSize = true;
            this.chPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chPorcentaje.Location = new System.Drawing.Point(85, 47);
            this.chPorcentaje.Name = "chPorcentaje";
            this.chPorcentaje.Size = new System.Drawing.Size(180, 20);
            this.chPorcentaje.TabIndex = 103;
            this.chPorcentaje.Text = "Mostrar Porcentaje Actual";
            this.chPorcentaje.UseVisualStyleBackColor = true;
            // 
            // Produccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1623, 797);
            this.Controls.Add(this.chPorcentaje);
            this.Controls.Add(this.lblTabGralCto);
            this.Controls.Add(this.lblReg);
            this.Controls.Add(this.bttnExcel);
            this.Controls.Add(this.bttnCerrar);
            this.Controls.Add(this.dgvTabGral);
            this.Controls.Add(this.cboTipoCon);
            this.Controls.Add(this.lblFiltroCto);
            this.Controls.Add(this.bttnConsultar);
            this.Controls.Add(this.FechaFin);
            this.Controls.Add(this.lblAl);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.FechaInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Produccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla General Contratos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabGral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FechaInicio;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblAl;
        private System.Windows.Forms.DateTimePicker FechaFin;
        private System.Windows.Forms.Button bttnConsultar;
        private System.Windows.Forms.Label lblFiltroCto;
        private System.Windows.Forms.ComboBox cboTipoCon;
        private System.Windows.Forms.DataGridView dgvTabGral;
        private System.Windows.Forms.Button bttnExcel;
        private System.Windows.Forms.Button bttnCerrar;
        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.Label lblTabGralCto;
        private System.Windows.Forms.CheckBox chPorcentaje;
    }
}