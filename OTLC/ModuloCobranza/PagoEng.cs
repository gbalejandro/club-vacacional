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
    public partial class PagoEng : Form
    {
        Conexion cx = new Conexion();
        Pagos p = new Pagos();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        llenarComboBox llenar = new llenarComboBox();
        FormasPago fp = new FormasPago();
        Empresa tipCam = new Empresa(); //Tipo de cambio del dia

        double pendiente;
        int valida;
        int idMoneda;
        public float EnganchePactado;
        

        public PagoEng()
        {
            InitializeComponent();
            permiso();
        }

        public PagoEng(int folio,int consec)
        {
            InitializeComponent();
            permiso();
            p.FolioContrato = folio;
            p.Consec = consec;
            cm.Existe = folio;
            cm.LeerContrato(cto);

            inicia();
        }

        private void permiso()
        {
            if (Sesion.CobranzaPagoEnganche == false)
            {
                groupBox1.Enabled = false;
                bttnGrabar.Enabled = false;
            }
        }

        private void inicia()
        {
            p.ConsultaPago(p);
            p.ImportePendiente(p,cto, 1, p.NoEnganche);            
            pendiente = p.Importe-p.MontoPagado;
            tipCam.LeerTipoCambio();
            Asigna();
        }

        private void Asigna()
        {
            bttncerrar.Enabled = true;

            txtNum.Text = p.NoEnganche.ToString();
            txtFecRef.Text = p.FechaReferencia.ToString("d");
            txtFecPag.Text =DateTime.Today.ToString("d");
            cboTipPago.SelectedIndex = 0;
            llenar.FormasPago(cboFormaPago);

            txtImporte.Text= pendiente.ToString("N2");
            txtInteres.Text = "0";
            txtTotal.Text = pendiente.ToString("N2");

            txtPendiente.Text = pendiente.ToString("N2");

            llenar.Moneda(cboMoneda);
            txtTipCambio.Text = "1.0000";//p.tipCambio.ToString("N2");
            idMoneda = 2;

            cboFormaPago.SelectedIndex = 0;
            cboDepositado.SelectedIndex = 0;
            cboMoneda.SelectedIndex = 1;

            EsTarjeta();
        }

        private void FechasNulas()
        {   
            if (p.FechaPago == Convert.ToDateTime("01/01/50"))
            { txtFecPag.Text = ""; }

            if (p.FechaReferencia == Convert.ToDateTime("01/01/50"))
            { txtFecRef.Text = ""; }
        }

        private void Limpiar()
        {
            p.ImportePendiente(p,cto, 1, p.NoEnganche);
            pendiente = p.Importe - p.MontoPagado;

            txtPendiente.Text = pendiente.ToString("N2");
            cboFRef.Value = DateTime.Today;
            cboFRecep.Value= DateTime.Today;

            txtImporte.Text = pendiente.ToString("N2");
            txtInteres.Text = "0";
            txtTotal.Text = pendiente.ToString("N2");

            cboFormaPago.SelectedIndex = 0;
            txtNoTarjeta.Text = "";

            txtFExpAno.Text = "";
            txtFExpMes.Text = "";
            txtNoAuto.Text = "";
            txtRef.Text = "";

            EsTarjeta();


            if (p.Importe == p.MontoPagado)
            {
                p.UpdPago(p, "EnganchePendiente");
                PagoTotal(p);
            }
        }

        private void Calcular()
        {
            if (txtImporte.Text == "" || txtImporte.Text == ".")
            {
                txtImporte.Text = "0";
            }

            if (txtInteres.Text == "" || txtInteres.Text == ".")
            {
                txtInteres.Text = "0";
            }

            else
            {
                if (Convert.ToDouble(txtImporte.Text) > 0)
                {
                  txtTotal.Text = (Convert.ToDouble(txtImporte.Text)+Convert.ToDouble(txtInteres.Text)).ToString("N2");
                }
            }

        }

        private void EsTarjeta()
        {
            fp.LeerFormasPago(Convert.ToInt32(cboFormaPago.SelectedValue));

            p.EsTarjeta = fp.EsTarjeta;

            if (p.EsTarjeta == "SI")
            {
                txtNoTarjeta.Visible = true;
                txtFExpMes.Visible = true;
                txtFExpAno.Visible = true;
                txtNoAuto.Visible = true;
                lblNoTarjeta.Visible = true;
                lblFExpira.Visible = true;
                lblseparador.Visible = true;
                lblNoAutoriza.Visible = true;
            }
            else
            {
                txtNoTarjeta.Visible = false;
                txtFExpMes.Visible = false;
                txtFExpAno.Visible = false;
                txtNoAuto.Visible = false;
                lblNoTarjeta.Visible = false;
                lblFExpira.Visible = false;
                lblseparador.Visible = false;
                lblNoAutoriza.Visible = false;
            }

           // cboNoTarjeta.SelectedIndex = 0;
            txtFExpMes.Text = "";
            txtFExpAno.Text = "";
            txtNoAuto.Text = "";
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.NumerosConPunto(sender, e, txtImporte);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtImporte.Text != "")
                {
                    Calcular();
                }
            }
        }

        private void txtInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.NumerosConPunto(sender, e, txtInteres);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtInteres.Text != "")
                {
                    Calcular();
                }

            }

        }

        private void txtFExpMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender,e);
        }

        private void txtFExpAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender, e);
        }

        private void txtNoTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender,e);
        }

        private void cboFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Calcular();
            EsTarjeta();
        }

        private void cboMoneda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtTipCambio.Text = cboMoneda.SelectedIndex == 2 ? tipCam.tipoCambio.ToString("N4") : "1.0000";
            idMoneda          = cboMoneda.SelectedIndex == 2 ? 1 : 2;
        }

        private void bttnGrabar_Click(object sender, EventArgs e)
        {
            Calcular();
            Validar();

            if (valida == 0)
            {
                if (p.Importe >= Convert.ToDouble(txtImporte.Text))
                {

                    if (p.Importe == Convert.ToDouble(txtImporte.Text))
                    {
                        Pagar();
                        PagoTotal(p);
                    }
                    else
                    {
                        Pagar();
                        MessageBox.Show("Se realizo el pago correctamente");
                        Limpiar();
                    }

                }
                else
                { MessageBox.Show("El importe debe ser menor o igual que: " + p.Importe.ToString()); }
            }     
                
        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Validar()
        {
            valida = 0;

            if (p.EsTarjeta == "SI")
            {
                if (txtNoTarjeta.Text == "" || txtFExpMes.Text == "" || txtFExpAno.Text == "" || txtNoAuto.Text =="")
                {
                    valida = 1;
                    MessageBox.Show("Debe proporcionar todos los datos de la Tarjeta: No Tarjeta, Fecha Expiración, No Autorización");
                }
            }

            if (txtImporte.Text == "" || Convert.ToDouble(txtImporte.Text) <= 0)
            {
                valida = 1;
                MessageBox.Show("El valor del Importe debe ser mayor a CERO");
            }

            if (txtInteres.Text == "" || Convert.ToDouble(txtInteres.Text)<0)
            {
                txtInteres.Text = "0";
            }
        }

        private void Pagar()
        {
            p.idMoneda = idMoneda;
            p.idForpag = Convert.ToInt32(cboFormaPago.SelectedValue);
            p.TipoCambio = Convert.ToDouble(txtTipCambio.Text);

            if (p.EsTarjeta == "SI")
            {
                p.NoTarjeta = txtNoTarjeta.Text;
                p.FechaExpiracion = Convert.ToDateTime("01/"+txtFExpMes.Text+"/"+txtFExpAno.Text);
                p.NoAutorizacion = txtNoAuto.Text;
            }

            p.Referencia = txtRef.Text;
            p.FechaReferencia = Convert.ToDateTime(cboFRef.Value);
            p.FechaRecepcion = Convert.ToDateTime(cboFRecep.Value);
            p.InteresMoratorio = Convert.ToDouble(txtInteres.Text);

            p.PagoEng(p,Convert.ToDouble(txtImporte.Text));
        }

        private void PagoTotal(Pagos p)
        {
            p.EnganchesDiferidos(cto);
            MessageBox.Show("Se registro el pago total del importe del enganche correctamente");
            this.Hide();

        }
    }
}
