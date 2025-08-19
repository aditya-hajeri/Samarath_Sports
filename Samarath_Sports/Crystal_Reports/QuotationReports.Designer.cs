namespace Samarath_Sports.Crystal_Reports
{
    partial class QuotationReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuotationCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // QuotationCrystalReportViewer
            // 
            this.QuotationCrystalReportViewer.ActiveViewIndex = -1;
            this.QuotationCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuotationCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.QuotationCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuotationCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.QuotationCrystalReportViewer.Name = "QuotationCrystalReportViewer";
            this.QuotationCrystalReportViewer.Size = new System.Drawing.Size(817, 627);
            this.QuotationCrystalReportViewer.TabIndex = 0;
            this.QuotationCrystalReportViewer.Load += new System.EventHandler(this.QuotationCrystalReportViewer_Load);
            // 
            // QuotationReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 627);
            this.Controls.Add(this.QuotationCrystalReportViewer);
            this.Name = "QuotationReports";
            this.Text = "QuotationReports";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer QuotationCrystalReportViewer;
    }
}