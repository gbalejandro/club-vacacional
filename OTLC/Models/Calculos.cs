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
    class Calculos
    {
        Conexion cx = new Conexion();
        Bitacora bita = new Bitacora();
        
        public double Cat { get; set; }
        public double CatIva { get; set; }

        public double NuevaMensualidad { get; set; }
        private double Monto { get; set; }
        private int    Plazo { get; set; }
        private double Taza { get; set; }

        //Tabla Pagos
        public int Consec { get; set; }
        public double PagCap { get; set; }
        public int Moneda { get; set; }
        public double TipoCambio { get; set; }
        public string NoTarjeta { get; set; }
        public DateTime Fexpira { get; set; }
        public string NoAutoriza { get; set; }
        public DateTime Fpago { get; set; }
        public string NoRef { get; set; }
        public DateTime Fref { get; set; }
        public int FormaPago { get; set; }

        public string Exit { get; set; }
        private DateTime FProxMens { get; set; }


        public Calculos()
        {
            Cat = 0;
            CatIva = 0;
            NuevaMensualidad = 0;
        }

        public void CalcCat(double interes)        // FORMA CONTRATOS REPORTES
        {
            double inter = 0;
            double cIva = 0;

            inter = (interes / 100) / 12; 

            cIva = (Math.Pow((1 + inter), 12)) - 1;
            CatIva = Math.Round((cIva * 100), 2);

            Cat = Math.Round((CatIva / 1.16), 2);
        }
        
        public void CalcMensualidad(double monto, int plazos, double taza) // FORMA PAGO CAPITAL CAP
        {
            Monto = monto;
            Plazo = plazos;
            Taza = taza;

            double t = ((taza / 100) / 12); 
            double s = (1 + t);
            double i = Math.Pow((s), plazos);
            double y = (1 - (1 / i));
            double x = (monto * t);

            NuevaMensualidad = Math.Round((x/y),2);
        }

        // DETALLE DE CXC
        public void TablaAmortizacion(Contratos c)
        {
            double ImporteCapital = 0;
            double ImporteInteres = 0;

            double interes = (c.TazaInteres / 100) / 12;

            LimpiarTablaAmortizacion();

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
             con.Open();

           //   cal.TablaAmortizacion(cto.Saldo, cto.TazaInteres, cto.ImporteMensualidad, cto.Plazo, cto.FolioContrato);

            for (int i = 1; i <= c.Plazo; i++)
            {
                ImporteInteres = Math.Round((interes * c.Saldo),2);
                ImporteCapital = Math.Round((c.ImporteMensualidad-ImporteInteres),2);
                double saldo   = Math.Round((c.Saldo - ImporteCapital), 2);

                string sql = "insert into TablaAmortizacion values (@FolioContrato,@NoMensualidad ,@ImporteCapital,@ImporteInteres," +
                    "@ImporteMensualidad,@Saldo,@Usr,SYSDATETIME())";

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@FolioContrato", SqlDbType.Int).Value = c.FolioContrato;
                        comando.Parameters.Add("@NoMensualidad", SqlDbType.Int).Value = i;
                        comando.Parameters.Add("@ImporteCapital", SqlDbType.Float).Value = ImporteCapital;
                        comando.Parameters.Add("@ImporteInteres", SqlDbType.Float).Value = ImporteInteres;
                        comando.Parameters.Add("@ImporteMensualidad", SqlDbType.Float).Value = c.ImporteMensualidad;
                        comando.Parameters.Add("@Saldo", SqlDbType.Float).Value = saldo;
                        comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                   
                }
                con.Close();
            }


        }

        public void LimpiarTablaAmortizacion()
        {
            string sql = "Delete TablaAmortizacion where Usr=@Usr";
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public void GeneraNuevoSaldo(Contratos c, string EsTarjeta)
        {
            if (Plazo != c.Plazo)
            { bita.RegistrarBitacora(c.FolioContrato, "Contratos", "Plazo", "U", Convert.ToString(c.Plazo), Convert.ToString(Plazo));  }

            if (Monto != c.Saldo)
            { bita.RegistrarBitacora(c.FolioContrato, "Contratos", "Saldo", "U", Convert.ToString(c.Saldo), Convert.ToString(Monto)); }

            if (Taza != c.TazaInteres)
            { bita.RegistrarBitacora(c.FolioContrato, "Contratos", "TazaInteres", "U", Convert.ToString(c.TazaInteres), Convert.ToString(Taza)); }

            if (NuevaMensualidad != c.ImporteMensualidad)
            { bita.RegistrarBitacora(c.FolioContrato, "Contratos", "ImporteMensualidad", "U", Convert.ToString(c.ImporteMensualidad), Convert.ToString(NuevaMensualidad)); }

            ProxMens(c);

                string sql = "Update Contratos set Saldo=@monto, Plazo=@plazo, TazaInteres=@taza, ImporteMensualidad=@mensua, idStatusCon2=6, Fecprimmen = @Fecha, FecprimmenActual = @Fecha where FolioContrato=@folio";
                using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@monto", SqlDbType.Float).Value = Monto;
                        comando.Parameters.Add("@plazo", SqlDbType.Int).Value = Plazo;
                        comando.Parameters.Add("@taza", SqlDbType.Float).Value = Taza;
                        comando.Parameters.Add("@mensua", SqlDbType.Float).Value = NuevaMensualidad;
                        comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = FProxMens;
                        comando.Parameters.Add("@folio", SqlDbType.Int).Value = c.FolioContrato;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }
            
            GeneraPago(c.FolioContrato,EsTarjeta);

        }
     
        private void ProxMens(Contratos c) // lo manda llamar el procedimiento GeneraNuevoSaldo
        {
            int num = 0;
            string sql = "select sum(PagosCubiertos) proxPago from Pagos where FolioContrato = @Folio and idTippag = 3 and Pagado = 'True' and idStatusPago=1 and Cancelado = 'False'";
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            num = reader.IsDBNull(0)?0: reader.GetInt32(0);
                            FProxMens = reader.IsDBNull(0) ? c.FecprimmenActual: c.FecprimmenActual.AddMonths(num);
                        }
                    }
                }

                con.Close();
            }

            //compara si la mensualidad a pagar es en el mismo mes/año del pago a capital ... se recorre un mes
            FProxMens = (FProxMens.Month == DateTime.Today.Month && FProxMens.Year == DateTime.Today.Year) ? c.FecprimmenActual.AddMonths(1) : c.FecprimmenActual;

        }
      
        private void GeneraPago(int Folio, string EsTarjeta) // lo manda llamar el procedimiento GeneraNuevoSaldo
        {
            consecPago(Folio);

            string sql = "insert into Pagos values (@Folio, @Consec, 10, @PagCap, @PagCap, 0, 0, 0, 0, @Moneda, @FormaPago, @TipoCambio, ";
            sql = EsTarjeta == "SI" ? sql + "@NoTarjeta, @Fexpira, @NoAutoriza, " : sql + "null, null, null, ";
            sql = sql+"1, 0, @FPago, 1, 0, 0, null, null, null, null, @NoRef,0, 0, 'True', 0, 'False', @Fref, 0, 'False', 0, null, 'False', 0, 0, @TipoCambio, 0, null, @idUsrAlt, @FPago, 0, 0, 0, 0)";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
                    comando.Parameters.Add("@Consec", SqlDbType.Int).Value = Consec;
                    comando.Parameters.Add("@PagCap", SqlDbType.Float).Value = PagCap;
                    comando.Parameters.Add("@Moneda", SqlDbType.Int).Value = Moneda;
                    comando.Parameters.Add("@FormaPago", SqlDbType.Int).Value = FormaPago;
                    comando.Parameters.Add("@TipoCambio", SqlDbType.Float).Value = TipoCambio;

                    if (EsTarjeta == "SI")
                    {
                        comando.Parameters.Add("@NoTarjeta", SqlDbType.VarChar).Value = NoTarjeta;
                        comando.Parameters.Add("@Fexpira", SqlDbType.DateTime).Value = Fexpira;
                        comando.Parameters.Add("@NoAutoriza", SqlDbType.VarChar).Value = NoAutoriza;
                    }

                    comando.Parameters.Add("@FPago", SqlDbType.DateTime).Value = Fpago;
                    comando.Parameters.Add("@NoRef", SqlDbType.VarChar).Value = NoRef;
                    comando.Parameters.Add("@Fref", SqlDbType.DateTime).Value = Fref;
                    comando.Parameters.Add("@idUsrAlt", SqlDbType.Int).Value = Sesion.ID;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();

                    con.Close();
                }
            }

            MessageBox.Show("Se realizo el Pago a Capital correctamente");                   
        }
               
        private void consecPago(int Folio) // lo manda llamar el procedimiento GeneraPago
        {
            Consec = 0;
            
            string sql = "select MAX(Consec) from Pagos where FolioContrato=@folio";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@folio", SqlDbType.VarChar).Value = Folio;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Consec = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }
                con.Close();
            }
            Consec = Consec + 1;           
        }

        // FORMA REESTRUECTURACION DE FECHA
        public void NuevaFechaPrimMens(DateTime nuevafecha, int FolioC, int status, DateTime fecPrimAct, int estatus)
        {
            bita.RegistrarBitacora(FolioC, "Contratos", "idStatusCon1", "U", Convert.ToString(status), estatus.ToString());
            bita.RegistrarBitacora(FolioC, "Contratos", "FecprimmenActual", "U", Convert.ToString(fecPrimAct), Convert.ToString(nuevafecha));

            string sql = "Update Contratos set idStatusCon1 = @estatus, Fecprimmen = @Fecha, FecprimmenActual = @Fecha where FolioContrato = @FolioContrato";
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@FolioContrato", SqlDbType.Int).Value = FolioC;
                    comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = nuevafecha;
                    comando.Parameters.Add("@estatus", SqlDbType.Int).Value = estatus;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

    }
}
