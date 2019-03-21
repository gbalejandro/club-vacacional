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
    public class Empresa 
    {

        Conexion c = new Conexion();
        Bitacora bita = new Bitacora();

        public Empresa()
        {
           this.idEmpresa = 1;
           this.LeerTipoCambio();
        }

        public int idEmpresa { get; set; }
        public string nomEmpresa { get; set; }
        public double tipoCambio { get; set; }

    /*
    [IdEmpresa] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Dir_1] [varchar](40) NULL,
	[Dir_2] [varchar](40) NULL,
	[Ult_con] [int] NULL,
	[Ult_rel] [int] NULL,
	[ult_mem] [int] NULL,
	[Clo_cos] [float] NULL,
	[Min_eng1] [float] NULL,
	[Min_eng2] [float] NULL,
	[ult_man] [int] NULL,
	[Lead] [int] NULL,
	[Iva] [float] NULL,
	[Ultpernom] [varchar](6) NULL,
	[Poroncan] [float] NULL,
	[Dirmar] [int] NULL,
	[Supmar] [int] NULL,
	[IdpuestoProm] [int] NULL,
	[IdPuestoTeamLeader] [int] NULL,
	[IdPuestoLiner] [int] NULL,
	[idPuestoCloser] [int] NULL,
	[idPuestoExitCloser] [int] NULL,
	[IdPuestoRecep] [int] NULL,
	[IdPuestoBell] [int] NULL,
	[IdPuestoConcierge] [int] NULL,
	[IdPuestoHostes] [int] NULL,
	[idPuestoVLO] [int] NULL,
	[idVisa] [int] NULL,
	[idMC] [int] NULL,
	[idAmex] [int] NULL,
	[idDiscover] [int] NULL,
	[DirDoc] [varchar](50) NULL,
	[IdUsuarioAlt] [int] NULL,
	[Fechoralt] [datetime] NULL,
	[Prianiuso] [int] NULL,
	[TopeMesesSinInteres] [int] NULL,
	[IdConceptoFondoCxL] [int] NULL,
	[Antiguedad1] [int] NULL,
	[Antiguedad2] [int] NULL,
	[Antiguedad3] [int] NULL,
	[Antiguedad4] [int] NULL,
	[DiasModContrato] [int] NULL,
	[VersionMinivacs32] [varchar](15) NULL,
	[VersionReservaciones] [varchar](15) NULL,
	[VersionDigitalC] [varchar](15) NULL,
	[VersionNomina] [varchar](15) NULL,
	[VersionStats] [varchar](15) NULL,
	[IpTraining] [varchar](20) NULL,
	[idDolar] [int] NULL,
	[TipoCambio] [money] NULL,
	[PrecioTopeMembresias] [money] NULL,
	[TipoCambioCB] [money] NOT NULL,
	[TipoCambioHoteles] [money] NOT NULL,
	[Logo] [image] NULL,
	[LogoAlto] [int] NOT NULL,
	[LogoAncho] [int] NOT NULL,
	[DirScaner] [varchar](50) NULL,
	[DirFotos] [varchar](50) NULL,
	[VersionBD] [varchar](255) NOT NULL,
	[VersionUP] [varchar](255) NOT NULL,
    */

        public void Limpiar()
        {
            idEmpresa = 0;
            nomEmpresa = "";
            tipoCambio = 0;
        }

        public void LeerTipoCambio()
        {

            string sql = "SELECT IdEmpresa, Nombre, TipoCambio FROM Empresa where idEmpresa=@idEmp";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idEmp", SqlDbType.Int).Value = idEmpresa;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idEmpresa  = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            nomEmpresa = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            tipoCambio = reader.IsDBNull(2) ? 0 : Convert.ToDouble(reader.GetDecimal(2));
                        }
                    }
                }

                con.Close();

            }

        }

        public void ModificarTipoCambio(double valor1, int valor2)
        {
           
            bita.RegistrarBitacora(100000, "Empresa", "TipoCambio (IdEmpresa:"+idEmpresa+")", "U", Convert.ToString(tipoCambio), Convert.ToString(valor1));
            
            string sql = "UPDATE Empresa set TipoCambio = @tipCambio WHERE idEmpresa = @idEmp";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@tipCambio", SqlDbType.Decimal).Value = valor1;
                    comando.Parameters.Add("@idEmp", SqlDbType.Int).Value = valor2;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

    }
}
