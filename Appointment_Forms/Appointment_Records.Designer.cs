namespace Appointments_Scheduler.Appointment_Forms
{
    partial class Appointment_Records
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
            this.dgv_Appointments = new System.Windows.Forms.DataGridView();
            this.lbl_AllAppointments = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.cmboBox_Month = new System.Windows.Forms.ComboBox();
            this.cmboBox_Day = new System.Windows.Forms.ComboBox();
            this.cmboBox_Year = new System.Windows.Forms.ComboBox();
            this.lbl_Month = new System.Windows.Forms.Label();
            this.lbl_Day = new System.Windows.Forms.Label();
            this.lbl_Year = new System.Windows.Forms.Label();
            this.btn_FilterAppointments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Appointments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Appointments
            // 
            this.dgv_Appointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Appointments.Location = new System.Drawing.Point(12, 217);
            this.dgv_Appointments.Name = "dgv_Appointments";
            this.dgv_Appointments.RowHeadersWidth = 51;
            this.dgv_Appointments.RowTemplate.Height = 24;
            this.dgv_Appointments.Size = new System.Drawing.Size(1358, 404);
            this.dgv_Appointments.TabIndex = 0;
            this.dgv_Appointments.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OnDataBindingComplete);
            // 
            // lbl_AllAppointments
            // 
            this.lbl_AllAppointments.AutoSize = true;
            this.lbl_AllAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AllAppointments.Location = new System.Drawing.Point(563, 37);
            this.lbl_AllAppointments.Name = "lbl_AllAppointments";
            this.lbl_AllAppointments.Size = new System.Drawing.Size(241, 36);
            this.lbl_AllAppointments.TabIndex = 1;
            this.lbl_AllAppointments.Text = "All Appointments";
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(264, 685);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(186, 65);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(928, 685);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(186, 65);
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.Location = new System.Drawing.Point(590, 685);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(186, 65);
            this.btn_Edit.TabIndex = 5;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // cmboBox_Month
            // 
            this.cmboBox_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Month.FormattingEnabled = true;
            this.cmboBox_Month.Location = new System.Drawing.Point(681, 150);
            this.cmboBox_Month.Name = "cmboBox_Month";
            this.cmboBox_Month.Size = new System.Drawing.Size(145, 33);
            this.cmboBox_Month.TabIndex = 8;
            this.cmboBox_Month.DropDown += new System.EventHandler(this.cmboBox_Month_DropDown);
            this.cmboBox_Month.SelectedIndexChanged += new System.EventHandler(this.cmboBox_Month_SelectedIndexChanged);
            // 
            // cmboBox_Day
            // 
            this.cmboBox_Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Day.FormattingEnabled = true;
            this.cmboBox_Day.Location = new System.Drawing.Point(847, 150);
            this.cmboBox_Day.Name = "cmboBox_Day";
            this.cmboBox_Day.Size = new System.Drawing.Size(145, 33);
            this.cmboBox_Day.TabIndex = 9;
            this.cmboBox_Day.DropDown += new System.EventHandler(this.cmboBox_Day_DropDown);
            this.cmboBox_Day.SelectedIndexChanged += new System.EventHandler(this.cmboBox_Day_SelectedIndexChanged);
            // 
            // cmboBox_Year
            // 
            this.cmboBox_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBox_Year.FormattingEnabled = true;
            this.cmboBox_Year.Location = new System.Drawing.Point(1016, 150);
            this.cmboBox_Year.Name = "cmboBox_Year";
            this.cmboBox_Year.Size = new System.Drawing.Size(145, 33);
            this.cmboBox_Year.TabIndex = 10;
            this.cmboBox_Year.DropDown += new System.EventHandler(this.cmboBox_Year_DropDown);
            this.cmboBox_Year.SelectedIndexChanged += new System.EventHandler(this.cmboBox_Year_SelectedIndexChanged);
            // 
            // lbl_Month
            // 
            this.lbl_Month.AutoSize = true;
            this.lbl_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Month.Location = new System.Drawing.Point(720, 111);
            this.lbl_Month.Name = "lbl_Month";
            this.lbl_Month.Size = new System.Drawing.Size(67, 25);
            this.lbl_Month.TabIndex = 11;
            this.lbl_Month.Text = "Month";
            // 
            // lbl_Day
            // 
            this.lbl_Day.AutoSize = true;
            this.lbl_Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Day.Location = new System.Drawing.Point(893, 111);
            this.lbl_Day.Name = "lbl_Day";
            this.lbl_Day.Size = new System.Drawing.Size(47, 25);
            this.lbl_Day.TabIndex = 12;
            this.lbl_Day.Text = "Day";
            // 
            // lbl_Year
            // 
            this.lbl_Year.AutoSize = true;
            this.lbl_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Year.Location = new System.Drawing.Point(1064, 111);
            this.lbl_Year.Name = "lbl_Year";
            this.lbl_Year.Size = new System.Drawing.Size(53, 25);
            this.lbl_Year.TabIndex = 13;
            this.lbl_Year.Text = "Year";
            // 
            // btn_FilterAppointments
            // 
            this.btn_FilterAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FilterAppointments.Location = new System.Drawing.Point(1190, 118);
            this.btn_FilterAppointments.Name = "btn_FilterAppointments";
            this.btn_FilterAppointments.Size = new System.Drawing.Size(148, 65);
            this.btn_FilterAppointments.TabIndex = 14;
            this.btn_FilterAppointments.Text = "Filter Appointments";
            this.btn_FilterAppointments.UseVisualStyleBackColor = true;
            // 
            // Appointment_Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 819);
            this.Controls.Add(this.btn_FilterAppointments);
            this.Controls.Add(this.lbl_Year);
            this.Controls.Add(this.lbl_Day);
            this.Controls.Add(this.lbl_Month);
            this.Controls.Add(this.cmboBox_Year);
            this.Controls.Add(this.cmboBox_Day);
            this.Controls.Add(this.cmboBox_Month);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.lbl_AllAppointments);
            this.Controls.Add(this.dgv_Appointments);
            this.Name = "Appointment_Records";
            this.Text = "Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Appointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Appointments;
        private System.Windows.Forms.Label lbl_AllAppointments;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.ComboBox cmboBox_Month;
        private System.Windows.Forms.ComboBox cmboBox_Day;
        private System.Windows.Forms.ComboBox cmboBox_Year;
        private System.Windows.Forms.Label lbl_Month;
        private System.Windows.Forms.Label lbl_Day;
        private System.Windows.Forms.Label lbl_Year;
        private System.Windows.Forms.Button btn_FilterAppointments;
    }
}