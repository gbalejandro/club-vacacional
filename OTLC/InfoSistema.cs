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
    public partial class InfoSistema : Form
    {
        public InfoSistema()
        {
            InitializeComponent();
            txtversion.Text = "Versión: " + Conexion.version;
            txtFecha.Text = "Fecha: 16 Nov. 2018";
            txtDesarrollador.Text = "Desarrollo";
            txtDpto.Text = "Dpto. Desarrollo";
            txtHotel.Text ="Oasis Hotels &Resorts";
        }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
