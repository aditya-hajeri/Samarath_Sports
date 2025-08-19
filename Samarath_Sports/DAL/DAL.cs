using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;


namespace Samarath_Sports.DAL
{
    class DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]);

        #region ALL USEFULL FUNCTION

        public void InsertInfo(string sqlcmd)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable FatchData(string sqlcmd)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public bool UpdateData(string sqlcmd)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, con);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(string sqlcmd)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, con);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region CODING FOR *** ADD COMPANY *** PAGE

        // Coding for Add Company Details in Company_Details Table
        public void AddCompany(string companyname)
        {
            string sql = "insert into Company_Details (Company_Name) values('" + companyname + "')";
            InsertInfo(sql);
        }

        // Coding for Fatch Data from Company_Details Table
        public DataTable Fatch_Company_Data()
        {
            string sql = "select Company_Name, CompanyID from Company_Details";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Edit Company Details from CompanyDetails Table
        public DataTable EditCompanyDetails(int CompanyID)
        {
            string sql = "select Company_Name from Company_Details where CompanyID='" + CompanyID + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Update Company Details From Company_Details Table
        public bool UpdateCompanyDetail(int CompanyID, string Companyname)
        {
            string sql = "update Company_Details set Company_Name='" + Companyname + "' where CompanyID='" + CompanyID + "'";

            if (UpdateData(sql))
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
            string sql = "delete from Company_Details where CompanyID='" + CompanyID + "'";

            if (DeleteData(sql))
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
            string sql = "select Company_Name from Company_Details where Company_Name like'" + searchstring + "%'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        #endregion


        #region CODING FOR *** ADD PRODUCTS *** PAGE

        // Codding for Add product in Product_Details table
        public void AddProduct(string companyname, string productname, string productcode, string Product_Type, string size, string each, string mrp)
        {
            string sql = "insert into Product_Details(Company_Name,Product_Name,Product_Code,Product_Type,Size,EACH,MRP) values('" + companyname + "','" + productname + "','" + productcode + "','" + Product_Type + "','" + size + "','" + each + "','" + mrp + "')";
            InsertInfo(sql);
        }

        // Coding for Fatct dtat from Product_Details Table 
        public DataTable Fatch_Product_Data()
        {
            string sql = "select Company_Name, Product_Name, Product_Code,Product_Type,Size,EACH,MRP, Product_ID from Product_Details";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Edit Product Details from Product_Details Table
        public DataTable EditProductDetails(int ProductID)
        {
            string sql = "select Company_Name, Product_Name, Product_Code, Product_Type, Size, EACH, MRP from Product_Details where Product_ID='" + ProductID + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Update Product Details From Product_Details Table
        public bool UpdateProductDetail(int ProductID, string companyname, string productname, string productcode, string Product_Type, string size, string each, string mrp)
        {
            string sql = "update Product_Details set Company_Name='" + companyname + "', Product_Name='" + productname + "', Product_Code='" + productcode + "', Product_Type='" + Product_Type + "', Size='" + size + "', EACH='" + each + "', MRP='" + mrp + "' where Product_ID='" + ProductID + "'";

            if (UpdateData(sql))
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
            string sql = "delete from Product_Details where Product_ID='" + ProductID + "'";

            if (DeleteData(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Coding for Search Recored form Product_Name,Product_Code form Product_Details Table
        public DataTable SearchProductDetails(string searchstring)
        {
            string sql = "select Company_Name, Product_Name, Product_Code, Product_Type, Size, EACH, MRP, Product_ID from Product_Details where Company_Name like '" + searchstring + "%' or Product_Name like'" + searchstring + "%' or Product_Code like'" + searchstring + "%' ";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for get Product name list from Product_Details
        public AutoCompleteStringCollection SelectProductName(string CompanyName)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string querry = "select Product_Name from Product_Details where Company_Name='" + CompanyName + "'";

                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        namesCollection.Add(Convert.ToString(dr["Product_Name"]));
                    }
                }

                con.Close();
                return namesCollection;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        // Coding for get Company name list from Company_Details
        public AutoCompleteStringCollection SelectCompanyName()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string querry = "select Company_Name from Company_Details";

                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        namesCollection.Add(Convert.ToString(dr["Company_Name"]));
                    }
                }

                con.Close();
                return namesCollection;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        // Coding for fiend Product is present or not in list
        public DataTable Fiend_Product_Present_or_Not(string ProductName)
        {
            string sql = "select Product_Code from Product_Details where Product_Code='" + ProductName + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        #endregion


        #region CODING FOR *** STOCK MAINTAIN *** PAGE


        // Coding for Insert Stock in Stock_Management Table
        public void InsertStock(string CompanyName, string Product_Type, string ProductName, string Code, string Totalstock)
        {
            DateTime date = System.DateTime.Now;
            string StockDate = date.ToShortDateString();

            string sql = "insert into Stock_Management(CompanyName,ProductType,ProductName,ProductCode,Stock,Date) values('" + CompanyName + "','" + Product_Type + "','" + ProductName + "','" + Code + "','" + Totalstock + "','" + StockDate + "')";
            InsertInfo(sql);
        }

        // Coding for Update Stock in Stock_Management Table
        public void UpdateStock(int StockID, string Totalstock)
        {
            DateTime date = System.DateTime.Now;
            string StockDate = date.ToShortDateString();

            string sql = "update Stock_Management set Stock='" + Totalstock + "', Date='" + StockDate + "' where StockID='" + StockID + "' ";
            InsertInfo(sql);
        }


        // Coding for get Company name list from Company_Details
        public AutoCompleteStringCollection SelectCompanyNameForStock()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string querry = "select Company_Name from Product_Details";

                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        namesCollection.Add(Convert.ToString(dr["Company_Name"]));
                    }
                }

                con.Close();
                return namesCollection;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        // Coding for get Product name list from Product_Details
        public AutoCompleteStringCollection SelectProductNameForStock(string CompanyName, string Product_Type)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string querry = "select Product_Name from Product_Details where Company_Name like '" + CompanyName + "%' and Product_Type like '" + Product_Type + "' ";

                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        namesCollection.Add(Convert.ToString(dr["Product_Name"]));
                    }
                }

                con.Close();
                return namesCollection;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        // Coding for Get all product details forom product name
        public DataTable FatchProduct_Details(string ProductName, string product_type)
        {
            string sql = "select Product_Code from Product_Details where Product_Name='" + ProductName + "' and Product_Type='" + product_type + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }


        // Coding for Get stock form Stock_Management table 
        public DataTable GetStock(string productname, string producttype, string productcodoe)
        {
            string sql = "select Stock, StockID from Stock_Management where ProductName='" + productname + "' and ProductType='" + producttype + "' and ProductCode='" + productcodoe + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }


        // Coding for fatch recored in Stock_Management Table
        public DataTable FatchRecored()
        {
            string sql = "select CompanyName,ProductType,ProductName,ProductCode,Stock,Date,StockID From Stock_Management";
            DataTable dt = FatchData(sql);
            return dt;
        }

        #endregion


        #region CODING FOR *** BILLING *** PAGE

        // Coding for generate Billing no
        public string GenerateBillingNo()
        {
            DateTime year = DateTime.Now;
            string Year_Last2Digits = year.ToString("yy");

            string month = System.DateTime.Now.Month.ToString();

            string Duty_Slip_ID = "";
            string ID;

            string str = "SS/" + month + "/" + Year_Last2Digits + "/";
            SqlCommand cmd = new SqlCommand("select MAX (Billing_ID) from BillingDetails", con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (Convert.ToInt32(dr.HasRows) > 0)
            {
                if (dr.Read())
                {
                    ID = Convert.ToString(dr[""].ToString());
                    if (ID == "")
                    {
                        int id = 0;
                        //ID = "0";
                        Duty_Slip_ID = str + Convert.ToString(id + 1);
                    }

                    else
                    {
                        int id = Convert.ToInt32(ID);
                        Duty_Slip_ID = str + Convert.ToString(id + 1);
                    }
                }
            }

            con.Close();

            return Duty_Slip_ID;
        }

        public AutoCompleteStringCollection SelectCustomerNameForBilling()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string querry = "select CustomerName from BillingDetails";

                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        namesCollection.Add(Convert.ToString(dr["CustomerName"]));
                    }
                }

                con.Close();
                return namesCollection;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public AutoCompleteStringCollection SelectProductNameForBilling(string CompanyName)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string querry = "select Product_Name from Product_Details where Company_Name like '" + CompanyName + "%'";

                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        namesCollection.Add(Convert.ToString(dr["Product_Name"]));
                    }
                }

                con.Close();
                return namesCollection;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        // Coding for select get CompanyID
        public DataTable CompanyIDForBilling(string CompanyName)
        {
            string sql = "select CompanyID from Company_Details where Company_Name='" + CompanyName + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Fatch product details
        public DataTable ProductDetails(string ProductName, string companyname)
        {
            string sql = "select Product_Code,Product_Type,Size,EACH,MRP from Product_Details where Company_Name='" + companyname + "' and Product_Name='" + ProductName + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Fatch stock form Stock Management
        public DataTable Fatch_Stock(string ProductName, string ProductCode)
        {
            string sql = "select Stock from Stock_Management where ProductName='" + ProductName + "' or ProductCode='" + ProductCode + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for update stock in Stock_Management table
        public void UpdateStockFromBilling(int stock, string ProdutName, string ProductCode)
        {
            string sql = "update Stock_Management set Stock='" + stock + "' where ProductName='" + ProdutName + "' and ProductCode='" + ProductCode + "'";
            InsertInfo(sql);
        }

        // Coding for Insert Billing Entry in Billing_Entry Table
        public void InsertBillgProduct(string BillingNo, string CompanyName, string productname, string ProductCode, string ProductType, string ProductCount, string ProductMRP, string ProductPrise)
        {
            string sql = "insert into Billing_Entry(BillingNo,CompanyName,ProductName,ProductCode,ProductType,ProductCount,ProductMRP,ProductPrise) values('" + BillingNo + "','" + CompanyName + "','" + productname + "','" + ProductCode + "','" + ProductType + "','" + ProductCount + "','" + ProductMRP + "','" + ProductPrise + "')";
            InsertInfo(sql);
        }

        // Coding for Fatch data from Billing_Entry Table (Product add list)
        public DataTable FatchAddedProduct(string BillingNo)
        {
            string sql = "select BillingNo,CompanyName,ProductName,ProductCode,ProductType,ProductCount,ProductPrise,BillID from Billing_Entry where BillingNo='" + BillingNo + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Save ActualBill in BillingDetails Table
        public void SaveBill(string BillingNo, string CustomerName, string TotalAmount)
        {
            DateTime Dtae = System.DateTime.Now;
            string TodayDate = Dtae.ToShortDateString();

            string MonthName = DateTime.Today.ToString("MMMM");
            string Year = DateTime.Today.ToString("yyyy");

            string sql = "insert into BillingDetails(BillingNo,CustomerName,Total_Amount,Date,Month,Year) values('" + BillingNo + "','" + CustomerName + "','" + TotalAmount + "','" + TodayDate + "','"+MonthName+"','"+Year+"')";
            InsertInfo(sql);
        }

        // Coding for Delete product from Billing list
        public bool DeleteProduct(int ProductID)
        {
            string sql = "Delete from Billing_Entry where BillID='" + ProductID + "'";
            if (DeleteData(sql))
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

        // Coding for fatch data from BillingDetails Table
        public DataTable FatchAll_BillRecords(string year, string monthname)
        {
            //string date =Convert.ToString( System.DateTime.Now.ToShortDateString());

            string sql = "select BillingNo, CustomerName, Total_Amount, Date, Billing_ID from BillingDetails where Month='" + monthname + "' and Year = '" + year + "' order by Billing_ID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for fatch data from BillingDetails Table Yearly
        public DataTable FatchAll_BillRecords_Yearly(string year)
        {
            //string date =Convert.ToString( System.DateTime.Now.ToShortDateString());

            string sql = "select BillingNo, CustomerName, Total_Amount, Date, Billing_ID from BillingDetails where Year = '" + year + "' order by Billing_ID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }


        // Coding for fatch data from BillingDetails Table Yearly, Monthly and SearchText Wise
        public DataTable FatchAll_BillRecords_TextWise_Year_Month(string year, string monthname, string SearchString)
        {
            //string date =Convert.ToString( System.DateTime.Now.ToShortDateString());

            string sql = "select BillingNo, CustomerName, Total_Amount, Date, Billing_ID from BillingDetails where Month = '" + monthname + "' and Year = '" + year + "' and (BillingNo like'" + SearchString + "%' or CustomerName like '" + SearchString + "%') order by Billing_ID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for fatch data from BillingDetails Table Yearly and SearchText Wise
        public DataTable FatchAll_BillRecords_TextWise_Yearly(string year, string SearchString)
        {
            //string date =Convert.ToString( System.DateTime.Now.ToShortDateString());

            string sql = "select BillingNo, CustomerName, Total_Amount, Date, Billing_ID from BillingDetails where Year = '" + year + "' and (BillingNo like'" + SearchString + "%' or CustomerName like '" + SearchString + "%') order by Billing_ID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }



        // Coding for fatch Today's Records from BillingDetails Table
        public DataTable Fatch_BillingTodays_Records()
        {
            DateTime Dtae = System.DateTime.Now;
            string TodayDate = Dtae.ToShortDateString();

            string sql = "select BillingNo,CustomerName,Total_Amount,Date,Billing_ID from BillingDetails where Date = '" + TodayDate + "' order by Billing_ID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for fatach dtat date wise from BillingDetails Table
        public DataTable Fatch_BillingDataDatewise(string datefrom, string dateto)
        {
            string sql = "select BillingNo, CustomerName, Total_Amount, Date, Billing_ID from BillingDetails where Date between '" + datefrom + "' and '" + dateto + "' order by Billing_ID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }
        
        // Coding for Fatch Data Textwise from BillingDetails Table
        public DataTable Fatch_BillingTextWise(string SearchText, string datefrom, string dateto)
        {
            string sql = "select BillingNo,CustomerName,Total_Amount,Date,Billing_ID from BillingDetails where (Date between '" + datefrom + "' and '" + dateto + "') and (BillingNo like'" + SearchText + "%' or CustomerName like '" + SearchText + "%') order by Billing_ID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }
        
        // Coding for Delete Records from BillingDetails Table
        public void Delete_Records(int BillID)
        {
            string sql = "delete from BillingDetails where Billing_ID='" + BillID + "'";
            InsertInfo(sql);
        }

        #endregion


        #region CODING FOR *** QUOTATION *** PAGE


        // Coding for create Invoice ID
        public string GenerateQuotationNo()
        {
            DateTime year = DateTime.Now;
            string Year_Last2Digits = year.ToString("yy");

            //string month = System.DateTime.Now.Month.ToString();

            string month = DateTime.Now.ToString("MM");

            string Quotation_No = "";
            string ID;

            string str = "SS/" + month + "/" + Year_Last2Digits + "/0";
            SqlCommand cmd = new SqlCommand("select MAX (QuotationID) from Main_Quotation", con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (Convert.ToInt32(dr.HasRows) > 0)
            {
                if (dr.Read())
                {
                    ID = Convert.ToString(dr[""].ToString());
                    if (ID == "")
                    {
                        int id = 0;
                        //ID = "0";
                        Quotation_No = str + Convert.ToString(id + 1);
                    }

                    else
                    {
                        int id = Convert.ToInt32(ID);
                        Quotation_No = str + Convert.ToString(id + 1);
                    }
                }
            }

            con.Close();

            return Quotation_No;
          
            //return Tuple.Create<Quotation_No, ID>;
        }

        // Retrun ID for insert in Quotation product list 
        public int ReturnID()
        {
            int ID=0;

            SqlCommand cmd = new SqlCommand("select MAX (QuotationID) from Main_Quotation", con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (Convert.ToInt32(dr.HasRows) > 0)
            {
                if (dr.Read())
                {
                    ID = Convert.ToInt32(dr[""].ToString());

                    if (ID == 0)
                    {
                        ID = 0+1;
                    }
                    else
                    {
                        ID = ID + 1;
                    }
                }
            }

            con.Close();

            return ID;
        }

        // Coding for Insert Quatation Details
        public void InsertQuatation()
        {
            string sql = "";
            InsertInfo(sql);
        }

        // Coding for Fatch product details Through Product Code
        public DataTable FatchProdut_ThroughProductCode(string ProductCode)
        {
            string sql = "select Company_Name, Product_Name, Product_Type, MRP, Size, EACH, MRP from Product_Details where Product_Code='" + ProductCode + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for save all Quotation Product / Report
        public void Save_Quotation(int MainQuotation_ID, string Quotation_No, string CompanyName, string ProductName, string ProductCode, string ProductType, string Rate, string Discount, string DiscountAmount, string Quantity, string TotalAmount, string Tax, string GrantTotal)
        {
            DateTime Today = System.DateTime.Now;
            string Date = Today.ToShortDateString();

            string MonthName = DateTime.Today.ToString("MMMM");
            string Year = DateTime.Today.ToString("yyyy");

            string one = "insert into Quotation (MainQuotation_ID, Quotation_No, CompanyName,ProductName,ProductCode,ProductType,Rate,Discount,DiscountAmount,Quantity,TotalAmount,Vat,GrantTotal,Date,Month,Year)";
            string two = "values('"+MainQuotation_ID+"','" + Quotation_No + "','" + CompanyName + "','" + ProductName + "','" + ProductCode + "','" + ProductType + "','" + Rate + "','" + Discount + "','" + DiscountAmount + "','" + Quantity + "','" + TotalAmount + "','" + Tax + "','" + GrantTotal + "','" + Date + "','"+MonthName+"','"+Year+"')";
            string sql = one + two;
            InsertInfo(sql);
        }

        // Coding for fatch data from Quotation Table
        public DataTable Fatch_Quotation(string Quotation_No)
        {
            string sql = "select ProductCode,CompanyName,ProductName,ProductType,Rate,Discount,DiscountAmount,Quantity,TotalAmount,Vat,GrantTotal,Date from Quotation where Quotation_No='" + Quotation_No + "'";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for Save All Quotation
        public void SaveMainQuotation(string quotation_no, string customer_name, string total_cost, string totalCostText, string TotalTax, string date)
        {
            string MonthName = DateTime.Today.ToString("MMMM");
            string Year = DateTime.Today.ToString("yyyy");

            string sql = " insert into Main_Quotation (Quotation_No,Customer_Name,Total_Cost,Total_Cost_Text,Total_Tax,Date,Month,Year) values('" + quotation_no + "','" + customer_name + "','" + total_cost + "','" + totalCostText + "','"+TotalTax+"','" + date + "','"+MonthName+"','"+Year+"')";
            InsertInfo(sql);
        }

        // Coding for Delete Selected Product Details
        public bool DeleteQuotationProduct(int ProductID)
        {
            string sql = "";
            if (DeleteData(sql))
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

        // Coding for fatch Records from Main_Quotation Table
        public DataTable Fatch_Quotation_Records(string year, string monthname)
        {

            DateTime Dtae = System.DateTime.Now;
            string Today = Dtae.ToShortDateString();

            string sql = "select Quotation_No,Customer_Name,Total_Cost,Total_Tax,Date,QuotationID from Main_Quotation where Month='"+monthname+"' and Year = '"+year+"' order by QuotationID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for fatch Records from Main_Quotation Table Yearly
        public DataTable Fatch_Quotation_Records_Yearly(string year)
        {

            DateTime Dtae = System.DateTime.Now;
            string Today = Dtae.ToShortDateString();

            string sql = "select Quotation_No,Customer_Name,Total_Cost,Total_Tax,Date,QuotationID from Main_Quotation where Year = '" + year + "' order by QuotationID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for fatch Records from Main_Quotation Table Yearly, Monthly and SearchText Wise
        public DataTable Fatch_Quotation_TextWise_Year_Month(string year, string monthname, string SearchString)
        {
            string sql = "select Quotation_No,Customer_Name,Total_Cost,Total_Tax,Date,QuotationID from Main_Quotation where Month='" + monthname + "' and Year = '" + year + "' and (Quotation_No like'" + SearchString + "%' or Customer_Name like '" + SearchString + "%') order by QuotationID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }

        // Coding for fatch Records from Main_Quotation Table Yearly and SearchText Wise
        public DataTable Fatch_Quotation_TextWise_Year(string year, string SearchString)
        {
            string sql = "select Quotation_No,Customer_Name,Total_Cost,Total_Tax,Date,QuotationID from Main_Quotation where Year = '" + year + "' and (Quotation_No like'" + SearchString + "%' or Customer_Name like '" + SearchString + "%') order by QuotationID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }


        //// Coding for fatach dtat date wise from Main_Quotation Table
        //public DataTable Fatch_Quotation_Data_Datewise(string datefrom, string dateto)
        //{
        //    string sql = "select Quotation_No,Customer_Name,Total_Cost,Total_Tax,Date,QuotationID from Main_Quotation where Date between '" + datefrom + "' and '" + dateto + "' order by QuotationID desc";
        //    DataTable dt = FatchData(sql);
        //    return dt;
        //}

        // Coding for Fatch Data Textwise from Main_Quotation Table

       

        // Coding for Delete Records from Main_Quotation Table


        public void Delete_Quotation_Records(int Quotation_ID)
        {
            string sql = "delete from Main_Quotation where QuotationID='" + Quotation_ID + "'";
            InsertInfo(sql);
        }

        // Coding for fatch data from Main_Quotation Table
        public DataTable FatchAll_Quotation_Records()
        {
            //string date =Convert.ToString( System.DateTime.Now.ToShortDateString());

            string sql = "select Quotation_No,Customer_Name,Total_Cost,Total_Tax,Date,QuotationID from Main_Quotation order by QuotationID desc";
            DataTable dt = FatchData(sql);
            return dt;
        }


        #endregion



    }
}
