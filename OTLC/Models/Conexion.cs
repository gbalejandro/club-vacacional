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
    public class Conexion
    {      
        public string cadenaConexion { get; set; }
        public static string version { get; set; }
       
        public Conexion()
        {
            version = "2.0.0.5";
           cadenaConexion = @"data source=192.168.31.2;initial catalog=dbTC;user id=sa;password=Retro4455;Connect Timeout=60";
        }

        public object getNullValue(object objeto)
        {
            if (objeto is bool)
            {
                return false;
            }
            else if (objeto is int)
            {
                return 0;
            }
            else if (objeto is DateTime)
            {
                return Convert.ToDateTime("01/01/50");
            }
            else if (objeto is float)
            {
                return 0;
            }
            else if (objeto is double)
            {
                return 0;
            }
            else
            {
                return "";
            }
        }

        public void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        public void NumerosConPunto(object sender, KeyPressEventArgs e, TextBox valor)
        {
            if (valor.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }
    }
}
