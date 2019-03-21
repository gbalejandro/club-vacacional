namespace OTLC
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.bttnCerrar = new System.Windows.Forms.Button();
            this.bttnSesion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.lblIdEmp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttnCerrar
            // 
            this.bttnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnCerrar.Location = new System.Drawing.Point(295, 59);
            this.bttnCerrar.Name = "bttnCerrar";
            this.bttnCerrar.Size = new System.Drawing.Size(75, 35);
            this.bttnCerrar.TabIndex = 21;
            this.bttnCerrar.Text = "Cerrar";
            this.bttnCerrar.UseVisualStyleBackColor = true;
            this.bttnCerrar.Click += new System.EventHandler(this.bttnCerrar_Click);
            // 
            // bttnSesion
            // 
            this.bttnSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSesion.Location = new System.Drawing.Point(295, 23);
            this.bttnSesion.Name = "bttnSesion";
            this.bttnSesion.Size = new System.Drawing.Size(75, 36);
            this.bttnSesion.TabIndex = 20;
            this.bttnSesion.Text = "Aceptar";
            this.bttnSesion.UseVisualStyleBackColor = true;
            this.bttnSesion.Click += new System.EventHandler(this.bttnSesion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.txtUsr);
            this.groupBox1.Controls.Add(this.lblIdEmp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 77);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(117, 43);
            this.txtPwd.MaxLength = 12;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 22);
            this.txtPwd.TabIndex = 18;
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwd_KeyPress);
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(117, 15);
            this.txtUsr.MaxLength = 10;
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(100, 22);
            this.txtUsr.TabIndex = 17;
            // 
            // lblIdEmp
            // 
            this.lblIdEmp.AutoSize = true;
            this.lblIdEmp.Location = new System.Drawing.Point(36, 18);
            this.lblIdEmp.Name = "lblIdEmp";
            this.lblIdEmp.Size = new System.Drawing.Size(58, 16);
            this.lblIdEmp.TabIndex = 3;
            this.lblIdEmp.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contraseña:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.bttnCerrar);
            this.Controls.Add(this.bttnSesion);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OASIS TRAVEL LEISURE CLUB ";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnCerrar;
        private System.Windows.Forms.Button bttnSesion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUsr;
        private System.Windows.Forms.Label lblIdEmp;
        private System.Windows.Forms.Label label1;
    }
}

