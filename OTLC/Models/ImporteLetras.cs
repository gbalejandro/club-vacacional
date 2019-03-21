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
    class ImporteLetras
    {

        public string enletrasEsp(string num, string moneda)
        {
            string res, dec = "";
            double entero;
            int decimales;
            double nro;

            try
            { nro = Convert.ToDouble(num); }
            catch
            { return ""; }

            entero = Convert.ToDouble(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

            if (decimales > 0)
            { dec = " " + decimales.ToString() + "/100 " + moneda; }

            res = toTextEsp(Convert.ToDouble(entero)) + dec;

            return res;
        }

        public string enletrasIng(string num, string moneda)
        {
            string res, dec = "";
            double entero;
            int decimales;
            double nro;

            try
            { nro = Convert.ToDouble(num); }
            catch
            { return ""; }

            entero = Convert.ToDouble(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));

            if (decimales > 0)
            {
                if (moneda == "USD")
                { dec = " DOLLARS " + decimales.ToString() + "/100 " + moneda; }
                else
                { dec = " " + decimales.ToString() + "/100 " + moneda; }
            }

            res = toTextIngles(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toTextEsp(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);

            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toTextEsp(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toTextEsp(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toTextEsp(Math.Truncate(value / 10) * 10) + " Y " + toTextEsp(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toTextEsp(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toTextEsp(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toTextEsp(Math.Truncate(value / 100) * 100) + " " + toTextEsp(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toTextEsp(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toTextEsp(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toTextEsp(value % 1000);
            }
            else if (value == 1000000) Num2Text = "UN MILLON";

            else if (value < 2000000) Num2Text = "UN MILLON " + toTextEsp(value % 1000000);

            else if (value < 1000000000000)
            {
                Num2Text = toTextEsp(Math.Truncate(value / 1000000)) + " MILLONES ";

                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toTextEsp(value - Math.Truncate(value / 1000000) * 1000000);
            }
            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toTextEsp(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = toTextEsp(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toTextEsp(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

        private string toTextIngles(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);

            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "ONE";
            else if (value == 2) Num2Text = "TWO";
            else if (value == 3) Num2Text = "THREE";
            else if (value == 4) Num2Text = "FOUR";
            else if (value == 5) Num2Text = "FIVE";
            else if (value == 6) Num2Text = "SIX";
            else if (value == 7) Num2Text = "SEVEN";
            else if (value == 8) Num2Text = "EIGHT";
            else if (value == 9) Num2Text = "NINE";
            else if (value == 10) Num2Text = "TEN";
            else if (value == 11) Num2Text = "ELEVEN";
            else if (value == 12) Num2Text = "TWELVE";
            else if (value == 13) Num2Text = "THIRTEEN";
            else if (value == 14) Num2Text = "FOURTEEN";
            else if (value == 15) Num2Text = "FIFTEEN";
            else if (value == 16) Num2Text = "SIXTEEN";
            else if (value == 17) Num2Text = "SEVENTEEN";
            else if (value == 18) Num2Text = "EIGHTEEN";
            else if (value == 19) Num2Text = "NINETEEN";
            else if (value == 20) Num2Text = "TWENTY";
            else if (value == 30) Num2Text = "THIRTY";
            else if (value == 40) Num2Text = "FORTY";
            else if (value == 50) Num2Text = "FIFTY";
            else if (value == 60) Num2Text = "SIXTY";
            else if (value == 70) Num2Text = "SEVENTY";
            else if (value == 80) Num2Text = "EIGHTY";
            else if (value == 90) Num2Text = "NINETY";
            else if (value < 100) Num2Text = toTextIngles(Math.Truncate(value / 10) * 10) + " " + toTextIngles(value % 10);
            else if ((value == 100) || (value == 200) || (value == 300) || (value == 400) || (value == 500) || (value == 600) || (value == 700) || (value == 800) || (value == 900)) Num2Text = toTextIngles(Math.Truncate(value / 100)) + " HUNDRED";
            else if (value < 1000) Num2Text = toTextIngles(Math.Truncate(value / 100) * 100) + " " + toTextIngles(value % 100);
            else if (value == 1000) Num2Text = "THOUSAND";
            else if (value < 2000) Num2Text = "THOUSAND " + toTextIngles(value % 1000);
            else if (value < 1000000)

            {
                Num2Text = toTextIngles(Math.Truncate(value / 1000)) + " THOUSAND";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toTextIngles(value % 1000);
            }
            else if (value == 1000000) Num2Text = "ONE MILLION";

            else if (value < 2000000) Num2Text = " MILLION " + toTextIngles(value % 1000000);

            else if (value < 1000000000000)

            {
                Num2Text = toTextIngles(Math.Truncate(value / 1000000)) + " MILLIONS ";

                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toTextIngles(value - Math.Truncate(value / 1000000) * 1000000);
            }
            else if (value == 1000000000000) Num2Text = "ONE BILLON";
            else if (value < 2000000000000) Num2Text = " BILLON " + toTextIngles(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = toTextIngles(Math.Truncate(value / 1000000000000)) + " BILLONS";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toTextIngles(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

    }
}
