using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using OTLC.Reports;
using OTLC.Models;

namespace OTLC
{
    public partial class EstadoPuntos : Form
    {
        Conexion cx = new Conexion();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();

        llenarComboBox llenar = new llenarComboBox();
        EstadoPts edo = new EstadoPts();
        VisorReportes vr = new VisorReportes();
        EstadoPtosEsp RepEsp = new EstadoPtosEsp();
        EstadoPtosIng RepIng = new EstadoPtosIng();
        EstadoPtosPort RepPort = new EstadoPtosPort();
        DataTable dt;

        public string NoContrato { get; set; }

        public EstadoPuntos()
        {
            InitializeComponent();
            ReporteReservas();
            permisos();
            llenarCombos();
        }

        private void permisos()
        {
            if (Sesion.ReservacionesAcc == false)
            {
                tabControl1.Enabled = false;
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

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender, e);
        }

        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void llenarCombos()
        {
            llenar.TipoCon(comboTipoCon);
            llenar.IdiomaDoctos(cboIdioma);
        }

        private void Consultar()
        {
            Inhabilitar();

            if (string.IsNullOrEmpty(txtNoCon.Text))
            { MessageBox.Show("Debe proporcionar el Numero de Contrato para la busqueda de la información."); }

            else
            {
                edo.LimpiarInfo();
                AsignaValores();

                if (cm.ExisteContrato(Convert.ToInt32(comboTipoCon.SelectedValue), Convert.ToInt32(txtNoCon.Text)) == 0)
                {
                    MessageBox.Show("El contrato " + comboTipoCon.Text + "-" + cto.NumCto + " no existe!");
                }
                else
                {
                    cm.LeerContrato(cto);
                    NoContrato = cm.TipCon + "-" + txtNoCon.Text;
                    AsignaValores();
                    if (Sesion.ReservacionesEdoPuntos == true)
                    {
                        Habilitar();
                    }

                }

            }
        }

        private void AsignaValores()
        {
            txtNoMem.Text = NoContrato;
            txtTipoMemb.Text = cm.Membresia;
            txtTitular.Text = cto.Nombre1;
            txtDuracion.Text = cm.Duracion.ToString();
            txtPuntos.Text = cto.Semanas.ToString();
            txtStatus.Text = cm.Status1;

            llenarDGV();

            edo.CalculaPuntos(cto);

            txtUsados.Text = edo.PtosUsados.ToString();
            txtDispPorcentaje.Text = edo.PtosPagoCap.ToString();
            txtDispActual.Text = edo.PtosDisPagoCap.ToString();
            txtPtosRestantes.Text = edo.PtosRestantesTotal.ToString();
            txtPorcentaje.Text = edo.Porcentaje.ToString();
        }

        private void llenarDGV()
        {
            string sql = "select ('Reservación No. '+Convert(varchar(50),Confirmacion))Reservacion," +
                "(case when UsaCertificado=1 then 0 else SemanasDescontar end) Puntos," +      
                "(case when Certificado = '' then 'No Aplica' else Certificado end) Certificado,Noches," +
                "(Convert(varchar(5), Adultos) + '.' + Convert(varchar(5), Menores1) + '.' + Convert(varchar(5), Menores2)) Personas," +
                "FechaLlegada 'Mes Ocupación' from Reservaciones where FolioContrato = @Folio and Status = 'C' order by 'Mes Ocupación'";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvReservas.Columns.Clear();

                    dgvReservas.DataSource = dt;

                    con.Close();
                }

            }

            lblNoReg.Text = "No. Registros:" + (dgvReservas.RowCount);

            //aliniacion de columnas a la derecha
            this.dgvReservas.Columns["Reservacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvReservas.Columns["Puntos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvReservas.Columns["Certificado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvReservas.Columns["Noches"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReservas.Columns["Personas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReservas.Columns["Mes Ocupación"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //fecha corta
            this.dgvReservas.Columns["Mes Ocupación"].DefaultCellStyle.Format = "d";

            //tamaño de las columnas   
            this.dgvReservas.Columns["Reservacion"].Width = 80;
            this.dgvReservas.Columns["Puntos"].Width = 25;
            this.dgvReservas.Columns["Certificado"].Width = 35;
            this.dgvReservas.Columns["Noches"].Width = 20;
            this.dgvReservas.Columns["Personas"].Width = 20;
            this.dgvReservas.Columns["Mes Ocupación"].Width = 100;

            int suma = 0;
            for (int count = 0; count < dgvReservas.Rows.Count; count++)
            {
                if (Convert.ToInt32(dgvReservas.Rows[count].Cells[1].Value) > 0)
                {
                    suma = suma + Convert.ToInt32(dgvReservas.Rows[count].Cells[1].Value);
                }
            }

            edo.PtosUsados = Convert.ToDouble(suma);
        }

        private void Inhabilitar()
        {
            txtDuracion.ReadOnly = true;
            bttnGrabar.Enabled = false;

            cboIdioma.Enabled = false;
            bttnImprimir.Enabled = false;
            cboIdioma.SelectedValue = 0;
        }

        private void Habilitar()
        {
            if (Sesion.ReservacionesMod == true)
            {
                txtDuracion.ReadOnly = false;
                bttnGrabar.Enabled = true;
            }

            cboIdioma.Enabled = true;
            bttnImprimir.Enabled = true;
            cboIdioma.SelectedValue = 1;
        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            edo.LimpiarEstadoPuntos();
            this.Hide();
        }

        private void bttnGrabar_Click(object sender, EventArgs e)
        {
            if (txtDuracion.Text != "")
            {
                if (cm.Duracion != Convert.ToInt32(txtDuracion.Text))
                {
                    if (MessageBox.Show("Confirmar cambio de Vigencia de Membresia de: " + cm.Duracion + " años por: " + txtDuracion.Text + " años.", "Modificar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        edo.VigenciaMembresia(cto, cm.Duracion,Convert.ToInt32(txtDuracion.Text));
                        Consultar();
                       // AsignaValores();
                    }
                }
                else
                {
                    MessageBox.Show("No hay cambios por guardar en la Vigencia de la Membresia");
                }
            }
            else
            {
                MessageBox.Show("No hay cambios por guardar: El valor no puede ser nulo");
            }
        }

        private void bttnImprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboIdioma.SelectedValue) == 2)
            {
                RepIngles();

            }
            else if (Convert.ToInt32(cboIdioma.SelectedValue) == 3)
            {
                RepPortugues();
            }
            else
            {
                RepEspañol();
            }

        }

        private void RepEspañol()
        {
            edo.ReservasEsp(RepEsp,cto.FolioContrato);
            RepEsp.SetParameterValue("NumMem", NoContrato);
            RepEsp.SetParameterValue("Titular", cto.Nombre1);
            RepEsp.SetParameterValue("Vigencia", cm.Duracion);
            RepEsp.SetParameterValue("Status", cm.Status1);
            RepEsp.SetParameterValue("TipMem", cm.Membresia);
            RepEsp.SetParameterValue("Porcentaje", edo.Porcentaje);
            RepEsp.SetParameterValue("PuntosMem", cto.Semanas);
            RepEsp.SetParameterValue("PuntosDispPagados", edo.PtosPagoCap);
            RepEsp.SetParameterValue("PuntosUsados", edo.PtosUsados);
            RepEsp.SetParameterValue("PuntosRestantesPagados", edo.PtosDisPagoCap);
            RepEsp.SetParameterValue("PuntosRestantesMem", edo.PtosRestantesTotal);

            vr = new VisorReportes(RepEsp);

            vr.ShowDialog();
        }

        private void RepIngles()
        {
            edo.ReservasIng(RepIng,cto.FolioContrato);
            RepIng.SetParameterValue("NumMem", NoContrato);
            RepIng.SetParameterValue("Titular", cto.Nombre1);
            RepIng.SetParameterValue("Vigencia", cm.Duracion);
            RepIng.SetParameterValue("Status", cm.Status1Idioma2);//traducir
            RepIng.SetParameterValue("TipMem", cm.TipMemIdioma2);//idioma2
            RepIng.SetParameterValue("Porcentaje", edo.Porcentaje);
            RepIng.SetParameterValue("PuntosMem", cto.Semanas);
            RepIng.SetParameterValue("PuntosDispPagados", edo.PtosPagoCap);
            RepIng.SetParameterValue("PuntosUsados", edo.PtosUsados);
            RepIng.SetParameterValue("PuntosRestantesPagados", edo.PtosDisPagoCap);
            RepIng.SetParameterValue("PuntosRestantesMem", edo.PtosRestantesTotal);

            vr = new VisorReportes(RepIng);

            vr.ShowDialog();

        }

        private void RepPortugues()
        {
            edo.ReservasPortu(RepPort,cto.FolioContrato);
            RepPort.SetParameterValue("NumMem", NoContrato);
            RepPort.SetParameterValue("Titular", cto.Nombre1);
            RepPort.SetParameterValue("Vigencia", cm.Duracion);
            RepPort.SetParameterValue("Status", cm.Status1Idioma3);
            RepPort.SetParameterValue("TipMem", cm.Membresia);
            RepPort.SetParameterValue("Porcentaje", edo.Porcentaje);
            RepPort.SetParameterValue("PuntosMem", cto.Semanas);
            RepPort.SetParameterValue("PuntosDispPagados", edo.PtosPagoCap);
            RepPort.SetParameterValue("PuntosUsados", edo.PtosUsados);
            RepPort.SetParameterValue("PuntosRestantesPagados", edo.PtosDisPagoCap);
            RepPort.SetParameterValue("PuntosRestantesMem", edo.PtosRestantesTotal);

            vr = new VisorReportes(RepPort);

            vr.ShowDialog();
        }



        //reporte de reservaciones
        private void bttnCerrar2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ReporteReservas()
        {
            string sql = "select r.FolioContrato,tc.Iniciales + '-' + Convert(varchar(50), c.NumCto) NumCto,c.Nombre1 Titular, count(*) NoReservas, " +
                        "(select COUNT(FolioContrato) from Reservaciones where UsaCertificado = 1  and Status = 'C' and FolioContrato = r.FolioContrato) NoCertificados, " +
                        "(select sum(SemanasDescontar) from Reservaciones where UsaCertificado = 0 and Status = 'C' and FolioContrato = r.FolioContrato) NoPuntosUsados " +
                        //"(select sum(SemanasDescontar) from Reservaciones where FolioContrato = r.FolioContrato and Status = 'C' and Certificado = '' ) NoPuntosUsados " +
                        "from Reservaciones r left join Contratos c on r.FolioContrato = c.FolioContrato " +
                        "inner join TiposContrato tc on c.idTipcon = tc.idtipcon " +
                        "where Status = 'C'  group by r.FolioContrato,tc.Iniciales,c.NumCto,c.Nombre1 order by NoReservas desc,NoPuntosUsados desc";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    dt = new DataTable();

                    da.Fill(dt);

                    dgvEstadistica.Columns.Clear();

                    dgvEstadistica.DataSource = dt;

                    con.Close();
                }

            }

            lblReg.Text = "No. Registros:" + (dgvEstadistica.RowCount);

            //aliniacion de columnas a la derecha
            this.dgvEstadistica.Columns["FolioContrato"].Visible = false;//.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvEstadistica.Columns["NoReservas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvEstadistica.Columns["NoCertificados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvEstadistica.Columns["NoPuntosUsados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


        }

        private void bttnExcel_Click(object sender, EventArgs e)
        {

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {

                Cursor.Current = Cursors.WaitCursor;

                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();

                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                //encabezados
                hoja_trabajo.Cells[1, 1] = "CONTRATO";
                hoja_trabajo.Cells[1, 2] = "TITULAR";
                hoja_trabajo.Cells[1, 3] = "No. RESERVAS";
                hoja_trabajo.Cells[1, 4] = "No. CERTIFICADOS";
                hoja_trabajo.Cells[1, 5] = "No. PUNTOS USADOS";

                hoja_trabajo.Cells[1, 1].Font.Bold = true;
                hoja_trabajo.Cells[1, 2].Font.Bold = true;
                hoja_trabajo.Cells[1, 3].Font.Bold = true;
                hoja_trabajo.Cells[1, 4].Font.Bold = true;
                hoja_trabajo.Cells[1, 5].Font.Bold = true;
     
                //Recorremos el DataGridView rellenando la hoja de trabajo
                int x = 1;
                for (int i = 0; i < dgvEstadistica.Rows.Count; i++) //renglones
                {                   
                    for (int j = 1; j < dgvEstadistica.Columns.Count; j++)//columnas
                    {
                            hoja_trabajo.Cells[x+1, j] = dgvEstadistica.Rows[i].Cells[j].Value.ToString();
                    }
                    x++;
                }
            
                libros_trabajo.SaveAs(fichero.FileName,Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                
                libros_trabajo.Close(true);
                aplicacion.Quit();

                Cursor.Current = Cursors.Default;                

                Process.Start(fichero.FileName);
                
            }
        }

        private void dgvEstadistica_DoubleClick(object sender, EventArgs e)
        {
            string contrato=  dgvEstadistica.CurrentRow.Cells[1].Value.ToString();
            string numeros = "";
            string letras = "";

            foreach (Char val in contrato)
            {
                if (Char.IsNumber(val))
                {
                    numeros = numeros + val;
                }
                else if (Char.IsLetter(val))
                {
                    letras = letras + val;
                }
            }

            TipCon(letras);
            cto.NumCto=Convert.ToInt32(numeros);

            txtNoCon.Text = numeros.ToString();
            comboTipoCon.SelectedValue = cto.idTipcon;

            Consultar();

            tabPage1.Show();
            tabControl1.SelectedTab = tabPage1;

        }

        private void TipCon(string letras)
        {
            string sql = "select distinct idtipcon from  TiposContrato where Iniciales=@letras";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@letras", SqlDbType.VarChar).Value = letras;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cto.idTipcon = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }
                con.Close();
            }
        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
