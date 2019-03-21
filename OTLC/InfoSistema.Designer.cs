namespace OTLC
{
    partial class InfoSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoSistema));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtversion = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtDesarrollador = new System.Windows.Forms.TextBox();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.txtHotel = new System.Windows.Forms.TextBox();
            this.bttnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtversion
            // 
            this.txtversion.BackColor = System.Drawing.Color.White;
            this.txtversion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtversion.Location = new System.Drawing.Point(214, 30);
            this.txtversion.Name = "txtversion";
            this.txtversion.ReadOnly = true;
            this.txtversion.Size = new System.Drawing.Size(163, 19);
            this.txtversion.TabIndex = 2;
            this.txtversion.TabStop = false;
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.White;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(214, 55);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(163, 19);
            this.txtFecha.TabIndex = 3;
            this.txtFecha.TabStop = false;
            // 
            // txtDesarrollador
            // 
            this.txtDesarrollador.BackColor = System.Drawing.Color.White;
            this.txtDesarrollador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesarrollador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesarrollador.Location = new System.Drawing.Point(214, 80);
            this.txtDesarrollador.Name = "txtDesarrollador";
            this.txtDesarrollador.ReadOnly = true;
            this.txtDesarrollador.Size = new System.Drawing.Size(163, 19);
            this.txtDesarrollador.TabIndex = 4;
            this.txtDesarrollador.TabStop = false;
            // 
            // txtDpto
            // 
            this.txtDpto.BackColor = System.Drawing.Color.White;
            this.txtDpto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDpto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDpto.Location = new System.Drawing.Point(214, 126);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.ReadOnly = true;
            this.txtDpto.Size = new System.Drawing.Size(163, 15);
            this.txtDpto.TabIndex = 5;
            this.txtDpto.TabStop = false;
            this.txtDpto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHotel
            // 
            this.txtHotel.BackColor = System.Drawing.Color.White;
            this.txtHotel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHotel.Location = new System.Drawing.Point(214, 145);
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.ReadOnly = true;
            this.txtHotel.Size = new System.Drawing.Size(163, 15);
            this.txtHotel.TabIndex = 6;
            this.txtHotel.TabStop = false;
            this.txtHotel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bttnAceptar
            // 
            this.bttnAceptar.Location = new System.Drawing.Point(302, 180);
            this.bttnAceptar.Name = "bttnAceptar";
            this.bttnAceptar.Size = new System.Drawing.Size(75, 23);
            this.bttnAceptar.TabIndex = 7;
            this.bttnAceptar.Text = "Aceptar";
            this.bttnAceptar.UseVisualStyleBackColor = true;
            this.bttnAceptar.Click += new System.EventHandler(this.bttnAceptar_Click);
            // 
            // InfoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 215);
            this.Controls.Add(this.bttnAceptar);
            this.Controls.Add(this.txtHotel);
            this.Controls.Add(this.txtDpto);
            this.Controls.Add(this.txtDesarrollador);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtversion);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OASIS TRAVEL LEISURE CLUB";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtversion;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtDesarrollador;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.TextBox txtHotel;
        private System.Windows.Forms.Button bttnAceptar;
    }
}