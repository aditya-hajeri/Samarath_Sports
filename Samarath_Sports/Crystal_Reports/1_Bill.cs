using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using Samarath_Sports.Crystal_Reports;
using Samarath_Sports;

namespace Samarath_Sports.Crystal_Reports
{
    public partial class _1_Bill : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]);
        //DataTable dt = new DataTable();
        ReportDocument rpt = new ReportDocument();
        //SqlCommand cmd;
        SqlDataAdapter adapter;

        string BILLNO;

        public _1_Bill(string BillingNO)
        {
            InitializeComponent();
            BILLNO = BillingNO;
        }

        public _1_Bill()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            string BillDetails = "select BillingNo,CustomerName,Total_Amount from BillingDetails where BillingNo='" + BILLNO + "'";

            string BillingDetails = "select a.CompanyName,a.ProductName, a.ProductCode, a.ProductType, a.ProductCount, a.ProductMRP, a.ProductPrise from Billing_Entry a,BillingDetails b where a.BillingNo='" + BILLNO + "' and a.BillingNo=b.BillingNo";

            rpt = new Bill_CrystalReport1();

            con.Open();

            DataTable DT1 = new DataTable("Bill_Details");

            adapter = new SqlDataAdapter(BillDetails, con);
            adapter.Fill(DT1);
            DataSet ds = new DataSet();

            adapter = new SqlDataAdapter(BillingDetails, con);
            adapter.Fill(ds, "Bill_Product");

            ds.Tables.Add(DT1);
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            con.Close();

        }




    }
}
