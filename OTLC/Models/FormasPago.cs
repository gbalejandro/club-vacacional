using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class FormasPago
    {
        Conexion c = new Conexion();

        public int idForpag { get; set; }
        public string Nombre { get; set; }
        public string Idioma2 { get; set; }
        public int idGrupoForpag { get; set; }
        public int idMoneda { get; set; }
        public string Confirmar { get; set; }
        public int ConfirmarDias { get; set; }
        public int Digitos1 { get; set; }
        public int Digitos2 { get; set; }
        public int Digitos3 { get; set; }
        public int Digitos4 { get; set; }
        public int idUsuarioAlt { get; set; }
        public DateTime FechorAlt { get; set; }

        public string EsTarjeta { get; set; }

        public void LeerFormasPago(int valor)
        {
            string sql = "select * from FormasPago where idForpag=@valor";

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
                            idForpag = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            Idioma2 = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            idGrupoForpag = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            idMoneda = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            Confirmar = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            ConfirmarDias = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                            Digitos1 = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                            Digitos2 = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                            Digitos3 = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                            Digitos4 = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                            idUsuarioAlt = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                            FechorAlt = reader.IsDBNull(12) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(12);
                        }
                    }

                    con.Close();
                }
            }

            if (idGrupoForpag == 2)
            { EsTarjeta = "SI"; }
            else
            { EsTarjeta = "NO"; }
        }
    }
}
