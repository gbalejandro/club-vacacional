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
using OTLC.Models;

namespace OTLC
{
    public partial class Permisos : Form
    {
        Conexion c = new Conexion();
        llenarComboBox llenar = new llenarComboBox();
        Usuarios usr = new Usuarios();
        Puestos ps = new Puestos();
        Departamentos dpto = new Departamentos(); 
        AsignaPermisos permisos = new AsignaPermisos();
       

        public Permisos()
        {
            InitializeComponent();
            permiso();
            llenar.UsuariosActivos(comboUsuario);   
        }

        private void permiso()
        {
            if (Sesion.AsignarPermisosAcc == false)
            {
                comboUsuario.Enabled = false;
                txtDpto.Enabled = false;
                txtPuesto.Enabled = false;
                txtIniciales.Enabled = false;
                treeView1.Enabled = false;
                radioSelecTodo.Enabled = false;
                radioLimpiar.Enabled = false;
                bttnGRABAR.Enabled = false;
            }
        }

        private void radioSelecTodo_CheckedChanged(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void radioLimpiar_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void comboUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
                        
            usr.LeerUsuario(Convert.ToInt32(comboUsuario.SelectedValue));
            ps.LeerPuestos(usr.IdPuesto);
            dpto.LeerDepartamentos(usr.IdDepto);
            txtDpto.Text = dpto.Nombre;
            txtPuesto.Text = ps.Nombre;
            txtIniciales.Text = usr.Iniciales;

            Limpiar();
            treeView1.CollapseAll();
            permisos.LeerPermisos(Convert.ToInt32(comboUsuario.SelectedValue));

            treeView1.Nodes[0].Checked          = permisos.EmpresaAcc;
            treeView1.Nodes[0].Nodes[0].Checked = permisos.EmpresaMod;
            treeView1.Nodes[1].Checked          = permisos.ContratosAcc;
            treeView1.Nodes[1].Nodes[0].Checked = permisos.ContratosModGeneral;
            treeView1.Nodes[1].Nodes[0].Nodes[0].Checked = permisos.ContratosModStatus1;
            treeView1.Nodes[1].Nodes[1].Checked = permisos.ContratosModTarjetas;
            treeView1.Nodes[1].Nodes[2].Checked = permisos.ContratosModVentas;
            treeView1.Nodes[1].Nodes[3].Checked = permisos.ContratosRep;
            treeView1.Nodes[1].Nodes[4].Checked = permisos.ContratosRegalos;
            treeView1.Nodes[1].Nodes[4].Nodes[0].Checked = permisos.ContratosRegalosRep;
            treeView1.Nodes[1].Nodes[4].Nodes[1].Checked = permisos.ContratosRegalosCat;
            treeView1.Nodes[2].Checked          = permisos.CobranzaAcc;
            treeView1.Nodes[2].Nodes[0].Checked = permisos.CobranzaReestructura;
            treeView1.Nodes[2].Nodes[1].Checked = permisos.CobranzaAplicarPagos;
            treeView1.Nodes[2].Nodes[1].Nodes[0].Checked = permisos.CobranzaPagoCapital;
            treeView1.Nodes[2].Nodes[1].Nodes[1].Checked = permisos.CobranzaPagoContrato;
            treeView1.Nodes[2].Nodes[1].Nodes[2].Checked = permisos.CobranzaPagoEnganche;
            treeView1.Nodes[3].Checked          = permisos.ReservacionesAcc;
            treeView1.Nodes[3].Nodes[0].Checked = permisos.ReservacionesEdoPuntos;
            treeView1.Nodes[3].Nodes[0].Nodes[0].Checked = permisos.ReservacionesMod;
            treeView1.Nodes[3].Nodes[1].Checked = permisos.ReservacionesPtosNuevoAño;
            treeView1.Nodes[3].Nodes[2].Checked = permisos.ReservacionesCumpleaños;
            treeView1.Nodes[3].Nodes[3].Checked = permisos.ReservacionesPorcentajes;
            treeView1.Nodes[4].Checked          = permisos.EstadisticasAcc;
            treeView1.Nodes[4].Nodes[0].Checked = permisos.EstadisticasTablaGralCtos;
            treeView1.Nodes[5].Checked          = permisos.AsignarPermisosAcc;

            treeView1.ExpandAll();
        }

        private void bttnGRABAR_Click(object sender, EventArgs e)
        {
            usr.LeerUsuario(Convert.ToInt32(comboUsuario.SelectedValue));

            permisos.EmpresaAcc                 = treeView1.Nodes[0].Checked;
            permisos.EmpresaMod                 = treeView1.Nodes[0].Nodes[0].Checked;
            permisos.ContratosAcc               = treeView1.Nodes[1].Checked;
            permisos.ContratosModGeneral        = treeView1.Nodes[1].Nodes[0].Checked;
            permisos.ContratosModStatus1        = treeView1.Nodes[1].Nodes[0].Nodes[0].Checked;
            permisos.ContratosModTarjetas       = treeView1.Nodes[1].Nodes[1].Checked; 
            permisos.ContratosModVentas         = treeView1.Nodes[1].Nodes[2].Checked; 
            permisos.ContratosRep               = treeView1.Nodes[1].Nodes[3].Checked;
            permisos.ContratosRegalos           = treeView1.Nodes[1].Nodes[4].Checked;
            permisos.ContratosRegalosRep        = treeView1.Nodes[1].Nodes[4].Nodes[0].Checked;
            permisos.ContratosRegalosCat        = treeView1.Nodes[1].Nodes[4].Nodes[1].Checked;
            permisos.CobranzaAcc                = treeView1.Nodes[2].Checked; 
            permisos.CobranzaReestructura       = treeView1.Nodes[2].Nodes[0].Checked;
            permisos.CobranzaAplicarPagos       = treeView1.Nodes[2].Nodes[1].Checked;
            permisos.CobranzaPagoCapital        = treeView1.Nodes[2].Nodes[1].Nodes[0].Checked;
            permisos.CobranzaPagoContrato       = treeView1.Nodes[2].Nodes[1].Nodes[1].Checked;
            permisos.CobranzaPagoEnganche       = treeView1.Nodes[2].Nodes[1].Nodes[2].Checked;
            permisos.ReservacionesAcc           = treeView1.Nodes[3].Checked;
            permisos.ReservacionesEdoPuntos     = treeView1.Nodes[3].Nodes[0].Checked;
            permisos.ReservacionesMod           = treeView1.Nodes[3].Nodes[0].Nodes[0].Checked;
            permisos.ReservacionesPtosNuevoAño  = treeView1.Nodes[3].Nodes[1].Checked;
            permisos.ReservacionesCumpleaños    = treeView1.Nodes[3].Nodes[2].Checked;
            permisos.ReservacionesPorcentajes   = treeView1.Nodes[3].Nodes[3].Checked;
            permisos.EstadisticasAcc            = treeView1.Nodes[4].Checked;
            permisos.EstadisticasTablaGralCtos  = treeView1.Nodes[4].Nodes[0].Checked;
            permisos.AsignarPermisosAcc         = treeView1.Nodes[5].Checked;

            permisos.GrabarPermisos(usr);



            MessageBox.Show("Los cambios han sido guardados con Éxito");
        }

        private void Limpiar()
        {
            treeView1.Nodes[0].Checked = false;
            treeView1.Nodes[0].Nodes[0].Checked = false;
            treeView1.Nodes[1].Checked = false;
            treeView1.Nodes[1].Nodes[0].Checked = false;
            treeView1.Nodes[1].Nodes[0].Nodes[0].Checked = false;
            treeView1.Nodes[1].Nodes[1].Checked = false;
            treeView1.Nodes[1].Nodes[2].Checked = false;
            treeView1.Nodes[1].Nodes[3].Checked = false;
            treeView1.Nodes[1].Nodes[4].Checked = false;
            treeView1.Nodes[1].Nodes[4].Nodes[0].Checked = false;
            treeView1.Nodes[1].Nodes[4].Nodes[1].Checked = false;
            treeView1.Nodes[2].Checked = false;
            treeView1.Nodes[2].Nodes[0].Checked = false;
            treeView1.Nodes[2].Nodes[1].Checked = false;
            treeView1.Nodes[2].Nodes[1].Nodes[0].Checked = true;
            treeView1.Nodes[2].Nodes[1].Nodes[1].Checked = true;
            treeView1.Nodes[2].Nodes[1].Nodes[2].Checked = true;
            treeView1.Nodes[3].Checked = false;
            treeView1.Nodes[3].Nodes[0].Checked = false;
            treeView1.Nodes[3].Nodes[0].Nodes[0].Checked = false;
            treeView1.Nodes[3].Nodes[1].Checked = false;
            treeView1.Nodes[3].Nodes[2].Checked = false;
            treeView1.Nodes[3].Nodes[3].Checked = false;
            treeView1.Nodes[4].Checked = false;
            treeView1.Nodes[4].Nodes[0].Checked = false;
            treeView1.Nodes[5].Checked = false;
        }

        private void Seleccionar()
        {
            //EMPRESA
            treeView1.Nodes[0].Checked = true;
            treeView1.Nodes[0].Nodes[0].Checked = true;
            //CONTRATOS
            treeView1.Nodes[1].Checked = true;
            treeView1.Nodes[1].Nodes[0].Checked = true;
            treeView1.Nodes[1].Nodes[0].Nodes[0].Checked = true;
            treeView1.Nodes[1].Nodes[1].Checked = true;
            treeView1.Nodes[1].Nodes[2].Checked = true;
            treeView1.Nodes[1].Nodes[3].Checked = true;
            treeView1.Nodes[1].Nodes[4].Checked = true;
            treeView1.Nodes[1].Nodes[4].Nodes[0].Checked = true;
            treeView1.Nodes[1].Nodes[4].Nodes[1].Checked = true;
            //COBRANZA
            treeView1.Nodes[2].Checked = true;
            treeView1.Nodes[2].Nodes[0].Checked = true;
            treeView1.Nodes[2].Nodes[1].Checked = true;
            treeView1.Nodes[2].Nodes[1].Nodes[0].Checked = true;
            treeView1.Nodes[2].Nodes[1].Nodes[1].Checked = true;
            treeView1.Nodes[2].Nodes[1].Nodes[2].Checked = true;
            //RESERVACIONES
            treeView1.Nodes[3].Checked = true;
            treeView1.Nodes[3].Nodes[0].Checked = true;
            treeView1.Nodes[3].Nodes[0].Nodes[0].Checked = true;
            treeView1.Nodes[3].Nodes[1].Checked = true;
            treeView1.Nodes[3].Nodes[2].Checked = true;
            treeView1.Nodes[3].Nodes[3].Checked = true;
            //ESTADISTICAS
            treeView1.Nodes[4].Checked = true;
            treeView1.Nodes[4].Nodes[0].Checked = true;
            //PERMISOS
            treeView1.Nodes[5].Checked = true;
        }

        private void bttncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }



}
