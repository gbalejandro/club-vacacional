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

namespace OTLC
{
    public partial class RegalosVenta : Form
    {
        Conexion c = new Conexion();
        llenarComboBox llenar = new llenarComboBox();
        Bitacora bi = new Bitacora();
        Regalos reg = new Regalos();

        string accion;

        public RegalosVenta()
        {
            InitializeComponent();
            permiso();
            llenarCombos();
            Deshabilitar();

            cbotipo.Text = "Todos";
            cboOrderBy.Text = "Folio";
            llenarDGV();

            Nuevo();
            accion = "N";
        }

        //REPORTE DE REGALOS DE VENTA
        private void permiso()
        {
            if (Sesion.ContratosRegalosRep == false)
            {
                inhabilitarReporteVta();
            }

            if (Sesion.ContratosRegalosCat == false)
            {
                inhabilitarCatRegalos();
            }
        }

        private void inhabilitarReporteVta()
        {
            groupBox1.Enabled = false;
            tabControl1.Enabled = false;
            bttnGenerar.Enabled = false;
            dgvRegalos.Enabled = false;
            cboGruposRegalos.Enabled = false;
            checkLimpiar.Enabled = false;
        }

        private void inhabilitarCatRegalos()
        {
            tabCatalogo.Enabled = false;
            panelRegPaq.Enabled = false;
            bttnGrabar.Enabled = false;
            bttnNuevo.Enabled = false;
        }

        private void llenarCombos()
        {
            //Reporte Regalos Venta
            llenar.SalasVta(comboSalaVta);
            llenar.RegalosGrupos(cboGruposRegalos);
            //Regalos catalogo
            llenar.Moneda(cboMoneda);
            llenar.RegalosGrupos(cboGrupo);
            llenar.Status(cboStatus);
            llenar.Division(cboDivision);
            llenar.RegalosDoctos(cboDocto1);
            llenar.RegalosDoctos(cboDocto2);


            cboMoneda.SelectedValue = 0;
            cboGrupo.SelectedValue = 0;
            cboStatus.SelectedValue = 0;
            cboDivision.SelectedValue = 0;
            cboDocto1.SelectedValue = 0;
            cboDocto2.SelectedValue = 0;
        }

        private void AsigValores()
        {

            reg.Limpiar();
            reg.Consec = radioConcec.Checked;
            reg.FVenta = radioFechaVta.Checked;
            reg.FFolio = radioFechaFolio.Checked;

            //filtro regalos
            Nums();

            //consecutivo
           
            reg.ultprim = Convert.ToString(cboOrden.SelectedItem);// Ultimos Primeros


            if (txtNumero.Text == "")
            { reg.topFolio = 0; }
            else { reg.topFolio = Convert.ToInt32(txtNumero.Text); }

            if (txtFolioempieza.Text == "")
            { reg.empieza = 0; }
            else { reg.empieza = Convert.ToInt32(txtFolioempieza.Text); }

            if (txtFolioInicio.Text == "")
            { reg.FolIni = 0; }
            else { reg.FolIni = Convert.ToInt32(txtFolioInicio.Text); }

            if (txtFolioFin.Text == "")
            { reg.FolFin = 0; }
            else { reg.FolFin = Convert.ToInt32(txtFolioFin.Text); }

            //fechas
            reg.FecIni = Convert.ToDateTime(cboFIni.Value);
            reg.FecFin = Convert.ToDateTime(cboFFin.Value);

            //General
            reg.Sala =Convert.ToInt32(comboSalaVta.SelectedValue);
            reg.Tipo= cbotipo.SelectedIndex;
            reg.OrderBy = cboOrderBy.SelectedIndex;
            reg.sinFolio = checkSinFolio.Checked;
        }

        private void Nums()
        {
            reg.NumsRegalos = "";

            for (int count = 0; count < dgvRegalos.Rows.Count; count++)
            {
                if (dgvRegalos.Rows[count].Cells[2].Value is DBNull)
                {
                    dgvRegalos.Rows[count].Cells[2].Value = false;
                }

                if (Convert.ToBoolean(dgvRegalos.Rows[count].Cells[2].Value) == true)
                {
                    reg.NumsRegalos = reg.NumsRegalos + Convert.ToString(dgvRegalos.Rows[count].Cells[0].Value)+"," ;                   
                }
            }

            if (reg.NumsRegalos != "")
            {
                reg.NumsRegalos = reg.NumsRegalos + "0";
            }
            
            //MessageBox.Show(reg.NumsRegalos);

        }

        private void llenarDGV()
        {
            string sql = "select idRegalo,Nombre,'False' as Seleccionar from Regalos where IdStatus='A' order by Nombre";


            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvRegalos.Columns.Clear();

                    dgvRegalos.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Seleccionar" , DataPropertyName = "Seleccionar" });
                    dgvRegalos.DataSource = dt;


                    dgvRegalos.Columns[0].Visible = false;

                    dgvRegalos.Columns["Seleccionar"].DisplayIndex = 2; //0
                    dgvRegalos.Columns["Seleccionar"].HeaderText = "Seleccionar";

                    dgvRegalos.Columns[1].ReadOnly = true;

                    dgvRegalos.Columns[1].Width = 300;
                    dgvRegalos.Columns[2].Width = 70;
                    

                    con.Close();
                }

            }


        }

        private void Deshabilitar()
        {
            cboOrden.Visible = false;
            txtNumero.Visible = false;
            lblfolios.Visible = false;
            txtFolioempieza.Visible = false;
            lblFolioEmpieza.Visible = false;
            lblFolioIni.Visible = false;
            txtFolioInicio.Visible = false;
            lblFolioFin.Visible = false;
            txtFolioFin.Visible = false;
            lblFIni.Visible = false;
            cboFIni.Visible = false;
            lblFFin.Visible = false;
            cboFFin.Visible = false;

            cboOrden.Text = "Ultimos";
            txtNumero.Text = "0";
            txtFolioempieza.Text = "";
            txtFolioInicio.Text = "";
            txtFolioFin.Text = "";

            cboFIni.Value = DateTime.Today;
            cboFFin.Value = DateTime.Today;
        }

        private void GruposRegalos(int grupo)
        {
            if (grupo > 0)
            {
                string sql = "select idRegalo,Nombre,'False' as Seleccionar from Regalos where IdStatus='A' and idGrupo=@Grupo order by Nombre";

                using (SqlConnection con = new SqlConnection(c.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@Grupo", SqlDbType.Int).Value = grupo;


                        SqlDataAdapter da = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        dgvRegalos.Columns.Clear();
                        dgvRegalos.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Seleccionar", DataPropertyName = "Seleccionar" });
                        dgvRegalos.DataSource = dt;

                        dgvRegalos.Columns[0].Visible = false;

                        dgvRegalos.Columns["Seleccionar"].DisplayIndex = 2; //0
                        dgvRegalos.Columns["Seleccionar"].HeaderText = "Seleccionar";

                        dgvRegalos.Columns[1].ReadOnly = true;

                        dgvRegalos.Columns[1].Width = 300;
                        dgvRegalos.Columns[2].Width = 70;

                        con.Close();
                    }

                }
            }
            else
            {
                llenarDGV();
            }


        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtFolioInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtFolioempieza_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtFolioFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void radioConcec_CheckedChanged(object sender, EventArgs e)
        {
            Deshabilitar();

            cboOrden.Visible = true;
            txtNumero.Visible = true;
            lblfolios.Visible = true;
            txtFolioempieza.Visible = true;
            lblFolioEmpieza.Visible = true;
            lblFolioIni.Visible = true;
            txtFolioInicio.Visible = true;
            lblFolioFin.Visible = true;
            txtFolioFin.Visible = true;
        }

        private void radioFechaVta_CheckedChanged(object sender, EventArgs e)
        {
            Deshabilitar();

            lblFIni.Visible = true;
            cboFIni.Visible = true;
            lblFFin.Visible = true;
            cboFFin.Visible = true;

            
        }

        private void radioFechaFolio_CheckedChanged(object sender, EventArgs e)
        {
            Deshabilitar();

            lblFIni.Visible = true;
            cboFIni.Visible = true;
            lblFFin.Visible = true;
            cboFFin.Visible = true;
        }
     
        private void cboGruposRegalos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            checkLimpiar.Checked = false;
            GruposRegalos(Convert.ToInt32(cboGruposRegalos.SelectedValue));
        }

        private void chLimpiar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLimpiar.Checked == true)
            {
                for (int count = 0; count < dgvRegalos.Rows.Count; count++)
                {
                    dgvRegalos.Rows[count].Cells[2].Value = true;
                }
            }
            else
            {
                for (int count = 0; count < dgvRegalos.Rows.Count; count++)
                {
                    dgvRegalos.Rows[count].Cells[2].Value = false;
                }
            }
        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bttnGenerar_Click(object sender, EventArgs e)
        {

            if (comboSalaVta.Text == "")
            {
                MessageBox.Show("Debe seleccionar una sala de Venta");
            }
            else
            {
                AsigValores();
                reg.RegalosVenta();              
            }

        }

        //AGREGAR REGALOS
        private void llenarDGVRegPaq()
        {
            string sql = "select p.IdRegalo,r.Nombre,p.Cantidad from RegalosPaquetes p inner join Regalos r on p.IdRegalo=r.idRegalo where p.IdRegaloPaq=@idRegalo";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idRegalo", SqlDbType.Int).Value = reg.idRegalo;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvRegPaq.Columns.Clear();

                    dgvRegPaq.DataSource = dt;

                    con.Close();
                }

            }


        }

        private void AsigValoresRegalos()
        {
            accion = "M";
            txtClave.Text = reg.idRegalo.ToString();
            txtNombre.Text = reg.Nombre;
            txtNombreCorto.Text = reg.NombreCorto;
            txtIdioma2.Text = reg.Idioma2;
            cboGrupo.SelectedValue = reg.idGrupo;
            cboMoneda.SelectedValue = reg.idMoneda;
            txtCosto.Text = reg.CostoA.ToString();
            chCapturaSeries.Checked = Convert.ToBoolean(reg.CapturaSeries);
            chCapturaRangoFechas.Checked = Convert.ToBoolean(reg.CapturaRangoFechas);
            chCapturaFecexp.Checked = Convert.ToBoolean(reg.CapturaFecexp);
            chPaquete.Checked = Convert.ToBoolean(reg.Paquete);
            chModPrecioVta.Checked = Convert.ToBoolean(reg.ModPrecioVta);
            cboStatus.SelectedValue = reg.IdStatus;
            cboDivision.SelectedValue = reg.idDivision;
            chShowRegInc.Checked = Convert.ToBoolean(reg.ShowRegInc);
            chShowRegNoInc.Checked = Convert.ToBoolean(reg.ShowRegNoInc);
            chModPrecioVta.Checked = Convert.ToBoolean(reg.ModPrecioVta);
            cboDocto1.SelectedValue = reg.idDocto1;
            cboDocto2.SelectedValue = reg.idDocto2;

            if (chPaquete.Checked == true)
            {
                llenar.RegalosCatalogo(cboRegalo);
                txtCantidad.Text = "0";
                llenarDGVRegPaq();
                panelRegPaq.Visible = true;
            }
            else
            {
                panelRegPaq.Visible = false;
            }

        }

        private void NuevosValores()
        {
            reg.idRegalo = 0;
            reg.Nombre = txtNombre.Text;
            reg.NombreCorto = txtNombreCorto.Text;
            reg.Idioma2 = txtIdioma2.Text;
            reg.idGrupo = Convert.ToInt32(cboGrupo.SelectedValue);
            reg.idMoneda= Convert.ToInt32(cboMoneda.SelectedValue);
            reg.CostoA = Convert.ToDouble(txtCosto.Text);         
            reg.CapturaSeries = chCapturaSeries.Checked.ToString();
            reg.CapturaRangoFechas = chCapturaRangoFechas.Checked.ToString();
            reg.CapturaFecexp = chCapturaFecexp.Checked.ToString();
            reg.Paquete = chPaquete.Checked.ToString();
            reg.IdStatus =Convert.ToString(cboStatus.SelectedValue);
            reg.idDivision = Convert.ToInt16(cboDivision.SelectedValue);
            reg.ShowRegInc = chShowRegInc.Checked.ToString();
            reg.ShowRegNoInc = chShowRegNoInc.Checked.ToString();
            reg.ModPrecioVta = chModPrecioVta.Checked.ToString();
            reg.idDocto1 = Convert.ToInt32(cboDocto1.SelectedValue);
            reg.idDocto2 = Convert.ToInt32(cboDocto2.SelectedValue);
        }

        private void Nuevo()
        {
            accion = "N";

            reg.idRegalo = 0;
            txtClave.Text = "";            
            txtNombre.Text = "";
            txtNombreCorto.Text = "";
            txtIdioma2.Text = "";
            cboGrupo.SelectedValue = 0;
            cboMoneda.SelectedValue = 0;
            txtCosto.Text = "";
            chCapturaSeries.Checked = false;
            chCapturaRangoFechas.Checked = false;
            chCapturaFecexp.Checked = false;
            chPaquete.Checked = false;
            chModPrecioVta.Checked = false;
            cboStatus.SelectedValue = "A";
            cboDivision.SelectedValue = 0;
            chShowRegInc.Checked = false;
            chShowRegNoInc.Checked = false;
            chModPrecioVta.Checked = false;
            cboDocto1.SelectedValue = 0;
            cboDocto2.SelectedValue = 0;

            panelRegPaq.Visible = false;
        }

        private void ComparaValores()
        {
            if (reg.Nombre != txtNombre.Text)
            {
                bi.RegistrarBitacora(200004, "Regalos", "Nombre", "U", reg.Nombre, txtNombre.Text);
                reg.Nombre = txtNombre.Text;
            }
            if (reg.NombreCorto != txtNombreCorto.Text)
            {
                bi.RegistrarBitacora(200004, "Regalos", "NombreCorto", "U", reg.NombreCorto, txtNombreCorto.Text);
                reg.NombreCorto = txtNombreCorto.Text;
            }
            if (reg.Idioma2 != txtIdioma2.Text)
            {
                bi.RegistrarBitacora(200004, "Regalos", "Idioma2", "U", reg.Idioma2,txtIdioma2.Text);
                reg.Idioma2 = txtIdioma2.Text;
            }
            if (reg.idGrupo != Convert.ToInt32(cboGrupo.SelectedValue))
            {
                bi.RegistrarBitacora(200004, "Regalos", "idGrupo", "U", reg.idGrupo.ToString(), cboGrupo.SelectedValue.ToString());
                reg.idGrupo = Convert.ToInt32(cboGrupo.SelectedValue);
            }
            if (reg.idMoneda != Convert.ToInt32(cboMoneda.SelectedValue))
            {
                bi.RegistrarBitacora(200004, "Regalos", "idMoneda", "U", reg.idMoneda.ToString(), cboMoneda.SelectedValue.ToString());
                reg.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            }

            if (reg.CostoA != Convert.ToDouble(txtCosto.Text))
            {
                bi.RegistrarBitacora(200004, "Regalos", "CostoA", "U", reg.CostoA.ToString(),txtCosto.Text);
                reg.CostoA = Convert.ToDouble(txtCosto.Text);
            }
            if (reg.CapturaSeries != chCapturaSeries.Checked.ToString())
            {
                bi.RegistrarBitacora(200004, "Regalos", "CapturaSeries", "U", reg.CapturaSeries, chCapturaSeries.Checked.ToString());
                reg.CapturaSeries = chCapturaSeries.Checked.ToString();
            }

            if (reg.CapturaRangoFechas != chCapturaRangoFechas.Checked.ToString())
            {
                bi.RegistrarBitacora(200004, "Regalos", "CapturaRangoFechas", "U", reg.CapturaRangoFechas, chCapturaRangoFechas.Checked.ToString());
                reg.CapturaRangoFechas = chCapturaRangoFechas.Checked.ToString();
            }
            if (reg.CapturaFecexp != chCapturaFecexp.Checked.ToString())
            {
                bi.RegistrarBitacora(200004, "Regalos", "CapturaFecexp", "U", reg.CapturaFecexp, chCapturaFecexp.Checked.ToString());
                reg.CapturaFecexp = chCapturaFecexp.Checked.ToString();
            }
            if (reg.Paquete != chPaquete.Checked.ToString())
            {
                bi.RegistrarBitacora(200004, "Regalos", "Paquete", "U", reg.Paquete, chPaquete.Checked.ToString());
                reg.Paquete = chPaquete.Checked.ToString();
            }
            if (reg.IdStatus != Convert.ToString(cboStatus.SelectedValue))
            {
                bi.RegistrarBitacora(200004, "Regalos", "IdStatus", "U", reg.IdStatus, Convert.ToString(cboStatus.SelectedValue));
                reg.IdStatus = Convert.ToString(cboStatus.SelectedValue);
            }
            if (reg.idDivision != Convert.ToInt16(cboDivision.SelectedValue))
            {
                bi.RegistrarBitacora(200004, "Regalos", "idDivision", "U", reg.idDivision.ToString(), cboDivision.SelectedValue.ToString());
                reg.idDivision = Convert.ToInt16(cboDivision.SelectedValue);
            }
            if (reg.ShowRegInc != chShowRegInc.Checked.ToString())
            {
                bi.RegistrarBitacora(200004, "Regalos", "ShowRegInc", "U", reg.ShowRegInc.ToString(), chShowRegInc.Checked.ToString());
                reg.ShowRegInc = chShowRegInc.Checked.ToString();
            }
            if (reg.ShowRegNoInc != chShowRegNoInc.Checked.ToString())
            {
                bi.RegistrarBitacora(200004, "Regalos", "ShowRegNoInc", "U", reg.ShowRegNoInc.ToString(), chShowRegNoInc.Checked.ToString());
                reg.ShowRegNoInc = chShowRegNoInc.Checked.ToString();
            }
            if (reg.ModPrecioVta != chModPrecioVta.Checked.ToString())
            {
                bi.RegistrarBitacora(200004, "Regalos", "idDivision", "U", reg.ModPrecioVta.ToString(), chModPrecioVta.Checked.ToString());
                reg.ModPrecioVta = chModPrecioVta.Checked.ToString();
            }
            if (reg.idDocto1 != Convert.ToInt32(cboDocto1.SelectedValue))
            {
                bi.RegistrarBitacora(200004, "Regalos", "idDivision", "U", reg.idDocto1.ToString(), cboDocto1.SelectedValue.ToString());
                reg.idDocto1 = Convert.ToInt32(cboDocto1.SelectedValue);
            }
            if (reg.idDocto2 != Convert.ToInt32(cboDocto2.SelectedValue))
            {
                bi.RegistrarBitacora(200004, "Regalos", "idDivision", "U", reg.idDocto2.ToString(), cboDocto2.SelectedValue.ToString());
                reg.idDocto2 = Convert.ToInt32(cboDocto2.SelectedValue);
            }

        }

        private void chPaquete_CheckedChanged(object sender, EventArgs e)
        {
            if (chPaquete.Checked == true)
            {
                llenar.RegalosCatalogo(cboRegalo);
                txtCantidad.Text = "1";
                llenarDGVRegPaq();
                panelRegPaq.Visible = true;
            }
            else
            {
                panelRegPaq.Visible = false;
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtClave.Text == "" || Convert.ToInt32(txtClave.Text) < 1)
                { MessageBox.Show("Debe proporcionar una clave valida para la busqueda"); }

                else
                {                  
                    reg.idRegalo = Convert.ToInt32(txtClave.Text);
                    reg.LeerRegalo();
                    AsigValoresRegalos();
                }
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.NumerosConPunto(sender, e, txtCosto);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtClave_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            RegalosCatalogo rc = new RegalosCatalogo();
            rc.ShowDialog();

            if (Convert.ToInt32(rc.regalo) > 0)
            {
                reg.idRegalo = Convert.ToInt32(rc.regalo);
                reg.LeerRegalo();
                AsigValoresRegalos();
            }

        }

        private void bttnCerrar2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bttnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void bttnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCosto.Text == "")
                    { txtCosto.Text = "0"; }


            if (txtNombre.Text == ""|| txtNombreCorto.Text=="")
            {
                MessageBox.Show("Los campos: Nombre y Nombre Corto no deben ser nulos, favor de llenar toda la información");

            }
            else
            {
                if (accion == "N")
                {

                    if (MessageBox.Show("Agregar regalo: " + txtNombre.Text, "Agregar regalo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        NuevosValores();
                        reg.AgregarRegalos("N");
                        bi.RegistrarBitacora(200003, "Regalos", "Registro Nuevo", "I", "", "idRegalo: " + reg.idRegalo + ", Regalo: " + reg.Nombre + ", CostoA: " + reg.CostoA);
                        Nuevo();
                    }

                }

                if (accion == "M")
                {
                    if (MessageBox.Show("Modificar regalo: " + reg.Nombre, "Agregar regalo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ComparaValores();
                        reg.AgregarRegalos("M");
                        Nuevo();
                    }
                }
            }




        }

        private void bttnAgrega_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32(txtCantidad.Text) > 0)
            {
                if (reg.idRegalo > 0)
                {
                    reg.RegPaq = "A";
                    reg.RegPaquete(Convert.ToInt32(cboRegalo.SelectedValue), Convert.ToInt32(txtCantidad.Text));                   
                    llenarDGVRegPaq();

                    cboRegalo.SelectedValue = 0;
                    txtCantidad.Text = "1";
                }
            }
            else
            {
                MessageBox.Show("La cantidad debe ser mayor a CERO");
            }
            
        }

        private void bttnBorrar_Click(object sender, EventArgs e)
        {
            if (reg.idRegalo > 0)
            {
                string regalo = dgvRegPaq.CurrentRow.Cells[0].Value.ToString();

                reg.RegPaq = "D";
                reg.RegPaquete(Convert.ToInt32(regalo), 0);

                llenarDGVRegPaq();
            }
        }

        private void bttnLimpiar1_Click(object sender, EventArgs e)
        {
            cboDocto1.SelectedValue = 0;
        }

        private void bttnLimpiar2_Click(object sender, EventArgs e)
        {
            cboDocto2.SelectedValue = 0;
        }
    }
}
