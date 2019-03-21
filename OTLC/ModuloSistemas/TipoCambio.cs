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

namespace OTLC
{
    public partial class TipoCambio : Form
    {
        Conexion cx = new Conexion();
        Empresa emp = new Empresa();

        public TipoCambio()
        {
            InitializeComponent();
            permiso();

            TxtIdEmpresa.Text = emp.nomEmpresa;// Convert.ToString("Club Oasis");
        }

        private void permiso()
        {
            if (Sesion.EmpresaMod == false)
            {
                TxtTipCambio.Enabled = false;
                bttnActualizar.Enabled = false;
            }
        }

        // C O N S U L T A   T I P O   D E   C A M B I O
        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            emp.LeerTipoCambio();
            MessageBox.Show("INFORMACION ACTUAL" + System.Environment.NewLine + System.Environment.NewLine

                           + "Fecha: " + DateTime.Today.ToString("d") + System.Environment.NewLine
                          + "Identificador: " + emp.idEmpresa + System.Environment.NewLine
                          + "Empresa: " + emp.nomEmpresa + System.Environment.NewLine
                          + "TipoCambio :" + emp.tipoCambio.ToString("N4"));
        }

        // A C T U A L I Z A   T I P O   D E   C A M B I O        
        private void bttnActualizar_Click(object sender, EventArgs e)
        {
            double tc = Convert.ToDouble( TxtTipCambio.Text);


            if (string.IsNullOrEmpty(TxtTipCambio.Text))
            {
                MessageBox.Show("El campo del tipo de cambio no debe estar vacio.");
            }
            else if (0 >= tc)
            {
                MessageBox.Show("El campo del tipo de cambio debe ser mayor a CERO.");
            }

            else
            {

                emp.ModificarTipoCambio(Convert.ToDouble(TxtTipCambio.Text), emp.idEmpresa);
                TxtTipCambio.Clear();
                emp.LeerTipoCambio();


                MessageBox.Show("A C T U A L I Z A D O" + System.Environment.NewLine + System.Environment.NewLine
                   + "Fecha: " + DateTime.Today.ToString("d") + System.Environment.NewLine
                   + "Identificador: " + emp.idEmpresa + System.Environment.NewLine
                   + "Empresa: " + emp.nomEmpresa + System.Environment.NewLine
                   + "TipoCambio :" + emp.tipoCambio);

            }
        }

        private void TxtTipCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            cx.NumerosConPunto(sender,e,TxtTipCambio);
        }
    }
}
