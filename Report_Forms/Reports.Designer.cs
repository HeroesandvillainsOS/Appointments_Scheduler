namespace Appointments_Scheduler.Report_Forms
{
    partial class Reports
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_CountriesServed = new System.Windows.Forms.Button();
            this.btn_UserSchedules = new System.Windows.Forms.Button();
            this.btn_AppointmentTypesByMonth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(493, 568);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(214, 123);
            this.btn_Exit.TabIndex = 8;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // btn_CountriesServed
            // 
            this.btn_CountriesServed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CountriesServed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CountriesServed.Location = new System.Drawing.Point(841, 155);
            this.btn_CountriesServed.Name = "btn_CountriesServed";
            this.btn_CountriesServed.Size = new System.Drawing.Size(330, 291);
            this.btn_CountriesServed.TabIndex = 7;
            this.btn_CountriesServed.Text = "Countries Served";
            this.btn_CountriesServed.UseVisualStyleBackColor = true;
            this.btn_CountriesServed.Click += new System.EventHandler(this.btn_CountriesServed_Click);
            // 
            // btn_UserSchedules
            // 
            this.btn_UserSchedules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UserSchedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UserSchedules.Location = new System.Drawing.Point(436, 155);
            this.btn_UserSchedules.Name = "btn_UserSchedules";
            this.btn_UserSchedules.Size = new System.Drawing.Size(330, 291);
            this.btn_UserSchedules.TabIndex = 6;
            this.btn_UserSchedules.Text = "User Schedules";
            this.btn_UserSchedules.UseVisualStyleBackColor = true;
            this.btn_UserSchedules.Click += new System.EventHandler(this.btn_UserSchedules_Click);
            // 
            // btn_AppointmentTypesByMonth
            // 
            this.btn_AppointmentTypesByMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AppointmentTypesByMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AppointmentTypesByMonth.Location = new System.Drawing.Point(43, 155);
            this.btn_AppointmentTypesByMonth.Name = "btn_AppointmentTypesByMonth";
            this.btn_AppointmentTypesByMonth.Size = new System.Drawing.Size(330, 291);
            this.btn_AppointmentTypesByMonth.TabIndex = 5;
            this.btn_AppointmentTypesByMonth.Text = "Appointment Types By Month";
            this.btn_AppointmentTypesByMonth.UseVisualStyleBackColor = true;
            this.btn_AppointmentTypesByMonth.Click += new System.EventHandler(this.btn_AppointmentTypesByMonth_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 761);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_CountriesServed);
            this.Controls.Add(this.btn_UserSchedules);
            this.Controls.Add(this.btn_AppointmentTypesByMonth);
            this.Name = "Reports";
            this.Text = "Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_CountriesServed;
        private System.Windows.Forms.Button btn_UserSchedules;
        private System.Windows.Forms.Button btn_AppointmentTypesByMonth;
    }
}