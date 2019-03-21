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
using System.Reflection;

namespace OTLC
{
    class Regalos
    {
        Conexion c = new Conexion();
        VisorReportes vr = new VisorReportes();
        RegalosVentas reporte = new RegalosVentas();
        Fechas fecha = new Fechas();
        Bitacora bi = new Bitacora();

        //***********************************REPORTE***********************************//
        public string NumsRegalos { get; set; } // in
        public int Sala { get; set; }
        public int Tipo { get; set; }
        public int OrderBy { get; set; }
        public Boolean sinFolio { get; set; }

        //por consecutivo
        public string ultprim { get; set; } //ultimos desc - primeros asc
        public int topFolio { get; set; } //top
        public int empieza { get; set; } //like
        public int FolIni { get; set; } // between 
        public int FolFin { get; set; } // between 

        //por fechas
        public DateTime FecIni { get; set; }
        public DateTime FecFin { get; set; }

        //opcion seleccionada
        public Boolean Consec { get; set; }
        public Boolean FVenta { get; set; }
        public Boolean FFolio { get; set; }

        private string consulta { get; set; }
        private string texto { get; set; }
        private Boolean ok { get; set; }


        //***********************************REGALO***********************************//
        public int idRegalo { get; set; }
        public int idSalaVta { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
        public string Idioma4 { get; set; }
        public string Idioma5 { get; set; }
        public double CostoA { get; set; }
        public double CostoN { get; set; }
        public string CapturaSeries { get; set; }
        public string SeriePorPax { get; set; }
        public string CapturaFecexp { get; set; }
        public string CapturaRangoFechas { get; set; }
        public string Paquete { get; set; }
        public int idGrupo { get; set; }
        public string IdStatus { get; set; }
        public int idMoneda { get; set; }               
        public int idDivision { get; set; }
        public string ShowRegInc { get; set; }
        public string ShowRegNoInc { get; set; }
        public string ModPrecioVta { get; set; }
        public int idDocto1 { get; set; }
        public int idDocto2 { get; set; }
        public int MinimoEnCaptura { get; set; }
        public int MaximoEnCaptura { get; set; }
        public string BorrarConFolio { get; set; }
        public string PrefijoParaFolioRegalo { get; set; }
        public string ShowInSalas { get; set; }
        public string ShowInTipoVta { get; set; }
        public string Filtro { get; set; }
        public string ShowInPrograma { get; set; }
        public string Desglosar { get; set; }
        public string CapturaSeriesPosterior { get; set; }
        public int IdusuarioAlt { get; set; }
        public DateTime FechorAlt { get; set; }
        public string ShowInLocaciones { get; set; }
        public int idGrupo2 { get; set; }
        public string ShowInTipoContrato { get; set; }
        public string Leyenda1 { get; set; }
        public string Leyenda2 { get; set; }
        public string Leyenda3 { get; set; }
        public string Leyenda4 { get; set; }
        public double CostoANIPV { get; set; }
        public double CostoNNIPV { get; set; }
        public bool EsCertificado { get; set; }
        public bool FolioString { get; set; }

        private string Existe { get; set; }
        public  string RegPaq { get; set; }
        private string ExisteRP { get; set; }



        //************REPORTE************//
        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Regalos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Regalos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        public void RegalosVenta()
        {
            ok = true;
            consulta = "";
            texto = "";
            ultprim = ultprim == "Ultimos" ? "desc" : "asc"; //ultimos=0 desc - primeros=1 asc

            //por consecutivo
            if (Consec == true)
            {
                if (topFolio > 0)
                {
                    consulta = "select Top " + topFolio + " t.Iniciales as TipCon,c.NumCto,c.FechaVta,reg.Nombre as Regalo,(case when r.Tipo=1 then 'Incluido' else 'No Incluido' end) Tipo, r.Folio,(case when r.Cancelado='True' then 'Si' else '' end) Cancelado,r.Cantidad,r.CostoA,(r.Cantidad*r.CostoA) as Total from ContratosRegalos r inner join Contratos c on  r.FolioContrato=c.FolioContrato left join Regalos reg on r.IdRegalo=reg.idRegalo left join TiposContrato t on  c.idTipcon=t.idtipcon";
                    texto = ultprim == "desc"? "-Ultimos: " + topFolio + " folios ":"-Primeros: " + topFolio + " folios ";
                }
                else
                {
                    consulta = "select t.Iniciales as TipCon,c.NumCto,c.FechaVta,reg.Nombre as Regalo,(case when r.Tipo=1 then 'Incluido' else 'No Incluido' end) Tipo, r.Folio,(case when r.Cancelado='True' then 'Si' else '' end) Cancelado,r.Cantidad,r.CostoA,(r.Cantidad*r.CostoA) as Total from ContratosRegalos r inner join Contratos c on  r.FolioContrato=c.FolioContrato left join Regalos reg on r.IdRegalo=reg.idRegalo left join TiposContrato t on c.idTipcon=t.idtipcon";
                }

                if (Sala > 0)
                {
                    consulta = consulta + " where c.idSalaVta=" + Sala;
                }
                else
                { ok = false; }

                if (empieza > 0)
                { consulta = consulta + " and r.FolioContrato like '" + empieza + "%'"; }

                if (FolFin > 1)
                {
                    consulta = consulta + " and r.FolioContrato between " + FolIni + " and " + FolFin;
                    texto = texto + " -Folio del: " + FolIni + " al: " + FolFin;
                }

                if (Tipo == 1 || Tipo == 2)
                {
                    consulta = consulta + " and r.Tipo =" + Tipo;

                    if (Tipo == 1)
                    { texto = texto + " -Tipo: " + "Incluido"; }
                    else if (Tipo == 2)
                    { texto = texto + " -Tipo: " + "No Incluido"; }
                    else
                    { texto = texto + " -Tipo: " + "Todos"; }
                }

                if (sinFolio == false)
                {
                    consulta = consulta + " and r.Folio is not null";
                    texto = texto + " -Regalos con Folio";
                }

                if (NumsRegalos != "")
                { consulta = consulta + " and r.IdRegalo in (" + NumsRegalos + ")"; }

                if (OrderBy == 1)
                {
                    consulta = consulta + " order by reg.Nombre " + ultprim;
                }
                else if (OrderBy == 2)
                {
                    consulta = consulta + " order by c.NumCto " + ultprim;
                }
                else
                {
                    consulta = consulta + " order by r.Folio " + ultprim;
                }

            }
            else if (FVenta == true || FFolio == true)
            {
                consulta = "select t.Iniciales as TipCon,c.NumCto,c.FechaVta,reg.Nombre as Regalo,(case when r.Tipo=1 then 'Incluido' else 'No Incluido' end) Tipo, r.Folio,(case when r.Cancelado='True' then 'Si' else '' end) Cancelado,r.Cantidad,r.CostoA,(r.Cantidad*r.CostoA) as Total from ContratosRegalos r inner join Contratos c on  r.FolioContrato=c.FolioContrato left join Regalos reg on r.IdRegalo=reg.idRegalo left join TiposContrato t on c.idTipcon=t.idtipcon";

                if (Sala > 0)
                { consulta = consulta + " where c.idSalaVta=" + Sala; }
                else
                { ok = false; }

                if (FVenta == true)
                {
                    consulta = consulta + " and c.FechaVta between " + "'" + FecIni.ToString("yyyyMMdd") + "'" + " and " + "'" + FecFin.ToString("yyyyMMdd") + "'";
                    texto = texto + " -Fecha de Venta del: " + FecIni.ToString("d") + " al: " + FecFin.ToString("d");
                }

                if (FFolio == true)
                {
                    consulta = consulta + " and r.FechorAlt between " + "'" + FecIni.ToString("yyyyMMdd") + "'" + " and " + "'" + FecFin.ToString("yyyyMMdd") + "'";
                    texto = texto + " -Fecha de Captura del: " + FecIni.ToString("d") + " al: " + FecFin.ToString("d");
                }

                if (Tipo == 1 || Tipo == 2)
                {
                    consulta = consulta + " and r.Tipo =" + Tipo;
                    if (Tipo == 1)
                    { texto = texto + " -Tipo: " + "Incluido"; }
                    else if (Tipo == 2)
                    { texto = texto + " -Tipo: " + "No Incluido"; }
                    else
                    { texto = texto + " -Tipo: " + "Todos"; }
                }

                if (sinFolio == false)
                { consulta = consulta + " and r.Folio is not null"; }

                if (NumsRegalos != "")
                { consulta = consulta + " and r.IdRegalo in (" + NumsRegalos + ")"; }

                if (OrderBy == 1)
                {
                    consulta = consulta + " order by reg.Nombre " + ultprim;
                }
                else if (OrderBy == 2)
                {
                    consulta = consulta + " order by c.NumCto " + ultprim;
                }
                else
                {
                    consulta = consulta + " order by r.Folio " + ultprim;
                }
            }
            else
            {
                consulta = "select t.Iniciales as TipCon,c.NumCto,c.FechaVta,reg.Nombre as Regalo,(case when r.Tipo=1 then 'Incluido' else 'No Incluido' end) Tipo, r.Folio,(case when r.Cancelado='True' then 'Si' else '' end) Cancelado,r.Cantidad,r.CostoA,(r.Cantidad*r.CostoA) as Total from ContratosRegalos r inner join Contratos c on  r.FolioContrato=c.FolioContrato left join Regalos reg on r.IdRegalo=reg.idRegalo left join TiposContrato t on c.idTipcon=t.idtipcon ";

                if (Sala > 0)
                { consulta = consulta + " where c.idSalaVta=" + Sala; }
                else
                { ok = false; }

                if (Tipo == 1 || Tipo == 2)
                {
                    consulta = consulta + " and r.Tipo =" + Tipo;
                    if (Tipo == 1)
                    { texto = texto + " -Tipo: " + "Incluido"; }
                    else if (Tipo == 2)
                    { texto = texto + " -Tipo: " + "No Incluido"; }
                    else
                    { texto = texto + " -Tipo: " + "Todos"; }
                }

                if (sinFolio == false)
                { consulta = consulta + " and r.Folio is not null"; }

                if (NumsRegalos != "")
                { consulta = consulta + " and r.IdRegalo in (" + NumsRegalos + ")"; }

                if (OrderBy == 1)
                {
                    consulta = consulta + " order by reg.Nombre " + ultprim;
                }
                else if (OrderBy == 2)
                {
                    consulta = consulta + " order by c.NumCto " + ultprim;
                }
                else
                {
                    consulta = consulta + " order by r.Folio " + ultprim;
                }
            }


            if (ok == false)
            {
                MessageBox.Show("Favor de verificar los filtros seleccionados");
                consulta = "";
            }
            else
            {
                string sql = consulta;

                using (SqlConnection con = new SqlConnection(c.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable("RegalosVenta");

                        da.Fill(dt);
                        reporte.SetDataSource(dt);

                        con.Close();
                    }

                }


                string ThisDay = "";
                fecha.GeneraFecha(DateTime.Today, 1);
                ThisDay = fecha.LetrasDia + ", " + fecha.NumDia + " DE " + fecha.LetrasMes + " DE " + fecha.Año;

                reporte.SetParameterValue("ThisDay", ThisDay);
                reporte.SetParameterValue("text", texto);
                // reporte.SetParameterValue("Texto", texto);
                vr = new VisorReportes(reporte);

                vr.ShowDialog();

            }

        }

        public void Limpiar()
        {
            consulta = "";
            NumsRegalos = "";
            Sala = 0;
            Tipo = 0;
            OrderBy = 0;
            sinFolio = false;
            ultprim = "";
            topFolio = 0;
            empieza = 0;
            FolIni = 0;
            FolFin = 0;
            FecIni = DateTime.Today;
            FecFin = DateTime.Today;
            Consec = false;
            FVenta = false;
            FFolio = false;
        }


        //************REGALO**************//
        private void ExisteRegalo()
        {
            string sql = "select DISTINCT 'SI' from Regalos where idRegalo = @idRegalo";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idRegalo", SqlDbType.Int).Value = idRegalo;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Existe = reader.IsDBNull(0) ? "NO" : Existe = reader.GetString(0);
                        }
                    }

                    con.Close();
                }

            }
        }

        public void LeerRegalo()
        {
            LimpiarRegalo();
            ExisteRegalo();

            if (Existe == "NO")
            {
                MessageBox.Show("No se encontro Regalo con la Clave "+idRegalo);
            }

            else
            {
                string sql = "select Nombre, NombreCorto, Idioma2, idGrupo, idMoneda, CostoA, CapturaSeries, CapturaFecexp, Paquete,CapturaRangoFechas, IdStatus, idDivision, ShowRegInc, ShowRegNoInc, ModPrecioVta, idDocto1, idDocto2 from Regalos where idRegalo = @IdRegalo";

                using (SqlConnection con = new SqlConnection(c.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@IdRegalo", SqlDbType.Int).Value = idRegalo;

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    this[reader.GetName(i)] = reader.IsDBNull(i) ? c.getNullValue(this[reader.GetName(i)]) : reader.GetValue(i);
                                }
                            }

                        }

                        con.Close();

                    }

                }

            }
        }

        private void LimpiarRegalo()
        {
            idSalaVta = 0;
            Nombre = "";
            NombreCorto = "";
            Idioma2 = "";
            Idioma3 = "";
            Idioma4 = "";
            Idioma5 = "";
            CostoA = 0;
            CostoN = 0;
            CapturaSeries = "";
            SeriePorPax = "";
            CapturaFecexp = "";
            CapturaRangoFechas = "";
            Paquete = "false";
            idGrupo = 0;
            IdStatus = "";
            idMoneda = 0;
            idDivision = 0;
            ShowRegInc = "false";
            ShowRegNoInc = "false";
            ModPrecioVta = "false";
            idDocto1 = 0;
            idDocto2 = 0;
            MinimoEnCaptura = 0;
            MaximoEnCaptura = 0;
            BorrarConFolio = "";
            PrefijoParaFolioRegalo = "";
            ShowInSalas = "";
            ShowInTipoVta = "";
            Filtro = "";
            ShowInPrograma = "";
            Desglosar = "";
            CapturaSeriesPosterior = "";
            IdusuarioAlt = 0;
            FechorAlt = Convert.ToDateTime("01/01/50");
            ShowInLocaciones = "";
            idGrupo2 = 0;
            ShowInTipoContrato = "";
            Leyenda1 = "";
            Leyenda2 = "";
            Leyenda3 = "";
            Leyenda4 = "";
            CostoANIPV = 0;
            CostoNNIPV = 0;
            EsCertificado = false;
            FolioString = false;
        }

        public void RegPaquete(int reg, double cant)
        {
            ExisteRP = "";
            string sql = "select DISTINCT 'SI' from RegalosPaquetes where IdRegaloPaq = @IdRegaloPaq and IdRegalo=@IdRegalo";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdRegaloPaq", SqlDbType.Int).Value = idRegalo;
                    comando.Parameters.Add("@IdRegalo", SqlDbType.Int).Value = reg;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0))
                            { ExisteRP = "NO"; }
                            else
                            { ExisteRP = reader.GetString(0); }
                        }
                    }
                    con.Close();
                }
            }
        
            if (RegPaq == "A")
            {
                if (ExisteRP == "SI")
                {
                    RegPaqModificar(reg, cant);
                }
                else
                {
                    RegPaqAgregar(reg, cant);
                }
            }

            if (RegPaq =="D")
            {
                if (ExisteRP == "SI")
                {
                    RegPaqEliminar(reg);
                }
                else
                {
                    MessageBox.Show("No se encontro registro para eliminar");
                }
            }
        }

        private void RegPaqAgregar( int reg, double cant)
        {            
            bi.RegistrarBitacora(200000, "RegalosPaquetes","Registro Nuevo","I","", "IdRegaloPaq: "+idRegalo+", IdRegalo: "+reg+", Cantidad: "+cant);

            string sql = "insert into RegalosPaquetes (IdRegaloPaq,IdRegalo,Cantidad,IdUsuarioAlt,FechorAlt) values (@IdRegaloPaq,@IdRegalo,@Cantidad,@IdUsuarioAlt,@FechorAlt)";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdRegaloPaq", SqlDbType.Int).Value = idRegalo;
                    comando.Parameters.Add("@IdRegalo", SqlDbType.Int).Value = reg;
                    comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cant;
                    comando.Parameters.Add("@IdUsuarioAlt", SqlDbType.Int).Value = Sesion.ID;
                    comando.Parameters.Add("@FechorAlt", SqlDbType.DateTime).Value = DateTime.Today;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        private void RegPaqModificar(int reg, double cant)
        {
            //optiene cantidad anterior
            double cantidad=0;
            string sql10 = "select Cantidad from RegalosPaquetes where IdRegaloPaq = @IdRegaloPaq and IdRegalo=@IdRegalo";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql10, con))
                {
                    comando.Parameters.Add("@IdRegaloPaq", SqlDbType.Int).Value = idRegalo;
                    comando.Parameters.Add("@IdRegalo", SqlDbType.Int).Value = reg;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0))
                            { cantidad = 0; }
                            else
                            { cantidad = reader.GetDouble(0); }
                        }
                    }
                    con.Close();
                }
            }

            bi.RegistrarBitacora(200002, "RegalosPaquetes", "Registro Modificado", "U", "IdRegaloPaq: " + idRegalo + ", IdRegalo: " + reg + ", Cantidad: " + cantidad, "IdRegaloPaq: " + idRegalo + ", IdRegalo: " + reg + ", Cantidad: " + cant);


            string sql = "Update RegalosPaquetes set Cantidad=@Cantidad where IdRegaloPaq=@IdRegaloPaq and IdRegalo=@IdRegalo";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdRegaloPaq", SqlDbType.Int).Value = idRegalo;
                    comando.Parameters.Add("@IdRegalo", SqlDbType.Int).Value = reg;
                    comando.Parameters.Add("@Cantidad", SqlDbType.Float).Value = cant;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        private void RegPaqEliminar(int reg)
        {
            bi.RegistrarBitacora(200001, "RegalosPaquetes", "Registro Eliminado", "D", "IdRegaloPaq: " + idRegalo + ", IdRegalo: " + reg,"");

            string sql = "delete RegalosPaquetes where IdRegaloPaq=@IdRegaloPaq and IdRegalo=@IdRegalo";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdRegaloPaq", SqlDbType.Int).Value = idRegalo;
                    comando.Parameters.Add("@IdRegalo", SqlDbType.Int).Value = reg;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }      

        }   

        public void AgregarRegalos(string accion)
        {

            if (accion == "M")
            {
                string sql = "Update Regalos set Nombre=@Nombre,NombreCorto=@NombreCorto,Idioma2=@Idioma2,CostoA=@CostoA,CapturaSeries=@CapturaSeries,CapturaFecexp=@CapturaFecexp,CapturaRangoFechas=@CapturaRangoFechas,Paquete= @Paquete,idGrupo= @idGrupo,IdStatus= @IdStatus,idMoneda= @idMoneda,idDivision= @idDivision,ShowRegInc= @ShowRegInc,ShowRegNoInc= @ShowRegNoInc,ModPrecioVta= @ModPrecioVta,idDocto1= @idDocto1,idDocto2= @idDocto2,CostoANIPV= @CostoA where idRegalo = @idRegalo";
                using (SqlConnection con = new SqlConnection(c.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@idRegalo", SqlDbType.Int).Value = idRegalo;
                        comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                        comando.Parameters.Add("@NombreCorto", SqlDbType.VarChar).Value = NombreCorto;
                        comando.Parameters.Add("@Idioma2", SqlDbType.VarChar).Value = Idioma2;
                        comando.Parameters.Add("@CostoA", SqlDbType.Float).Value = CostoA;
                        comando.Parameters.Add("@CapturaSeries", SqlDbType.VarChar).Value = CapturaSeries;
                        comando.Parameters.Add("@CapturaFecexp", SqlDbType.VarChar).Value = CapturaFecexp;
                        comando.Parameters.Add("@CapturaRangoFechas", SqlDbType.VarChar).Value = CapturaRangoFechas;
                        comando.Parameters.Add("@Paquete", SqlDbType.VarChar).Value = Paquete;
                        comando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;
                        comando.Parameters.Add("@IdStatus", SqlDbType.VarChar).Value = IdStatus;
                        comando.Parameters.Add("@idMoneda", SqlDbType.Int).Value = idMoneda;
                        comando.Parameters.Add("@idDivision", SqlDbType.Int).Value = idDivision;
                        comando.Parameters.Add("@ShowRegInc", SqlDbType.VarChar).Value = ShowRegInc;
                        comando.Parameters.Add("@ShowRegNoInc", SqlDbType.VarChar).Value = ShowRegNoInc;
                        comando.Parameters.Add("@ModPrecioVta", SqlDbType.VarChar).Value = ModPrecioVta;
                        comando.Parameters.Add("@idDocto1", SqlDbType.Int).Value = idDocto1;
                        comando.Parameters.Add("@idDocto2", SqlDbType.Int).Value = idDocto2;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }

                MessageBox.Show("¡Se modifico el regalo " + Nombre + " correctamente!");

            }
            else
            {
                idRegalo = 0;
                string sql = "select MAX(idRegalo) from Regalos";

                using (SqlConnection con = new SqlConnection(c.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                idRegalo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            }
                        }

                        con.Close();
                    }

                }

                idRegalo = idRegalo + 1;

                string sql2 = "insert into Regalos(idRegalo, idSalaVta, Nombre, NombreCorto, Idioma2, Idioma3, Idioma4, Idioma5, CostoA, CostoN, CapturaSeries, SeriePorPax, CapturaFecexp, CapturaRangoFechas,Paquete, idGrupo, IdStatus, idMoneda, idDivision, ShowRegInc, ShowRegNoInc, ModPrecioVta, idDocto1, idDocto2, MinimoEnCaptura, MaximoEnCaptura, BorrarConFolio,PrefijoParaFolioRegalo, ShowInSalas, ShowInTipoVta, Filtro, ShowInPrograma, Desglosar, CapturaSeriesPosterior, IdusuarioAlt, FechorAlt, ShowInLocaciones, idGrupo2, ShowInTipoContrato, Leyenda1, Leyenda2, Leyenda3, Leyenda4, CostoANIPV, CostoNNIPV, EsCertificado, FolioString) VALUES (@idRegalo, '1', @Nombre, @NombreCorto, @Idioma2, NULL, NULL, NULL,@CostoA, '0', @CapturaSeries, 'False', @CapturaFecexp, @CapturaRangoFechas,@Paquete, @idGrupo, @IdStatus, @idMoneda, @idDivision, @ShowRegInc, @ShowRegNoInc, @ModPrecioVta,@idDocto1, @idDocto2, 1, 1, 'True', NULL, ',1,2,3,', ',1,2,', NULL, NULL, 'False', 'False', @IdusuarioAlt, @FechorAlt,NULL, 1, NULL, NULL, NULL, NULL, NULL, @CostoA, 0, 0, 0)";
                using (SqlConnection con = new SqlConnection(c.cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql2, con))
                    {
                        comando.Parameters.Add("@idRegalo", SqlDbType.Int).Value = idRegalo;
                        comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                        comando.Parameters.Add("@NombreCorto", SqlDbType.VarChar).Value = NombreCorto;
                        comando.Parameters.Add("@Idioma2", SqlDbType.VarChar).Value = Idioma2;
                        comando.Parameters.Add("@CostoA", SqlDbType.Float).Value = CostoA;
                        comando.Parameters.Add("@CapturaSeries", SqlDbType.VarChar).Value = CapturaSeries;
                        comando.Parameters.Add("@CapturaFecexp", SqlDbType.VarChar).Value = CapturaFecexp;
                        comando.Parameters.Add("@CapturaRangoFechas", SqlDbType.VarChar).Value = CapturaRangoFechas;
                        comando.Parameters.Add("@Paquete", SqlDbType.VarChar).Value =Paquete;
                        comando.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;
                        comando.Parameters.Add("@IdStatus", SqlDbType.VarChar).Value = IdStatus;
                        comando.Parameters.Add("@idMoneda", SqlDbType.Int).Value = idMoneda;
                        comando.Parameters.Add("@idDivision", SqlDbType.Int).Value = idDivision;
                        comando.Parameters.Add("@ShowRegInc", SqlDbType.VarChar).Value = ShowRegInc;
                        comando.Parameters.Add("@ShowRegNoInc", SqlDbType.VarChar).Value = ShowRegNoInc;
                        comando.Parameters.Add("@ModPrecioVta", SqlDbType.VarChar).Value = ModPrecioVta;
                        comando.Parameters.Add("@idDocto1", SqlDbType.Int).Value = idDocto1;
                        comando.Parameters.Add("@idDocto2", SqlDbType.Int).Value = idDocto2;
                        comando.Parameters.Add("@IdusuarioAlt", SqlDbType.Int).Value = Sesion.ID;
                        comando.Parameters.Add("@FechorAlt", SqlDbType.DateTime).Value = DateTime.Today;

                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }

                MessageBox.Show("¡Se agrego el regalo "+Nombre+" correctamente!");
            }


        }
               



        

    }
}
