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
            this.changedByRd = new System.Windows.Forms.RadioButton();
            this.projectDefectNumBox = new System.Windows.Forms.TextBox();
            this.defectTaskBox = new System.Windows.Forms.TextBox();
            this.defectTypeBox = new System.Windows.Forms.TextBox();
            this.projectIdLbl = new System.Windows.Forms.Label();
            this.taskIdLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.parameterLbl = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.noneRd = new System.Windows.Forms.RadioButton();
            this.developerEstimateChk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DefectCode = new System.Windows.Forms.Label();
            this.crTypeBox = new System.Windows.Forms.TextBox();
            this.crTaskIdBox = new System.Windows.Forms.TextBox();
            this.crProjectNumBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.processText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(12, 41);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(581, 22);
            this.UserNameBox.TabIndex = 0;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(12, 102);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(581, 22);
            this.PasswordBox.TabIndex = 1;
            // 
            // TfsURIBox
            // 
            this.TfsURIBox.Location = new System.Drawing.Point(12, 156);
            this.TfsURIBox.Name = "TfsURIBox";
            this.TfsURIBox.Size = new System.Drawing.Size(581, 22);
            this.TfsURIBox.TabIndex = 2;
            // 
            // btnGenCSV
            // 
            this.btnGenCSV.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGenCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenCSV.ForeColor = System.Drawing.Color.Black;
            this.btnGenCSV.Location = new System.Drawing.Point(11, 480);
            this.btnGenCSV.Name = "btnGenCSV";
            this.btnGenCSV.Size = new System.Drawing.Size(246, 37);
            this.btnGenCSV.TabIndex = 3;
            this.btnGenCSV.Text = "Generate Excel";
            this.btnGenCSV.UseVisualStyleBackColor = false;
            this.btnGenCSV.Click += new System.EventHandler(this.btnGenCSV_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(351, 480);
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
            // changedByRd
            // 
            this.changedByRd.AutoSize = true;
            this.changedByRd.Location = new System.Drawing.Point(129, 361);
            this.changedByRd.Name = "changedByRd";
            this.changedByRd.Size = new System.Drawing.Size(106, 21);
            this.changedByRd.TabIndex = 12;
            this.changedByRd.TabStop = true;
            this.changedByRd.Text = "Changed By";
            this.changedByRd.UseVisualStyleBackColor = true;
            // 
            // projectDefectNumBox
            // 
            this.projectDefectNumBox.Location = new System.Drawing.Point(12, 238);
            this.projectDefectNumBox.Name = "projectDefectNumBox";
            this.projectDefectNumBox.Size = new System.Drawing.Size(149, 22);
            this.projectDefectNumBox.TabIndex = 13;
            // 
            // defectTaskBox
            // 
            this.defectTaskBox.Location = new System.Drawing.Point(197, 238);
            this.defectTaskBox.Name = "defectTaskBox";
            this.defectTaskBox.Size = new System.Drawing.Size(149, 22);
            this.defectTaskBox.TabIndex = 14;
            // 
            // defectTypeBox
            // 
            this.defectTypeBox.Location = new System.Drawing.Point(384, 238);
            this.defectTypeBox.Name = "defectTypeBox";
            this.defectTypeBox.Size = new System.Drawing.Size(149, 22);
            this.defectTypeBox.TabIndex = 15;
            // 
            // projectIdLbl
            // 
            this.projectIdLbl.AutoSize = true;
            this.projectIdLbl.Location = new System.Drawing.Point(10, 211);
            this.projectIdLbl.Name = "projectIdLbl";
            this.projectIdLbl.Size = new System.Drawing.Size(106, 17);
            this.projectIdLbl.TabIndex = 16;
            this.projectIdLbl.Text = "Project Number";
            // 
            // taskIdLbl
            // 
            this.taskIdLbl.AutoSize = true;
            this.taskIdLbl.Location = new System.Drawing.Point(194, 211);
            this.taskIdLbl.Name = "taskIdLbl";
            this.taskIdLbl.Size = new System.Drawing.Size(56, 17);
            this.taskIdLbl.TabIndex = 17;
            this.taskIdLbl.Text = "Task ID";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Location = new System.Drawing.Point(381, 211);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(44, 17);
            this.typeLbl.TabIndex = 18;
            this.typeLbl.Text = "Type ";
            // 
            // parameterLbl
            // 
            this.parameterLbl.AutoSize = true;
            this.parameterLbl.Location = new System.Drawing.Point(12, 334);
            this.parameterLbl.Name = "parameterLbl";
            this.parameterLbl.Size = new System.Drawing.Size(129, 17);
            this.parameterLbl.TabIndex = 19;
            this.parameterLbl.Text = "General Parameter";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(11, 405);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(582, 27);
            this.progressBar.TabIndex = 20;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // noneRd
            // 
            this.noneRd.AutoSize = true;
            this.noneRd.Location = new System.Drawing.Point(15, 361);
            this.noneRd.Name = "noneRd";
            this.noneRd.Size = new System.Drawing.Size(108, 21);
            this.noneRd.TabIndex = 21;
            this.noneRd.TabStop = true;
            this.noneRd.Text = "Resolved By";
            this.noneRd.UseVisualStyleBackColor = true;
            // 
            // developerEstimateChk
            // 
            this.developerEstimateChk.AutoSize = true;
            this.developerEstimateChk.Location = new System.Drawing.Point(380, 361);
            this.developerEstimateChk.Name = "developerEstimateChk";
            this.developerEstimateChk.Size = new System.Drawing.Size(153, 21);
            this.developerEstimateChk.TabIndex = 22;
            this.developerEstimateChk.Text = "Developer Estimate";
            this.developerEstimateChk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Hour Parameter";
            // 
            // DefectCode
            // 
            this.DefectCode.AutoSize = true;
            this.DefectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefectCode.Location = new System.Drawing.Point(540, 241);
            this.DefectCode.Name = "DefectCode";
            this.DefectCode.Size = new System.Drawing.Size(55, 17);
            this.DefectCode.TabIndex = 24;
            this.DefectCode.Text = "Defect";
            // 
            // crTypeBox
            // 
            this.crTypeBox.Location = new System.Drawing.Point(384, 280);
            this.crTypeBox.Name = "crTypeBox";
            this.crTypeBox.Size = new System.Drawing.Size(149, 22);
            this.crTypeBox.TabIndex = 27;
            // 
            // crTaskIdBox
            // 
            this.crTaskIdBox.Location = new System.Drawing.Point(197, 280);
            this.crTaskIdBox.Name = "crTaskIdBox";
            this.crTaskIdBox.Size = new System.Drawing.Size(149, 22);
            this.crTaskIdBox.TabIndex = 26;
            // 
            // crProjectNumBox
            // 
            this.crProjectNumBox.Location = new System.Drawing.Point(12, 280);
            this.crProjectNumBox.Name = "crProjectNumBox";
            this.crProjectNumBox.Size = new System.Drawing.Size(149, 22);
            this.crProjectNumBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "CR";
            // 
            // processText
            // 
            this.processText.AutoSize = true;
            this.processText.BackColor = System.Drawing.Color.Transparent;
            this.processText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.processText.Image = ((System.Drawing.Image)(resources.GetObject("processText.Image")));
            this.processText.Location = new System.Drawing.Point(12, 449);
            this.processText.Name = "processText";
            this.processText.Size = new System.Drawing.Size(0, 17);
            this.processText.TabIndex = 29;
            // 
            // TfsTimeSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(605, 529);
            this.Controls.Add(this.processText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crTypeBox);
            this.Controls.Add(this.crTaskIdBox);
            this.Controls.Add(this.crProjectNumBox);
            this.Controls.Add(this.DefectCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.developerEstimateChk);
            this.Controls.Add(this.noneRd);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.parameterLbl);
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.taskIdLbl);
            this.Controls.Add(this.projectIdLbl);
            this.Controls.Add(this.defectTypeBox);
            this.Controls.Add(this.defectTaskBox);
            this.Controls.Add(this.projectDefectNumBox);
            this.Controls.Add(this.changedByRd);
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
            this.Name = "TfsTimeSheetForm";
            this.Text = "TFS Time Sheet Helper";
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
        private System.Windows.Forms.RadioButton changedByRd;
        private System.Windows.Forms.TextBox projectDefectNumBox;
        private System.Windows.Forms.TextBox defectTaskBox;
        private System.Windows.Forms.TextBox defectTypeBox;
        private System.Windows.Forms.Label projectIdLbl;
        private System.Windows.Forms.Label taskIdLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label parameterLbl;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.RadioButton noneRd;
        private System.Windows.Forms.CheckBox developerEstimateChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DefectCode;
        private System.Windows.Forms.TextBox crTypeBox;
        private System.Windows.Forms.TextBox crTaskIdBox;
        private System.Windows.Forms.TextBox crProjectNumBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label processText;
    }
}

