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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblNoInternetConnection = new System.Windows.Forms.Label();
            this.butCloseEverything = new System.Windows.Forms.Button();
            this.butStopCSSPWebTools = new System.Windows.Forms.Button();
            this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.panelLanguageCenter = new System.Windows.Forms.Panel();
            this.butEnglish = new System.Windows.Forms.Button();
            this.butFrancais = new System.Windows.Forms.Button();
            this.linkLabelLanguage = new System.Windows.Forms.LinkLabel();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLanguage.SuspendLayout();
            this.panelLanguageCenter.SuspendLayout();
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
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.linkLabelLanguage);
            this.panelLeft.Controls.Add(this.lblNoInternetConnection);
            this.panelLeft.Controls.Add(this.butCloseEverything);
            this.panelLeft.Controls.Add(this.butStopCSSPWebTools);
            this.panelLeft.Controls.Add(this.linkLabelHelp);
            this.panelLeft.Controls.Add(this.butUpdatesAvailable);
            this.panelLeft.Controls.Add(this.butStartCSSPWebTools);
            this.panelLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelLeft.Location = new System.Drawing.Point(18, 5);
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
            this.linkLabelHelp.Location = new System.Drawing.Point(142, 12);
            this.linkLabelHelp.Name = "linkLabelHelp";
            this.linkLabelHelp.Size = new System.Drawing.Size(42, 21);
            this.linkLabelHelp.TabIndex = 7;
            this.linkLabelHelp.TabStop = true;
            this.linkLabelHelp.Text = "Help";
            this.linkLabelHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelp_LinkClicked);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.richTextBoxStatus);
            this.panelRight.Location = new System.Drawing.Point(635, 296);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(433, 209);
            this.panelRight.TabIndex = 7;
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(48, 23);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(239, 183);
            this.richTextBoxStatus.TabIndex = 0;
            this.richTextBoxStatus.Text = "";
            // 
            // panelLanguage
            // 
            this.panelLanguage.Controls.Add(this.panelLanguageCenter);
            this.panelLanguage.Location = new System.Drawing.Point(289, 57);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(357, 207);
            this.panelLanguage.TabIndex = 8;
            // 
            // panelLanguageCenter
            // 
            this.panelLanguageCenter.Controls.Add(this.butEnglish);
            this.panelLanguageCenter.Controls.Add(this.butFrancais);
            this.panelLanguageCenter.Location = new System.Drawing.Point(45, 57);
            this.panelLanguageCenter.Name = "panelLanguageCenter";
            this.panelLanguageCenter.Size = new System.Drawing.Size(246, 88);
            this.panelLanguageCenter.TabIndex = 1;
            // 
            // butEnglish
            // 
            this.butEnglish.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butEnglish.Location = new System.Drawing.Point(19, 25);
            this.butEnglish.Name = "butEnglish";
            this.butEnglish.Size = new System.Drawing.Size(88, 35);
            this.butEnglish.TabIndex = 0;
            this.butEnglish.Text = "English";
            this.butEnglish.UseVisualStyleBackColor = true;
            this.butEnglish.Click += new System.EventHandler(this.butEnglish_Click);
            // 
            // butFrancais
            // 
            this.butFrancais.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butFrancais.Location = new System.Drawing.Point(139, 25);
            this.butFrancais.Name = "butFrancais";
            this.butFrancais.Size = new System.Drawing.Size(89, 35);
            this.butFrancais.TabIndex = 0;
            this.butFrancais.Text = "Français";
            this.butFrancais.UseVisualStyleBackColor = true;
            this.butFrancais.Click += new System.EventHandler(this.butFrancais_Click);
            // 
            // linkLabelLanguage
            // 
            this.linkLabelLanguage.AutoSize = true;
            this.linkLabelLanguage.Location = new System.Drawing.Point(12, 12);
            this.linkLabelLanguage.Name = "linkLabelLanguage";
            this.linkLabelLanguage.Size = new System.Drawing.Size(78, 21);
            this.linkLabelLanguage.TabIndex = 7;
            this.linkLabelLanguage.TabStop = true;
            this.linkLabelLanguage.Text = "Language";
            this.linkLabelLanguage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLanguage_LinkClicked);
            // 
            // CSSPDesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 551);
            this.Controls.Add(this.panelLanguage);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "CSSPDesktopForm";
            this.Text = "CSSP Desktop Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CSSPDesktopForm_FormClosing);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguageCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butStartCSSPWebTools;
        private System.Windows.Forms.Button butUpdatesAvailable;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.LinkLabel linkLabelHelp;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Button butStopCSSPWebTools;
        private System.Windows.Forms.Button butCloseEverything;
        private System.Windows.Forms.Label lblNoInternetConnection;
        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.Panel panelLanguageCenter;
        private System.Windows.Forms.Button butEnglish;
        private System.Windows.Forms.Button butFrancais;
        private System.Windows.Forms.LinkLabel linkLabelLanguage;
    }
}

