namespace CSSPDesktop
{
    partial class CSSPDesktopForm
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
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.panelLanguageCenter = new System.Windows.Forms.Panel();
            this.butSetLanguageToFrancais = new System.Windows.Forms.Button();
            this.butSetLanguageToEnglish = new System.Windows.Forms.Button();
            this.splitContainerFirst = new System.Windows.Forms.SplitContainer();
            this.panelButtonCenter = new System.Windows.Forms.Panel();
            this.butStart = new System.Windows.Forms.Button();
            this.butShowHelpPanel = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.butShowLanguagePanel = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.butUpdatesAvailable = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSatusText = new System.Windows.Forms.Label();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.webBrowserHelp = new System.Windows.Forms.WebBrowser();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.panelHelpTop = new System.Windows.Forms.Panel();
            this.butHideHelpPanel = new System.Windows.Forms.Button();
            this.timerCheckInternetConnection = new System.Windows.Forms.Timer(this.components);
            this.panelUpdateCenter = new System.Windows.Forms.Panel();
            this.lblDownloading = new System.Windows.Forms.Label();
            this.lblInstalling = new System.Windows.Forms.Label();
            this.progressBarDownloading = new System.Windows.Forms.ProgressBar();
            this.progressBarInstalling = new System.Windows.Forms.ProgressBar();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butCancelUpdate = new System.Windows.Forms.Button();
            this.butUpdateCompleted = new System.Windows.Forms.Button();
            this.panelLanguage.SuspendLayout();
            this.panelLanguageCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).BeginInit();
            this.splitContainerFirst.Panel1.SuspendLayout();
            this.splitContainerFirst.Panel2.SuspendLayout();
            this.splitContainerFirst.SuspendLayout();
            this.panelButtonCenter.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelHelp.SuspendLayout();
            this.panelHelpTop.SuspendLayout();
            this.panelUpdateCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLanguage
            // 
            this.panelLanguage.Controls.Add(this.panelLanguageCenter);
            this.panelLanguage.Location = new System.Drawing.Point(706, 116);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(296, 161);
            this.panelLanguage.TabIndex = 0;
            // 
            // panelLanguageCenter
            // 
            this.panelLanguageCenter.Controls.Add(this.butSetLanguageToFrancais);
            this.panelLanguageCenter.Controls.Add(this.butSetLanguageToEnglish);
            this.panelLanguageCenter.Location = new System.Drawing.Point(14, 16);
            this.panelLanguageCenter.Name = "panelLanguageCenter";
            this.panelLanguageCenter.Size = new System.Drawing.Size(262, 104);
            this.panelLanguageCenter.TabIndex = 0;
            // 
            // butSetLanguageToFrancais
            // 
            this.butSetLanguageToFrancais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSetLanguageToFrancais.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.butSetLanguageToFrancais.Location = new System.Drawing.Point(146, 39);
            this.butSetLanguageToFrancais.Name = "butSetLanguageToFrancais";
            this.butSetLanguageToFrancais.Size = new System.Drawing.Size(98, 32);
            this.butSetLanguageToFrancais.TabIndex = 1;
            this.butSetLanguageToFrancais.Text = "Français";
            this.butSetLanguageToFrancais.UseVisualStyleBackColor = true;
            this.butSetLanguageToFrancais.Click += new System.EventHandler(this.butSetLanguageToFrancais_Click);
            // 
            // butSetLanguageToEnglish
            // 
            this.butSetLanguageToEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSetLanguageToEnglish.Location = new System.Drawing.Point(27, 39);
            this.butSetLanguageToEnglish.Name = "butSetLanguageToEnglish";
            this.butSetLanguageToEnglish.Size = new System.Drawing.Size(98, 32);
            this.butSetLanguageToEnglish.TabIndex = 0;
            this.butSetLanguageToEnglish.Text = "English";
            this.butSetLanguageToEnglish.UseVisualStyleBackColor = true;
            this.butSetLanguageToEnglish.Click += new System.EventHandler(this.butSetLanguageToEnglish_Click);
            // 
            // splitContainerFirst
            // 
            this.splitContainerFirst.Location = new System.Drawing.Point(15, 12);
            this.splitContainerFirst.Name = "splitContainerFirst";
            this.splitContainerFirst.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFirst.Panel1
            // 
            this.splitContainerFirst.Panel1.Controls.Add(this.panelUpdateCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelButtonCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelStatus);
            this.splitContainerFirst.Panel1.MouseHover += new System.EventHandler(this.splitContainerFirst_Panel1_MouseHover);
            // 
            // splitContainerFirst.Panel2
            // 
            this.splitContainerFirst.Panel2.Controls.Add(this.richTextBoxStatus);
            this.splitContainerFirst.Size = new System.Drawing.Size(685, 426);
            this.splitContainerFirst.SplitterDistance = 265;
            this.splitContainerFirst.TabIndex = 1;
            // 
            // panelButtonCenter
            // 
            this.panelButtonCenter.Controls.Add(this.butStart);
            this.panelButtonCenter.Controls.Add(this.butShowHelpPanel);
            this.panelButtonCenter.Controls.Add(this.butClose);
            this.panelButtonCenter.Controls.Add(this.butShowLanguagePanel);
            this.panelButtonCenter.Controls.Add(this.butStop);
            this.panelButtonCenter.Controls.Add(this.butUpdatesAvailable);
            this.panelButtonCenter.Location = new System.Drawing.Point(13, 17);
            this.panelButtonCenter.Name = "panelButtonCenter";
            this.panelButtonCenter.Size = new System.Drawing.Size(423, 182);
            this.panelButtonCenter.TabIndex = 7;
            this.panelButtonCenter.MouseHover += new System.EventHandler(this.panelButtonCenter_MouseHover);
            // 
            // butStart
            // 
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butStart.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butStart.Location = new System.Drawing.Point(16, 12);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(120, 33);
            this.butStart.TabIndex = 3;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            this.butStart.MouseHover += new System.EventHandler(this.butStart_MouseHover);
            // 
            // butShowHelpPanel
            // 
            this.butShowHelpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butShowHelpPanel.Location = new System.Drawing.Point(288, 51);
            this.butShowHelpPanel.Name = "butShowHelpPanel";
            this.butShowHelpPanel.Size = new System.Drawing.Size(122, 33);
            this.butShowHelpPanel.TabIndex = 2;
            this.butShowHelpPanel.Text = "Help";
            this.butShowHelpPanel.UseVisualStyleBackColor = true;
            this.butShowHelpPanel.Click += new System.EventHandler(this.butShowHelpPanel_Click);
            this.butShowHelpPanel.MouseHover += new System.EventHandler(this.butShowHelpPanel_MouseHover);
            // 
            // butClose
            // 
            this.butClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butClose.Location = new System.Drawing.Point(16, 140);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(120, 33);
            this.butClose.TabIndex = 6;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            this.butClose.MouseHover += new System.EventHandler(this.butClose_MouseHover);
            // 
            // butShowLanguagePanel
            // 
            this.butShowLanguagePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butShowLanguagePanel.Location = new System.Drawing.Point(288, 12);
            this.butShowLanguagePanel.Name = "butShowLanguagePanel";
            this.butShowLanguagePanel.Size = new System.Drawing.Size(122, 33);
            this.butShowLanguagePanel.TabIndex = 0;
            this.butShowLanguagePanel.Text = "Language";
            this.butShowLanguagePanel.UseVisualStyleBackColor = true;
            this.butShowLanguagePanel.Click += new System.EventHandler(this.butShowLanguagePanel_Click);
            this.butShowLanguagePanel.MouseHover += new System.EventHandler(this.butShowLanguagePanel_MouseHover);
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butStop.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butStop.Location = new System.Drawing.Point(16, 60);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(120, 33);
            this.butStop.TabIndex = 4;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            this.butStop.MouseHover += new System.EventHandler(this.butStop_MouseHover);
            // 
            // butUpdatesAvailable
            // 
            this.butUpdatesAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUpdatesAvailable.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUpdatesAvailable.Location = new System.Drawing.Point(184, 140);
            this.butUpdatesAvailable.Name = "butUpdatesAvailable";
            this.butUpdatesAvailable.Size = new System.Drawing.Size(226, 33);
            this.butUpdatesAvailable.TabIndex = 5;
            this.butUpdatesAvailable.Text = "Updates Available";
            this.butUpdatesAvailable.UseVisualStyleBackColor = true;
            this.butUpdatesAvailable.Click += new System.EventHandler(this.butUpdatesAvailable_Click);
            this.butUpdatesAvailable.MouseHover += new System.EventHandler(this.butUpdatesAvailable_MouseHover);
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Controls.Add(this.lblSatusText);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 229);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(685, 36);
            this.panelStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(69, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "[empty]";
            // 
            // lblSatusText
            // 
            this.lblSatusText.AutoSize = true;
            this.lblSatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatusText.Location = new System.Drawing.Point(9, 9);
            this.lblSatusText.Name = "lblSatusText";
            this.lblSatusText.Size = new System.Drawing.Size(55, 20);
            this.lblSatusText.TabIndex = 0;
            this.lblSatusText.Text = "Satus:";
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxStatus.Location = new System.Drawing.Point(118, 13);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(90, 80);
            this.richTextBoxStatus.TabIndex = 1;
            this.richTextBoxStatus.Text = "";
            // 
            // webBrowserHelp
            // 
            this.webBrowserHelp.Location = new System.Drawing.Point(45, 42);
            this.webBrowserHelp.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserHelp.Name = "webBrowserHelp";
            this.webBrowserHelp.Size = new System.Drawing.Size(145, 70);
            this.webBrowserHelp.TabIndex = 0;
            // 
            // panelHelp
            // 
            this.panelHelp.Controls.Add(this.webBrowserHelp);
            this.panelHelp.Controls.Add(this.panelHelpTop);
            this.panelHelp.Location = new System.Drawing.Point(726, 298);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(276, 140);
            this.panelHelp.TabIndex = 2;
            // 
            // panelHelpTop
            // 
            this.panelHelpTop.Controls.Add(this.butHideHelpPanel);
            this.panelHelpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHelpTop.Location = new System.Drawing.Point(0, 0);
            this.panelHelpTop.Name = "panelHelpTop";
            this.panelHelpTop.Size = new System.Drawing.Size(276, 36);
            this.panelHelpTop.TabIndex = 1;
            // 
            // butHideHelpPanel
            // 
            this.butHideHelpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHideHelpPanel.Location = new System.Drawing.Point(104, 2);
            this.butHideHelpPanel.Name = "butHideHelpPanel";
            this.butHideHelpPanel.Size = new System.Drawing.Size(98, 32);
            this.butHideHelpPanel.TabIndex = 1;
            this.butHideHelpPanel.Text = "Close Help";
            this.butHideHelpPanel.UseVisualStyleBackColor = true;
            this.butHideHelpPanel.Click += new System.EventHandler(this.butHideHelpPanel_Click);
            // 
            // timerCheckInternetConnection
            // 
            this.timerCheckInternetConnection.Enabled = true;
            this.timerCheckInternetConnection.Interval = 5000;
            this.timerCheckInternetConnection.Tick += new System.EventHandler(this.timerCheckInternetConnection_Tick);
            // 
            // panelUpdateCenter
            // 
            this.panelUpdateCenter.Controls.Add(this.butCancelUpdate);
            this.panelUpdateCenter.Controls.Add(this.butUpdate);
            this.panelUpdateCenter.Controls.Add(this.progressBarInstalling);
            this.panelUpdateCenter.Controls.Add(this.progressBarDownloading);
            this.panelUpdateCenter.Controls.Add(this.lblInstalling);
            this.panelUpdateCenter.Controls.Add(this.lblDownloading);
            this.panelUpdateCenter.Controls.Add(this.butUpdateCompleted);
            this.panelUpdateCenter.Location = new System.Drawing.Point(326, 21);
            this.panelUpdateCenter.Name = "panelUpdateCenter";
            this.panelUpdateCenter.Size = new System.Drawing.Size(504, 170);
            this.panelUpdateCenter.TabIndex = 8;
            this.panelUpdateCenter.MouseHover += new System.EventHandler(this.panelUpdateCenter_MouseHover);
            // 
            // lblDownloading
            // 
            this.lblDownloading.AutoSize = true;
            this.lblDownloading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloading.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblDownloading.Location = new System.Drawing.Point(61, 64);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(105, 20);
            this.lblDownloading.TabIndex = 1;
            this.lblDownloading.Text = "Downloading:";
            // 
            // lblInstalling
            // 
            this.lblInstalling.AutoSize = true;
            this.lblInstalling.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstalling.Location = new System.Drawing.Point(61, 119);
            this.lblInstalling.Name = "lblInstalling";
            this.lblInstalling.Size = new System.Drawing.Size(76, 20);
            this.lblInstalling.TabIndex = 2;
            this.lblInstalling.Text = "Installing:";
            // 
            // progressBarDownloading
            // 
            this.progressBarDownloading.Location = new System.Drawing.Point(65, 88);
            this.progressBarDownloading.Name = "progressBarDownloading";
            this.progressBarDownloading.Size = new System.Drawing.Size(397, 12);
            this.progressBarDownloading.TabIndex = 3;
            // 
            // progressBarInstalling
            // 
            this.progressBarInstalling.Location = new System.Drawing.Point(65, 142);
            this.progressBarInstalling.Name = "progressBarInstalling";
            this.progressBarInstalling.Size = new System.Drawing.Size(397, 12);
            this.progressBarInstalling.TabIndex = 4;
            // 
            // butUpdate
            // 
            this.butUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUpdate.Location = new System.Drawing.Point(88, 15);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(169, 33);
            this.butUpdate.TabIndex = 5;
            this.butUpdate.Text = "Update";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            this.butUpdate.MouseHover += new System.EventHandler(this.butUpdate_MouseHover);
            // 
            // butCancelUpdate
            // 
            this.butCancelUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butCancelUpdate.Location = new System.Drawing.Point(283, 15);
            this.butCancelUpdate.Name = "butCancelUpdate";
            this.butCancelUpdate.Size = new System.Drawing.Size(169, 33);
            this.butCancelUpdate.TabIndex = 6;
            this.butCancelUpdate.Text = "Cancel";
            this.butCancelUpdate.UseVisualStyleBackColor = true;
            this.butCancelUpdate.Click += new System.EventHandler(this.butCancelUpdate_Click);
            this.butCancelUpdate.MouseHover += new System.EventHandler(this.butCancelUpdate_MouseHover);
            // 
            // butUpdateCompleted
            // 
            this.butUpdateCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUpdateCompleted.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUpdateCompleted.Location = new System.Drawing.Point(161, 16);
            this.butUpdateCompleted.Name = "butUpdateCompleted";
            this.butUpdateCompleted.Size = new System.Drawing.Size(233, 33);
            this.butUpdateCompleted.TabIndex = 7;
            this.butUpdateCompleted.Text = "Update Completed";
            this.butUpdateCompleted.UseVisualStyleBackColor = true;
            this.butUpdateCompleted.Click += new System.EventHandler(this.butUpdateCompleted_Click);
            this.butUpdateCompleted.MouseHover += new System.EventHandler(this.butUpdateCompleted_MouseHover);
            // 
            // CSSPDesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelHelp);
            this.Controls.Add(this.splitContainerFirst);
            this.Controls.Add(this.panelLanguage);
            this.Name = "CSSPDesktopForm";
            this.Text = "CSSP Desktop";
            this.Resize += new System.EventHandler(this.CSSPDesktopForm_Resize);
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguageCenter.ResumeLayout(false);
            this.splitContainerFirst.Panel1.ResumeLayout(false);
            this.splitContainerFirst.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).EndInit();
            this.splitContainerFirst.ResumeLayout(false);
            this.panelButtonCenter.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelHelp.ResumeLayout(false);
            this.panelHelpTop.ResumeLayout(false);
            this.panelUpdateCenter.ResumeLayout(false);
            this.panelUpdateCenter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.Panel panelLanguageCenter;
        private System.Windows.Forms.Button butSetLanguageToEnglish;
        private System.Windows.Forms.Button butSetLanguageToFrancais;
        private System.Windows.Forms.SplitContainer splitContainerFirst;
        private System.Windows.Forms.Button butShowLanguagePanel;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.WebBrowser webBrowserHelp;
        private System.Windows.Forms.Panel panelButtonCenter;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butShowHelpPanel;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butUpdatesAvailable;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSatusText;
        private System.Windows.Forms.Panel panelHelp;
        private System.Windows.Forms.Panel panelHelpTop;
        private System.Windows.Forms.Button butHideHelpPanel;
        private System.Windows.Forms.Timer timerCheckInternetConnection;
        private System.Windows.Forms.Panel panelUpdateCenter;
        private System.Windows.Forms.Button butCancelUpdate;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.ProgressBar progressBarInstalling;
        private System.Windows.Forms.ProgressBar progressBarDownloading;
        private System.Windows.Forms.Label lblInstalling;
        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.Button butUpdateCompleted;
    }
}

