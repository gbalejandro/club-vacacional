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
    public partial class Produccion : Form
    {
        Conexion cx = new Conexion();
        Contratos c = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        EstadoPts edo = new EstadoPts();

        DataTable dt;
        
       // bool cargado = false;

        public Produccion()
        {
            InitializeComponent();      
            LlenarCboTipCto();
            Registros();
            Permisos();
        }

        private void Permisos()
        {
            if (Sesion.EstadisticasTablaGralCtos == false)
            {
                chPorcentaje.Enabled = false;
                bttnExcel.Enabled = false;
                bttnConsultar.Enabled = false;
                FechaInicio.Enabled = false;
                FechaFin.Enabled = false;
            }
        }

        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;           
            LlenarDgv();
            Cursor.Current = Cursors.Default;
        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void cboTipoCon_SelectionChangeCommitted(object sender, EventArgs e)
        {
          // Filtros();
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

        private void LlenarDgv()
        {
            dt = new DataTable();
            SqlConnection con = new SqlConnection(cx.cadenaConexion);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("spCN_TablaGeneral", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@FechaI", SqlDbType.VarChar, 20);
            da.SelectCommand.Parameters.Add("@FechaF", SqlDbType.VarChar, 20);

            da.SelectCommand.Parameters["@FechaI"].Value = FechaInicio.Value.ToString("dd/MM/yy");
            da.SelectCommand.Parameters["@FechaF"].Value = FechaFin.Value.ToString("dd/MM/yy");

            da.Fill(dt);

            dgvTabGral.Columns.Clear();

            dgvTabGral.DataSource = dt;

            dgvTabGral.Columns.Add(Name="PORCENTAJE","PORCENTAJE");  
            dgvTabGral.Columns["PORCENTAJE"].DisplayIndex = 44;
  
            if (chPorcentaje.Checked == true)
            {  Porcentaje(); }
            else
            {  dgvTabGral.Columns["PORCENTAJE"].Visible = false;      }

  
            DarFormato();           
            con.Close();
        }
    
        private void Registros()
        {
            lblReg.Text = "No. Registros: " + (dgvTabGral.RowCount);
            lblTabGralCto.Text = "Tabla General de Contratos del " + FechaInicio.Value.ToString("dd MMM yyyy") + " al " + FechaFin.Value.ToString("dd MMM yyyy");
        }

        /*
        private void Filtros()
        {
            if (cargado == true)
            {
                string fieldName1 = string.Concat("[", dt.Columns[4].ColumnName, "]");
                dt.DefaultView.Sort = fieldName1;
                DataView view1 = dt.DefaultView;
                view1.RowFilter = string.Empty;

                if (cboTipoCon.Text != "-TODOS-")
                {
                    view1.RowFilter = fieldName1 + " Like '%" + cboTipoCon.Text + "%'";
                   // dgvTabGral.Columns.Clear();
                    dgvTabGral.DataSource = view1;

                    dgvTabGral.Columns.Add(Name = "PORCENTAJE", "PORCENTAJE");
                    dgvTabGral.Columns["PORCENTAJE"].DisplayIndex = 44;
                }


                DarFormato();
            }
        }
            */
        private void Porcentaje()
        {
            for (int count = 0; count < dgvTabGral.Rows.Count; count++)
            {
                cm.Limpiar(c);
                cm.Existe = Convert.ToInt32(dgvTabGral.Rows[count].Cells[0].Value);//"Folio"
                cm.LeerContrato(c);

                edo.LimpiarInfo();
                edo.CalculaPorcentaje(c);

                dgvTabGral.Rows[count].Cells[44].Value = edo.Porcentaje;
            }
        }

        private void DarFormato()
        {
           // cargado = true;
            bttnExcel.Enabled = true;
            cboTipoCon.Enabled = true;
            dgvTabGral.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTabGral.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;        

            ColumnasNombres();
            ColumnasAlineacion();
            ColumnasTamaño();
            ColumnasFormato();
            Registros();

            for (int count = 0; count < dgvTabGral.Columns.Count; count++)
            {
                dgvTabGral.Columns[count].SortMode= DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void ColumnasNombres()
        {
            dgvTabGral.Columns[0].HeaderText = "Folio";
            dgvTabGral.Columns[1].HeaderText = "Moneda";
            dgvTabGral.Columns[2].HeaderText = "Status";
            dgvTabGral.Columns[3].HeaderText = "StatusCon2";
            dgvTabGral.Columns[4].HeaderText = "Contrato";
            dgvTabGral.Columns[5].HeaderText = "Número";
            dgvTabGral.Columns[6].HeaderText = "Cliente";
            dgvTabGral.Columns[7].HeaderText = "Fecha Venta";
            dgvTabGral.Columns[8].HeaderText = "Mes Venta";
            dgvTabGral.Columns[9].HeaderText = "Año Venta";
            dgvTabGral.Columns[10].HeaderText = "Plazo";
            dgvTabGral.Columns[11].HeaderText = "Precio Venta";
            dgvTabGral.Columns[12].HeaderText = "Costo Contrato";
            dgvTabGral.Columns[13].HeaderText = "Intereses";
            dgvTabGral.Columns[14].HeaderText = "Total Contrato";
            dgvTabGral.Columns[15].HeaderText = "CC Cobrado";
            dgvTabGral.Columns[16].HeaderText = "Enganche Pactado";
            dgvTabGral.Columns[17].HeaderText = "Enganche Cobrado";
            dgvTabGral.Columns[18].HeaderText = "Equity";
            dgvTabGral.Columns[19].HeaderText = "Mensualidades Cobradas";
            dgvTabGral.Columns[20].HeaderText = "Pago Capital";
            dgvTabGral.Columns[21].HeaderText = "Total Cobrado";
            dgvTabGral.Columns[22].HeaderText = "CC por Cobrar";
            dgvTabGral.Columns[23].HeaderText = "Enganche por Cobrar";
            dgvTabGral.Columns[24].HeaderText = "Mensualidades por Cobrar";
            dgvTabGral.Columns[25].HeaderText = "Interes por Cobrar";
            dgvTabGral.Columns[26].HeaderText = "Total por Cobrar";
            dgvTabGral.Columns[27].HeaderText = "Saldo por Cobrar sin Interes";
            dgvTabGral.Columns[28].HeaderText = "Num CC Pagados";
            dgvTabGral.Columns[29].HeaderText = "Num Enganches Pagados";
            dgvTabGral.Columns[30].HeaderText = "Num Mensualidades Pagadas";
            dgvTabGral.Columns[31].HeaderText = "Enganche Total";
            dgvTabGral.Columns[32].HeaderText = "Nacionalidad";
            dgvTabGral.Columns[33].HeaderText = "Refinanciado";
            dgvTabGral.Columns[34].HeaderText = "Dias Morosidad";
            dgvTabGral.Columns[35].HeaderText = "Dias Morosidad Enganche";
            dgvTabGral.Columns[36].HeaderText = "Último Pago";
            dgvTabGral.Columns[37].HeaderText = "Vencimiento Último Pago";
            dgvTabGral.Columns[38].HeaderText = "Fin. GUSA";
            dgvTabGral.Columns[39].HeaderText = "Desc. Bancomext";
            dgvTabGral.Columns[40].HeaderText = "Interés Cobrado";
            dgvTabGral.Columns[41].HeaderText = "1er Pago Mensualidad";
            dgvTabGral.Columns[42].HeaderText = "Ult. Mens. Aplicada";
            dgvTabGral.Columns[43].HeaderText = "Ult. Mens. Pagada";
        }

        private void ColumnasAlineacion()
        {
            dgvTabGral.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //"Folio";
            dgvTabGral.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //"Número";
            dgvTabGral.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //"Fecha Venta";

            for (int i = 8; i <= 31; i++)
            {
                dgvTabGral.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 

            }

            dgvTabGral.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // "DiasMorosidad";
            dgvTabGral.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // "DiasMorosidadEnganche";
            dgvTabGral.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // "Último Pago";
            dgvTabGral.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // "Vencimiento Último Pago";
            dgvTabGral.Columns[40].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // "Interés Cobrado";
            dgvTabGral.Columns[41].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // "1er Pago Mensualidad";
            dgvTabGral.Columns[42].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // "Ult. Mens. Aplicada";
            dgvTabGral.Columns[43].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // "Ult. Mens. Pagada";
            dgvTabGral.Columns[44].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // ""PORCENTAJE"";

        }

        private void ColumnasTamaño()
        {
            dgvTabGral.Columns[0].Width = 55;// "Folio";
            dgvTabGral.Columns[1].Width = 55;// "Moneda";
            dgvTabGral.Columns[2].Width = 200;// "Status";
            dgvTabGral.Columns[3].Width = 200;// "StatusCon2";
            dgvTabGral.Columns[4].Width = 80;// "Contrato";
            dgvTabGral.Columns[5].Width = 50;// "Número";
            dgvTabGral.Columns[6].Width = 300;// "Cliente";
        }

        private void ColumnasFormato()
        {
            dgvTabGral.Columns[7].DefaultCellStyle.Format  = "dd MMM yyyy";//"Fecha Venta";

            for (int i = 11; i <= 27; i++)
            {
                dgvTabGral.Columns[i].DefaultCellStyle.Format = "N";
            }

            dgvTabGral.Columns[31].DefaultCellStyle.Format = "N";// "Enganche Total";
            dgvTabGral.Columns[36].DefaultCellStyle.Format = "dd MMM yyyy";// "Último Pago";
            dgvTabGral.Columns[37].DefaultCellStyle.Format = "dd MMM yyyy";// "Vencimiento Último Pago";
            dgvTabGral.Columns[40].DefaultCellStyle.Format = "N";// "Interés Cobrado";
            dgvTabGral.Columns[41].DefaultCellStyle.Format = "dd MMM yyyy";// "1er Pago Mensualidad";
            dgvTabGral.Columns[44].DefaultCellStyle.Format = "N";// ""PORCENTAJE"";

        }

        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            Registros();
        }

        private void FechaFin_ValueChanged(object sender, EventArgs e)
        {
            Registros();
        }


    }
}
