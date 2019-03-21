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
    class Bitacora
    {
        Conexion cx = new Conexion();

        public int MaximoId { get; set; }


        public Bitacora()
        {
            MaximoId = 0;
        }

        public void RegistrarBitacora(int Folio, string Tabla, string Campo, string Accion, string valAnt, string valNew)
        {

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select Max(CB_ID)from CSharpBitacora where CB_FOLIO = @Folio";
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaximoId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }


                // registra accion en bitacora'
                string sql2 = "INSERT INTO CSharpBitacora (CB_FOLIO, CB_ID, CB_TABLA, CB_CAMPO, CB_ACCION, CB_VALORANT, CB_VALORNEW, CB_USR, CB_FECHA) VALUES (@folio,@id,@tabla,@campo, @accion, @valAnt, @valNew,@usr,SYSDATETIME())";

                using (SqlCommand comando = new SqlCommand(sql2, con))
                {
                    comando.Parameters.Add("@folio", SqlDbType.Int).Value = Folio;
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = MaximoId + 1;
                    comando.Parameters.Add("@tabla", SqlDbType.VarChar).Value = Tabla;
                    comando.Parameters.Add("@campo", SqlDbType.VarChar).Value = Campo;
                    comando.Parameters.Add("@accion", SqlDbType.VarChar).Value = Accion;
                    comando.Parameters.Add("@valAnt", SqlDbType.VarChar).Value = valAnt;
                    comando.Parameters.Add("@valNew", SqlDbType.VarChar).Value = valNew;
                    comando.Parameters.Add("@usr", SqlDbType.Int).Value = Sesion.ID;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }


        }

    }
}
