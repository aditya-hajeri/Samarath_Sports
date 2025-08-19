using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Samarath_Sports.BAL;
using Samarath_Sports.Crystal_Reports;

namespace Samarath_Sports.UI
{
    public partial class Browse_Bill : Form
    {
        BAL.BAL BALObject;

        string year;
        string monthname;

        string datefrom, dateto; // VERIABLE FOR STORE SELECTED DATE.
        int BillingID = 0;   // VERIABLE FOR STORE BILLINGID
        string BillingNo;    // Veriable for store Billing String 

        public Browse_Bill()
        {
            InitializeComponent();
        }

        private void Browse_Bill_Load(object sender, EventArgs e)
        {
            BALObject = new BAL.BAL();
            AddYear();

            CHKBox.Checked = false;

            //DateFrom.Value = System.DateTime.Now;
            //DateTo.Value = System.DateTime.Now;

            FillGridView();
        }


        private void TextSearch_TextChanged_1(object sender, EventArgs e)
        {
            ////if (TextSearch.Text != "")
            ////{
            //    string SearchText = Convert.ToString(TextSearch.Text.ToString());
            //    DataTable dt = BALObject.Fatch_BillingTextWise(SearchText, datefrom, dateto);

            //    GridView(dt);
            ////}

            string SearchString = Convert.ToString(TextSearch.Text);

            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            if (CHKBox.Checked == false)
            {
                if (TextSearch.Text != "")
                {
                    string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());

                    DataTable dt = BALObject.FatchAll_BillRecords_TextWise_Year_Month(year, monthname, SearchString);
                    GridView(dt);
                }

                else
                {
                    string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());

                    DataTable dt = BALObject.FatchAll_BillRecords(year, monthname);
                    GridView(dt);
                }
            }

            else
            {
                if (CHKBox.Checked == true)
                {
                    DataTable dt = BALObject.FatchAll_BillRecords_TextWise_Yearly(year, SearchString);
                    GridView(dt);
                }

                else
                {
                    DataTable dt = BALObject.FatchAll_BillRecords_Yearly(year);
                    GridView(dt);
                }
            }
        }


        private void CHKBox_CheckedChanged(object sender, EventArgs e)
        {
            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            if (CHKBox.Checked == false)
            {
                CHKBox.Checked = false;
                CHKBox.Text = "Show Month";
                LBLmonth.Visible = true;
                ComboMonth.Visible = true;

                string MonthName = DateTime.Today.ToString("MMMM");
                ComboMonth.SelectedItem = MonthName;

                string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());

                DataTable dt = BALObject.FatchAll_BillRecords(year, monthname);
                GridView(dt);
            }

            else
            {
                CHKBox.Text = "Hide Month";
                LBLmonth.Visible = false;
                ComboMonth.Visible = false;

                DataTable dt = BALObject.FatchAll_BillRecords_Yearly(year);
                GridView(dt);
            }
        }

        private void ComboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            if (CHKBox.Checked == true)
            {
                DataTable dt = BALObject.FatchAll_BillRecords_Yearly(year);
                GridView(dt);
            }
            else
            {
                string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());
                DataTable dt = BALObject.FatchAll_BillRecords(year, monthname);
                GridView(dt);
            }
        }

        private void ComboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            if (CHKBox.Checked == false)
            {
                string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());
                DataTable dt = BALObject.FatchAll_BillRecords(year, monthname);
                GridView(dt);
            }
            else
            {
                DataTable dt = BALObject.FatchAll_BillRecords_Yearly(year);
                GridView(dt);
            }
        }

        public void AddYear()
        {
            int year = DateTime.Now.Year;
            for (int i = year - 5; i <= year; i++)
            {
                ComboYear.Items.Add(i.ToString());
            }

            string Year = DateTime.Today.ToString("yyyy");
            ComboYear.SelectedItem = Year;

            string MonthName = DateTime.Today.ToString("MMMM");
            ComboMonth.SelectedItem = MonthName;
        }


        #region GRIDVIEW

        public void FillGridView()
        {
             year = Convert.ToString(ComboYear.SelectedItem.ToString());
            monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());

            DataTable dt = BALObject.FatchAll_BillRecords(year, monthname);

            if (dt.Rows.Count > 0)
            {
                GridView(dt);
                //this.GridBillList.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue; 
            }
        }

        public void GridView(DataTable Table)
        {
            #region

            GridBillList.AutoGenerateColumns = false;
            GridBillList.Columns.Clear();

            //DataGridViewCheckBoxColumn dvchk = new DataGridViewCheckBoxColumn();
            //dvchk.Name = "chk";
            //dvchk.HeaderText = "";
            //dvchk.Width = 25;
            //DriverGridView.Columns.Insert(0, dvchk);

            //Rectangle rect = DriverGridView.GetCellDisplayRectangle(0, -1, true);
            //rect.X = rect.Location.X + (rect.Width / 4);
            //CheckBox checkboxHeader = new CheckBox();
            //checkboxHeader.Name = "checkboxHeader";
            //checkboxHeader.Size = new Size(18, 18);
            //checkboxHeader.Location = rect.Location;
            //checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            //DriverGridView.Controls.Add(checkboxHeader);            

            DataGridViewTextBoxColumn BillingNo = new DataGridViewTextBoxColumn();
            BillingNo.Name = "BillingNo";
            BillingNo.HeaderText = "Billing No";
            BillingNo.DataPropertyName = "BillingNo";
            BillingNo.Width = 150;
            GridBillList.Columns.Insert(0, BillingNo);

            DataGridViewTextBoxColumn CustomerName = new DataGridViewTextBoxColumn();
            CustomerName.Name = "CustomerName";
            CustomerName.HeaderText = "Customer Name";
            CustomerName.DataPropertyName = "CustomerName";
            CustomerName.Width = 420;
            GridBillList.Columns.Insert(1, CustomerName);

            DataGridViewTextBoxColumn Total_Amount = new DataGridViewTextBoxColumn();
            Total_Amount.Name = "Total_Amount";
            Total_Amount.HeaderText = "Total Amount";
            Total_Amount.DataPropertyName = "Total_Amount";
            Total_Amount.Width = 130;
            GridBillList.Columns.Insert(2, Total_Amount);

            DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
            Date.Name = "Date";
            Date.HeaderText = "Date";
            Date.DataPropertyName = "Date";
            Date.Width = 110;
            GridBillList.Columns.Insert(3, Date);

            DataGridViewTextBoxColumn Billing_ID = new DataGridViewTextBoxColumn();
            Billing_ID.Name = "Billing_ID";
            Billing_ID.HeaderText = "Billing ID";
            Billing_ID.DataPropertyName = "Billing_ID";
            Billing_ID.Width = 30;
            Billing_ID.Visible = false;
            GridBillList.Columns.Insert(4, Billing_ID);

            GridBillList.DataSource = Table;
            GridBillList.Refresh();

            #endregion

            UpdateFont();
            this.GridBillList.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in GridBillList.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }
        }
        
        private void GridBillList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BillingID = Convert.ToInt32(GridBillList.Rows[e.RowIndex].Cells[4].Value);
            BillingNo = Convert.ToString(GridBillList.Rows[e.RowIndex].Cells[0].Value);
        }

        #endregion


        #region BUTTONS

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (BillingID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure, the record will be Delete Permenantly..!!!", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BALObject.Delete_Records(BillingID);
                    MessageBox.Show("Record Deleted Successfully...", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("Please Select the Record");
            }

        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            if (BillingID != 0)
            {
                _1_Bill newform = new _1_Bill(BillingNo);
                newform.Show();
            }
        }
        
        private void BtnAllRecords_Click_1(object sender, EventArgs e)
        {
            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            DataTable dt = BALObject.FatchAll_BillRecords_Yearly(year);
            GridView(dt);
        }

        private void BtnReset_Click_1(object sender, EventArgs e)
        {
            FillGridView();
            //DateFrom.Value = System.DateTime.Now;
            //DateTo.Value = System.DateTime.Now;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        



        #region

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }



        //public void TodaysRecords()
        //{
        //    DataTable dt = BALObject.Fatch_BillingTodays_Records();
        //    GridView(dt);
        //}

        public void FromDateFinder()
        {
            //DateTime fromdate = DateFrom.Value;
            //datefrom = fromdate.ToShortDateString();
            //fromdate = DateTime.ParseExact(datefrom, "dd/MM/yyyy", null);
            //datefrom = fromdate.ToString("dd/MM/yyyy");

            //DateTime todate = Convert.ToDateTime(dateto);
            //dateto = todate.ToShortDateString();
            //todate = DateTime.ParseExact(dateto, "dd/MM/yyyy", null);
            //dateto = todate.ToString("dd/MM/yyyy");
        }

        public void ToDateFinder()
        {
            //DateTime todate = DateTo.Value;
            //dateto = todate.ToShortDateString();
            //todate = DateTime.ParseExact(dateto, "dd/MM/yyyy", null);
            //dateto = todate.ToString("dd/MM/yyyy");

            //DateTime fromdate = Convert.ToDateTime(datefrom);
            //datefrom = fromdate.ToShortDateString();
            //fromdate = DateTime.ParseExact(datefrom, "dd/MM/yyyy", null);
            //datefrom = fromdate.ToString("dd/MM/yyyy");
        }

        
        

       

        //private void DateFrom_ValueChanged(object sender, EventArgs e)
        //{
        //    FromDateFinder();
        //    DataTable dt = BALObject.Fatch_BillingDataDatewise(datefrom, dateto);
        //    GridView(dt);
        //}

        //private void DateTo_ValueChanged(object sender, EventArgs e)
        //{
        //    ToDateFinder();
        //    DataTable dt = BALObject.Fatch_BillingDataDatewise(datefrom, dateto);
        //    GridView(dt);
        //}

        #endregion



    }
}
