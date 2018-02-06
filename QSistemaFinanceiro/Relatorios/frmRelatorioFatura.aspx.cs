using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QSistemaFinanceiro.Relatorios
{
    public partial class frmRelatorioFatura : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand comando;
        SqlDataAdapter adapter;
        SqlParameter param;
        string idVenda;


        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=0.0.0.0,1433;Initial Catalog=Financeiro;User ID=sa;Password=000000");
            if (!IsPostBack)
            {
                renderReport();
            }
        }

        public void renderReport()
        {
            idVenda = Request.QueryString.Get("idVenda");

            DataTable dt = carregar(idVenda);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Relatorios/frmRelatorioFatura.rdlc";

            //parameters
            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("idVenda",idVenda.ToString())
            };
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        public DataTable carregar(string codigovenda)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(@"Data Source=0.0.0.0,1433;Initial Catalog=Financeiro;User ID=sa;Password=000000"))
            {

                SqlCommand cmd = new SqlCommand("sp_relatorio_venda", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idVenda", SqlDbType.Int).Value = idVenda;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;

        }
    }
}