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
    public partial class frmRelatorioProduto : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand comando;
        SqlDataAdapter adapter;
        SqlParameter param;

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


            DataTable dt = carregar();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Relatorios/frmRelatorioProduto.rdlc";


            ReportViewer1.LocalReport.Refresh();

        }



        public DataTable carregar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(@"Data Source=0.0.0.0,1433;Initial Catalog=Financeiro;User ID=sa;Password=000000"))
            {

                SqlCommand cmd = new SqlCommand("select * from produto order by nome asc", con);
                cmd.CommandType = CommandType.Text;


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;

        }
    }
}