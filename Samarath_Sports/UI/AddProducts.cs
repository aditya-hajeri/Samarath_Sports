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
    public partial class AddProducts : Form
    {
        BAL.BAL BALObject;
        int ProductID; // Veriable for store porduct ID

        public AddProducts()
        {
            InitializeComponent();
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            BALObject = new BAL.BAL();
            FillGridView(); LoadCompanyName();
            ComboProductType.SelectedIndex = 0;
            ComboEach.SelectedIndex = 0;
        }

        #region BUTTON CLICKS

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string companyname = Convert.ToString(TextCompanyName.Text);
            string productname = Convert.ToString(TextProductName.Text);
            string productcode = Convert.ToString(TextProductCode.Text);
            string Product_Type = Convert.ToString(ComboProductType.SelectedItem.ToString());
            string size = Convert.ToString(ComboSize.SelectedItem.ToString());
            string each = Convert.ToString(ComboEach.SelectedItem.ToString());
            string mrp = Convert.ToString(TextMRP.Text);

            if (TextProductName.Text != "" && TextProductCode.Text != "")
            {
                BALObject.AddProduct(companyname, productname, productcode, Product_Type, size, each, mrp);
                MessageBox.Show("Recored inserted successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please Fillup all fields correctly...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (ProductID != 0)
            {
                DataTable dt = BALObject.EditProductDetails(ProductID);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    TextCompanyName.Text = Convert.ToString(dr["Company_Name"].ToString());
                    TextProductName.Text = Convert.ToString(dr["Product_Name"].ToString());
                    TextProductCode.Text = Convert.ToString(dr["Product_Code"].ToString());
                    ComboProductType.SelectedItem = Convert.ToString(dr["Product_Type"].ToString());
                    ComboSize.SelectedItem = Convert.ToString(dr["Size"].ToString());
                    ComboEach.SelectedItem = Convert.ToString(dr["EACH"].ToString());
                    TextMRP.Text = Convert.ToString(dr["MRP"].ToString());
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
            string companyname = Convert.ToString(TextCompanyName.Text);
            string productname = Convert.ToString(TextProductName.Text);
            string productcode = Convert.ToString(TextProductCode.Text);
            string Product_Type = Convert.ToString(ComboProductType.SelectedItem.ToString());
            string size = Convert.ToString(ComboSize.SelectedItem.ToString());
            string each = Convert.ToString(ComboEach.SelectedItem.ToString());
            string mrp = Convert.ToString(TextMRP.Text.ToString());

            if (BALObject.UpdateProductDetail(ProductID, companyname, productname, productcode, Product_Type, size, each, mrp))
            {
                MessageBox.Show("Recored Updated Successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Somthing is going wrong call Developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (BALObject.DeleteProductDetail(ProductID))
            {
                MessageBox.Show("Recored Delete Successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView();
            }
            else
            {
                MessageBox.Show("Somthing is going wrong call Developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region GRID VIEW 

        public void FillGridView()
        {
            DataTable dt = BALObject.Fatch_Product_Data();

            if (dt.Rows.Count > 0)
            {
                GridView(dt);
            }
        }

        public void GridView(DataTable Table)
        {
            #region
            DataTable dt = Table;

            GridAddProduct.AutoGenerateColumns = false;
            GridAddProduct.Columns.Clear();

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
            Company_Name.Width = 220;
            GridAddProduct.Columns.Insert(0, Company_Name);

            DataGridViewTextBoxColumn Product_Name = new DataGridViewTextBoxColumn();
            Product_Name.Name = "Product_Name";
            Product_Name.HeaderText = "Product Name";
            Product_Name.DataPropertyName = "Product_Name";
            Product_Name.Width = 220;
            GridAddProduct.Columns.Insert(1, Product_Name);

            DataGridViewTextBoxColumn Product_Code = new DataGridViewTextBoxColumn();
            Product_Code.Name = "Product_Code";
            Product_Code.HeaderText = "Product Code";
            Product_Code.DataPropertyName = "Product_Code";
            Product_Code.Width = 100;
            GridAddProduct.Columns.Insert(2, Product_Code);

            DataGridViewTextBoxColumn Product_Type = new DataGridViewTextBoxColumn();
            Product_Type.Name = "Product_Type";
            Product_Type.HeaderText = "Product Type";
            Product_Type.DataPropertyName = "Product_Type";
            Product_Type.Width = 150;
            GridAddProduct.Columns.Insert(3, Product_Type);

            DataGridViewTextBoxColumn Size = new DataGridViewTextBoxColumn();
            Size.Name = "Size";
            Size.HeaderText = "Size";
            Size.DataPropertyName = "Size";
            Size.Width = 100;
            GridAddProduct.Columns.Insert(4, Size);

            DataGridViewTextBoxColumn EACH = new DataGridViewTextBoxColumn();
            EACH.Name = "EACH";
            EACH.HeaderText = "EACH";
            EACH.DataPropertyName = "EACH";
            EACH.Width = 100;
            GridAddProduct.Columns.Insert(5, EACH);

            DataGridViewTextBoxColumn MRP = new DataGridViewTextBoxColumn();
            MRP.Name = "MRP";
            MRP.HeaderText = "MRP";
            MRP.DataPropertyName = "MRP";
            MRP.Width = 130;
            GridAddProduct.Columns.Insert(6, MRP);

            DataGridViewTextBoxColumn Product_ID = new DataGridViewTextBoxColumn();
            Product_ID.Name = "Product_ID";
            Product_ID.HeaderText = "Product ID";
            Product_ID.DataPropertyName = "Product_ID";
            Product_ID.Width = 100;
            Product_ID.Visible = false;
            GridAddProduct.Columns.Insert(7, Product_ID);

            GridAddProduct.DataSource = dt;
            GridAddProduct.Refresh();

            #endregion

            UpdateFont();
            this.GridAddProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in GridAddProduct.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }
        }

        private void GridAddProduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductID = Convert.ToInt32(GridAddProduct.Rows[e.RowIndex].Cells[7].Value);
        }

        #endregion


        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchString = Convert.ToString(TextSearch.Text);

            if (SearchString != "")
            {
                DataTable dt = BALObject.SearchProductDetails(SearchString);
                GridView(dt);
            }
            else
            {
                FillGridView();
            }
        }

        public void ClearFields()
        {
            TextCompanyName.Text = ""; TextCompanyName.Focus();
            TextProductName.Text = "";
            TextProductCode.Text = "";
            ComboProductType.SelectedIndex = 0;
            ComboSize.SelectedIndex = 0;
            ComboEach.SelectedItem = 0;
            TextMRP.Text = "";
        }

        private void LoadCompanyName()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            namesCollection = BALObject.SelectCompanyName();

            TextCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextCompanyName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextCompanyName.AutoCompleteCustomSource = namesCollection;
        }

        public void LoadProductName(string CompanyName)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            namesCollection = BALObject.SelectProductName(CompanyName);

            TextProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextProductName.AutoCompleteCustomSource = namesCollection;
        }

        string CompanyName = "";

        private void TextCompanyName_TextChanged(object sender, EventArgs e)
        {
            CompanyName = Convert.ToString(TextCompanyName.Text);
            LoadProductName(CompanyName);
        }
         
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

          private void TextProductCode_Leave(object sender, EventArgs e)
        {
            string ProductName = Convert.ToString(TextProductCode.Text);

            DataTable dt = BALObject.Fiend_Product_Present_or_Not(ProductName);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("This Product Code is allready present, insert new", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                

                String searchValue = Convert.ToString(TextProductCode.Text);
                int rowIndex = -1;
                foreach (DataGridViewRow row in GridAddProduct.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        GridAddProduct.Rows[rowIndex].Selected = true;
                        //GridAddProduct.DefaultCellStyle.SelectionForeColor = Color.Red;
                        TextProductCode.Text = "";
                        TextProductCode.Focus();
                        break;
                    }
                }
            }
            else
            {
                
            }
        }




    }
}
