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
    public class llenarComboBox
    {
        Conexion c = new Conexion();

        public void TipoCon(ComboBox valor)
        {
            string sql = "select idtipcon, Iniciales from TiposContrato order by idTipvta";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion)) //---se declara una variable de tipo SqlConnection y se indica la cadena de conexion
            {
                con.Open();

                DataSet ds = new DataSet();                          //---codigo para llenar el comboBox               
                SqlDataAdapter da = new SqlDataAdapter(sql, con);    //---indicamos la consulta en SQL            
                da.Fill(ds, "TiposContrato");                        //---se indica el nombre de la tabla

                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idtipcon";                     //se especifica el valor con el identificador del campo de la tabla
                valor.DisplayMember = "Iniciales";                  //campo como texto que mostrara el combo

                con.Close();
            }
        }

        public void Moneda(ComboBox valor)
        {
            string sql = "select idMoneda,Nombre from Monedas order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Monedas");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idMoneda";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void Nacionalidad(ComboBox valor)
        {
            string sql = "select distinct idNacionalidad,Nombre from Nacionalidades order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Nacionalidades");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idNacionalidad";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void Idioma(ComboBox valor)
        {
            string sql = "select IdIdioma, Nombre from Idiomas order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Idiomas");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "IdIdioma";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void TipoPersona(ComboBox valor)
        {
            string sql = "select idTipoPersona,Nombre from TiposPersona order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "TiposPersona");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idTipoPersona";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void EdoCivil(ComboBox valor)
        {
            string sql = "select idEdoCivil, Nombre From EdoCivil order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "EdoCivil");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idEdoCivil";
                valor.DisplayMember = "Nombre";


                con.Close();
            }
        }

        public void Ciudad(ComboBox valor)
        {
            string sql = "select distinct idCiudad, Nombre from Ciudades order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Ciudades");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idCiudad";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void Estado(ComboBox valor)
        {
            string sql = "select distinct idEstado, Nombre from Estados order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Estados");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idEstado";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void Pais(ComboBox valor)
        {
            string sql = "select distinct idPais,Nombre from Paises order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Paises");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idPais";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void Status1(ComboBox valor)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                string sql = "select idStatusCon1, Nombre from StatusContratos1 order by Nombre";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            dt.Rows.Add(new object[] { 0, "" });
            valor.DisplayMember = "Nombre";
            valor.ValueMember = "idStatusCon1";
            valor.DataSource = dt;

        }

        public void Status2(ComboBox valor)
        {
            string sql = "select idStatusCon2,Nombre from StatusContratos2 order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "StatusContratos2");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idStatusCon2";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void IdiomaDoctos(ComboBox valor) //Reportes
        {
            string sql = "select DI_ID, DI_NOMBRE from CSharpDoctosIdiomas order by DI_ID";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "CSharpDoctosIdiomas");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "DI_ID";
                valor.DisplayMember = "DI_NOMBRE";

                con.Close();
            }
        }

        public void GrupoDoctos(ComboBox valor) //Reportes
        {
            string sql = "select idGrupo, Nombre from GrupoDoctos order by idGrupo";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "GrupoDoctos");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idGrupo";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void FormasPago(ComboBox valor)
        {
            string sql = "select distinct idForpag,Nombre from FormasPago order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "FormasPago");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idForpag";
                valor.DisplayMember = "Nombre";

                con.Close();
            }
        }

        public void UsuariosActivos(ComboBox valor)
        {
            string sql = "select distinct idUsuario, Nombre+' | '+Iniciales as Nombre from Usuarios where IdStatus = 'A' order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Usuarios");
                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idUsuario";
                valor.DisplayMember = "Nombre";
                
                con.Close();
            }
        }

        public void SalasVta(ComboBox valor)
        {
             string sql = "select idSalaVta, Nombre from SalasVta where Activo=1 order by idSalaVta";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            { 
                con.Open();

                DataSet ds = new DataSet();                                    
                SqlDataAdapter da = new SqlDataAdapter(sql, con);              
                da.Fill(ds, "SalasVta");                        

                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idSalaVta";                     
                valor.DisplayMember = "Nombre";                 

                con.Close();
            }
        }

        public void RegalosGrupos(ComboBox valor)
        {
            string sql = "select idGrupo,Nombre from RegalosGrupos order by idGrupo";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "RegalosGrupos");

                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idGrupo";
                valor.DisplayMember = "Nombre";

                con.Close();
            }

        }

        public void Status(ComboBox valor)
        {
            string sql = "select idStatus, Nombre from Status";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Status");

                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idStatus";
                valor.DisplayMember = "Nombre";

                con.Close();
            }

        }

        public void Division(ComboBox valor)
        {
            string sql = "select idDivision,Nombre from Divisiones order by idDivision";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Divisiones");

                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idDivision";
                valor.DisplayMember = "Nombre";

                con.Close();
            }

        }

        public void RegalosDoctos(ComboBox valor)
        {
            string sql = "select d.idDocto as idDocto, d.Nombre+' ('+i.Nombre+')' as Nombre from Doctos d left join Idiomas i on d.IdIdioma= i.IdIdioma where idSalaVta = 1 order by d.Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Doctos");

                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idDocto";
                valor.DisplayMember = "Nombre";

                con.Close();
            }

        }

        public void RegalosCatalogo(ComboBox valor)
        {
            string sql = "select idRegalo, Nombre from Regalos where idSalaVta = 1 order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Regalos");

                valor.DataSource = ds.Tables[0].DefaultView;
                valor.ValueMember = "idRegalo";
                valor.DisplayMember = "Nombre";

                con.Close();
            }

        }

        public void Hoteles(ComboBox valor)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                string sql = "SELECT idHotel,Nombre FROM Hoteles where idSalaVta>0";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            dt.Rows.Add(new object[] { 0, "- SELECCIONAR -" });
            valor.ValueMember = "idHotel";
            valor.DisplayMember = "Nombre";
            valor.DataSource = dt;

            valor.SelectedValue = 0;
        }

        public void Habitaciones(ComboBox valor, int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                string sql = "SELECT IdHabitacion,Nombre FROM ReservacionesHabitaciones where IdHotel="+id;
                                                                                        
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            //dt.Rows.Add(new object[] { 0, "- SELECCIONAR -" });
            valor.ValueMember = "IdHabitacion";
            valor.DisplayMember = "Nombre";
            valor.DataSource = dt;

           // valor.SelectedValue = 0;
        }

    }
}
