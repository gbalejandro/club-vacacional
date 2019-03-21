using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Puestos
    {
        Conexion cx = new Conexion();

        public int idPuesto { get; set; }
        public string Nombre { get; set; }
        public string ShowNomina { get; set; }
        public int idDivision { get; set; }
        public string ShowInPromotor { get; set; }
        public string ShowInLiner { get; set; }
        public string ShowInCloser { get; set; }
        public string ShowInExitCloser { get; set; }
        public string ShowInHostes { get; set; }
        public string ShowInVlo { get; set; }
        public string ShowInFrontDesk { get; set; }
        public string IdStatus { get; set; }
        public int Orden { get; set; }
        public int idPuestoReporte { get; set; }
        public int IdUsuarioalt { get; set; }
        public DateTime Fechoralt { get; set; }
        public string ShowInTeamLeader { get; set; }

        public void Limpiar()
        {
            idPuesto = 0;
            Nombre = "";
            ShowNomina = "";
            idDivision = 0;
            ShowInPromotor = "";
            ShowInLiner = "";
            ShowInCloser = "";
            ShowInExitCloser = "";
            ShowInHostes = "";
            ShowInVlo = "";
            ShowInFrontDesk = "";
            IdStatus = "";
            Orden = 0;
            idPuestoReporte = 0;
            IdUsuarioalt = 0;
            Fechoralt = Convert.ToDateTime("01/01/50");
            ShowInTeamLeader = "";
        }

        public void LeerPuestos(int valor)
        {
            Limpiar();

            string sql = "selecT*from Puestos where idPuesto=@valor";

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
                            idPuesto            = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre              = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            ShowNomina          = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            idDivision          = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            ShowInPromotor      = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            ShowInLiner         = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            ShowInCloser        = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            ShowInExitCloser    = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            ShowInHostes        = reader.IsDBNull(8) ? "" : reader.GetString(8);
                            ShowInVlo           = reader.IsDBNull(9) ? "" : reader.GetString(9);
                            ShowInFrontDesk     = reader.IsDBNull(10) ? "" : reader.GetString(10);
                            IdStatus            = reader.IsDBNull(11) ? "" : reader.GetString(11);
                            Orden               = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
                            idPuestoReporte     = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
                            IdUsuarioalt        = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);
                            Fechoralt           = reader.IsDBNull(15) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(15);
                            ShowInTeamLeader    = reader.IsDBNull(16) ? "" : reader.GetString(16);                
                        }
                    }

                    con.Close();
                }
            }
        }






    }
}
