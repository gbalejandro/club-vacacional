namespace OTLC
{
    partial class TipoCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoCambio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtIdEmpresa = new System.Windows.Forms.TextBox();
            this.lblIdEmp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTipCambio = new System.Windows.Forms.TextBox();
            this.bttnConsultar = new System.Windows.Forms.Button();
            this.bttnActualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.TxtIdEmpresa);
            this.groupBox1.Controls.Add(this.lblIdEmp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtTipCambio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 77);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // TxtIdEmpresa
            // 
            this.TxtIdEmpresa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtIdEmpresa.Enabled = false;
            this.TxtIdEmpresa.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TxtIdEmpresa.Location = new System.Drawing.Point(129, 15);
            this.TxtIdEmpresa.Name = "TxtIdEmpresa";
            this.TxtIdEmpresa.Size = new System.Drawing.Size(100, 22);
            this.TxtIdEmpresa.TabIndex = 4;
            this.TxtIdEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIdEmp
            // 
            this.lblIdEmp.AutoSize = true;
            this.lblIdEmp.Location = new System.Drawing.Point(57, 18);
            this.lblIdEmp.Name = "lblIdEmp";
            this.lblIdEmp.Size = new System.Drawing.Size(66, 16);
            this.lblIdEmp.TabIndex = 3;
            this.lblIdEmp.Text = "Empresa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de Cambio:";
            // 
            // TxtTipCambio
            // 
            this.TxtTipCambio.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtTipCambio.Location = new System.Drawing.Point(129, 43);
            this.TxtTipCambio.Name = "TxtTipCambio";
            this.TxtTipCambio.Size = new System.Drawing.Size(100, 22);
            this.TxtTipCambio.TabIndex = 2;
            this.TxtTipCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtTipCambio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTipCambio_KeyPress);
            // 
            // bttnConsultar
            // 
            this.bttnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnConsultar.Location = new System.Drawing.Point(272, 18);
            this.bttnConsultar.Name = "bttnConsultar";
            this.bttnConsultar.Size = new System.Drawing.Size(95, 36);
            this.bttnConsultar.TabIndex = 11;
            this.bttnConsultar.Text = "Consultar";
            this.bttnConsultar.UseVisualStyleBackColor = true;
            this.bttnConsultar.Click += new System.EventHandler(this.bttnConsultar_Click);
            // 
            // bttnActualizar
            // 
            this.bttnActualizar.BackColor = System.Drawing.Color.DarkOrange;
            this.bttnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnActualizar.Location = new System.Drawing.Point(272, 60);
            this.bttnActualizar.Name = "bttnActualizar";
            this.bttnActualizar.Size = new System.Drawing.Size(95, 36);
            this.bttnActualizar.TabIndex = 12;
            this.bttnActualizar.Text = "Actualizar";
            this.bttnActualizar.UseVisualStyleBackColor = false;
            this.bttnActualizar.Click += new System.EventHandler(this.bttnActualizar_Click);
            // 
            // TipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 111);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttnConsultar);
            this.Controls.Add(this.bttnActualizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TipoCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OASIS TRAVEL LEISURE CLUB";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtIdEmpresa;
        private System.Windows.Forms.Label lblIdEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTipCambio;
        private System.Windows.Forms.Button bttnConsultar;
        private System.Windows.Forms.Button bttnActualizar;
    }
}