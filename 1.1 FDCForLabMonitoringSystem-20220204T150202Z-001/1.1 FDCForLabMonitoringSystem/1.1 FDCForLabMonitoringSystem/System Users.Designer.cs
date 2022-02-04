namespace _1._1_FDCForLabMonitoringSystem
{
    partial class System_Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(System_Users));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UserAccessComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.UserRetypePasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.UserLastNameTextBox = new System.Windows.Forms.TextBox();
            this.UserFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_addUser = new System.Windows.Forms.Button();
            this.UserEditButton = new System.Windows.Forms.Button();
            this.UserDeleteButton = new System.Windows.Forms.Button();
            this.UserClearButton = new System.Windows.Forms.Button();
            this.SystemUsersDGV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UserStatusComboBox = new System.Windows.Forms.ComboBox();
            this.UserValidUntilDTP = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemUsersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(955, 5);
            this.panel4.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 47);
            this.panel2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(922, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 47);
            this.button1.TabIndex = 25;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gotham Bold", 20.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 32);
            this.label2.TabIndex = 24;
            this.label2.Text = "Manage Users";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UserAccessComboBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.UserRetypePasswordTextBox);
            this.groupBox2.Controls.Add(this.UserPasswordTextBox);
            this.groupBox2.Controls.Add(this.UserNameTextBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.UserLastNameTextBox);
            this.groupBox2.Controls.Add(this.UserFirstNameTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 209);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User details";
            // 
            // UserAccessComboBox
            // 
            this.UserAccessComboBox.FormattingEnabled = true;
            this.UserAccessComboBox.Items.AddRange(new object[] {
            "Administrator",
            "Laboratory Staff",
            "User"});
            this.UserAccessComboBox.Location = new System.Drawing.Point(102, 31);
            this.UserAccessComboBox.Name = "UserAccessComboBox";
            this.UserAccessComboBox.Size = new System.Drawing.Size(219, 24);
            this.UserAccessComboBox.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Retype password:";
            // 
            // UserRetypePasswordTextBox
            // 
            this.UserRetypePasswordTextBox.Location = new System.Drawing.Point(146, 176);
            this.UserRetypePasswordTextBox.Name = "UserRetypePasswordTextBox";
            this.UserRetypePasswordTextBox.PasswordChar = '*';
            this.UserRetypePasswordTextBox.Size = new System.Drawing.Size(175, 22);
            this.UserRetypePasswordTextBox.TabIndex = 27;
            // 
            // UserPasswordTextBox
            // 
            this.UserPasswordTextBox.Location = new System.Drawing.Point(102, 147);
            this.UserPasswordTextBox.Name = "UserPasswordTextBox";
            this.UserPasswordTextBox.PasswordChar = '*';
            this.UserPasswordTextBox.Size = new System.Drawing.Size(219, 22);
            this.UserPasswordTextBox.TabIndex = 26;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(102, 118);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(219, 22);
            this.UserNameTextBox.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 150);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 16);
            this.label16.TabIndex = 22;
            this.label16.Text = "Password:";
            // 
            // UserLastNameTextBox
            // 
            this.UserLastNameTextBox.Location = new System.Drawing.Point(102, 89);
            this.UserLastNameTextBox.Name = "UserLastNameTextBox";
            this.UserLastNameTextBox.Size = new System.Drawing.Size(219, 22);
            this.UserLastNameTextBox.TabIndex = 15;
            // 
            // UserFirstNameTextBox
            // 
            this.UserFirstNameTextBox.Location = new System.Drawing.Point(102, 60);
            this.UserFirstNameTextBox.Name = "UserFirstNameTextBox";
            this.UserFirstNameTextBox.Size = new System.Drawing.Size(219, 22);
            this.UserFirstNameTextBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Last name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "First name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Access as:";
            // 
            // btn_addUser
            // 
            this.btn_addUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.btn_addUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_addUser.FlatAppearance.BorderSize = 0;
            this.btn_addUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.btn_addUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addUser.ForeColor = System.Drawing.Color.White;
            this.btn_addUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addUser.Location = new System.Drawing.Point(357, 382);
            this.btn_addUser.Name = "btn_addUser";
            this.btn_addUser.Size = new System.Drawing.Size(125, 31);
            this.btn_addUser.TabIndex = 36;
            this.btn_addUser.Text = "Add User";
            this.btn_addUser.UseVisualStyleBackColor = false;
            this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // UserEditButton
            // 
            this.UserEditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.UserEditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UserEditButton.FlatAppearance.BorderSize = 0;
            this.UserEditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.UserEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserEditButton.ForeColor = System.Drawing.Color.White;
            this.UserEditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UserEditButton.Location = new System.Drawing.Point(24, 382);
            this.UserEditButton.Name = "UserEditButton";
            this.UserEditButton.Size = new System.Drawing.Size(77, 31);
            this.UserEditButton.TabIndex = 37;
            this.UserEditButton.Text = "Update";
            this.UserEditButton.UseVisualStyleBackColor = false;
            this.UserEditButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserDeleteButton
            // 
            this.UserDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.UserDeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UserDeleteButton.FlatAppearance.BorderSize = 0;
            this.UserDeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.UserDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserDeleteButton.ForeColor = System.Drawing.Color.White;
            this.UserDeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UserDeleteButton.Location = new System.Drawing.Point(107, 382);
            this.UserDeleteButton.Name = "UserDeleteButton";
            this.UserDeleteButton.Size = new System.Drawing.Size(77, 31);
            this.UserDeleteButton.TabIndex = 38;
            this.UserDeleteButton.Text = "Delete";
            this.UserDeleteButton.UseVisualStyleBackColor = false;
            this.UserDeleteButton.Click += new System.EventHandler(this.UserDeleteButton_Click);
            // 
            // UserClearButton
            // 
            this.UserClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.UserClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UserClearButton.FlatAppearance.BorderSize = 0;
            this.UserClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(48)))), ((int)(((byte)(166)))));
            this.UserClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserClearButton.ForeColor = System.Drawing.Color.White;
            this.UserClearButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UserClearButton.Location = new System.Drawing.Point(190, 382);
            this.UserClearButton.Name = "UserClearButton";
            this.UserClearButton.Size = new System.Drawing.Size(77, 31);
            this.UserClearButton.TabIndex = 39;
            this.UserClearButton.Text = "Clear";
            this.UserClearButton.UseVisualStyleBackColor = false;
            this.UserClearButton.Click += new System.EventHandler(this.UserClearButton_Click);
            // 
            // SystemUsersDGV
            // 
            this.SystemUsersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SystemUsersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SystemUsersDGV.Location = new System.Drawing.Point(357, 86);
            this.SystemUsersDGV.Name = "SystemUsersDGV";
            this.SystemUsersDGV.Size = new System.Drawing.Size(571, 290);
            this.SystemUsersDGV.TabIndex = 40;
            this.SystemUsersDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SystemUsersDGV_RowHeaderMouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 42;
            this.label6.Text = "User status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "Valid until:";
            // 
            // UserStatusComboBox
            // 
            this.UserStatusComboBox.FormattingEnabled = true;
            this.UserStatusComboBox.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.UserStatusComboBox.Location = new System.Drawing.Point(115, 336);
            this.UserStatusComboBox.Name = "UserStatusComboBox";
            this.UserStatusComboBox.Size = new System.Drawing.Size(219, 21);
            this.UserStatusComboBox.TabIndex = 38;
            // 
            // UserValidUntilDTP
            // 
            this.UserValidUntilDTP.Location = new System.Drawing.Point(115, 307);
            this.UserValidUntilDTP.Name = "UserValidUntilDTP";
            this.UserValidUntilDTP.Size = new System.Drawing.Size(218, 20);
            this.UserValidUntilDTP.TabIndex = 43;
            // 
            // System_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 450);
            this.Controls.Add(this.UserValidUntilDTP);
            this.Controls.Add(this.UserStatusComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SystemUsersDGV);
            this.Controls.Add(this.UserClearButton);
            this.Controls.Add(this.UserDeleteButton);
            this.Controls.Add(this.UserEditButton);
            this.Controls.Add(this.btn_addUser);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "System_Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System_Users";
            this.Load += new System.EventHandler(this.System_Users_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemUsersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox UserRetypePasswordTextBox;
        private System.Windows.Forms.TextBox UserPasswordTextBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox UserLastNameTextBox;
        private System.Windows.Forms.TextBox UserFirstNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UserAccessComboBox;
        private System.Windows.Forms.Button btn_addUser;
        private System.Windows.Forms.Button UserEditButton;
        private System.Windows.Forms.Button UserDeleteButton;
        private System.Windows.Forms.Button UserClearButton;
        private System.Windows.Forms.DataGridView SystemUsersDGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox UserStatusComboBox;
        private System.Windows.Forms.DateTimePicker UserValidUntilDTP;
    }
}