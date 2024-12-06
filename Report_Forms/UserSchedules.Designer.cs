namespace Appointments_Scheduler.Report_Forms
{
    partial class UserSchedules
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
            this.cmboBox_Users = new System.Windows.Forms.ComboBox();
            this.btn_GenerateReport = new System.Windows.Forms.Button();
            this.cmboBox_Month = new System.Windows.Forms.ComboBox();
            this.lbl_UserSchedules = new System.Windows.Forms.Label();
            this.dgv_UserSchedules = new System.Windows.Forms.DataGridView();
            this.lbl_Users = new System.Windows.Forms.Label();
            this.lbl_Timeframe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // cmboBox_Users
            // 
            this.cmboBox_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Users.FormattingEnabled = true;
            this.cmboBox_Users.Location = new System.Drawing.Point(60, 158);
            this.cmboBox_Users.Name = "cmboBox_Users";
            this.cmboBox_Users.Size = new System.Drawing.Size(328, 33);
            this.cmboBox_Users.TabIndex = 32;
            this.cmboBox_Users.Text = "--";
            // 
            // btn_GenerateReport
            // 
            this.btn_GenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerateReport.Location = new System.Drawing.Point(574, 665);
            this.btn_GenerateReport.Name = "btn_GenerateReport";
            this.btn_GenerateReport.Size = new System.Drawing.Size(172, 82);
            this.btn_GenerateReport.TabIndex = 31;
            this.btn_GenerateReport.Text = "Generate Report";
            this.btn_GenerateReport.UseVisualStyleBackColor = true;
            // 
            // cmboBox_Month
            // 
            this.cmboBox_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Month.FormattingEnabled = true;
            this.cmboBox_Month.Location = new System.Drawing.Point(985, 158);
            this.cmboBox_Month.Name = "cmboBox_Month";
            this.cmboBox_Month.Size = new System.Drawing.Size(239, 33);
            this.cmboBox_Month.TabIndex = 29;
            this.cmboBox_Month.Text = "--";
            // 
            // lbl_UserSchedules
            // 
            this.lbl_UserSchedules.AutoSize = true;
            this.lbl_UserSchedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserSchedules.Location = new System.Drawing.Point(549, 43);
            this.lbl_UserSchedules.Name = "lbl_UserSchedules";
            this.lbl_UserSchedules.Size = new System.Drawing.Size(226, 36);
            this.lbl_UserSchedules.TabIndex = 28;
            this.lbl_UserSchedules.Text = "User Schedules";
            // 
            // dgv_UserSchedules
            // 
            this.dgv_UserSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserSchedules.Location = new System.Drawing.Point(21, 220);
            this.dgv_UserSchedules.Name = "dgv_UserSchedules";
            this.dgv_UserSchedules.RowHeadersWidth = 51;
            this.dgv_UserSchedules.RowTemplate.Height = 24;
            this.dgv_UserSchedules.Size = new System.Drawing.Size(1288, 404);
            this.dgv_UserSchedules.TabIndex = 27;
            // 
            // lbl_Users
            // 
            this.lbl_Users.AutoSize = true;
            this.lbl_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Users.Location = new System.Drawing.Point(164, 109);
            this.lbl_Users.Name = "lbl_Users";
            this.lbl_Users.Size = new System.Drawing.Size(110, 25);
            this.lbl_Users.TabIndex = 36;
            this.lbl_Users.Text = "User Name";
            // 
            // lbl_Timeframe
            // 
            this.lbl_Timeframe.AutoSize = true;
            this.lbl_Timeframe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Timeframe.Location = new System.Drawing.Point(1045, 109);
            this.lbl_Timeframe.Name = "lbl_Timeframe";
            this.lbl_Timeframe.Size = new System.Drawing.Size(117, 25);
            this.lbl_Timeframe.TabIndex = 35;
            this.lbl_Timeframe.Text = "Time Frame";
            // 
            // UserSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 791);
            this.Controls.Add(this.lbl_Users);
            this.Controls.Add(this.lbl_Timeframe);
            this.Controls.Add(this.cmboBox_Users);
            this.Controls.Add(this.btn_GenerateReport);
            this.Controls.Add(this.cmboBox_Month);
            this.Controls.Add(this.lbl_UserSchedules);
            this.Controls.Add(this.dgv_UserSchedules);
            this.Name = "UserSchedules";
            this.Text = "UserSchedules";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserSchedules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmboBox_Users;
        private System.Windows.Forms.Button btn_GenerateReport;
        private System.Windows.Forms.ComboBox cmboBox_Month;
        private System.Windows.Forms.Label lbl_UserSchedules;
        private System.Windows.Forms.DataGridView dgv_UserSchedules;
        private System.Windows.Forms.Label lbl_Users;
        private System.Windows.Forms.Label lbl_Timeframe;
    }
}