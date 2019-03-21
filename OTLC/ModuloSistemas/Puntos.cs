using OTLC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTLC
{
    public partial class Puntos : Form
    {
        Conexion c = new Conexion();
        llenarComboBox llenar = new llenarComboBox();
        Hoteles h = new Hoteles();
        ReservacionesHabitaciones hab = new ReservacionesHabitaciones();
        ReservacionesSemanas pts = new ReservacionesSemanas();

        //int v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12 = 0;

        public Puntos()
        {
            InitializeComponent();
            llenaCb();
            Permisos();
        }

        private void Permisos()
        {
            if (Sesion.ReservacionesPtosNuevoAño == false)
            {
                tabControl1.Enabled = false;
            }

        }

        private void llenaCb()
        {        
            llenar.Hoteles(cboSelecHot);
            llenar.SalasVta(cboHotSalaVta);
            llenar.Hoteles(cboHabHotel);
            llenar.Hoteles(cboPtsHotel);
            llenar.Hoteles(cboHotelHab);
        }

        //HOTEL

        private void LimpiarHotel()
        {
            gpoHoteles.Visible = false;
            txtHotCodigo.Text = "";
            txtHotNombre.Text = "";
            cboHotSalaVta.SelectedValue = 1;
        }

        private void InhabiltaHotel()
        {
            groupHotel.Visible = true;

            bttnGrabarHotel.Visible = false;
            bttnDesactivaHotel.Visible = true;

            lblSelecHot.Visible = true;
            cboSelecHot.Visible = true;

            txtHotCodigo.ReadOnly = true;
            txtHotNombre.ReadOnly = true;
            cboHotSalaVta.Enabled = false;

            txtHotCodigo.BackColor = Color.LightGray;
            txtHotNombre.BackColor = Color.LightGray;
        }

        private void HabiltaHotel()
        {
            groupHotel.Visible = true;

            txtHotCodigo.ReadOnly = false;
            txtHotNombre.ReadOnly = false;
            cboHotSalaVta.Enabled = true;

            bttnGrabarHotel.Visible = true;
            bttnDesactivaHotel.Visible = false;

            lblSelecHot.Visible = false;
            cboSelecHot.Visible = false;

            txtHotCodigo.BackColor = Color.White;
            txtHotNombre.BackColor = Color.White;
        }

        private void radioInsert_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarHotel();
            groupHotel.Text = "Dar de Alta Hotel";
            HabiltaHotel();
            cboHotSalaVta.SelectedValue = h.idSalaVta;
        }

        private void radioUpdate_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarHotel();
            groupHotel.Text = "Dar de Baja Hotel";
            InhabiltaHotel();
            cboHotSalaVta.SelectedValue = h.idSalaVta;
        }

        private void radioConsulta_CheckedChanged(object sender, EventArgs e)
        {          
            groupHotel.Visible = false;
            gpoHoteles.Visible = true;
            gpoHoteles.Text = "Hoteles Activos";

            llenarDGVHoteles();
        }

        private void llenarDGVHoteles()
        {
            string sql = "SELECT h.Codigo,h.Nombre,s.Nombre SalaVta FROM Hoteles h left join SalasVta s on h.idSalaVta=s.idSalaVta where h.idSalaVta>0 order by SalaVta";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgvHoteles.Columns.Clear();
                dgvHoteles.DataSource = dt;
        
                con.Close();
            }

            //tamaño de las columnas 
            this.dgvHoteles.Columns["Codigo"].Width = 100;
            this.dgvHoteles.Columns["Nombre"].Width = 250;
            this.dgvHoteles.Columns["SalaVta"].Width = 130;
        }

        private void cboSelecHot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LimpiarHotel();
            h.LeerHotel(Convert.ToInt32(cboSelecHot.SelectedValue));

            txtHotCodigo.Text = h.Codigo;
            txtHotNombre.Text = h.Nombre;
            cboHotSalaVta.SelectedValue = h.idSalaVta;
        }

        private void bttnDesactivaHotel_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboSelecHot.SelectedValue) > 0)
            {
                if (MessageBox.Show("Se desactivara el Hotel: " + cboSelecHot.Text, "Desactivar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    h.ModificaHotel(h, "idSalaVta", cboHotSalaVta.SelectedValue.ToString(), "0");
                    h.ModificaHotel(h, "Codigo", txtHotCodigo.Text, "");
                    MessageBox.Show("Se desactivo el hotel Correctamente");
                    llenaCb();
                    LimpiarHotel();
                }
            }
        }

        private void bttnGrabarHotel_Click(object sender, EventArgs e)
        {
            if (txtHotCodigo.Text != "" && txtHotNombre.Text != "" && Convert.ToInt32(cboHotSalaVta.SelectedValue) > 0)
            {
                if (h.ExisteRegistro("Nombre", txtHotNombre.Text) > 0)
                {
                    if (h.Activo == true)
                    {
                        MessageBox.Show("Ya existe un registro Hotel con el nombre " + txtHotNombre.Text + ", Status: ACTIVO");
                    }
                    else
                    {
                        if (h.ExisteRegistro("Codigo", txtHotCodigo.Text) == 0)
                        {
                            if (MessageBox.Show("Ya existe un registro Hotel con el nombre " + txtHotNombre.Text + ", Status: NO ACTIVO, ¿Reactivar Hotel?", "Modificar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                h.LeerHotel(h.ExisteRegistro("Nombre", txtHotNombre.Text));
                                h.ModificaHotel(h, "idSalaVta", "0", cboHotSalaVta.SelectedValue.ToString());
                                h.ModificaHotel(h, "Codigo", "", txtHotCodigo.Text);
                                MessageBox.Show("Se Reactivo el hotel Correctamente");
                                llenaCb();
                                LimpiarHotel();
                            }
                        }
                    }
                }
                else if (h.ExisteRegistro("Codigo", txtHotCodigo.Text) > 0)
                {
                    MessageBox.Show("Ya existe un registro Hotel con el codigo " + txtHotCodigo.Text);
                }

                else
                {
                    h.Codigo = txtHotCodigo.Text;
                    h.Nombre = txtHotNombre.Text;
                    h.idSalaVta = Convert.ToInt32(cboHotSalaVta.SelectedValue);
                    h.InsertHotel();
                    MessageBox.Show("Se Agrego el hotel Correctamente");
                    llenaCb();
                    LimpiarHotel();
                }

            }
            else
            {
                MessageBox.Show("Debe llenar la información de todos los campos");
            }
        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        //HABITACION
        private void LimpiarHabitacion()
        {
            gpoHotelHab.Visible = false;

            txtHabNombre.Text = "";
            txtHabCodigo.Text = "";
            txtAdultos.Text = "";
            txtNinos.Text = "";
            txtCapacidad.Text = "";
            cboHabSelec.SelectedValue = 0;
        }

        private void InhabilitaHab()
        {
            gpoHabitacion.Visible = true;
            cboHabSelec.Visible = true;
            cboHabHotel.Visible = true;
            lblHabitacion.Visible = true;
            cboHabSelec.Enabled = false;
            txtHabCodigo.ReadOnly = true;
            txtHabNombre.ReadOnly = true;
            txtHabNombre.Visible = false;
            lblHabNombre.Visible = false;
            cboHabHotel.SelectedValue = 0;
            cboHabSelec.SelectedValue = 0;

            txtHabCodigo.BackColor = Color.LightGray;
        }

        private void HabilitaHab()
        {
            gpoHabitacion.Visible = true;
            cboHabSelec.Visible = false;
            lblHabitacion.Visible = false;
            cboHabSelec.Enabled = false;
            cboHabHotel.Visible = true;
            txtHabCodigo.ReadOnly = false;
            txtHabNombre.ReadOnly = false;
            txtHabNombre.Visible = true;
            lblHabNombre.Visible = true;
            cboHabHotel.SelectedValue = 0;
            cboHabSelec.SelectedValue = 0;

            txtHabCodigo.BackColor = Color.White;
        }

        private void rdioHab_CheckedChanged(object sender, EventArgs e)
        {
            gpoHabitacion.Visible = false;
            dgvHabitaciones.Visible = false;
            gpoHotelHab.Visible = true;
            gpoHotelHab.Text = "Habitaciónes por Hotel";

            cboHotelHab.SelectedValue = 0;
            dgvHabitaciones.Columns.Clear();
        }

        private void rdioAlta_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarHabitacion();
            gpoHabitacion.Text = "Dar de Alta Habitación";
            HabilitaHab();
        }

        private void rdioEditar_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarHabitacion();
            gpoHabitacion.Text = "Modificar Habitación";
            InhabilitaHab();
        }

        private void llenarDGVHabitaciones()
        {
            string sql = "select Codigo,Nombre,Adultos,Menores,Capacidad from ReservacionesHabitaciones  where IdHotel=@IdHotel";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdHotel", SqlDbType.Int).Value = Convert.ToInt32(cboHotelHab.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgvHabitaciones.Columns.Clear();
                    dgvHabitaciones.DataSource = dt;

                    con.Close();
                }
            }

            //aliniacion de columnas a la derecha
            this.dgvHabitaciones.Columns["Adultos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvHabitaciones.Columns["Menores"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvHabitaciones.Columns["Capacidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //tamaño de las columnas 
            this.dgvHabitaciones.Columns["Codigo"].Width = 75;
            this.dgvHabitaciones.Columns["Nombre"].Width = 180;
            this.dgvHabitaciones.Columns["Adultos"].Width = 75;
            this.dgvHabitaciones.Columns["Menores"].Width = 75;
            this.dgvHabitaciones.Columns["Capacidad"].Width = 75;
        }

        private void cboHabHotel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            llenar.Habitaciones(cboHabSelec, Convert.ToInt32(cboHabHotel.SelectedValue));
            cboHabSelec.Enabled = true;
            
            LimpiarHabitacion();
        }

        private void cboHabSelec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            hab.LeerHabitacion(Convert.ToInt32(cboHabHotel.SelectedValue), Convert.ToInt32(cboHabSelec.SelectedValue));
            txtHabCodigo.Text = hab.Codigo;
            txtHabNombre.Text = hab.Nombre;
            txtAdultos.Text = hab.Adultos.ToString();
            txtNinos.Text = hab.Menores.ToString();
            txtCapacidad.Text = hab.Capacidad.ToString();
        }

        private void cboHotelHab_SelectionChangeCommitted(object sender, EventArgs e)
        {                                  
            llenarDGVHabitaciones();
            dgvHabitaciones.Visible = true;
        }

        private void bttnHabGrabar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboHabHotel.SelectedValue) <= 0 || txtHabCodigo.Text == "" || txtHabNombre.Text == "" || txtAdultos.Text == "" || txtNinos.Text == "" || txtCapacidad.Text == "")
            {
                MessageBox.Show("Debe llenar la información de todos los campos");
            }
            else
            {
                if (Convert.ToInt32(txtAdultos.Text) > Convert.ToInt32(txtCapacidad.Text))
                {
                    MessageBox.Show("La cantidad de 'ADULTOS' debe ser menor o igual que la Capacidad");
                }
                else if (Convert.ToInt32(txtNinos.Text) >= Convert.ToInt32(txtCapacidad.Text))
                {
                    MessageBox.Show("La cantidad de 'MENORES' debe ser menor que la Capacidad");
                }
                else if (Convert.ToInt32(txtNinos.Text) > Convert.ToInt32(txtAdultos.Text))
                {
                    MessageBox.Show("La cantidad de 'MENORES' debe ser menor o igual que la cantidad de 'ADULTOS'");
                }

                else
                {
                    if (rdioAlta.Checked == true)
                    {
                        hab.IdHotel = Convert.ToInt32(cboHabHotel.SelectedValue);

                        if (hab.ExisteRegistro("Nombre", txtHabNombre.Text) > 0)
                        {
                            MessageBox.Show("Ya existe una habitación con nombre:" + txtHabNombre.Text + " en el hotel " + cboHabHotel.Text);
                            txtHabNombre.Text = "";
                        }
                        else if (hab.ExisteRegistro("Codigo", txtHabCodigo.Text) > 0)
                        {
                            MessageBox.Show("Ya existe una habitación con codigo:" + txtHabCodigo.Text + " en el hotel " + cboHabHotel.Text);
                            txtHabCodigo.Text = "";
                        }
                        else
                        {
                            hab.Nombre = txtHabNombre.Text;
                            hab.Codigo = txtHabCodigo.Text;
                            hab.Adultos = Convert.ToInt32(txtAdultos.Text);
                            hab.Menores = Convert.ToInt32(txtNinos.Text);
                            hab.Capacidad = Convert.ToInt32(txtCapacidad.Text);

                            hab.InsertHabitaciones();
                            MessageBox.Show("Se Agrego la habitación Correctamente");
                            llenaCb();
                            LimpiarHabitacion();
                        }
                    }

                    if (rdioEditar.Checked == true)
                    {
                        bool mod = false;

                        if (Convert.ToInt32(txtAdultos.Text) != hab.Adultos)
                        {
                            mod = true;
                            hab.ModificaHabitacion("Adultos", hab.Adultos.ToString(), txtAdultos.Text);
                        }

                        if (Convert.ToInt32(txtNinos.Text) != hab.Menores)
                        {
                            mod = true;
                            hab.ModificaHabitacion("Menores", hab.Menores.ToString(), txtNinos.Text);
                        }

                        if (Convert.ToInt32(txtCapacidad.Text) != hab.Capacidad)
                        {
                            mod = true;
                            hab.ModificaHabitacion("Capacidad", hab.Capacidad.ToString(), txtCapacidad.Text);
                        }

                        if (mod == true)
                        {
                            MessageBox.Show("Se modifico la información Correctamente");
                            llenaCb();
                            LimpiarHabitacion();
                        }

                    }
                }

            }

        }

        private void bttnCerrarHabit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtAdultos_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtNinos_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }


        //SEMANAS

        private void LimpiaPts()
        {
            gpoSemanas.Visible = false;
            cboPtsHabitacion.SelectedValue = 0;
            cboPtsHotel.SelectedValue = 0;
        }
        private void cboPtsHotel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            dgvSemanas.Visible = false;
            gpoAgregaPts.Visible = false;
            PtsInHabilita();

            llenar.Habitaciones(cboPtsHabitacion, Convert.ToInt32(cboPtsHotel.SelectedValue));
            cboPtsHabitacion.Enabled = true;
            cboPtsHabitacion.SelectedValue = 0;
        }

        private void cboPtsHabitacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rdioSemAgrega.Checked == true)
            {
                dgvSemanas.Visible = false;
                gpoAgregaPts.Visible = true;
                PtsInHabilita();

                hab.LeerHabitacion(Convert.ToInt32(cboPtsHotel.SelectedValue), Convert.ToInt32(cboPtsHabitacion.SelectedValue));

                PtsHAbilitar();
            }
            else if (rdioModPuntos.Checked==true)
            {
                dgvSemanas.Visible = false;
                gpoAgregaPts.Visible = true;

                PtsInHabilita();
                hab.LeerHabitacion(Convert.ToInt32(cboPtsHotel.SelectedValue), Convert.ToInt32(cboPtsHabitacion.SelectedValue));

                PtsModificar();
            }
            else
            {
                dgvSemanas.Visible = true;
                gpoAgregaPts.Visible = false;
                llenarDGVSemanas();
            }
        }

        private void PtsInHabilita ()
        {
            FecIni1.Text = DateTime.Today.ToString();
            FecFin1.Text = DateTime.Today.AddDays(1).ToString();
            lblFecIni.Visible = false;
            lblFecFin.Visible = false;
            lblSemDesc.Visible = false;
            FecIni1.Visible = false;
            FecIni2.Visible = false;
            FecIni3.Visible = false;
            FecIni4.Visible = false;
            FecIni5.Visible = false;
            FecIni6.Visible = false;
            FecIni7.Visible = false;
            FecIni8.Visible = false;
            FecIni9.Visible = false;
            FecIni10.Visible = false;
            FecIni11.Visible = false;
            FecIni12.Visible = false;
            FecFin1.Visible = false;
            FecFin2.Visible = false;
            FecFin3.Visible = false;
            FecFin4.Visible = false;
            FecFin5.Visible = false;
            FecFin6.Visible = false;
            FecFin7.Visible = false;
            FecFin8.Visible = false;
            FecFin9.Visible = false;
            FecFin10.Visible = false;
            FecFin11.Visible = false;
            FecFin12.Visible = false;
            txtSem1.Text = "0";
            txtSem2.Text = "0";
            txtSem3.Text = "0";
            txtSem4.Text = "0";
            txtSem5.Text = "0";
            txtSem6.Text = "0";
            txtSem7.Text = "0";
            txtSem8.Text = "0";
            txtSem9.Text = "0";
            txtSem10.Text = "0";
            txtSem11.Text = "0";
            txtSem12.Text = "0";
            txtSem1.Visible = false;
            txtSem2.Visible = false;
            txtSem3.Visible = false;
            txtSem4.Visible = false;
            txtSem5.Visible = false;
            txtSem6.Visible = false;
            txtSem7.Visible = false;
            txtSem8.Visible = false;
            txtSem9.Visible = false;
            txtSem10.Visible = false;
            txtSem11.Visible = false;
            txtSem12.Visible = false;

        }

        private void PtsHAbilitar()
        {
            FecIni1.Text = DateTime.Today.ToString();
            FecFin1.Text = DateTime.Today.AddDays(1).ToString();
            lblFecIni.Visible = true;
            lblFecFin.Visible = true;
            lblSemDesc.Visible = true;
            FecIni1.Visible = true;
            FecFin1.Visible = true;
            txtSem1.Visible = true;
        }

        private void PtsModificar()
        {
            DateTime fi, ff;
            int id, pts;
            string sql = "select IdTipo,FechaVentaInicio,FechaVentaFinal,SemanasDescontar from ReservacionesSemanas " +
                " where IdHotel=@IdHotel and IdHabitacion=@IdHabitacion and FechaVentaFinal between " +
                " CONVERT(datetime, Convert(varchar, year(getdate()))+'1201') and " +
                " CONVERT(datetime, Convert(varchar, year(getdate()) + 1) + '1231')";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdHotel", SqlDbType.Int).Value = Convert.ToInt32(cboPtsHotel.SelectedValue);
                    comando.Parameters.Add("@IdHabitacion", SqlDbType.Int).Value = Convert.ToInt32(cboPtsHabitacion.SelectedValue);


                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    //for (int i; i< dt.)


                    //dgvSemanas.Columns.Clear();
                    //dgvSemanas.DataSource = dt;


                    /*
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                fi = reader.IsDBNull(1) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(1);
                                ff = reader.IsDBNull(2) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(2);
                                pts = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                                AsignarInfo(i, id, fi, ff, pts);
                            }
                        }
                    }
                    */

                    con.Close();
                }
            }
        }
      
        /*
        private void AsignarInfo(int cont, int id, DateTime f1, DateTime f2, int pts)
        {
            switch (cont)
            {

                case 0:
                    lblFecIni.Visible = true;
                    lblFecFin.Visible = true;
                    lblSemDesc.Visible = true;

                    v1 = id;
                    FecIni1.Text = f1.ToString();
                    FecFin1.Text = f2.ToString();
                    txtSem1.Text = pts.ToString();

                    FecIni1.Visible = true;
                    FecFin1.Visible = true;
                    txtSem1.Visible = true;
                    break;

                case 1:
                    v2 = id;
                    FecIni2.Text = f1.ToString();
                    FecFin2.Text = f2.ToString();
                    txtSem2.Text = pts.ToString();

                    FecIni2.Visible = true;
                    FecFin2.Visible = true;
                    txtSem2.Visible = true;
                    break;

                case 2:
                    v3 = id;
                    FecIni3.Text = f1.ToString();
                    FecFin3.Text = f2.ToString();
                    txtSem3.Text = pts.ToString();

                    FecIni3.Visible = true;
                    FecFin3.Visible = true;
                    txtSem3.Visible = true;
                    break;

                case 3:
                    v4 = id;
                    FecIni4.Text = f1.ToString();
                    FecFin4.Text = f2.ToString();
                    txtSem4.Text = pts.ToString();

                    FecIni4.Visible = true;
                    FecFin4.Visible = true;
                    txtSem4.Visible = true;
                    break;

                case 4:
                    v5 = id;
                    FecIni5.Text = f1.ToString();
                    FecFin5.Text = f2.ToString();
                    txtSem5.Text = pts.ToString();

                    FecIni5.Visible = true;
                    FecFin5.Visible = true;
                    txtSem5.Visible = true;
                    break;

                default:
                    MessageBox.Show("No se pueden modificar registros del Ejercicio en curso");
                    break;
            }
        }
        */

        private void llenarDGVSemanas()
        {
            string sql = "select Codigo,FechaVentaInicio,FechaVentaFinal,SemanasDescontar from ReservacionesSemanas where IdHotel=@IdHotel and IdHabitacion=@IdHabitacion";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdHotel", SqlDbType.Int).Value = Convert.ToInt32(cboPtsHotel.SelectedValue);
                    comando.Parameters.Add("@IdHabitacion", SqlDbType.Int).Value = Convert.ToInt32(cboPtsHabitacion.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgvSemanas.Columns.Clear();
                    dgvSemanas.DataSource = dt;

                    con.Close();
                }
            }

            //aliniacion de columnas a la derecha
            this.dgvSemanas.Columns["FechaVentaInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSemanas.Columns["FechaVentaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSemanas.Columns["SemanasDescontar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //tamaño de las columnas 
            this.dgvSemanas.Columns["Codigo"].Width = 80;
            this.dgvSemanas.Columns["FechaVentaInicio"].Width = 130;
            this.dgvSemanas.Columns["FechaVentaFinal"].Width = 130;
            this.dgvSemanas.Columns["SemanasDescontar"].Width = 130;
        }

        private void config()
        {
            cboPtsHotel.SelectedValue = 0;
            cboPtsHabitacion.SelectedValue = 0;
            cboPtsHabitacion.Enabled = false;
            gpoSemanas.Visible = true;
            dgvSemanas.Visible = false;
            gpoAgregaPts.Visible = false;
            dgvSemanas.Columns.Clear();
            PtsInHabilita();
        }

        private void bttnGrabarSemanas_Click(object sender, EventArgs e)
        {         
            if (Nulos() == false)
            {
                if (DateTime.Compare(FecFin1.Value, FecIni1.Value) > 0)
                {
                    if (MessageBox.Show("Se grabara la información, ¿Continuar?", "Agregar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        pts.IdHotel = hab.IdHotel;
                        pts.IdHabitacion = hab.IdHabitacion;
                        pts.Codigo = hab.Codigo;

                        Insertar();

                        MessageBox.Show("Se guardo correctamente");

                        PtsInHabilita();
                        rdioSemConsulta.Checked = true;
                        rdioSemAgrega.Checked = false;

                        dgvSemanas.Visible = true;
                        gpoAgregaPts.Visible = false;
                        cboPtsHotel.SelectedValue = pts.IdHotel;
                        cboPtsHabitacion.SelectedValue = pts.IdHabitacion;

                        llenarDGVSemanas();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Fecha de Inicio debe ser anterior a la Fecha Final");
                }
            }
            else
            {
                MessageBox.Show("El valor de 'Semanas a Descontar' no debe ser nulo/vacio");
            }

        }

        private bool Nulos()
        {
            if (txtSem1.Text == "" || txtSem2.Text == "" || txtSem3.Text == "" || txtSem4.Text == "" ||
                txtSem5.Text == "" || txtSem6.Text == "" || txtSem7.Text == "" || txtSem8.Text == "" ||
                txtSem9.Text == "" || txtSem10.Text == "" || txtSem11.Text == "" || txtSem12.Text == "")
            { return true; }
            else
            { return false; }
        }

        private void Insertar()
        {

            if (FecIni1.Visible==true && FecFin1.Visible==true && txtSem1.Visible == true)
            {  pts.InsertSemanas(FecIni1.Value,FecFin1.Value, dividePuntos(Convert.ToDouble(txtSem1.Text)) );  }

            if (FecIni2.Visible == true && FecFin2.Visible == true && txtSem2.Visible == true)
            { pts.InsertSemanas(FecIni2.Value, FecFin2.Value, dividePuntos(Convert.ToInt32(txtSem2.Text))); }

            if (FecIni3.Visible == true && FecFin3.Visible == true && txtSem3.Visible == true)
            { pts.InsertSemanas(FecIni3.Value, FecFin3.Value, dividePuntos(Convert.ToInt32(txtSem3.Text))); }

            if (FecIni4.Visible == true && FecFin4.Visible == true && txtSem4.Visible == true)
            { pts.InsertSemanas(FecIni4.Value, FecFin4.Value, dividePuntos(Convert.ToInt32(txtSem4.Text))); }

            if (FecIni5.Visible == true && FecFin5.Visible == true && txtSem5.Visible == true)
            { pts.InsertSemanas(FecIni5.Value, FecFin5.Value, dividePuntos(Convert.ToInt32(txtSem5.Text))); }

            if (FecIni6.Visible == true && FecFin6.Visible == true && txtSem6.Visible == true)
            { pts.InsertSemanas(FecIni6.Value, FecFin6.Value, dividePuntos(Convert.ToInt32(txtSem6.Text))); }

            if (FecIni7.Visible == true && FecFin7.Visible == true && txtSem7.Visible == true)
            { pts.InsertSemanas(FecIni7.Value, FecFin7.Value, dividePuntos(Convert.ToInt32(txtSem7.Text))); }

            if (FecIni8.Visible == true && FecFin8.Visible == true && txtSem8.Visible == true)
            { pts.InsertSemanas(FecIni8.Value, FecFin8.Value, dividePuntos(Convert.ToInt32(txtSem8.Text))); }

            if (FecIni9.Visible == true && FecFin9.Visible == true && txtSem9.Visible == true)
            { pts.InsertSemanas(FecIni9.Value, FecFin9.Value, dividePuntos(Convert.ToInt32(txtSem9.Text))); }

            if (FecIni10.Visible == true && FecFin10.Visible == true && txtSem10.Visible == true)
            { pts.InsertSemanas(FecIni10.Value, FecFin10.Value, dividePuntos(Convert.ToInt32(txtSem10.Text))); }

            if (FecIni11.Visible == true && FecFin11.Visible == true && txtSem11.Visible == true)
            { pts.InsertSemanas(FecIni11.Value, FecFin11.Value, dividePuntos(Convert.ToInt32(txtSem11.Text))); }

            if (FecIni12.Visible == true && FecFin12.Visible == true && txtSem12.Visible == true)
            { pts.InsertSemanas(FecIni12.Value, FecFin12.Value, dividePuntos(Convert.ToInt32(txtSem12.Text))); }
        }

        private int dividePuntos(double var)
        {
            double x = Math.Floor(var / 2);
            return Convert.ToInt32(x);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tabControl1.SelectedIndex) == 2) //HOTELES
            {
                LimpiarHotel();
                cboSelecHot.SelectedValue = 0;
                cboHotSalaVta.SelectedValue = 0;
                radioConsulta.Checked = false;
                radioInsert.Checked = false;
                radioUpdate.Checked = false;
            }
            else if (Convert.ToInt32(tabControl1.SelectedIndex) == 1) //HABITACIONES
            {
                LimpiarHabitacion();
                cboHabHotel.SelectedValue = 0;
                rdioHab.Checked = false;
                rdioAlta.Checked = false;
                rdioEditar.Checked = false;
            }
            else //PUNTOS
            {                
                config();
                LimpiaPts();
                rdioSemAgrega.Checked = false;
                rdioSemConsulta.Checked = false;
                rdioModPuntos.Checked = false;
            }
        }

        private void rdioSemConsulta_CheckedChanged(object sender, EventArgs e)
        {
            gpoSemanas.Text = "Consultar las Cuotas de Semanas por Habitación";
            config();
        }

        private void rdioSemAgrega_CheckedChanged(object sender, EventArgs e)
        {
            gpoSemanas.Text = "Agregar Cuotas de Semanas por Habitación";
            config();
        }

        private void rdioModPuntos_CheckedChanged(object sender, EventArgs e)
        {
            gpoSemanas.Text = "Modificar Cuotas de Semanas por Habitación del nuevo Ejercicio";
            config();
        }

        private void bttnCerrarSemanas_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtSem1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender,e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni2.Visible = true;
                FecFin2.Visible = true;
                txtSem2.Visible = true;

                FecIni2.Text = FecFin1.Value.AddDays(1).ToString();
                FecFin2.Text = FecIni2.Value.AddDays(1).ToString();
            }
        }

        private void txtSem2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni3.Visible = true;
                FecFin3.Visible = true;
                txtSem3.Visible = true;

                FecIni3.Text = FecFin2.Value.AddDays(1).ToString();
                FecFin3.Text = FecIni3.Value.AddDays(1).ToString();
            }
        }

        private void txtSem3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni4.Visible = true;
                FecFin4.Visible = true;
                txtSem4.Visible = true;

                FecIni4.Text = FecFin3.Value.AddDays(1).ToString();
                FecFin4.Text = FecIni4.Value.AddDays(1).ToString();
            }
        }

        private void txtSem4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni5.Visible = true;
                FecFin5.Visible = true;
                txtSem5.Visible = true;

                FecIni5.Text = FecFin4.Value.AddDays(1).ToString();
                FecFin5.Text = FecIni5.Value.AddDays(1).ToString();
            }
        }

        private void txtSem5_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni6.Visible = true;
                FecFin6.Visible = true;
                txtSem6.Visible = true;

                FecIni6.Text = FecFin5.Value.AddDays(1).ToString();
                FecFin6.Text = FecIni6.Value.AddDays(1).ToString();
            }
        }

        private void txtSem6_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni7.Visible = true;
                FecFin7.Visible = true;
                txtSem7.Visible = true;

                FecIni7.Text = FecFin6.Value.AddDays(1).ToString();
                FecFin7.Text = FecIni7.Value.AddDays(1).ToString();
            }
        }

        private void txtSem7_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni8.Visible = true;
                FecFin8.Visible = true;
                txtSem8.Visible = true;

                FecIni8.Text = FecFin7.Value.AddDays(1).ToString();
                FecFin8.Text = FecIni8.Value.AddDays(1).ToString();
            }
        }

        private void txtSem8_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni9.Visible = true;
                FecFin9.Visible = true;
                txtSem9.Visible = true;

                FecIni9.Text = FecFin8.Value.AddDays(1).ToString();
                FecFin9.Text = FecIni9.Value.AddDays(1).ToString();
            }
        }

        private void txtSem9_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni10.Visible = true;
                FecFin10.Visible = true;
                txtSem10.Visible = true;

                FecIni10.Text = FecFin9.Value.AddDays(1).ToString();
                FecFin10.Text = FecIni10.Value.AddDays(1).ToString();
            }
        }

        private void txtSem10_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni11.Visible = true;
                FecFin11.Visible = true;
                txtSem11.Visible = true;

                FecIni11.Text = FecFin10.Value.AddDays(1).ToString();
                FecFin11.Text = FecIni11.Value.AddDays(1).ToString();
            }
        }

        private void txtSem11_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                FecIni12.Visible = true;
                FecFin12.Visible = true;
                txtSem12.Visible = true;

                FecIni12.Text = FecFin11.Value.AddDays(1).ToString();
                FecFin12.Text = FecIni12.Value.AddDays(1).ToString();
            }
        }


    }
}
