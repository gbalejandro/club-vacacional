namespace OTLC
{
    partial class PagoEng
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboFRef = new System.Windows.Forms.DateTimePicker();
            this.txtNoTarjeta = new System.Windows.Forms.TextBox();
            this.cboTipPago = new System.Windows.Forms.ComboBox();
            this.lblTipag = new System.Windows.Forms.Label();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.lblInteres = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.cboDepositado = new System.Windows.Forms.ComboBox();
            this.cboFRecep = new System.Windows.Forms.DateTimePicker();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblFRecep = new System.Windows.Forms.Label();
            this.lblDepositadoEn = new System.Windows.Forms.Label();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblPagoCapital = new System.Windows.Forms.Label();
            this.lblFRef = new System.Windows.Forms.Label();
            this.lblNoTarjeta = new System.Windows.Forms.Label();
            this.lblFExpira = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblNoAutoriza = new System.Windows.Forms.Label();
            this.txtFExpMes = new System.Windows.Forms.TextBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.lblseparador = new System.Windows.Forms.Label();
            this.txtNoAuto = new System.Windows.Forms.TextBox();
            this.txtFExpAno = new System.Windows.Forms.TextBox();
            this.txtFecRef = new System.Windows.Forms.TextBox();
            this.txtFecPag = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblFecPago = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.bttncerrar = new System.Windows.Forms.Button();
            this.bttnGrabar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFVence = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.txtPendiente = new System.Windows.Forms.TextBox();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.txtTipCambio = new System.Windows.Forms.TextBox();
            this.lblTipCambio = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cboFRef);
            this.groupBox1.Controls.Add(this.txtNoTarjeta);
            this.groupBox1.Controls.Add(this.cboTipPago);
            this.groupBox1.Controls.Add(this.lblTipag);
            this.groupBox1.Controls.Add(this.txtInteres);
            this.groupBox1.Controls.Add(this.lblInteres);
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.cboDepositado);
            this.groupBox1.Controls.Add(this.cboFRecep);
            this.groupBox1.Controls.Add(this.txtRef);
            this.groupBox1.Controls.Add(this.lblReferencia);
            this.groupBox1.Controls.Add(this.lblFRecep);
            this.groupBox1.Controls.Add(this.lblDepositadoEn);
            this.groupBox1.Controls.Add(this.lblFormaPago);
            this.groupBox1.Controls.Add(this.lblPagoCapital);
            this.groupBox1.Controls.Add(this.lblFRef);
            this.groupBox1.Controls.Add(this.lblNoTarjeta);
            this.groupBox1.Controls.Add(this.lblFExpira);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblNoAutoriza);
            this.groupBox1.Controls.Add(this.txtFExpMes);
            this.groupBox1.Controls.Add(this.cboFormaPago);
            this.groupBox1.Controls.Add(this.lblseparador);
            this.groupBox1.Controls.Add(this.txtNoAuto);
            this.groupBox1.Controls.Add(this.txtFExpAno);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 368);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // cboFRef
            // 
            this.cboFRef.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cboFRef.Location = new System.Drawing.Point(133, 47);
            this.cboFRef.Name = "cboFRef";
            this.cboFRef.Size = new System.Drawing.Size(102, 22);
            this.cboFRef.TabIndex = 119;
            // 
            // txtNoTarjeta
            // 
            this.txtNoTarjeta.Location = new System.Drawing.Point(133, 105);
            this.txtNoTarjeta.Name = "txtNoTarjeta";
            this.txtNoTarjeta.Size = new System.Drawing.Size(206, 22);
            this.txtNoTarjeta.TabIndex = 118;
            this.txtNoTarjeta.TabStop = false;
            this.txtNoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoTarjeta_KeyPress);
            // 
            // cboTipPago
            // 
            this.cboTipPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipPago.FormattingEnabled = true;
            this.cboTipPago.ItemHeight = 16;
            this.cboTipPago.Items.AddRange(new object[] {
            "Enganche"});
            this.cboTipPago.Location = new System.Drawing.Point(133, 17);
            this.cboTipPago.Name = "cboTipPago";
            this.cboTipPago.Size = new System.Drawing.Size(175, 24);
            this.cboTipPago.TabIndex = 116;
            // 
            // lblTipag
            // 
            this.lblTipag.AutoSize = true;
            this.lblTipag.Location = new System.Drawing.Point(8, 22);
            this.lblTipag.Name = "lblTipag";
            this.lblTipag.Size = new System.Drawing.Size(91, 16);
            this.lblTipag.TabIndex = 117;
            this.lblTipag.Text = "Tipo de Pago";
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(133, 232);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.Size = new System.Drawing.Size(100, 22);
            this.txtInteres.TabIndex = 113;
            this.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInteres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteres_KeyPress);
            // 
            // lblInteres
            // 
            this.lblInteres.AutoSize = true;
            this.lblInteres.Location = new System.Drawing.Point(8, 235);
            this.lblInteres.Name = "lblInteres";
            this.lblInteres.Size = new System.Drawing.Size(108, 16);
            this.lblInteres.TabIndex = 114;
            this.lblInteres.Text = "Interés Moratorio";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(133, 204);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(100, 22);
            this.txtImporte.TabIndex = 0;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // cboDepositado
            // 
            this.cboDepositado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepositado.FormattingEnabled = true;
            this.cboDepositado.ItemHeight = 16;
            this.cboDepositado.Items.AddRange(new object[] {
            "Oficina de Cancun"});
            this.cboDepositado.Location = new System.Drawing.Point(133, 333);
            this.cboDepositado.Name = "cboDepositado";
            this.cboDepositado.Size = new System.Drawing.Size(175, 24);
            this.cboDepositado.TabIndex = 8;
            // 
            // cboFRecep
            // 
            this.cboFRecep.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cboFRecep.Location = new System.Drawing.Point(374, 47);
            this.cboFRecep.Name = "cboFRecep";
            this.cboFRecep.Size = new System.Drawing.Size(102, 22);
            this.cboFRecep.TabIndex = 111;
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(133, 305);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(175, 22);
            this.txtRef.TabIndex = 7;
            this.txtRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(8, 308);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(74, 16);
            this.lblReferencia.TabIndex = 113;
            this.lblReferencia.Text = "Referencia";
            // 
            // lblFRecep
            // 
            this.lblFRecep.AutoSize = true;
            this.lblFRecep.Location = new System.Drawing.Point(253, 52);
            this.lblFRecep.Name = "lblFRecep";
            this.lblFRecep.Size = new System.Drawing.Size(115, 16);
            this.lblFRecep.TabIndex = 112;
            this.lblFRecep.Text = "Fecha Recepción";
            // 
            // lblDepositadoEn
            // 
            this.lblDepositadoEn.AutoSize = true;
            this.lblDepositadoEn.Location = new System.Drawing.Point(8, 336);
            this.lblDepositadoEn.Name = "lblDepositadoEn";
            this.lblDepositadoEn.Size = new System.Drawing.Size(98, 16);
            this.lblDepositadoEn.TabIndex = 114;
            this.lblDepositadoEn.Text = "Depositado En";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(8, 78);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(102, 16);
            this.lblFormaPago.TabIndex = 109;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // lblPagoCapital
            // 
            this.lblPagoCapital.AutoSize = true;
            this.lblPagoCapital.Location = new System.Drawing.Point(8, 207);
            this.lblPagoCapital.Name = "lblPagoCapital";
            this.lblPagoCapital.Size = new System.Drawing.Size(53, 16);
            this.lblPagoCapital.TabIndex = 107;
            this.lblPagoCapital.Text = "Importe";
            // 
            // lblFRef
            // 
            this.lblFRef.AutoSize = true;
            this.lblFRef.Location = new System.Drawing.Point(8, 52);
            this.lblFRef.Name = "lblFRef";
            this.lblFRef.Size = new System.Drawing.Size(115, 16);
            this.lblFRef.TabIndex = 110;
            this.lblFRef.Text = "Fecha Referencia";
            // 
            // lblNoTarjeta
            // 
            this.lblNoTarjeta.AutoSize = true;
            this.lblNoTarjeta.Location = new System.Drawing.Point(8, 108);
            this.lblNoTarjeta.Name = "lblNoTarjeta";
            this.lblNoTarjeta.Size = new System.Drawing.Size(75, 16);
            this.lblNoTarjeta.TabIndex = 110;
            this.lblNoTarjeta.Text = "No. Tarjeta";
            // 
            // lblFExpira
            // 
            this.lblFExpira.AutoSize = true;
            this.lblFExpira.Location = new System.Drawing.Point(8, 136);
            this.lblFExpira.Name = "lblFExpira";
            this.lblFExpira.Size = new System.Drawing.Size(112, 16);
            this.lblFExpira.TabIndex = 111;
            this.lblFExpira.Text = "Fecha Expiración";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(133, 260);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 34;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(8, 262);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 16);
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = "T o t a l";
            // 
            // lblNoAutoriza
            // 
            this.lblNoAutoriza.AutoSize = true;
            this.lblNoAutoriza.Location = new System.Drawing.Point(8, 164);
            this.lblNoAutoriza.Name = "lblNoAutoriza";
            this.lblNoAutoriza.Size = new System.Drawing.Size(105, 16);
            this.lblNoAutoriza.TabIndex = 112;
            this.lblNoAutoriza.Text = "No. Autorización";
            // 
            // txtFExpMes
            // 
            this.txtFExpMes.Location = new System.Drawing.Point(133, 133);
            this.txtFExpMes.Name = "txtFExpMes";
            this.txtFExpMes.Size = new System.Drawing.Size(44, 22);
            this.txtFExpMes.TabIndex = 4;
            this.txtFExpMes.TabStop = false;
            this.txtFExpMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFExpMes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFExpMes_KeyPress);
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.ItemHeight = 16;
            this.cboFormaPago.Location = new System.Drawing.Point(133, 75);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(206, 24);
            this.cboFormaPago.TabIndex = 17;
            this.cboFormaPago.TabStop = false;
            this.cboFormaPago.SelectionChangeCommitted += new System.EventHandler(this.cboFormaPago_SelectionChangeCommitted);
            // 
            // lblseparador
            // 
            this.lblseparador.AutoSize = true;
            this.lblseparador.Location = new System.Drawing.Point(183, 136);
            this.lblseparador.Name = "lblseparador";
            this.lblseparador.Size = new System.Drawing.Size(12, 16);
            this.lblseparador.TabIndex = 32;
            this.lblseparador.Text = "/";
            // 
            // txtNoAuto
            // 
            this.txtNoAuto.Location = new System.Drawing.Point(133, 161);
            this.txtNoAuto.Name = "txtNoAuto";
            this.txtNoAuto.Size = new System.Drawing.Size(126, 22);
            this.txtNoAuto.TabIndex = 6;
            this.txtNoAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFExpAno
            // 
            this.txtFExpAno.Location = new System.Drawing.Point(197, 133);
            this.txtFExpAno.Name = "txtFExpAno";
            this.txtFExpAno.Size = new System.Drawing.Size(58, 22);
            this.txtFExpAno.TabIndex = 5;
            this.txtFExpAno.TabStop = false;
            this.txtFExpAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFExpAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFExpAno_KeyPress);
            // 
            // txtFecRef
            // 
            this.txtFecRef.BackColor = System.Drawing.Color.White;
            this.txtFecRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecRef.Location = new System.Drawing.Point(133, 70);
            this.txtFecRef.Name = "txtFecRef";
            this.txtFecRef.ReadOnly = true;
            this.txtFecRef.Size = new System.Drawing.Size(85, 22);
            this.txtFecRef.TabIndex = 115;
            this.txtFecRef.TabStop = false;
            this.txtFecRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFecPag
            // 
            this.txtFecPag.BackColor = System.Drawing.Color.White;
            this.txtFecPag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecPag.Location = new System.Drawing.Point(133, 44);
            this.txtFecPag.Name = "txtFecPag";
            this.txtFecPag.ReadOnly = true;
            this.txtFecPag.Size = new System.Drawing.Size(85, 22);
            this.txtFecPag.TabIndex = 24;
            this.txtFecPag.TabStop = false;
            this.txtFecPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNum
            // 
            this.txtNum.BackColor = System.Drawing.Color.White;
            this.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNum.Location = new System.Drawing.Point(133, 18);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(50, 22);
            this.txtNum.TabIndex = 22;
            this.txtNum.TabStop = false;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFecPago
            // 
            this.lblFecPago.AutoSize = true;
            this.lblFecPago.Location = new System.Drawing.Point(8, 46);
            this.lblFecPago.Name = "lblFecPago";
            this.lblFecPago.Size = new System.Drawing.Size(104, 16);
            this.lblFecPago.TabIndex = 1;
            this.lblFecPago.Text = "Fecha del Pago";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(8, 20);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(90, 16);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "No Enganche";
            // 
            // bttncerrar
            // 
            this.bttncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttncerrar.Location = new System.Drawing.Point(390, 495);
            this.bttncerrar.Name = "bttncerrar";
            this.bttncerrar.Size = new System.Drawing.Size(109, 37);
            this.bttncerrar.TabIndex = 59;
            this.bttncerrar.Text = "CERRAR";
            this.bttncerrar.UseVisualStyleBackColor = true;
            this.bttncerrar.Click += new System.EventHandler(this.bttncerrar_Click);
            // 
            // bttnGrabar
            // 
            this.bttnGrabar.BackColor = System.Drawing.Color.DarkOrange;
            this.bttnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnGrabar.Location = new System.Drawing.Point(275, 495);
            this.bttnGrabar.Name = "bttnGrabar";
            this.bttnGrabar.Size = new System.Drawing.Size(109, 37);
            this.bttnGrabar.TabIndex = 58;
            this.bttnGrabar.Text = "GRABAR";
            this.bttnGrabar.UseVisualStyleBackColor = false;
            this.bttnGrabar.Click += new System.EventHandler(this.bttnGrabar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Controls.Add(this.lblFVence);
            this.groupBox2.Controls.Add(this.cboMoneda);
            this.groupBox2.Controls.Add(this.lblMoneda);
            this.groupBox2.Controls.Add(this.txtFecRef);
            this.groupBox2.Controls.Add(this.txtNum);
            this.groupBox2.Controls.Add(this.txtPendiente);
            this.groupBox2.Controls.Add(this.lblNum);
            this.groupBox2.Controls.Add(this.lblFecPago);
            this.groupBox2.Controls.Add(this.lblPendiente);
            this.groupBox2.Controls.Add(this.txtFecPag);
            this.groupBox2.Controls.Add(this.txtTipCambio);
            this.groupBox2.Controls.Add(this.lblTipCambio);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 103);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // lblFVence
            // 
            this.lblFVence.AutoSize = true;
            this.lblFVence.Location = new System.Drawing.Point(8, 72);
            this.lblFVence.Name = "lblFVence";
            this.lblFVence.Size = new System.Drawing.Size(123, 16);
            this.lblFVence.TabIndex = 119;
            this.lblFVence.Text = "Fecha Vencimiento";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.ItemHeight = 16;
            this.cboMoneda.Location = new System.Drawing.Point(374, 43);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(102, 24);
            this.cboMoneda.TabIndex = 118;
            this.cboMoneda.SelectionChangeCommitted += new System.EventHandler(this.cboMoneda_SelectionChangeCommitted);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(263, 46);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(58, 16);
            this.lblMoneda.TabIndex = 45;
            this.lblMoneda.Text = "Moneda";
            // 
            // txtPendiente
            // 
            this.txtPendiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPendiente.Enabled = false;
            this.txtPendiente.Location = new System.Drawing.Point(374, 70);
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.ReadOnly = true;
            this.txtPendiente.Size = new System.Drawing.Size(102, 22);
            this.txtPendiente.TabIndex = 15;
            this.txtPendiente.TabStop = false;
            this.txtPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = true;
            this.lblPendiente.Location = new System.Drawing.Point(263, 73);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(69, 16);
            this.lblPendiente.TabIndex = 115;
            this.lblPendiente.Text = "Pendiente";
            // 
            // txtTipCambio
            // 
            this.txtTipCambio.BackColor = System.Drawing.Color.White;
            this.txtTipCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipCambio.Location = new System.Drawing.Point(374, 18);
            this.txtTipCambio.Name = "txtTipCambio";
            this.txtTipCambio.ReadOnly = true;
            this.txtTipCambio.Size = new System.Drawing.Size(67, 22);
            this.txtTipCambio.TabIndex = 44;
            this.txtTipCambio.TabStop = false;
            this.txtTipCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTipCambio
            // 
            this.lblTipCambio.AutoSize = true;
            this.lblTipCambio.Location = new System.Drawing.Point(263, 20);
            this.lblTipCambio.Name = "lblTipCambio";
            this.lblTipCambio.Size = new System.Drawing.Size(105, 16);
            this.lblTipCambio.TabIndex = 17;
            this.lblTipCambio.Text = "Tipo de Cambio";
            // 
            // PagoEng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 543);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bttncerrar);
            this.Controls.Add(this.bttnGrabar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PagoEng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enganches";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtFecPag;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFecPago;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblPagoCapital;
        private System.Windows.Forms.Label lblNoTarjeta;
        private System.Windows.Forms.Label lblFExpira;
        private System.Windows.Forms.ComboBox cboDepositado;
        private System.Windows.Forms.Label lblNoAutoriza;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtNoAuto;
        private System.Windows.Forms.Label lblDepositadoEn;
        private System.Windows.Forms.Label lblseparador;
        private System.Windows.Forms.TextBox txtFExpAno;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.TextBox txtFExpMes;
        private System.Windows.Forms.Button bttncerrar;
        private System.Windows.Forms.Button bttnGrabar;
        private System.Windows.Forms.DateTimePicker cboFRecep;
        private System.Windows.Forms.Label lblFRecep;
        private System.Windows.Forms.Label lblFRef;
        private System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Label lblInteres;
        private System.Windows.Forms.TextBox txtFecRef;
        private System.Windows.Forms.ComboBox cboTipPago;
        private System.Windows.Forms.Label lblTipag;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.TextBox txtPendiente;
        private System.Windows.Forms.Label lblPendiente;
        private System.Windows.Forms.TextBox txtTipCambio;
        private System.Windows.Forms.Label lblTipCambio;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Label lblFVence;
        private System.Windows.Forms.TextBox txtNoTarjeta;
        private System.Windows.Forms.DateTimePicker cboFRef;
    }
}