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
using OTLC.Reports;
using OTLC.Models;

namespace OTLC
{
    public partial class ContratosReportes : Form
    {
        Conexion c = new Conexion();
        Empresa emp = new Empresa();
        Sociedad soc = new Sociedad();

        llenarComboBox llenar = new llenarComboBox();
        Contratos cto = new Contratos();
        ContratosMetodos cm = new ContratosMetodos();
        TiposPersona tp = new TiposPersona();
        Ciudades cd = new Ciudades();
        Estados ed = new Estados();
        Paises ps = new Paises();
        EdoCivil ec = new EdoCivil();
        Nacionalidades nac = new Nacionalidades();

        //Crear Objeto REPORTE
        VisorReportes vr;
        Calculos cal = new Calculos();
        Fechas fecha = new Fechas();
        ImporteLetras letras = new ImporteLetras();
        EspAnexoA anexoA = new EspAnexoA(); 
        EspAnexoB anexoB = new EspAnexoB();
        EspAnexoC anexoC = new EspAnexoC();
        EspAnexoD anexoD = new EspAnexoD();
        EspAutorizacion cartaAut = new EspAutorizacion();
        EspPagare pagare = new EspPagare();
        EspContrato contrato = new EspContrato();
        IngAnexoA anexoAA = new IngAnexoA();
        IngAnexoB anexoBB = new IngAnexoB();
        IngAnexoC anexoCC = new IngAnexoC();
        IngAnexoD anexoDD = new IngAnexoD();
        IngAutorizacion cartaAutIng = new IngAutorizacion();
        IngPagare pagaree = new IngPagare();
        IngContrato contratoIng = new IngContrato();



        public ContratosReportes()
        {
            InitializeComponent();
            permiso();
            Inhabilitar(); 
            llenarCombos();  
        }

        private void permiso()
        {
            if (Sesion.ContratosRep == false)
            { dataGridView1.Enabled = false; }
        }

        private void Consultar()
        {
            if (string.IsNullOrEmpty(txtNoCon.Text))
            {
                MessageBox.Show("Debe proporcionar el Numero de Contrato para la busqueda de la información.");
            }

            else
            {
                cm.Limpiar(cto);
                AsignaValores();

                if (cm.ExisteContrato(Convert.ToInt32(comboTipoCon.SelectedValue),Convert.ToInt32(txtNoCon.Text)) == 0)
                { MessageBox.Show("El contrato " + comboTipoCon.Text + "-" + cto.NumCto + " no existe!"); }
                else
                {
                    cm.LeerContrato(cto);
                    tp.LeerTipoPersona(cto.idTipoPersona);
                    cd.LeerCiudad(cto.idCiudad1);
                    ed.LeerEstado(cm.idEstado1);
                    ps.LeerPais(cm.idPais1);
                    ec.LeerEdoCivil(cto.idEdoCivil1);
                    nac.LeerNacionalidad(cto.idNAcionalidad1);

                    cal.CalcCat(cto.TazaInteres);
                    BorrarPagos();
                    cm.UltimaMensualidad(cto);
                    AsignaValores();
                    Habilitar();
                }

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

        private void bttnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void llenarCombos()
        {
            llenar.TipoCon(comboTipoCon);
            llenar.IdiomaDoctos(comboIdioma);
            llenar.GrupoDoctos(comboGrupo);
        }

        private void Inhabilitar()
        {
            comboGrupo.Enabled = false;
            radioLimpiar.Enabled = false;
            radioSelecTodo.Enabled = false;

            dataGridView1.Enabled = false;
            comboIdioma.Enabled = false;
        }

        private void Habilitar()
        {
            dataGridView1.Enabled = true;
            comboIdioma.Enabled = true;
            radioSelecTodo.Enabled = true;
            radioLimpiar.Enabled = true;
        }

        private void AsignaValores()
        {
            txtNombre1.Text = cto.Nombre1.ToString();
            txtNombre2.Text = cto.Nombre2.ToString();

            if (cto.FechaVta == Convert.ToDateTime("01/01/50")|| cto.FechaVta == Convert.ToDateTime("01/01/0001"))
            { txtFechaVta.Text = ""; }
            else
            { txtFechaVta.Text = cto.FechaVta.ToString("d"); }

            if (cto.FechaProceso == Convert.ToDateTime("01/01/50")|| cto.FechaProceso == Convert.ToDateTime("01/01/0001"))
            { txtFechaProc.Text = ""; }
            else
            { txtFechaProc.Text = cto.FechaProceso.ToString("d"); }

            if (cto.FechaCxl == Convert.ToDateTime("01/01/50")|| cto.FechaCxl == Convert.ToDateTime("01/01/0001"))
            { txtFechaCxl.Text = ""; }
            else { txtFechaCxl.Text = cto.FechaCxl.ToString("d"); }

            txtStatus.Text = cm.Status1;
            txtMembresia.Text = cm.Membresia;
            txtTemporada.Text = cm.Temporada;

            comboIdioma.SelectedValue = cto.IdIdioma;

            Documentos(Convert.ToInt32(comboIdioma.SelectedValue), Convert.ToInt32(comboGrupo.SelectedValue));

        }

        private void Documentos(int idioma, int grupo)
        {
            string sql = "select DC_NOMBRE AS 'NOMBRE DEL DOCUMENTO' from CSharpDoctos where DC_IDIOMA = @Idioma and DC_GRUPO = @Grupo and DC_ACTIVO='A'";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Idioma", SqlDbType.Int).Value = idioma;
                    comando.Parameters.Add("@Grupo", SqlDbType.Int).Value = grupo;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
               
                    con.Close();
                }

            }
        }

        private void comboIdioma_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            Documentos(Convert.ToInt32(comboIdioma.SelectedValue), Convert.ToInt32(comboGrupo.SelectedValue));
        }

        private void radioSelecTodo_Click_1(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            radioLimpiar.Checked = false;
        }

        private void radioLimpiar_Click_1(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            radioSelecTodo.Checked = false;
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            radioLimpiar.Checked = false;
            radioSelecTodo.Checked = false;
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idioma = Convert.ToInt32(comboIdioma.SelectedValue);
            string Reporte = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Reporte == "Anexo A")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }              
            }

            if (Reporte == "Anexo B")
            {
                if (idioma == 1)
                {  ReportesEsp(Reporte);  }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Anexo C")
            {
                if (idioma == 1)
                {  ReportesEsp(Reporte);  }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Anexo D")
            {
                if (idioma == 1)
                {  ReportesEsp(Reporte);  }
                else
                { ReportesIng(Reporte); }

            }

            if( Reporte == "Autorizacion")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Contrato")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
               { ReportesIng(Reporte); }
            }

            if (Reporte == "Pagare")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }

        }

        private void ReportesEsp(string reporte)
        {

            int idioma = Convert.ToInt32(comboIdioma.SelectedValue);
            string Moneda;
            string ThisDay;
            string ThisHora;
            string FechaUltiMen = "";
            string FechaPrimMen = "";
            string Importe ="";

            //formato fecha del dia actual
            fecha.GeneraFecha(DateTime.Today, 1);
            ThisDay = fecha.LetrasDia + ", " + fecha.NumDia + " DE " + fecha.LetrasMes + " DE " + fecha.Año;
            ThisHora = DateTime.Today.Hour + ":" + DateTime.Today.Minute;

            //define fecha de venta
            string fVta;
            fecha.GeneraFecha(cto.FechaVta, 1);
            fVta = fecha.NumDia + " " + fecha.LetrasMes + " " + fecha.Año;

            if (cto.FecprimmenActual.Year == 50 || (cto.FecprimmenActual.Year < 1900))
            {
                FechaPrimMen = "";
                FechaUltiMen = "";
            }
            else
            {
                //genera formato fecha ultima mensualidad
                cm.UltimaMensualidad(cto);
                fecha.GeneraFecha(Convert.ToDateTime(cm.FechaUltiMen), 1);
                FechaUltiMen = fecha.NumDia + " " + fecha.LetrasMes + " " + fecha.Año;

                //genera formato fecha primera mensualidad
                fecha.GeneraFecha(cto.FecprimmenActual, 1);
                FechaPrimMen = fecha.NumDia + " " + fecha.LetrasMes + " " + fecha.Año;
            }

            Moneda = cto.idMoneda == 1 ? "PESOS" : "USD";

            Importe = letras.enletrasEsp(Convert.ToString(cto.ImporteMensualidad), Moneda);

            //_______________________________________________________________________________________________________________ANEXOA
            if (reporte == "Anexo A")    //Envia parametros al AnexoA
            {
                anexoA.SetParameterValue("NumCto", cto.NumCto);
                anexoA.SetParameterValue("TipCto", cm.TipCon);
                anexoA.SetParameterValue("Vendedor", soc.Vendedor);
                anexoA.SetParameterValue("Comprador", soc.Comprador);
                anexoA.SetParameterValue("Compradores", soc.Compradores);
                anexoA.SetParameterValue("OTLC", soc.OTLC);
                anexoA.SetParameterValue("OTLCmin", soc.OTLCmin);
                anexoA.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoA);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________ANEXOB
            if (reporte == "Anexo B")    //Envia parametros al AnexoB
            {
                anexoB.SetParameterValue("Vendedor", soc.Vendedor);
                anexoB.SetParameterValue("Comprador", soc.Comprador);
                anexoB.SetParameterValue("NumCto", cto.NumCto);
                anexoB.SetParameterValue("TipCto", cm.TipCon);
                anexoB.SetParameterValue("Membresia", cm.Temporada);
                anexoB.SetParameterValue("OTLC", soc.OTLC);

                if (cto.idTipmem == 15)
                { anexoB.SetParameterValue("Dias", 120); } //silver
                else
                { anexoB.SetParameterValue("Dias", 90); } //zafiro, golden, premium

                anexoB.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoB);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________ANEXOC
            if (reporte == "Anexo C")    //Envia parametros al AnexoC
            {
                anexoC.SetParameterValue("NumCto", cto.NumCto);
                anexoC.SetParameterValue("TipCto", cm.TipCon);
                anexoC.SetParameterValue("Membresia", cm.Temporada);
                anexoC.SetParameterValue("Puntos", cto.Semanas);
                anexoC.SetParameterValue("Duracion", cm.Duracion);

                if (cto.idTipmem == 18)
                { anexoC.SetParameterValue("Texto", "Sin restricciones"); } //zafiro
                else
                { anexoC.SetParameterValue("Texto", "Febrero a Abril 15, Presidente, Semana Santa y Pascua, Acción de Gracias, Navidad y Año Nuevo"); } //silver, golden, premium
                anexoC.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoC);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________ANEXOD
            if (reporte == "Anexo D")    //Envia parametros al AnexoD
            {
                string nombres;
                string direccion;
                double saldoFinal;
                string status;

                nombres = cto.Nombre1 + "," + cto.Nombre2;
                direccion = cto.Direccion1 + "," + cd.Nombre + "," + ed.Nombre + "," + ps.Nombre + ", CP:" + cto.Cp1;
                saldoFinal = (cto.ImporteMensualidad * cto.Plazo);

                anexoD.SetParameterValue("TipCto", cm.TipCon);
                anexoD.SetParameterValue("NumCto", cto.NumCto);
                anexoD.SetParameterValue("FechaVta", fVta);
                anexoD.SetParameterValue("Nombres", nombres);
                anexoD.SetParameterValue("Rfc", cto.SegsocRFC1);
                anexoD.SetParameterValue("Direccion", direccion);
                anexoD.SetParameterValue("TelCasa", cto.TelCasa1);
                anexoD.SetParameterValue("TelOficina", cto.TelOficina1);
                anexoD.SetParameterValue("Email", cto.Email1);
                anexoD.SetParameterValue("Interes", cto.TazaInteres);
                anexoD.SetParameterValue("Saldo", cto.Saldo);
                anexoD.SetParameterValue("SaldoFinal", saldoFinal);
                anexoD.SetParameterValue("Moneda", Moneda);
                anexoD.SetParameterValue("Plazo", cto.Plazo);
                anexoD.SetParameterValue("Mensualidad", cto.ImporteMensualidad);

                if (cto.idStatusCon1 == 5)
                { anexoD.SetParameterValue("Status", "Liquidado"); }
                else
                {
                    if (cto.FecprimmenActual.Year == 50 || (cto.FecprimmenActual.Year < 1900))
                    {   status = "";   }
                    else
                    {
                        fecha.GeneraFecha(cto.FecprimmenActual, 1);
                        status = "El " + fecha.NumDia + " de cada mes, empezando en " + fecha.LetrasMes + " del " + fecha.Año;
                    }

                    anexoD.SetParameterValue("Status", status);
                }

                anexoD.SetParameterValue("Vendedor", soc.Vendedor);
                anexoD.SetParameterValue("Comprador", soc.Comprador);
                anexoD.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoD);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________AUTORIZACION
            if (reporte == "Autorizacion")    //Envia parametros a la Carta de Autorización
            {
                //genera formato fecha expiracion
                fecha.GeneraFecha(cto.MFExpiracion1, 1);
                string TExp = fecha.NumMes + "/" + fecha.Año;

                //tipos de tarjeta
                string Tvi = cto.MFIdTarjeta1 == 4 ? "X" : "O"; //TARJETAVISA
                string Tmc = cto.MFIdTarjeta1 == 3 ? "X" : "O"; //TARJETAMC
                string Tam = cto.MFIdTarjeta1 == 7 ? "X" : "O"; //TARJETAAMEXCO

                cartaAut.SetParameterValue("TipCto", cm.TipCon);
                cartaAut.SetParameterValue("NumCto", cto.NumCto);
                cartaAut.SetParameterValue("Moneda", Moneda);
                cartaAut.SetParameterValue("Plazo", cto.Plazo);
                cartaAut.SetParameterValue("FechaVta", fVta);
                cartaAut.SetParameterValue("Mensualidad", cto.ImporteMensualidad);
                cartaAut.SetParameterValue("Nombre1", cto.Nombre1);
                cartaAut.SetParameterValue("Nombre2", cto.Nombre2);
                cartaAut.SetParameterValue("TNombre", cto.MFNombre1);
                cartaAut.SetParameterValue("TNumero", cto.MFNoTarjeta1);
                cartaAut.SetParameterValue("TCodigo", cto.MFCodSeg1);
                cartaAut.SetParameterValue("TFecha", TExp);
                cartaAut.SetParameterValue("TVI", Tvi);
                cartaAut.SetParameterValue("TMC", Tmc);
                cartaAut.SetParameterValue("TAM", Tam);
                cartaAut.SetParameterValue("Importe", Importe);
                cartaAut.SetParameterValue("Sociedad", soc.Nombre);
                cartaAut.SetParameterValue("CxcTel", soc.CxcTel);
                cartaAut.SetParameterValue("CxcEmail", soc.CxcEmail);
                cartaAut.SetParameterValue("Domicilio", soc.Domicilio);
                cartaAut.SetParameterValue("Ciudad", soc.Ciudad);
                cartaAut.SetParameterValue("Estado", soc.Estado);
                cartaAut.SetParameterValue("CP", soc.Cp);
                cartaAut.SetParameterValue("FecPrimMen", FechaPrimMen);
                cartaAut.SetParameterValue("FecUltiMen", FechaUltiMen);
                cartaAut.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(cartaAut);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________PAGARE
            if (reporte == "Pagare")    //Envia parametros al PAGARE
            {
                string fechaVta = "";

                PagosPagare(pagare);

                fecha.GeneraFecha(cto.FechaVta, 1);
                fechaVta = fecha.NumDia + " de " + fecha.LetrasMes + ", " + fecha.Año;

                pagare.SetParameterValue("TipCto", cm.TipCon);
                pagare.SetParameterValue("NumCto", cto.NumCto);
                pagare.SetParameterValue("FechaVta", fechaVta);
                pagare.SetParameterValue("Importe", Importe);
                pagare.SetParameterValue("Saldo", cto.Saldo);
                pagare.SetParameterValue("Moneda", Moneda);
                pagare.SetParameterValue("Interes", cto.TazaInteres);
                pagare.SetParameterValue("Plazo", cto.Plazo);
                pagare.SetParameterValue("Mensualidad", cto.ImporteMensualidad);
                pagare.SetParameterValue("FecPrimMen", FechaPrimMen);
                pagare.SetParameterValue("FecUltiMen", FechaUltiMen);
                pagare.SetParameterValue("Nombres", cto.Nombre1 + ", " + cto.Nombre2);
                pagare.SetParameterValue("Sociedad", soc.Nombre);
                pagare.SetParameterValue("Representante", soc.Representante);

                if (cto.idNAcionalidad1 == 1)
                {
                    pagare.SetParameterValue("Titulo", "EN PESOS MONEDA NACIONAL");
                    pagare.SetParameterValue("SocTxt", soc.TextoMxn);
                    pagare.SetParameterValue("SocAbono", soc.CtaAbonoMxn);
                    pagare.SetParameterValue("SocClav", soc.CtaClaveMxn);
                    pagare.SetParameterValue("SocDiv", soc.DivisaMxn);
                }
                else
                {
                    pagare.SetParameterValue("Titulo", "EN DÓLARES MONEDA DE CURSO LEGAL DE LOS ESTADOS UNIDOS DE AMÉRICA");
                    pagare.SetParameterValue("SocTxt", soc.TextoUsd);
                    pagare.SetParameterValue("SocAbono", soc.CtaAbonoUsd);
                    pagare.SetParameterValue("SocClav", soc.CtaClaveUsd);
                    pagare.SetParameterValue("SocDiv", soc.DivisaUsd);
                }

                pagare.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(pagare);
                
                vr.ShowDialog();

            }

                //_______________________________________________________________________________________________________________CONTRATO
                if (reporte == "Contrato")    //Envia parametros al CONTRATO
            {
                string fechaPrimMen = "";
                double saldoFinal = 0;

              
                if (cto.FecprimmenActual.Year == 50 || (cto.FecprimmenActual.Year < 1900))
                { fechaPrimMen = ""; }
                else
                {
                    fecha.GeneraFecha(cto.FecprimmenActual, 1);
                    fechaPrimMen = fecha.NumDia + " DE " + fecha.LetrasMes + " DE " + fecha.Año;
                }

                saldoFinal = (cto.ImporteMensualidad * cto.Plazo);

                fecha.GeneraFecha(cto.FechaVta, 1);

                contrato.SetParameterValue("TipCto", cm.TipCon);
                contrato.SetParameterValue("NumCto", cto.NumCto);
                contrato.SetParameterValue("TipPer", tp.Nombre);
                contrato.SetParameterValue("Nombre1", cto.Nombre1);
                contrato.SetParameterValue("Nombre2", cto.Nombre2);
                contrato.SetParameterValue("Nacionalidad", nac.Nombre);
                contrato.SetParameterValue("EdoCivil", ec.Nombre);
                contrato.SetParameterValue("Domicilio", cto.Direccion1);
                contrato.SetParameterValue("Ciudad", cd.Nombre);
                contrato.SetParameterValue("Estado", ed.Nombre);
                contrato.SetParameterValue("Pais", ps.Nombre);
                contrato.SetParameterValue("CP", cto.Cp1);
                contrato.SetParameterValue("TelCasa", cto.TelCasa1);
                contrato.SetParameterValue("TelOfic", cto.TelOficina1);
                contrato.SetParameterValue("Celular", cto.Celular1);
                contrato.SetParameterValue("Fax", cto.Fax1);
                contrato.SetParameterValue("Email", cto.Email1);
                contrato.SetParameterValue("Membresia", cm.Temporada);
                contrato.SetParameterValue("PrecioVta", cto.PrecioVenta);
                contrato.SetParameterValue("Moneda", Moneda);
                contrato.SetParameterValue("Puntos", cto.Semanas);
                contrato.SetParameterValue("CCPactado", cto.CCPactado);
                contrato.SetParameterValue("EngancheCobrado", cto.EngancheCobrado);
                contrato.SetParameterValue("Saldo", cto.Saldo);
                contrato.SetParameterValue("Plazo", cto.Plazo);
                contrato.SetParameterValue("Mensualidad", cto.ImporteMensualidad);
                contrato.SetParameterValue("FecPriMen", fechaPrimMen);
                contrato.SetParameterValue("TasaInteres", cto.TazaInteres);
                contrato.SetParameterValue("SaldoFinal", saldoFinal);
                contrato.SetParameterValue("FechaVta", fVta);
                contrato.SetParameterValue("Dia", fecha.NumDia);
                contrato.SetParameterValue("Mes", fecha.LetrasMes);
                contrato.SetParameterValue("Ano", fecha.Año);

                contrato.SetParameterValue("Sociedad", soc.Nombre);
                contrato.SetParameterValue("SocRep", soc.Representante);
                contrato.SetParameterValue("SocTxtMXN", soc.TextoMxn);
                contrato.SetParameterValue("SocAbonoMXN", soc.CtaAbonoMxn);
                contrato.SetParameterValue("SocClavMXN", soc.CtaClaveMxn);
                contrato.SetParameterValue("SocDivMXN", soc.DivisaMxn);
                contrato.SetParameterValue("SocTxtUSD", soc.TextoUsd);
                contrato.SetParameterValue("SocAbonoUSD", soc.CtaAbonoUsd);
                contrato.SetParameterValue("SocClavUSD", soc.CtaClaveUsd);
                contrato.SetParameterValue("SocDivUSD", soc.DivisaUsd);
                contrato.SetParameterValue("SocDomicilio", soc.Domicilio);
                contrato.SetParameterValue("SocCiudad", soc.Ciudad);
                contrato.SetParameterValue("SocEstado", soc.Estado);
                contrato.SetParameterValue("SocPais", soc.Pais);
                contrato.SetParameterValue("SocCP", soc.Cp);
                contrato.SetParameterValue("SocTelMX", soc.TelMx);
                contrato.SetParameterValue("SocTelUSA", soc.TelUsa);
                contrato.SetParameterValue("SocTelOtro", soc.TelOtro);
                contrato.SetParameterValue("SocEmail1", soc.Email1);
                contrato.SetParameterValue("SocEmail2", soc.Email2);

                contrato.SetParameterValue("Cat", cal.CatIva);
                contrato.SetParameterValue("CatSinIva", cal.Cat);

                contrato.SetParameterValue("ThisDay", ThisDay);
                contrato.SetParameterValue("Vendedor", soc.Vendedor);
                contrato.SetParameterValue("Comprador", soc.Comprador);
                contrato.SetParameterValue("Compradores", soc.Compradores);
                contrato.SetParameterValue("OTLCiniciales", soc.OTLCiniciales);
                contrato.SetParameterValue("OTLC", soc.OTLC);

                vr = new VisorReportes(contrato);
                vr.ShowDialog();

            }
        }

        private void ReportesIng(string reporte)
        {

            int idioma = Convert.ToInt32(comboIdioma.SelectedValue);
            string Moneda;
            string ThisDay;
            string ThisHora;
            string FechaUltiMen = "";
            string FechaPrimMen = "";
            string Importe = "";

            //formato fecha del dia actual
            fecha.GeneraFecha(DateTime.Today, 2);
            ThisDay = fecha.LetrasDia + ", " + fecha.NumDia + " " + fecha.LetrasMes + " " + fecha.Año;
            ThisHora = DateTime.Today.Hour + ":" + DateTime.Today.Minute;

            //define fecha de venta
            string fVta;
            fecha.GeneraFecha(cto.FechaVta, 2);
            fVta = fecha.NumDia + " " + fecha.LetrasMes + " " + fecha.Año;


            if (cto.FecprimmenActual.Year == 50 || (cto.FecprimmenActual.Year < 1900))
            {
                FechaPrimMen = "";
                FechaUltiMen = "";
            }
            else
            {
                //genera formato fecha ultima mensualidad
                cm.UltimaMensualidad(cto);
                fecha.GeneraFecha(Convert.ToDateTime(cm.FechaUltiMen), 2);
                FechaUltiMen = fecha.NumDia + " " + fecha.LetrasMes + " " + fecha.Año;

                //genera formato fecha primera mensualidad
                fecha.GeneraFecha(cto.FecprimmenActual, 2);
                FechaPrimMen = fecha.NumDia + " " + fecha.LetrasMes + " " + fecha.Año;
            }

            Moneda = cto.idMoneda == 1 ? "PESOS" : "USD";

            Importe = letras.enletrasIng(Convert.ToString(cto.ImporteMensualidad), Moneda);

            //_______________________________________________________________________________________________________________ANEXOA
            if (reporte == "Anexo A")    //Envia parametros al AnexoA
            {
                anexoAA.SetParameterValue("NumCto", cto.NumCto);
                anexoAA.SetParameterValue("TipCto", cm.TipCon);
                anexoAA.SetParameterValue("Vendedor2", soc.Vendedor2);
                anexoAA.SetParameterValue("Comprador2", soc.Comprador2);
                anexoAA.SetParameterValue("Compradores2", soc.Compradores2);
                anexoAA.SetParameterValue("OTLC", soc.OTLC);
                anexoAA.SetParameterValue("OTLCmin", soc.OTLCmin);
                anexoAA.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoAA);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________ANEXOB
            if (reporte == "Anexo B")    //Envia parametros al AnexoB
            {
                anexoBB.SetParameterValue("Vendedor", soc.Vendedor2);
                anexoBB.SetParameterValue("Comprador", soc.Comprador2);
                anexoBB.SetParameterValue("NumCto", cto.NumCto);
                anexoBB.SetParameterValue("TipCto", cm.TipCon);
                anexoBB.SetParameterValue("Membresia", cm.TipMemIdioma2);
                anexoBB.SetParameterValue("OTLC", soc.OTLC);

                if (cto.idTipmem == 15)
                { anexoBB.SetParameterValue("Dias", 120); } //silver
                else
                { anexoBB.SetParameterValue("Dias", 90); } //zafiro, golden, premium

                anexoBB.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoBB);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________ANEXOC
            if (reporte == "Anexo C")    //Envia parametros al AnexoC
            {
                anexoCC.SetParameterValue("NumCto", cto.NumCto);
                anexoCC.SetParameterValue("TipCto", cm.TipCon);
                anexoCC.SetParameterValue("Membresia", cm.TipMemIdioma2);
                anexoCC.SetParameterValue("Puntos", cto.Semanas);
                anexoCC.SetParameterValue("Duracion", cm.Duracion);

                if (cto.idTipmem == 18)
                { anexoCC.SetParameterValue("Texto", "No Restrictions"); } //zafiro
                else
                { anexoCC.SetParameterValue("Texto", "February to April 15, President´s, Holy, Eastern, Thanksgiving, Christmas and New Year"); } //silver, golden, premium
                anexoCC.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoCC);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________ANEXOD
            if (reporte == "Anexo D")    //Envia parametros al AnexoD
            {
                string nombres;
                string direccion;
                double saldoFinal;
                string status;

                nombres = cto.Nombre1 + "," + cto.Nombre2;
                direccion = cto.Direccion1 + "," + cd.Nombre + "," + ed.Nombre + "," + ps.Nombre + ", CP:" + cto.Cp1;
                saldoFinal = (cto.ImporteMensualidad * cto.Plazo);

                anexoDD.SetParameterValue("TipCto", cm.TipCon);
                anexoDD.SetParameterValue("NumCto", cto.NumCto);
                anexoDD.SetParameterValue("FechaVta", fVta);
                anexoDD.SetParameterValue("Nombres", nombres);
                anexoDD.SetParameterValue("Rfc", cto.SegsocRFC1);
                anexoDD.SetParameterValue("Direccion", direccion);
                anexoDD.SetParameterValue("TelCasa", cto.TelCasa1);
                anexoDD.SetParameterValue("TelOficina", cto.TelOficina1);
                anexoDD.SetParameterValue("Email", cto.Email1);
                anexoDD.SetParameterValue("Interes", cto.TazaInteres);
                anexoDD.SetParameterValue("Saldo", cto.Saldo);
                anexoDD.SetParameterValue("SaldoFinal", saldoFinal);
                anexoDD.SetParameterValue("Moneda", Moneda);
                anexoDD.SetParameterValue("Plazo", cto.Plazo);
                anexoDD.SetParameterValue("Mensualidad", cto.ImporteMensualidad);

                if (cto.idStatusCon1 == 5)
                { anexoDD.SetParameterValue("Status", "---"); }
                else
                {
                    if (cto.FecprimmenActual.Year == 50 || (cto.FecprimmenActual.Year < 1900))
                    { status = ""; }
                    else
                    {
                        fecha.GeneraFecha(cto.FecprimmenActual, 1);
                        status = fecha.LetrasMes + fecha.NumDia + ", " + fecha.Año;
                    }

                    anexoDD.SetParameterValue("Status", status);
                }

                anexoDD.SetParameterValue("Vendedor", soc.Vendedor2);
                anexoDD.SetParameterValue("Comprador", soc.Comprador2);
                anexoDD.SetParameterValue("Compradores",soc.Compradores2);
                anexoDD.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(anexoDD);
                vr.ShowDialog();

            }


            //_______________________________________________________________________________________________________________AUTORIZACION
            if (reporte == "Autorizacion")    //Envia parametros a la Carta de Autorización
            {
                //genera formato fecha expiracion
                fecha.GeneraFecha(cto.MFExpiracion1, 2);
                string TExp = fecha.NumMes + "/" + fecha.Año;

                //tipos de tarjeta
                string Tvi = cto.MFIdTarjeta1 == 4 ? "X" : "O"; //TARJETAVISA
                string Tmc = cto.MFIdTarjeta1 == 3 ? "X" : "O"; //TARJETAMC
                string Tam = cto.MFIdTarjeta1 == 7 ? "X" : "O"; //TARJETAAMEXCO

                cartaAutIng.SetParameterValue("TipCto", cm.TipCon);
                cartaAutIng.SetParameterValue("NumCto", cto.NumCto);
                cartaAutIng.SetParameterValue("Moneda", Moneda);
                cartaAutIng.SetParameterValue("Plazo", cto.Plazo);
                cartaAutIng.SetParameterValue("FechaVta", fVta);
                cartaAutIng.SetParameterValue("Mensualidad", cto.ImporteMensualidad);
                cartaAutIng.SetParameterValue("Nombre1", cto.Nombre1);
                cartaAutIng.SetParameterValue("Nombre2", cto.Nombre2);
                cartaAutIng.SetParameterValue("TNombre", cto.MFNombre1);
                cartaAutIng.SetParameterValue("TNumero", cto.MFNoTarjeta1);
                cartaAutIng.SetParameterValue("TCodigo", cto.MFCodSeg1);
                cartaAutIng.SetParameterValue("TFecha", TExp);
                cartaAutIng.SetParameterValue("TVI", Tvi);
                cartaAutIng.SetParameterValue("TMC", Tmc);
                cartaAutIng.SetParameterValue("TAM", Tam);
                cartaAutIng.SetParameterValue("Importe", Importe);
                cartaAutIng.SetParameterValue("Sociedad", soc.Nombre);
                cartaAutIng.SetParameterValue("CxcTel", soc.CxcTel);
                cartaAutIng.SetParameterValue("CxcEmail", soc.CxcEmail);
                cartaAutIng.SetParameterValue("Domicilio", soc.Domicilio);
                cartaAutIng.SetParameterValue("Ciudad", soc.Ciudad);
                cartaAutIng.SetParameterValue("Estado", soc.Estado);
                cartaAutIng.SetParameterValue("CP", soc.Cp);
                cartaAutIng.SetParameterValue("FecPrimMen", FechaPrimMen);
                cartaAutIng.SetParameterValue("FecUltiMen", FechaUltiMen);
                cartaAutIng.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(cartaAutIng);
                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________PAGARE
            if (reporte == "Pagare")    //Envia parametros al PAGARE
            {
                string fechaVta = "";

                PagosPagare2(pagaree);

                fecha.GeneraFecha(cto.FechaVta, 2);
                fechaVta = fecha.NumDia + " de " + fecha.LetrasMes + ", " + fecha.Año;

                pagaree.SetParameterValue("TipCto", cm.TipCon);
                pagaree.SetParameterValue("NumCto", cto.NumCto);
                pagaree.SetParameterValue("FechaVta", fechaVta);
                pagaree.SetParameterValue("Importe", Importe);
                pagaree.SetParameterValue("Saldo", cto.Saldo);
                pagaree.SetParameterValue("Moneda", Moneda);
                pagaree.SetParameterValue("Interes", cto.TazaInteres);
                pagaree.SetParameterValue("Plazo", cto.Plazo);
                pagaree.SetParameterValue("Mensualidad", cto.ImporteMensualidad);
                pagaree.SetParameterValue("FecPrimMen", FechaPrimMen);
                pagaree.SetParameterValue("FecUltiMen", FechaUltiMen);
                pagaree.SetParameterValue("Nombres", cto.Nombre1 + ", " + cto.Nombre2);
                pagaree.SetParameterValue("Sociedad", soc.Nombre);
                pagaree.SetParameterValue("Representante", soc.Representante);

                if (cto.idNAcionalidad1 == 1)
                {
                    pagaree.SetParameterValue("Titulo", "IN PESOS MXN");
                    pagaree.SetParameterValue("SocTxt", soc.TextoMxn);
                    pagaree.SetParameterValue("SocAbono", soc.CtaAbonoMxn);
                    pagaree.SetParameterValue("SocClav", soc.CtaClaveMxn);
                    pagaree.SetParameterValue("SocDiv", soc.DivisaMxn);
                }
                else
                {
                    pagaree.SetParameterValue("Titulo", "IN US DOLLARS");
                    pagaree.SetParameterValue("SocTxt", soc.TextoUsd);
                    pagaree.SetParameterValue("SocAbono", soc.CtaAbonoUsd);
                    pagaree.SetParameterValue("SocClav", soc.CtaClaveUsd);
                    pagaree.SetParameterValue("SocDiv", soc.DivisaUsd);
                }

                pagaree.SetParameterValue("ThisDay", ThisDay);

                vr = new VisorReportes(pagaree);

                vr.ShowDialog();
            }

            //_______________________________________________________________________________________________________________CONTRATO
            if (reporte == "Contrato")    //Envia parametros al CONTRATO
            {
                string fechaPrimMen = "";
                double saldoFinal = 0;

                if (cto.FecprimmenActual.Year == 50 || (cto.FecprimmenActual.Year < 1900))
                {
                    fechaPrimMen = "";
                }
                else
                {
                    fecha.GeneraFecha(cto.FecprimmenActual, 2);
                    fechaPrimMen = fecha.LetrasMes + " " + fecha.NumDia + ", " + fecha.Año;
                }

                saldoFinal = (cto.ImporteMensualidad * cto.Plazo);

                fecha.GeneraFecha(cto.FechaVta, 2);

                contratoIng.SetParameterValue("TipCto", cm.TipCon);
                contratoIng.SetParameterValue("NumCto", cto.NumCto);
                contratoIng.SetParameterValue("TipPer", tp.Idioma2);
                contratoIng.SetParameterValue("Nombre1", cto.Nombre1);
                contratoIng.SetParameterValue("Nombre2", cto.Nombre2);
                contratoIng.SetParameterValue("Nacionalidad", nac.Nombre);
                contratoIng.SetParameterValue("EdoCivil", ec.Idioma2);
                contratoIng.SetParameterValue("Domicilio", cto.Direccion1);
                contratoIng.SetParameterValue("Ciudad", cd.Nombre);
                contratoIng.SetParameterValue("Estado", ed.Nombre);
                contratoIng.SetParameterValue("Pais", ps.Nombre);
                contratoIng.SetParameterValue("CP", cto.Cp1);
                contratoIng.SetParameterValue("TelCasa", cto.TelCasa1);
                contratoIng.SetParameterValue("TelOfic", cto.TelOficina1);
                contratoIng.SetParameterValue("Celular", cto.Celular1);
                contratoIng.SetParameterValue("Fax", cto.Fax1);
                contratoIng.SetParameterValue("Email", cto.Email1);
                contratoIng.SetParameterValue("Membresia", cm.TipMemIdioma2);
                contratoIng.SetParameterValue("PrecioVta", cto.PrecioVenta);
                contratoIng.SetParameterValue("Moneda", Moneda);
                contratoIng.SetParameterValue("Puntos", cto.Semanas);
                contratoIng.SetParameterValue("CCPactado", cto.CCPactado);
                contratoIng.SetParameterValue("EngancheCobrado", cto.EngancheCobrado);
                contratoIng.SetParameterValue("Saldo", cto.Saldo);
                contratoIng.SetParameterValue("Plazo", cto.Plazo);
                contratoIng.SetParameterValue("Mensualidad", cto.ImporteMensualidad);
                contratoIng.SetParameterValue("FecPriMen", fechaPrimMen);
                contratoIng.SetParameterValue("TasaInteres", cto.TazaInteres);
                contratoIng.SetParameterValue("SaldoFinal", saldoFinal);
                contratoIng.SetParameterValue("FechaVta", fVta);
                contratoIng.SetParameterValue("Dia", fecha.NumDia);
                contratoIng.SetParameterValue("Mes", fecha.LetrasMes);
                contratoIng.SetParameterValue("Ano", fecha.Año);

                contratoIng.SetParameterValue("Sociedad", soc.Nombre);
                contratoIng.SetParameterValue("SocRep", soc.Representante);
                contratoIng.SetParameterValue("SocTxtUSD", soc.TextoUsd);
                contratoIng.SetParameterValue("SocAbonoUSD", soc.CtaAbonoUsd);
                contratoIng.SetParameterValue("SocClavUSD", soc.CtaClaveUsd);
                contratoIng.SetParameterValue("SocDivUSD", soc.DivisaUsd);
                contratoIng.SetParameterValue("SocDomicilio", soc.Domicilio);
                contratoIng.SetParameterValue("SocCiudad", soc.Ciudad);
                contratoIng.SetParameterValue("SocEstado", soc.Estado);
                contratoIng.SetParameterValue("SocPais", soc.Pais);
                contratoIng.SetParameterValue("SocCP", soc.Cp);
                contratoIng.SetParameterValue("SocTelMX", soc.TelMx);
                contratoIng.SetParameterValue("SocTelUSA", soc.TelUsa);
                contratoIng.SetParameterValue("SocTelOtro", soc.TelOtro);
                contratoIng.SetParameterValue("SocEmail1", soc.Email1);
                contratoIng.SetParameterValue("SocEmail2", soc.Email2);

                contratoIng.SetParameterValue("Cat", cal.CatIva);
                contratoIng.SetParameterValue("CatSinIva", cal.Cat);

                contratoIng.SetParameterValue("ThisDay", ThisDay);
                contratoIng.SetParameterValue("Vendedor", soc.Vendedor2);
                contratoIng.SetParameterValue("Comprador", soc.Comprador2);
                contratoIng.SetParameterValue("Compradores", soc.Compradores2);
                contratoIng.SetParameterValue("OTLCiniciales", soc.OTLCiniciales);
                contratoIng.SetParameterValue("OTLC", soc.OTLC);

                vr = new VisorReportes(contratoIng);
                vr.ShowDialog();
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            BorrarPagos();
        }

        private void BorrarPagos()
        {
            string sql2 = "Delete CSharpPagos where Usr=@Usr";

            using (SqlConnection conn = new SqlConnection(c.cadenaConexion))
            {
                conn.Open();

                using (SqlCommand comando = new SqlCommand(sql2, conn))
                {
                    comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        private void PagosPagare(EspPagare pagare)
        {

            string sql = "select distinct Folio,Id1,Fecha1,Importe1,Id2,Fecha2,Importe2,Id3,Fecha3,Importe3,Id4,Fecha4,Importe4,Usr from CSharpPagos where Folio=@Folio and Usr=@Usr";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;
                    comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable("CSharpPagos");
                    da.Fill(dt);
                    pagare.SetDataSource(dt);
                }

                con.Close();
            }


        }

        private void PagosPagare2(IngPagare pagaree)
        {

            string sql = "select distinct Folio,Id1,Fecha1,Importe1,Id2,Fecha2,Importe2,Id3,Fecha3,Importe3,Id4,Fecha4,Importe4,Usr from CSharpPagos where Folio=@Folio and Usr=@Usr";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;
                    comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable("CSharpPagos");
                    da.Fill(dt);
                    pagaree.SetDataSource(dt);
                }

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int idioma = Convert.ToInt32(comboIdioma.SelectedValue);
            string Reporte = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            //REPORTES EN ESPAÑOL
            if (Reporte == "Anexo A")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Anexo B")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Anexo C")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Anexo D")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }

            }

            if (Reporte == "Autorizacion")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Contrato")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }

            if (Reporte == "Pagare")
            {
                if (idioma == 1)
                { ReportesEsp(Reporte); }
                else
                { ReportesIng(Reporte); }
            }
        }
    }






}

