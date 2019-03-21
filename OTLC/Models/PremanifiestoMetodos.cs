using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class PremanifiestoMetodos
    {
        Conexion cx = new Conexion();

        private void Limpiar(Premanifiesto p)
        {
            p.Folio = 0;
            p.IdSalaVta = 0;
            p.IdHotel = 0;
            p.FechaLlegada = Convert.ToDateTime("01/01/50");
            p.FechaSalida = Convert.ToDateTime("01/01/50");
            p.Noches = 0;
            p.Habitacion = "";
            p.IdTipHab = 0;
            p.IdAgencia = 0;
            p.Nombre1 = "";
            p.Nombre2 = "";
            p.Edad1 = 0;
            p.Edad2 = 0;
            p.IdEdoCivil1 = 0;
            p.IdEdoCivil2 = 0;
            p.IdEspecial = 0;
            p.Idciudad = 0;
            p.IdIdioma = 0;
            p.Prospecto = "";
            p.IdMotNopro = 0;
            p.IdUsuarioNopro = 0;
            p.IdNomolestar = 0;
            p.IdUsuarioNoMol = 0;
            p.Reminder = "";
            p.IdusuarioCapRemi = 0;
            p.FechorCapRemi = Convert.ToDateTime("01/01/50");
            p.Sorry = "";
            p.SorryPromotor = 0;
            p.IdusuarioCapSorry = 0;
            p.FechorCapSorry = Convert.ToDateTime("01/01/50");
            p.GoldCard = "";
            p.FolioGoldCard = 0;
            p.IdPromGold = 0;
            p.IdCapturoGold = 0;
            p.FechorCapGold = Convert.ToDateTime("01/01/50");
            p.Invitado = "";
            p.FechaInv = Convert.ToDateTime("01/01/50");
            p.HoraInv = Convert.ToDateTime("01/01/50");
            p.FolioInv = 0;
            p.Letra = "";
            p.IdLocacion = 0;
            p.IdPromInvito = 0;
            p.NoImpresiones = 0;
            p.idUsuarioImp = 0;
            p.FechorImp = Convert.ToDateTime("01/01/50");
            p.IdCapturoInv = 0;
            p.FechaCapinv = Convert.ToDateTime("01/01/50");
            p.PaxA = 0;
            p.PaxN = 0;
            p.RsInvitado = "";
            p.RsFechaInv = Convert.ToDateTime("01/01/50");
            p.RsHoraInv = Convert.ToDateTime("01/01/50");
            p.RsFolioInv = 0;
            p.RsIdLocacion = 0;
            p.RsIdPromInvito = 0;
            p.RsNoImpresiones = 0;
            p.RsIdUsuarioImp = 0;
            p.RsFechorImp = Convert.ToDateTime("01/01/50");
            p.RsIdCapturoInv = 0;
            p.RsFechaCapInv = Convert.ToDateTime("01/01/50");
            p.Venta = "";
            p.IdTipconA = 0;
            p.NumCtoA = 0;
            p.VentaFeccap = Convert.ToDateTime("01/01/50");
            p.VentaIdUsuarioCap = 0;
            p.Grupo = "";
            p.OrigenCaptura = "";
            p.idTipoGarantia = 0;
            p.Cuenta = "";
            p.IdPrecal = 0;
            p.idPromotorPrecal = 0;
            p.IdLocacionPrecal = 0;
            p.idUsuarioCapPrecal = 0;
            p.FechorCapPrecal = Convert.ToDateTime("01/01/50");
            p.PrimeraVisitaHotel = "";
            p.Email = "";
            p.PrimeraVezAll = "";
            p.IdCelebra = 0;
            p.IdOcupacion = 0;
            p.DebitVisa = "";
            p.DebitMC = "";
            p.CreditVisa = "";
            p.CreditMC = "";
            p.CreditAmex = "";
            p.Actividad1 = "";
            p.Actividad2 = "";
            p.Actividad3 = "";
            p.Actividad4 = "";
            p.Actividad5 = "";
            p.Actividad6 = "";
            p.Actividad7 = "";
            p.Actividad8 = "";
            p.CP = "";
            p.Quemada = 0;
            p.AplicoQuemada = "";
            p.IdHotelQuemada = 0;
            p.QuemadaIdUsuario = 0;
            p.QuemadaFechorCap = Convert.ToDateTime("01/01/50");
            p.TaxiIn = 0;
            p.TaxiOut = 0;
            p.Deposito = 0;
            p.idFormaPagoDepo = 0;
            p.Reembolsado = 0;
            p.idFormaPagoReem = 0;
            p.Bitacora = "";
            p.RegalosEntrega = "";
            p.RegalosCome = "";
            p.Lead = 0;
            p.idCalif = 0;
            p.Show = "";
            p.ShowIn = Convert.ToDateTime("01/01/50");
            p.ShowInFecCap = Convert.ToDateTime("01/01/50");
            p.ShowInIdUsuario = 0;
            p.ShowOut = Convert.ToDateTime("01/01/50");
            p.ShowOutFecCap = Convert.ToDateTime("01/01/50");
            p.ShowOutIdUsuario = 0;
            p.Desayuno = "";
            p.IdCiaInter = 0;
            p.HostesIn = 0;
            p.HostesOut = 0;
            p.InOut = "";
            p.InOutCap = 0;
            p.InOutFecCap = Convert.ToDateTime("01/01/50");
            p.WalkOut = "";
            p.WalkOutCap = 0;
            p.WalkOutFecCap = Convert.ToDateTime("01/01/50");
            p.BeBack = "";
            p.BeBackCap = 0;
            p.BeBackFecCap = Convert.ToDateTime("01/01/50");
            p.WillBeDown = "";
            p.idWillBeDownProm = 0;
            p.WillBeDownCap = 0;
            p.WillBeDownFecCap = Convert.ToDateTime("01/01/50");
            p.Llamadas = "";
            p.idNacionalidad = 0;
            p.NombreReserv = "";
            p.PaisReserv = "";
            p.IdiomaReserv = "";
            p.HoraCheckIn = Convert.ToDateTime("01/01/50");
            p.Preventa = "";
            p.idTipcon = 0;
            p.idTipmem = 0;
            p.Semanas = 0;
            p.SemanasR = 0;
            p.PrecioVenta = 0;
            p.PrecioLIsta = 0;
            p.SemanasLista = 0;
            p.PorEnganchePac = 0;
            p.EnganchePactado = 0;
            p.CCPactado = 0;
            p.Plazo = 0;
            p.TazaInteres = 0;
            p.PreventaAtendida = "";
            p.PreventaFecCap = Convert.ToDateTime("01/01/50");
            p.PreventaIdUsuarioCap = 0;
            p.IdSegmento2 = 0;
            p.Directa = "";
            p.FechaNac1 = Convert.ToDateTime("01/01/50");
            p.FechaNac2 = Convert.ToDateTime("01/01/50");
            p.OtraTarjeta = "";
            p.idOcupacion2 = 0;
            p.SocioIdTipcon = 0;
            p.SocioNumCto = 0;
            p.TipoCambio = 0;
            p.idTipoSocio = 0;
            p.IdUsuarioAlt = 0;
            p.FechaAlta = Convert.ToDateTime("01/01/50");
            p.IdReservaMiniVac = 0;
            p.DownGrade = "";
            p.DownGradeCap = 0;
            p.DownGradeFeccap = Convert.ToDateTime("01/01/50");
            p.BeBack2 = "";
            p.BeBackCap2 = 0;
            p.BeBackFecCap2 = Convert.ToDateTime("01/01/50");
            p.OutPending = "";
            p.OutPendingCap = 0;
            p.OuPendingFecCap = Convert.ToDateTime("01/01/50");
            p.ShowInSala = Convert.ToDateTime("01/01/50");
            p.LinerTourOut = Convert.ToDateTime("01/01/50");
            p.ShowOutSala = Convert.ToDateTime("01/01/50");
            p.CerradorOut = Convert.ToDateTime("01/01/50");
            p.ExitCloserOut = Convert.ToDateTime("01/01/50");
            p.VloTimeIn = Convert.ToDateTime("01/01/50");
            p.IdLinerInvito = 0;
            p.RsIdLinerInvito = 0;
            p.IdPrTaxi = 0;
            p.IdTaxiDescontado = "";
            p.CheckInReserv = Convert.ToDateTime("01/01/50");
            p.SelfGen = false;
            p.NoshowConRegalos = false;
            p.LugarUltimasVacaciones1 = "";
            p.AnioUltimasVacaciones1 = 0;
            p.CostoUltimasVacaciones1 = 0;
            p.LugarUltimasVacaciones2 = "";
            p.AnioUltimasVacaciones2 = 0;
            p.CostoUltimasVacaciones2 = 0;
            p.LugarUltimasVacaciones3 = "";
            p.AnioUltimasVacaciones3 = 0;
            p.CostoUltimasVacaciones3 = 0;
            p.LugarProximasVacaciones1 = "";
            p.AnioProximasVacaciones1 = 0;
            p.CostoProximasVacaciones1 = 0;
            p.LugarProximasVacaciones2 = "";
            p.AnioProximasVacaciones2 = 0;
            p.CostoProximasVacaciones2 = 0;
            p.LugarProximasVacaciones3 = "";
            p.AnioProximasVacaciones3 = 0;
            p.CostoProximasVacaciones3 = 0;
            p.FolioTarjetaReg = 0;
            p.IngresoMensual = 0;
            p.Upgrade = false;
            p.UpgradeCap = 0;
            p.UpgradeFecCap = Convert.ToDateTime("01/01/50");
            p.idHotelAsignado = 0;
            p.Representante = "";
            p.ParejaQuemada = false;
            p.IdDesarrollo = 0;
            p.FolioInvitacionQuemada = 0;
            p.LetraInvitacionQuemada = "";
            p.IdCloserInvito = 0;
            p.RsIdCloserInvito = 0;
            p.SuperSelfgen = false;
        }

        public void LeerPremanifiesto(Premanifiesto p, int Folio)
        {
            Limpiar(p);
            string sql = "select*from Premanifiesto where Folio=@Folio";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                p[reader.GetName(i)] = reader.IsDBNull(i) ? cx.getNullValue(p[reader.GetName(i)]) : reader.GetValue(i);
                            }
                        }
                    }

                    con.Close();
                }
            }
        }
    }
}
