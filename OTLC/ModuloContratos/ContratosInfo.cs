using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OTLC.Models;
using System.Data.SqlClient;

namespace OTLC
{
    public partial class ContratosInfo : Form
    {
        Conexion c = new Conexion();
        llenarComboBox llenar = new llenarComboBox();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        Fechas fec = new Fechas();

        public ContratosInfo()
        {
            InitializeComponent();
            permiso();
            Inhabilitar();  
            llenarCombos();
            comboModStat1.SelectedValue = 0;
        }

        private void permiso()
        {
            if (Sesion.ContratosModGeneral == false)
            {
                Inhabilitar();
                txtModLead.Enabled = false;
                comboModStat1.Enabled = false;
                comboModStat2.Enabled = false;
                bttnGRABAR.Visible = false;
            }
            if (Sesion.ContratosModTarjetas == false)
            {
                InhabilitarTarjetas();
                bttnTarjetas.Visible = false;
            }
            if (Sesion.ContratosModVentas == false)
            {
                //InhabilitarVentas();
            }
            if (Sesion.ContratosModStatus1 == false)
            {
                comboModStat1.Enabled = false;
            }
        }

        private void Consultar()
        {
            if (string.IsNullOrEmpty(txtNoCon.Text))
            { MessageBox.Show("Debe proporcionar el Numero de Contrato para la busqueda de la información."); }

            else
            {
                Cursor.Current = Cursors.WaitCursor;
                cm.Limpiar(cto);
                AsignaValores();

                if (cm.ExisteContrato(Convert.ToInt32(comboTipoCon.SelectedValue),Convert.ToInt32(txtNoCon.Text)) == 0)
                {
                    bttnGRABAR.Enabled = false;
                    MessageBox.Show("El contrato " + comboTipoCon.Text + "-" + cto.NumCto + " no existe!");
                }
                else
                {
                    cm.LeerContrato(cto);
                    AsignaValores();
                    bttnGRABAR.Enabled = true;
                }

                Cursor.Current = Cursors.Default;
            }

        }

        private void txtNoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Consultar();
            }
        }

        private void txtModLead_KeyPress(object sender, KeyPressEventArgs e)

        {
            c.SoloNumeros(sender, e);
        }

        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void bttnGRABAR_Click(object sender, EventArgs e)
        {
            if (cto.TipoCambio != 0)
            {
                if (cto.idStatusCon1 != Convert.ToInt32(comboModStat1.SelectedValue))
                {
                    if (MessageBox.Show("Actualizar: ESTATUS CONTRATO: " + txtStat1.Text + " por: " + comboModStat1.Text, "Modificar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cm.ModContrato(cto, "idStatusCon1", Convert.ToString(cto.idStatusCon1), Convert.ToString(comboModStat1.SelectedValue));
                        Ejecutar("ESTATUS CONTRATO");
                    }
                }

                if (cto.idStatusCon2 != Convert.ToInt32(comboModStat2.SelectedValue))
                {
                    if (MessageBox.Show("Actualizar: ESTATUS PROCESO: " + txtStat2.Text + " por: " + comboModStat2.Text, "Modificar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cm.ModContrato(cto, "idStatusCon2", Convert.ToString(cto.idStatusCon2), Convert.ToString(comboModStat2.SelectedValue));
                        Ejecutar("ESTATUS PROCESO");
                    }
                }

                if (txtModLead.Text != "" && Convert.ToInt32(txtModLead.Text)>0)
                {
                    if (cto.Lead != Convert.ToInt32(txtModLead.Text))
                    {
                        //Existe en la tabla de Premanifiesto
                        if (cm.ExisteLeadEnPrema(Convert.ToInt32(txtModLead.Text)) > 0)//"SI")
                        {
                            // Esta asignado en la tabla de contratos
                            if (cm.VerificaLead(Convert.ToInt32(txtModLead.Text)) == 0)//"NO")
                            {
                                if (MessageBox.Show("Actualizar: LEAD: " + txtLead.Text + " por: " + txtModLead.Text, "Modificar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    cm.ModContrato(cto, "Lead", Convert.ToString(cto.Lead), Convert.ToString(txtModLead.Text));
                                    cm.ModContrato(cto, "FolioPrema", Convert.ToString(cto.FolioPrema), Convert.ToString(txtModLead.Text));
                                    Ejecutar("LEAD");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El LEAD: " + txtModLead.Text + " ya esta asignado a un Contrato");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El LEAD: " + txtModLead.Text + " no existe en el sistema (Premanifiesto)");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El valor del campo LEAD: " + txtModLead.Text + " debe ser mayor que CERO");
                }
            }
        }

        private void Ejecutar(string campo)
        {
            cm.LeerContrato(cto);
            MessageBox.Show("Registro "+campo+" modificado correctamente");
            AsignaValores();
        }

        private void bttnTarjetas_Click(object sender, EventArgs e)
        {
            
            if (cto.TipoCambio != 0)
            {
                if (MessageBox.Show("Se actualizara la información, ¿Continuar?", "Modificar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModificaCampos();
                }
                cm.LeerContrato(cto);
                AsignaValores();
            }
        }

        private void ModificaCampos()
        {
            string mod = "NO";

            //TARJETA 1
            if (cto.MFNombre1 != txtTNombre1.Text)
            {   mod = "SI"; cm.ModContrato(cto,"MFNombre1",cto.MFNombre1, txtTNombre1.Text);  }

            if (cto.MFNoTarjeta1 != txtNum1.Text)
            {   mod = "SI"; cm.ModContrato(cto,"MFNoTarjeta1",cto.MFNoTarjeta1, txtNum1.Text); }

            if (cto.MFIdTarjeta1 != Convert.ToInt32(cbTipo1.SelectedValue))
            {   mod = "SI"; cm.ModContrato(cto,"MFIdTarjeta1", Convert.ToString(cto.MFIdTarjeta1),Convert.ToString(cbTipo1.SelectedValue));   }

            if (cto.MFCodSeg1 != txtCodigo1.Text)
            {   mod = "SI"; cm.ModContrato(cto, "MFCodSeg1", cto.MFCodSeg1, txtCodigo1.Text);  }

            if (txtExpMes1.Text != "" && txtExpAno1.Text != "")
            {
                if (cto.MFExpiracion1!=Convert.ToDateTime("01/"+ txtExpMes1.Text + "/" + txtExpAno1.Text))
                {  mod = "SI";  cm.ModContrato(cto, "MFExpiracion1", Convert.ToString(cto.MFExpiracion1), "01/" + txtExpMes1.Text + "/" + txtExpAno1.Text);   }
            }
            else
            {
                if (cto.MFExpiracion1 != Convert.ToDateTime("01/01/50") || cto.MFExpiracion1 == Convert.ToDateTime("01/01/0001"))
                {  mod = "SI"; cm.ModContrato(cto, "MFExpiracion1", Convert.ToString(cto.MFExpiracion1), "");    }
            }
                      
            if (cto.MFActiva1 != Convert.ToString(chActiva1.Checked))
            {   mod = "SI"; cm.ModContrato(cto, "MFActiva1", cto.MFActiva1, Convert.ToString(chActiva1.Checked));  }

            if (cto.MFNacional1 != Convert.ToString(chNacional1.Checked))
            {   mod = "SI"; cm.ModContrato(cto,"MFNacional1",cto.MFNacional1,Convert.ToString(chNacional1.Checked));  }

            // TARJETA 2
            if (cto.MFNombre2 != txtTNombre2.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNombre2", cto.MFNombre2, txtTNombre2.Text); }

            if (cto.MFNoTarjeta2 != txtNum2.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNoTarjeta2", cto.MFNoTarjeta2, txtNum2.Text); }

            if (cto.MFIdTarjeta2 != Convert.ToInt32(cbTipo2.SelectedValue))
            { mod = "SI"; cm.ModContrato(cto, "MFIdTarjeta2", Convert.ToString(cto.MFIdTarjeta2), Convert.ToString(cbTipo2.SelectedValue)); }

            if (cto.MFCodSeg2 != txtCodigo2.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFCodSeg2", cto.MFCodSeg2, txtCodigo2.Text); }

            if (txtExpMes2.Text != "" && txtExpAno2.Text != "")
            {
                if (cto.MFExpiracion2 != Convert.ToDateTime("01/" + txtExpMes2.Text + "/" + txtExpAno2.Text))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion2", Convert.ToString(cto.MFExpiracion2), "01/" + txtExpMes2.Text + "/" + txtExpAno2.Text); }
            }
            else
            {
                if (cto.MFExpiracion2 != Convert.ToDateTime("01/01/50") || cto.MFExpiracion2 == Convert.ToDateTime("01/01/0001"))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion2", Convert.ToString(cto.MFExpiracion2), ""); }
            }

            if (cto.MFActiva2 != Convert.ToString(chActiva2.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFActiva2", cto.MFActiva2, Convert.ToString(chActiva2.Checked)); }

            if (cto.MFNacional2 != Convert.ToString(chNacional2.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFNacional2", cto.MFNacional2, Convert.ToString(chNacional2.Checked)); }

            // TARJETA 3

            if (cto.MFNombre3 != txtTNombre3.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNombre3", cto.MFNombre3, txtTNombre3.Text); }

            if (cto.MFNoTarjeta3 != txtNum3.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNoTarjeta3", cto.MFNoTarjeta3, txtNum3.Text); }

            if (cto.MFIdTarjeta3 != Convert.ToInt32(cbTipo3.SelectedValue))
            { mod = "SI"; cm.ModContrato(cto, "MFIdTarjeta3", Convert.ToString(cto.MFIdTarjeta3), Convert.ToString(cbTipo3.SelectedValue)); }

            if (cto.MFCodSeg3 != txtCodigo3.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFCodSeg3", cto.MFCodSeg3, txtCodigo3.Text); }

            if (txtExpMes3.Text != "" && txtExpAno3.Text != "")
            {
                if (cto.MFExpiracion3 != Convert.ToDateTime("01/" + txtExpMes3.Text + "/" + txtExpAno3.Text))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion3", Convert.ToString(cto.MFExpiracion3), "01/" + txtExpMes3.Text + "/" + txtExpAno3.Text); }
            }
            else
            {
                if (cto.MFExpiracion3 != Convert.ToDateTime("01/01/50") || cto.MFExpiracion3 == Convert.ToDateTime("01/01/0001"))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion3", Convert.ToString(cto.MFExpiracion3), ""); }
            }

            if (cto.MFActiva3 != Convert.ToString(chActiva3.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFActiva3", cto.MFActiva3, Convert.ToString(chActiva3.Checked)); }

            if (cto.MFNacional3 != Convert.ToString(chNacional3.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFNacional3", cto.MFNacional3, Convert.ToString(chNacional3.Checked)); }

            // TARJETA 4
            if (cto.MFNombre4 != txtTNombre4.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNombre4", cto.MFNombre4, txtTNombre4.Text); }

            if (cto.MFNoTarjeta4 != txtNum4.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNoTarjeta4", cto.MFNoTarjeta4, txtNum4.Text); }

            if (cto.MFIdTarjeta4 != Convert.ToInt32(cbTipo4.SelectedValue))
            { mod = "SI"; cm.ModContrato(cto, "MFIdTarjeta4", Convert.ToString(cto.MFIdTarjeta4), Convert.ToString(cbTipo4.SelectedValue)); }

            if (cto.MFCodSeg4 != txtCodigo4.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFCodSeg1", cto.MFCodSeg4, txtCodigo4.Text); }

            if (txtExpMes4.Text != "" && txtExpAno4.Text != "")
            {
                if (cto.MFExpiracion4 != Convert.ToDateTime("01/" + txtExpMes4.Text + "/" + txtExpAno4.Text))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion4", Convert.ToString(cto.MFExpiracion4), "01/" + txtExpMes4.Text + "/" + txtExpAno4.Text); }
            }
            else
            {
                if (cto.MFExpiracion4 != Convert.ToDateTime("01/01/50") || cto.MFExpiracion4 == Convert.ToDateTime("01/01/0001"))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion4", Convert.ToString(cto.MFExpiracion4), ""); }
            }

            if (cto.MFActiva4 != Convert.ToString(chActiva4.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFActiva4", cto.MFActiva4, Convert.ToString(chActiva4.Checked)); }

            if (cto.MFNacional4 != Convert.ToString(chNacional4.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFNacional4", cto.MFNacional4, Convert.ToString(chNacional4.Checked)); }


            // TARJETA 5
            if (cto.MFNombre5 != txtTNombre5.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNombre5", cto.MFNombre5, txtTNombre5.Text); }

            if (cto.MFNoTarjeta5 != txtNum5.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFNoTarjeta5", cto.MFNoTarjeta5, txtNum5.Text); }

            if (cto.MFIdTarjeta5 != Convert.ToInt32(cbTipo5.SelectedValue))
            { mod = "SI"; cm.ModContrato(cto, "MFIdTarjeta5", Convert.ToString(cto.MFIdTarjeta5), Convert.ToString(cbTipo5.SelectedValue)); }

            if (cto.MFCodSeg5 != txtCodigo5.Text)
            { mod = "SI"; cm.ModContrato(cto, "MFCodSeg5", cto.MFCodSeg5, txtCodigo5.Text); }


            if (txtExpMes5.Text != "" && txtExpAno5.Text != "")
            {
                if (cto.MFExpiracion5 != Convert.ToDateTime("01/" + txtExpMes5.Text + "/" + txtExpAno5.Text))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion5", Convert.ToString(cto.MFExpiracion5), "01/" + txtExpMes5.Text + "/" + txtExpAno5.Text); }
            }
            else
            {
                if (cto.MFExpiracion5 != Convert.ToDateTime("01/01/50") || cto.MFExpiracion5 == Convert.ToDateTime("01/01/0001"))
                { mod = "SI"; cm.ModContrato(cto, "MFExpiracion5", Convert.ToString(cto.MFExpiracion5), ""); }
            }

            if (cto.MFActiva5 != Convert.ToString(chActiva5.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFActiva5", cto.MFActiva5, Convert.ToString(chActiva5.Checked)); }

            if (cto.MFNacional5 != Convert.ToString(chNacional5.Checked))
            { mod = "SI"; cm.ModContrato(cto, "MFNacional5", cto.MFNacional5, Convert.ToString(chNacional5.Checked)); }


            // MENSUALIDAD 1
            if (cto.CargoTC1 != Convert.ToDouble(txtImp1.Text))
            {
                mod = "SI";
                if (Convert.ToDouble(txtImp1.Text) == 0)
                { txtImp1.Text = ""; }
                cm.ModContrato(cto, "CargoTC1", Convert.ToString(cto.CargoTC1), txtImp1.Text);
            }

            if (cto.MensualidadTC1 != comboNumT1.SelectedItem.ToString())
            {   mod = "SI"; cm.ModContrato(cto, "MensualidadTC1", cto.MensualidadTC1, comboNumT1.SelectedItem.ToString());    }

            // MENSUALIDAD 2
            if (cto.CargoTC2 != Convert.ToDouble(txtImp2.Text))
            {
                mod = "SI";
                if (Convert.ToDouble(txtImp2.Text) == 0)
                { txtImp2.Text = ""; }
                cm.ModContrato(cto, "CargoTC2", Convert.ToString(cto.CargoTC2), txtImp2.Text); 
            }

            if (cto.MensualidadTC2 != comboNumT2.SelectedItem.ToString())
            { mod = "SI"; cm.ModContrato(cto, "MensualidadTC2", cto.MensualidadTC2, comboNumT2.SelectedItem.ToString()); }

            // MENSUALIDAD 3
            if (cto.CargoTC3 != Convert.ToDouble(txtImp3.Text))
            {
                mod = "SI";
                if (Convert.ToDouble(txtImp3.Text) == 0)
                { txtImp3.Text = ""; }
                cm.ModContrato(cto, "CargoTC3", Convert.ToString(cto.CargoTC3), txtImp3.Text); 
            }

            if (cto.MensualidadTC3 != comboNumT3.SelectedItem.ToString())
            { mod = "SI"; cm.ModContrato(cto, "MensualidadTC3", cto.MensualidadTC3, comboNumT3.SelectedItem.ToString()); }

            // MENSUALIDAD 4
            if (cto.CargoTC4 != Convert.ToDouble(txtImp4.Text))
            {
                mod = "SI";
                if (Convert.ToDouble(txtImp4.Text) == 0)
                { txtImp4.Text = ""; }
                cm.ModContrato(cto, "CargoTC4", Convert.ToString(cto.CargoTC4), txtImp4.Text); 
            }

            if (cto.MensualidadTC4 != comboNumT4.SelectedItem.ToString())
            { mod = "SI"; cm.ModContrato(cto, "MensualidadTC4", cto.MensualidadTC4, comboNumT4.SelectedItem.ToString()); }


            if (mod == "SI")
            {  MessageBox.Show("Información actualizada correctamente"); }

        }

        private void AsignaValores()
        {
            txtTipCam.Text = cto.TipoCambio.ToString("N4");            
            txtFolio.Text = cto.FolioContrato.ToString();
            txtLead.Text = cto.Lead.ToString();
            txtNom1.Text = cto.Nombre1.ToString();
            txtNom2.Text = cto.Nombre2.ToString();
            txtRfc1.Text = cto.SegsocRFC1.ToString();
            txtRfc2.Text = cto.SegsocRFC2.ToString();
            txtCard1.Text = cto.IdCard1.ToString();
            txtCard2.Text = cto.idCard2.ToString();
            txtBenef1.Text = cto.Beneficiario1.ToString();
            txtBenef2.Text = cto.Beneficiario2.ToString();
            txtRepLeg1.Text = cto.RepLegal1.ToString();
            txtRepLeg2.Text = cto.RepLegal2.ToString();
            txtDir1.Text = cto.Direccion1.ToString();
            txtDir2.Text = cto.Direccion2.ToString();
            txtCp1.Text = cto.Cp1.ToString();
            txtCp2.Text = cto.Cp2.ToString();
            txtTelCasa1.Text = cto.TelCasa1.ToString();
            txtTelCasa2.Text = cto.TelCasa2.ToString();
            txtTelOfic1.Text = cto.TelOficina1.ToString();
            txtTelOfic2.Text = cto.TelOficina2.ToString();
            txtFax1.Text = cto.Fax1.ToString();
            txtFax2.Text = cto.Fax2.ToString();
            txtCel1.Text = cto.Celular1.ToString();
            txtCel2.Text = cto.Celular2.ToString();
            txtCorreo1.Text = cto.Email1.ToString();
            txtCorreo2.Text = cto.Email2.ToString();
            txtWeb1.Text = cto.WebSite1.ToString();
            txtWeb2.Text = cto.WebSite2.ToString();
            txtTipCalc.Text = cm.TipoCalculo;
            txtStat1.Text = cm.Status1;
            txtStat2.Text = cm.Status2;

            comboMoneda.SelectedValue = cto.idMoneda;
            comboNacion1.SelectedValue = cto.idNAcionalidad1;
            comboNacion2.SelectedValue = cto.idNacionalidad2;
            comboIdioma.SelectedValue = cto.IdIdioma;
            comboTipPer.SelectedValue = cto.idTipoPersona;
            comboEdoCiv1.SelectedValue = cto.idEdoCivil1;
            comboEdoCiv2.SelectedValue = cto.idEdoCivil2;
            comboCiudad1.SelectedValue = cto.idCiudad1;
            comboEstado1.SelectedValue = cm.idEstado1;
            comboPais1.SelectedValue = cm.idPais1;
            comboCiudad2.SelectedValue = cto.idCiudad2;
            comboEstado2.SelectedValue = cm.idEstado2;
            comboPais2.SelectedValue = cm.idPais2;

            txtModLead.Text = cto.Lead.ToString();
            comboModStat1.SelectedValue = cto.idStatusCon1;
            comboModStat2.SelectedValue = cto.idStatusCon2;

            cm.TipCon = comboTipoCon.DisplayMember;


            Tarjetas();
        }

        private void Tarjetas()
        {
            txtTNombre1.Text = cto.MFNombre1;
            txtTNombre2.Text = cto.MFNombre2;
            txtTNombre3.Text = cto.MFNombre3;
            txtTNombre4.Text = cto.MFNombre4;
            txtTNombre5.Text = cto.MFNombre5;

            txtNum1.Text = cto.MFNoTarjeta1;
            txtNum2.Text = cto.MFNoTarjeta2;
            txtNum3.Text = cto.MFNoTarjeta3;
            txtNum4.Text = cto.MFNoTarjeta4;
            txtNum5.Text = cto.MFNoTarjeta5;

            cbTipo1.SelectedValue = cto.MFIdTarjeta1;
            cbTipo2.SelectedValue = cto.MFIdTarjeta2;
            cbTipo3.SelectedValue = cto.MFIdTarjeta3;
            cbTipo4.SelectedValue = cto.MFIdTarjeta4;
            cbTipo5.SelectedValue = cto.MFIdTarjeta5;
            txtCodigo1.Text = cto.MFCodSeg1;
            txtCodigo2.Text = cto.MFCodSeg2;
            txtCodigo3.Text = cto.MFCodSeg3;
            txtCodigo4.Text = cto.MFCodSeg4;
            txtCodigo5.Text = cto.MFCodSeg5;

            if (cto.MFExpiracion1 == Convert.ToDateTime("01/01/50") || cto.MFExpiracion1 == Convert.ToDateTime("01/01/0001"))
            {
                txtExpMes1.Text = "";
                txtExpAno1.Text = "";
            }
            else
            {
                fec.GeneraFecha(cto.MFExpiracion1, 1);
                txtExpMes1.Text = fec.NumMes;
                txtExpAno1.Text = Convert.ToString(fec.Año);
            }

            if (cto.MFExpiracion2 == Convert.ToDateTime("01/01/50") || cto.MFExpiracion2 == Convert.ToDateTime("01/01/0001"))
            {
                txtExpMes2.Text = "";
                txtExpAno2.Text = "";
            }
            else
            {
                fec.GeneraFecha(cto.MFExpiracion2, 1);
                txtExpMes2.Text = fec.NumMes;
                txtExpAno2.Text = Convert.ToString(fec.Año);
            }

            if (cto.MFExpiracion3 == Convert.ToDateTime("01/01/50") || cto.MFExpiracion3 == Convert.ToDateTime("01/01/0001"))
            {
                txtExpMes3.Text = "";
                txtExpAno3.Text = "";
            }
            else
            {
                fec.GeneraFecha(cto.MFExpiracion3, 1);
                txtExpMes3.Text = fec.NumMes;
                txtExpAno3.Text = Convert.ToString(fec.Año);
            }

            if (cto.MFExpiracion4 == Convert.ToDateTime("01/01/50") || cto.MFExpiracion4 == Convert.ToDateTime("01/01/0001"))
            {
                txtExpMes4.Text = "";
                txtExpAno4.Text = "";
            }
            else
            {
                fec.GeneraFecha(cto.MFExpiracion4, 1);
                txtExpMes4.Text = fec.NumMes;
                txtExpAno4.Text = Convert.ToString(fec.Año);
            }

            if (cto.MFExpiracion5 == Convert.ToDateTime("01/01/50") || cto.MFExpiracion5 == Convert.ToDateTime("01/01/0001"))
            {
                txtExpMes5.Text = "";
                txtExpAno5.Text = "";
            }
            else
            {
                fec.GeneraFecha(cto.MFExpiracion5, 1);
                txtExpMes5.Text = fec.NumMes;
                txtExpAno5.Text = Convert.ToString(fec.Año);
            }

            chActiva1.Checked = Convert.ToBoolean(cto.MFActiva1);
            chActiva2.Checked = Convert.ToBoolean(cto.MFActiva2);
            chActiva3.Checked = Convert.ToBoolean(cto.MFActiva3);
            chActiva4.Checked = Convert.ToBoolean(cto.MFActiva4);
            chActiva5.Checked = Convert.ToBoolean(cto.MFActiva5);
            chNacional1.Checked = Convert.ToBoolean(cto.MFNacional1);
            chNacional2.Checked = Convert.ToBoolean(cto.MFNacional2);
            chNacional3.Checked = Convert.ToBoolean(cto.MFNacional3);
            chNacional4.Checked = Convert.ToBoolean(cto.MFNacional4);
            chNacional5.Checked = Convert.ToBoolean(cto.MFNacional5);

            txtImp1.Text = cto.CargoTC1.ToString("N");
            txtImp2.Text = cto.CargoTC2.ToString("N");
            txtImp3.Text = cto.CargoTC3.ToString("N");
            txtImp4.Text = cto.CargoTC4.ToString("N");

            TarjetasUsuario(comboNumT1, cto.MensualidadTC1);
            TarjetasUsuario(comboNumT2, cto.MensualidadTC2);
            TarjetasUsuario(comboNumT3, cto.MensualidadTC3);
            TarjetasUsuario(comboNumT4, cto.MensualidadTC4);
        }


        private void Inhabilitar()
        {
            txtFolio.Enabled = false;
            txtTipCalc.Enabled = false;
          /*  txtTipCam.Enabled = false;
            txtLead.Enabled = false;
            txtStat1.Enabled = false;
            txtStat2.Enabled = false;
            txtNom1.Enabled = false;
            txtNom2.Enabled = false;
            txtRfc1.Enabled = false;
            txtRfc2.Enabled = false;
            txtCard1.Enabled = false;
            txtCard2.Enabled = false;
            txtBenef1.Enabled = false;
            txtBenef2.Enabled = false;
            txtRepLeg1.Enabled = false;
            txtRepLeg2.Enabled = false;
            txtDir1.Enabled = false;
            txtDir2.Enabled = false;
            txtCp1.Enabled = false;
            txtCp2.Enabled = false;
            txtTelCasa1.Enabled = false;
            txtTelCasa2.Enabled = false;
            txtTelOfic1.Enabled = false;
            txtTelOfic2.Enabled = false;
            txtFax1.Enabled = false;
            txtFax2.Enabled = false;
            txtCel1.Enabled = false;
            txtCel2.Enabled = false;
            txtCorreo1.Enabled = false;
            txtCorreo2.Enabled = false;
            txtWeb1.Enabled = false;
            txtWeb2.Enabled = false;
            */
            comboMoneda.Enabled = false;
            comboIdioma.Enabled = false;
            comboTipPer.Enabled = false;
            comboEdoCiv1.Enabled = false;
            comboEdoCiv2.Enabled = false;
            comboNacion1.Enabled = false;
            comboNacion2.Enabled = false;
            comboPais1.Enabled = false;
            comboPais2.Enabled = false;
            comboEstado1.Enabled = false;
            comboEstado2.Enabled = false;
            comboCiudad1.Enabled = false;
            comboCiudad2.Enabled = false;

        }
        
        private void InhabilitarTarjetas()
        {
            txtTNombre1.Enabled = false;
            txtTNombre2.Enabled = false;
            txtTNombre3.Enabled = false;
            txtTNombre4.Enabled = false;
            txtTNombre5.Enabled = false;
            txtNum1.Enabled = false;
            txtNum2.Enabled = false;
            txtNum3.Enabled = false;
            txtNum4.Enabled = false;
            txtNum5.Enabled = false;
            cbTipo1.Enabled = false;
            cbTipo2.Enabled = false;
            cbTipo3.Enabled = false;
            cbTipo4.Enabled = false;
            cbTipo5.Enabled = false;
            txtCodigo1.Enabled = false;
            txtCodigo2.Enabled = false;
            txtCodigo3.Enabled = false;
            txtCodigo4.Enabled = false;
            txtCodigo5.Enabled = false;
            txtExpMes1.Enabled = false;
            txtExpMes2.Enabled = false;
            txtExpMes3.Enabled = false;
            txtExpMes4.Enabled = false;
            txtExpMes5.Enabled = false;
            txtExpAno1.Enabled = false;
            txtExpAno2.Enabled = false;
            txtExpAno3.Enabled = false;
            txtExpAno4.Enabled = false;
            txtExpAno5.Enabled = false;
            chActiva1.Enabled = false;
            chActiva2.Enabled = false;
            chActiva3.Enabled = false;
            chActiva4.Enabled = false;
            chActiva5.Enabled = false;
            chNacional1.Enabled = false;
            chNacional2.Enabled = false;
            chNacional3.Enabled = false;
            chNacional4.Enabled = false;
            chNacional5.Enabled = false;
            txtImp1.Enabled = false;
            txtImp2.Enabled = false;
            txtImp3.Enabled = false;
            txtImp4.Enabled = false;
            comboNumT1.Enabled = false;
            comboNumT2.Enabled = false;
            comboNumT3.Enabled = false;
            comboNumT4.Enabled = false;
            buttLimpiar1.Enabled = false;
            buttLimpiar2.Enabled = false;
            buttLimpiar3.Enabled = false;
            buttLimpiar4.Enabled = false;
        }

        private void llenarCombos()
        {
            llenar.TipoCon(comboTipoCon);
            llenar.Moneda(comboMoneda);
            llenar.Nacionalidad(comboNacion1);
            llenar.Nacionalidad(comboNacion2);
            llenar.Idioma(comboIdioma);
            llenar.TipoPersona(comboTipPer);
            llenar.EdoCivil(comboEdoCiv1);
            llenar.EdoCivil(comboEdoCiv2);
            llenar.Ciudad(comboCiudad1);
            llenar.Ciudad(comboCiudad2);
            llenar.Estado(comboEstado1);
            llenar.Estado(comboEstado2);
            llenar.Pais(comboPais1);
            llenar.Pais(comboPais2);
            llenar.Status1(comboModStat1);
            llenar.Status2(comboModStat2);
            llenar.FormasPago(cbTipo1);
            llenar.FormasPago(cbTipo2);
            llenar.FormasPago(cbTipo3);
            llenar.FormasPago(cbTipo4);
            llenar.FormasPago(cbTipo5);

        }

        private void TarjetasUsuario(ComboBox valor, string NoTarjeta)
        {
            valor.Items.Clear();

            int i = 0;
            int index = 0;

            valor.Items.Insert(i, ""); i++;

            if (cto.MFNoTarjeta1 != "")
            {
                valor.Items.Insert(i, cto.MFNoTarjeta1); 
                if (NoTarjeta == cto.MFNoTarjeta1)
                {   index = i;   }
                i++;
            }

            if (cto.MFNoTarjeta2 != "")
            {
                valor.Items.Insert(i, cto.MFNoTarjeta2); 
                if (NoTarjeta == cto.MFNoTarjeta2)
                { index = i; }
                i++;
            }

            if (cto.MFNoTarjeta3 != "")
            {
                valor.Items.Insert(i, cto.MFNoTarjeta3); 
                if (NoTarjeta == cto.MFNoTarjeta3)
                { index = i; }
                i++;
            }

            if (cto.MFNoTarjeta4 != "")
            {
                valor.Items.Insert(i, cto.MFNoTarjeta4); 
                if (NoTarjeta == cto.MFNoTarjeta4)
                { index = i; }
                i++;
            }

            if (cto.MFNoTarjeta5 != "")
            {
                valor.Items.Insert(i, cto.MFNoTarjeta5); 
                if (NoTarjeta == cto.MFNoTarjeta5)
                { index = i; }
                i++;
            }

            valor.SelectedIndex = index;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bttnTC1_Click(object sender, EventArgs e)
        {
            txtTNombre1.Text = "";
            txtNum1.Text = "";
            cbTipo1.SelectedValue = 0;
            txtCodigo1.Text = "";
            txtExpMes1.Text = "";
            txtExpAno1.Text = "";
            chActiva1.Checked = false;
            chNacional1.Checked = false;
        }

        private void bttnTC2_Click(object sender, EventArgs e)
        {
            txtTNombre2.Text = "";
            txtNum2.Text = "";
            cbTipo2.SelectedValue = 0;
            txtCodigo2.Text = "";
            txtExpMes2.Text = "";
            txtExpAno2.Text = "";
            chActiva2.Checked = false;
            chNacional2.Checked = false;
        }

        private void bttnTC3_Click(object sender, EventArgs e)
        {
            txtTNombre3.Text = "";
            txtNum3.Text = "";
            cbTipo3.SelectedValue = 0;
            txtCodigo3.Text = "";
            txtExpMes3.Text = "";
            txtExpAno3.Text = "";
            chActiva3.Checked = false;
            chNacional3.Checked = false;
        }

        private void bttnTC4_Click(object sender, EventArgs e)
        {
            txtTNombre4.Text = "";
            txtNum4.Text = "";
            cbTipo4.SelectedValue = 0;
            txtCodigo4.Text = "";
            txtExpMes4.Text = "";
            txtExpAno4.Text = "";
            chActiva4.Checked = false;
            chNacional4.Checked = false;
        }

        private void bttnTC5_Click(object sender, EventArgs e)
        {
            txtTNombre5.Text = "";
            txtNum5.Text = "";
            cbTipo5.SelectedValue = 0;
            txtCodigo5.Text = "";
            txtExpMes5.Text = "";
            txtExpAno5.Text = "";
            chActiva5.Checked = false;
            chNacional5.Checked = false;
        }

        private void buttLimpiar1_Click(object sender, EventArgs e)
        {
            txtImp1.Text = "0";
            comboNumT1.SelectedIndex = 0;
        }

        private void buttLimpiar2_Click(object sender, EventArgs e)
        {
            txtImp2.Text = "0";
            comboNumT2.SelectedIndex = 0;
        }

        private void buttLimpiar3_Click(object sender, EventArgs e)
        {
            txtImp3.Text = "0";
            comboNumT3.SelectedIndex = 0;
        }

        private void buttLimpiar4_Click(object sender, EventArgs e)
        {
            txtImp4.Text = "0";
            comboNumT4.SelectedIndex = 0;
        }

        private void txtImp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.NumerosConPunto(sender,e, txtImp1);
        }

        private void txtImp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.NumerosConPunto(sender, e, txtImp2);
        }

        private void txtImp3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.NumerosConPunto(sender, e, txtImp3);
        }

        private void txtImp4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.NumerosConPunto(sender, e, txtImp4);
        }

        private void txtCodigo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender,e);
        }

        private void txtCodigo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtCodigo3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtCodigo4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtCodigo5_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpMes1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpMes2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpMes3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpMes4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpMes5_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpAno1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpAno2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpAno3_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpAno4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }

        private void txtExpAno5_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.SoloNumeros(sender, e);
        }



    }
}
