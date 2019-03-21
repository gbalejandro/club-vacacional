using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class StatusContratos1
    {
        Conexion cx = new Conexion();

        public int idStatusCon1 { get; set; }
        public string Nombre { get; set; }
        public int ColorFondo { get; set; }
        public int ColorFuente { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }

        public void Limpiar()
        {
            idStatusCon1 = 0;
            Nombre = "";
            ColorFondo = 0;
            ColorFuente = 0;
            Idioma2 = "";
            Idioma3 = "";
        }

        public void LeerStatus1(int valor)
        {
            string sql = "select*from StatusContratos1 where idStatusCon1=@valor";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idStatusCon1 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre       = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            ColorFondo   = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            ColorFuente  = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        }
                    }

                    con.Close();
                }

                Traduccion(valor);

            }
        }

        private void Traduccion(int status)
        {
            Idioma2 = ""; //ingles
            Idioma3 = ""; //portugues

            switch (status)
            {
                case 1: //"Pendiente":
                    Idioma2 = "Pending";
                    Idioma3 = "Pendente";
                    break;
                case 2:// "Al Corriente":
                    Idioma2 = "Aware";
                    Idioma3 = "A corrente";
                    break;
                case 3:// "Moroso":
                    Idioma2 = "Defaulter";
                    Idioma3 = "Moroso";
                    break;
                case 4:// "Cancelado":
                    Idioma2 = "Cancelled";
                    Idioma3 = "Cancelado";
                    break;
                case 5:// "Liquidado":
                    Idioma2 = "Liquidated";
                    Idioma3 = "Liquidado";
                    break;
                case 6:// "Procesable":
                    Idioma2 = "Actionable";
                    Idioma3 = "Processável";
                    break;
                case 7:// "Procesable No Comisionable":
                    Idioma2 = "Processable Non-Commissionable";
                    Idioma3 = "Processável não comutável";
                    break;
                case 8:// "Anulado":
                    Idioma2 = "Canceled";
                    Idioma3 = "Cancelado";
                    break;
                case 50:// "RMI":
                    Idioma2 = "RMI";
                    Idioma3 = "RMI";
                    break;
                case 100:// "Suspendido":               
                    Idioma2 = "Discontinued";
                    Idioma3 = "Suspenso";
                    break;
                default:
                    Idioma2 = "";
                    Idioma3 = "";
                    break;
            }
        }        
    }
}
