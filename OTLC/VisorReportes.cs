using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using OTLC.Reports;

namespace OTLC
{
    public partial class VisorReportes : Form
    {
        

         public VisorReportes()
        {
            InitializeComponent();
        }

        public string reporte { get; set; }

        // español
        public VisorReportes(EspAnexoA rep)
        {
            InitializeComponent();
            reporte = "AnexoA";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(EspAnexoB rep)
        {
            InitializeComponent();
            reporte = "AnexoB";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(EspAnexoC rep)
        {
            InitializeComponent();
            reporte = "AnexoC";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(EspAnexoD rep)
        {
            InitializeComponent();
            reporte = "AnexoD";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(EspAutorizacion rep)
        {
            InitializeComponent();
            reporte = "CartaAut";
            this.crystalReportViewer1.ReportSource = rep;
        }
        public VisorReportes(EspPagare rep)
        {
            InitializeComponent();
            reporte = "Pagare";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(EspContrato rep)
        {
            InitializeComponent();
            reporte = "Contrato";
            this.crystalReportViewer1.ReportSource = rep;
        }

        // ingles
        public VisorReportes(IngAnexoA rep)
        {
            InitializeComponent();
            reporte = "AnexoA";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(IngAnexoB rep)
        {
            InitializeComponent();
            reporte = "AnexoB";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(IngAnexoC rep)
        {
            InitializeComponent();
            reporte = "AnexoC";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(IngAnexoD rep)
        {
            InitializeComponent();
            reporte = "AnexoD";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(IngAutorizacion rep)
        {
            InitializeComponent();
            reporte = "CartaAut";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(IngPagare rep)
        {
            InitializeComponent();
            reporte = "Pagare";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(IngContrato rep)
        {
            InitializeComponent();
            reporte = "Contrato";
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(RegalosVentas rep)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = rep;
        }

        public VisorReportes(EstadoPtosEsp esp)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = esp;
        }

        public VisorReportes(EstadoPtosIng ing)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = ing;
        }

        public VisorReportes(EstadoPtosPort port)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = port;
        }


        /*

                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\SampleReport.pdf";
                    CrExportOptions = doc.ExportOptions;
                    {
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;

                    }
                    doc.Export();

        */



    }
}
