namespace OTLC
{
    partial class Permisos
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Editar Tipo de Cambio");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Empresa", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Cambiar Status1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Editar Info. General", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Editar Info. Tarjetas");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Editar Info. Ventas");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Reportes");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Reporte Regalos Ventas");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Catalogo de Regalos");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Regalos", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Contratos", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Reestructuración");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Pago a Capital");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Costo Contrato");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Enganche");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Aplicar Pagos", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Cobranza", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Editar Duracion de Membresia");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Estado de Puntos", new System.Windows.Forms.TreeNode[] {
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Añadir Puntos de nuevo Ejercicio");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Lista de Cumpleaños");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Reporte Porcentajes");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Reservaciones", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Interfaz de Producción");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Estadisticas", new System.Windows.Forms.TreeNode[] {
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Permisos");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Permisos));
            this.comboUsuario = new System.Windows.Forms.ComboBox();
            this.LblUsr = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.lblIniciales = new System.Windows.Forms.Label();
            this.txtIniciales = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.radioLimpiar = new System.Windows.Forms.RadioButton();
            this.radioSelecTodo = new System.Windows.Forms.RadioButton();
            this.bttnGRABAR = new System.Windows.Forms.Button();
            this.bttncerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboUsuario
            // 
            this.comboUsuario.FormattingEnabled = true;
            this.comboUsuario.Location = new System.Drawing.Point(113, 17);
            this.comboUsuario.Name = "comboUsuario";
            this.comboUsuario.Size = new System.Drawing.Size(410, 24);
            this.comboUsuario.TabIndex = 1;
            this.comboUsuario.SelectionChangeCommitted += new System.EventHandler(this.comboUsuario_SelectionChangeCommitted);
            // 
            // LblUsr
            // 
            this.LblUsr.AutoSize = true;
            this.LblUsr.Location = new System.Drawing.Point(10, 20);
            this.LblUsr.Name = "LblUsr";
            this.LblUsr.Size = new System.Drawing.Size(58, 16);
            this.LblUsr.TabIndex = 2;
            this.LblUsr.Text = "Usuario:";
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Location = new System.Drawing.Point(10, 49);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(97, 16);
            this.lblDepto.TabIndex = 3;
            this.lblDepto.Text = "Departamento:";
            // 
            // txtDpto
            // 
            this.txtDpto.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtDpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDpto.ForeColor = System.Drawing.Color.Black;
            this.txtDpto.Location = new System.Drawing.Point(113, 47);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(270, 22);
            this.txtDpto.TabIndex = 47;
            this.txtDpto.TabStop = false;
            this.txtDpto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPuesto
            // 
            this.txtPuesto.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtPuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPuesto.ForeColor = System.Drawing.Color.Black;
            this.txtPuesto.Location = new System.Drawing.Point(113, 75);
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.Size = new System.Drawing.Size(270, 22);
            this.txtPuesto.TabIndex = 48;
            this.txtPuesto.TabStop = false;
            this.txtPuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Location = new System.Drawing.Point(10, 77);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(53, 16);
            this.lblPuesto.TabIndex = 49;
            this.lblPuesto.Text = "Puesto:";
            // 
            // lblIniciales
            // 
            this.lblIniciales.AutoSize = true;
            this.lblIniciales.Location = new System.Drawing.Point(389, 77);
            this.lblIniciales.Name = "lblIniciales";
            this.lblIniciales.Size = new System.Drawing.Size(60, 16);
            this.lblIniciales.TabIndex = 50;
            this.lblIniciales.Text = "Iniciales:";
            // 
            // txtIniciales
            // 
            this.txtIniciales.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtIniciales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIniciales.ForeColor = System.Drawing.Color.Black;
            this.txtIniciales.Location = new System.Drawing.Point(455, 75);
            this.txtIniciales.Name = "txtIniciales";
            this.txtIniciales.Size = new System.Drawing.Size(68, 22);
            this.txtIniciales.TabIndex = 51;
            this.txtIniciales.TabStop = false;
            this.txtIniciales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.txtIniciales);
            this.groupBox1.Controls.Add(this.lblIniciales);
            this.groupBox1.Controls.Add(this.lblPuesto);
            this.groupBox1.Controls.Add(this.txtPuesto);
            this.groupBox1.Controls.Add(this.txtDpto);
            this.groupBox1.Controls.Add(this.lblDepto);
            this.groupBox1.Controls.Add(this.LblUsr);
            this.groupBox1.Controls.Add(this.comboUsuario);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 130);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.ItemHeight = 16;
            this.treeView1.Location = new System.Drawing.Point(7, 168);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "101";
            treeNode1.Text = "Editar Tipo de Cambio";
            treeNode1.ToolTipText = "Opción para modificar Tipo de Cambio del Sistema";
            treeNode2.Name = "100";
            treeNode2.Text = "Empresa";
            treeNode2.ToolTipText = "Acceso a Modulo Empresa";
            treeNode3.Name = "208";
            treeNode3.Text = "Cambiar Status1";
            treeNode3.ToolTipText = "Cambiar el Status del Contrato";
            treeNode4.Name = "201";
            treeNode4.Text = "Editar Info. General";
            treeNode4.ToolTipText = "Opción para modificar información general de los contratos";
            treeNode5.Name = "202";
            treeNode5.Text = "Editar Info. Tarjetas";
            treeNode5.ToolTipText = "Opción para modificar información de tarjetas de los contratos";
            treeNode6.Name = "203";
            treeNode6.Text = "Editar Info. Ventas";
            treeNode6.ToolTipText = "Opción para modificar información de venta de los contratos";
            treeNode7.Name = "204";
            treeNode7.Text = "Reportes";
            treeNode7.ToolTipText = "Opción para generar los Documentos de Contratación";
            treeNode8.Name = "206";
            treeNode8.Text = "Reporte Regalos Ventas";
            treeNode9.Name = "207";
            treeNode9.Text = "Catalogo de Regalos";
            treeNode9.ToolTipText = "Agregar y Modificar Regalos";
            treeNode10.Name = "205";
            treeNode10.Text = "Regalos";
            treeNode10.ToolTipText = "Agregar y Modificar Inf. Regalos";
            treeNode11.Name = "200";
            treeNode11.Text = "Contratos";
            treeNode11.ToolTipText = "Acceso a Modulo Contratos";
            treeNode12.Name = "301";
            treeNode12.Text = "Reestructuración";
            treeNode12.ToolTipText = "Reestructurar fechas de pagos de contratos de Renegociacion";
            treeNode13.Name = "303";
            treeNode13.Text = "Pago a Capital";
            treeNode14.Name = "304";
            treeNode14.Text = "Costo Contrato";
            treeNode15.Name = "305";
            treeNode15.Text = "Enganche";
            treeNode16.Name = "302";
            treeNode16.Text = "Aplicar Pagos";
            treeNode16.ToolTipText = "Aplicar pagos";
            treeNode17.Name = "300";
            treeNode17.Text = "Cobranza";
            treeNode17.ToolTipText = "Acceso a Modulo Cobranza";
            treeNode18.Name = "601";
            treeNode18.Text = "Editar Duracion de Membresia";
            treeNode19.Name = "602";
            treeNode19.Text = "Estado de Puntos";
            treeNode19.ToolTipText = "Reporte de Estado de Puntos del Socio";
            treeNode20.Name = "603";
            treeNode20.Text = "Añadir Puntos de nuevo Ejercicio";
            treeNode20.ToolTipText = "Añadir el nuevo catalogo de puntos para el ejercicio proximo";
            treeNode21.Name = "604";
            treeNode21.Text = "Lista de Cumpleaños";
            treeNode21.ToolTipText = "Listado de Cumpleaños de los Socios";
            treeNode22.Name = "605";
            treeNode22.Text = "Reporte Porcentajes";
            treeNode22.ToolTipText = "consulta y Generacion de Reporte de Porcentaje Actual Pagado de los Socios";
            treeNode23.Name = "600";
            treeNode23.Text = "Reservaciones";
            treeNode23.ToolTipText = "Acceso a Modulo de Reservaciones";
            treeNode24.Name = "401";
            treeNode24.Text = "Interfaz de Producción";
            treeNode25.Name = "400";
            treeNode25.Text = "Estadisticas";
            treeNode25.ToolTipText = "Acceso a Modulo Estadisticas";
            treeNode26.Name = "500";
            treeNode26.Text = "Permisos";
            treeNode26.ToolTipText = "Acceso a Modulo Permisos de Usuario";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode11,
            treeNode17,
            treeNode23,
            treeNode25,
            treeNode26});
            this.treeView1.Size = new System.Drawing.Size(539, 500);
            this.treeView1.TabIndex = 53;
            // 
            // radioLimpiar
            // 
            this.radioLimpiar.AutoSize = true;
            this.radioLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLimpiar.Location = new System.Drawing.Point(406, 142);
            this.radioLimpiar.Name = "radioLimpiar";
            this.radioLimpiar.Size = new System.Drawing.Size(124, 20);
            this.radioLimpiar.TabIndex = 55;
            this.radioLimpiar.TabStop = true;
            this.radioLimpiar.Text = "Quitar Selección";
            this.radioLimpiar.UseVisualStyleBackColor = true;
            this.radioLimpiar.CheckedChanged += new System.EventHandler(this.radioLimpiar_CheckedChanged);
            // 
            // radioSelecTodo
            // 
            this.radioSelecTodo.AutoSize = true;
            this.radioSelecTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSelecTodo.Location = new System.Drawing.Point(256, 142);
            this.radioSelecTodo.Name = "radioSelecTodo";
            this.radioSelecTodo.Size = new System.Drawing.Size(134, 20);
            this.radioSelecTodo.TabIndex = 54;
            this.radioSelecTodo.TabStop = true;
            this.radioSelecTodo.Text = "Seleccionar Todo";
            this.radioSelecTodo.UseVisualStyleBackColor = true;
            this.radioSelecTodo.CheckedChanged += new System.EventHandler(this.radioSelecTodo_CheckedChanged);
            // 
            // bttnGRABAR
            // 
            this.bttnGRABAR.BackColor = System.Drawing.Color.DarkOrange;
            this.bttnGRABAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnGRABAR.ForeColor = System.Drawing.Color.Black;
            this.bttnGRABAR.Location = new System.Drawing.Point(322, 674);
            this.bttnGRABAR.Name = "bttnGRABAR";
            this.bttnGRABAR.Size = new System.Drawing.Size(109, 37);
            this.bttnGRABAR.TabIndex = 56;
            this.bttnGRABAR.Text = "GRABAR";
            this.bttnGRABAR.UseVisualStyleBackColor = false;
            this.bttnGRABAR.Click += new System.EventHandler(this.bttnGRABAR_Click);
            // 
            // bttncerrar
            // 
            this.bttncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttncerrar.Location = new System.Drawing.Point(437, 674);
            this.bttncerrar.Name = "bttncerrar";
            this.bttncerrar.Size = new System.Drawing.Size(109, 37);
            this.bttncerrar.TabIndex = 57;
            this.bttncerrar.Text = "CERRAR";
            this.bttncerrar.UseVisualStyleBackColor = true;
            this.bttncerrar.Click += new System.EventHandler(this.bttncerrar_Click);
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(554, 719);
            this.Controls.Add(this.bttncerrar);
            this.Controls.Add(this.bttnGRABAR);
            this.Controls.Add(this.radioLimpiar);
            this.Controls.Add(this.radioSelecTodo);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Permisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OASIS TRAVEL LEISURE CLUB";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboUsuario;
        private System.Windows.Forms.Label LblUsr;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.Label lblIniciales;
        private System.Windows.Forms.TextBox txtIniciales;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RadioButton radioLimpiar;
        private System.Windows.Forms.RadioButton radioSelecTodo;
        private System.Windows.Forms.Button bttnGRABAR;
        private System.Windows.Forms.Button bttncerrar;
    }
}