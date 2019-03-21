using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OTLC.Models;

namespace OTLC
{
    public partial class PagoCapital : Form
    {
        Conexion cx = new Conexion();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        Arreglos arr = new Arreglos();
        Usuarios usr = new Usuarios();
        llenarComboBox llenar = new llenarComboBox();
        PagoDetalle pago;
        PagoCC cc;
        PagoEng pe;

        bool pendiente;
        private double suma = 0;

        public PagoCapital()
        {
            InitializeComponent();
            permiso();
            llenarCombos(); 
        }

        private void permiso()
        {
            if (Sesion.CobranzaAplicarPagos == false)
            {
                tabControl1.Enabled = false;
                groupBox2.Enabled = false;
            }

        }

        private void txtNoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender, e);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Consultar();
            }
        }

        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            if (string.IsNullOrEmpty(txtNoCon.Text))
            { MessageBox.Show("Debe proporcionar el Numero de Contrato para la busqueda de la información."); }

            else
            {
                AsignaValores();

                if (cm.ExisteContrato(Convert.ToInt32(comboTipoCon.SelectedValue),Convert.ToInt32(txtNoCon.Text)) ==0)
                {
                    MessageBox.Show("El contrato " + comboTipoCon.Text + "-" + cto.NumCto + " no existe!");
                }
                else
                {                   
                    cm.LeerContrato(cto);
                    arr.LeerArreglo(cto.FolioContrato,cm.NoArregloMax);
                    usr.LeerUsuario(cto.Vlo);
                    AsignaValores();
                    llenarDGV();
                    llenarDGVEngVencidos();
                    llenarDGVTratoInicial();

                    if (Sesion.CobranzaPagoCapital == true)
                    {
                        bttnPAGOCAP.Enabled = true;
                    }

                    if (Sesion.CobranzaPagoContrato == true)
                    {
                        bttnCCont.Enabled = true;
                    }

                    if (Sesion.CobranzaPagoEnganche == true)
                    {
                        bttnEng.Enabled = true;
                    }

                }

            }
        }

        private void AsignaValores()
        {           
            txtFinanciado.Text = "Financiado";
            txtFolio.Text = cto.FolioContrato.ToString();
            txtLead.Text = cto.Lead.ToString();

            if (cto.FechaProceso == Convert.ToDateTime("01/01/50")|| cto.FechaProceso == Convert.ToDateTime("01/01/0001"))
            { txtFechaProc.Text = ""; }
            else
            { txtFechaProc.Text = cto.FechaProceso.ToString("d");  }

            if (cto.FechaVta == Convert.ToDateTime("01/01/50")|| cto.FechaVta == Convert.ToDateTime("01/01/0001"))
            { txtFechaVta.Text = ""; }
            else
            { txtFechaVta.Text = cto.FechaVta.ToString("d");       }

            if (cto.FechaCxl == Convert.ToDateTime("01/01/50")|| cto.FechaCxl == Convert.ToDateTime("01/01/0001"))
            { txtFechaCxl.Text = ""; }
            else
            {  txtFechaCxl.Text = cto.FechaCxl.ToString("d"); }

            
            txtStat1.Text = cm.Status1;
            txtStat2.Text = cm.Status2;

            comboIdioma.SelectedValue = cto.IdIdioma;

            txtNom1.Text = cto.Nombre1;
            txtNom2.Text = cto.Nombre2;

            txtMoneda.Text = cto.idMoneda == 1 ? "Pesos" : "Dolares";

            txtMembresia.Text = cm.Membresia;
            txtMembresiaDesc.Text = cm.Temporada;
            txtMembCom.Text = cm.Membresia;//consulta.MembresiaCom;
            txtMemComiDesc.Text = cm.Temporada;//consulta.MembresiaComDesc;
            txtPuntos.Text = cto.Semanas.ToString();
            txtPrecioVta.Text = cto.PrecioVenta.ToString("N");
            txtEngPact.Text = cto.EnganchePactado.ToString("N");
            txtEngCobrado.Text = cto.EngancheCobrado.ToString("N");
            txtPorcEngPact.Text = cto.PorEnganchePac.ToString("N");
            txtPorcEngCobrado.Text = cto.PorEngancheCob.ToString("N");
            txtEquity.Text = cto.PagadoUpDown.ToString("N");//m.Equity.ToString("N");PagadoUpDown
            txtSaldocontrato.Text = cto.Saldo.ToString("N");
            txtCCpactado.Text = cto.CCPactado.ToString("N");
            txtCCCobrado.Text = cto.CCCobrado.ToString("N");
            txtPlazo.Text = cto.Plazo.ToString();
            txtTasaInteres.Text = cto.TazaInteres.ToString("N");
            txtMensualidad.Text = cto.ImporteMensualidad.ToString("N");

            if (cto.FecprimmenActual == Convert.ToDateTime("01/01/50")|| cto.FecprimmenActual == Convert.ToDateTime("01/01/0001"))
            { txtPrimMensua.Text = ""; }
            else { txtPrimMensua.Text = cto.FecprimmenActual.ToString("d"); }

            if (cto.Fecultmen == Convert.ToDateTime("01/01/50")|| cto.Fecultmen == Convert.ToDateTime("01/01/0001"))
            { txtUltMensua.Text = ""; }
            else { txtUltMensua.Text = cto.Fecultmen.ToString("d"); }

            txtPrecioList.Text = cto.PrecioLista.ToString("N");
            txtPrecioListaCom.Text = cto.PrecioListaCom.ToString("N");
            txtSemList.Text = cto.SemanasLista.ToString();
            txtSemLisCom.Text = cto.Semliscom.ToString();

            if (cto.PagarComision == "True")
            {  txtPagarComi.Text = "Si";  }
            else
            {  txtPagarComi.Text = "No";  }


            txtVLO.Text = usr.Nombre;
            txtTipCambio.Text = cto.TipoCambio.ToString("N4");
            txtCargoTC1.Text = cto.CargoTC1.ToString("N");
            txtCargoTC2.Text = cto.CargoTC2.ToString("N");
            txtSaldoFinanciado.Text = cto.SaldoFinanciado.ToString("N");
            txtNoMensuaPag.Text = cto.NoMensualidadesPagadas.ToString();
            txtNoMensuaAdel.Text = cto.NoMensualidadesAdelantadas.ToString();


            txtArrPorcEngPac.Text = arr.PorEnganchePac.ToString("N");
            txtArrEngPac.Text = arr.EnganchePactado.ToString("N");
            txtArrSaldoContrato.Text = arr.SaldoContrato.ToString("N");
            txtArrPlazo.Text = arr.Plazo.ToString();
            txtArrTazaInteres.Text = arr.TazaInteres.ToString("N");
            txtArrMensualidad.Text = arr.ImporteMensualidad.ToString("N");

            if (arr.FecprimmenActual == Convert.ToDateTime("01/01/50")|| arr.FecprimmenActual == Convert.ToDateTime("01/01/0001"))
            { txtArrPriMensua.Text = ""; }
            else { txtArrPriMensua.Text = arr.FecprimmenActual.ToString("d"); }

            if (arr.Fecultmen == Convert.ToDateTime("01/01/50")|| arr.Fecultmen == Convert.ToDateTime("01/01/0001"))
            { txtArrUltMensua.Text = ""; }
            else { txtArrUltMensua.Text = arr.Fecultmen.ToString("d"); }

            txtArrSaldoFinanciado.Text = arr.SaldoFinanciadoActual.ToString("N");
            txtArrNoMensuaPag.Text = arr.NoMensualidadesPagadas.ToString();
            txtArrNoMensuaAdel.Text = arr.NoMensualidadesAdelantadas.ToString();

            //asigna las iniciales del Tipo de Contrato
            cm.TipCon = comboTipoCon.DisplayMember;

        }

        private void llenarCombos()
        {
            llenar.TipoCon(comboTipoCon);
            llenar.Idioma(comboIdioma);
        }

        private void llenarDGV()
        {
            string sql = "select Consec AS 'No.', NoArregloM AS 'No. ARREGLO', t.Nombre AS 'TIPO DE PAGO',NoMensualidad AS 'No. MENSU',NoEnganche AS 'No. ENGA', "+
                         "f.Nombre AS 'FORMA DE PAGO',Importe AS 'IMPORTE',InteresMoratorio AS 'INTERES MORATORIO',s.Nombre AS 'STATUS DEL PAGO',FechaPago AS 'FECHA DEL PAGO', "+
                         "PagosCubiertos AS 'PAGOS CUBIERTOS',NoTarjeta AS 'No. TARJETA', Convert(varchar(20), month(FechaExpiracion)) + '/' + Convert(varchar(20), year(FechaExpiracion)) 'EXPIRACION',NoAutorizacion AS 'No. AUTORIZACION', " +
                         "Cancelado AS 'CANCELADO',TipoCambio AS 'TIPO DE CAMBIO',IdFactura AS 'ID FACTURA' "+
                         "from Pagos p left join TiposPago t on p.idTippag=t.idTippag  " +
                         "left join FormasPago f on p.idForpag=f.idForpag " +
                         "left join StatusPago s on p.idStatusPago=s.idStatusPago  where p.FolioContrato = @Folio and p.idStatusPago = 1 ";


            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvPagos.Columns.Clear();
                    dgvPagos.Columns.Add(new DataGridViewCheckBoxColumn { Name = "CANCELADO", DataPropertyName = "CANCELADO" });

                    dgvPagos.DataSource = dt;

                    dgvPagos.Columns["CANCELADO"].DisplayIndex = 14;

                    con.Close();
                }

            }

            FormatoDgvPagos();

        }

        private void llenarDGVEngVencidos()
        {
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();


            string sum = "select sum (Saldo) from Pagos where FolioContrato = @Folio and idTippag = 1 and idStatusPago = 2 and Pagado = 'False' and Saldo>0 /*and FechaReferencia< SYSDATETIME()*/";

                using (SqlCommand comando = new SqlCommand(sum, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suma = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        }
                    }
                }


            string sql = "select p.Consec 'No.',tp.Nombre 'Tipo de Pago',p.NoEnganche 'No. Enganche', fp.Nombre 'Forma de Pago', p.Importe 'Importe', p.Saldo 'Saldo', "+
                         "'' 'Fecha de Pago',p.FechaReferencia 'Fecha Vencimiento',sp.Nombre 'Status del Pago',p.NoTarjeta 'No. de Tarjeta', "+
                         "CONVERT(varchar(2), month(p.FechaExpiracion)) + '/' + CONVERT(varchar(4), year(p.FechaExpiracion)) 'Expiracion', "+
                         "p.NoAutorizacion 'No. de Autorización',p.TipoCambio 'Tipo de Cambio' "+
                            "from Pagos p left join TiposPago tp on p.idTippag = tp.idTippag "+
                            "left join FormasPago fp on p.idForpag = fp.idForpag "+
                            "left join StatusPago sp on p.idStatusPago = sp.idStatusPago "+
                            "where p.FolioContrato = @Folio and p.idTippag = 1 and p.idStatusPago = 2 and p.Pagado = 'False' and Saldo>0 /*and FechaReferencia< SYSDATETIME()*/";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    DataTable dc = new DataTable();

                    da.Fill(dt);

                    dgvEngVencidos.Columns.Clear();
                    dgvEngVencidos.DataSource = dt;

                }

                con.Close();
            }

            FormatoDgvEngVencidos();

        }

        private void llenarDGVTratoInicial()
        {
            string sql = "Select tp.Nombre 'Tipo de Pago',p.Importe 'Importe',(case when p.idStatusPago = 2 then '' else Convert(varchar(20),p.FechaPago,103) end) 'Fecha de Pago', " +
                         "p.NoTarjeta 'No. de Tarjeta', fp.Nombre 'Forma de Pago', (case when p.idStatusPago=1 then '' else Convert(varchar(20),p.FechaReferencia,103) end) 'Fecha Futura de Pago', " +
                         "sp.Nombre 'Status', p.NoArregloM 'No. Arreglo',Consec " +
                         "from Pagos p left join TiposPago tp on p.idTippag = tp.idTippag left join FormasPago fp on p.idForpag = fp.idForpag "+
                         "left join StatusPago sp on p.idStatusPago = sp.idStatusPago where p.FolioContrato = @Folio and p.idTippag in (1,2) and Contrato = 'True'";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvTratoInicial.Columns.Clear();
                    dgvTratoInicial.DataSource = dt;

                    con.Close();
                }

            }

            this.dgvTratoInicial.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvTratoInicial.Columns["No. Arreglo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvTratoInicial.Columns["Fecha de Pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTratoInicial.Columns["Fecha Futura de Pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTratoInicial.Columns["Importe"].DefaultCellStyle.Format = "N";
            this.dgvTratoInicial.Columns["Consec"].Visible = false;
        }

        private void FormatoDgvPagos()
        {
            //aliniacion de columnas a la derecha
            this.dgvPagos.Columns["No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["No. ARREGLO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["No. MENSU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["No. ENGA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["IMPORTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["INTERES MORATORIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["PAGOS CUBIERTOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["TIPO DE CAMBIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["ID FACTURA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPagos.Columns["FECHA DEL PAGO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPagos.Columns["EXPIRACION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //formato divisa y fecha corta
            this.dgvPagos.Columns["IMPORTE"].DefaultCellStyle.Format = "N";
            this.dgvPagos.Columns["TIPO DE CAMBIO"].DefaultCellStyle.Format = "N";
            this.dgvPagos.Columns["FECHA DEL PAGO"].DefaultCellStyle.Format = "d";

            //tamaño de las columnas   
            this.dgvPagos.Columns["No."].Width = 50;
            this.dgvPagos.Columns["No. ARREGLO"].Width = 50;
            this.dgvPagos.Columns["TIPO DE PAGO"].Width = 100;
            this.dgvPagos.Columns["No. MENSU"].Width = 50;
            this.dgvPagos.Columns["No. ENGA"].Width = 50;
            this.dgvPagos.Columns["FORMA DE PAGO"].Width = 100;
            this.dgvPagos.Columns["IMPORTE"].Width = 80;
            this.dgvPagos.Columns["INTERES MORATORIO"].Width = 80;
            this.dgvPagos.Columns["STATUS DEL PAGO"].Width = 80;
            this.dgvPagos.Columns["FECHA DEL PAGO"].Width = 80;
            this.dgvPagos.Columns["PAGOS CUBIERTOS"].Width = 50;
            this.dgvPagos.Columns["No. TARJETA"].Width = 120;
            this.dgvPagos.Columns["EXPIRACION"].Width = 80;
            this.dgvPagos.Columns["No. AUTORIZACION"].Width = 80;
            this.dgvPagos.Columns["CANCELADO"].Width = 50;
            this.dgvPagos.Columns["TIPO DE CAMBIO"].Width = 50;
            this.dgvPagos.Columns["ID FACTURA"].Width = 50;


            //Colorear de rojo los pagos cancelados
            for (int count = 0; count < dgvPagos.Rows.Count; count++)
            {
                if (Convert.ToBoolean(dgvPagos.Rows[count].Cells[14].Value) == true)
                {
                    dgvPagos.Rows[count].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FormatoDgvEngVencidos()
        {
            txtSumSaldo.Text = suma.ToString("N2");


            //aliniacion de columnas a la derecha
            this.dgvEngVencidos.Columns["No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvEngVencidos.Columns["No. Enganche"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvEngVencidos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvEngVencidos.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvEngVencidos.Columns["No. de Autorización"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvEngVencidos.Columns["Tipo de Cambio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //formato divisa y fecha corta
            this.dgvEngVencidos.Columns["Importe"].DefaultCellStyle.Format = "N";
            this.dgvEngVencidos.Columns["Saldo"].DefaultCellStyle.Format = "N";
            this.dgvEngVencidos.Columns["Tipo de Cambio"].DefaultCellStyle.Format = "N4";
            this.dgvEngVencidos.Columns["Fecha Vencimiento"].DefaultCellStyle.Format = "d";

        }

        private void bttnConsultar_Click_1(object sender, EventArgs e)
        {
            Consultar();
        }

        private void bttnPAGCAP_Click(object sender, EventArgs e)
        {
            PagoCapitalCap pc = new PagoCapitalCap(cto.FolioContrato);
            pc.ShowDialog();
            Consultar();
        }

        private void bttncerrar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvPagos_DoubleClick(object sender, EventArgs e)
        {
            pago = new PagoDetalle(cto.FolioContrato, Convert.ToInt32(dgvPagos.CurrentRow.Cells[0].Value.ToString()));
            pago.ShowDialog();

        }

        private void bttnCCont_Click(object sender, EventArgs e)
        {
            Pagos p = new Pagos();

            p.FolioContrato = cto.FolioContrato;

            p.ConsultaCxc(p,cto);

            if (p.noPagosCxc == 1 || (p.noPagosCxc > 1 && p.CCCobrado != p.MontoPagado))
            {
                p.Consec = 2;
                p.ConsultaPago(p);
                p.ImportePendiente(p,cto, 2, 0);

                if (p.FechaPago.ToString("d") == DateTime.Today.ToString("d")|| p.FechaPago.ToString("d") == DateTime.Today.AddDays(-1).ToString("d"))
                {
                    cc = new PagoCC(cto.FolioContrato);
                    cc.ShowDialog();
                    Consultar();
                }

                else
                {
                    MessageBox.Show("Esta opción solo aplica el dia " + p.FechaPago.ToString("d") + " en que se realizo el pago del Costo de Cierre");
                }
            }
            else
            {
                MessageBox.Show("El Costo de Cierre de este socio ya fue tratado");
            }     

        }

        private void bttnEng_Click(object sender, EventArgs e)
        {
            Pagos p = new Pagos();
            p.FolioContrato = cto.FolioContrato;

            PagPendientes(p);

            if (pendiente ==true)
            {
                pe = new PagoEng(p.FolioContrato,p.EngConsec);
                pe.ShowDialog();
                Consultar();
            }
            else
            {
                MessageBox.Show("No se encontro enganche con saldo pendiente");
            }
        }

        private void PagPendientes(Pagos p)
        {
            p.ConsultaEng(p);


            if (p.EngConsec > 0)
            {
                p.Consec = p.EngConsec;

                p.ConsultaPago(p);
                p.ImportePendiente(p,cto, p.idTippag, p.NoEnganche);

                if (p.Importe == p.MontoPagado)
                {
                    p.EngContrato(p);
                    pendiente = false;

                    PagPendientes(p);
                }
                else
                {
                    pendiente = true;
                }
            }
            else
            {
                pendiente = false;
            }
        }


        private void dgvTratoInicial_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTratoInicial.CurrentRow.Cells[6].Value.ToString() == "Pendiente")
            {
                Pagos p = new Pagos();
                p.FolioContrato = cto.FolioContrato;
                p.Consec = Convert.ToInt32(dgvTratoInicial.CurrentRow.Cells[8].Value.ToString());

                p.ConsultaPago(p);
                p.ImportePendiente(p,cto, p.idTippag, p.NoEnganche);

                if (p.Importe == p.MontoPagado)
                {
                    p.EngContrato(p);
                    MessageBox.Show("Se actualizo la información del pago");
                    Consultar();
                }
                else
                {
                    MessageBox.Show("INFORMACIÓN ENGANCHE NO. "+p.NoEnganche.ToString()+ System.Environment.NewLine
                        + "TOTAL A PAGAR: "+p.Importe.ToString("N2") + System.Environment.NewLine
                        + "MONTO PAGADO: " +p.MontoPagado.ToString("N2") + System.Environment.NewLine
                        + "PENDIENTE POR PAGAR: "+(p.Importe-p.MontoPagado).ToString("N4"));
                }
            }
        }
    }
}
