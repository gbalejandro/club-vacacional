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
    public partial class Reestructuracion : Form
    {
        Conexion c = new Conexion();
        llenarComboBox llenar = new llenarComboBox();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        Fechas fec = new Fechas();
        Calculos calc = new Calculos();


        public Reestructuracion()
        {
            InitializeComponent();
            permiso();

            llenarCombos();  
        }

        private void permiso()
        {
            if (Sesion.CobranzaReestructura == false)
            {
                 Inhabilitar();
            }
        }

        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            if (string.IsNullOrEmpty(txtNoCon.Text))
            { MessageBox.Show("Debe proporcionar el Numero de Contrato para la busqueda de la información."); }

            else
            {
                cm.Limpiar(cto);
                AsignaValores();

                if (cm.ExisteContrato(Convert.ToInt32(comboTipoCon.SelectedValue), Convert.ToInt32(txtNoCon.Text)) == 0)
                {
                    MessageBox.Show("El contrato " + comboTipoCon.Text + "-" + cto.NumCto + " no existe!");
                }
                else
                {
                    cto.FolioContrato = cm.Existe;
                    cm.LeerContrato(cto);
                    AsignaValores();
                }

            }
        }

        private void AsignaValores()
        {
            txtFolio.Text = cto.FolioContrato.ToString();
            txtLead.Text = cto.Lead.ToString();

            if (cto.FechaVta == Convert.ToDateTime("01/01/50")|| cto.FechaVta == Convert.ToDateTime("01/01/0001"))
            { txtFechaVta.Text = ""; }
            else
            { txtFechaVta.Text = cto.FechaVta.ToString("d"); }

            comboIdioma.SelectedValue = cto.IdIdioma;
            txtStat1.Text = cm.Status1;
            txtStat2.Text = cm.Status2;

            txtNom1.Text = cto.Nombre1;
            txtNom2.Text = cto.Nombre2;

            txtNoMensuaPag.Text = cto.NoMensualidadesPagadas.ToString();
            txtNoMensuaAdel.Text = cto.NoMensualidadesAdelantadas.ToString();

            if (cm.UltimoPago == Convert.ToDateTime("01/01/50")|| cm.UltimoPago == Convert.ToDateTime("01/01/0001"))
            { txtFechaUltPago.Text = ""; }
            else
            { txtFechaUltPago.Text = cm.UltimoPago.ToString("d"); }

            cm.TipCon = comboTipoCon.DisplayMember;


        }

        private void Inhabilitar()
        {
            txtNoCon.Enabled = false;
            bttnConsultar.Enabled = false;
            bttnReest.Enabled = false;
        }

        private void llenarCombos()
        {
            llenar.TipoCon(comboTipoCon);
            llenar.Idioma(comboIdioma);
        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtNoCon_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Consultar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime nuevafecha;
            string fecha;
            int dia;
            int status = 0;

            if (MessageBox.Show("Se llevara acabo un ajuste en las fechas de mensualidad para poner al corriente el contrato; Estatus Actual:" + txtStat1.Text, "Modificar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {              
                dia = cto.FecprimmenActual.Day;

                nuevafecha = DateTime.Today.AddMonths(-cto.NoMensualidadesPagadas);
                fecha =  Convert.ToString(dia)+"/"+ Convert.ToString(nuevafecha.Month)+"/"+Convert.ToString(nuevafecha.Year);
                nuevafecha = Convert.ToDateTime(fecha);

                status = cto.FecprimmenActual >= DateTime.Today ? 2 : 3;

                calc.NuevaFechaPrimMens(nuevafecha, cto.FolioContrato,cto.idStatusCon1,cto.FecprimmenActual, status);

                cm.LeerContrato(cto);
                MessageBox.Show("Se realizo el proceso de reestructuración correctamente");
                AsignaValores();
            }
        }

  
    }
}
