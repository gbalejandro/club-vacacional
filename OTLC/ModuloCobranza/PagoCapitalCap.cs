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
    public partial class PagoCapitalCap : Form
    {
        Conexion cx = new Conexion();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        FormasPago fp = new FormasPago();
        llenarComboBox llenar = new llenarComboBox();
        Fechas fec = new Fechas();
        Calculos cal = new Calculos();
        
        public PagoCapitalCap()
        {
            InitializeComponent();
            permiso();
        }

        public PagoCapitalCap( int Folio)
        {
            InitializeComponent();
            permiso();
            llenar.FormasPago(cboFormaPago);
            cm.Existe = Folio;
            cm.LeerContrato(cto);
            NoTarjetas();
            AsignaValores();
        }

        private void permiso()
        {
            if (Sesion.CobranzaPagoCapital == false)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                bttnGrabar.Enabled = false;
            }
        }

        private void AsignaValores()
        {
            txtNoMensPag.Text = cto.NoMensualidadesPagadas.ToString();
            txtMensPorPag.Text = (cto.Plazo - cto.NoMensualidadesPagadas).ToString();
            txtImpMens.Text = cto.ImporteMensualidad.ToString("N");
            txtFecPago.Text = DateTime.Today.ToString("d");
            txtPlazo.Text = cto.Plazo.ToString();
            txtTazaInteres.Text = cto.TazaInteres.ToString("N");
            txtSaldoCto.Text = cto.Saldo.ToString("N");

            FormaPago();
            EsTarjeta();

            cboDepositado.SelectedIndex = 0;
            cboNoTarjeta.SelectedIndex = 0;
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
            if (Convert.ToString(cboNoTarjeta.SelectedItem) == cto.MFNoTarjeta1)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta1;
                fec.GeneraFecha(cto.MFExpiracion1,1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }
            else if (Convert.ToString(cboNoTarjeta.SelectedItem) == cto.MFNoTarjeta2)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta2;
                fec.GeneraFecha(cto.MFExpiracion2, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }
            else if (Convert.ToString(cboNoTarjeta.SelectedItem) == cto.MFNoTarjeta3)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta3;
                fec.GeneraFecha(cto.MFExpiracion3, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }
            else if (Convert.ToString(cboNoTarjeta.SelectedItem) == cto.MFNoTarjeta4)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta4;
                fec.GeneraFecha(cto.MFExpiracion4, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }
            else if (Convert.ToString(cboNoTarjeta.SelectedItem) == cto.MFNoTarjeta5)
            {
                cboFormaPago.SelectedValue = cto.MFIdTarjeta5;
                fec.GeneraFecha(cto.MFExpiracion5, 1);
                txtFExpMes.Text = fec.NumMes.ToString();
                txtFExpAno.Text = fec.Año.ToString();
            }

        }

        private void cboNoTarjeta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FormaPago();
        }

        private void bttnGrabar_Click(object sender, EventArgs e)
        {         
            if (txtPlazo.Text != "" && txtTazaInteres.Text != "" && txtPagoCapital.Text != "")
            {                
                cal.PagCap = Convert.ToDouble(txtPagoCapital.Text);
                cal.Moneda = cto.idMoneda;
                cal.FormaPago = Convert.ToInt32(cboFormaPago.SelectedValue);
                cal.TipoCambio = cto.TipoCambio;
                cal.NoTarjeta= cboNoTarjeta.SelectedItem.ToString();
                cal.Fexpira = Convert.ToDateTime("01/"+txtFExpMes.Text+"/"+txtFExpAno.Text);
                cal.NoAutoriza = txtNoAuto.Text;
                cal.Fpago = Convert.ToDateTime(txtFecPago.Text);
                cal.NoRef = txtRef.Text;
                cal.Fref = Convert.ToDateTime(cboFRef.Value);

                cal.CalcMensualidad(Convert.ToDouble(txtNuevoSaldo.Text), Convert.ToInt32(txtPlazo.Text), Convert.ToDouble(txtTazaInteres.Text));
                cal.GeneraNuevoSaldo(cto, fp.EsTarjeta);

                this.Hide();
            }
            else
            {
                MessageBox.Show("Los campos: Plazo, Taza Interés y Pago a Capital son obligatorios");
            }
            
        }

        private void calcular()
        {
            if (txtPagoCapital.Text == "")
            {
                txtPagoCapital.Text = "0";
            }

            if (txtTazaInteres.Text == "")
            {
                txtTazaInteres.Text = "0";
            }


            if (txtPlazo.Text == "" || Convert.ToInt32(txtPlazo.Text) <= 0)
            {
                MessageBox.Show("El numero de plazos debe ser mayor a cero");
            }
            else
            {
                txtNuevoSaldo.Text = (cto.Saldo - (Convert.ToDouble(txtPagoCapital.Text))).ToString("N");

                if (txtPagoCapital.Text == "" || Convert.ToDouble(txtPagoCapital.Text) <= 0)
                {
                    cal.CalcMensualidad(Convert.ToDouble(txtSaldoCto.Text), Convert.ToInt16(txtPlazo.Text), Convert.ToDouble(txtTazaInteres.Text));
                }
                else
                {
                    cal.CalcMensualidad(Convert.ToDouble(txtNuevoSaldo.Text), Convert.ToInt16(txtPlazo.Text), Convert.ToDouble(txtTazaInteres.Text));
                }

                txtNuevaMens.Text = cal.NuevaMensualidad.ToString("N");



                if (cto.NoMensualidadesPagadas >= Convert.ToInt32(txtPlazo.Text))
                {
                    txtMensPorPag.Text = txtPlazo.Text;
                }
                else
                {
                    txtMensPorPag.Text = (Convert.ToInt32(txtPlazo.Text) - cto.NoMensualidadesPagadas).ToString();
                }
                    
            }


        }

        private void txtPagoCapital_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.NumerosConPunto(sender,e,txtPagoCapital);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtPagoCapital.Text !="")
                {
                    calcular();
                }
                
            }
        }

        private void txtTazaInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.NumerosConPunto(sender, e, txtTazaInteres);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtTazaInteres.Text != "")
                {
                    calcular();
                }

            }
        }

        private void txtPlazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender, e);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtPlazo.Text != "")
                {
                    calcular();
                }
            }
        }

        private void txtRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender, e);
        }

        private void txtNoAuto_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.SoloNumeros(sender, e);
        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cboFormaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EsTarjeta();
        }

        private void EsTarjeta()
        {
            fp.LeerFormasPago(Convert.ToInt32(cboFormaPago.SelectedValue));

            if (fp.EsTarjeta == "SI")
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

                txtNoAuto.Text = "";

                lblNoTarjeta.Visible = false;
                lblFExpira.Visible = false;
                lblseparador.Visible = false;
                lblNoAutoriza.Visible = false;
            }
        }
    }
}
