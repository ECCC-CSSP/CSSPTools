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
            this.panelLanguageCenter = new System.Windows.Forms.Panel();
            this.butSetLanguageToFrancais = new System.Windows.Forms.Button();
            this.butSetLanguageToEnglish = new System.Windows.Forms.Button();
            this.splitContainerFirst = new System.Windows.Forms.SplitContainer();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.richTextBoxHelp = new System.Windows.Forms.RichTextBox();
            this.panelHelpTop = new System.Windows.Forms.Panel();
            this.butHideHelpPanel = new System.Windows.Forms.Button();
            this.panelLoginCenter = new System.Windows.Forms.Panel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLoginEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLoginEmail = new System.Windows.Forms.Label();
            this.lblCSSPWebToolsLoginOneTime = new System.Windows.Forms.Label();
            this.butLogin = new System.Windows.Forms.Button();
            this.panelUpdateCenter = new System.Windows.Forms.Panel();
            this.butCancelUpdate = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.progressBarInstalling = new System.Windows.Forms.ProgressBar();
            this.lblInstalling = new System.Windows.Forms.Label();
            this.butUpdateCompleted = new System.Windows.Forms.Button();
            this.panelCommandsCenter = new System.Windows.Forms.Panel();
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
            this.timerCheckInternetConnection = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelLanguageCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).BeginInit();
            this.splitContainerFirst.Panel1.SuspendLayout();
            this.splitContainerFirst.Panel2.SuspendLayout();
            this.splitContainerFirst.SuspendLayout();
            this.panelHelp.SuspendLayout();
            this.panelHelpTop.SuspendLayout();
            this.panelLoginCenter.SuspendLayout();
            this.panelUpdateCenter.SuspendLayout();
            this.panelCommandsCenter.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLanguageCenter
            // 
            this.panelLanguageCenter.Controls.Add(this.butSetLanguageToFrancais);
            this.panelLanguageCenter.Controls.Add(this.butSetLanguageToEnglish);
            this.panelLanguageCenter.Location = new System.Drawing.Point(556, 237);
            this.panelLanguageCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelLanguageCenter.Name = "panelLanguageCenter";
            this.panelLanguageCenter.Size = new System.Drawing.Size(306, 120);
            this.panelLanguageCenter.TabIndex = 0;
            // 
            // butSetLanguageToFrancais
            // 
            this.butSetLanguageToFrancais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butSetLanguageToFrancais.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.butSetLanguageToFrancais.Location = new System.Drawing.Point(170, 45);
            this.butSetLanguageToFrancais.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butSetLanguageToFrancais.Name = "butSetLanguageToFrancais";
            this.butSetLanguageToFrancais.Size = new System.Drawing.Size(114, 37);
            this.butSetLanguageToFrancais.TabIndex = 1;
            this.butSetLanguageToFrancais.Text = "Français";
            this.butSetLanguageToFrancais.UseVisualStyleBackColor = true;
            this.butSetLanguageToFrancais.Click += new System.EventHandler(this.butSetLanguageToFrancais_Click);
            // 
            // butSetLanguageToEnglish
            // 
            this.butSetLanguageToEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butSetLanguageToEnglish.Location = new System.Drawing.Point(31, 45);
            this.butSetLanguageToEnglish.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butSetLanguageToEnglish.Name = "butSetLanguageToEnglish";
            this.butSetLanguageToEnglish.Size = new System.Drawing.Size(114, 37);
            this.butSetLanguageToEnglish.TabIndex = 0;
            this.butSetLanguageToEnglish.Text = "English";
            this.butSetLanguageToEnglish.UseVisualStyleBackColor = true;
            this.butSetLanguageToEnglish.Click += new System.EventHandler(this.butSetLanguageToEnglish_Click);
            // 
            // splitContainerFirst
            // 
            this.splitContainerFirst.Location = new System.Drawing.Point(18, 14);
            this.splitContainerFirst.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainerFirst.Name = "splitContainerFirst";
            this.splitContainerFirst.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFirst.Panel1
            // 
            this.splitContainerFirst.Panel1.Controls.Add(this.panelLanguageCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelHelp);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelLoginCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelUpdateCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelCommandsCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelStatus);
            this.splitContainerFirst.Panel1.MouseHover += new System.EventHandler(this.splitContainerFirst_Panel1_MouseHover);
            // 
            // splitContainerFirst.Panel2
            // 
            this.splitContainerFirst.Panel2.Controls.Add(this.richTextBoxStatus);
            this.splitContainerFirst.Size = new System.Drawing.Size(1148, 770);
            this.splitContainerFirst.SplitterDistance = 659;
            this.splitContainerFirst.SplitterWidth = 5;
            this.splitContainerFirst.TabIndex = 1;
            // 
            // panelHelp
            // 
            this.panelHelp.Controls.Add(this.richTextBoxHelp);
            this.panelHelp.Controls.Add(this.panelHelpTop);
            this.panelHelp.Location = new System.Drawing.Point(766, 433);
            this.panelHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(322, 162);
            this.panelHelp.TabIndex = 2;
            // 
            // richTextBoxHelp
            // 
            this.richTextBoxHelp.Location = new System.Drawing.Point(62, 52);
            this.richTextBoxHelp.Name = "richTextBoxHelp";
            this.richTextBoxHelp.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxHelp.TabIndex = 2;
            this.richTextBoxHelp.Text = "";
            // 
            // panelHelpTop
            // 
            this.panelHelpTop.Controls.Add(this.butHideHelpPanel);
            this.panelHelpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHelpTop.Location = new System.Drawing.Point(0, 0);
            this.panelHelpTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelHelpTop.Name = "panelHelpTop";
            this.panelHelpTop.Size = new System.Drawing.Size(322, 42);
            this.panelHelpTop.TabIndex = 1;
            // 
            // butHideHelpPanel
            // 
            this.butHideHelpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butHideHelpPanel.Location = new System.Drawing.Point(121, 2);
            this.butHideHelpPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butHideHelpPanel.Name = "butHideHelpPanel";
            this.butHideHelpPanel.Size = new System.Drawing.Size(114, 37);
            this.butHideHelpPanel.TabIndex = 1;
            this.butHideHelpPanel.Text = "Close Help";
            this.butHideHelpPanel.UseVisualStyleBackColor = true;
            this.butHideHelpPanel.Click += new System.EventHandler(this.butHideHelpPanel_Click);
            // 
            // panelLoginCenter
            // 
            this.panelLoginCenter.Controls.Add(this.textBoxPassword);
            this.panelLoginCenter.Controls.Add(this.textBoxLoginEmail);
            this.panelLoginCenter.Controls.Add(this.lblPassword);
            this.panelLoginCenter.Controls.Add(this.lblLoginEmail);
            this.panelLoginCenter.Controls.Add(this.lblCSSPWebToolsLoginOneTime);
            this.panelLoginCenter.Controls.Add(this.butLogin);
            this.panelLoginCenter.Location = new System.Drawing.Point(24, 256);
            this.panelLoginCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelLoginCenter.Name = "panelLoginCenter";
            this.panelLoginCenter.Size = new System.Drawing.Size(484, 284);
            this.panelLoginCenter.TabIndex = 9;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(59, 177);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(311, 26);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.MouseHover += new System.EventHandler(this.textBoxPassword_MouseHover);
            // 
            // textBoxLoginEmail
            // 
            this.textBoxLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLoginEmail.Location = new System.Drawing.Point(59, 104);
            this.textBoxLoginEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxLoginEmail.Name = "textBoxLoginEmail";
            this.textBoxLoginEmail.Size = new System.Drawing.Size(311, 26);
            this.textBoxLoginEmail.TabIndex = 7;
            this.textBoxLoginEmail.MouseHover += new System.EventHandler(this.textBoxLoginEmail_MouseHover);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(55, 150);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 20);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // lblLoginEmail
            // 
            this.lblLoginEmail.AutoSize = true;
            this.lblLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoginEmail.Location = new System.Drawing.Point(55, 77);
            this.lblLoginEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoginEmail.Name = "lblLoginEmail";
            this.lblLoginEmail.Size = new System.Drawing.Size(95, 20);
            this.lblLoginEmail.TabIndex = 5;
            this.lblLoginEmail.Text = "Login Email:";
            // 
            // lblCSSPWebToolsLoginOneTime
            // 
            this.lblCSSPWebToolsLoginOneTime.AutoSize = true;
            this.lblCSSPWebToolsLoginOneTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCSSPWebToolsLoginOneTime.Location = new System.Drawing.Point(44, 23);
            this.lblCSSPWebToolsLoginOneTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCSSPWebToolsLoginOneTime.Name = "lblCSSPWebToolsLoginOneTime";
            this.lblCSSPWebToolsLoginOneTime.Size = new System.Drawing.Size(292, 20);
            this.lblCSSPWebToolsLoginOneTime.TabIndex = 4;
            this.lblCSSPWebToolsLoginOneTime.Text = "CSSP Web Tools Login (one time thing) ";
            // 
            // butLogin
            // 
            this.butLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butLogin.Location = new System.Drawing.Point(238, 219);
            this.butLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(206, 38);
            this.butLogin.TabIndex = 3;
            this.butLogin.Text = "Login";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            this.butLogin.MouseHover += new System.EventHandler(this.butLogin_MouseHover);
            // 
            // panelUpdateCenter
            // 
            this.panelUpdateCenter.Controls.Add(this.butCancelUpdate);
            this.panelUpdateCenter.Controls.Add(this.butUpdate);
            this.panelUpdateCenter.Controls.Add(this.progressBarInstalling);
            this.panelUpdateCenter.Controls.Add(this.lblInstalling);
            this.panelUpdateCenter.Controls.Add(this.butUpdateCompleted);
            this.panelUpdateCenter.Location = new System.Drawing.Point(544, 33);
            this.panelUpdateCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelUpdateCenter.Name = "panelUpdateCenter";
            this.panelUpdateCenter.Size = new System.Drawing.Size(588, 163);
            this.panelUpdateCenter.TabIndex = 8;
            this.panelUpdateCenter.MouseHover += new System.EventHandler(this.panelUpdateCenter_MouseHover);
            // 
            // butCancelUpdate
            // 
            this.butCancelUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butCancelUpdate.Location = new System.Drawing.Point(330, 17);
            this.butCancelUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butCancelUpdate.Name = "butCancelUpdate";
            this.butCancelUpdate.Size = new System.Drawing.Size(197, 38);
            this.butCancelUpdate.TabIndex = 6;
            this.butCancelUpdate.Text = "Cancel";
            this.butCancelUpdate.UseVisualStyleBackColor = true;
            this.butCancelUpdate.Click += new System.EventHandler(this.butCancelUpdate_Click);
            this.butCancelUpdate.MouseHover += new System.EventHandler(this.butCancelUpdate_MouseHover);
            // 
            // butUpdate
            // 
            this.butUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUpdate.Location = new System.Drawing.Point(103, 17);
            this.butUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(197, 38);
            this.butUpdate.TabIndex = 5;
            this.butUpdate.Text = "Update";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            this.butUpdate.MouseHover += new System.EventHandler(this.butUpdate_MouseHover);
            // 
            // progressBarInstalling
            // 
            this.progressBarInstalling.Location = new System.Drawing.Point(82, 114);
            this.progressBarInstalling.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarInstalling.Name = "progressBarInstalling";
            this.progressBarInstalling.Size = new System.Drawing.Size(463, 14);
            this.progressBarInstalling.TabIndex = 4;
            // 
            // lblInstalling
            // 
            this.lblInstalling.AutoSize = true;
            this.lblInstalling.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInstalling.Location = new System.Drawing.Point(77, 88);
            this.lblInstalling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstalling.Name = "lblInstalling";
            this.lblInstalling.Size = new System.Drawing.Size(76, 20);
            this.lblInstalling.TabIndex = 2;
            this.lblInstalling.Text = "Installing:";
            // 
            // butUpdateCompleted
            // 
            this.butUpdateCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butUpdateCompleted.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUpdateCompleted.Location = new System.Drawing.Point(188, 18);
            this.butUpdateCompleted.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butUpdateCompleted.Name = "butUpdateCompleted";
            this.butUpdateCompleted.Size = new System.Drawing.Size(272, 38);
            this.butUpdateCompleted.TabIndex = 7;
            this.butUpdateCompleted.Text = "Update Completed";
            this.butUpdateCompleted.UseVisualStyleBackColor = true;
            this.butUpdateCompleted.Click += new System.EventHandler(this.butUpdateCompleted_Click);
            this.butUpdateCompleted.MouseHover += new System.EventHandler(this.butUpdateCompleted_MouseHover);
            // 
            // panelCommandsCenter
            // 
            this.panelCommandsCenter.Controls.Add(this.button1);
            this.panelCommandsCenter.Controls.Add(this.butStart);
            this.panelCommandsCenter.Controls.Add(this.butShowHelpPanel);
            this.panelCommandsCenter.Controls.Add(this.butClose);
            this.panelCommandsCenter.Controls.Add(this.butShowLanguagePanel);
            this.panelCommandsCenter.Controls.Add(this.butStop);
            this.panelCommandsCenter.Controls.Add(this.butUpdatesAvailable);
            this.panelCommandsCenter.Location = new System.Drawing.Point(15, 20);
            this.panelCommandsCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelCommandsCenter.Name = "panelCommandsCenter";
            this.panelCommandsCenter.Size = new System.Drawing.Size(493, 210);
            this.panelCommandsCenter.TabIndex = 7;
            this.panelCommandsCenter.MouseHover += new System.EventHandler(this.panelCommandsCenter_MouseHover);
            // 
            // butStart
            // 
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butStart.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butStart.Location = new System.Drawing.Point(19, 14);
            this.butStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(140, 38);
            this.butStart.TabIndex = 3;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            this.butStart.MouseHover += new System.EventHandler(this.butStart_MouseHover);
            // 
            // butShowHelpPanel
            // 
            this.butShowHelpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butShowHelpPanel.Location = new System.Drawing.Point(336, 59);
            this.butShowHelpPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butShowHelpPanel.Name = "butShowHelpPanel";
            this.butShowHelpPanel.Size = new System.Drawing.Size(142, 38);
            this.butShowHelpPanel.TabIndex = 2;
            this.butShowHelpPanel.Text = "Help";
            this.butShowHelpPanel.UseVisualStyleBackColor = true;
            this.butShowHelpPanel.Click += new System.EventHandler(this.butShowHelpPanel_Click);
            this.butShowHelpPanel.MouseHover += new System.EventHandler(this.butShowHelpPanel_MouseHover);
            // 
            // butClose
            // 
            this.butClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.butClose.Location = new System.Drawing.Point(19, 162);
            this.butClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(140, 38);
            this.butClose.TabIndex = 6;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            this.butClose.MouseHover += new System.EventHandler(this.butClose_MouseHover);
            // 
            // butShowLanguagePanel
            // 
            this.butShowLanguagePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butShowLanguagePanel.Location = new System.Drawing.Point(336, 14);
            this.butShowLanguagePanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butShowLanguagePanel.Name = "butShowLanguagePanel";
            this.butShowLanguagePanel.Size = new System.Drawing.Size(142, 38);
            this.butShowLanguagePanel.TabIndex = 0;
            this.butShowLanguagePanel.Text = "Language";
            this.butShowLanguagePanel.UseVisualStyleBackColor = true;
            this.butShowLanguagePanel.Click += new System.EventHandler(this.butShowLanguagePanel_Click);
            this.butShowLanguagePanel.MouseHover += new System.EventHandler(this.butShowLanguagePanel_MouseHover);
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butStop.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butStop.Location = new System.Drawing.Point(19, 69);
            this.butStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(140, 38);
            this.butStop.TabIndex = 4;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            this.butStop.MouseHover += new System.EventHandler(this.butStop_MouseHover);
            // 
            // butUpdatesAvailable
            // 
            this.butUpdatesAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butUpdatesAvailable.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUpdatesAvailable.Location = new System.Drawing.Point(215, 162);
            this.butUpdatesAvailable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butUpdatesAvailable.Name = "butUpdatesAvailable";
            this.butUpdatesAvailable.Size = new System.Drawing.Size(264, 38);
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
            this.panelStatus.Location = new System.Drawing.Point(0, 617);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1148, 42);
            this.panelStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(80, 9);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "[empty]";
            // 
            // lblSatusText
            // 
            this.lblSatusText.AutoSize = true;
            this.lblSatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSatusText.Location = new System.Drawing.Point(10, 10);
            this.lblSatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSatusText.Name = "lblSatusText";
            this.lblSatusText.Size = new System.Drawing.Size(55, 20);
            this.lblSatusText.TabIndex = 0;
            this.lblSatusText.Text = "Satus:";
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxStatus.Location = new System.Drawing.Point(138, 15);
            this.richTextBoxStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(104, 92);
            this.richTextBoxStatus.TabIndex = 1;
            this.richTextBoxStatus.Text = "";
            // 
            // timerCheckInternetConnection
            // 
            this.timerCheckInternetConnection.Enabled = true;
            this.timerCheckInternetConnection.Interval = 5000;
            this.timerCheckInternetConnection.Tick += new System.EventHandler(this.timerCheckInternetConnection_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 110);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CSSPDesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 796);
            this.Controls.Add(this.splitContainerFirst);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CSSPDesktopForm";
            this.Text = "CSSP Desktop";
            this.Resize += new System.EventHandler(this.CSSPDesktopForm_Resize);
            this.panelLanguageCenter.ResumeLayout(false);
            this.splitContainerFirst.Panel1.ResumeLayout(false);
            this.splitContainerFirst.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).EndInit();
            this.splitContainerFirst.ResumeLayout(false);
            this.panelHelp.ResumeLayout(false);
            this.panelHelpTop.ResumeLayout(false);
            this.panelLoginCenter.ResumeLayout(false);
            this.panelLoginCenter.PerformLayout();
            this.panelUpdateCenter.ResumeLayout(false);
            this.panelUpdateCenter.PerformLayout();
            this.panelCommandsCenter.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLanguageCenter;
        private System.Windows.Forms.Button butSetLanguageToEnglish;
        private System.Windows.Forms.Button butSetLanguageToFrancais;
        private System.Windows.Forms.SplitContainer splitContainerFirst;
        private System.Windows.Forms.Button butShowLanguagePanel;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Panel panelCommandsCenter;
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
        private System.Windows.Forms.Label lblInstalling;
        private System.Windows.Forms.Button butUpdateCompleted;
        private System.Windows.Forms.Panel panelLoginCenter;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLoginEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLoginEmail;
        private System.Windows.Forms.Label lblCSSPWebToolsLoginOneTime;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.RichTextBox richTextBoxHelp;
        private System.Windows.Forms.Button button1;
    }
}

