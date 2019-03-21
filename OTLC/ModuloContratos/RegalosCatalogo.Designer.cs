namespace OTLC
{
    partial class RegalosCatalogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegalosCatalogo));
            this.dgvRegCat = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bttncerrar = new System.Windows.Forms.Button();
            this.bttnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegCat)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRegCat
            // 
            this.dgvRegCat.AllowUserToAddRows = false;
            this.dgvRegCat.AllowUserToDeleteRows = false;
            this.dgvRegCat.AllowUserToResizeColumns = false;
            this.dgvRegCat.AllowUserToResizeRows = false;
            this.dgvRegCat.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRegCat.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvRegCat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegCat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRegCat.EnableHeadersVisualStyles = false;
            this.dgvRegCat.Location = new System.Drawing.Point(0, 0);
            this.dgvRegCat.Name = "dgvRegCat";
            this.dgvRegCat.RowHeadersVisible = false;
            this.dgvRegCat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegCat.Size = new System.Drawing.Size(1133, 383);
            this.dgvRegCat.TabIndex = 113;
            this.dgvRegCat.DoubleClick += new System.EventHandler(this.dgvRegCat_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1141, 409);
            this.tabControl1.TabIndex = 114;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvRegCat);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1133, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Catalogo de Regalos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bttncerrar
            // 
            this.bttncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttncerrar.Location = new System.Drawing.Point(1040, 427);
            this.bttncerrar.Name = "bttncerrar";
            this.bttncerrar.Size = new System.Drawing.Size(109, 37);
            this.bttncerrar.TabIndex = 116;
            this.bttncerrar.Text = "CERRAR";
            this.bttncerrar.UseVisualStyleBackColor = true;
            this.bttncerrar.Click += new System.EventHandler(this.bttncerrar_Click);
            // 
            // bttnAceptar
            // 
            this.bttnAceptar.BackColor = System.Drawing.Color.DarkOrange;
            this.bttnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAceptar.ForeColor = System.Drawing.Color.Black;
            this.bttnAceptar.Location = new System.Drawing.Point(925, 427);
            this.bttnAceptar.Name = "bttnAceptar";
            this.bttnAceptar.Size = new System.Drawing.Size(109, 37);
            this.bttnAceptar.TabIndex = 115;
            this.bttnAceptar.Text = "ACEPTAR";
            this.bttnAceptar.UseVisualStyleBackColor = false;
            this.bttnAceptar.Click += new System.EventHandler(this.bttnAceptar_Click);
            // 
            // RegalosCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1165, 476);
            this.ControlBox = false;
            this.Controls.Add(this.bttncerrar);
            this.Controls.Add(this.bttnAceptar);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegalosCatalogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OASIS TRAVEL LEISURE CLUB";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegCat)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegCat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button bttncerrar;
        private System.Windows.Forms.Button bttnAceptar;
    }
}