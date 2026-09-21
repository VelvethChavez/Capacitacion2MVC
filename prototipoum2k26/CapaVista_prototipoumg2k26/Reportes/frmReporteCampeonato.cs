using CapaControlador_prototipoumg2k26;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_prototipoumg2k26.Reportes
{
    public partial class frmReporteCampeonato : Form
    {
        
        private ModeloCampeonato campeonato = new ModeloCampeonato();

        public frmReporteCampeonato()
        {
            InitializeComponent();
        }

        private void frmReporteCampeonato_Load(object sender, EventArgs e)
        {
            
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", campeonato.GetAll());
                reportViewer1.LocalReport.ReportEmbeddedResource = "CapaVista_prototipoumg2k26.Reportes.ReportCampeonato.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            
             
        }
    }
}
