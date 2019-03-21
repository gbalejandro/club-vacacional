namespace OTLC
{
    partial class NotasDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotasDetalle));
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.bttncerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.White;
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.HideSelection = false;
            this.txtComentario.Location = new System.Drawing.Point(12, 12);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ReadOnly = true;
            this.txtComentario.Size = new System.Drawing.Size(423, 518);
            this.txtComentario.TabIndex = 2;
            this.txtComentario.TabStop = false;
            // 
            // bttncerrar
            // 
            this.bttncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttncerrar.Location = new System.Drawing.Point(326, 536);
            this.bttncerrar.Name = "bttncerrar";
            this.bttncerrar.Size = new System.Drawing.Size(109, 37);
            this.bttncerrar.TabIndex = 1;
            this.bttncerrar.Text = "CERRAR";
            this.bttncerrar.UseVisualStyleBackColor = true;
            this.bttncerrar.Click += new System.EventHandler(this.bttncerrar_Click);
            // 
            // NotasDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(447, 585);
            this.ControlBox = false;
            this.Controls.Add(this.bttncerrar);
            this.Controls.Add(this.txtComentario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotasDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button bttncerrar;
    }
}