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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace OTLC
{
    public partial class Cumpleaños : Form
    {
        Conexion c = new Conexion();
        Fechas fec = new Fechas();
        string sql;

        public Cumpleaños()
        {
            InitializeComponent();
            Permisos();
            invisibles();
        }

        private void Permisos()
        {
            if (Sesion.ReservacionesCumpleaños == false)
            {
                tabControl1.Enabled = false;
            }
        }

        private void rdioMes_CheckedChanged(object sender, EventArgs e)
        {
            lblRango.Visible = false;
            lblA.Visible = false;
            cboFechaIni.Visible = false;
            cboFechaFin.Visible = false;

            lblMes.Visible = true;
            cboMes.Visible = true;
            cboMes.SelectedIndex = 0;
            dgvSocios.Columns.Clear();
            sql = "";
        }

        private void rdioFechas_CheckedChanged(object sender, EventArgs e)
        {
            lblRango.Visible = true;
            lblA.Visible = true;
            cboFechaIni.Visible = true;
            cboFechaFin.Visible = true;

            lblMes.Visible = false;
            cboMes.Visible = false;
            dgvSocios.Columns.Clear();
            sql = "";
        }

        private void rdioSinFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioSinFecha.Checked == true)
            {
                invisibles();
                sql = "";
                llenarDGV();
            }
        }

        private void cboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void invisibles()
        {         
            lblRango.Visible = false;
            lblA.Visible = false;
            cboFechaIni.Visible = false;
            cboFechaFin.Visible = false;

            lblMes.Visible = false;
            cboMes.Visible = false;
            dgvSocios.Columns.Clear();
        }

        private void llenarDGV()
        {           
            lblReg.Text = "No. Registoros:";

            if (rdioFechas.Checked == true)
            {
                sql = "select Day(p.FechaNac1)dia, month(p.FechaNac1) mes,tc.Iniciales + '-' + Convert(varchar(50), c.NumCto) NoContrato,c.Nombre1 'Titular', " +
                      "CONVERT(VARCHAR(15),p.FechaNac1, 106) Fecha,'Titular' Socio,s1.Nombre Status1, s2.Nombre Status2, idioma.Nombre Idioma " +
                      "from Contratos c left join TiposContrato tc on c.idTipcon = tc.idtipcon left " +
                      "join StatusContratos1 s1 on c.idStatusCon1 = s1.idStatusCon1 "+
                      "left join StatusContratos2 s2 on c.idStatusCon2 = s2.idStatusCon2 "+
                      "left join Idiomas idioma on c.IdIdioma=idioma.IdIdioma " +
                      "left join Premanifiesto p on c.FolioPrema = p.Folio where c.idStatusCon1 not in (4,100) and " +
                      "Day(p.FechaNac1) between @DiaIni and @DiaFin and month(p.FechaNac1) between @MesIni and @MesFin  union " +
                      "selecT Day(p.FechaNac2) dia, month(p.FechaNac2) mes,tc.Iniciales + '-' + Convert(varchar(50), c.NumCto) NoContrato, c.Nombre2 'Titular', " +
                      "CONVERT(VARCHAR(15),p.FechaNac2, 106) Fecha,'Cotitular' Socio,s1.Nombre Status1, s2.Nombre Status2, idioma.Nombre Idioma " +
                      "from Contratos c left join TiposContrato tc on c.idTipcon = tc.idtipcon left " +
                      "join StatusContratos1 s1 on c.idStatusCon1 = s1.idStatusCon1 "+
                      "left join StatusContratos2 s2 on c.idStatusCon2 = s2.idStatusCon2 "+
                      "left join Idiomas idioma on c.IdIdioma=idioma.IdIdioma " +
                      "left join Premanifiesto p on c.FolioPrema = p.Folio " +
                      "where c.idStatusCon1 not in (4,100) and c.Nombre2 is not null and "+
                      "Day(p.FechaNac2) between @DiaIni and @DiaFin and month(p.FechaNac2) between @MesIni and @MesFin  " +
                      "order by mes, dia";
            }

            else if (rdioMes.Checked == true)
            {
                if (cboMes.SelectedIndex > 0)
                {
                    sql = "selecT Day(p.FechaNac1)dia, month(p.FechaNac1) mes,tc.Iniciales + '-' + Convert(varchar(50), c.NumCto) NoContrato,c.Nombre1 'Titular', " +
                          "CONVERT(VARCHAR(15),p.FechaNac1, 106) Fecha,'Titular' Socio,s1.Nombre Status1,s2.Nombre Status2, idioma.Nombre Idioma " +
                          "from Contratos c left join TiposContrato tc on c.idTipcon=tc.idtipcon "+
                          "left join StatusContratos1 s1 on c.idStatusCon1=s1.idStatusCon1 " +
                          "left join StatusContratos2 s2 on c.idStatusCon2=s2.idStatusCon2 "+
                          "left join Idiomas idioma on c.IdIdioma=idioma.IdIdioma " +
                          "left join Premanifiesto p on c.FolioPrema=p.Folio " +
                          "where c.idStatusCon1 not in (4,100) and month(p.FechaNac1)=@Mes union " +
                          "selecT Day(p.FechaNac2) dia, month(p.FechaNac2) mes,tc.Iniciales + '-' + Convert(varchar(50), c.NumCto) NoContrato, c.Nombre2 'Titular', " +
                          "CONVERT(VARCHAR(15),p.FechaNac2, 106) Fecha,'Cotitular' Socio,s1.Nombre Status1,s2.Nombre Status2, idioma.Nombre Idioma " +
                          "from Contratos c left join TiposContrato tc on c.idTipcon=tc.idtipcon "+
                          "left join StatusContratos1 s1 on c.idStatusCon1=s1.idStatusCon1 " +
                          "left join StatusContratos2 s2 on c.idStatusCon2=s2.idStatusCon2 "+
                          "left join Idiomas idioma on c.IdIdioma=idioma.IdIdioma " +
                          "left join Premanifiesto p on c.FolioPrema=p.Folio where c.idStatusCon1 not in (4,100) " +
                          "and c.Nombre2 is not null and month(p.FechaNac2)=@Mes order by mes, dia";
                }
                else
                {
                    dgvSocios.Columns.Clear();
                }
            }

            else if (rdioSinFecha.Checked == true)
            {
                sql = "selecT tc.Iniciales + '-' + Convert(varchar(50), c.NumCto) NoContrato, c.Nombre1 'Titular', "+
                      "p.FechaNac1 Fecha,'Titular' Socio,s1.Nombre Status1, s2.Nombre Status2 , idioma.Nombre Idioma " +
                      "from Contratos c left join TiposContrato tc on c.idTipcon = tc.idtipcon "+
                      "left join StatusContratos1 s1 on c.idStatusCon1 = s1.idStatusCon1 "+ 
                      "left join StatusContratos2 s2 on c.idStatusCon2 = s2.idStatusCon2 "+
                      "left join Idiomas idioma on c.IdIdioma=idioma.IdIdioma "+
                      "left join Premanifiesto p on c.FolioPrema = p.Folio "+
                      "where c.idStatusCon1 not in (4,100) and p.FechaNac1 is null union " +
                      "selecT tc.Iniciales + '-' + Convert(varchar(50), c.NumCto) NoContrato, c.Nombre2 'Titular', "+
                      "p.FechaNac2 Fecha,'Cotitular' Socio,s1.Nombre Status1, s2.Nombre Status2 , idioma.Nombre Idioma " +
                      "from Contratos c left join TiposContrato tc on c.idTipcon = tc.idtipcon "+
                      "left join StatusContratos1 s1 on c.idStatusCon1 = s1.idStatusCon1 " +
                      "left join StatusContratos2 s2 on c.idStatusCon2 = s2.idStatusCon2 "+
                      "left join Idiomas idioma on c.IdIdioma=idioma.IdIdioma " +
                      "left join Premanifiesto p on c.FolioPrema = p.Folio " +
                      "where c.idStatusCon1 not in (4,100) " +
                      "and c.Nombre2 is not null and p.FechaNac2 is null order by NoContrato";
            }

            else
            {
                MessageBox.Show("Debe seleccionar una opcion de busqueda");
                sql = "";
            }


            if (sql != "")
            {
                using (SqlConnection con = new SqlConnection(c.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        if (rdioMes.Checked == true)
                        {
                            comando.Parameters.Add("@Mes", SqlDbType.Int).Value = cboMes.SelectedIndex;
                        }

                        if (rdioFechas.Checked == true)
                        {
                            fec.GeneraFecha(Convert.ToDateTime(cboFechaIni.Value),1);
                            comando.Parameters.Add("@DiaIni", SqlDbType.Int).Value = fec.NumDia;
                            comando.Parameters.Add("@MesIni", SqlDbType.Int).Value = fec.NumMes;

                            fec.GeneraFecha(Convert.ToDateTime(cboFechaFin.Value), 1);
                            comando.Parameters.Add("@DiaFin", SqlDbType.Int).Value = fec.NumDia;
                            comando.Parameters.Add("@MesFin", SqlDbType.Int).Value = fec.NumMes;
                        }

                        SqlDataAdapter da = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvSocios.Columns.Clear();
                        dgvSocios.DataSource = dt;                       

                        con.Close();
                    }
                }

                lblReg.Text = "No. Registros:"+(dgvSocios.RowCount);

                if (rdioMes.Checked == true || rdioFechas.Checked==true)
                {
                    this.dgvSocios.Columns["mes"].Visible = false;
                    this.dgvSocios.Columns["dia"].Visible = false;
                }

                this.dgvSocios.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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

                if (rdioSinFecha.Checked == true)
                {
                    hoja_trabajo.Cells[1, 1] = "CONTRATO";
                    hoja_trabajo.Cells[1, 2] = "TITULAR";
                    hoja_trabajo.Cells[1, 3] = "CUMPLEAÑOS";
                    hoja_trabajo.Cells[1, 4] = "SOCIO";
                    hoja_trabajo.Cells[1, 5] = "STATUS1";
                    hoja_trabajo.Cells[1, 6] = "STATUS2";
                    hoja_trabajo.Cells[1, 7] = "IDIOMA";

                    hoja_trabajo.Cells[1, 1].Font.Bold = true;
                    hoja_trabajo.Cells[1, 2].Font.Bold = true;
                    hoja_trabajo.Cells[1, 3].Font.Bold = true;
                    hoja_trabajo.Cells[1, 4].Font.Bold = true;
                    hoja_trabajo.Cells[1, 5].Font.Bold = true;
                    hoja_trabajo.Cells[1, 6].Font.Bold = true;
                    hoja_trabajo.Cells[1, 7].Font.Bold = true;

                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    for (int i = 0; i < dgvSocios.Rows.Count; i++) //renglones
                    {
                        for (int j = 0; j < dgvSocios.Columns.Count; j++)//columnas
                        {
                            hoja_trabajo.Cells[i + 2, j + 1] = dgvSocios.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                else
                {
                    hoja_trabajo.Cells[1, 1] = "#MES";
                    hoja_trabajo.Cells[1, 2] = "CONTRATO";
                    hoja_trabajo.Cells[1, 3] = "TITULAR";
                    hoja_trabajo.Cells[1, 4] = "CUMPLEAÑOS";
                    hoja_trabajo.Cells[1, 5] = "SOCIO";
                    hoja_trabajo.Cells[1, 6] = "STATUS1";
                    hoja_trabajo.Cells[1, 7] = "STATUS2";
                    hoja_trabajo.Cells[1, 8] = "IDIOMA";

                    hoja_trabajo.Cells[1, 1].Font.Bold = true;
                    hoja_trabajo.Cells[1, 2].Font.Bold = true;
                    hoja_trabajo.Cells[1, 3].Font.Bold = true;
                    hoja_trabajo.Cells[1, 4].Font.Bold = true;
                    hoja_trabajo.Cells[1, 5].Font.Bold = true;
                    hoja_trabajo.Cells[1, 6].Font.Bold = true;
                    hoja_trabajo.Cells[1, 7].Font.Bold = true;
                    hoja_trabajo.Cells[1, 8].Font.Bold = true;

                    //Recorremos el DataGridView rellenando la hoja de trabajo
                    int x = 1;
                    for (int i = 0; i < dgvSocios.Rows.Count; i++) //renglones
                    {
                        for (int j = 1; j < dgvSocios.Columns.Count; j++)//columnas
                        {
                            hoja_trabajo.Cells[x + 1, j] = dgvSocios.Rows[i].Cells[j].Value.ToString();
                        }
                        x++;
                    }
                }


                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                libros_trabajo.Close(true);
                aplicacion.Quit();

                Cursor.Current = Cursors.Default;

                Process.Start(fichero.FileName);
            }
        }

        private void bttnCerrar2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cboFechaFin_ValueChanged(object sender, EventArgs e)
        {
            llenarDGV();
        }
    }
}
