using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Adapters;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using CRVsPackageLib;
using CrystalDecisions.ReportSource;

namespace Ponto_TI.Admin
{
    public partial class RelatoriosAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpContext context = HttpContext.Current;
            //if (Convert.ToString(context.Session["LoginEstado"]) != "OK")
            //{
            //    Response.Redirect("LoginAdm.aspx");
            //}
        }

        protected void btn_pesquisar_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            CrystalDecisions.CrystalReports.Engine.Database crDatabase;
            Tables CrTables;

            cryRpt.Load("C:\\Users\\erick\\Source\\Repos\\Ponto_TI\\Ponto_TI\\Admin\\Relatorios\\RelatorioPorColaborador.rpt");

            crConnectionInfo.ServerName = "localhost";
            crConnectionInfo.DatabaseName = "PontoOnLine";
            crConnectionInfo.UserID = "pontoti";
            crConnectionInfo.Password = "pontoadmin";
            
            crDatabase = cryRpt.Database;
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            cryRpt.SetParameterValue("@CodColab", cbo_Colab.SelectedValue);
            cryRpt.SetParameterValue("@DataIni", txt_dataini.Text);
            cryRpt.SetParameterValue("@DataFim", txt_datafim.Text);

            CrystalReportViewer.ReportSource = cryRpt;
            

        }

        protected void rdo_regional_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_regional.Checked == true && txt_datafim.Text != "" && txt_datafim.Text != "")
            {
                btn_pesquisar.Enabled = true;
                cbo_regional.Enabled = true;                
                cbo_Colab.Enabled = false;
            }           

        }

        protected void rdo_colab_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_colab.Checked == true && txt_datafim.Text != "" && txt_datafim.Text != "")
            {
                btn_pesquisar.Enabled = true;
                cbo_Colab.Enabled = true;                
                cbo_regional.Enabled = false;
            }          
        }
    }
}