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
    public partial class Stock_Maintain : Form
    {
        BAL.BAL BALObject;

        string CompanyNames = "";   // Veriable for Store Company Name
        string Product_Type = "";   // Veriable for Store Product type in Combobox
        string Product_Name = "";   // Veriable for store Product Name for Fatch other details like code
        string Produc_Code = "";    // Veriable for store Produc_Code for fatch Stock
        int STOCKID = 0;            // Veriable for store Stock ID

        public Stock_Maintain()
        {
            InitializeComponent();
        }

        private void Stock_Maintain_Load(object sender, EventArgs e)
        {
            BALObject = new BAL.BAL();
            ComboProductType.SelectedIndex = 0;
            LoadCompanyName();
            TextCompanyName.Focus();
            FillGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string companyname = Convert.ToString(TextCompanyName.Text);
            string producttype = Convert.ToString(ComboProductType.SelectedItem.ToString());
            string productname = Convert.ToString(TextProductName.Text);
            string productcode = Convert.ToString(TextProductCode.Text);
            string totalstock = Convert.ToString(TextTotal.Text);

            if (TextCompanyName.Text != "" && ComboProductType.SelectedIndex != 0 && TextProductName.Text != "" && TextProductCode.Text != "" && TextTotal.Text != "")
            {
                if (STOCKID == 0)
                {
                    BALObject.InsertStock(companyname, producttype, productname, productcode, totalstock);
                    MessageBox.Show("Recored inserted successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearField();
                    FillGridView();
                }
                else
                {
                    BALObject.UpdateStock(STOCKID, totalstock);
                    MessageBox.Show("Stock Updated Successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearField();
                    FillGridView();
                }
            }
            else
            {
                MessageBox.Show("Please Fillup all fields correctly...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }        

        private void TextCompanyName_TextChanged(object sender, EventArgs e)
        {
            //CompanyNames = Convert.ToString(TextCompanyName.Text);
            //LoadProductName(CompanyNames);
        }

        private void TextProductName_TextChanged(object sender, EventArgs e)
        {
            //if (TextProductName.Text != "")
            //{
            //    Product_Name = Convert.ToString(TextProductName.Text);

            //    DataTable dt = BALObject.FatchProduct_Details(Product_Name);

            //    if (dt.Rows.Count > 0)
            //    {
            //        DataRow dr = dt.Rows[0];

            //        TextProductCode.Text = dr["ProductCode"].ToString();
            //        TextStock.Text = dr["Stock"].ToString();
            //    }
            //}
        }

        private void ComboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboProductType.SelectedIndex != 0)
            {
                CompanyNames = Convert.ToString(TextCompanyName.Text);
                Product_Type = ComboProductType.SelectedItem.ToString();

                LoadProductName(CompanyNames);

                if (TextProductName.Text != "" && TextProductCode.Text != "" && TextStock.Text != "")
                {
                    TextProductName.Text = ""; TextProductCode.Text = ""; TextStock.Text = "";

                    if (TextStockAdded.Text != "" && TextTotal.Text != "")
                    {
                        TextStockAdded.Text = ""; TextTotal.Text = "";
                    }
                }
            }
        }

        private void TextProductCode_Leave(object sender, EventArgs e)
        {
            if (TextProductName.Text != "")
            {
                Product_Name = Convert.ToString(TextProductName.Text);
                Product_Type = Convert.ToString(ComboProductType.SelectedItem.ToString());
                Produc_Code = Convert.ToString(TextProductCode.Text);

                DataTable dt = BALObject.GetStock(Product_Name, Product_Type, Produc_Code);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                                        
                    TextStock.Text = dr["Stock"].ToString();
                    STOCKID = Convert.ToInt32(dr["StockID"].ToString());
                }

                else
                {
                    MessageBox.Show(" We add this product in our list First Time ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextStock.Text = "0";
                }

            }
        }

        private void TextProductName_Leave(object sender, EventArgs e)
        {
            if (TextProductName.Text != "")
            {
                Product_Name = Convert.ToString(TextProductName.Text);
                Product_Type = Convert.ToString(ComboProductType.SelectedItem.ToString());

                DataTable dt = BALObject.FatchProduct_Details(Product_Name, Product_Type);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    TextProductCode.Text = dr["Product_Code"].ToString();
                    //TextStock.Text = dr["Stock"].ToString();
                }

                else
                {
                    MessageBox.Show(" This product is not available...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextProductName.Text = "";

                    ClearField();
                }

            }
        }

        private void TextStockAdded_TextChanged(object sender, EventArgs e)
        {
            if (TextStockAdded.Text != "")
            {
                int available_stock = Convert.ToInt32(TextStock.Text);
                int added_stock = Convert.ToInt32(TextStockAdded.Text);
                int total_Stock = 0;

                total_Stock = available_stock + added_stock;

                TextTotal.Text = Convert.ToString(total_Stock);
            }
        }

        public void ClearField()
        {
            TextCompanyName.Text = ""; TextCompanyName.Focus();
            ComboProductType.SelectedIndex = 0;
            TextProductName.Text = "";
            TextProductCode.Text = "";
            TextTotal.Text = "";
            TextStock.Text = "";
            TextTotal.Text = "";
            TextStockAdded.Text = "";
        }

        private void LoadCompanyName()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            namesCollection = BALObject.SelectCompanyNameForStock();

            TextCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextCompanyName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextCompanyName.AutoCompleteCustomSource = namesCollection;
        }

        public void LoadProductName(string CompanyName)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            namesCollection = BALObject.SelectProductNameForStock(CompanyName, Product_Type);

            TextProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextProductName.AutoCompleteCustomSource = namesCollection;
        }


        public void FillGridView()
        {
            DataTable dt = BALObject.FatchRecored();

            if (dt.Rows.Count > 0)
            {
                GridView(dt);
            }
        }


        public void GridView(DataTable Table)
        {                             
            #region
            DataTable dt = Table;

            GridStockMgmt.AutoGenerateColumns = false;
            GridStockMgmt.Columns.Clear();

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

            DataGridViewTextBoxColumn CompanyName = new DataGridViewTextBoxColumn();
            CompanyName.Name = "CompanyName";
            CompanyName.HeaderText = "Company Name";
            CompanyName.DataPropertyName = "CompanyName";
            CompanyName.Width = 230;
            GridStockMgmt.Columns.Insert(0, CompanyName);

            DataGridViewTextBoxColumn ProductType = new DataGridViewTextBoxColumn();
            ProductType.Name = "ProductType";
            ProductType.HeaderText = "Product Type";
            ProductType.DataPropertyName = "ProductType";
            ProductType.Width = 220;
            GridStockMgmt.Columns.Insert(1, ProductType);

            DataGridViewTextBoxColumn ProductName = new DataGridViewTextBoxColumn();
            ProductName.Name = "ProductName";
            ProductName.HeaderText = "Product Name";
            ProductName.DataPropertyName = "ProductName";
            ProductName.Width = 200;
            GridStockMgmt.Columns.Insert(2, ProductName);

            DataGridViewTextBoxColumn ProductCode = new DataGridViewTextBoxColumn();
            ProductCode.Name = "ProductCode";
            ProductCode.HeaderText = "Product Code";
            ProductCode.DataPropertyName = "ProductCode";
            ProductCode.Width = 150;
            GridStockMgmt.Columns.Insert(3, ProductCode);

            DataGridViewTextBoxColumn Stock = new DataGridViewTextBoxColumn();
            Stock.Name = "Stock";
            Stock.HeaderText = "Stock";
            Stock.DataPropertyName = "Stock";
            Stock.Width = 80;
            GridStockMgmt.Columns.Insert(4, Stock);

            DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
            Date.Name = "Date";
            Date.HeaderText = "Date";
            Date.DataPropertyName = "Date";
            Date.Width = 120;
            GridStockMgmt.Columns.Insert(5, Date);

            DataGridViewTextBoxColumn StockID = new DataGridViewTextBoxColumn();
            StockID.Name = "StockID";
            StockID.HeaderText = "StockID";
            StockID.DataPropertyName = "StockID";
            StockID.Width = 130;
            StockID.Visible = false;
            GridStockMgmt.Columns.Insert(6, StockID);



            GridStockMgmt.DataSource = dt;
            GridStockMgmt.Refresh();

            #endregion

            UpdateFont();
            this.GridStockMgmt.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }


        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in GridStockMgmt.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }
        }
    }
}
