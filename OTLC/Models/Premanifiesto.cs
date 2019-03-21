using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Premanifiesto
    {

        public int Folio { get; set; }
        public int IdSalaVta { get; set; }
        public int IdHotel { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Noches { get; set; }
        public string Habitacion { get; set; }
        public int IdTipHab { get; set; }
        public int IdAgencia { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public int Edad1 { get; set; }
        public int Edad2 { get; set; }
        public int IdEdoCivil1 { get; set; }
        public int IdEdoCivil2 { get; set; }
        public int IdEspecial { get; set; }
        public int Idciudad { get; set; }
        public int IdIdioma { get; set; }
        public string Prospecto { get; set; }
        public int IdMotNopro { get; set; }
        public int IdUsuarioNopro { get; set; }
        public int IdNomolestar { get; set; }
        public int IdUsuarioNoMol { get; set; }
        public string Reminder { get; set; }
        public int IdusuarioCapRemi { get; set; }
        public DateTime FechorCapRemi { get; set; }
        public string Sorry { get; set; }
        public int SorryPromotor { get; set; }
        public int IdusuarioCapSorry { get; set; }
        public DateTime FechorCapSorry { get; set; }
        public string GoldCard { get; set; }
        public int FolioGoldCard { get; set; }
        public int IdPromGold { get; set; }
        public int IdCapturoGold { get; set; }
        public DateTime FechorCapGold { get; set; }
        public string Invitado { get; set; }
        public DateTime FechaInv { get; set; }
        public DateTime HoraInv { get; set; }
        public int FolioInv { get; set; }
        public string Letra { get; set; }
        public int IdLocacion { get; set; }
        public int IdPromInvito { get; set; }
        public int NoImpresiones { get; set; }
        public int idUsuarioImp { get; set; }
        public DateTime FechorImp { get; set; }
        public int IdCapturoInv { get; set; }
        public DateTime FechaCapinv { get; set; }
        public int PaxA { get; set; }
        public int PaxN { get; set; }
        public string RsInvitado { get; set; }
        public DateTime RsFechaInv { get; set; }
        public DateTime RsHoraInv { get; set; }
        public int RsFolioInv { get; set; }
        public int RsIdLocacion { get; set; }
        public int RsIdPromInvito { get; set; }
        public int RsNoImpresiones { get; set; }
        public int RsIdUsuarioImp { get; set; }
        public DateTime RsFechorImp { get; set; }
        public int RsIdCapturoInv { get; set; }
        public DateTime RsFechaCapInv { get; set; }
        public string Venta { get; set; }
        public int IdTipconA { get; set; }
        public int NumCtoA { get; set; }
        public DateTime VentaFeccap { get; set; }
        public int VentaIdUsuarioCap { get; set; }
        public string Grupo { get; set; }
        public string OrigenCaptura { get; set; }
        public int idTipoGarantia { get; set; }
        public string Cuenta { get; set; }
        public int IdPrecal { get; set; }
        public int idPromotorPrecal { get; set; }
        public int IdLocacionPrecal { get; set; }
        public int idUsuarioCapPrecal { get; set; }
        public DateTime FechorCapPrecal { get; set; }
        public string PrimeraVisitaHotel { get; set; }
        public string Email { get; set; }
        public string PrimeraVezAll { get; set; }
        public int IdCelebra { get; set; }
        public int IdOcupacion { get; set; }
        public string DebitVisa { get; set; }
        public string DebitMC { get; set; }
        public string CreditVisa { get; set; }
        public string CreditMC { get; set; }
        public string CreditAmex { get; set; }
        public string Actividad1 { get; set; }
        public string Actividad2 { get; set; }
        public string Actividad3 { get; set; }
        public string Actividad4 { get; set; }
        public string Actividad5 { get; set; }
        public string Actividad6 { get; set; }
        public string Actividad7 { get; set; }
        public string Actividad8 { get; set; }
        public string CP { get; set; }
        public double Quemada { get; set; }
        public string AplicoQuemada { get; set; }
        public int IdHotelQuemada { get; set; }
        public int QuemadaIdUsuario { get; set; }
        public DateTime QuemadaFechorCap { get; set; }
        public double TaxiIn { get; set; }
        public double TaxiOut { get; set; }
        public double Deposito { get; set; }
        public int idFormaPagoDepo { get; set; }
        public double Reembolsado { get; set; }
        public int idFormaPagoReem { get; set; }
        public string Bitacora { get; set; }
        public string RegalosEntrega { get; set; }
        public string RegalosCome { get; set; }
        public int Lead { get; set; }
        public int idCalif { get; set; }
        public string Show { get; set; }
        public DateTime ShowIn { get; set; }
        public DateTime ShowInFecCap { get; set; }
        public int ShowInIdUsuario { get; set; }
        public DateTime ShowOut { get; set; }
        public DateTime ShowOutFecCap { get; set; }
        public int ShowOutIdUsuario { get; set; }
        public string Desayuno { get; set; }
        public int IdCiaInter { get; set; }
        public int HostesIn { get; set; }
        public int HostesOut { get; set; }
        public string InOut { get; set; }
        public int InOutCap { get; set; }
        public DateTime InOutFecCap { get; set; }
        public string WalkOut { get; set; }
        public int WalkOutCap { get; set; }
        public DateTime WalkOutFecCap { get; set; }
        public string BeBack { get; set; }
        public int BeBackCap { get; set; }
        public DateTime BeBackFecCap { get; set; }
        public string WillBeDown { get; set; }
        public int idWillBeDownProm { get; set; }
        public int WillBeDownCap { get; set; }
        public DateTime WillBeDownFecCap { get; set; }
        public string Llamadas { get; set; }
        public int idNacionalidad { get; set; }
        public string NombreReserv { get; set; }
        public string PaisReserv { get; set; }
        public string IdiomaReserv { get; set; }
        public DateTime HoraCheckIn { get; set; }
        public string Preventa { get; set; }
        public int idTipcon { get; set; }
        public int idTipmem { get; set; }
        public int Semanas { get; set; }
        public int SemanasR { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioLIsta { get; set; }
        public int SemanasLista { get; set; }
        public double PorEnganchePac { get; set; }
        public double EnganchePactado { get; set; }
        public double CCPactado { get; set; }
        public int Plazo { get; set; }
        public double TazaInteres { get; set; }
        public string PreventaAtendida { get; set; }
        public DateTime PreventaFecCap { get; set; }
        public int PreventaIdUsuarioCap { get; set; }
        public int IdSegmento2 { get; set; }
        public string Directa { get; set; }
        public DateTime FechaNac1 { get; set; }
        public DateTime FechaNac2 { get; set; }
        public string OtraTarjeta { get; set; }
        public int idOcupacion2 { get; set; }
        public int SocioIdTipcon { get; set; }
        public int SocioNumCto { get; set; }
        public double TipoCambio { get; set; }
        public int idTipoSocio { get; set; }
        public int IdUsuarioAlt { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdReservaMiniVac { get; set; }
        public string DownGrade { get; set; }
        public int DownGradeCap { get; set; }
        public DateTime DownGradeFeccap { get; set; }
        public string BeBack2 { get; set; }
        public int BeBackCap2 { get; set; }
        public DateTime BeBackFecCap2 { get; set; }
        public string OutPending { get; set; }
        public int OutPendingCap { get; set; }
        public DateTime OuPendingFecCap { get; set; }
        public DateTime ShowInSala { get; set; }
        public DateTime LinerTourOut { get; set; }
        public DateTime ShowOutSala { get; set; }
        public DateTime CerradorOut { get; set; }
        public DateTime ExitCloserOut { get; set; }
        public DateTime VloTimeIn { get; set; }
        public int IdLinerInvito { get; set; }
        public int RsIdLinerInvito { get; set; }
        public int IdPrTaxi { get; set; }
        public string IdTaxiDescontado { get; set; }
        public DateTime CheckInReserv { get; set; }
        public bool SelfGen { get; set; }
        public bool NoshowConRegalos { get; set; }
        public string LugarUltimasVacaciones1 { get; set; }
        public int AnioUltimasVacaciones1 { get; set; }
        public double CostoUltimasVacaciones1 { get; set; }
        public string LugarUltimasVacaciones2 { get; set; }
        public int AnioUltimasVacaciones2 { get; set; }
        public double CostoUltimasVacaciones2 { get; set; }
        public string LugarUltimasVacaciones3 { get; set; }
        public int AnioUltimasVacaciones3 { get; set; }
        public double CostoUltimasVacaciones3 { get; set; }
        public string LugarProximasVacaciones1 { get; set; }
        public int AnioProximasVacaciones1 { get; set; }
        public double CostoProximasVacaciones1 { get; set; }
        public string LugarProximasVacaciones2 { get; set; }
        public int AnioProximasVacaciones2 { get; set; }
        public double CostoProximasVacaciones2 { get; set; }
        public string LugarProximasVacaciones3 { get; set; }
        public int AnioProximasVacaciones3 { get; set; }
        public double CostoProximasVacaciones3 { get; set; }
        public int FolioTarjetaReg { get; set; }
        public decimal IngresoMensual { get; set; }
        public bool Upgrade { get; set; }
        public int UpgradeCap { get; set; }
        public DateTime UpgradeFecCap { get; set; }
        public int idHotelAsignado { get; set; }
        public string Representante { get; set; }
        public bool ParejaQuemada { get; set; }
        public int IdDesarrollo { get; set; }
        public int FolioInvitacionQuemada { get; set; }
        public string LetraInvitacionQuemada { get; set; }
        public int IdCloserInvito { get; set; }
        public int RsIdCloserInvito { get; set; }
        public bool SuperSelfgen { get; set; }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Premanifiesto);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Premanifiesto);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

    }
}
