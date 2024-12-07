namespace Appointments_Scheduler.Report_Forms
{
    partial class CountriesServed
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
            this.txtBox_TotalCountries = new System.Windows.Forms.TextBox();
            this.lbl_TotalCountries = new System.Windows.Forms.Label();
            this.lbl_CountriesServed = new System.Windows.Forms.Label();
            this.listView_CountriesServed = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtBox_TotalCountries
            // 
            this.txtBox_TotalCountries.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBox_TotalCountries.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_TotalCountries.Location = new System.Drawing.Point(111, 144);
            this.txtBox_TotalCountries.Name = "txtBox_TotalCountries";
            this.txtBox_TotalCountries.ReadOnly = true;
            this.txtBox_TotalCountries.Size = new System.Drawing.Size(72, 38);
            this.txtBox_TotalCountries.TabIndex = 40;
            this.txtBox_TotalCountries.TabStop = false;
            this.txtBox_TotalCountries.Text = "--";
            this.txtBox_TotalCountries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_TotalCountries
            // 
            this.lbl_TotalCountries.AutoSize = true;
            this.lbl_TotalCountries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalCountries.Location = new System.Drawing.Point(75, 103);
            this.lbl_TotalCountries.Name = "lbl_TotalCountries";
            this.lbl_TotalCountries.Size = new System.Drawing.Size(145, 25);
            this.lbl_TotalCountries.TabIndex = 39;
            this.lbl_TotalCountries.Text = "Total Countries";
            // 
            // lbl_CountriesServed
            // 
            this.lbl_CountriesServed.AutoSize = true;
            this.lbl_CountriesServed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CountriesServed.Location = new System.Drawing.Point(557, 45);
            this.lbl_CountriesServed.Name = "lbl_CountriesServed";
            this.lbl_CountriesServed.Size = new System.Drawing.Size(245, 36);
            this.lbl_CountriesServed.TabIndex = 35;
            this.lbl_CountriesServed.Text = "Countries Served";
            // 
            // listView_CountriesServed
            // 
            this.listView_CountriesServed.Enabled = false;
            this.listView_CountriesServed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_CountriesServed.HideSelection = false;
            this.listView_CountriesServed.Location = new System.Drawing.Point(33, 206);
            this.listView_CountriesServed.Name = "listView_CountriesServed";
            this.listView_CountriesServed.Size = new System.Drawing.Size(1288, 404);
            this.listView_CountriesServed.TabIndex = 41;
            this.listView_CountriesServed.UseCompatibleStateImageBehavior = false;
            this.listView_CountriesServed.View = System.Windows.Forms.View.List;
            // 
            // CountriesServed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 768);
            this.Controls.Add(this.listView_CountriesServed);
            this.Controls.Add(this.txtBox_TotalCountries);
            this.Controls.Add(this.lbl_TotalCountries);
            this.Controls.Add(this.lbl_CountriesServed);
            this.Name = "CountriesServed";
            this.Text = "CountriesServed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_TotalCountries;
        private System.Windows.Forms.Label lbl_TotalCountries;
        private System.Windows.Forms.Label lbl_CountriesServed;
        private System.Windows.Forms.ListView listView_CountriesServed;
    }
}