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
using OTLC.Models;

namespace OTLC
{
    public class Sesion
    {
        Conexion c = new Conexion();
        Usuarios us = new Usuarios();
        AsignaPermisos ap = new AsignaPermisos();

        // U S U A R I I O
        public static int ID { get; set; }
        public static string USR { get; set; }
        public static string PWD { get; set; }
        public static string STATUS { get; set; }


        public bool existeMeta { get; set; }
        public bool existeOtlc { get; set; }


        //  P E R M I S O S
        public static bool EmpresaAcc { get; set; }
        public static bool EmpresaMod { get; set; }
        public static bool ContratosAcc { get; set; }
        public static bool ContratosMod { get; set; }
        public static bool ContratosModGeneral { get; set; }
        public static bool ContratosModStatus1 { get; set; }
        public static bool ContratosModTarjetas { get; set; }
        public static bool ContratosModVentas { get; set; }
        public static bool ContratosRep { get; set; }
        public static bool ContratosRegalos { get; set; }
        public static bool ContratosRegalosRep { get; set; }
        public static bool ContratosRegalosCat { get; set; }
        public static bool CobranzaAcc { get; set; }
        public static bool CobranzaReestructura { get; set; }
        public static bool CobranzaAplicarPagos { get; set; }
        public static bool CobranzaPagoCapital { get; set; }
        public static bool CobranzaPagoContrato { get; set; }
        public static bool CobranzaPagoEnganche { get; set; }
        public static bool EstadisticasAcc { get; set; }
        public static bool EstadisticasTablaGralCtos { get; set; }
        public static bool AsignarPermisosAcc { get; set; }
        public static bool ReservacionesAcc { get; set; }
        public static bool ReservacionesMod { get; set; }
        public static bool ReservacionesPtosNuevoAño { get; set; }
        public static bool ReservacionesEdoPuntos { get; set; }
        public static bool ReservacionesCumpleaños { get; set; }
        public static bool ReservacionesPorcentajes { get; set; }


        public Sesion()
        {
            Limpiar();
        }

        public void VerificarUsuario(string usr, string pwd)
        {
            us.SesionUsuario(usr, pwd);

            if (us.idUsuario > 0)
            {
                existeMeta = true;
                UsrActivoEnClub();

                if (ID > 0)
                {
                    ap.LeerPermisos(ID);
                    AsignaValores();
                }
            }
            else
            {
                existeMeta = false;
            }
        }

        private void UsrActivoEnClub()
        {

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                string sql = "select 'true' from CSharpUsuarios where US_ID=@usr";
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.Int).Value = us.idUsuario;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            existeOtlc = reader.IsDBNull(0) ? false : Convert.ToBoolean(reader.GetString(0));
                        }
                    }
                }

                if (existeOtlc == true)
                {
                    ID = us.idUsuario;
                    USR = us.Iniciales;
                    PWD = us.Contra;
                    STATUS = us.IdStatus;

                    string sql2 = "update CSharpUsuarios set US_STATUS=@STAT,US_PWD=@PWD where US_ID=@ID";
                    using (SqlCommand comando = new SqlCommand(sql2, con))
                    {
                        comando.Parameters.Add("@STAT", SqlDbType.VarChar).Value = STATUS;
                        comando.Parameters.Add("@PWD", SqlDbType.VarChar).Value = PWD;
                        comando.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }
                }
                else
                {
                    Limpiar();
                }

                con.Close();
            }
        }

        private void AsignaValores()
        {
            EmpresaAcc = ap.EmpresaAcc;
            EmpresaMod = ap.EmpresaMod;
            ContratosAcc = ap.ContratosAcc;
            ContratosMod = ap.ContratosMod;
            ContratosModGeneral = ap.ContratosModGeneral;
            ContratosModStatus1 = ap.ContratosModStatus1;
            ContratosModTarjetas = ap.ContratosModTarjetas;
            ContratosModVentas = ap.ContratosModVentas;
            ContratosRep = ap.ContratosRep;
            ContratosRegalos = ap.ContratosRegalos;
            ContratosRegalosRep = ap.ContratosRegalosRep;
            ContratosRegalosCat = ap.ContratosRegalosCat;
            CobranzaAcc = ap.CobranzaAcc;
            CobranzaReestructura = ap.CobranzaReestructura;
            CobranzaAplicarPagos = ap.CobranzaAplicarPagos;
            CobranzaPagoCapital = ap.CobranzaPagoCapital;
            CobranzaPagoContrato = ap.CobranzaPagoContrato;
            CobranzaPagoEnganche = ap.CobranzaPagoEnganche;
            EstadisticasAcc = ap.EstadisticasAcc;
            EstadisticasTablaGralCtos = ap.EstadisticasTablaGralCtos;
            AsignarPermisosAcc = ap.AsignarPermisosAcc;
            ReservacionesAcc = ap.ReservacionesAcc;
            ReservacionesMod = ap.ReservacionesMod;
            ReservacionesPtosNuevoAño = ap.ReservacionesPtosNuevoAño;
            ReservacionesEdoPuntos = ap.ReservacionesEdoPuntos;
            ReservacionesCumpleaños = ap.ReservacionesCumpleaños;
            ReservacionesPorcentajes = ap.ReservacionesPorcentajes;
        }

        private void Limpiar()
        {
            ID = 0;
            USR = "";
            PWD = "";
            STATUS = "";

            EmpresaAcc = false;
            EmpresaMod = false;
            ContratosAcc = false;
            ContratosMod = false;
            ContratosModGeneral = false;
            ContratosModStatus1 = false;
            ContratosModTarjetas = false;
            ContratosModVentas = false;
            ContratosRep = false;
            ContratosRegalos = false;
            ContratosRegalosRep = false;
            ContratosRegalosCat = false;
            CobranzaAcc = false;
            CobranzaReestructura = false;
            CobranzaAplicarPagos = false;
            CobranzaPagoCapital = false;
            CobranzaPagoContrato = false;
            CobranzaPagoEnganche = false;
            EstadisticasAcc = false;
            EstadisticasTablaGralCtos = false;
            AsignarPermisosAcc = false;
            ReservacionesAcc = false;
            ReservacionesMod = false;
            ReservacionesPtosNuevoAño = false;
            ReservacionesEdoPuntos = false;
            ReservacionesCumpleaños = false;
            ReservacionesPorcentajes = false;
        }

    }

}
