namespace TestingPolSourceGrouping
{
    partial class TestingPolSourceGrouping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestingPolSourceGrouping));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.butLoadExcelSheet = new System.Windows.Forms.Button();
            this.checkBoxFR = new System.Windows.Forms.CheckBox();
            this.butCheckCircular = new System.Windows.Forms.Button();
            this.butShowReportText = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butSeeFileNamesThatWillBeGenerated = new System.Windows.Forms.Button();
            this.butGenerateAllCodeFiles = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butPartialServiceResFR = new System.Windows.Forms.Button();
            this.butPartialServiceResEN = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFileLocation = new System.Windows.Forms.TextBox();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxStatus);
            this.splitContainer1.Size = new System.Drawing.Size(1147, 816);
            this.splitContainer1.SplitterDistance = 623;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(909, 512);
            this.panel4.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.butLoadExcelSheet);
            this.panel5.Controls.Add(this.checkBoxFR);
            this.panel5.Controls.Add(this.butCheckCircular);
            this.panel5.Controls.Add(this.butShowReportText);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(909, 41);
            this.panel5.TabIndex = 72;
            // 
            // butLoadExcelSheet
            // 
            this.butLoadExcelSheet.Location = new System.Drawing.Point(14, 8);
            this.butLoadExcelSheet.Name = "butLoadExcelSheet";
            this.butLoadExcelSheet.Size = new System.Drawing.Size(182, 23);
            this.butLoadExcelSheet.TabIndex = 0;
            this.butLoadExcelSheet.Text = "Load and Check Excel Sheet";
            this.butLoadExcelSheet.UseVisualStyleBackColor = true;
            this.butLoadExcelSheet.Click += new System.EventHandler(this.butLoadExcelSheet_Click);
            // 
            // checkBoxFR
            // 
            this.checkBoxFR.AutoSize = true;
            this.checkBoxFR.Location = new System.Drawing.Point(437, 14);
            this.checkBoxFR.Name = "checkBoxFR";
            this.checkBoxFR.Size = new System.Drawing.Size(66, 17);
            this.checkBoxFR.TabIndex = 71;
            this.checkBoxFR.Text = "Français";
            this.checkBoxFR.UseVisualStyleBackColor = true;
            this.checkBoxFR.CheckedChanged += new System.EventHandler(this.checkBoxFR_CheckedChanged);
            // 
            // butCheckCircular
            // 
            this.butCheckCircular.Location = new System.Drawing.Point(202, 8);
            this.butCheckCircular.Name = "butCheckCircular";
            this.butCheckCircular.Size = new System.Drawing.Size(81, 23);
            this.butCheckCircular.TabIndex = 0;
            this.butCheckCircular.Text = "Get All Paths";
            this.butCheckCircular.UseVisualStyleBackColor = true;
            this.butCheckCircular.Click += new System.EventHandler(this.butShowAllPaths_Click);
            // 
            // butShowReportText
            // 
            this.butShowReportText.Location = new System.Drawing.Point(289, 8);
            this.butShowReportText.Name = "butShowReportText";
            this.butShowReportText.Size = new System.Drawing.Size(133, 23);
            this.butShowReportText.TabIndex = 69;
            this.butShowReportText.Text = "Show Report Text";
            this.butShowReportText.UseVisualStyleBackColor = true;
            this.butShowReportText.Click += new System.EventHandler(this.butShowReportText_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butSeeFileNamesThatWillBeGenerated);
            this.panel3.Controls.Add(this.butGenerateAllCodeFiles);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.butPartialServiceResFR);
            this.panel3.Controls.Add(this.butPartialServiceResEN);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(909, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 553);
            this.panel3.TabIndex = 10;
            // 
            // butSeeFileNamesThatWillBeGenerated
            // 
            this.butSeeFileNamesThatWillBeGenerated.Location = new System.Drawing.Point(29, 31);
            this.butSeeFileNamesThatWillBeGenerated.Name = "butSeeFileNamesThatWillBeGenerated";
            this.butSeeFileNamesThatWillBeGenerated.Size = new System.Drawing.Size(199, 23);
            this.butSeeFileNamesThatWillBeGenerated.TabIndex = 6;
            this.butSeeFileNamesThatWillBeGenerated.Text = "See file code that will be generated";
            this.butSeeFileNamesThatWillBeGenerated.UseVisualStyleBackColor = true;
            this.butSeeFileNamesThatWillBeGenerated.Click += new System.EventHandler(this.butSeeFileNamesThatWillBeGenerated_Click);
            // 
            // butGenerateAllCodeFiles
            // 
            this.butGenerateAllCodeFiles.Location = new System.Drawing.Point(28, 60);
            this.butGenerateAllCodeFiles.Name = "butGenerateAllCodeFiles";
            this.butGenerateAllCodeFiles.Size = new System.Drawing.Size(199, 23);
            this.butGenerateAllCodeFiles.TabIndex = 6;
            this.butGenerateAllCodeFiles.Text = "Generate all code files";
            this.butGenerateAllCodeFiles.UseVisualStyleBackColor = true;
            this.butGenerateAllCodeFiles.Click += new System.EventHandler(this.butGenerateAllCodeFiles_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "for Charles";
            // 
            // butPartialServiceResFR
            // 
            this.butPartialServiceResFR.Location = new System.Drawing.Point(45, 143);
            this.butPartialServiceResFR.Name = "butPartialServiceResFR";
            this.butPartialServiceResFR.Size = new System.Drawing.Size(182, 23);
            this.butPartialServiceResFR.TabIndex = 0;
            this.butPartialServiceResFR.Text = "PolSourceInfoEnumRes FR";
            this.butPartialServiceResFR.UseVisualStyleBackColor = true;
            this.butPartialServiceResFR.Click += new System.EventHandler(this.butPolSourceInfoEnumResFR_Click);
            // 
            // butPartialServiceResEN
            // 
            this.butPartialServiceResEN.Location = new System.Drawing.Point(45, 114);
            this.butPartialServiceResEN.Name = "butPartialServiceResEN";
            this.butPartialServiceResEN.Size = new System.Drawing.Size(182, 23);
            this.butPartialServiceResEN.TabIndex = 0;
            this.butPartialServiceResEN.Text = "PolSourceInfoEnumRes EN";
            this.butPartialServiceResEN.UseVisualStyleBackColor = true;
            this.butPartialServiceResEN.Click += new System.EventHandler(this.butPolSourceInfoEnumResEN_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 588);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1143, 31);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(66, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxFileLocation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 35);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Location:";
            // 
            // textBoxFileLocation
            // 
            this.textBoxFileLocation.Location = new System.Drawing.Point(90, 6);
            this.textBoxFileLocation.Name = "textBoxFileLocation";
            this.textBoxFileLocation.Size = new System.Drawing.Size(701, 20);
            this.textBoxFileLocation.TabIndex = 1;
            this.textBoxFileLocation.Text = "C:\\Users\\leblancc\\Desktop\\PolSourceGrouping.xlsm";
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(1143, 185);
            this.richTextBoxStatus.TabIndex = 0;
            this.richTextBoxStatus.Text = "";
            // 
            // TestingPolSourceGrouping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 816);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestingPolSourceGrouping";
            this.Text = "Testing Pollution Source Grouping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFileLocation;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butCheckCircular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butPartialServiceResEN;
        private System.Windows.Forms.Button butPartialServiceResFR;
        private System.Windows.Forms.Button butLoadExcelSheet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button butShowReportText;
        private System.Windows.Forms.CheckBox checkBoxFR;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button butSeeFileNamesThatWillBeGenerated;
        private System.Windows.Forms.Button butGenerateAllCodeFiles;
    }
}

