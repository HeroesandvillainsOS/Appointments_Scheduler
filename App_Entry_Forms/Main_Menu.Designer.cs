namespace Appointments_Scheduler.Forms
{
    partial class Main_Menu
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
            this.btn_CustomerRecords = new System.Windows.Forms.Button();
            this.btn_Appointments = new System.Windows.Forms.Button();
            this.btn_Reports = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CustomerRecords
            // 
            this.btn_CustomerRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CustomerRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CustomerRecords.Location = new System.Drawing.Point(36, 160);
            this.btn_CustomerRecords.Name = "btn_CustomerRecords";
            this.btn_CustomerRecords.Size = new System.Drawing.Size(330, 291);
            this.btn_CustomerRecords.TabIndex = 0;
            this.btn_CustomerRecords.Text = "Customer Records";
            this.btn_CustomerRecords.UseVisualStyleBackColor = true;
            this.btn_CustomerRecords.Click += new System.EventHandler(this.btn_CustomerRecords_Click);
            // 
            // btn_Appointments
            // 
            this.btn_Appointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Appointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Appointments.Location = new System.Drawing.Point(424, 160);
            this.btn_Appointments.Name = "btn_Appointments";
            this.btn_Appointments.Size = new System.Drawing.Size(330, 291);
            this.btn_Appointments.TabIndex = 1;
            this.btn_Appointments.Text = "Appointments";
            this.btn_Appointments.UseVisualStyleBackColor = true;
            this.btn_Appointments.Click += new System.EventHandler(this.btn_Appointments_Click);
            // 
            // btn_Reports
            // 
            this.btn_Reports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reports.Location = new System.Drawing.Point(841, 160);
            this.btn_Reports.Name = "btn_Reports";
            this.btn_Reports.Size = new System.Drawing.Size(330, 291);
            this.btn_Reports.TabIndex = 3;
            this.btn_Reports.Text = "Reports";
            this.btn_Reports.UseVisualStyleBackColor = true;
            this.btn_Reports.Click += new System.EventHandler(this.btn_Reports_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(483, 575);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(214, 123);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 773);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Reports);
            this.Controls.Add(this.btn_Appointments);
            this.Controls.Add(this.btn_CustomerRecords);
            this.Name = "Main_Menu";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Menu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CustomerRecords;
        private System.Windows.Forms.Button btn_Appointments;
        private System.Windows.Forms.Button btn_Reports;
        private System.Windows.Forms.Button btn_Exit;
    }
}