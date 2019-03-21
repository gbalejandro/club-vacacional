using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTLC.Models
{
    class Contratos
    {

        public int FolioContrato { get; set; }
        public int idSalaVta { get; set; }
        public int idTipcon { get; set; }
        public int NumCto { get; set; }
        public int idTipmem { get; set; }
        public DateTime FechaVta { get; set; }
        public int IdIdioma { get; set; }
        public int Lead { get; set; }

        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public int idEdoCivil1 { get; set; }
        public int idEdoCivil2 { get; set; }
        public int idNAcionalidad1 { get; set; }
        public int idNacionalidad2 { get; set; }
        public string SegsocRFC1 { get; set; }
        public string SegsocRFC2 { get; set; }
        public string IdCard1 { get; set; }
        public string idCard2 { get; set; }
        public string Beneficiario1 { get; set; }
        public string Beneficiario2 { get; set; }
        public string RepLegal1 { get; set; }
        public string RepLegal2 { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public int idCiudad1 { get; set; }
        public int idCiudad2 { get; set; }
        public string Cp1 { get; set; }
        public string Cp2 { get; set; }
        public string TelCasa1 { get; set; }
        public string TelCasa2 { get; set; }
        public string TelOficina1 { get; set; }
        public string TelOficina2 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string WebSite1 { get; set; }
        public string WebSite2 { get; set; }

        public int idStatusCon1 { get; set; }
        public int idStatusCon2 { get; set; }
        public int FolioRCI { get; set; }
        public double PrecioLista { get; set; }
        public int SemanasLista { get; set; }
        public double PrecioVenta { get; set; }
        public int Semanas { get; set; }
        public int SemanasR { get; set; }
        public double PorEnganchePac { get; set; }
        public double EnganchePactado { get; set; }
        public double EngancheCobrado { get; set; }
        public double PorEngancheCob { get; set; }
        public double CCPactado { get; set; }
        public double CCCobrado { get; set; }
        public double Saldo { get; set; }
        public int Plazo { get; set; }
        public double TazaInteres { get; set; }
        public double ImporteMensualidad { get; set; }
        public DateTime Fecprimmen { get; set; }
        public DateTime Fecultmen { get; set; }
        public int Vlo { get; set; }

        public string MFNombre1 { get; set; }   //-----> TARJETA 1
        public int MFIdTarjeta1 { get; set; }
        public string MFNoTarjeta1 { get; set; }
        public string MFCodSeg1 { get; set; }
        public DateTime MFExpiracion1 { get; set; }
        public string MFActiva1 { get; set; }
        public string MFNacional1 { get; set; }
        public string MFNombre2 { get; set; }   //-----> TARJETA 2
        public int MFIdTarjeta2 { get; set; }
        public string MFNoTarjeta2 { get; set; }
        public string MFCodSeg2 { get; set; }
        public DateTime MFExpiracion2 { get; set; }
        public string MFActiva2 { get; set; }
        public string MFNacional2 { get; set; }
        public string MFNombre3 { get; set; }   //-----> TARJETA 3
        public int MFIdTarjeta3 { get; set; }
        public string MFNoTarjeta3 { get; set; }
        public string MFCodSeg3 { get; set; }
        public DateTime MFExpiracion3 { get; set; }
        public string MFActiva3 { get; set; }
        public string MFNacional3 { get; set; }
        public string MFNombre4 { get; set; }   //-----> TARJETA 4
        public int MFIdTarjeta4 { get; set; }
        public string MFNoTarjeta4 { get; set; }
        public string MFCodSeg4 { get; set; }
        public DateTime MFExpiracion4 { get; set; }
        public string MFActiva4 { get; set; }
        public string MFNacional4 { get; set; }
        public string MFNombre5 { get; set; }   //-----> TARJETA 5
        public int MFIdTarjeta5 { get; set; }
        public string MFNoTarjeta5 { get; set; }
        public string MFCodSeg5 { get; set; }
        public DateTime MFExpiracion5 { get; set; }
        public string MFActiva5 { get; set; }
        public string MFNacional5 { get; set; }

        public int IdUsuarioAlt { get; set; }
        public DateTime FecCap { get; set; }
        public DateTime FechorAlt { get; set; }
        public DateTime FecCashOut { get; set; }
        public int idMoneda { get; set; }
        public double TipoCambio { get; set; }
        public int FolioPrema { get; set; }
        public int Relacion { get; set; }
        public DateTime FechaProceso { get; set; }
        public DateTime FechaCxl { get; set; }
        public string PagarComision { get; set; }
        public double ImporteUpGrade { get; set; }
        public double ImporteDownGrade { get; set; }
        public double PagadoUpDown { get; set; }
        public string PagadoUpDownAE { get; set; }
        public double PorPagadoUpDown { get; set; }
        public double ImporteDevuelto { get; set; }
        public int idRazonCxl { get; set; }
        public int idTipmemCom { get; set; }
        public double PrecioListaCom { get; set; }
        public int Semliscom { get; set; }
        public double TotalRegInc { get; set; }
        public double TotalRegNoInc { get; set; }

        public double CargoTC1 { get; set; }
        public string MensualidadTC1 { get; set; } //-----> Tarjeta Mensualidad 1
        public double CargoTC2 { get; set; }
        public string MensualidadTC2 { get; set; } //-----> Tarjeta Mensualidad 2
        public double CargoTC3 { get; set; }
        public string MensualidadTC3 { get; set; } //-----> Tarjeta Mensualidad 3
        public double CargoTC4 { get; set; }
        public string MensualidadTC4 { get; set; } //-----> Tarjeta Mensualidad 4

        public double SaldoFinanciado { get; set; }
        public int NoMensualidadesPagadas { get; set; }
        public int NoEnganchesDiferidos { get; set; }
        public int UpGradeTo { get; set; }
        public int UpGradeFrom { get; set; }
        public int DownGradeTo { get; set; }
        public int DownGradeFrom { get; set; }
        public string PeriodoPago2 { get; set; }
        public int idUsuarioCxl { get; set; }
        public DateTime FechaLiquidado { get; set; }
        public DateTime FecprimmenActual { get; set; }
        public int idUsuarioCambia { get; set; }
        public DateTime FecHorCambio { get; set; }
        public string UpGrade { get; set; }
        public string DownGrade { get; set; }
        public int idUsuarioReactiva { get; set; }
        public DateTime FecHorReactiva { get; set; }
        public string CapturoNomina1 { get; set; }
        public string CapturoNomina2 { get; set; }
        public string PagarComisionesFijas100 { get; set; }
        public string PagarComisionesVLO100 { get; set; }
        public string ExcluirVLO { get; set; }
        public string AgregarEnPeriodo { get; set; }
        public string TieneArreglosM { get; set; }
        public int TipoCalculo { get; set; }
        public string AgregarEnPeriodoP { get; set; }
        public int NoMensualidadesAdelantadas { get; set; }
        public int idNegociadoEn { get; set; }
        public string ccCobradoEquity { get; set; }
        public int idStatusCancelado { get; set; }
        public string ConsideraEquity { get; set; }
        public DateTime FechaRecibo { get; set; }
        public string ExcepcionPesos { get; set; }
        public int idTipoPersona { get; set; }
        public string ExcluirAE { get; set; }
        public string ProcesarSEnganche { get; set; }
        public double PrecioVentaUpPesos { get; set; }
        public double PrecioVentaUpDolares { get; set; }
        public int NoPagoAgregado { get; set; }
        public double AgregadoAl { get; set; }
        public int IdTitulo1 { get; set; }
        public int IdTitulo2 { get; set; }
        public int IdFactura { get; set; }

        public bool MFActiva1D { get; set; }//Activa enganche, pestaña de tarjetas //
        public bool MFActiva2D { get; set; }
        public bool MFActiva3D { get; set; }
        public bool MFActiva4D { get; set; }
        public bool MFActiva5D { get; set; }

        public int IdFacturaCxL { get; set; }
        public int Periodicidad { get; set; }

        public string Email12 { get; set; }
        public string Email13 { get; set; }
        public string Email22 { get; set; }
        public string Email23 { get; set; }

        public bool UpGradeSemana { get; set; }
        public string FolioRCI2 { get; set; }
        public string FolioTravelClub { get; set; }
        public bool BeneficioMexicanos { get; set; }
        public string TravelTCFL { get; set; }
        public double TopeProcesableFuturo { get; set; }
        public double ImporteMensualidad2 { get; set; }
        public int idRegion { get; set; }
        public string RealClubDestinos { get; set; }
        public string NoMaestro { get; set; }
        public string NoWally { get; set; }
        public string NoWally2 { get; set; }
        public string FolioInterval { get; set; }
        public string Nombre3 { get; set; }
        public string Nombre4 { get; set; }
        public string NombrePais { get; set; }
        public string NombreEstado { get; set; }
        public string NombreCiudad { get; set; }
        public bool BeneficioViva { get; set; }
        public bool ExcepcionNotificacion { get; set; }

        public string MFNombre6 { get; set; }   //-----> TARJETA 6
        public int MFIdTarjeta6 { get; set; }
        public string MFNoTarjeta6 { get; set; }
        public string MFCodSeg6 { get; set; }
        public DateTime MFExpiracion6 { get; set; }
        public string MFActiva6 { get; set; }
        public string MFNacional6 { get; set; }
        public string MFNombre7 { get; set; }   //-----> TARJETA 7
        public int MFIdTarjeta7 { get; set; }
        public string MFNoTarjeta7 { get; set; }
        public string MFCodSeg7 { get; set; }
        public DateTime MFExpiracion7 { get; set; }
        public string MFActiva7 { get; set; }
        public string MFNacional7 { get; set; }
        public string MFNombre8 { get; set; }   //-----> TARJETA 8
        public int MFIdTarjeta8 { get; set; }
        public string MFNoTarjeta8 { get; set; }
        public string MFCodSeg8 { get; set; }
        public DateTime MFExpiracion8 { get; set; }
        public string MFActiva8 { get; set; }
        public string MFNacional8 { get; set; }
        public double CargoTC5 { get; set; }
        public string MensualidadTC5 { get; set; } //-----> Tarjeta Mensualidad 5
        public double CargoTC6 { get; set; }
        public string MensualidadTC6 { get; set; } //-----> Tarjeta Mensualidad 6
        public double CargoTC7 { get; set; }
        public string MensualidadTC7 { get; set; } //-----> Tarjeta Mensualidad 7
        public double CargoTC8 { get; set; }
        public string MensualidadTC8 { get; set; } //-----> Tarjeta Mensualidad 8

        public DateTime FechaAfiliacionInterval { get; set; }
        public bool TarjetaEnviada { get; set; }
        public string NumGuiaTarjeta { get; set; }
        public DateTime FechaAfiliacionRCI { get; set; }

        public int IdForpagTC1 { get; set; }
        public int IdForpagTC2 { get; set; }
        public int IdForpagTC3 { get; set; }
        public int IdForpagTC4 { get; set; }
        public int IdForpagTC5 { get; set; }
        public int IdForpagTC6 { get; set; }
        public int IdForpagTC7 { get; set; }
        public int IdForpagTC8 { get; set; }
        public bool ConfirmaPerderLoPagado { get; set; }
        public string Nombre1Nombres { get; set; }
        public string Nombre1Apellidos { get; set; }
        public string Nombre2Nombres { get; set; }
        public string Nombre2Apellidos { get; set; }
        public string Nombre3Nombres { get; set; }
        public string Nombre3Apellidos { get; set; }
        public string Nombre4Nombres { get; set; }
        public string Nombre4Apellidos { get; set; }

        public int Edad1 { get; set; }
        public int Edad2 { get; set; }
        public string EdadHijos { get; set; }
        public double IngresoMensual { get; set; }

        
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Contratos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Contratos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

    }
}

