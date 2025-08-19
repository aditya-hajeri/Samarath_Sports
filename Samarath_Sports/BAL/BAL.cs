using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using System.Globalization;
using System.Windows.Forms;

using Samarath_Sports.DAL;
using System.Data;

namespace Samarath_Sports.BAL
{

    class BAL
    {
        DAL.DAL DALObject = new DAL.DAL();

        #region CODING FOR *** ADD COMPANY *** PAGE

        // Coding for Add Company Details in Company_Details Table
        public void AddCompany(string companyname)
        {
            DALObject.AddCompany(companyname);
        }

        // Coding for Fatch Data from Company_Details Table
        public DataTable Fatch_Company_Data()
        {
            DataTable dt = DALObject.Fatch_Company_Data();
            return dt;
        }

        // Coding for Edit Company Details from Company_Details Table
        public DataTable EditCompanyDetails(int CompanyID)
        {
            DataTable dt = DALObject.EditCompanyDetails(CompanyID);
            return dt;
        }

        // Coding for Update Company Details From Company_Details Table
        public bool UpdateCompanyDetail(int CompanyID, string Companyname)
        {
            if (DALObject.UpdateCompanyDetail(CompanyID, Companyname))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Coding for Delete Company Details From Company_Details Table
        public bool DeleteCompanyDetail(int CompanyID)
        {
            if (DALObject.DeleteCompanyDetail(CompanyID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Coding for Search Recored form Product_Name,Product_Code form Product_Details Table
        public DataTable SearchCompanyDetails(string searchstring)
        {
            DataTable dt = DALObject.SearchCompanyDetails(searchstring);
            return dt;
        }

        #endregion


        #region CODING FOR *** ADD PRODUCT *** PAGE

        // Codding for Add product in Product_Details table
        public void AddProduct(string companyname, string productname, string productcode, string Product_Type, string size, string each, string mrp)
        {
            DALObject.AddProduct(companyname, productname, productcode, Product_Type, size, each, mrp);
        }

        // Coding for Fatct dtat from Product_Details Table 
        public DataTable Fatch_Product_Data()
        {
            DataTable dt = DALObject.Fatch_Product_Data();
            return dt;
        }

        // Coding for Edit Product Details from Product_Details Table
        public DataTable EditProductDetails(int ProductID)
        {
            DataTable dt = DALObject.EditProductDetails(ProductID);
            return dt;
        }

        // Coding for Update Product Details From Product_Details Table
        public bool UpdateProductDetail(int ProductID, string companyname, string productname, string productcode, string Product_Type, string size, string each, string mrp)
        {
            if (DALObject.UpdateProductDetail(ProductID, companyname, productname, productcode, Product_Type, size, each, mrp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Coding for Delete Product Details From Product_Details Table
        public bool DeleteProductDetail(int ProductID)
        {
            if (DALObject.DeleteProductDetail(ProductID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Search Recored form Product_Name,Product_Code form Product_Details Table
        public DataTable SearchProductDetails(string searchstring)
        {
            DataTable dt = DALObject.SearchProductDetails(searchstring);
            return dt;
        }

        // Coding for get Company name list from Company_Details
        public AutoCompleteStringCollection SelectProductName(string CompanyName)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            namesCollection = DALObject.SelectProductName(CompanyName);
            return namesCollection;
        }

        // Coding for get Company name list from Company_Details
        public AutoCompleteStringCollection SelectCompanyName()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            namesCollection = DALObject.SelectCompanyName();
            return namesCollection;
        }

        // Coding for fiend Product is present or not in list
        public DataTable Fiend_Product_Present_or_Not(string ProductName)
        {
            DataTable dt = DALObject.Fiend_Product_Present_or_Not(ProductName);
            return dt;
        }

        #endregion

        
        #region CODING FOR *** STOCK MAINTAIN *** PAGE

        // Coding for Insert Stock in Stock_Management Table
        public void InsertStock(string CompanyName, string Product_Type, string ProductName, string Code, string Totalstock)
        {
            DALObject.InsertStock(CompanyName, Product_Type, ProductName, Code, Totalstock);
        }

         // Coding for Update Stock in Stock_Management Table
        public void UpdateStock(int StockID, string Totalstock)
        {
            DALObject.UpdateStock(StockID, Totalstock);
        }

        // Coding for get Company name list from Company_Details
        public AutoCompleteStringCollection SelectCompanyNameForStock()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            namesCollection = DALObject.SelectCompanyNameForStock();
            return namesCollection;
        }

        // Coding for get Product name list from Product_Details
        public AutoCompleteStringCollection SelectProductNameForStock(string CompanyName, string Product_Type)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            namesCollection = DALObject.SelectProductNameForStock(CompanyName, Product_Type);
            return namesCollection;
        }


        // Coding for Get all product details forom product name
        public DataTable FatchProduct_Details(string ProductName, string product_type)
        {
            DataTable dt = DALObject.FatchProduct_Details(ProductName,product_type);
            return dt;
        }

        // Coding for Get stock form Stock_Management table 
        public DataTable GetStock(string productname, string producttype, string productcodoe)
        {
            DataTable dt = DALObject.GetStock(productname, producttype, productcodoe);
            return dt;
        }

        // Coding for fatch recored in Stock_Management Table
        public DataTable FatchRecored()
        {
            DataTable dt = DALObject.FatchRecored();
            return dt;
        }

        #endregion


        #region CODING FOR *** BILLING *** PAGE

        // Coding for generate Billing no
        public string GenerateBillingNo()
        {            
            string billingstring = DALObject.GenerateBillingNo();

            return billingstring;
        }

        // Coding for get Company name list from Company_Details
        public AutoCompleteStringCollection SelectCustomerNameForBilling()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            namesCollection = DALObject.SelectCustomerNameForBilling();
            return namesCollection;
        }

        // Coding for get Company name list from Company_Details
        public AutoCompleteStringCollection SelectProductNameForBilling(string CompanyName)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            namesCollection = DALObject.SelectProductNameForBilling(CompanyName);
            return namesCollection;
        }
               
        public int CompanyID(string CompanyName)
        {
            int ID;
            DataTable dt = DALObject.CompanyIDForBilling(CompanyName);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                ID=Convert.ToInt32(dr["CompanyID"].ToString());
                return ID;
            }
            else
            {
                return ID = 0;
            }  
        }
        
         // Coding for Fatch product details
        public DataTable ProductDetails(string ProductName,string companyname)
        {
            DataTable dt = DALObject.ProductDetails(ProductName,companyname);
            return dt;
        }

       
        // Coding for Fatch stock form Stock Management
        public int Fatch_Stock(string ProductName, string ProductCode)
        {
            int stock = 0;
            DataTable dt = DALObject.Fatch_Stock(ProductName,ProductCode);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                stock = Convert.ToInt32(dr["Stock"].ToString());
                return stock;
            }
                
            else
            {
                return stock;
            }

        }

        // Coding for update stock in Stock_Management table
        public void UpdateStockFromBilling(int stock, string ProdutName, string ProductCode)
        {
            DALObject.UpdateStockFromBilling(stock, ProdutName, ProductCode);
        }



         // Coding for Insert Billing Entry in Billing_Entry Table
        public void InsertBillgProduct(string BillingNo, string CompanyName,string productname, string ProductCode, string ProductType, string ProductCount, string ProductMRP, string ProductPrise)
        {
            DALObject.InsertBillgProduct(BillingNo, CompanyName, productname,ProductCode, ProductType, ProductCount, ProductMRP, ProductPrise);
        }

        
        // Coding for Fatch data from Billing_Entry Table (Product add list)
        public DataTable FatchAddedProduct(string BillingNo)
        {
            DataTable dt = DALObject.FatchAddedProduct(BillingNo);
            //CalculateTotalAmount(dt);
            return dt;
        }

        // Coding for calculate Total prise of added product list
        public double CalculateTotalAmount(DataTable Table)
        {
            double TotalBill = 0;
            foreach (DataRow dr in Table.Rows)
            {
                TotalBill += Convert.ToDouble(dr["ProductPrise"]);               
            }
            return TotalBill;
        }

        // Coding for Save ActualBill in BillingDetails Table
        public void SaveBill(string BillingNo,string CustomerName, string TotalAmount)
        {
            DALObject.SaveBill(BillingNo,CustomerName, TotalAmount);
        }

        // Coding for Delete product from Billing list
        public bool DeleteProduct(int ProductID)
        {            
            if (DALObject.DeleteProduct(ProductID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region CODING FOR *** BROWSE BILL *** PAGE

        // Coding for fatch data from BillingDetails
        public DataTable FatchAll_BillRecords(string year, string monthname)
        {
            DataTable dt = DALObject.FatchAll_BillRecords(year, monthname);
            return dt;
        }


         // Coding for fatch Today's Records
        public DataTable FatchAll_BillRecords_Yearly(string year)
        {
            DataTable dt = DALObject.FatchAll_BillRecords_Yearly(year);
            return dt;
        }

         // Coding for fatach dtat date wise
        public DataTable FatchAll_BillRecords_TextWise_Year_Month(string year, string monthname, string SearchString)
        {
            DataTable dt = DALObject.FatchAll_BillRecords_TextWise_Year_Month(year, monthname, SearchString);
            return dt;
        }

        // Coding for Fatch Data Textwise
        public DataTable FatchAll_BillRecords_TextWise_Yearly(string year, string SearchString)
        {
            DataTable dt = DALObject.FatchAll_BillRecords_TextWise_Yearly(year, SearchString);
            return dt;
        }

        // Coding for Delete Records from BillingDetails Table
        public void Delete_Records(int BillID)
        {
            DALObject.Delete_Records(BillID);            
        }

        #endregion

        
        #region CODING FOR *** QUTATION PAGE *** PAGE

        // Coding for generate Billing no
        public string GenerateQuotationNo()
        {
            string Quotation_No = DALObject.GenerateQuotationNo();

            return Quotation_No;
        }

          // Retrun ID for insert in Quotation product list 
        public int ReturnID()
        {
            int ID = DALObject.ReturnID();
            return ID;
        }

        // Coding for calculate Total prise of added product list
        public double CalculateQuatationAmount(DataTable Table)
        {
            double TotalBill = 0;
            foreach (DataRow dr in Table.Rows)
            {
                TotalBill += Convert.ToDouble(dr["GrantTotal"]);
            }
            return TotalBill;
        }

        // Coding for Fatch product details
        public DataTable FatchProdut_ThroughProductCode(string ProductCode)
        {
            DataTable dt = DALObject.FatchProdut_ThroughProductCode(ProductCode);
            return dt;
        }

        // Coding for save all Quotation Product / Report
        public void Save_Quotation(int MainQuotation_ID, string Quotation_No, string CompanyName, string ProductName, string ProductCode, string ProductType, string Rate, string Discount, string DiscountAmount, string Quantity, string TotalAmount, string Tax, string GrantTotal)
        {
            DALObject.Save_Quotation(MainQuotation_ID, Quotation_No, CompanyName, ProductName, ProductCode, ProductType, Rate, Discount, DiscountAmount, Quantity, TotalAmount, Tax, GrantTotal);
        }

        // Coding for fatch data from Quotation Table
        public DataTable Fatch_Quotation(string Quotation_No)
        {
            DataTable dt = DALObject.Fatch_Quotation(Quotation_No);
            return dt;
        }

        // Coding for Save All Quotation
        public void SaveMainQuotation(string quotation_no, string customer_name, string total_cost, string totalCostText, string TotalTax, string date)
        {
            DALObject.SaveMainQuotation(quotation_no, customer_name, total_cost, totalCostText, TotalTax, date);
        }

        // Coding for Delete Selected Product Details
        public bool DeleteQuotationProduct(int ProductID)
        {            
            if (DALObject.DeleteQuotationProduct(ProductID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region CODING FOR *** BROWSE QUOTATION *** PAGE


        // Coding for fatch Today's Records from Main_Quotation Table
        public DataTable Fatch_Quotation_Records(string year, string monthname)
        {
            DataTable dt = DALObject.Fatch_Quotation_Records(year, monthname);
            return dt;
        }


        // Coding for fatch Records from Main_Quotation Table Yearly
        public DataTable Fatch_Quotation_Records_Yearly(string year)
        {
            DataTable dt = DALObject.Fatch_Quotation_Records_Yearly(year);
            return dt;
        }


        // Coding for fatch Records from Main_Quotation Table Yearly, Monthly and SearchText Wise
        public DataTable Fatch_Quotation_TextWise_Year_Month(string year, string monthname, string SearchString)
        {
            DataTable dt = DALObject.Fatch_Quotation_TextWise_Year_Month(year, monthname, SearchString);
            return dt;
        }

        // Coding for fatch Records from Main_Quotation Table Yearly and SearchText Wise
        public DataTable Fatch_Quotation_TextWise_Year(string year, string SearchString)
        {
            DataTable dt = DALObject.Fatch_Quotation_TextWise_Year(year, SearchString);
            return dt;
        }


        // Coding for Delete Records from Main_Quotation Table
        public void Delete_Quotation_Records(int Quotation_ID)
        {
            DALObject.Delete_Quotation_Records(Quotation_ID);
        }


        // Coding for fatch data from Main_Quotation Table
        public DataTable FatchAll_Quotation_Records()
        {
            DataTable dt = DALObject.FatchAll_Quotation_Records();
            return dt;
        }


        #endregion

    }
}
