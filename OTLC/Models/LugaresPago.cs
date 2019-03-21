using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class LugaresPago
    {
        Conexion c = new Conexion();

        public int idLugarPago { get; set; }
        public string Nombre { get; set; }
        public int idUsuarioAlt { get; set; }
        public DateTime Fechorcap { get; set; }

        public void Limpiar()
        {
            idLugarPago = 0;
            Nombre = "";
            idUsuarioAlt = 0;
            Fechorcap = Convert.ToDateTime("01/01/50");
        }

        public void LeerLugaresPago(int valor)
        {
            string sql = "select * from LugaresPago where idLugarPago=@valor";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idLugarPago =   reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre =        reader.IsDBNull(1) ? "" : reader.GetString(1);
                            idUsuarioAlt =  reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            Fechorcap =     reader.IsDBNull(3) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(3);
                        }
                    }

                    con.Close();
                }
            }
        }



    }




}
