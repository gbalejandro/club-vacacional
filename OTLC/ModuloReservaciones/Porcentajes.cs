using OTLC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTLC
{
    public partial class Porcentajes : Form
    {
        Conexion cx = new Conexion();
        Contratos c = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        EstadoPts edo = new EstadoPts();

        DataTable dt;
        DataView dv;

        public Porcentajes()
        {
            InitializeComponent();
            Permisos();
            Inicio();
        }

        private void Permisos()
        {
            if (Sesion.ReservacionesPorcentajes == false)
            {
                gpoFiltros.Enabled = false;
                dgvTabGral.Enabled = false;
                bttnConsultar.Enabled = false;
            }
        }

        private void Inicio()
        {
            LlenarCboTipCto();
            LlenarCboTipMem();
            LlenarCboStat();
            lblReg.Text = "No. Registros: " + (dgvTabGral.RowCount);
        }

        private void LlenarCboTipCto()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                string sql = "select idtipcon, Iniciales from TiposContrato order by idTipvta";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            dt.Rows.Add(new object[] { 0, "-TODOS-" });
            cboTipoCon.DisplayMember = "Iniciales";
            cboTipoCon.ValueMember = "idtipcon";
            cboTipoCon.DataSource = dt;

            cboTipoCon.SelectedValue = 0;
        }

        private void LlenarCboTipMem()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                string sql = "select idTipmem, Nombre from TiposMembresia order by idTipmem";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            dt.Rows.Add(new object[] { 0, "-TODOS-" });
            cboTipMem.DisplayMember = "Nombre";
            cboTipMem.ValueMember = "idTipmem";
            cboTipMem.DataSource = dt;

            cboTipMem.SelectedValue = 0;
        }

        private void LlenarCboStat()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                string sql = "select idStatusCon1,Nombre from StatusContratos1";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            dt.Rows.Add(new object[] { 0, "-TODOS-" });
            cboStatus.DisplayMember = "Nombre";
            cboStatus.ValueMember = "idStatusCon1";
            cboStatus.DataSource = dt;

            cboStatus.SelectedValue = 0;
        }

        private void LlenarDgv()
        {
            string sql = "";

            int tc = Convert.ToInt32(cboTipoCon.SelectedValue);
            int tm = Convert.ToInt32(cboTipMem.SelectedValue);
            int s1 = Convert.ToInt32(cboStatus.SelectedValue);

            dt = new DataTable();
            SqlConnection con = new SqlConnection(cx.cadenaConexion);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("spCN_Porcentajes", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);
            dv = new DataView(dt);

            if (tc > 0 || tm > 0 || s1 > 0)
            {
                sql = tc > 0 ? "idTipcon=" + tc : sql;

                if (tm > 0)
                {
                    sql = tc > 0 ? sql + " and idTipmem="+ tm : "idTipmem =" + tm;
                }

                if (s1 > 0)
                {
                    sql = tc > 0 || tm>0 ? sql+ " and idStatusCon1=" + s1 : "idStatusCon1=" + s1;
                }

                dv.RowFilter = sql;
            }

            dgvTabGral.Columns.Clear();
            dgvTabGral.DataSource = dv;

            con.Close();

            lblReg.Text = "No. Registros:" + (dgvTabGral.RowCount);
           
            Porcentaje();
            DarFormato();             
        }

        private void DarFormato()
        {
            bttnExcel.Enabled = true;
            cboTipoCon.Enabled = true;
            dgvTabGral.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTabGral.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;

            dgvTabGral.Columns[0].Visible = false;//folio
            dgvTabGral.Columns[1].HeaderText = "Nombre del Titular";
            dgvTabGral.Columns[2].HeaderText = "Numero de Contrato";
            dgvTabGral.Columns[3].HeaderText = "Tipo de Membresía";
            dgvTabGral.Columns[4].HeaderText = "Precio Membresía";
            dgvTabGral.Columns[5].HeaderText = "Porcentaje pagado";
            dgvTabGral.Columns[6].HeaderText = "Status";
            dgvTabGral.Columns[7].HeaderText = "Puntos Adquiridos";
            dgvTabGral.Columns[8].HeaderText = "Puntos Utilizados";
            dgvTabGral.Columns[9].HeaderText = "Fecha de la venta";
            dgvTabGral.Columns[10].HeaderText = "Tipo Cambio";
            dgvTabGral.Columns[11].HeaderText = "Afiliación Interval";
            dgvTabGral.Columns[12].HeaderText = "Afiliación RCI";
            dgvTabGral.Columns[13].HeaderText = "Nacionalidad";
            dgvTabGral.Columns[14].Visible = false;//idtipcon
            dgvTabGral.Columns[15].Visible = false;//idtipmem
            dgvTabGral.Columns[16].Visible = false;//idstatus
            dgvTabGral.Columns[17].Visible = false;//seguimiento

            dgvTabGral.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTabGral.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTabGral.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTabGral.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTabGral.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTabGral.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTabGral.Columns[1].Width = 350;
            dgvTabGral.Columns[2].Width = 150;
            dgvTabGral.Columns[3].Width = 150;
            dgvTabGral.Columns[6].Width = 150;

            dgvTabGral.Columns[4].DefaultCellStyle.Format = "N";
            dgvTabGral.Columns[9].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvTabGral.Columns[5].DefaultCellStyle.Format = "N4";
            dgvTabGral.Columns[10].DefaultCellStyle.Format = "N4";
        }

        private void Porcentaje()
        {
            double porciento=0;
            string status = "";

            for (int count = 0; count < dgvTabGral.Rows.Count; count++)
            {
                porciento = Convert.ToDouble(dgvTabGral.Rows[count].Cells[5].Value);
                status= Convert.ToString(dgvTabGral.Rows[count].Cells[16].Value);

                if ( porciento>= 18 && porciento <= 21 && status=="S")
                {
                    dgvTabGral.Rows[count].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
            }
        }

        private void bttnExcel_Click(object sender, EventArgs e)
        {
            if (dgvTabGral.RowCount > 0)
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
                    for (int i = 0; i < dgvTabGral.Columns.Count; i++)
                    {
                        hoja_trabajo.Cells[1, i + 1] = dgvTabGral.Columns[i].HeaderText;
                        hoja_trabajo.Cells[1, i + 1].Font.Bold = true;
                    }

                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    for (int i = 0; i < dgvTabGral.Rows.Count; i++) //renglones
                    {
                        for (int j = 0; j < dgvTabGral.Columns.Count; j++)//columnas
                        {
                            hoja_trabajo.Cells[i + 2, j + 1] = dgvTabGral.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                    libros_trabajo.Close(true);
                    aplicacion.Quit();

                    Cursor.Current = Cursors.Default;

                    Process.Start(fichero.FileName);
                }
            }
        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LlenarDgv();
            Cursor.Current = Cursors.Default;
        }
    }
}
