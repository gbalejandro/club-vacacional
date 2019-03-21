using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTLC.Models
{
    class ContratosMetodos
    {
        Conexion cx = new Conexion();
        Bitacora bita = new Bitacora();
        TiposContrato tc = new TiposContrato();
        TiposMembresia tm = new TiposMembresia();
        ContratosDuracion cd = new ContratosDuracion();
        StatusContratos1 s1 = new StatusContratos1();
        StatusContratos2 s2 = new StatusContratos2();
        TiposCalculo tipcal = new TiposCalculo();
        Ciudades ciudad = new Ciudades();
        Arreglos arr = new Arreglos();
        
        public int Existe { get; set; } // verificacion de que existe el contrato
    //    public int ExisteLead { get; set; }

        //adicionales
        public string TipCon { get; set; }
        public string Membresia { get; set; }
        public string Temporada { get; set; }
        public string TipMemIdioma2 { get; set; }
        public int Duracion { get; set; }
        public string Status1 { get; set; }
        public string Status2 { get; set; }
        public string Status1Idioma2 { get; set; }
        public string Status1Idioma3 { get; set; }
        public string TipoCalculo { get; set; }
        public int idEstado1 { get; set; }
        public int idEstado2 { get; set; }
        public int idPais1 { get; set; }
        public int idPais2 { get; set; }

        public int NoArregloMax { get; set; }

        //REPORTES
        public string FechaUltiMen { get; set; }
        public DateTime FPag15 { get; set; }
        public DateTime FPag30 { get; set; }
        public DateTime FPag45 { get; set; }
        
        //Informacion de tabla de Pagos
        public DateTime UltimoPago { get; set; }
            
        public void Limpiar(Contratos c)
        {
            idEstado1 = 0;
            idEstado2 = 0;
            idPais1 = 0;
            idPais2 = 0;
            TipCon = "";
            Membresia = "";
            Temporada = "";
            Duracion = 0;
            Status1 = "";
            Status2 = "";


            c.FolioContrato = 0;
            c.idSalaVta = 0;
            c.idTipcon = 0;
            c.NumCto = 0;
            c.idTipmem = 0;
            c.FechaVta= Convert.ToDateTime("01/01/50");
            c.IdIdioma = 0;
            c.Lead = 0;

            c.Nombre1 = "";
            c.Nombre2 = "";
            c.idEdoCivil1 =0;
            c.idEdoCivil2 =0;
            c.idNAcionalidad1 =0;
            c.idNacionalidad2 =0;
            c.SegsocRFC1 = "";
            c.SegsocRFC2 = "";
            c.IdCard1 = "";
            c.idCard2 = "";
            c.Beneficiario1 = "";
            c.Beneficiario2 = "";
            c.RepLegal1 = "";
            c.RepLegal2 = "";
            c.Direccion1 = "";
            c.Direccion2 = "";
            c.idCiudad1 =0;
            c.idCiudad2 =0;
            c.Cp1 = "";
            c.Cp2 = "";
            c.TelCasa1 = "";
            c.TelCasa2 = "";
            c.TelOficina1 = "";
            c.TelOficina2 = "";
            c.Fax1 = "";
            c.Fax2 = "";
            c.Celular1 = "";
            c.Celular2 = "";
            c.Email1 = "";
            c.Email2 = "";
            c.WebSite1 = "";
            c.WebSite2 = "";

            c.idStatusCon1 =0;
            c.idStatusCon2 = 0;
            c.FolioRCI = 0;
            c.PrecioLista = 0;
            c.SemanasLista = 0;
            c.PrecioVenta = 0;
            c.Semanas = 0;
            c.SemanasR = 0;
            c.PorEnganchePac = 0;
            c.EnganchePactado = 0;
            c.EngancheCobrado = 0;
            c.PorEngancheCob = 0;
            c.CCPactado = 0;
            c.CCCobrado = 0;
            c.Saldo = 0;
            c.Plazo = 0;
            c.TazaInteres = 0;
            c.ImporteMensualidad = 0;
            c.Fecprimmen = Convert.ToDateTime("01/01/50");
            c.Fecultmen = Convert.ToDateTime("01/01/50");
            c.Vlo = 0;

            c.MFNombre1 = "";  //-----> TARJETA 1
            c.MFIdTarjeta1 = 0;
            c.MFNoTarjeta1 = "";
            c.MFCodSeg1 = "";
            c.MFExpiracion1 = Convert.ToDateTime("01/01/50");
            c.MFActiva1 = "false";
            c.MFNacional1 = "false";
            c.MFNombre2 = "";   //-----> TARJETA 2
            c.MFIdTarjeta2 = 0;
            c.MFNoTarjeta2 = "";
            c.MFCodSeg2 = "";
            c.MFExpiracion2 = Convert.ToDateTime("01/01/50");
            c.MFActiva2 = "false";
            c.MFNacional2 = "false";
            c.MFNombre3 = "";  //-----> TARJETA 3
            c.MFIdTarjeta3 = 0;
            c.MFNoTarjeta3 = "";
            c.MFCodSeg3 = "";
            c.MFExpiracion3 = Convert.ToDateTime("01/01/50");
            c.MFActiva3 = "false";
            c.MFNacional3 = "false";
            c.MFNombre4 = "";  //-----> TARJETA 4
            c.MFIdTarjeta4 = 0;
            c.MFNoTarjeta4 = "";
            c.MFCodSeg4 = "";
            c.MFExpiracion4 = Convert.ToDateTime("01/01/50");
            c.MFActiva4 = "false";
            c.MFNacional4 = "false";
            c.MFNombre5 = "";  //-----> TARJETA 5
            c.MFIdTarjeta5 = 0;
            c.MFNoTarjeta5 = "";
            c.MFCodSeg5 = "";
            c.MFExpiracion5 = Convert.ToDateTime("01/01/50");
            c.MFActiva5 = "false";
            c.MFNacional5 = "false";

            c.IdUsuarioAlt = 0;
            c.FecCap = Convert.ToDateTime("01/01/50");
            c.FechorAlt = Convert.ToDateTime("01/01/50");
            c.FecCashOut = Convert.ToDateTime("01/01/50");
            c.idMoneda = 0;
            c.TipoCambio = 0;
            c.FolioPrema = 0;
            c.Relacion = 0;
            c.FechaProceso = Convert.ToDateTime("01/01/50");
            c.FechaCxl = Convert.ToDateTime("01/01/50");
            c.PagarComision = "";
            c.ImporteUpGrade = 0;
            c.ImporteDownGrade = 0;
            c.PagadoUpDown = 0;
            c.PagadoUpDownAE = "";
            c.PorPagadoUpDown = 0;
            c.ImporteDevuelto = 0;
            c.idRazonCxl = 0;
            c.idTipmemCom = 0;
            c.PrecioListaCom = 0;
            c.Semliscom = 0;
            c.TotalRegInc = 0;
            c.TotalRegNoInc = 0;

            c.CargoTC1 = 0;
            c.MensualidadTC1 = ""; //-----> Tarjeta Mensualidad 1
            c.CargoTC2 = 0;
            c.MensualidadTC2 = ""; //-----> Tarjeta Mensualidad 2
            c.CargoTC3 = 0;
            c.MensualidadTC3 = ""; //-----> Tarjeta Mensualidad 3
            c.CargoTC4 = 0;
            c.MensualidadTC4 = ""; //-----> Tarjeta Mensualidad 4

            c.SaldoFinanciado = 0;
            c.NoMensualidadesPagadas = 0;
            c.NoEnganchesDiferidos = 0;
            c.UpGradeTo = 0;
            c.UpGradeFrom = 0;
            c.DownGradeTo = 0;
            c.DownGradeFrom = 0;
            c.PeriodoPago2 = "";
            c.idUsuarioCxl = 0;
            c.FechaLiquidado = Convert.ToDateTime("01/01/50");
            c.FecprimmenActual = Convert.ToDateTime("01/01/50");
            c.idUsuarioCambia = 0;
            c.FecHorCambio = Convert.ToDateTime("01/01/50");
            c.UpGrade = "";
            c.DownGrade = "";
            c.idUsuarioReactiva = 0;
            c.FecHorReactiva = Convert.ToDateTime("01/01/50");
            c.CapturoNomina1 = "";
            c.CapturoNomina2 = "";
            c.PagarComisionesFijas100 = "";
            c.PagarComisionesVLO100 = "";
            c.ExcluirVLO = "";
            c.AgregarEnPeriodo = "";
            c.TieneArreglosM = "";
            c.TipoCalculo = 0;
            c.AgregarEnPeriodoP = "";
            c.NoMensualidadesAdelantadas = 0;
            c.idNegociadoEn = 0;
            c.ccCobradoEquity = "";
            c.idStatusCancelado = 0;
            c.ConsideraEquity = "";
            c.FechaRecibo = Convert.ToDateTime("01/01/50");
            c.ExcepcionPesos = "";
            c.idTipoPersona = 0;
            c.ExcluirAE = "";
            c.ProcesarSEnganche = "";
            c.PrecioVentaUpPesos = 0;
            c.PrecioVentaUpDolares = 0;
            c.NoPagoAgregado = 0;
            c.AgregadoAl = 0;
            c.IdTitulo1 = 0;
            c.IdTitulo2 = 0;
            c.IdFactura = 0;

            c.MFActiva1D = false;//Activa enganche, pestaña de tarjetas //
            c.MFActiva2D = false;
            c.MFActiva3D = false;
            c.MFActiva4D = false;
            c.MFActiva5D = false;

            c.IdFacturaCxL = 0;
            c.Periodicidad = 0;

            c.Email12 = "";
            c.Email13 = "";
            c.Email22 = "";
            c.Email23 = "";

            c.UpGradeSemana = false;
            c.FolioRCI2 = "";
            c.FolioTravelClub = "";
            c.BeneficioMexicanos = false;
            c.TravelTCFL = "";
            c.TopeProcesableFuturo = 0;
            c.ImporteMensualidad2 = 0;
            c.idRegion = 0;
            c.RealClubDestinos = "";
            c.NoMaestro = "";
            c.NoWally = "";
            c.NoWally2 = "";
            c.FolioInterval = "";
            c.Nombre3 = "";
            c.Nombre4 = "";
            c.NombrePais = "";
            c.NombreEstado = "";
            c.NombreCiudad = "";
            c.BeneficioViva = false;
            c.ExcepcionNotificacion = false;

            c.MFNombre6 = "";   //-----> TARJETA 6
            c.MFIdTarjeta6 = 0;
            c.MFNoTarjeta6 = "";
            c.MFCodSeg6 = "";
            c.MFExpiracion6 = Convert.ToDateTime("01/01/50");
            c.MFActiva6 = "";
            c.MFNacional6 = "";
            c.MFNombre7 = "";  //-----> TARJETA 7
            c.MFIdTarjeta7 = 0;
            c.MFNoTarjeta7 = "";
            c.MFCodSeg7 = "";
            c.MFExpiracion7 = Convert.ToDateTime("01/01/50");
            c.MFActiva7 = "";
            c.MFNacional7 = "";
            c.MFNombre8 = "";   //-----> TARJETA 8
            c.MFIdTarjeta8 = 0;
            c.MFNoTarjeta8 = "";
            c.MFCodSeg8 = "";
            c.MFExpiracion8 = Convert.ToDateTime("01/01/50");
            c.MFActiva8 = "";
            c.MFNacional8 = "";
            c.CargoTC5 = 0;
            c.MensualidadTC5 = ""; //-----> Tarjeta Mensualidad 5
            c.CargoTC6 = 0;
            c.MensualidadTC6 = ""; //-----> Tarjeta Mensualidad 6
            c.CargoTC7 = 0;
            c.MensualidadTC7 = ""; //-----> Tarjeta Mensualidad 7
            c.CargoTC8 = 0;
            c.MensualidadTC8 = ""; //-----> Tarjeta Mensualidad 8

            c.FechaAfiliacionInterval = Convert.ToDateTime("01/01/50");
            c.TarjetaEnviada = false;
            c.NumGuiaTarjeta = "";
            c.FechaAfiliacionRCI = Convert.ToDateTime("01/01/50");

            c.IdForpagTC1 = 0;
            c.IdForpagTC2 = 0;
            c.IdForpagTC3 = 0;
            c.IdForpagTC4 = 0;
            c.IdForpagTC5 = 0;
            c.IdForpagTC6 = 0;
            c.IdForpagTC7 = 0;
            c.IdForpagTC8 = 0;
            c.ConfirmaPerderLoPagado = false;
            c.Nombre1Nombres = "";
            c.Nombre1Apellidos = "";
            c.Nombre2Nombres = "";
            c.Nombre2Apellidos = "";
            c.Nombre3Nombres = "";
            c.Nombre3Apellidos = "";
            c.Nombre4Nombres = "";
            c.Nombre4Apellidos = "";

            c.Edad1 = 0;
            c.Edad2 = 0;
            c.EdadHijos = "";
            c.IngresoMensual = 0;
    }

        public int ExisteContrato(int TipCon, int NumCon)
        {
            Existe = 0;

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select FolioContrato from Contratos where idTipcon = @idTipCon and NumCto = @NumCto";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idTipCon", SqlDbType.Int).Value = TipCon;
                    comando.Parameters.Add("@NumCto", SqlDbType.Int).Value = NumCon;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Existe = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                      
                }

                string sql2 = "Delete CSharpPagos where Usr=@Usr";

                using (SqlCommand comando = new SqlCommand(sql2, con))
                {
                    comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }


                con.Close();

                return Existe;

            }
        }

        public int ExisteLeadEnPrema(int lead)
        {
            int ExisteLead = 0;
            string sql = "select distinct Folio from Premanifiesto where Folio = @Lead";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Lead", SqlDbType.Int).Value = lead;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ExisteLead = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }

            return ExisteLead;
        }

        public int VerificaLead(int lead)
        {
            int ExisteLead = 0;
            string sql = "select distinct Lead from Contratos where Lead = @Lead";
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Lead", SqlDbType.Int).Value = lead;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ExisteLead = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }
            return ExisteLead;
        }

        public void LeerContrato(Contratos c)
        {
            Limpiar(c);
            string sql = "select * from Contratos where FolioContrato=@Folio";//idTipcon = @idTipCon and NumCto = @NumCto";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Existe;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                c[reader.GetName(i)] = reader.IsDBNull(i) ? cx.getNullValue(c[reader.GetName(i)]) : reader.GetValue(i);
                            }

                        }
                    }

                    con.Close();


                    adicionales(c);
                    UltimoPagoRealizado(c);
                }

            }

        }

        private void adicionales(Contratos c    )
        {
            tc.LeerTipCon(c.idTipcon);
            TipCon = tc.Iniciales;

            tm.LeerTipMem(c.idTipmem);
            Membresia = tm.Iniciales;
            Temporada = tm.Nombre;
            TipMemIdioma2 = tm.Idioma2;

            cd.LeerCtoDuracion(c.FolioContrato);
            Duracion = cd.DuracionAños == 0 ? tm.DuracionAños : cd.DuracionAños;

            s1.LeerStatus1(c.idStatusCon1);
            Status1 = s1.Nombre;
            Status1Idioma2 = s1.Idioma2;
            Status1Idioma3 = s1.Idioma3;

            s2.LeerStatus2(c.idStatusCon2);
            Status2 = s2.Nombre;

            tipcal.LeerTiposCalculo(c.TipoCalculo);
            TipoCalculo = tipcal.NOmbre;

            ciudad.LeerCiudad(c.idCiudad1);
            idEstado1 = ciudad.idEstado;
            idPais1 = ciudad.idPais;

            ciudad.LeerCiudad(c.idCiudad2);
            idEstado2 = ciudad.idEstado;
            idPais2 = ciudad.idPais;

            if (c.TieneArreglosM == "True")
            {
                NoArregloMax = arr.NoArregloMax(c.FolioContrato);
            }
            else
            { NoArregloMax = 0; }

        }

        public void ModContrato(Contratos cto, string campo, string anterior, string nuevo)
        {
            string sql = nuevo == "" ? "UPDATE Contratos set " + campo + "=null  where FolioContrato = @Folio"  
                              : "UPDATE Contratos set " + campo + "= '" + nuevo +"' where FolioContrato = @Folio";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = cto.FolioContrato;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }

            bita.RegistrarBitacora(cto.FolioContrato, "Contratos", campo, "U", anterior, nuevo);

        }

        public void UltimaMensualidad(Contratos c)//DateTime fecha, Contratos con)
        {
            String FPagos;

            if (c.Plazo > 0)
            {
                for (int i = 0; i < c.Plazo; i++)//limitar plazo a 15              
                {
                    FechaUltiMen = c.FecprimmenActual.AddMonths(i).ToString("d");
                    FPagos = c.FecprimmenActual.AddMonths(i).ToString("d");

                    string sql = "insert into CSharpPagos (Folio,Id1,Fecha1,Importe1,Usr) values(@Folio,@Id1,@Fecha1,@Importe1,@Usr)";

                    using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
                    {
                        conn.Open();

                        using (SqlCommand comando = new SqlCommand(sql, conn))
                        {
                            comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;
                            comando.Parameters.Add("@Id1", SqlDbType.Int).Value = i + 1;
                            comando.Parameters.Add("@Fecha1", SqlDbType.DateTime).Value = Convert.ToDateTime(FPagos);
                            comando.Parameters.Add("@Importe1", SqlDbType.Float).Value = c.ImporteMensualidad;
                            comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                            comando.CommandType = CommandType.Text;
                            comando.ExecuteNonQuery();
                        }

                        conn.Close();
                    }

                    if (i + 1 == 16)
                    {
                        FPag15 = Convert.ToDateTime(FPagos);
                    }

                    if (i + 1 == 31)
                    {
                        FPag30 = Convert.ToDateTime(FPagos);
                    }

                    if (i + 1 == 46)
                    {
                        FPag45 = Convert.ToDateTime(FPagos);
                    }

                }


                if (c.Plazo > 15)
                {
                    Pago2(FPag15, c);

                    if (c.Plazo > 30)
                    {
                        Pago3(FPag30, c);

                        if (c.Plazo > 45)
                        {
                            Pago4(FPag45, c);
                        }
                    }
                }
            }

            else
            {
                FechaUltiMen = Convert.ToString(c.FecprimmenActual);
            }
        }

        public void Pago2(DateTime fecha, Contratos con)
        {
            String FPagos;

            for (int i = 0; i < con.Plazo - 15; i++)
            {
                FPagos = fecha.AddMonths(i).ToString("d");

                string sql = "update CSharpPagos set Id2=@Id,Fecha2=@Fecha,Importe2=@Importe where Folio=@Folio and Id1=@Id1 and Usr=@Usr";

                using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
                {
                    conn.Open();

                    using (SqlCommand comando = new SqlCommand(sql, conn))
                    {
                        comando.Parameters.Add("@Folio", SqlDbType.Int).Value = con.FolioContrato;
                        comando.Parameters.Add("@Id1", SqlDbType.Int).Value = i + 1;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = i + 16;
                        comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(FPagos);
                        comando.Parameters.Add("@Importe", SqlDbType.Float).Value = con.ImporteMensualidad;
                        comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    conn.Close();
                }

            }

        }

        public void Pago3(DateTime fecha, Contratos con)
        {
            String FPagos;

            for (int i = 0; i < con.Plazo - 30; i++)
            {
                FPagos = fecha.AddMonths(i).ToString("d");

                string sql = "update CSharpPagos set Id3=@Id,Fecha3=@Fecha,Importe3=@Importe where Folio=@Folio and Id1=@Id1 and Usr=@Usr";

                using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
                {
                    conn.Open();

                    using (SqlCommand comando = new SqlCommand(sql, conn))
                    {
                        comando.Parameters.Add("@Folio", SqlDbType.Int).Value = con.FolioContrato;
                        comando.Parameters.Add("@Id1", SqlDbType.Int).Value = i + 1;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = i + 31;
                        comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(FPagos);
                        comando.Parameters.Add("@Importe", SqlDbType.Float).Value = con.ImporteMensualidad;
                        comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    conn.Close();
                }

            }

        }

        public void Pago4(DateTime fecha, Contratos con)
        {
            String FPagos;

            for (int i = 0; i < con.Plazo - 45; i++)
            {
                FPagos = fecha.AddMonths(i).ToString("d");

                string sql = "update CSharpPagos set Id4=@Id,Fecha4=@Fecha,Importe4=@Importe where Folio=@Folio and Id1=@Id1 and Usr=@Usr";

                using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
                {
                    conn.Open();

                    using (SqlCommand comando = new SqlCommand(sql, conn))
                    {
                        comando.Parameters.Add("@Folio", SqlDbType.Int).Value = con.FolioContrato;
                        comando.Parameters.Add("@Id1", SqlDbType.Int).Value = i + 1;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = i + 46;
                        comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(FPagos);
                        comando.Parameters.Add("@Importe", SqlDbType.Float).Value = con.ImporteMensualidad;
                        comando.Parameters.Add("@Usr", SqlDbType.Int).Value = Sesion.ID;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    conn.Close();
                }

            }

        }

        public void UltimoPagoRealizado(Contratos c)
        {
            string sql = "selecT FechaPago from Pagos where FolioContrato=@Folio and NoMensualidad=@NoPago and idTippag=3 and Pagado='True' and Cancelado='False'";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = c.FolioContrato;
                    comando.Parameters.Add("@NoPago", SqlDbType.Int).Value = c.NoMensualidadesPagadas;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UltimoPago = reader.IsDBNull(0) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(0);
                        }
                    }

                    con.Close();
                }

            }

        }
    }
}
