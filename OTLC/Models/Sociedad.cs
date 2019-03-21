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
    class Sociedad
    {
        Conexion c = new Conexion();

        public Sociedad()
        {
            this.IdSociedad = 1;
            this.LeerSociedad();
        }

        public int IdSociedad { get; set; }
        public string Nombre { get; set; }
        public string Representante { get; set; }
        public string TextoMxn { get; set; }
        public string CtaAbonoMxn { get; set; }
        public string CtaClaveMxn { get; set; }
        public string DivisaMxn { get; set; }
        public string TextoUsd { get; set; }
        public string CtaAbonoUsd { get; set; }
        public string CtaClaveUsd { get; set; }
        public string DivisaUsd { get; set; }
        public string Domicilio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cp { get; set; }
        public string TelMx { get; set; }
        public string TelUsa { get; set; }
        public string TelOtro { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Vendedor { get; set; }
        public string Comprador { get; set; }
        public string Compradores { get; set; }
        public string OTLC { get; set; }
        public string OTLCmin { get; set; }
        public string CxcTel { get; set; }
        public string CxcEmail { get; set; }
        public string Vendedor2 { get; set; }
        public string Comprador2 { get; set; }
        public string Compradores2 { get; set; }
        public string OTLCiniciales { get; set; }


        public void LeerSociedad()
        {

            string sql = "select IdSociedad, Nombre , Representante , TextoMxn,CtaAbonoMxn ,CtaClaveMxn , DivisaMxn ,TextoUsd , CtaAbonoUsd, CtaClaveUsd , DivisaUsd, Domicilio , Ciudad , Estado, Pais , Cp, TelMx , TelUsa, TelOtro, Email1 , Email2, Vendedor, Comprador,Compradores ,OTLC,OTLCmin,CxcTel,CxcEmail, Vendedor2, Comprador2,Compradores2,OTLCiniciales from Sociedad where IdSociedad = @IdSociedad";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdSociedad", SqlDbType.Int).Value = IdSociedad;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0))
                            { IdSociedad = 0; }
                            else { IdSociedad = reader.GetInt32(0);}
                             
                            if (reader.IsDBNull(1))
                            { Nombre = ""; }
                            else { Nombre = reader.GetString(1); }

                            if (reader.IsDBNull(2))
                            { Representante = ""; }
                            else { Representante = reader.GetString(2); }

                            if (reader.IsDBNull(3))
                            { TextoMxn = ""; }
                            else { TextoMxn = reader.GetString(3); }

                            if (reader.IsDBNull(4))
                            { CtaAbonoMxn = ""; }
                            else { CtaAbonoMxn = reader.GetString(4); }

                            if (reader.IsDBNull(5))
                            { CtaClaveMxn = ""; }
                            else { CtaClaveMxn = reader.GetString(5); }

                            if (reader.IsDBNull(6))
                            { DivisaMxn = ""; }
                            else { DivisaMxn = reader.GetString(6); }

                            if (reader.IsDBNull(7))
                            { TextoUsd = ""; }
                            else { TextoUsd = reader.GetString(7); }

                            if (reader.IsDBNull(8))
                            { CtaAbonoUsd = ""; }
                            else { CtaAbonoUsd = reader.GetString(8); }

                            if (reader.IsDBNull(9))
                            { CtaClaveUsd = ""; }
                            else { CtaClaveUsd = reader.GetString(9); }

                            if (reader.IsDBNull(10))
                            { DivisaUsd = ""; }
                            else { DivisaUsd = reader.GetString(10); }

                            if (reader.IsDBNull(11))
                            { Domicilio = ""; }
                            else { Domicilio = reader.GetString(11); }

                            if (reader.IsDBNull(12))
                            { Ciudad = ""; }
                            else { Ciudad = reader.GetString(12); }

                            if (reader.IsDBNull(13))
                            { Estado = ""; }
                            else { Estado = reader.GetString(13); }

                            if (reader.IsDBNull(14))
                            { Pais = ""; }
                            else { Pais = reader.GetString(14); }

                            if (reader.IsDBNull(15))
                            { Cp = ""; }
                            else { Cp = reader.GetString(15); }

                            if (reader.IsDBNull(16))
                            { TelMx = ""; }
                            else { TelMx = reader.GetString(16); }

                            if (reader.IsDBNull(17))
                            { TelUsa = ""; }
                            else { TelUsa = reader.GetString(17); }

                            if (reader.IsDBNull(18))
                            { TelOtro = ""; }
                            else { TelOtro = reader.GetString(18); }

                            if (reader.IsDBNull(19))
                            { Email1 = ""; }
                            else { Email1 = reader.GetString(19); }

                            if (reader.IsDBNull(20))
                            { Email2 = ""; }
                            else { Email2 = reader.GetString(20); }

                            if (reader.IsDBNull(21))
                            { Vendedor = ""; }
                            else { Vendedor = reader.GetString(21); }

                            if (reader.IsDBNull(22))
                            { Comprador = ""; }
                            else { Comprador = reader.GetString(22); }

                            if (reader.IsDBNull(23))
                            { Compradores = ""; }
                            else { Compradores = reader.GetString(23); }

                            if (reader.IsDBNull(24))
                            { OTLC = ""; }
                            else { OTLC = reader.GetString(24); }

                            if (reader.IsDBNull(25))
                            { OTLCmin = ""; }
                            else { OTLCmin = reader.GetString(25); }

                            if (reader.IsDBNull(26))
                            { CxcTel = ""; }
                            else { CxcTel = reader.GetString(26); }

                            if (reader.IsDBNull(27))
                            { CxcEmail = ""; }
                            else { CxcEmail = reader.GetString(27); }

                            if (reader.IsDBNull(28))
                            { Vendedor2 = ""; }
                            else { Vendedor2 = reader.GetString(28); }

                            if (reader.IsDBNull(29))
                            { Comprador2 = ""; }
                            else { Comprador2 = reader.GetString(29); }

                            if (reader.IsDBNull(30))
                            { Compradores2 = ""; }
                            else { Compradores2 = reader.GetString(30); }

                            if (reader.IsDBNull(31))
                            { OTLCiniciales = ""; }
                            else { OTLCiniciales = reader.GetString(31); }

                        }
                    }

                    con.Close();

                }

            }

        }









    }
}
