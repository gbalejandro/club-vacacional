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
    class Pagos
    {
        Conexion cx = new Conexion();
        ContratosMetodos cm = new ContratosMetodos();

        Bitacora bita = new Bitacora();


        public int FolioContrato { get; set; }
        public int Consec { get; set; }
        public int idTippag { get; set; }
        public double Importe { get; set; }
        public double ImporteBase { get; set; }
        public double PorDsctoCapital { get; set; }
        public double ImporteDsctoCapital { get; set; }
        public double PorDsctoInteres { get; set; }
        public double ImporteDsctoInteres { get; set; }
        public int idMoneda { get; set; } 
        public int idForpag { get; set; }
        public double TipoCambio { get; set; }
        public string NoTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; } 
        public string NoAutorizacion { get; set; }
        public int idLugarPago { get; set; }
        public int NoRelacion { get; set; }
        public DateTime FechaPago { get; set; } 
        public int idStatusPago { get; set; }//-------> 1=Pagado 2=Pendiente
        public int NoArregloM { get; set; }
        public int NoMensualidad { get; set; }
        public DateTime Fecpagpro { get; set; }
        public string ConfirmaCobro { get; set; }
        public DateTime Fecconcob { get; set; }
        public int idUsuarioConCob { get; set; }
        public string Referencia { get; set; }
        public int Liga { get; set; }
        public double Saldo { get; set; }
        public string Pagado { get; set; }
        public int NoEnganche { get; set; }
        public string Contrato { get; set; }
        public DateTime FechaReferencia { get; set; } 
        public int PagosCubiertos { get; set; }
        public string Cancelado { get; set; }
        public int idUsuarioCxl { get; set; }
        public DateTime FechaCxl { get; set; }
        public string Adelantada { get; set; }
        public int NoReporte { get; set; }
        public decimal ImportePesos { get; set; }
        public decimal TipoCambio2 { get; set; }
        public decimal ComisionBancaria { get; set; }
        public DateTime FechaRecepcion { get; set; } 
        public int idUsuarioAlt { get; set; }
        public DateTime FechorAlt { get; set; } 
        public int IdFactura { get; set; }//---------> 0
        public double InteresMoratorio { get; set; }
        public int idPlazoSI { get; set; }//---------> 0
        public bool Void { get; set; }

        //operaciones
        public double TotalPagado { get; set; }
        private int maximoConsec { get; set; }
        public double CCCobrado { get; set; }
        public double MontoPagado { get; set; }
        public int CCConsec { get; set; }
        public int noPagosCxc { get; set; }
        public int EngConsec { get; set; }
        public string EsTarjeta { get; set; }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Pagos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Pagos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        private void Limpiar(Pagos p)
        {
           // p.FolioContrato = 0;
           // p.Consec = 0;
            p.idTippag = 0;
            p.Importe = 0;
            p.ImporteBase = 0;
            p.PorDsctoCapital = 0;
            p.ImporteDsctoCapital = 0;
            p.PorDsctoInteres = 0;
            p.ImporteDsctoInteres = 0;
            p.idMoneda = 0;
            p.idForpag = 0;
            p.TipoCambio = 0;
            p.NoTarjeta = "";
            p.FechaExpiracion = Convert.ToDateTime("01/01/50");
            p.NoAutorizacion = "";
            p.idLugarPago = 0;
            p.NoRelacion = 0;
            p.FechaPago = Convert.ToDateTime("01/01/50");
            p.idStatusPago = 0;
            p.NoArregloM = 0;
            p.NoMensualidad = 0;
            p.Fecpagpro = Convert.ToDateTime("01/01/50");
            p.ConfirmaCobro = "";
            p.Fecconcob = Convert.ToDateTime("01/01/50");
            p.idUsuarioConCob = 0;
            p.Referencia = "";
            p.Liga = 0;
            p.Saldo = 0;
            p.Pagado = "";
            p.NoEnganche = 0;
            p.Contrato = "";
            p.FechaReferencia = Convert.ToDateTime("01/01/50");
            p.PagosCubiertos = 0;
            p.Cancelado = "";
            p.idUsuarioCxl = 0;
            p.FechaCxl = Convert.ToDateTime("01/01/50");
            p.Adelantada = "";
            p.NoReporte = 0;
            p.ImportePesos = 0;
            p.TipoCambio2 = 0;
            p.ComisionBancaria = 0;
            p.FechaRecepcion = Convert.ToDateTime("01/01/50");
            p.idUsuarioAlt = 0;
            p.FechorAlt = Convert.ToDateTime("01/01/50");
            p.IdFactura = 0;
            p.InteresMoratorio = 0;
            p.idPlazoSI = 0;
            p.Void = false;

            p.TotalPagado = 0;
        }

        public void ConsultaPago(Pagos p) //asignar folio y consecutivo antes de llamar al metodo
        {           
            Limpiar(p);

            string sql = "select * from Pagos where FolioContrato = @Folio and Consec = @Consec";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@Consec", SqlDbType.Int).Value = p.Consec;

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

                p.TotalPagado = p.Importe + p.InteresMoratorio;
            }

        }

        private void MaxConsec(Pagos p)
        {
            p.maximoConsec = 0;

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select Max(Consec) from Pagos where FolioContrato = @Folio";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p.maximoConsec = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }

                con.Close();
            }

        }
        
        public void ImportePendiente(Pagos p,Contratos cto, int tipPago, int noEng)
        {
            string sql = "";
            p.MontoPagado = 0;
            p.CCCobrado = 0;

            sql = tipPago == 2?
                    "select SUM(Importe)from Pagos where FolioContrato = @Folio and idTippag = @tipoPago and idStatusPago = 1 and consec <> 2 and Cancelado='False'" :
                    "select SUM(Importe)from Pagos where FolioContrato = @Folio and idTippag = @tipoPago and idStatusPago = 1 and Pagado='True' and NoEnganche=@Enganche and Cancelado='False'";           

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@tipoPago", SqlDbType.Int).Value = tipPago;

                    if (tipPago != 2) //enganche
                    {
                        comando.Parameters.Add("@Enganche", SqlDbType.Int).Value = noEng;
                    }

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p.MontoPagado = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        }
                    }
                }


                if (tipPago == 2) //costo de contrato
                {
                    p.CCCobrado = cto.CCCobrado;

                    string sqlConc = "select Max(Consec) from Pagos where FolioContrato = @Folio and idTippag = 2";

                    using (SqlCommand comando = new SqlCommand(sqlConc, con))
                    {
                        comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                p.CCConsec = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            }
                        }
                    }
                }


                con.Close();
            }
        }

        public void Consecutivos(Pagos p, int cons)
        {
            p.MaxConsec(p);
            
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                for (int i = p.maximoConsec; i > cons; i--)
                {
                    string sql2 = "update Pagos set Consec = @num where FolioContrato = @Folio and Consec = @Consec";

                    using (SqlCommand comando = new SqlCommand(sql2, con))
                    {
                        comando.Parameters.Add("@num", SqlDbType.Int).Value = i + 1;
                        comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                        comando.Parameters.Add("@Consec", SqlDbType.Int).Value = i;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                }

                con.Close();
            }
        }

        public void ConsultaCxc(Pagos p, Contratos cto)
        {
            p.noPagosCxc = 0;

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select COUNT(*) from Pagos where FolioContrato = @Folio and idTippag = 2 and idStatusPago=1 and Cancelado='False' ";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p.noPagosCxc = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }

                con.Close();
            }

            if (p.noPagosCxc > 1)
            {
                ImportePendiente(p,cto, 2, 0);
            }

        }

        public void ConsultaEng(Pagos p)
        {
            p.EngConsec = 0;

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select min(Consec) from Pagos where FolioContrato = @Folio and idTippag = 1 and idStatusPago = 2 and Contrato = 'True' and Cancelado='False' and Saldo>0 ";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p.EngConsec = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }

                con.Close();
            }
        }

        public void PagoCC(Pagos p)//(int folio,int cons,double imp,int formaPago,string noTarj,DateTime fExp,string auto,string noRef)
        {
            string sql = "";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                sql = "insert into Pagos values (@Folio, @Consec, 2, @Importe, @Importe, 0, 0, 0, 0, @Moneda, @FormaPago, @TipoCambio, ";
                sql = p.EsTarjeta == "SI" ? sql + " @NoTarjeta, @Fexpira, @NoAutoriza, " : sql + " null, null, null,";
                sql = sql+" 1, 0, @FPago, 1, 0, 0, null, 'False', '18991230', 0, @NoRef,0, 0, 'True', 0, 'True', @Fref, 0, 'False', 0, null, 'False', 0, 0, @TipoCambio2, 0, null, @idUsrAlt, @FPago, 0, 0, 0, 0)";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@Consec", SqlDbType.Int).Value = p.CCConsec + 1;
                    comando.Parameters.Add("@Importe", SqlDbType.Float).Value = p.Importe;
                    comando.Parameters.Add("@Moneda", SqlDbType.Int).Value = p.idMoneda;
                    comando.Parameters.Add("@FormaPago", SqlDbType.Int).Value = p.idForpag;
                    comando.Parameters.Add("@TipoCambio", SqlDbType.Float).Value = p.TipoCambio;

                    if (p.EsTarjeta == "SI")
                    {
                        comando.Parameters.Add("@NoTarjeta", SqlDbType.VarChar).Value = p.NoTarjeta.Trim();
                        comando.Parameters.Add("@Fexpira", SqlDbType.DateTime).Value = p.FechaExpiracion;
                        comando.Parameters.Add("@NoAutoriza", SqlDbType.VarChar).Value = p.NoAutorizacion;
                    }

                    comando.Parameters.Add("@FPago", SqlDbType.DateTime).Value = p.FechaPago;
                    comando.Parameters.Add("@NoRef", SqlDbType.VarChar).Value = p.Referencia;
                    comando.Parameters.Add("@Fref", SqlDbType.DateTime).Value = p.FechaReferencia;
                    comando.Parameters.Add("@TipoCambio2", SqlDbType.Money).Value = p.TipoCambio2;
                    comando.Parameters.Add("@idUsrAlt", SqlDbType.Int).Value = Sesion.ID;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public void PagoEng(Pagos p, double imp)//(int folio, double imp, double interes, int formaPago, string noTarj, DateTime fExp, string auto, string noRef, double tCambio, int idMoneda, DateTime FRef, DateTime FRec)
        {
            p.MaxConsec(p);
            p.maximoConsec = p.maximoConsec + 1;

            if (p.Importe == imp)
            {  EngUpd(p);       }
            else 
            {  EngIns(p, imp);  }
        }

        private void EngUpd(Pagos p)
        {
            string sql = "";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                sql = "update Pagos set Consec=@Maximo, idMoneda = @Moneda, idForpag = @FormaPago, TipoCambio = @TipoCambio, FechaPago = SYSDATETIME(),"+
                      "idStatusPago = 1, ImporteBase=@Importe, Saldo = 0, Pagado = 'True', TipoCambio2 = @TipoCambio, FechorAlt = SYSDATETIME(),"+
                      "Referencia = @NoRef,  FechaReferencia = @Fref ,FechaRecepcion = @Frecepcion, idUsuarioAlt = @idUsrAlt,  InteresMoratorio = @interes ";
                sql = p.EsTarjeta == "SI" ? sql + ",NoTarjeta = @NoTarjeta, FechaExpiracion = @Fexpira, NoAutorizacion = @NoAutoriza " : "";
                sql = sql + " where FolioContrato = @Folio and Consec = @Consec";


                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@Consec", SqlDbType.Int).Value = p.Consec;
                    comando.Parameters.Add("@Maximo", SqlDbType.Int).Value = p.maximoConsec;
                    comando.Parameters.Add("@Moneda", SqlDbType.Int).Value = p.idMoneda;
                    comando.Parameters.Add("@FormaPago", SqlDbType.Int).Value = p.idForpag;
                    comando.Parameters.Add("@TipoCambio", SqlDbType.Float).Value = p.TipoCambio;
                    comando.Parameters.Add("@Importe", SqlDbType.Float).Value = p.Importe;
                    comando.Parameters.Add("@NoRef", SqlDbType.VarChar).Value = p.Referencia;
                    comando.Parameters.Add("@Fref", SqlDbType.DateTime).Value = p.FechaReferencia;
                    comando.Parameters.Add("@Frecepcion", SqlDbType.DateTime).Value = p.FechaRecepcion;
                    comando.Parameters.Add("@interes", SqlDbType.Float).Value = p.InteresMoratorio;
                    comando.Parameters.Add("@idUsrAlt", SqlDbType.Int).Value = Sesion.ID;

                    if (p.EsTarjeta == "SI")
                    {
                        comando.Parameters.Add("@NoTarjeta", SqlDbType.VarChar).Value = p.NoTarjeta.Trim();
                        comando.Parameters.Add("@Fexpira", SqlDbType.DateTime).Value = p.FechaExpiracion;
                        comando.Parameters.Add("@NoAutoriza", SqlDbType.VarChar).Value = p.NoAutorizacion;
                    }


                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }



        }

        private void EngIns(Pagos p, double imp)
        {
            string sql = "";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                sql = "insert into Pagos values (@Folio, @Consec, 1, @Importe, @Importe, 0, 0, 0, 0, @Moneda, @FormaPago, @TipoCambio,";
                sql = p.EsTarjeta == "SI" ? sql + "@NoTarjeta, @Fexpira, @NoAutoriza," : "null, null, null,";
                sql = sql + "1, 0, SYSDATETIME(), 1, 0, 0, null, 'False', null, 0, @NoRef, 0, 0, 'True', @NoEng, 'True', @Fref, 0, "+
                            "'False', 0, null, 'False', 0, 0, @TipoCambio, 0, @Frecepcion, @idUsrAlt, SYSDATETIME(), 0, @interes, 0, 0)";
               
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@Consec", SqlDbType.Int).Value = p.maximoConsec;
                    comando.Parameters.Add("@Importe", SqlDbType.Float).Value = imp;
                    comando.Parameters.Add("@Moneda", SqlDbType.Int).Value = p.idMoneda;
                    comando.Parameters.Add("@FormaPago", SqlDbType.Int).Value = p.idForpag;
                    comando.Parameters.Add("@TipoCambio", SqlDbType.Float).Value = p.TipoCambio;

                    if (p.EsTarjeta == "SI")
                    {
                        comando.Parameters.Add("@NoTarjeta", SqlDbType.VarChar).Value = p.NoTarjeta.Trim();
                        comando.Parameters.Add("@Fexpira", SqlDbType.DateTime).Value = p.FechaExpiracion;
                        comando.Parameters.Add("@NoAutoriza", SqlDbType.VarChar).Value = p.NoAutorizacion;
                    }

                    comando.Parameters.Add("@NoRef", SqlDbType.VarChar).Value = p.Referencia;
                    comando.Parameters.Add("@NoEng", SqlDbType.Int).Value = p.NoEnganche;
                    comando.Parameters.Add("@Fref", SqlDbType.DateTime).Value = p.FechaReferencia;
                    comando.Parameters.Add("@Frecepcion", SqlDbType.DateTime).Value = p.FechaRecepcion;
                    comando.Parameters.Add("@interes", SqlDbType.Float).Value = p.InteresMoratorio;
                    comando.Parameters.Add("@idUsrAlt", SqlDbType.Int).Value = Sesion.ID;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void UpdPago(Pagos p, string tipo)
        {
            bita.RegistrarBitacora(p.FolioContrato, "Pagos", tipo, "U", "Consec="+p.Consec, "registro movido a la tabla CSharpPagosCC");

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "insert into CSharpPagosCC select*from Pagos where FolioContrato = @Folio and Consec = @Consec";
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@Consec", SqlDbType.Int).Value = p.Consec;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                string sql2 = "delete Pagos where FolioContrato = @Folio and Consec =  @Consec";
                using (SqlCommand comando = new SqlCommand(sql2, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@Consec", SqlDbType.Int).Value = p.Consec;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public void EngContrato(Pagos p)
        {
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                string sql = "update Pagos set Contrato ='True' where FolioContrato = @Folio and NoEnganche = @NoEnganche";

                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {                  
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@NoEnganche", SqlDbType.Int).Value = p.NoEnganche;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }

            UpdPago(p, "EnganchePendiente");

        }

        public void EnganchesDiferidos(Contratos c)
        {
            double EngaPagado = 0;

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql2 = "select SUM(Importe) from Pagos where FolioContrato = @Folio and idTippag = 1 and idStatusPago = 1 and Pagado='True' and Cancelado='False' ";

                using (SqlCommand comando = new SqlCommand(sql2, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EngaPagado = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        }
                    }
                }
                con.Close();
            }

            if (c.EnganchePactado == EngaPagado)
            {
                if (c.Fecprimmen >= DateTime.Today)
                {
                    cm.ModContrato(c, "idStatusCon1",Convert.ToString(c.idStatusCon1),"6"); //PROCESABLE              
                }
                else
                {
                    cm.ModContrato(c, "idStatusCon1", Convert.ToString(c.idStatusCon1), "3"); //MOROSO
                }

            }

        }
            
    }
}
