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
    public class Usuarios
    {
        Conexion cx = new Conexion();

        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Iniciales { get; set; }
        public string Contra { get; set; }
        public string NombreCorto { get; set; }
        public string Rfc { get; set; }
        public string Contacto { get; set; }
        public int IdPuesto { get; set; }
        public int IdDepto { get; set; }
        public int IdHotel { get; set; }
        public int IdSalaVta { get; set; }
        public string Linea { get; set; }
        public double Porcom { get; set; }
        public double Iva { get; set; }
        public int IdLocacion { get; set; }
        public DateTime FechaBaja { get; set; }
        public int Faltas { get; set; }
        public string Excluir { get; set; }
        public double Acufoncan { get; set; }
        public string Foncan { get; set; }
        public string IdStatus { get; set; }
        public int IdusuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }
        public bool Referidos { get; set; }
        public int idRole { get; set; }
        public bool Filtro1 { get; set; }
        public bool EsInformativo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime FechaCambio { get; set; }
        public string UsuarioCorreo { get; set; }
        public string ContraCorreo { get; set; }
        public int DiaDescanso { get; set; }
        public int IdIdioma { get; set; }
        public byte IdEsquemaComision { get; set; }
        public bool NoTRM { get; set; }

        public bool existeOTLC { get; set; }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Usuarios);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Usuarios);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        public void LeerUsuario(int valor)
        {
            string sql = "select * from Usuarios where idUsuario=@valor";

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

        public void SesionUsuario(string usr, string pwd)
        {
            string sql = "select * from Usuarios where Iniciales=@usr and Contra=@pwd";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.VarChar).Value = usr;
                    comando.Parameters.Add("@pwd", SqlDbType.VarChar).Value = pwd;

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
