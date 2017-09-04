namespace TfsTimeSheetHelper
{
    partial class TfsTimeSheetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfsTimeSheetForm));
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.TfsURIBox = new System.Windows.Forms.TextBox();
            this.btnGenCSV = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblTFSUrl = new System.Windows.Forms.Label();
            this.developerEstimateRd = new System.Windows.Forms.RadioButton();
            this.changedByRd = new System.Windows.Forms.RadioButton();
            this.projectNumBox = new System.Windows.Forms.TextBox();
            this.taskBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.projectIdLbl = new System.Windows.Forms.Label();
            this.taskIdLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.parameterLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(12, 41);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(521, 22);
            this.UserNameBox.TabIndex = 0;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(12, 102);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(521, 22);
            this.PasswordBox.TabIndex = 1;
            // 
            // TfsURIBox
            // 
            this.TfsURIBox.Location = new System.Drawing.Point(12, 156);
            this.TfsURIBox.Name = "TfsURIBox";
            this.TfsURIBox.Size = new System.Drawing.Size(521, 22);
            this.TfsURIBox.TabIndex = 2;
            // 
            // btnGenCSV
            // 
            this.btnGenCSV.Location = new System.Drawing.Point(11, 329);
            this.btnGenCSV.Name = "btnGenCSV";
            this.btnGenCSV.Size = new System.Drawing.Size(246, 37);
            this.btnGenCSV.TabIndex = 3;
            this.btnGenCSV.Text = "Generate CSV";
            this.btnGenCSV.UseVisualStyleBackColor = true;
            this.btnGenCSV.Click += new System.EventHandler(this.btnGenCSV_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(289, 329);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(244, 37);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(8, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(111, 17);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Enter Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 80);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(107, 17);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Enter Password";
            // 
            // lblTFSUrl
            // 
            this.lblTFSUrl.AutoSize = true;
            this.lblTFSUrl.Location = new System.Drawing.Point(9, 136);
            this.lblTFSUrl.Name = "lblTFSUrl";
            this.lblTFSUrl.Size = new System.Drawing.Size(66, 17);
            this.lblTFSUrl.TabIndex = 7;
            this.lblTFSUrl.Text = "TFS URL";
            // 
            // developerEstimateRd
            // 
            this.developerEstimateRd.AutoSize = true;
            this.developerEstimateRd.Location = new System.Drawing.Point(12, 287);
            this.developerEstimateRd.Name = "developerEstimateRd";
            this.developerEstimateRd.Size = new System.Drawing.Size(152, 21);
            this.developerEstimateRd.TabIndex = 11;
            this.developerEstimateRd.TabStop = true;
            this.developerEstimateRd.Text = "Developer Estimate";
            this.developerEstimateRd.UseVisualStyleBackColor = true;
            // 
            // changedByRd
            // 
            this.changedByRd.AutoSize = true;
            this.changedByRd.Location = new System.Drawing.Point(179, 287);
            this.changedByRd.Name = "changedByRd";
            this.changedByRd.Size = new System.Drawing.Size(106, 21);
            this.changedByRd.TabIndex = 12;
            this.changedByRd.TabStop = true;
            this.changedByRd.Text = "Changed By";
            this.changedByRd.UseVisualStyleBackColor = true;
            // 
            // projectNumBox
            // 
            this.projectNumBox.Location = new System.Drawing.Point(12, 218);
            this.projectNumBox.Name = "projectNumBox";
            this.projectNumBox.Size = new System.Drawing.Size(149, 22);
            this.projectNumBox.TabIndex = 13;
            // 
            // taskBox
            // 
            this.taskBox.Location = new System.Drawing.Point(197, 218);
            this.taskBox.Name = "taskBox";
            this.taskBox.Size = new System.Drawing.Size(149, 22);
            this.taskBox.TabIndex = 14;
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(384, 218);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(149, 22);
            this.typeBox.TabIndex = 15;
            // 
            // projectIdLbl
            // 
            this.projectIdLbl.AutoSize = true;
            this.projectIdLbl.Location = new System.Drawing.Point(10, 195);
            this.projectIdLbl.Name = "projectIdLbl";
            this.projectIdLbl.Size = new System.Drawing.Size(106, 17);
            this.projectIdLbl.TabIndex = 16;
            this.projectIdLbl.Text = "Project Number";
            // 
            // taskIdLbl
            // 
            this.taskIdLbl.AutoSize = true;
            this.taskIdLbl.Location = new System.Drawing.Point(194, 195);
            this.taskIdLbl.Name = "taskIdLbl";
            this.taskIdLbl.Size = new System.Drawing.Size(56, 17);
            this.taskIdLbl.TabIndex = 17;
            this.taskIdLbl.Text = "Task ID";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Location = new System.Drawing.Point(381, 195);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(44, 17);
            this.typeLbl.TabIndex = 18;
            this.typeLbl.Text = "Type ";
            // 
            // parameterLbl
            // 
            this.parameterLbl.AutoSize = true;
            this.parameterLbl.Location = new System.Drawing.Point(12, 260);
            this.parameterLbl.Name = "parameterLbl";
            this.parameterLbl.Size = new System.Drawing.Size(81, 17);
            this.parameterLbl.TabIndex = 19;
            this.parameterLbl.Text = "Parameters";
            // 
            // TfsTimeSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(546, 383);
            this.Controls.Add(this.parameterLbl);
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.taskIdLbl);
            this.Controls.Add(this.projectIdLbl);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.taskBox);
            this.Controls.Add(this.projectNumBox);
            this.Controls.Add(this.changedByRd);
            this.Controls.Add(this.developerEstimateRd);
            this.Controls.Add(this.lblTFSUrl);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.btnGenCSV);
            this.Controls.Add(this.TfsURIBox);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserNameBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TfsTimeSheetForm";
            this.Text = "TFS Time Sheet Helper";
            this.Load += new System.EventHandler(this.TfsTimeSheetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox TfsURIBox;
        private System.Windows.Forms.Button btnGenCSV;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTFSUrl;
        private System.Windows.Forms.RadioButton developerEstimateRd;
        private System.Windows.Forms.RadioButton changedByRd;
        private System.Windows.Forms.TextBox projectNumBox;
        private System.Windows.Forms.TextBox taskBox;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.Label projectIdLbl;
        private System.Windows.Forms.Label taskIdLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label parameterLbl;
    }
}

