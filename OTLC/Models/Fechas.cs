using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC
{
    class Fechas
    {
        public string NumDia { get; set; }
        public string NumMes { get; set; }
        public string LetrasDia { get; set; }
        public string LetrasMes { get; set; }
        public int Año { get; set; }

        public Fechas()
        {
            NumDia = "";
            NumMes = "";
            LetrasDia = "";
            LetrasMes = "";
            Año = 0;
        }

        public void GeneraFecha(DateTime fecha, int idioma)
        {
            if (fecha.Month < 10)
            {
                NumMes = "0" + fecha.Month;
            }
            else
            {
                NumMes = Convert.ToString(fecha.Month);
            }
                
                NombreMes(NumMes,idioma);

            if(fecha.Day<10)
            {
                NumDia = "0"+fecha.Day;
            }
            else
            {
                NumDia = Convert.ToString(fecha.Day);
            }
                
                NombreDia(Convert.ToString(fecha.DayOfWeek),idioma);

                Año = fecha.Year;
        }

        private void NombreMes(string mes, int idioma)
        {
            if (idioma == 1) //ESPAÑOL
            {
                switch (mes)
                {
                    case "01":
                        LetrasMes = "ENERO";
                        break;
                    case "02":
                        LetrasMes = "FEBRERO";
                        break;
                    case "03":
                        LetrasMes = "MARZO";
                        break;
                    case "04":
                        LetrasMes = "ABRIL";
                        break;
                    case "05":
                        LetrasMes = "MAYO";
                        break;
                    case "06":
                        LetrasMes = "JUNIO";
                        break;
                    case "07":
                        LetrasMes = "JULIO";
                        break;
                    case "08":
                        LetrasMes = "AGOSTO";
                        break;
                    case "09":
                        LetrasMes = "SEPTIEMBRE";
                        break;
                    case "10":
                        LetrasMes = "OCTUBRE";
                        break;
                    case "11":
                        LetrasMes = "NOVIEMBRE";
                        break;
                    case "12":
                        LetrasMes = "DICIEMBRE";
                        break;
                    default:
                        LetrasMes = "";
                        break;

                }
            }

            else //INGLES
            {
                switch (mes)
                {
                    case "01":
                        LetrasMes = "JANUARY";
                        break;
                    case "02":
                        LetrasMes = "FEBRUARY";
                        break;
                    case "03":
                        LetrasMes = "MARCH";
                        break;
                    case "04":
                        LetrasMes = "APRIL";
                        break;
                    case "05":
                        LetrasMes = "MAY";
                        break;
                    case "06":
                        LetrasMes = "JUNE";
                        break;
                    case "07":
                        LetrasMes = "JULY";
                        break;
                    case "08":
                        LetrasMes = "AUGUST";
                        break;
                    case "09":
                        LetrasMes = "SEPTEMBRE";
                        break;
                    case "10":
                        LetrasMes = "OCTOBER";
                        break;
                    case "11":
                        LetrasMes = "NOVEMBER";
                        break;
                    case "12":
                        LetrasMes = "DECEMBER";
                        break;
                    default:
                        LetrasMes = "";
                        break;
                }

            }

        }

        private void NombreDia(string dia, int idioma)
        {
            if (idioma == 1) //ESPAÑOL
            {
                switch (dia)
                {
                    case "Monday":
                        LetrasDia = "LUNES";
                        break;
                    case "Tuesday":
                        LetrasDia = "MARTES";
                        break;
                    case "Wednesday":
                        LetrasDia = "MIERCOLES";
                        break;
                    case "Thursday":
                        LetrasDia = "JUEVES";
                        break;
                    case "Friday":
                        LetrasDia = "VIERNES";
                        break;
                    case "Saturday":
                        LetrasDia = "SABADO";
                        break;
                    case "Sunday":
                        LetrasDia = "DOMINIGO";
                        break;
                    default:
                        LetrasDia = "";
                        break;

                }
            }
            else
            {
                LetrasDia = dia;
            }
                
        }


    }
}
