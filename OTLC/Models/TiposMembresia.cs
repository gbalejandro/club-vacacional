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
    class TiposMembresia
    {
        Conexion cx = new Conexion();

        public int idTipmem { get; set; }
        public string Nombre { get; set; }
        public string Idioma2 { get; set; }
        public string Iniciales { get; set; }
        public int idTemporada { get; set; }
        public int SemanasBase { get; set; }
        public int LimiteSemanas { get; set; }
        public double PrecioVentaSugerido { get; set; }
        public double PrecioLista { get; set; }
        public double PrecioListaFinan { get; set; }
        public double PrecioTope { get; set; }
        public int idStatus { get; set; }
        public int idUsuarioAlt { get; set; }
        public DateTime FechorAlt { get; set; }
        public double PrecioVentaCash { get; set; }
        public int PuntosXAño { get; set; }
        public int DuracionAños { get; set; }
        public string NombreTTop { get; set; }
        public bool CostoCierreCero { get; set; }


        public void Limpiar()
        {
            idTipmem = 0;
            Nombre = "";
            Idioma2 = "";
            Iniciales = "";
            idTemporada = 0;
            SemanasBase = 0;
            LimiteSemanas = 0;
            PrecioVentaSugerido = 0;
            PrecioLista = 0;
            PrecioListaFinan = 0;
            PrecioTope = 0;
            idStatus = 0;
            idUsuarioAlt = 0;
            FechorAlt = Convert.ToDateTime("01/01/50");
            PrecioVentaCash = 0;
            PuntosXAño = 0;
            DuracionAños = 0;
            NombreTTop = "";
            CostoCierreCero = false;
        }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(TiposMembresia);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(TiposMembresia);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        public void LeerTipMem(int valor)
        {
            string sql = "select *from TiposMembresia where idTipmem=@valor";

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
