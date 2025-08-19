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
namespace Samarath_Sports.UI
{
    public partial class Add_Company : Form
    {
        BAL.BAL BALObject;
        int CompanyID = 0;

        public Add_Company()
        {
            InitializeComponent();
        }

        private void Add_Company_Load(object sender, EventArgs e)
        {
            // Set Form's Transperancy 100 %
            this.Opacity = 0;

            // Start the Timer To Animate Form
            timer1.Enabled = true;

            BALObject = new BAL.BAL();
            FillGridView();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Make Form Visible a Bit more on Every timer Tick
            this.Opacity += 0.10;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (CompanyID != 0)
            {
                DataTable dt = BALObject.EditCompanyDetails(CompanyID);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    TextCompanyName.Text = Convert.ToString(dr["Company_Name"].ToString());                   
                }
                BtnSave.Visible = false;
                BtnUpdate.Visible = true;
            }

            else
            {
                MessageBox.Show("Please Select Recored", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string CompanyName = Convert.ToString(TextCompanyName.Text);

            if (BALObject.UpdateCompanyDetail(CompanyID, CompanyName))
            {
                MessageBox.Show("Recored Updated Successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView();
                TextCompanyName.Text = "";
            }
            else
            {
                MessageBox.Show("Somthing is going wrong call Developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (BALObject.DeleteCompanyDetail(CompanyID))
            {
                MessageBox.Show("Recored Delete Successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView();
            }
            else
            {
                MessageBox.Show("Somthing is going wrong call Developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string companyname = Convert.ToString(TextCompanyName.Text);          

            if (TextCompanyName.Text !="" )
            {
                BALObject.AddCompany(companyname);
                MessageBox.Show("Recored inserted successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView();
                TextCompanyName.Text = "";
                TextCompanyName.Focus();
            }
            else
            {
                MessageBox.Show("Please Fillup all field correctly...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchString = Convert.ToString(TextSearch.Text);

            if (SearchString != "")
            {
                DataTable dt = BALObject.SearchCompanyDetails(SearchString);
                GridView(dt);
            }
            else
            {
                FillGridView();
            }
        }

        public void FillGridView()
        {
            DataTable dt = BALObject.Fatch_Company_Data();

            if (dt.Rows.Count > 0)
            {
                GridView(dt);              
            }
        }

        public void GridView(DataTable Table)
        {

            #region

            DataTable dt = Table;

            GridAddCompany.AutoGenerateColumns = false;
            GridAddCompany.Columns.Clear();

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

            DataGridViewTextBoxColumn Company_Name = new DataGridViewTextBoxColumn();
            Company_Name.Name = "Company_Name";
            Company_Name.HeaderText = "Company Name";
            Company_Name.DataPropertyName = "Company_Name";
            Company_Name.Width = 580;
            GridAddCompany.Columns.Insert(0, Company_Name);
                        
            DataGridViewTextBoxColumn CompanyID = new DataGridViewTextBoxColumn();
            CompanyID.Name = "CompanyID";
            CompanyID.HeaderText = "Company ID";
            CompanyID.DataPropertyName = "CompanyID";
            CompanyID.Width = 120;
            CompanyID.Visible = false;
            GridAddCompany.Columns.Insert(1, CompanyID);

            GridAddCompany.DataSource = dt;
            GridAddCompany.Refresh();

            #endregion

            UpdateFont();
            this.GridAddCompany.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in GridAddCompany.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }
        }

        private void GridAddCompany_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CompanyID = Convert.ToInt32(GridAddCompany.Rows[e.RowIndex].Cells[1].Value);
        }

        

        

        


    }
}
