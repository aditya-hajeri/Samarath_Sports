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
    public partial class Billing : Form
    {
        BAL.BAL BALObject;
        int CompanyID = 0;  // Veriable for store CompanyID, when we select company
        int ProductID = 0;  // Veriable for store ProductID, when we select Row in GridView for Edit / Delete / Update

        public Billing()
        {
            InitializeComponent();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            BALObject = new BAL.BAL();

            //LoadCustomerName();
            //LoadCompanyName();

            TextCustomerName.Focus();
            BillingString();
        }



        public void BillingString()
        {
            string Billing_String = BALObject.GenerateBillingNo();

            TextBillingNo.Text = Convert.ToString(Billing_String);
        }

        private void LoadCustomerName()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            namesCollection = BALObject.SelectCustomerNameForBilling();

            TextCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextCustomerName.AutoCompleteCustomSource = namesCollection;
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

            namesCollection = BALObject.SelectProductNameForBilling(CompanyName);

            TextName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextName.AutoCompleteCustomSource = namesCollection;
        }

        



        private void TextCompanyName_Leave(object sender, EventArgs e)
        {
            //string Company_name = Convert.ToString(TextCompanyName.Text);
            //CompanyID = BALObject.CompanyID(Company_name);

            //LoadProductName(Company_name);
        }
        
        private void TextName_Leave(object sender, EventArgs e)
        {
            //int Stock = 0;
            //string productname = Convert.ToString(TextName.Text);
            //string companyname=Convert.ToString(TextCompanyName.Text);
            //DataTable dt = BALObject.ProductDetails(productname, companyname);

            //if (dt.Rows.Count > 0)
            //{
            //    DataRow dr = dt.Rows[0];

            //    TextCode.Text = Convert.ToString(dr["Product_Code"].ToString());
            //    TextType.Text = Convert.ToString(dr["Product_Type"].ToString());
            //    TextSize.Text = Convert.ToString(dr["Size"].ToString());
            //    TextEach.Text = Convert.ToString(dr["EACH"].ToString());
            //    TextMRP.Text = Convert.ToString(dr["MRP"].ToString());

            //    Stock = BALObject.Fatch_Stock(productname, Convert.ToString(TextCode.Text));

            //    if (Stock != 0)
            //    {
            //        TextStock.Text = Convert.ToString(Stock);
            //    }

            //    else
            //    {
            //        TextStock.Text = "0";
            //    }
            //}

            //else
            //{
            //    MessageBox.Show("Product is not available in productlis please add first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    TextName.Text = "";
            //    TextName.Focus();
            //}
        }

        


        
     ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
      
        private void TextCode_Leave(object sender, EventArgs e)
        {
            string ProductCode = Convert.ToString(TextCode.Text);

            DataTable dt = BALObject.FatchProdut_ThroughProductCode(ProductCode);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                TextCompanyName.Text = Convert.ToString(dr["Company_Name"].ToString());
                TextName.Text = Convert.ToString(dr["Product_Name"].ToString());
                TextType.Text = Convert.ToString(dr["Product_Type"].ToString());
                TextSize.Text=Convert.ToString(dr["Size"].ToString());
                TextEach.Text = Convert.ToString(dr["EACH"].ToString());
                TextMRP.Text = Convert.ToString(dr["MRP"].ToString());
                //TextRate.Text = Convert.ToString(dr["MRP"].ToString());

                StockFinder();
            }
            else
            {
                MessageBox.Show("Product is not available in productlis please add first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void StockFinder()
        {
            int Stock = 0;
            string productname = Convert.ToString(TextName.Text);
            string companyname = Convert.ToString(TextCompanyName.Text);
            DataTable dt = BALObject.ProductDetails(productname, companyname);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                TextCode.Text = Convert.ToString(dr["Product_Code"].ToString());
                TextType.Text = Convert.ToString(dr["Product_Type"].ToString());
                TextSize.Text = Convert.ToString(dr["Size"].ToString());
                TextEach.Text = Convert.ToString(dr["EACH"].ToString());
                TextMRP.Text = Convert.ToString(dr["MRP"].ToString());

                Stock = BALObject.Fatch_Stock(productname, Convert.ToString(TextCode.Text));

                if (Stock != 0)
                {
                    TextStock.Text = Convert.ToString(Stock);
                }

                else
                {
                    TextStock.Text = "0";
                }

                TextCount.Focus();
            }

            else
            {
                MessageBox.Show("Product is not available in productlis please add first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextName.Text = "";
                TextName.Focus();
            }
        }


        private void TextCount_TextChanged(object sender, EventArgs e)
        {
            if (TextCount.Text != "")
            {
                double count = Convert.ToDouble(TextCount.Text);
                double mrp = Convert.ToDouble(TextMRP.Text);

                double total = count * mrp;
                TextTotal.Text = Convert.ToString(total);
            }
        }


        public void ClearField()
        {
            TextCompanyName.Text = ""; TextName.Text = "";
            TextCode.Text = ""; TextType.Text = "";
            TextSize.Text = ""; TextEach.Text = "";
            TextMRP.Text = ""; TextStock.Text = "";
            TextCount.Text = ""; TextTotal.Text = "";
        }



        #region BUTTONS

        private void BtnAdd_Click(object sender, EventArgs e)
        {           
                string BillingNo = Convert.ToString(TextBillingNo.Text);
                string CompanyName = Convert.ToString(TextCompanyName.Text);
                string productname = Convert.ToString(TextName.Text);
                string ProductCode = Convert.ToString(TextCode.Text);
                string ProductType = Convert.ToString(TextType.Text);
                string ProductCount = Convert.ToString(TextCount.Text);
                string ProductMRP = Convert.ToString(TextMRP.Text);
                string ProductPrise = Convert.ToString(TextTotal.Text);

                if (TextCompanyName.Text != "" && TextName.Text != "" && TextCode.Text != "" && TextType.Text != "" && TextCount.Text != "" && TextTotal.Text != "" && TextTotal.Text!="0")
                {
                    if (TextStock.Text != "0")
                    {
                        int Productcount = Convert.ToInt32(TextCount.Text);
                        int stock = Convert.ToInt32(TextStock.Text);
                        int totalstock = stock - Productcount;

                        BALObject.UpdateStockFromBilling(totalstock, Convert.ToString(TextName.Text), Convert.ToString(TextCode.Text));
                    }

                    BALObject.InsertBillgProduct(BillingNo, CompanyName, productname, ProductCode, ProductType, ProductCount, ProductMRP, ProductPrise);

                    DataTable dt = BALObject.FatchAddedProduct(BillingNo);
                    if (dt.Rows.Count > 0)
                    {
                        GridView(dt);

                        double TotalBill = BALObject.CalculateTotalAmount(dt);
                        TextTotalCost.Text = Convert.ToString(TotalBill);
                    }

                    ClearField();
                    TextCompanyName.Focus();
                }
                else
                {
                    MessageBox.Show("Please fill all information Correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                               
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TextTotalCost.Text != "")
            {
                string BillingNo = Convert.ToString(TextBillingNo.Text);
                string TotalPrise = Convert.ToString(TextTotalCost.Text);
                string CustomerName = Convert.ToString(TextCustomerName.Text);

                BALObject.SaveBill(BillingNo,CustomerName, TotalPrise);

                MessageBox.Show("Bill Save Successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill all information Correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ProductID != 0)
            {
                if (BALObject.DeleteProduct(ProductID))
                {
                    MessageBox.Show("Product is Deleted...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Somthing is wrong call Developer...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("If you want a delete product, please select first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                    
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

                

        #region GRIDVIEW

        public void GridView(DataTable Table)
        {
            #region
            DataTable dt = Table;

            AddedProduct.AutoGenerateColumns = false;
            AddedProduct.Columns.Clear();

            DataGridViewTextBoxColumn BillingNo = new DataGridViewTextBoxColumn();
            BillingNo.Name = "BillingNo";
            BillingNo.HeaderText = "Billing No";
            BillingNo.DataPropertyName = "BillingNo";
            BillingNo.Width = 120;
            AddedProduct.Columns.Insert(0, BillingNo);

            DataGridViewTextBoxColumn CompanyName = new DataGridViewTextBoxColumn();
            CompanyName.Name = "CompanyName";
            CompanyName.HeaderText = "Company Name";
            CompanyName.DataPropertyName = "CompanyName";
            CompanyName.Width = 150;
            AddedProduct.Columns.Insert(1, CompanyName);

            DataGridViewTextBoxColumn ProductName = new DataGridViewTextBoxColumn();
            ProductName.Name = "ProductName";
            ProductName.HeaderText = "Product Name";
            ProductName.DataPropertyName = "ProductName";
            ProductName.Width = 200;
            AddedProduct.Columns.Insert(2, ProductName);

            DataGridViewTextBoxColumn ProductCode = new DataGridViewTextBoxColumn();
            ProductCode.Name = "ProductCode";
            ProductCode.HeaderText = "ProductCode";
            ProductCode.DataPropertyName = "ProductCode";
            ProductCode.Width = 100;
            AddedProduct.Columns.Insert(3, ProductCode);

            DataGridViewTextBoxColumn ProductType = new DataGridViewTextBoxColumn();
            ProductType.Name = "ProductType";
            ProductType.HeaderText = "Product Type";
            ProductType.DataPropertyName = "ProductType";
            ProductType.Width = 130;
            AddedProduct.Columns.Insert(4, ProductType);

            DataGridViewTextBoxColumn ProductCount = new DataGridViewTextBoxColumn();
            ProductCount.Name = "ProductCount";
            ProductCount.HeaderText = "Product Count";
            ProductCount.DataPropertyName = "ProductCount";
            ProductCount.Width = 60;
            AddedProduct.Columns.Insert(5, ProductCount);

            DataGridViewTextBoxColumn ProductPrise = new DataGridViewTextBoxColumn();
            ProductPrise.Name = "ProductPrise";
            ProductPrise.HeaderText = "Product Prise";
            ProductPrise.DataPropertyName = "ProductPrise";
            ProductPrise.Width = 100;
            AddedProduct.Columns.Insert(6, ProductPrise);

            DataGridViewTextBoxColumn BillID = new DataGridViewTextBoxColumn();
            BillID.Name = "BillID";
            BillID.HeaderText = "BillID";
            BillID.DataPropertyName = "BillID";
            BillID.Width = 100;
            BillID.Visible = false;
            AddedProduct.Columns.Insert(7, BillID);

            AddedProduct.DataSource = dt;
            AddedProduct.Refresh();

            #endregion

            UpdateFont();
            this.AddedProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in AddedProduct.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }
        }

        private void AddedProduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductID = Convert.ToInt32(AddedProduct.Rows[e.RowIndex].Cells[7].Value);
        }

        #endregion

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddedProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TextType_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextStock_TextChanged(object sender, EventArgs e)
        {

        }

       

    }
}
