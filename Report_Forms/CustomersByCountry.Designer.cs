namespace Appointments_Scheduler.Report_Forms
{
    partial class CustomersByCountry
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
            this.txtBox_TotalResults = new System.Windows.Forms.TextBox();
            this.lbl_TotalResults = new System.Windows.Forms.Label();
            this.btn_GenerateReport = new System.Windows.Forms.Button();
            this.lbl_Countries = new System.Windows.Forms.Label();
            this.cmboBox_Countries = new System.Windows.Forms.ComboBox();
            this.lbl_CustomersByCountry = new System.Windows.Forms.Label();
            this.dgv_CustomersByCountry = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomersByCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_TotalResults
            // 
            this.txtBox_TotalResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_TotalResults.Location = new System.Drawing.Point(116, 158);
            this.txtBox_TotalResults.Name = "txtBox_TotalResults";
            this.txtBox_TotalResults.Size = new System.Drawing.Size(72, 34);
            this.txtBox_TotalResults.TabIndex = 33;
            this.txtBox_TotalResults.Text = "--";
            this.txtBox_TotalResults.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_TotalResults
            // 
            this.lbl_TotalResults.AutoSize = true;
            this.lbl_TotalResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalResults.Location = new System.Drawing.Point(94, 119);
            this.lbl_TotalResults.Name = "lbl_TotalResults";
            this.lbl_TotalResults.Size = new System.Drawing.Size(125, 25);
            this.lbl_TotalResults.TabIndex = 32;
            this.lbl_TotalResults.Text = "Total Results";
            // 
            // btn_GenerateReport
            // 
            this.btn_GenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerateReport.Location = new System.Drawing.Point(577, 665);
            this.btn_GenerateReport.Name = "btn_GenerateReport";
            this.btn_GenerateReport.Size = new System.Drawing.Size(172, 82);
            this.btn_GenerateReport.TabIndex = 31;
            this.btn_GenerateReport.Text = "Generate Report";
            this.btn_GenerateReport.UseVisualStyleBackColor = true;
            // 
            // lbl_Countries
            // 
            this.lbl_Countries.AutoSize = true;
            this.lbl_Countries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Countries.Location = new System.Drawing.Point(1027, 119);
            this.lbl_Countries.Name = "lbl_Countries";
            this.lbl_Countries.Size = new System.Drawing.Size(96, 25);
            this.lbl_Countries.TabIndex = 30;
            this.lbl_Countries.Text = "Countries";
            // 
            // cmboBox_Countries
            // 
            this.cmboBox_Countries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Countries.FormattingEnabled = true;
            this.cmboBox_Countries.Location = new System.Drawing.Point(967, 158);
            this.cmboBox_Countries.Name = "cmboBox_Countries";
            this.cmboBox_Countries.Size = new System.Drawing.Size(218, 33);
            this.cmboBox_Countries.TabIndex = 29;
            this.cmboBox_Countries.Text = "--";
            // 
            // lbl_CustomersByCountry
            // 
            this.lbl_CustomersByCountry.AutoSize = true;
            this.lbl_CustomersByCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CustomersByCountry.Location = new System.Drawing.Point(505, 49);
            this.lbl_CustomersByCountry.Name = "lbl_CustomersByCountry";
            this.lbl_CustomersByCountry.Size = new System.Drawing.Size(313, 36);
            this.lbl_CustomersByCountry.TabIndex = 28;
            this.lbl_CustomersByCountry.Text = "Customers By Country";
            // 
            // dgv_CustomersByCountry
            // 
            this.dgv_CustomersByCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CustomersByCountry.Location = new System.Drawing.Point(24, 220);
            this.dgv_CustomersByCountry.Name = "dgv_CustomersByCountry";
            this.dgv_CustomersByCountry.RowHeadersWidth = 51;
            this.dgv_CustomersByCountry.RowTemplate.Height = 24;
            this.dgv_CustomersByCountry.Size = new System.Drawing.Size(1288, 404);
            this.dgv_CustomersByCountry.TabIndex = 27;
            // 
            // CustomersByCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 794);
            this.Controls.Add(this.txtBox_TotalResults);
            this.Controls.Add(this.lbl_TotalResults);
            this.Controls.Add(this.btn_GenerateReport);
            this.Controls.Add(this.lbl_Countries);
            this.Controls.Add(this.cmboBox_Countries);
            this.Controls.Add(this.lbl_CustomersByCountry);
            this.Controls.Add(this.dgv_CustomersByCountry);
            this.Name = "CustomersByCountry";
            this.Text = "Customers By Country";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomersByCountry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_TotalResults;
        private System.Windows.Forms.Label lbl_TotalResults;
        private System.Windows.Forms.Button btn_GenerateReport;
        private System.Windows.Forms.Label lbl_Countries;
        private System.Windows.Forms.ComboBox cmboBox_Countries;
        private System.Windows.Forms.Label lbl_CustomersByCountry;
        private System.Windows.Forms.DataGridView dgv_CustomersByCountry;
    }
}