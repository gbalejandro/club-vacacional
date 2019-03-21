using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class TiposContrato
    {
        Conexion cx = new Conexion();

        public int idtipcon { get; set; }
        public string Nombre { get; set; }
        public string Iniciales { get; set; }
        public int idSalaVta { get; set; }
        public int Folio { get; set; }
        public int UltimaRelacion { get; set; }
        public string AutoFoliar { get; set; }
        public double CostoCierre { get; set; }
        public double Pormineng { get; set; }
        public double Portopeng { get; set; }
        public int idTipvta { get; set; }
        public double CostoCierreUpGrade { get; set; }
        public double CostoCierreUpGradeER { get; set; }
        public string CuentaDolares { get; set; }
        public string CuentaPesos { get; set; }
        public string CtaAbonoDolaresCobranza { get; set; }
        public string CtaAbonoPesosCobranza { get; set; }
        public decimal Iva { get; set; }
        public string CtaCostoVenta { get; set; }
        public int idTipconGpo { get; set; }
        public string CtaInteresDevengado { get; set; }
        public string ProcesarSEnganche { get; set; }
        public int idUsuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }
        public bool PorEngachePacatadoCero { get; set; }


        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(TiposContrato);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(TiposContrato);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        private void Limpiar()
        {
            idtipcon = 0;
            Nombre = "";
            Iniciales = "";
            idSalaVta = 0;
            Folio = 0;
            UltimaRelacion = 0;
            AutoFoliar = "";
            CostoCierre = 0;
            Pormineng = 0;
            Portopeng = 0;
            idTipvta = 0;
            CostoCierreUpGrade = 0;
            CostoCierreUpGradeER = 0;
            CuentaDolares = "";
            CuentaPesos = "";
            CtaAbonoDolaresCobranza = "";
            CtaAbonoPesosCobranza = "";
            Iva = 0;
            CtaCostoVenta = "";
            idTipconGpo = 0;
            CtaInteresDevengado = "";
            ProcesarSEnganche = "";
            idUsuarioAlt = 0;
            Fechoralt = Convert.ToDateTime("01/01/50");
            PorEngachePacatadoCero = false;

        }

        public void LeerTipCon(int valor)
        {
            Limpiar();
            string sql = "select* from TiposContrato where idtipcon = @idTipCon";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idTipCon", SqlDbType.Int).Value = valor;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                this[reader.GetName(i)] = reader.IsDBNull(i) ? cx.getNullValue(this[reader.GetName(i)]) : reader.GetValue(i);
                            }

                        }
                    }

                    con.Close();
                }
            }

        }





    }
}
