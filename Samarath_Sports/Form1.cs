using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Samarath_Sports.UI;

namespace Samarath_Sports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            LblDate.Text = DateTime.Now.ToLongDateString();
        }

        public void Display_Form(Form FromName)
        {
            FromName.TopLevel = false;
            FromName.AutoScroll = true;
            DisplayPannel.Controls.Clear();
            DisplayPannel.Controls.Add(FromName);
            FromName.Dock = DockStyle.Fill;

            FromName.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (menuPannel.Visible == true)
            {
                menuPannel.Visible = false;
                PanelOption.Visible = true;
            }
            else
            {
                menuPannel.Visible = true;
                PanelOption.Visible = false;
            }
        }

        private void BtnStockMgmt_Click(object sender, EventArgs e)
        {
            Stock_Maintain form = new Stock_Maintain();
            Display_Form(form);
            
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            Add_Company form = new Add_Company();
            //Display_Form(form);
            form.ShowDialog();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProducts form = new AddProducts();
            Display_Form(form);
            //form.ShowDialog();
        }

        private void TextBilling_Click(object sender, EventArgs e)
        {
            Billing form = new Billing();
            Display_Form(form);
        }

        private void BtnBrowseBilling_Click(object sender, EventArgs e)
        {
            Browse_Bill form = new Browse_Bill();
            Display_Form(form);
        }

        private void BtnQuotation_Click(object sender, EventArgs e)
        {
            Quotation form = new Quotation();
            Display_Form(form);
        }

        private void BrowseQuatation_Click(object sender, EventArgs e)
        {
            Browse_Quotation form = new Browse_Quotation();
            Display_Form(form);
        }


        #region *** LABEL MOUSE HOVER EFFECT ***

        private void label3_MouseHover(object sender, EventArgs e)
        {
            this.label3.BackColor = Color.FromArgb(229, 126, 49);
        }
        
        private void label4_MouseHover(object sender, EventArgs e)
        {
            this.label4.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            this.label5.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            this.label6.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            this.label7.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            this.label8.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            this.label9.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            this.label10.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            this.label11.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            this.label12.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            this.label13.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            this.label14.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            this.label15.BackColor = Color.FromArgb(229, 126, 49);
        }

        private void tableLayoutPanel1_MouseHover(object sender, EventArgs e)
        {
            this.label3.BackColor = Color.FromArgb(229, 126, 49);
            this.label4.BackColor = Color.FromArgb(229, 126, 49);
            this.label5.BackColor = Color.FromArgb(229, 126, 49);
            this.label6.BackColor = Color.FromArgb(229, 126, 49);
            this.label7.BackColor = Color.FromArgb(229, 126, 49);
            this.label8.BackColor = Color.FromArgb(229, 126, 49);
            this.label9.BackColor = Color.FromArgb(229, 126, 49);
            this.label10.BackColor = Color.FromArgb(229, 126, 49);
            this.label11.BackColor = Color.FromArgb(229, 126, 49);
            this.label12.BackColor = Color.FromArgb(229, 126, 49);
            this.label13.BackColor = Color.FromArgb(229, 126, 49);
            this.label14.BackColor = Color.FromArgb(229, 126, 49);
            this.label15.BackColor = Color.FromArgb(229, 126, 49);
        }

        #endregion


        #region *** LABEL MOUSE LEAVE EFFECT ***

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.label3.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.label4.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            this.label5.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            this.label6.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            this.label7.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            this.label8.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            this.label9.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            this.label10.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            this.label11.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            this.label12.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            this.label13.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            this.label14.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            this.label15.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void tableLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            this.label3.BackColor = Color.FromArgb(41, 53, 65);
            this.label4.BackColor = Color.FromArgb(41, 53, 65);
            this.label5.BackColor = Color.FromArgb(41, 53, 65);
            this.label6.BackColor = Color.FromArgb(41, 53, 65);
            this.label7.BackColor = Color.FromArgb(41, 53, 65);
            this.label8.BackColor = Color.FromArgb(41, 53, 65);
            this.label9.BackColor = Color.FromArgb(41, 53, 65);
            this.label10.BackColor = Color.FromArgb(41, 53, 65);
            this.label11.BackColor = Color.FromArgb(41, 53, 65);
            this.label12.BackColor = Color.FromArgb(41, 53, 65);
            this.label13.BackColor = Color.FromArgb(41, 53, 65);
            this.label14.BackColor = Color.FromArgb(41, 53, 65);
            this.label15.BackColor = Color.FromArgb(41, 53, 65);
        }


        #endregion

        private void BtnGeneral_Click(object sender, EventArgs e)
        {

        }

        private void BtnGeneral_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
