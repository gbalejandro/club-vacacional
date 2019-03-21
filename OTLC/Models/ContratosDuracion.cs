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
    class ContratosDuracion
    {
        Conexion cx = new Conexion();


        public int Folio { get; set; }
        public int idTipMem { get; set; }
        public int DuracionAños { get; set; }
        public int idUsrAlt { get; set; }
        public DateTime FecHorAlt { get; set; }

        public void Limpiar()
        {
            Folio = 0;
            idTipMem = 0;
            DuracionAños = 0;
            idUsrAlt = 0;
            FecHorAlt = Convert.ToDateTime("01/01/50");
        }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(ContratosDuracion);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(ContratosDuracion);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        public void LeerCtoDuracion(int folio)
        {
            string sql = "select*from ContratosDuracion where Folio=@Folio";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = folio;

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
