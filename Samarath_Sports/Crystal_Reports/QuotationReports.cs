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
    public partial class QuotationReports : Form
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]);
        //DataTable dt = new DataTable();
        ReportDocument rpt = new ReportDocument();
        //SqlCommand cmd;
        SqlDataAdapter adapter;

        int QuotationID;

        string QuotationNO;

        public QuotationReports(int Q_ID, string Q_NO)
        {
            InitializeComponent();

            QuotationID = Q_ID;
            QuotationNO = Q_NO;
        }

        public QuotationReports()
        {
            InitializeComponent();
        }

        private void QuotationCrystalReportViewer_Load(object sender, EventArgs e)
        {

            string MainQuotation = "select Quotation_No,Customer_Name,Total_Cost,Date from Main_Quotation where QuotationID = '"+QuotationID+"'";

            string Quotation = "select CompanyName, ProductName, ProductCode, ProductType, Rate, Discount, DiscountAmount, Quantity, TotalAmount, Vat, GrantTotal from Quotation where MainQuotation_ID = '"+QuotationID+"'";

            rpt = new Quotation_Report();

            con.Open();

            DataTable DT1 = new DataTable("Main_Quotation");

            adapter = new SqlDataAdapter(MainQuotation, con);
            adapter.Fill(DT1);
            DataSet ds = new DataSet();

            adapter = new SqlDataAdapter(Quotation, con);
            adapter.Fill(ds, "Quotation");

            ds.Tables.Add(DT1);
            rpt.SetDataSource(ds);
            QuotationCrystalReportViewer.ReportSource = rpt;
            con.Close();

        }
    }
}
