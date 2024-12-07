namespace Appointments_Scheduler.Report_Forms
{
    partial class AppointmentTypesByMonth
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
            this.btn_GenerateReport = new System.Windows.Forms.Button();
            this.lbl_Year = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.lbl_Month = new System.Windows.Forms.Label();
            this.cmboBox_Year = new System.Windows.Forms.ComboBox();
            this.cmboBox_Month = new System.Windows.Forms.ComboBox();
            this.lbl_AppointmentsTypesByMonth = new System.Windows.Forms.Label();
            this.dgv_AppointmentTypesByMonth = new System.Windows.Forms.DataGridView();
            this.cmboBox_Type = new System.Windows.Forms.ComboBox();
            this.lbl_TotalResults = new System.Windows.Forms.Label();
            this.txtBox_TotalResults = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AppointmentTypesByMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GenerateReport
            // 
            this.btn_GenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerateReport.Location = new System.Drawing.Point(575, 653);
            this.btn_GenerateReport.Name = "btn_GenerateReport";
            this.btn_GenerateReport.Size = new System.Drawing.Size(172, 82);
            this.btn_GenerateReport.TabIndex = 23;
            this.btn_GenerateReport.Text = "Generate Report";
            this.btn_GenerateReport.UseVisualStyleBackColor = true;
            this.btn_GenerateReport.Click += new System.EventHandler(this.btn_GenerateReport_Click);
            // 
            // lbl_Year
            // 
            this.lbl_Year.AutoSize = true;
            this.lbl_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Year.Location = new System.Drawing.Point(944, 107);
            this.lbl_Year.Name = "lbl_Year";
            this.lbl_Year.Size = new System.Drawing.Size(53, 25);
            this.lbl_Year.TabIndex = 22;
            this.lbl_Year.Text = "Year";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Type.Location = new System.Drawing.Point(1132, 107);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(57, 25);
            this.lbl_Type.TabIndex = 21;
            this.lbl_Type.Text = "Type";
            // 
            // lbl_Month
            // 
            this.lbl_Month.AutoSize = true;
            this.lbl_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Month.Location = new System.Drawing.Point(742, 107);
            this.lbl_Month.Name = "lbl_Month";
            this.lbl_Month.Size = new System.Drawing.Size(67, 25);
            this.lbl_Month.TabIndex = 20;
            this.lbl_Month.Text = "Month";
            // 
            // cmboBox_Year
            // 
            this.cmboBox_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Year.FormattingEnabled = true;
            this.cmboBox_Year.Location = new System.Drawing.Point(887, 146);
            this.cmboBox_Year.Name = "cmboBox_Year";
            this.cmboBox_Year.Size = new System.Drawing.Size(174, 33);
            this.cmboBox_Year.TabIndex = 19;
            this.cmboBox_Year.Text = "--";
            this.cmboBox_Year.DropDown += new System.EventHandler(this.cmboBox_Year_DropDown);
            // 
            // cmboBox_Month
            // 
            this.cmboBox_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Month.FormattingEnabled = true;
            this.cmboBox_Month.Location = new System.Drawing.Point(694, 146);
            this.cmboBox_Month.Name = "cmboBox_Month";
            this.cmboBox_Month.Size = new System.Drawing.Size(174, 33);
            this.cmboBox_Month.TabIndex = 17;
            this.cmboBox_Month.Text = "--";
            this.cmboBox_Month.DropDown += new System.EventHandler(this.cmboBox_Month_DropDown);
            // 
            // lbl_AppointmentsTypesByMonth
            // 
            this.lbl_AppointmentsTypesByMonth.AutoSize = true;
            this.lbl_AppointmentsTypesByMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AppointmentsTypesByMonth.Location = new System.Drawing.Point(461, 35);
            this.lbl_AppointmentsTypesByMonth.Name = "lbl_AppointmentsTypesByMonth";
            this.lbl_AppointmentsTypesByMonth.Size = new System.Drawing.Size(407, 36);
            this.lbl_AppointmentsTypesByMonth.TabIndex = 16;
            this.lbl_AppointmentsTypesByMonth.Text = "Appointment Types By Month";
            // 
            // dgv_AppointmentTypesByMonth
            // 
            this.dgv_AppointmentTypesByMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AppointmentTypesByMonth.Location = new System.Drawing.Point(22, 208);
            this.dgv_AppointmentTypesByMonth.Name = "dgv_AppointmentTypesByMonth";
            this.dgv_AppointmentTypesByMonth.RowHeadersWidth = 51;
            this.dgv_AppointmentTypesByMonth.RowTemplate.Height = 24;
            this.dgv_AppointmentTypesByMonth.Size = new System.Drawing.Size(1288, 404);
            this.dgv_AppointmentTypesByMonth.TabIndex = 15;
            this.dgv_AppointmentTypesByMonth.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OnDataBindingComplete);
            // 
            // cmboBox_Type
            // 
            this.cmboBox_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Type.FormattingEnabled = true;
            this.cmboBox_Type.Location = new System.Drawing.Point(1083, 146);
            this.cmboBox_Type.Name = "cmboBox_Type";
            this.cmboBox_Type.Size = new System.Drawing.Size(174, 33);
            this.cmboBox_Type.TabIndex = 24;
            this.cmboBox_Type.Text = "--";
            this.cmboBox_Type.DropDown += new System.EventHandler(this.cmboBox_Type_DropDown);
            // 
            // lbl_TotalResults
            // 
            this.lbl_TotalResults.AutoSize = true;
            this.lbl_TotalResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalResults.Location = new System.Drawing.Point(92, 107);
            this.lbl_TotalResults.Name = "lbl_TotalResults";
            this.lbl_TotalResults.Size = new System.Drawing.Size(125, 25);
            this.lbl_TotalResults.TabIndex = 25;
            this.lbl_TotalResults.Text = "Total Results";
            // 
            // txtBox_TotalResults
            // 
            this.txtBox_TotalResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_TotalResults.Location = new System.Drawing.Point(114, 146);
            this.txtBox_TotalResults.Name = "txtBox_TotalResults";
            this.txtBox_TotalResults.ReadOnly = true;
            this.txtBox_TotalResults.Size = new System.Drawing.Size(72, 34);
            this.txtBox_TotalResults.TabIndex = 26;
            this.txtBox_TotalResults.TabStop = false;
            this.txtBox_TotalResults.Text = "--";
            this.txtBox_TotalResults.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AppointmentTypesByMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 796);
            this.Controls.Add(this.txtBox_TotalResults);
            this.Controls.Add(this.lbl_TotalResults);
            this.Controls.Add(this.cmboBox_Type);
            this.Controls.Add(this.btn_GenerateReport);
            this.Controls.Add(this.lbl_Year);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_Month);
            this.Controls.Add(this.cmboBox_Year);
            this.Controls.Add(this.cmboBox_Month);
            this.Controls.Add(this.lbl_AppointmentsTypesByMonth);
            this.Controls.Add(this.dgv_AppointmentTypesByMonth);
            this.Name = "AppointmentTypesByMonth";
            this.Text = "Appointments Types By Month";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AppointmentTypesByMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GenerateReport;
        private System.Windows.Forms.Label lbl_Year;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.Label lbl_Month;
        private System.Windows.Forms.ComboBox cmboBox_Year;
        private System.Windows.Forms.ComboBox cmboBox_Month;
        private System.Windows.Forms.Label lbl_AppointmentsTypesByMonth;
        private System.Windows.Forms.DataGridView dgv_AppointmentTypesByMonth;
        private System.Windows.Forms.ComboBox cmboBox_Type;
        private System.Windows.Forms.Label lbl_TotalResults;
        private System.Windows.Forms.TextBox txtBox_TotalResults;
    }
}