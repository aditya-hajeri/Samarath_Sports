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
    public partial class Quotation : Form
    {
        BAL.BAL BALObject;

        int ProductID=0;  // Veriable for store quatation product id
        int ID; // Veriabl for store Main Quotation ID in Main_Quotation Table

        double TotalTax = 0; // Veriable for store Total tax on pericular product

        public Quotation()
        {
            InitializeComponent();
        }

        private void Quotation_Load(object sender, EventArgs e)
        {
            BALObject = new BAL.BAL();
            //LoadCompanyName();
            QuotationString();
            TextCustomerName.Focus();
        }

        public void QuotationString()
        {
            string QuotationNo = BALObject.GenerateQuotationNo();
            TextQuotationNo.Text = Convert.ToString(QuotationNo);
            ID = BALObject.ReturnID();
        }



        #region GRIDVIEW

        public void FillGridView()
        {
            string Quotation_No = Convert.ToString(TextQuotationNo.Text);

            DataTable dt = BALObject.Fatch_Quotation(Quotation_No);

            if (dt.Rows.Count > 0)
            {
                GridView(dt);

                double TotalBill = BALObject.CalculateQuatationAmount(dt);
                TextTotalCost.Text = Convert.ToString(TotalBill);

            }
        }

        public void GridView(DataTable Table)
        {
            #region
            DataTable dt = Table;

            QuotationProduct.AutoGenerateColumns = false;
            QuotationProduct.Columns.Clear();

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

            DataGridViewTextBoxColumn ProductCode = new DataGridViewTextBoxColumn();
            ProductCode.Name = "ProductCode";
            ProductCode.HeaderText = "Product Code";
            ProductCode.DataPropertyName = "ProductCode";
            ProductCode.Width = 110;
            QuotationProduct.Columns.Insert(0, ProductCode);

            DataGridViewTextBoxColumn CompanyName = new DataGridViewTextBoxColumn();
            CompanyName.Name = "CompanyName";
            CompanyName.HeaderText = "Company Name";
            CompanyName.DataPropertyName = "CompanyName";
            CompanyName.Width = 110;
            QuotationProduct.Columns.Insert(1, CompanyName);

            DataGridViewTextBoxColumn ProductName = new DataGridViewTextBoxColumn();
            ProductName.Name = "ProductName";
            ProductName.HeaderText = "Product Name";
            ProductName.DataPropertyName = "ProductName";
            ProductName.Width = 170;
            QuotationProduct.Columns.Insert(2, ProductName);

            DataGridViewTextBoxColumn ProductType = new DataGridViewTextBoxColumn();
            ProductType.Name = "ProductType";
            ProductType.HeaderText = "Product Type";
            ProductType.DataPropertyName = "ProductType";
            ProductType.Width = 130;
            QuotationProduct.Columns.Insert(3, ProductType);

            DataGridViewTextBoxColumn Rate = new DataGridViewTextBoxColumn();
            Rate.Name = "Rate";
            Rate.HeaderText = "Rate";
            Rate.DataPropertyName = "Rate";
            Rate.Width = 55;
            QuotationProduct.Columns.Insert(4, Rate);

            DataGridViewTextBoxColumn Discount = new DataGridViewTextBoxColumn();
            Discount.Name = "Discount";
            Discount.HeaderText = "Discount";
            Discount.DataPropertyName = "Discount";
            Discount.Width = 60;
            QuotationProduct.Columns.Insert(5, Discount);

            DataGridViewTextBoxColumn DiscountAmount = new DataGridViewTextBoxColumn();
            DiscountAmount.Name = "DiscountAmount";
            DiscountAmount.HeaderText = "Discount Amount";
            DiscountAmount.DataPropertyName = "DiscountAmount";
            DiscountAmount.Width = 70;
            QuotationProduct.Columns.Insert(6, DiscountAmount);

            DataGridViewTextBoxColumn Quantity = new DataGridViewTextBoxColumn();
            Quantity.Name = "Quantity";
            Quantity.HeaderText = "Quantity";
            Quantity.DataPropertyName = "Quantity";
            Quantity.Width = 72;
            QuotationProduct.Columns.Insert(7, Quantity);

            DataGridViewTextBoxColumn TotalAmount = new DataGridViewTextBoxColumn();
            TotalAmount.Name = "TotalAmount";
            TotalAmount.HeaderText = "Total Amount";
            TotalAmount.DataPropertyName = "TotalAmount";
            TotalAmount.Width = 100;
            QuotationProduct.Columns.Insert(8, TotalAmount);

            DataGridViewTextBoxColumn Vat = new DataGridViewTextBoxColumn();
            Vat.Name = "Vat";
            Vat.HeaderText = "Vat";
            Vat.DataPropertyName = "Vat";
            Vat.Width = 40;
            QuotationProduct.Columns.Insert(9, Vat);

            DataGridViewTextBoxColumn GrantTotal = new DataGridViewTextBoxColumn();
            GrantTotal.Name = "GrantTotal";
            GrantTotal.HeaderText = "Grant Total";
            GrantTotal.DataPropertyName = "GrantTotal";
            GrantTotal.Width = 60;            
            QuotationProduct.Columns.Insert(10, GrantTotal);

            DataGridViewTextBoxColumn QuotationID = new DataGridViewTextBoxColumn();
            QuotationID.Name = "QuotationID";
            QuotationID.HeaderText = "ID";
            QuotationID.DataPropertyName = "QuotationID";
            QuotationID.Width = 100;
            QuotationID.Visible = false;
            QuotationProduct.Columns.Insert(11, QuotationID);

            QuotationProduct.DataSource = dt;
            QuotationProduct.Refresh();

            #endregion

            UpdateFont();
            this.QuotationProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in QuotationProduct.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            }
        }

        private void QuotationProduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductID = Convert.ToInt32(QuotationProduct.Rows[e.RowIndex].Cells[11].Value);
        }

        #endregion



        #region BUTTON

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TextCustomerName.Text != "" && TextCode.Text != "" && TextDiscount.Text != "" && TextQuantity.Text != "" && TextVat.Text != "")
            {
                string Quotation_No = Convert.ToString(TextQuotationNo.Text);
                string CustomerName = Convert.ToString(TextCustomerName.Text);
                string CompanyName = Convert.ToString(TextCompanyName.Text);
                string ProductName = Convert.ToString(TextName.Text);
                string ProductCode = Convert.ToString(TextCode.Text);
                string ProductType = Convert.ToString(TextType.Text);
                string Rate = Convert.ToString(TextRate.Text);
                string Discount = Convert.ToString(TextDiscount.Text);
                string DiscountAmount = Convert.ToString(TextDiscountAmount.Text);
                string Quantity = Convert.ToString(TextQuantity.Text);
                string TotalAmount = Convert.ToString(TextTotalAmount.Text);
                string Tax = Convert.ToString(TextVat.Text);
                string GrantTotal = Convert.ToString(TextGrantTotal.Text);
                int MainQuotation_ID = Convert.ToInt32(ID);

                BALObject.Save_Quotation(MainQuotation_ID, Quotation_No, CompanyName, ProductName, ProductCode, ProductType, Rate, Discount, DiscountAmount, Quantity, TotalAmount, Tax, GrantTotal);

                MessageBox.Show("Product Add Successfully !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear();

                FillGridView();
            }

            else
            {
                MessageBox.Show("Plese Insert All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TextTotalCost.Text != "")
            {
                string QuotationNo = Convert.ToString(TextQuotationNo.Text);
                string CustomerName = Convert.ToString(TextCustomerName.Text);
                string TotalCost = Convert.ToString(TextTotalCost.Text);
                string TotalCostText = "";
                string Date = Convert.ToString(DatePicker1.Value.ToShortDateString());

                string Total_Tax_Amount = Convert.ToString(TotalTax);

                BALObject.SaveMainQuotation(QuotationNo, CustomerName, TotalCost, TotalCostText, Total_Tax_Amount, Date);

                MessageBox.Show("Quotation Add Successfully...!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Please Insert all details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ProductID == 0)
            {
                MessageBox.Show("Please Select Recored.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (BALObject.DeleteQuotationProduct(ProductID))
                {
                    MessageBox.Show("Product Delete Successfully...!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Somthing is wrong call Developer...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }        
        }

        #endregion



        #region OTHER

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
                TextRate.Text = Convert.ToString(dr["MRP"].ToString());

            }
            else
            {
                MessageBox.Show("Product is not available in productlis please add first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextDiscount_Leave(object sender, EventArgs e)
        {
            if (TextRate.Text != "")
            {
                double Rate = Convert.ToDouble(TextRate.Text);
                double Discount = Convert.ToDouble(TextDiscount.Text);

                double DiscountAmount = ((Rate / 100) * Discount);

                double AfterDiscount = Rate - DiscountAmount;

                TextDiscountAmount.Text = Convert.ToString(AfterDiscount);

                TextQuantity.Focus();

            }
        }

        private void TextQuantity_Leave(object sender, EventArgs e)
        {
            if (TextQuantity.Text == ""&& TextDiscountAmount.Text!="")
            {
                MessageBox.Show("Plese Insert Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextQuantity.Focus();
            }
        }

        private void TextQuantity_TextChanged(object sender, EventArgs e)
        {
            if (TextQuantity.Text != "")
            {
                double DiscountAmount = Convert.ToDouble(TextDiscountAmount.Text);
                double Quantity = Convert.ToDouble(TextQuantity.Text);

                double TotalAmount = DiscountAmount * Quantity;
                TextTotalAmount.Text = Convert.ToString(TotalAmount);
            }
            if (TextQuantity.Text == "")
            {
                TextTotalAmount.Text = "";
            }
        }

        private void TextVat_Leave(object sender, EventArgs e)
        {
            if (TextVat.Text != "")
            {
                double Tax = Convert.ToDouble(TextVat.Text);
                double Amount = Convert.ToDouble(TextTotalAmount.Text);
                double TaxAmount;
                double GrantTotal;

                TaxAmount = ((Amount / 100) * Tax);
                TotalTax = TotalTax + TaxAmount;

                GrantTotal = Amount + TaxAmount;
                TextGrantTotal.Text = Convert.ToString(GrantTotal);
            }
        }

        private void TextVat_TextChanged(object sender, EventArgs e)
        {
            //if (TextVat.Text != "")
            //{
            //    double Tax = Convert.ToDouble(TextVat.Text);
            //    double Amount = Convert.ToDouble(TextTotalAmount.Text);
            //    double TaxAmount;
            //    double GrantTotal;

            //    TaxAmount = ((Amount / 100) * Tax);

            //    GrantTotal = Amount + TaxAmount;
            //    TextGrantTotal.Text = Convert.ToString(GrantTotal);
            //}
        }        

        public void Clear()
        {
            TextCode.Text = ""; TextCompanyName.Text = ""; TextName.Text = ""; TextType.Text = "";
            TextDiscount.Text = ""; TextDiscount.Text = "0";

            TextQuantity.Text = "";

            TextVat.Text = ""; TextVat.Text = "0";
            TextRate.Text = ""; TextDiscountAmount.Text = ""; TextQuantity.Text = ""; TextTotalAmount.Text = ""; TextGrantTotal.Text = "";
        }

        #endregion 



        #region

        private void LoadCompanyName()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            namesCollection = BALObject.SelectCompanyNameForStock();

            TextCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextCompanyName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextCompanyName.AutoCompleteCustomSource = namesCollection;
        }

        private void TextCompanyName_Leave(object sender, EventArgs e)
        {
            //string Company_name = Convert.ToString(TextCompanyName.Text);
            //LoadProductName(Company_name);
        }

        public void LoadProductName(string CompanyName)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            namesCollection = BALObject.SelectProductNameForBilling(CompanyName);

            TextName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextName.AutoCompleteCustomSource = namesCollection;
        }

        private void TextCompanyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextName_Leave(object sender, EventArgs e)
        {
            //string productname = Convert.ToString(TextCode.Text);
            //string companyname = Convert.ToString(TextCompanyName.Text);

            //DataTable dt = BALObject.ProductDetails(productname, companyname);

            //if (dt.Rows.Count > 0)
            //{
            //    DataRow dr = dt.Rows[0];

            //    TextCode.Text = Convert.ToString(dr["Product_Code"].ToString());
            //    TextType.Text = Convert.ToString(dr["Product_Type"].ToString());
            //    TextRate.Text = Convert.ToString(dr["MRP"].ToString());

            //}
            //else
            //{
            //    MessageBox.Show("Product is not available in productlis please add first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion
      

    }
}
