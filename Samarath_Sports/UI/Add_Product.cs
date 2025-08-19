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
    public partial class Add_Product : Form
    {
        BAL.BAL BALObject;

        int ProductID = 0; // Veriable for store Product ID

        public Add_Product()
        {
            InitializeComponent();
        }

        private void Add_Product_Load(object sender, EventArgs e)
        {
            BALObject = new BAL.BAL();
            FillGridView();
        }

        

        #region GRIDVIEW

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

            DataGridViewTextBoxColumn Product_Name = new DataGridViewTextBoxColumn();
            Product_Name.Name = "Product_Name";
            Product_Name.HeaderText = "Product Name";
            Product_Name.DataPropertyName = "Product_Name";
            Product_Name.Width = 290;
            GridAddProduct.Columns.Insert(0, Product_Name);

            DataGridViewTextBoxColumn Product_Code = new DataGridViewTextBoxColumn();
            Product_Code.Name = "Product_Code";
            Product_Code.HeaderText = "Product Code";
            Product_Code.DataPropertyName = "Product_Code";
            Product_Code.Width = 290;
            GridAddProduct.Columns.Insert(1, Product_Code);

            DataGridViewTextBoxColumn Product_ID = new DataGridViewTextBoxColumn();
            Product_ID.Name = "Product_ID";
            Product_ID.HeaderText = "Product ID";
            Product_ID.DataPropertyName = "Product_ID";
            Product_ID.Width = 100;
            Product_ID.Visible = false;
            GridAddProduct.Columns.Insert(2, Product_ID);

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
            ProductID = Convert.ToInt32(GridAddProduct.Rows[e.RowIndex].Cells[2].Value);
        }

        #endregion


        #region BUTTON

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string productname = Convert.ToString(TextProductName.Text);
            string productcode = Convert.ToString(TextProductCode.Text);

            if (TextProductName.Text != "" && TextProductCode.Text != "")
            {
                //BALObject.AddProduct(productname, productcode);
                MessageBox.Show("Recored inserted successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillGridView();
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
                    TextProductName.Text = Convert.ToString(dr["Product_Name"].ToString());
                    TextProductCode.Text = Convert.ToString(dr["Product_Code"].ToString());
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
            string productname = Convert.ToString(TextProductName.Text);
            string productcode = Convert.ToString(TextProductCode.Text);

            //if (BALObject.UpdateProductDetail(ProductID, productname, productcode))
            //{
            //    MessageBox.Show("Recored Updated Successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    FillGridView();
            //}
            //else
            //{
            //    MessageBox.Show("Somthing is going wrong call Developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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


    }
}
