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
    public partial class contenedor : Form
    {
        llenarComboBox llenar = new llenarComboBox();
        ContratosInfo con = new ContratosInfo();

        public contenedor()
        {
            InitializeComponent();
            permiso();
        }

        private void permiso()
        {
            //PERMISOS CONTRATOS
            if (Sesion.ContratosAcc == false)
            { contratosToolStripMenuItem.Enabled = false; }
            else
            {
                if (Sesion.ContratosMod == false)
                    {modificarInformaciónToolStripMenuItem.Enabled = false; }

                if (Sesion.ContratosRep == false)
                    { documentosToolStripMenuItem.Enabled = false; }
                
                if (Sesion.ContratosRegalos == false)
                { regalosDeVentaToolStripMenuItem.Enabled = false; }
            }

            //PERMISOS COBRANZA
            if (Sesion.CobranzaAcc == false)
            {  cobranzaToolStripMenuItem.Enabled = false; }
            else
            {
                if (Sesion.CobranzaReestructura == false)
                    { reestructuracionToolStripMenuItem.Enabled = false; }
                
                if (Sesion.CobranzaAplicarPagos == false)
                    { pagoACapitalToolStripMenuItem.Enabled = false; }     
            }

            //PERMISOS RESERVACIONES
            if (Sesion.ReservacionesAcc == false)
            { reservacionesToolStripMenuItem.Enabled = false; }
            else
            {
                if (Sesion.ReservacionesEdoPuntos == false)
                { estadoDePuntosToolStripMenuItem.Enabled = false; }

                if (Sesion.ReservacionesCumpleaños == false)
                { listaDeCumpleañosToolStripMenuItem.Enabled = false; }

                if (Sesion.ReservacionesPorcentajes == false)
                { reporteDePorcentajesToolStripMenuItem.Enabled = false; }
            }


            //PERMISOS SISTEMAS
            if (Sesion.AsignarPermisosAcc == false)
            { SistemasToolStripMenuItem.Enabled = false; }
            else
            {
                if (Sesion.EmpresaAcc == false)
                { tipoDeCambioToolStripMenuItem1.Enabled = false; }

                if (Sesion.ReservacionesPtosNuevoAño == false)
                { puntosAplicablesNuevoAñoToolStripMenuItem.Enabled = false; }
            }


            //PERMISOS ESTADISTICAS
            if (Sesion.EstadisticasAcc == false)
            { estadisticasToolStripMenuItem.Enabled = false; }
            else
            {
                if (Sesion.EstadisticasTablaGralCtos == false)
                {
                    estadisticasToolStripMenuItem.Visible = false;
                    interfazDeProducciónToolStripMenuItem.Enabled = false;
                }
            }
        }

        //CONTRATOS
        private void modificarInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContratosInfo con = new ContratosInfo();
            con.ShowDialog();
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContratosReportes cr = new ContratosReportes();
            cr.ShowDialog();
        }

        private void regalosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegalosVenta r = new RegalosVenta();
            r.ShowDialog();
        }


        //COBRANZA
        private void reestructuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Reestructuracion res = new Reestructuracion();
           res.ShowDialog();
        }
        
        private void pagoACapitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PagoCapital pc = new PagoCapital();
            pc.ShowDialog();
        }


        //RESERVACIONES
        private void estadoDePuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstadoPuntos edo = new EstadoPuntos();
            edo.ShowDialog();
        }

        private void listaDeCumpleañosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cumpleaños cumple = new Cumpleaños();
            cumple.ShowDialog();
        }

        private void reporteDePorcentajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Porcentajes por = new Porcentajes();
            por.ShowDialog();
        }

        //SISTEMAS
        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos per = new Permisos();
            per.ShowDialog();
        }

        private void tipoDeCambioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TipoCambio tip = new TipoCambio();
            tip.ShowDialog();
        }

        private void puntosAplicablesNuevoAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Puntos p = new Puntos();
            p.ShowDialog();
        }

        private void interfazDeProducciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Produccion pro = new Produccion();
            pro.ShowDialog();
        }

        private void cambiarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Inicio ini = new Inicio();
            ini.Show();
            this.Hide();
        }

        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoSistema Info = new InfoSistema();
            Info.Show();
        }

        private void tarifarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Puntos p = new Puntos();
            p.ShowDialog();
        }
    }
}
