using OTLC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTLC
{
    public partial class PagoDetalle : Form
    {
        Pagos p = new Pagos();
        TiposPago tp = new TiposPago();
        FormasPago fp = new FormasPago();
        LugaresPago lp = new LugaresPago();
        Usuarios usr = new Usuarios();

        public PagoDetalle()
        {
            InitializeComponent();
        }

        public PagoDetalle(int folio, int consec)
        {
            InitializeComponent();
            Limpiar();
            p.FolioContrato = folio;
            p.Consec = consec;
            p.ConsultaPago(p);
            Asignar();
        }

        private void Asignar()
        {
            tp.LeerTiposPago(p.idTippag);
            fp.LeerFormasPago(p.idForpag);
            usr.LeerUsuario(p.idUsuarioAlt);

            txtNum.Text = p.Consec.ToString();
            txtFecPag.Text = p.FechaPago.ToString("d");
            txtFecVenc.Text = p.FechaReferencia.ToString("d");
            txtTipPag.Text = tp.Nombre;
            txtFormPag.Text = fp.Nombre;
            txtNoTarj.Text = p.NoTarjeta;
            txtFecExp.Text = p.FechaExpiracion.ToString("d");
            txtNoAut.Text = p.NoAutorizacion;
            txtImp.Text = p.ImporteBase.ToString("N2");
            txtDescCap.Text = p.PorDsctoCapital.ToString("N6");
            txtDescInt.Text = p.PorDsctoInteres.ToString("N6");
            txtImpDesCap.Text = p.ImporteDsctoCapital.ToString("N2");
            txtImpDesInt.Text = p.ImporteDsctoInteres.ToString("N2");
            txtTotal.Text = p.Importe.ToString("N2");
            txtIntMor.Text = p.InteresMoratorio.ToString("N2");
            txtTotPag.Text = p.TotalPagado.ToString("N2");
            txtTipCambio.Text = p.TipoCambio.ToString("N2");
            txtRef.Text = p.Referencia;
            txtDepos.Text = lp.Nombre;
            txtUsrAlt.Text = usr.Nombre;
            txtFecAlt.Text = p.FechorAlt.ToString("d");
            txtNoEng.Text = p.NoEnganche.ToString();
            txtNoMens.Text = p.NoMensualidad.ToString();
            txtFecRecep.Text = p.FechaRecepcion.ToString("d");

            FechasNulas();
        }

        private void Limpiar()
        {
            txtNum.Text = "";
            txtFecPag.Text = "";
            txtFecVenc.Text = "";
            txtTipPag.Text = "";
            txtFormPag.Text = "";
            txtNoTarj.Text = "";
            txtFecExp.Text = "";
            txtNoAut.Text = "";
            txtImp.Text = "";
            txtDescCap.Text = "";
            txtDescInt.Text = "";
            txtImpDesCap.Text = "";
            txtImpDesInt.Text = "";
            txtTotal.Text = "";
            txtIntMor.Text = "";
            txtTotPag.Text = "";
            txtTipCambio.Text = "";
            txtRef.Text = "";
            txtDepos.Text = "";
            txtUsrAlt.Text = "";
            txtFecAlt.Text = "";
            txtNoEng.Text = "";
            txtNoMens.Text = "";
            txtFecRecep.Text = "";
        }

        private void FechasNulas()
        {
            if (p.FechaPago == Convert.ToDateTime("01/01/50"))
            {   txtFecPag.Text = "";   }

            if (p.FechaReferencia == Convert.ToDateTime("01/01/50"))
            { txtFecVenc.Text = ""; }

            if (p.FechaExpiracion == Convert.ToDateTime("01/01/50"))
            { txtFecExp.Text = ""; }

            if (p.FechorAlt == Convert.ToDateTime("01/01/50"))
            { txtFecAlt.Text = ""; }

            if (p.FechaRecepcion == Convert.ToDateTime("01/01/50"))
            { txtFecRecep.Text = ""; }
        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



    }
}
