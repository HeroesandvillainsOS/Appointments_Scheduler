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
            this.lbl_FilterAppointmentsByType = new System.Windows.Forms.Label();
            this.dgv_AppointmentsByType = new System.Windows.Forms.DataGridView();
            this.cmboBox_Type = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AppointmentsByType)).BeginInit();
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
            // lbl_FilterAppointmentsByType
            // 
            this.lbl_FilterAppointmentsByType.AutoSize = true;
            this.lbl_FilterAppointmentsByType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilterAppointmentsByType.Location = new System.Drawing.Point(479, 32);
            this.lbl_FilterAppointmentsByType.Name = "lbl_FilterAppointmentsByType";
            this.lbl_FilterAppointmentsByType.Size = new System.Drawing.Size(389, 36);
            this.lbl_FilterAppointmentsByType.TabIndex = 16;
            this.lbl_FilterAppointmentsByType.Text = "Filter Appointments By Type";
            // 
            // dgv_AppointmentsByType
            // 
            this.dgv_AppointmentsByType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AppointmentsByType.Location = new System.Drawing.Point(22, 208);
            this.dgv_AppointmentsByType.Name = "dgv_AppointmentsByType";
            this.dgv_AppointmentsByType.RowHeadersWidth = 51;
            this.dgv_AppointmentsByType.RowTemplate.Height = 24;
            this.dgv_AppointmentsByType.Size = new System.Drawing.Size(1288, 404);
            this.dgv_AppointmentsByType.TabIndex = 15;
            this.dgv_AppointmentsByType.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OnDataBindingComplete);
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
            // AppointmentTypesByMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 796);
            this.Controls.Add(this.cmboBox_Type);
            this.Controls.Add(this.btn_GenerateReport);
            this.Controls.Add(this.lbl_Year);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_Month);
            this.Controls.Add(this.cmboBox_Year);
            this.Controls.Add(this.cmboBox_Month);
            this.Controls.Add(this.lbl_FilterAppointmentsByType);
            this.Controls.Add(this.dgv_AppointmentsByType);
            this.Name = "AppointmentTypesByMonth";
            this.Text = "Appointment Types By Month";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AppointmentsByType)).EndInit();
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
        private System.Windows.Forms.Label lbl_FilterAppointmentsByType;
        private System.Windows.Forms.DataGridView dgv_AppointmentsByType;
        private System.Windows.Forms.ComboBox cmboBox_Type;
    }
}