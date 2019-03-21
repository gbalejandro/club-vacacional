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
    public partial class PagoCC : Form
    {
        Conexion cx = new Conexion();
        Pagos p = new Pagos();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        FormasPago fp = new FormasPago();
        Monedas mon = new Monedas();     
        llenarComboBox llenar = new llenarComboBox();
        Fechas fec = new Fechas();

        double pendiente;
        double acumulado;


        public PagoCC()
        {
            InitializeComponent();
            Permiso();
        }

        public PagoCC(int folio)
        {
            InitializeComponent();
            Permiso();
            p.FolioContrato = folio;
            cm.Existe = folio;
            cm.LeerContrato(cto);
            inicia();      
        }

        private void Permiso()
        {
            if (Sesion.CobranzaPagoContrato == false)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                bttnGrabar.Enabled = false;
            }
        }

        private void inicia()
        {       
            p.Consec = 2;
            p.ConsultaPago(p);           
            p.ImportePendiente(p,cto, 2, 0);
            pendiente = p.CCCobrado - p.MontoPagado;
            acumulado = p.MontoPagado;
            NoTarjetas();
            Asigna();
        }

        private void Asigna()
        { 
            bttncerrar.Enabled = true;
            llenar.FormasPago(cboFormaPago);
            mon.LeerMoneda(p.idMoneda);
            txtNum.Text = p.Consec.ToString();
            txtFecPag.Text = p.FechaPago.ToString("d");
            txtTotal.Text = p.Importe.ToString("N2");
            txtTipCambio.Text = p.TipoCambio.ToString("N2");
            txtMoneda.Text = mon.Nombre;

            txtImporte.Text = "0.00";
            txtPendiente.Text = pendiente.ToString("N2");

            FechasNulas();
            EsTarjeta();

            cboFormaPago.SelectedIndex = 0;
            cboDepositado.SelectedIndex = 0;
        }

        private void FechasNulas()
        {
            if (p.FechaPago == Convert.ToDateTime("01/01/50"))
            { txtFecPag.Text = ""; }
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

        private void cboFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Calcular();
            EsTarjeta();
        }

        private void cboNoTarjeta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FormaPago();
        }

        private void EsTarjeta()
        {
            fp.LeerFormasPago(Convert.ToInt32(cboFormaPago.SelectedValue));

            p.EsTarjeta = fp.EsTarjeta;

            if (p.EsTarjeta == "SI")
            {
                cboNoTarjeta.Visible = true;
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
                cboNoTarjeta.Visible = false;
                txtFExpMes.Visible = false;
                txtFExpAno.Visible = false;
                txtNoAuto.Visible = false;
                lblNoTarjeta.Visible = false;
                lblFExpira.Visible = false;
                lblseparador.Visible = false;
                lblNoAutoriza.Visible = false;
            }

          //  cboNoTarjeta.SelectedIndex = 0;
          //  txtFExpMes.Text = "";
          //  txtFExpAno.Text = "";
          //  txtNoAuto.Text = "";
        }
        private void NoTarjetas()
        {
            int i = 0;

            cboNoTarjeta.Items.Insert(i, "Seleccionar");
            i++;

            if (cto.MFNoTarjeta1 != "")
            {
                cboNoTarjeta.Items.Insert(i, cto.MFNoTarjeta1);
                i++;
            }

            if (cto.MFNoTarjeta2 != "")
            {
                cboNoTarjeta.Items.Insert(i, cto.MFNoTarjeta2);
                i++;
            }

            if (cto.MFNoTarjeta3 != "")
            {
                cboNoTarjeta.Items.Insert(i, cto.MFNoTarjeta3);
                i++;
            }

            if (cto.MFNoTarjeta4 != "")
            {
                cboNoTarjeta.Items.Insert(i, cto.MFNoTarjeta4);
                i++;
            }

            if (cto.MFNoTarjeta5 != "")
            {
                cboNoTarjeta.Items.Insert(i, cto.MFNoTarjeta5);
                i++;
            }          

        }

        private void FormaPago()
        {
            if (cboNoTarjeta.SelectedIndex == 0)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta1;
                p.FechaExpiracion = Convert.ToDateTime("01/01/50");
                txtFExpMes.Text = "";
                txtFExpAno.Text = "";
                txtNoAuto.Text  = "";
            }

            if (cboNoTarjeta.SelectedIndex == 1)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta1;
                p.FechaExpiracion = cto.MFExpiracion1;
                fec.GeneraFecha(cto.MFExpiracion1, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }

            if (cboNoTarjeta.SelectedIndex == 2)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta2;
                p.FechaExpiracion = cto.MFExpiracion2;
                fec.GeneraFecha(cto.MFExpiracion2, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }

            if (cboNoTarjeta.SelectedIndex == 3)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta3;
                p.FechaExpiracion = cto.MFExpiracion3;
                fec.GeneraFecha(cto.MFExpiracion3, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }

            if (cboNoTarjeta.SelectedIndex == 4)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta4;
                p.FechaExpiracion = cto.MFExpiracion4;
                fec.GeneraFecha(cto.MFExpiracion4, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }

            if (cboNoTarjeta.SelectedIndex == 5)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta5;
                p.FechaExpiracion = cto.MFExpiracion5;
                fec.GeneraFecha(cto.MFExpiracion5, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }

        }

        private void Calcular()
        {
            if (txtImporte.Text == "" || txtImporte.Text == ".")
            {
                txtImporte.Text = "0.00";
            }
            else
            {
                if (Convert.ToDouble(txtImporte.Text) > 0)
                {
                    pendiente = p.CCCobrado - Convert.ToDouble(txtImporte.Text)-acumulado;
                    txtPendiente.Text = pendiente.ToString("N2");
                }
            }

        }

        private void Limpiar()
        {
            inicia();

            txtImporte.Text = "";
            cboFormaPago.SelectedIndex = 0;
            cboNoTarjeta.SelectedIndex = 0;
            txtFExpAno.Text = "";
            txtFExpMes.Text = "";
            txtNoAuto.Text = "";
            txtRef.Text = "";

            p.ConsultaCxc(p,cto);

            if (p.CCCobrado == p.MontoPagado && p.CCConsec > 2)
            {

                p.UpdPago(p,"CostoCierreContrato");

                MessageBox.Show("Se registraron los pagos correctamente");
                bttncerrar.Enabled = true;
                this.Hide();
            }
        }

        private void bttnGrabar_Click(object sender, EventArgs e)
        {
            Calcular();

            if (p.EsTarjeta == "SI" && cboNoTarjeta.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar una No. de Tarjeta");
            }
            else
            {
                if (pendiente < 0)
                {
                    MessageBox.Show("Importe sobrepasa el saldo total registrado");
                }
                else
                {
                    if (txtImporte.Text != "" && Convert.ToDouble(txtImporte.Text) > 0)
                    {
                        if (p.CCCobrado > Convert.ToDouble(txtImporte.Text))
                        {
                            Pagar();
                            MessageBox.Show("Se realizo el pago correctamente");
                            Limpiar();
                        }
                        else
                        { MessageBox.Show("El importe debe ser menor que: " + p.CCCobrado.ToString()); }
                    }
                    else
                    { MessageBox.Show("El importe debe ser mayor que CERO"); }
                }
            }
        }

        private void Pagar()
        {
            p.Consecutivos(p, p.CCConsec);           
            p.Importe = Convert.ToDouble(txtImporte.Text);
            p.idForpag = Convert.ToInt32(cboFormaPago.SelectedValue);
            p.Referencia = txtRef.Text;

            if (p.EsTarjeta == "SI")
            {
                p.NoTarjeta = cboNoTarjeta.SelectedItem.ToString();
                p.NoAutorizacion = txtNoAuto.Text;
            }
            else
            {
                p.NoTarjeta = null;
                p.FechaExpiracion = Convert.ToDateTime("01/01/50");
                p.NoAutorizacion = null;
            }

            p.PagoCC(p);

            acumulado = acumulado + Convert.ToDouble(txtImporte.Text);


        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
