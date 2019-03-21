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
using System.Deployment.Application;
using System.Reflection;

namespace OTLC
{
    public partial class Inicio : Form
    {
        Sesion s = new Sesion();
        Empresa emp = new Empresa();
        Sociedad soc = new Sociedad();


        public Inicio()
        {           
            InitializeComponent();
            emp.idEmpresa = 1;
            soc.LeerSociedad();

            this.Text = "OASIS TRAVEL LEISURE CLUB ";
        }

        private void bttnSesion_Click(object sender, EventArgs e)
        {
            InicioSesion();
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                InicioSesion();
            }
        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InicioSesion()
        {
            if (txtUsr.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
            }

            else
            {
                s.VerificarUsuario(txtUsr.Text, txtPwd.Text);

                if (s.existeMeta == true)
                {
                    if (s.existeOtlc == true)
                    {
                        if (Sesion.STATUS == "A")
                        {
                            contenedor con = new contenedor();
                            con.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no esta Activo");
                            txtPwd.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario sin acceso a Modulo de Incidencias");
                        txtPwd.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no existe");
                    txtPwd.Text = "";
                }             
            }
        }
    }
}
