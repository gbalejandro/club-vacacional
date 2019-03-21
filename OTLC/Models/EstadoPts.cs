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
using OTLC.Reports;
using OTLC.Models;

namespace OTLC
{
    class EstadoPts
    {
        Conexion cx = new Conexion();
        Bitacora bita = new Bitacora();
        Calculos cal = new Calculos();

        //VARIABLES CALCULABLES
        public double Porcentaje { get; set; }
        public double PtosUsados { get; set; }
        public double PtosPagoCap { get; set; }
        public double PtosDisPagoCap { get; set; }
        public double PtosRestantesTotal { get; set; }

        
        public void Leer(Contratos cto)
        {
                CalculaPorcentaje(cto);            
        }
        //   cal.TablaAmortizacion(cto.Saldo, cto.TazaInteres, cto.ImporteMensualidad, cto.Plazo, cto.FolioContrato);

        public void LimpiarInfo()
        {
            Porcentaje = 0;
            PtosUsados = 0;
            PtosPagoCap = 0;
            PtosDisPagoCap = 0;
            PtosRestantesTotal = 0;
        }

        public void VigenciaMembresia(Contratos c,int anterior, int duracion )
        {
            string ExisteCD="";

            //VERIFICA SI YA EXISTE REGISTRO CON ESE FOLIO DE CONTRATO EN LA TABLA DE CONTRATOS-DURACION
            string sql = "select DISTINCT 'SI' from ContratosDuracion where Folio = @Folio";

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
                            ExisteCD = reader.IsDBNull(0) ? "NO" : reader.GetString(0);
                        }
                    }

                    con.Close();
                }

            }

            //SI YA EXISTE ESE REGISTRO, MODIFICA LA VIGENCIA
            if (ExisteCD == "SI")
            {
                bita.RegistrarBitacora(c.FolioContrato, "ContratosDuracion", "DuracionAños", "U", Convert.ToString(anterior), Convert.ToString(duracion));

                string sqlSI = "Update ContratosDuracion set DuracionAños=@duracion where Folio = @Folio ";

                using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sqlSI, con))
                    {
                        comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;
                        comando.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion;
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }
                    con.Close();
                }

                MessageBox.Show("Modificación realizada con exito!");
            }
            //SI NO EXISTE ESE REGISTRO, LO INSERTA EN LA TABLA CONTRATOS-DURACION
            else
            {
                bita.RegistrarBitacora(c.FolioContrato, "ContratosDuracion", "DuracionAños", "I", "---", Convert.ToString(duracion));

                string sqlNO = "insert into ContratosDuracion values(@Folio,@TipMem,@Duracion,@Usr,SYSDATETIME())";

                using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sqlNO, con))
                    {
                        comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;
                        comando.Parameters.Add("@TipMem", SqlDbType.Int).Value = c.idTipmem;
                        comando.Parameters.Add("@Duracion", SqlDbType.Int).Value = duracion;
                        comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }

                MessageBox.Show("Insercion realizada con exito!");
            }

            LimpiarInfo();
        }

       
        public void CalculaPorcentaje(Contratos c)
        {
            double sumaMensPagadas = 0;
            double sumaOtrosPagos = 0;

            double suma = 0;
            double capital= (c.Saldo+c.EnganchePactado);


            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select sum(ImporteCapital)from PagosEnc where FolioContrato = @Folio and Pagado = 'True'";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sumaMensPagadas = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        }
                    }                
                }


                string sql2 = "selecT sum(Importe) from Pagos where FolioContrato = @Folio and idTippag in (1, 10) and Pagado = 'True' "+
                    "and Cancelado = 'False' and idStatusPago = 1";

                using (SqlCommand comando = new SqlCommand(sql2, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sumaOtrosPagos = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        }
                    }
                }

                con.Close();
            }
          
            suma = sumaMensPagadas + sumaOtrosPagos + c.PagadoUpDown;
            suma = suma * 100;
            Porcentaje = (suma/capital);

            Porcentaje = Math.Round(Porcentaje, 4);

            Porcentaje = Porcentaje > 99 ? 100 : Porcentaje;

        }

        public void CalculaPuntos(Contratos cto)
        {
            CalculaPorcentaje(cto);

            double c = 0;
            c = Porcentaje / 100;
            c = Convert.ToDouble(cto.Semanas) * c;
            c = Math.Truncate(c);

            PtosPagoCap = c;
            PtosDisPagoCap = PtosPagoCap - PtosUsados;
            PtosRestantesTotal = cto.Semanas - PtosUsados;

        }

        public void ReservasEsp(EstadoPtosEsp esp,int Folio)
        {
            EstadoPuntos(1,Folio);

            string sql = "select Reservacion, Puntos, Certificado, Noches, Personas, MesOcupacion from EstadoPuntos where folio = @Folio and idUsr = @idUsr";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
                    comando.Parameters.Add("@idUsr", SqlDbType.Int).Value = Sesion.ID;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable("EstadoPuntos");
                    da.Fill(dt);
                    esp.SetDataSource(dt);
                }

                con.Close();
            }
        }

        public void ReservasIng(EstadoPtosIng ing, int Folio)
        {
            EstadoPuntos(2,Folio);

            string sql = "select Reservacion, Puntos, Certificado, Noches, Personas, MesOcupacion from EstadoPuntos where folio = @Folio and idUsr = @idUsr";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
                    comando.Parameters.Add("@idUsr", SqlDbType.Int).Value = Sesion.ID;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable("EstadoPuntos");
                    da.Fill(dt);
                    ing.SetDataSource(dt);
                }

                con.Close();
            }

        }

        public void ReservasPortu(EstadoPtosPort port, int Folio)
        {
            EstadoPuntos(3,Folio);

            string sql = "select Reservacion, Puntos, Certificado, Noches, Personas, MesOcupacion from EstadoPuntos where folio = @Folio and idUsr = @idUsr";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
                    comando.Parameters.Add("@idUsr", SqlDbType.Int).Value = Sesion.ID;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable("EstadoPuntos");
                    da.Fill(dt);
                    port.SetDataSource(dt);
                }

                con.Close();
            }
        }

        private void EstadoPuntos(int idioma, int Folio)
        {
            LimpiarEstadoPuntos();

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string insert;

                insert = "insert into EstadoPuntos select('";

                if (idioma == 2) {  insert = insert + "Reservation";  } //INGLES 
                else if (idioma == 3) {  insert = insert + "Reserva";      }//PORTUGUES
                else  {  insert = insert + "Reservación";  } //ESPAÑOL          
                  insert = insert + " No. ' + Convert(varchar(50), Confirmacion))Reservacion,(case when UsaCertificado = 1 then  0 else SemanasDescontar end) Puntos," +
                    "(case when Certificado = '' then '";

                if (idioma == 2) { insert = insert + "Not Apply"; } //INGLES 
                else if (idioma == 3) { insert = insert + "Não se aplica"; }//PORTUGUES
                else { insert = insert + "No Aplica"; } //ESPAÑOL

                insert = insert + "' else Certificado end) Certificado,Noches,(Convert(varchar(5), Adultos) + '.' + Convert(varchar(5), Menores1) + '.' + "+
                    "Convert(varchar(5), Menores2)) Personas,CONVERT(varchar(15), month(FechaLlegada)) + '/' + CONVERT(varchar(10), year(FechaLlegada)) " +
                    "'MesOcupacion',@Folio,@idUsr from Reservaciones where FolioContrato = @Folio and Status = 'C' order by FechaLlegada";


                using (SqlCommand comando = new SqlCommand(insert, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
                    comando.Parameters.Add("@idUsr", SqlDbType.Int).Value = Sesion.ID;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }

        }

        public void LimpiarEstadoPuntos()
        {
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))

            {
                con.Open();

                string delete = "delete EstadoPuntos where idUsr=@idUsr";

                using (SqlCommand comando = new SqlCommand(delete, con))
                {
                    comando.Parameters.Add("@idUsr", SqlDbType.Int).Value = Sesion.ID;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }

        }


    }
}
