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
    public partial class NotasDetalle : Form
    {
        Conexion cx = new Conexion();
        public NotasDetalle()
        {
            InitializeComponent();
        }

        public NotasDetalle(int folio,int id, string tipo)
        {
            InitializeComponent();
            LeerNota(folio,id,tipo);

        }

        private void LeerNota(int folio, int id, string tipo)
        {
            string sql = "select Comentario from ";
            sql = tipo == "NotasExtras" ? sql + " ContratosNotasExtras " : sql + " ContratosNotas ";
            sql = sql +" where FolioContrato = @Folio and idComentario=@id";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = folio;
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtComentario.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        }
                    }

                    con.Close();
                }
            }
        }



        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
