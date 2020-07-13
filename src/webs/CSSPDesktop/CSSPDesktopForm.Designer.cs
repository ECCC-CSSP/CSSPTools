namespace CSSPDesktop
{
    partial class CSSPDesktopForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butStartCSSPWebTools = new System.Windows.Forms.Button();
            this.butUpdatesAvailable = new System.Windows.Forms.Button();
            this.radioButtonEN = new System.Windows.Forms.RadioButton();
            this.radioButtonFR = new System.Windows.Forms.RadioButton();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblNoInternetConnection = new System.Windows.Forms.Label();
            this.butCloseEverything = new System.Windows.Forms.Button();
            this.butStopCSSPWebTools = new System.Windows.Forms.Button();
            this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
            this.lblLanguageText = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // butStartCSSPWebTools
            // 
            this.butStartCSSPWebTools.Location = new System.Drawing.Point(12, 83);
            this.butStartCSSPWebTools.Name = "butStartCSSPWebTools";
            this.butStartCSSPWebTools.Size = new System.Drawing.Size(178, 34);
            this.butStartCSSPWebTools.TabIndex = 2;
            this.butStartCSSPWebTools.Text = "Start CSSP Web Tools";
            this.butStartCSSPWebTools.UseVisualStyleBackColor = true;
            this.butStartCSSPWebTools.Click += new System.EventHandler(this.butStartCSSPWebTools_Click);
            // 
            // butUpdatesAvailable
            // 
            this.butUpdatesAvailable.Location = new System.Drawing.Point(12, 308);
            this.butUpdatesAvailable.Name = "butUpdatesAvailable";
            this.butUpdatesAvailable.Size = new System.Drawing.Size(178, 34);
            this.butUpdatesAvailable.TabIndex = 2;
            this.butUpdatesAvailable.Text = "Updates Available";
            this.butUpdatesAvailable.UseVisualStyleBackColor = true;
            this.butUpdatesAvailable.Visible = false;
            // 
            // radioButtonEN
            // 
            this.radioButtonEN.AutoSize = true;
            this.radioButtonEN.Checked = true;
            this.radioButtonEN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonEN.Location = new System.Drawing.Point(91, 12);
            this.radioButtonEN.Name = "radioButtonEN";
            this.radioButtonEN.Size = new System.Drawing.Size(48, 25);
            this.radioButtonEN.TabIndex = 5;
            this.radioButtonEN.TabStop = true;
            this.radioButtonEN.Text = "EN";
            this.radioButtonEN.UseVisualStyleBackColor = true;
            this.radioButtonEN.Click += new System.EventHandler(this.LanguageSelect_Click);
            // 
            // radioButtonFR
            // 
            this.radioButtonFR.AutoSize = true;
            this.radioButtonFR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonFR.Location = new System.Drawing.Point(144, 12);
            this.radioButtonFR.Name = "radioButtonFR";
            this.radioButtonFR.Size = new System.Drawing.Size(46, 25);
            this.radioButtonFR.TabIndex = 5;
            this.radioButtonFR.Text = "FR";
            this.radioButtonFR.UseVisualStyleBackColor = true;
            this.radioButtonFR.Click += new System.EventHandler(this.LanguageSelect_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblNoInternetConnection);
            this.panelLeft.Controls.Add(this.butCloseEverything);
            this.panelLeft.Controls.Add(this.butStopCSSPWebTools);
            this.panelLeft.Controls.Add(this.linkLabelHelp);
            this.panelLeft.Controls.Add(this.lblLanguageText);
            this.panelLeft.Controls.Add(this.radioButtonEN);
            this.panelLeft.Controls.Add(this.radioButtonFR);
            this.panelLeft.Controls.Add(this.butUpdatesAvailable);
            this.panelLeft.Controls.Add(this.butStartCSSPWebTools);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(201, 551);
            this.panelLeft.TabIndex = 6;
            // 
            // lblNoInternetConnection
            // 
            this.lblNoInternetConnection.AutoSize = true;
            this.lblNoInternetConnection.Location = new System.Drawing.Point(12, 284);
            this.lblNoInternetConnection.Name = "lblNoInternetConnection";
            this.lblNoInternetConnection.Size = new System.Drawing.Size(172, 21);
            this.lblNoInternetConnection.TabIndex = 8;
            this.lblNoInternetConnection.Text = "No Internet Connection";
            this.lblNoInternetConnection.Visible = false;
            // 
            // butCloseEverything
            // 
            this.butCloseEverything.Location = new System.Drawing.Point(12, 505);
            this.butCloseEverything.Name = "butCloseEverything";
            this.butCloseEverything.Size = new System.Drawing.Size(178, 34);
            this.butCloseEverything.TabIndex = 2;
            this.butCloseEverything.Text = "Close Everything";
            this.butCloseEverything.UseVisualStyleBackColor = true;
            this.butCloseEverything.Click += new System.EventHandler(this.butCloseEverything_Click);
            // 
            // butStopCSSPWebTools
            // 
            this.butStopCSSPWebTools.Location = new System.Drawing.Point(12, 123);
            this.butStopCSSPWebTools.Name = "butStopCSSPWebTools";
            this.butStopCSSPWebTools.Size = new System.Drawing.Size(178, 34);
            this.butStopCSSPWebTools.TabIndex = 2;
            this.butStopCSSPWebTools.Text = "Stop CSSP Web Tools";
            this.butStopCSSPWebTools.UseVisualStyleBackColor = true;
            this.butStopCSSPWebTools.Visible = false;
            this.butStopCSSPWebTools.Click += new System.EventHandler(this.butStopCSSPWebTools_Click);
            // 
            // linkLabelHelp
            // 
            this.linkLabelHelp.AutoSize = true;
            this.linkLabelHelp.Location = new System.Drawing.Point(71, 50);
            this.linkLabelHelp.Name = "linkLabelHelp";
            this.linkLabelHelp.Size = new System.Drawing.Size(42, 21);
            this.linkLabelHelp.TabIndex = 7;
            this.linkLabelHelp.TabStop = true;
            this.linkLabelHelp.Text = "Help";
            this.linkLabelHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelp_LinkClicked);
            // 
            // lblLanguageText
            // 
            this.lblLanguageText.AutoSize = true;
            this.lblLanguageText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLanguageText.Location = new System.Drawing.Point(4, 12);
            this.lblLanguageText.Name = "lblLanguageText";
            this.lblLanguageText.Size = new System.Drawing.Size(81, 21);
            this.lblLanguageText.TabIndex = 6;
            this.lblLanguageText.Text = "Language:";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.richTextBoxStatus);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(201, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(899, 551);
            this.panelRight.TabIndex = 7;
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(48, 23);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(565, 427);
            this.richTextBoxStatus.TabIndex = 0;
            this.richTextBoxStatus.Text = "";
            // 
            // CSSPDesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 551);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "CSSPDesktopForm";
            this.Text = "CSSP Desktop Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CSSPDesktopForm_FormClosing);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butStartCSSPWebTools;
        private System.Windows.Forms.Button butUpdatesAvailable;
        private System.Windows.Forms.RadioButton radioButtonEN;
        private System.Windows.Forms.RadioButton radioButtonFR;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblLanguageText;
        private System.Windows.Forms.LinkLabel linkLabelHelp;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Button butStopCSSPWebTools;
        private System.Windows.Forms.Button butCloseEverything;
        private System.Windows.Forms.Label lblNoInternetConnection;
    }
}

