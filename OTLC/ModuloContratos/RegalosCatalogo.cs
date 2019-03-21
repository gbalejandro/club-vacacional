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
    public partial class RegalosCatalogo : Form
    {
        Conexion c = new Conexion();

        public string regalo { get; set; }

        public RegalosCatalogo()
        {
            InitializeComponent();

            regalo = "";
            llenarDGVRegCat();
        }

        private void llenarDGVRegCat()
        {
            string sql = "select  r.Nombre,r.idRegalo as Clave,m.Nombre as Moneda,r.CostoA,'' as CostoN, r.CapturaSeries,r.CapturaFecexp,r.Paquete,d.Nombre as División,sv.Nombre as 'Sala de Venta',sta.Nombre as 'Status' from Regalos r left join Monedas m on r.idMoneda = m.idMoneda left join Divisiones d on r.idDivision = d.idDivision left join SalasVta sv on r.idSalaVta = sv.idSalaVta left join Status sta on r.IdStatus = sta.idStatus where r.idSalaVta = 1 and idRegalo> 0 order by Nombre";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgvRegCat.Columns.Clear();

                    dgvRegCat.Columns.Add(new DataGridViewCheckBoxColumn { Name = "CapturaSeries", DataPropertyName = "CapturaSeries" });
                    dgvRegCat.Columns.Add(new DataGridViewCheckBoxColumn { Name = "CapturaFecexp", DataPropertyName = "CapturaFecexp" });
                    dgvRegCat.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Paquete", DataPropertyName = "Paquete" });

                    dgvRegCat.DataSource = dt;

                    dgvRegCat.Columns["Nombre"].DisplayIndex = 0;
                    dgvRegCat.Columns["Clave"].DisplayIndex = 1;
                    dgvRegCat.Columns["Moneda"].DisplayIndex = 2;
                    dgvRegCat.Columns["CostoA"].DisplayIndex = 3;
                    dgvRegCat.Columns["CostoN"].DisplayIndex = 4;
                    dgvRegCat.Columns["CapturaSeries"].DisplayIndex = 5;
                    dgvRegCat.Columns["CapturaFecexp"].DisplayIndex = 6;
                    dgvRegCat.Columns["Paquete"].DisplayIndex = 7;
                    dgvRegCat.Columns["División"].DisplayIndex =8;
                    dgvRegCat.Columns["Sala de Venta"].DisplayIndex = 9;
                    dgvRegCat.Columns["Status"].DisplayIndex = 10;

                    con.Close();
                }
            }
          
            //aliniacion de columnas a la derecha
            this.dgvRegCat.Columns["Clave"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRegCat.Columns["CostoA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //encabezado columnas checkbox
            this.dgvRegCat.Columns["CapturaSeries"].HeaderText = "Captura Series";
            this.dgvRegCat.Columns["CapturaFecexp"].HeaderText = "Captura Expiración";
            this.dgvRegCat.Columns["Paquete"].HeaderText = "Paquete";

            //tamaño de las columnas   
            this.dgvRegCat.Columns["Nombre"].Width = 300;
            this.dgvRegCat.Columns["Clave"].Width = 50;
            this.dgvRegCat.Columns["Moneda"].Width = 70;
            this.dgvRegCat.Columns["CostoA"].Width = 70;
            this.dgvRegCat.Columns["CostoN"].Width = 70;
            this.dgvRegCat.Columns["CapturaSeries"].Width = 70;
            this.dgvRegCat.Columns["CapturaFecexp"].Width = 70;
            this.dgvRegCat.Columns["Paquete"].Width = 70;
            this.dgvRegCat.Columns["División"].Width = 100;
            this.dgvRegCat.Columns["Sala de Venta"].Width = 150;
            this.dgvRegCat.Columns["Status"].Width = 90;

        }


        private void bttncerrar_Click(object sender, EventArgs e)
        {
            regalo = "0";
            this.Hide();
        }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            regalo= dgvRegCat.CurrentRow.Cells[1].Value.ToString();
            this.Hide();
        }

        private void dgvRegCat_DoubleClick(object sender, EventArgs e)
        {
            regalo = dgvRegCat.CurrentRow.Cells[1].Value.ToString();
            this.Hide();
        }
    }
}
