using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Samarath_Sports.Crystal_Reports;

namespace Samarath_Sports.UI
{
    public partial class Browse_Quotation : Form
    {
        BAL.BAL BALObject;

        string year;
        string monthname;

        string datefrom, dateto; // VERIABLE FOR STORE SELECTED DATE.
        int QuotationID = 0;   // VERIABLE FOR STORE Quotation ID
        string QuotationNo;    // Veriable for store Quotation String 

        public Browse_Quotation()
        {
            InitializeComponent();
        }

        private void Browse_Quotation_Load(object sender, EventArgs e)
        {
            BALObject = new BAL.BAL();
            AddYear();

            CHKBox.Checked = false;

            //DateFrom.Value = System.DateTime.Now;
            //DateTo.Value = System.DateTime.Now;

            FillGridView();
        }

       

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            //string SearchText = Convert.ToString(TextSearch.Text.ToString());

            //DataTable dt = BALObject.Fatch_Quotation_TextWise(SearchText, datefrom, dateto);

            //GridView(dt);


            string SearchString = Convert.ToString(TextSearch.Text);

            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            if (CHKBox.Checked == false)
            {
                if (TextSearch.Text != "")
                {
                    string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());

                    DataTable dt = BALObject.Fatch_Quotation_TextWise_Year_Month(year, monthname, SearchString);
                    GridView(dt);
                }

                else
                {
                    string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());
                    DataTable dt = BALObject.Fatch_Quotation_Records(year, monthname);
                    GridView(dt);
                }
            }

            else
            {
                if (CHKBox.Checked == true)
                {
                    DataTable dt = BALObject.Fatch_Quotation_TextWise_Year(year, SearchString);
                    GridView(dt);
                }

                else
                {
                    DataTable dt = BALObject.Fatch_Quotation_Records_Yearly(year);
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

                DataTable dt = BALObject.Fatch_Quotation_Records(year, monthname);
                GridView(dt);
            }

            else
            {
                CHKBox.Text = "Hide Month";
                LBLmonth.Visible = false;
                ComboMonth.Visible = false;

               DataTable dt = BALObject.Fatch_Quotation_Records_Yearly(year);
                GridView(dt);
            }
        }


        private void ComboYear_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            if (CHKBox.Checked == true)
            {
                DataTable dt = BALObject.Fatch_Quotation_Records_Yearly(year);
                GridView(dt);
            }
            else
            {
                string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());
                DataTable dt = BALObject.Fatch_Quotation_Records(year, monthname);
                GridView(dt);
            }
        }


        private void ComboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string year = Convert.ToString(ComboYear.SelectedItem.ToString());

            if (CHKBox.Checked == false)
            {
                string monthname = Convert.ToString(ComboMonth.SelectedItem.ToString());
                DataTable dt = BALObject.Fatch_Quotation_Records(year, monthname);
                GridView(dt);
            }
            else
            {
                DataTable dt = BALObject.Fatch_Quotation_Records_Yearly(year);
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

            DataTable dt = BALObject.Fatch_Quotation_Records(year, monthname);

            if (dt.Rows.Count > 0)
            {
                GridView(dt);
            }
        }

        public void GridView(DataTable Table)
        {
            #region

            GridQuotationList.AutoGenerateColumns = false;
            GridQuotationList.Columns.Clear();

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

            DataGridViewTextBoxColumn Quotation_No = new DataGridViewTextBoxColumn();
            Quotation_No.Name = "Quotation_No";
            Quotation_No.HeaderText = "Quotation No";
            Quotation_No.DataPropertyName = "Quotation_No";
            Quotation_No.Width = 150;
            GridQuotationList.Columns.Insert(0, Quotation_No);

            DataGridViewTextBoxColumn Customer_Name = new DataGridViewTextBoxColumn();
            Customer_Name.Name = "Customer_Name";
            Customer_Name.HeaderText = "Customer Name";
            Customer_Name.DataPropertyName = "Customer_Name";
            Customer_Name.Width = 420;
            GridQuotationList.Columns.Insert(1, Customer_Name);

            DataGridViewTextBoxColumn Total_Cost = new DataGridViewTextBoxColumn();
            Total_Cost.Name = "Total_Cost";
            Total_Cost.HeaderText = "Total Amount";
            Total_Cost.DataPropertyName = "Total_Cost";
            Total_Cost.Width = 100;
            GridQuotationList.Columns.Insert(2, Total_Cost);

            DataGridViewTextBoxColumn Total_Tax = new DataGridViewTextBoxColumn();
            Total_Tax.Name = "Total_Tax";
            Total_Tax.HeaderText = "Total_Tax";
            Total_Tax.DataPropertyName = "Total_Tax";
            Total_Tax.Width = 80;
            GridQuotationList.Columns.Insert(3, Total_Tax);

            DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
            Date.Name = "Date";
            Date.HeaderText = "Date";
            Date.DataPropertyName = "Date";
            Date.Width = 110;
            GridQuotationList.Columns.Insert(4, Date);

            DataGridViewTextBoxColumn QuotationID = new DataGridViewTextBoxColumn();
            QuotationID.Name = "QuotationID";
            QuotationID.HeaderText = "QuotationID";
            QuotationID.DataPropertyName = "QuotationID";
            QuotationID.Width = 30;
            QuotationID.Visible = false;
            GridQuotationList.Columns.Insert(5, QuotationID);

            GridQuotationList.DataSource = Table;
            GridQuotationList.Refresh();

            #endregion

            UpdateFont();
            this.GridQuotationList.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in GridQuotationList.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }
        }        

        private void GridQuotationList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            QuotationID = Convert.ToInt32(GridQuotationList.Rows[e.RowIndex].Cells[5].Value);
            QuotationNo = Convert.ToString(GridQuotationList.Rows[e.RowIndex].Cells[0].Value);
        }

        #endregion


        #region BUTTONS

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (QuotationID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure, the record will be Delete Permenantly..!!!", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BALObject.Delete_Quotation_Records(QuotationID);
                    MessageBox.Show("Record Deleted Successfully...", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("Please Select the Record");
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            FillGridView();            
        }

        private void BtnAllRecords_Click(object sender, EventArgs e)
        {
            DataTable dt = BALObject.FatchAll_Quotation_Records();
            GridView(dt);
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            QuotationReports form = new QuotationReports(QuotationID, QuotationNo);
            form.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region

        //public void TodaysRecords()
        //{
        //    DataTable dt = BALObject.Fatch_Quotation_Todays_Records();
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
        //    DataTable dt = BALObject.Fatch_Quotation_Data_Datewise(datefrom, dateto);
        //    GridView(dt);
        //}

        //private void DateTo_ValueChanged(object sender, EventArgs e)
        //{
        //    ToDateFinder();
        //    DataTable dt = BALObject.Fatch_Quotation_Data_Datewise(datefrom, dateto);
        //    GridView(dt);
        //}

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridQuotationList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }        

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ComboYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        #endregion

       

        


    }
}
