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
    public class AsignaPermisos
    {
        Conexion c = new Conexion();

        //  P E R M I S O S
        public  bool EmpresaAcc { get; set; }
        public  bool EmpresaMod { get; set; }
        public  bool ContratosAcc { get; set; }
        public  bool ContratosMod { get; set; }
        public  bool ContratosModGeneral { get; set; }
        public  bool ContratosModStatus1 { get; set; }
        public  bool ContratosModTarjetas { get; set; }
        public  bool ContratosModVentas { get; set; }
        public  bool ContratosRep { get; set; }
        public  bool ContratosRegalos { get; set; }
        public  bool ContratosRegalosRep { get; set; }
        public  bool ContratosRegalosCat { get; set; }
        public  bool CobranzaAcc { get; set; }
        public  bool CobranzaReestructura { get; set; }
        public  bool CobranzaAplicarPagos { get; set; }
        public  bool CobranzaPagoCapital { get; set; }
        public  bool CobranzaPagoContrato { get; set; }
        public  bool CobranzaPagoEnganche { get; set; }
        public  bool EstadisticasAcc { get; set; }
        public  bool EstadisticasTablaGralCtos { get; set; }
        public  bool AsignarPermisosAcc { get; set; }
        public  bool ReservacionesAcc { get; set; }
        public  bool ReservacionesMod { get; set; }
        public  bool ReservacionesPtosNuevoAño { get; set; }
        public  bool ReservacionesEdoPuntos { get; set; }
        public  bool ReservacionesCumpleaños { get; set; }
        public  bool ReservacionesPorcentajes { get; set; }

        private int noPermSist { get; set; }
        private int noPermUsr { get; set; }

        public void LeerPermisos(int idUsr)
        {
            Limpiar();
            SeleccionarPermisos(idUsr);
        }

        public string VerificarUsuario(int idUsr)
        {
            string Existe = "";

            string sql = "select DISTINCT 'SI' from CSharpUsuarios where US_ID=@usr and US_STATUS='A'";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.VarChar).Value = idUsr;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Existe = reader.IsDBNull(0) ? "NO" : reader.GetString(0);
                        }
                    }
                }

                con.Close();
            }
            return Existe;
        }

        public void GrabarPermisos(Usuarios usr)
        {

            if (VerificarUsuario(usr.idUsuario) == "SI")
            {
                verificaNoPermisos(usr.idUsuario);
                if (noPermSist == noPermUsr)
                {
                    ModificarPermisos(usr.idUsuario);
                }
                else
                {
                    DeletePermisos(usr.idUsuario);
                    InsertarPermisos(usr.idUsuario);
                }
            }
            else
            {
                AltaUsuario(usr);
                InsertarPermisos(usr.idUsuario);
            }
        }

        private void Limpiar()
        {
            EmpresaAcc = false;
            EmpresaMod = false;
            ContratosAcc = false;
            ContratosMod = false;
            ContratosModGeneral = false;
            ContratosModStatus1 = false;
            ContratosModTarjetas = false;
            ContratosModVentas = false;
            ContratosRep = false;
            ContratosRegalos = false;
            ContratosRegalosRep = false;
            ContratosRegalosCat = false;
            CobranzaAcc = false;
            CobranzaReestructura = false;
            CobranzaAplicarPagos = false;
            CobranzaPagoCapital = false;
            CobranzaPagoContrato = false;
            CobranzaPagoEnganche = false;
            EstadisticasAcc = false;
            EstadisticasTablaGralCtos = false;
            AsignarPermisosAcc = false;
            ReservacionesAcc = false;
            ReservacionesMod = false;
            ReservacionesEdoPuntos = false;
            ReservacionesPtosNuevoAño = false;
            ReservacionesCumpleaños = false;
            ReservacionesPorcentajes = false;
        }

        private void verificaNoPermisos(int idUsr)
        {
            noPermUsr  = 0;
            noPermSist = 0;

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                string sql = "select COUNT(CU_USUARIO)from CSharpUsuariosPermisos where CU_USUARIO=@usr";
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.VarChar).Value = idUsr;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {  noPermUsr = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);   }
                    }
                }

                string sql2 = "select COUNT(*) from CSharpPermisos";
                using (SqlCommand comando = new SqlCommand(sql2, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {  noPermSist = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);  }
                    }
                }
                con.Close();
            }
        }

        //----- L E E R * P E R M I S O S ----//
        private void SeleccionarPermisos(int idUsr)
        {
            EmpresaAcc              = SelectPermiso(idUsr, 100);    // EMPRESA      100	ACCESO
            EmpresaMod              = SelectPermiso(idUsr, 101);    // EMPRESA	    101	MODIFICAR
            ContratosAcc            = SelectPermiso(idUsr, 200);    // CONTRATOS    200	ACCESO
            ContratosModGeneral     = SelectPermiso(idUsr, 201);    // CONTRATOS    201 MODIFICAR INF GENERAL
            ContratosModTarjetas    = SelectPermiso(idUsr, 202);    // CONTRATOS    202 MODIFICAR INF TARJETAS
            ContratosModVentas      = SelectPermiso(idUsr, 203);    // CONTRATOS    203 MODIFICAR INF VENTAS
            ContratosRep            = SelectPermiso(idUsr, 204);    // CONTRATOS    204 REPORTES
            ContratosRegalosRep     = SelectPermiso(idUsr, 205);    // CONTRATOS    205	REGALOS DE VENTA REPORTE
            ContratosRegalosCat     = SelectPermiso(idUsr, 206);    // CONTRATOS    206	REGALOS DE VENTA CATALOGO
            ContratosModStatus1     = SelectPermiso(idUsr, 207);    // CONTRATOS    207 MODIFICAR INF GENERAL status1
            CobranzaAcc             = SelectPermiso(idUsr, 300);    // COBRANZA	    300	ACCESO
            CobranzaReestructura    = SelectPermiso(idUsr, 301);    // COBRANZA	    301	REESTRUCTURAR
            CobranzaAplicarPagos    = SelectPermiso(idUsr, 302);    // COBRANZA	    302	APLICAR PAGOS
            CobranzaPagoCapital     = SelectPermiso(idUsr, 303);    // COBRANZA	    303	PAGO A CAPITAL
            CobranzaPagoContrato    = SelectPermiso(idUsr, 304);    // COBRANZA	    304	COSTO DE CONTRATO
            CobranzaPagoEnganche    = SelectPermiso(idUsr, 305);    // COBRANZA	    305	PAGO DE ENGANCHES
            EstadisticasAcc         = SelectPermiso(idUsr, 400);    // ESTADISTICAS	    400	ACCESO
            EstadisticasTablaGralCtos= SelectPermiso(idUsr,401);    // ESTADISTICAS     401 EstadisticasTablaGralCtos
            AsignarPermisosAcc      = SelectPermiso(idUsr, 500);    // PERMISOS	        500	ACCESO
            ReservacionesAcc        = SelectPermiso(idUsr, 600);    // RESERVACIONES	600	ACCESO
            ReservacionesMod        = SelectPermiso(idUsr, 601);    // RESERVACIONES	601	MODIFICAR DURACION CONTRATO
            ReservacionesEdoPuntos  = SelectPermiso(idUsr, 602);    // RESERVACIONES	602	GENERAR ESTADO DE PUNTOS
            ReservacionesPtosNuevoAño= SelectPermiso(idUsr, 603);   // RESERVACIONES	603	ALTA PUNTOS NUEVO AÑO
            ReservacionesCumpleaños = SelectPermiso(idUsr, 604);    // RESERVACIONES	604	LISTA DE CUMPLEAÑOS SOCIOS
            ReservacionesPorcentajes = SelectPermiso(idUsr, 605);   // RESERVACIONES	605	REPORTE PPORCENTAJES

            if (ContratosModGeneral == true || ContratosModTarjetas == true || ContratosModVentas == true)
            {
                ContratosMod = true;         
            }

            if (ContratosRegalosRep == true || ContratosRegalosCat == true)
            {
                ContratosRegalos = true;
            }
        }

        private bool SelectPermiso(int idUsr, int numero)
        {
           bool valor = false;

            string sql = "select distinct CU_PERMISO from CSharpUsuariosPermisos where CU_USUARIO=@usr and CU_PROGRAMA=@num";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.VarChar).Value = idUsr;
                    comando.Parameters.Add("@num", SqlDbType.VarChar).Value = numero;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            valor = reader.IsDBNull(0) ? false : reader.GetBoolean(0);
                        }
                    }
                }
                con.Close();
            }

            return valor;
        }

        //------- I N S E R T A R  ------//
        private void AltaUsuario(Usuarios usr)
        {
            //insert into CSharpUsuarios (US_ID,US_NOMBRE,US_USR,US_PWD,US_PUESTO,US_DEPTO,US_HOTEL,US_STATUS,US_USRALT,US_FECHAALT) values()
            string sql = "insert into CSharpUsuarios (US_ID,US_NOMBRE,US_USR,US_PWD,US_PUESTO,US_DEPTO,US_HOTEL,US_STATUS,US_USRALT,US_FECHAALT) values(@ID,@NOMBRE,@USR,@PWD,@PUESTO,@DEPTO,@HOTEL,'A',@USRALT,@FECHA)";

            using (SqlConnection conn = new SqlConnection(c.cadenaConexion))
            {
                conn.Open();

                using (SqlCommand comando = new SqlCommand(sql, conn))
                {
                    comando.Parameters.Add("@ID", SqlDbType.Int).Value = usr.idUsuario;//con.UsrId;
                    comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = usr.Nombre;//con.UsrNombre;
                    comando.Parameters.Add("@USR", SqlDbType.VarChar).Value = usr.Iniciales;//con.UsrIniciales;
                    comando.Parameters.Add("@PWD", SqlDbType.VarChar).Value = usr.Contra;//con.UsrContra;
                    comando.Parameters.Add("@PUESTO", SqlDbType.Int).Value = usr.IdPuesto;// con.UsrIdPuesto;
                    comando.Parameters.Add("@DEPTO", SqlDbType.Int).Value = usr.IdDepto;// con.UsrIdDepartamento;
                    comando.Parameters.Add("@HOTEL", SqlDbType.Int).Value = usr.IdHotel;// con.UsrIdHotel;
                    comando.Parameters.Add("@USRALT", SqlDbType.Int).Value = Sesion.ID;
                    comando.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = DateTime.Today;//thisDay;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        private void InsertarPermisos(int idUsr)
        {
            InsertPermiso(idUsr, 100, EmpresaAcc);                  // EMPRESA          100	ACCESO
            InsertPermiso(idUsr, 101, EmpresaMod);                  // EMPRESA          101 MODIFICAR
            InsertPermiso(idUsr, 200, ContratosAcc);                // CONTRATOS	    200 ACCESO
            InsertPermiso(idUsr, 201, ContratosModGeneral);         // CONTRATOS        201 MODIFICAR INF GENERAL
            InsertPermiso(idUsr, 202, ContratosModTarjetas);        // CONTRATOS        202 MODIFICAR INF TARJETAS
            InsertPermiso(idUsr, 203, ContratosModVentas);          // CONTRATOS        203 MODIFICAR INF VENTAS
            InsertPermiso(idUsr, 204, ContratosRep);                // CONTRATOS        204 REPORTES
            InsertPermiso(idUsr, 205, ContratosRegalosRep);         // CONTRATOS        205	REGALOS DE VENTA REPORTE
            InsertPermiso(idUsr, 206, ContratosRegalosCat);         // CONTRATOS        206	REGALOS DE VENTA CATALOGO
            InsertPermiso(idUsr, 207, ContratosModStatus1);         // CONTRATOS        207 MODIFICAR INF GENERAL status1
            InsertPermiso(idUsr, 300, CobranzaAcc);                 // COBRANZA	        300	ACCESO
            InsertPermiso(idUsr, 301, CobranzaReestructura);        // COBRANZA	        301	REESTRUCTURAR
            InsertPermiso(idUsr, 302, CobranzaAplicarPagos);        // COBRANZA	        302	APLICAR PAGOS
            InsertPermiso(idUsr, 303, CobranzaPagoCapital);         // COBRANZA	        303	PAGO A CAPITAL
            InsertPermiso(idUsr, 304, CobranzaPagoContrato);        // COBRANZA	        304	COSTO DE CONTRATO
            InsertPermiso(idUsr, 305, CobranzaPagoEnganche);        // COBRANZA	        305	PAGO DE ENGANCHES
            InsertPermiso(idUsr, 400, EstadisticasAcc);             // ESTADISTICAS	    400	ACCESO
            InsertPermiso(idUsr, 401, EstadisticasTablaGralCtos);   // ESTADISTICAS     401 EstadisticasTablaGralCtos
            InsertPermiso(idUsr, 500, AsignarPermisosAcc);          // PERMISOS	        500	ACCESO
            InsertPermiso(idUsr, 600, ReservacionesAcc);            // RESERVACIONES	600	ACCESO
            InsertPermiso(idUsr, 601, ReservacionesMod);            // RESERVACIONES	601	MODIFICAR DURACION CONTRATO
            InsertPermiso(idUsr, 602, ReservacionesEdoPuntos);      // RESERVACIONES	602	GENERAR ESTADO DE PUNTOS
            InsertPermiso(idUsr, 603, ReservacionesPtosNuevoAño);   // RESERVACIONES	603	ALTA PUNTOS NUEVO AÑO
            InsertPermiso(idUsr, 604, ReservacionesCumpleaños);     // RESERVACIONES	604	LISTA DE CUMPLEAÑOS SOCIOS
            InsertPermiso(idUsr, 605, ReservacionesPorcentajes);    // RESERVACIONES	605	REPORTE PORCENTAJES
        }

        private void InsertPermiso(int idUsr,int numero, bool permiso )
        {
            string sql1 = "insert into CSharpUsuariosPermisos (CU_USUARIO,CU_PROGRAMA,CU_PERMISO,CU_USRALT) "+
                          "values (@usr,@num,@permiso,@USRALT)";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql1, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.Int).Value = idUsr;
                    comando.Parameters.Add("@num", SqlDbType.Int).Value = numero;
                    comando.Parameters.Add("@permiso", SqlDbType.Int).Value = permiso;
                    comando.Parameters.Add("@USRALT", SqlDbType.Int).Value = Sesion.ID;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        //-------- U P D A T E  --------//
        private void ModificarPermisos(int idUsr)
        {
            UpdatePermiso(idUsr, 100, EmpresaAcc);                  // EMPRESA          100	ACCESO
            UpdatePermiso(idUsr, 101, EmpresaMod);                  // EMPRESA          101 MODIFICAR
            UpdatePermiso(idUsr, 200, ContratosAcc);                // CONTRATOS	    200 ACCESO
            UpdatePermiso(idUsr, 201, ContratosModGeneral);         // CONTRATOS        201 MODIFICAR INF GENERAL
            UpdatePermiso(idUsr, 202, ContratosModTarjetas);        // CONTRATOS        202 MODIFICAR INF TARJETAS
            UpdatePermiso(idUsr, 203, ContratosModVentas);          // CONTRATOS        203 MODIFICAR INF VENTAS
            UpdatePermiso(idUsr, 204, ContratosRep);                // CONTRATOS        204 REPORTES
            UpdatePermiso(idUsr, 205, ContratosRegalosRep);         // CONTRATOS        205	REGALOS DE VENTA REPORTE
            UpdatePermiso(idUsr, 206, ContratosRegalosCat);         // CONTRATOS        206	REGALOS DE VENTA CATALOGO        
            UpdatePermiso(idUsr, 207, ContratosModStatus1);         // CONTRATOS        207 MODIFICAR INF GENERAL status1
            UpdatePermiso(idUsr, 300, CobranzaAcc);                 // COBRANZA	        300	ACCESO
            UpdatePermiso(idUsr, 301, CobranzaReestructura);        // COBRANZA	        301	REESTRUCTURAR
            UpdatePermiso(idUsr, 302, CobranzaAplicarPagos);        // COBRANZA	        302	APLICAR PAGOS
            UpdatePermiso(idUsr, 303, CobranzaPagoCapital);         // COBRANZA	        303	PAGO A CAPITAL
            UpdatePermiso(idUsr, 304, CobranzaPagoContrato);        // COBRANZA	        304	COSTO DE CONTRATO
            UpdatePermiso(idUsr, 305, CobranzaPagoEnganche);        // COBRANZA	        305	PAGO DE ENGANCHES
            UpdatePermiso(idUsr, 400, EstadisticasAcc);             // ESTADISTICAS	    400	ACCESO
            UpdatePermiso(idUsr, 401, EstadisticasTablaGralCtos);   // ESTADISTICAS     401 EstadisticasTablaGralCtos
            UpdatePermiso(idUsr, 500, AsignarPermisosAcc);          // PERMISOS	        500	ACCESO
            UpdatePermiso(idUsr, 600, ReservacionesAcc);            // RESERVACIONES	600	ACCESO
            UpdatePermiso(idUsr, 601, ReservacionesMod);            // RESERVACIONES	601	MODIFICAR DURACION CONTRATO
            UpdatePermiso(idUsr, 602, ReservacionesEdoPuntos);      // RESERVACIONES	602	GENERAR ESTADO DE PUNTOS
            UpdatePermiso(idUsr, 603, ReservacionesPtosNuevoAño);   // RESERVACIONES	603	ALTA PUNTOS NUEVO AÑO
            UpdatePermiso(idUsr, 604, ReservacionesCumpleaños);     // RESERVACIONES	604	LISTA DE CUMPLEAÑOS SOCIOS
            UpdatePermiso(idUsr, 605, ReservacionesPorcentajes);    // RESERVACIONES	605 REPORTE PORCENTAJES
        }

        private void UpdatePermiso(int idUsr, int numero, bool permiso)
        {
            string sql1 = "Update CSharpUsuariosPermisos set CU_PERMISO=@permiso where CU_USUARIO=@usr and CU_PROGRAMA=@num";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql1, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.Int).Value = idUsr;
                    comando.Parameters.Add("@num", SqlDbType.Int).Value = numero;
                    comando.Parameters.Add("@permiso", SqlDbType.Int).Value = permiso;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        //-------- D E L E T E  --------//
        private void DeletePermisos(int idUsr)
        {
            string sql = "delete CSharpUsuariosPermisos where CU_USUARIO=@usr";
            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@usr", SqlDbType.VarChar).Value = idUsr;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }







    }

}
