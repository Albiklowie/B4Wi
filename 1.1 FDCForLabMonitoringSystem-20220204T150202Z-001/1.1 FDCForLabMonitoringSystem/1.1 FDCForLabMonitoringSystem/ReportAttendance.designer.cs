namespace _1._1_FDCForLabMonitoringSystem
{
    partial class ReportAttendance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAttendance));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SubjectCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AttendanceDTP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ScheduleCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InstructorCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PrintAttendanceButton = new System.Windows.Forms.Button();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.EDPCodeTextbox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.Back_Btn = new System.Windows.Forms.Button();
            this.FaceRecognitionDBDataSet2 = new _1._1_FDCForLabMonitoringSystem.FaceRecognitionDBDataSetReport1();
            this.spFR_StudentAttendanceReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spFR_StudentAttendanceReportTableAdapter = new _1._1_FDCForLabMonitoringSystem.FaceRecognitionDBDataSetReport1TableAdapters.spFR_StudentAttendanceReportTableAdapter();
            this.AttendanceDTP2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FaceRecognitionDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFR_StudentAttendanceReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "_1._1_FDCForLabMonitoringSystem.Reports2.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 143);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ServerReport.ReportPath = "/AttendanceReport";
            this.reportViewer1.Size = new System.Drawing.Size(896, 381);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // SubjectCombobox
            // 
            this.SubjectCombobox.FormattingEnabled = true;
            this.SubjectCombobox.Location = new System.Drawing.Point(111, 74);
            this.SubjectCombobox.Name = "SubjectCombobox";
            this.SubjectCombobox.Size = new System.Drawing.Size(204, 21);
            this.SubjectCombobox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gotham Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subject Code:";
            // 
            // AttendanceDTP
            // 
            this.AttendanceDTP.CustomFormat = "yyyy-MM-dd";
            this.AttendanceDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttendanceDTP.Location = new System.Drawing.Point(682, 73);
            this.AttendanceDTP.Name = "AttendanceDTP";
            this.AttendanceDTP.Size = new System.Drawing.Size(114, 20);
            this.AttendanceDTP.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gotham Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(638, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start";
            // 
            // ScheduleCombobox
            // 
            this.ScheduleCombobox.FormattingEnabled = true;
            this.ScheduleCombobox.Location = new System.Drawing.Point(419, 101);
            this.ScheduleCombobox.Name = "ScheduleCombobox";
            this.ScheduleCombobox.Size = new System.Drawing.Size(213, 21);
            this.ScheduleCombobox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gotham Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(348, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Schedule:";
            // 
            // InstructorCombobox
            // 
            this.InstructorCombobox.FormattingEnabled = true;
            this.InstructorCombobox.Location = new System.Drawing.Point(111, 101);
            this.InstructorCombobox.Name = "InstructorCombobox";
            this.InstructorCombobox.Size = new System.Drawing.Size(204, 21);
            this.InstructorCombobox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gotham Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Instructor:";
            // 
            // PrintAttendanceButton
            // 
            this.PrintAttendanceButton.Location = new System.Drawing.Point(804, 71);
            this.PrintAttendanceButton.Name = "PrintAttendanceButton";
            this.PrintAttendanceButton.Size = new System.Drawing.Size(82, 23);
            this.PrintAttendanceButton.TabIndex = 9;
            this.PrintAttendanceButton.Text = "Print";
            this.PrintAttendanceButton.UseVisualStyleBackColor = true;
            // 
            // PreviewButton
            // 
            this.PreviewButton.Font = new System.Drawing.Font("Gotham Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewButton.Location = new System.Drawing.Point(804, 71);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(93, 51);
            this.PreviewButton.TabIndex = 10;
            this.PreviewButton.Text = "Print Preview";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gotham Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(348, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Subject Name:";
            // 
            // EDPCodeTextbox
            // 
            this.EDPCodeTextbox.Location = new System.Drawing.Point(442, 73);
            this.EDPCodeTextbox.Name = "EDPCodeTextbox";
            this.EDPCodeTextbox.Size = new System.Drawing.Size(190, 20);
            this.EDPCodeTextbox.TabIndex = 12;
            this.EDPCodeTextbox.Text = "1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(920, 5);
            this.panel4.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.Back_Btn);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 47);
            this.panel2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gotham Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 32);
            this.label6.TabIndex = 24;
            this.label6.Text = "Report";
            // 
            // Back_Btn
            // 
            this.Back_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.Back_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Back_Btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.Back_Btn.FlatAppearance.BorderSize = 0;
            this.Back_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.Back_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_Btn.Font = new System.Drawing.Font("Gotham Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_Btn.ForeColor = System.Drawing.Color.White;
            this.Back_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Back_Btn.Image")));
            this.Back_Btn.Location = new System.Drawing.Point(887, 0);
            this.Back_Btn.Name = "Back_Btn";
            this.Back_Btn.Size = new System.Drawing.Size(33, 47);
            this.Back_Btn.TabIndex = 25;
            this.Back_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Back_Btn.UseVisualStyleBackColor = false;
            this.Back_Btn.Click += new System.EventHandler(this.Back_Btn_Click);
            // 
            // FaceRecognitionDBDataSet2
            // 
            this.FaceRecognitionDBDataSet2.DataSetName = "FaceRecognitionDBDataSet2";
            this.FaceRecognitionDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spFR_StudentAttendanceReportBindingSource
            // 
            this.spFR_StudentAttendanceReportBindingSource.DataMember = "spFR_StudentAttendanceReport";
            this.spFR_StudentAttendanceReportBindingSource.DataSource = this.FaceRecognitionDBDataSet2;
            // 
            // spFR_StudentAttendanceReportTableAdapter
            // 
            this.spFR_StudentAttendanceReportTableAdapter.ClearBeforeFill = true;
            // 
            // AttendanceDTP2
            // 
            this.AttendanceDTP2.CustomFormat = "yyyy-MM-dd";
            this.AttendanceDTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttendanceDTP2.Location = new System.Drawing.Point(682, 102);
            this.AttendanceDTP2.Name = "AttendanceDTP2";
            this.AttendanceDTP2.Size = new System.Drawing.Size(114, 20);
            this.AttendanceDTP2.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gotham Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(638, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "End";
            // 
            // ReportAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 547);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AttendanceDTP2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.EDPCodeTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PreviewButton);
            this.Controls.Add(this.PrintAttendanceButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InstructorCombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScheduleCombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AttendanceDTP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubjectCombobox);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Report";
            this.Load += new System.EventHandler(this.ReportAttendance_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FaceRecognitionDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFR_StudentAttendanceReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox SubjectCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker AttendanceDTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ScheduleCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox InstructorCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PrintAttendanceButton;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.BindingSource spFR_StudentAttendanceReportBindingSource;
        private FaceRecognitionDBDataSetReport1 FaceRecognitionDBDataSet2;
        private FaceRecognitionDBDataSetReport1TableAdapters.spFR_StudentAttendanceReportTableAdapter spFR_StudentAttendanceReportTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EDPCodeTextbox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Back_Btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker AttendanceDTP2;
        private System.Windows.Forms.Label label7;
    }
}