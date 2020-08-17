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
            this.panelLanguageCenter = new System.Windows.Forms.Panel();
            this.butSetLanguageToFrancais = new System.Windows.Forms.Button();
            this.butSetLanguageToEnglish = new System.Windows.Forms.Button();
            this.splitContainerFirst = new System.Windows.Forms.SplitContainer();
            this.panelLoginEmail = new System.Windows.Forms.Panel();
            this.lblContactLoggedIn = new System.Windows.Forms.Label();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.richTextBoxHelp = new System.Windows.Forms.RichTextBox();
            this.panelHelpTop = new System.Windows.Forms.Panel();
            this.butHideHelpPanel = new System.Windows.Forms.Button();
            this.panelHelpSpace1 = new System.Windows.Forms.Panel();
            this.panelLoginCenter = new System.Windows.Forms.Panel();
            this.butLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLoginEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLoginEmail = new System.Windows.Forms.Label();
            this.lblCSSPWebToolsLoginOneTime = new System.Windows.Forms.Label();
            this.panelUpdateCenter = new System.Windows.Forms.Panel();
            this.butCancelUpdate = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butUpdateCompleted = new System.Windows.Forms.Button();
            this.progressBarInstalling = new System.Windows.Forms.ProgressBar();
            this.lblInstalling = new System.Windows.Forms.Label();
            this.panelCommandsCenter = new System.Windows.Forms.Panel();
            this.butShowUpdatePanel = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.butStart = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.butShowHelpPanel = new System.Windows.Forms.Button();
            this.panelTopSpace4 = new System.Windows.Forms.Panel();
            this.butShowLanguagePanel = new System.Windows.Forms.Button();
            this.panelToSpace3 = new System.Windows.Forms.Panel();
            this.butShowLoginPanel = new System.Windows.Forms.Button();
            this.panelTopSpace2 = new System.Windows.Forms.Panel();
            this.butLogoff = new System.Windows.Forms.Button();
            this.panelTopSpace1 = new System.Windows.Forms.Panel();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.panelLanguageCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).BeginInit();
            this.splitContainerFirst.Panel1.SuspendLayout();
            this.splitContainerFirst.Panel2.SuspendLayout();
            this.splitContainerFirst.SuspendLayout();
            this.panelLoginEmail.SuspendLayout();
            this.panelHelp.SuspendLayout();
            this.panelHelpTop.SuspendLayout();
            this.panelLoginCenter.SuspendLayout();
            this.panelUpdateCenter.SuspendLayout();
            this.panelCommandsCenter.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLanguageCenter
            // 
            this.panelLanguageCenter.Controls.Add(this.butSetLanguageToFrancais);
            this.panelLanguageCenter.Controls.Add(this.butSetLanguageToEnglish);
            this.panelLanguageCenter.Location = new System.Drawing.Point(555, 288);
            this.panelLanguageCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelLanguageCenter.Name = "panelLanguageCenter";
            this.panelLanguageCenter.Size = new System.Drawing.Size(306, 120);
            this.panelLanguageCenter.TabIndex = 0;
            // 
            // butSetLanguageToFrancais
            // 
            this.butSetLanguageToFrancais.AutoSize = true;
            this.butSetLanguageToFrancais.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butSetLanguageToFrancais.Location = new System.Drawing.Point(172, 39);
            this.butSetLanguageToFrancais.Name = "butSetLanguageToFrancais";
            this.butSetLanguageToFrancais.Size = new System.Drawing.Size(92, 42);
            this.butSetLanguageToFrancais.TabIndex = 1;
            this.butSetLanguageToFrancais.Text = "Français";
            this.butSetLanguageToFrancais.Click += new System.EventHandler(this.butSetLanguageToFrancais_Click);
            // 
            // butSetLanguageToEnglish
            // 
            this.butSetLanguageToEnglish.AutoSize = true;
            this.butSetLanguageToEnglish.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butSetLanguageToEnglish.Location = new System.Drawing.Point(45, 39);
            this.butSetLanguageToEnglish.Name = "butSetLanguageToEnglish";
            this.butSetLanguageToEnglish.Size = new System.Drawing.Size(92, 42);
            this.butSetLanguageToEnglish.TabIndex = 0;
            this.butSetLanguageToEnglish.Text = "English";
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
            this.splitContainerFirst.Panel1.Controls.Add(this.panelLoginEmail);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelLanguageCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelHelp);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelLoginCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelUpdateCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelCommandsCenter);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelStatus);
            this.splitContainerFirst.Panel1.Controls.Add(this.panelTop);
            // 
            // splitContainerFirst.Panel2
            // 
            this.splitContainerFirst.Panel2.Controls.Add(this.richTextBoxStatus);
            this.splitContainerFirst.Size = new System.Drawing.Size(1148, 770);
            this.splitContainerFirst.SplitterDistance = 659;
            this.splitContainerFirst.SplitterWidth = 5;
            this.splitContainerFirst.TabIndex = 1;
            // 
            // panelLoginEmail
            // 
            this.panelLoginEmail.Controls.Add(this.lblContactLoggedIn);
            this.panelLoginEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoginEmail.Location = new System.Drawing.Point(0, 36);
            this.panelLoginEmail.Name = "panelLoginEmail";
            this.panelLoginEmail.Size = new System.Drawing.Size(1148, 27);
            this.panelLoginEmail.TabIndex = 11;
            // 
            // lblContactLoggedIn
            // 
            this.lblContactLoggedIn.AutoSize = true;
            this.lblContactLoggedIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblContactLoggedIn.Enabled = false;
            this.lblContactLoggedIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblContactLoggedIn.Location = new System.Drawing.Point(1108, 0);
            this.lblContactLoggedIn.Name = "lblContactLoggedIn";
            this.lblContactLoggedIn.Size = new System.Drawing.Size(40, 21);
            this.lblContactLoggedIn.TabIndex = 9;
            this.lblContactLoggedIn.Text = "-----";
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
            this.panelHelpTop.Controls.Add(this.panelHelpSpace1);
            this.panelHelpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHelpTop.Location = new System.Drawing.Point(0, 0);
            this.panelHelpTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelHelpTop.Name = "panelHelpTop";
            this.panelHelpTop.Size = new System.Drawing.Size(322, 37);
            this.panelHelpTop.TabIndex = 1;
            // 
            // butHideHelpPanel
            // 
            this.butHideHelpPanel.AutoSize = true;
            this.butHideHelpPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.butHideHelpPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butHideHelpPanel.Location = new System.Drawing.Point(15, 0);
            this.butHideHelpPanel.Name = "butHideHelpPanel";
            this.butHideHelpPanel.Size = new System.Drawing.Size(124, 37);
            this.butHideHelpPanel.TabIndex = 0;
            this.butHideHelpPanel.Text = "Close Help";
            this.butHideHelpPanel.Click += new System.EventHandler(this.butHideHelpPanel_Click);
            // 
            // panelHelpSpace1
            // 
            this.panelHelpSpace1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHelpSpace1.Location = new System.Drawing.Point(0, 0);
            this.panelHelpSpace1.Name = "panelHelpSpace1";
            this.panelHelpSpace1.Size = new System.Drawing.Size(15, 37);
            this.panelHelpSpace1.TabIndex = 6;
            // 
            // panelLoginCenter
            // 
            this.panelLoginCenter.Controls.Add(this.butLogin);
            this.panelLoginCenter.Controls.Add(this.textBoxPassword);
            this.panelLoginCenter.Controls.Add(this.textBoxLoginEmail);
            this.panelLoginCenter.Controls.Add(this.lblPassword);
            this.panelLoginCenter.Controls.Add(this.lblLoginEmail);
            this.panelLoginCenter.Controls.Add(this.lblCSSPWebToolsLoginOneTime);
            this.panelLoginCenter.Location = new System.Drawing.Point(24, 327);
            this.panelLoginCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelLoginCenter.Name = "panelLoginCenter";
            this.panelLoginCenter.Size = new System.Drawing.Size(484, 284);
            this.panelLoginCenter.TabIndex = 9;
            // 
            // butLogin
            // 
            this.butLogin.AutoSize = true;
            this.butLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butLogin.Location = new System.Drawing.Point(150, 217);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(139, 44);
            this.butLogin.TabIndex = 2;
            this.butLogin.Text = "Login";
            this.butLogin.Click += new System.EventHandler(this.linkLabelLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(59, 177);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(311, 26);
            this.textBoxPassword.TabIndex = 1;
            // 
            // textBoxLoginEmail
            // 
            this.textBoxLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLoginEmail.Location = new System.Drawing.Point(59, 104);
            this.textBoxLoginEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxLoginEmail.Name = "textBoxLoginEmail";
            this.textBoxLoginEmail.Size = new System.Drawing.Size(311, 26);
            this.textBoxLoginEmail.TabIndex = 0;
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
            // panelUpdateCenter
            // 
            this.panelUpdateCenter.Controls.Add(this.butCancelUpdate);
            this.panelUpdateCenter.Controls.Add(this.butUpdate);
            this.panelUpdateCenter.Controls.Add(this.butUpdateCompleted);
            this.panelUpdateCenter.Controls.Add(this.progressBarInstalling);
            this.panelUpdateCenter.Controls.Add(this.lblInstalling);
            this.panelUpdateCenter.Location = new System.Drawing.Point(545, 95);
            this.panelUpdateCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelUpdateCenter.Name = "panelUpdateCenter";
            this.panelUpdateCenter.Size = new System.Drawing.Size(588, 163);
            this.panelUpdateCenter.TabIndex = 8;
            // 
            // butCancelUpdate
            // 
            this.butCancelUpdate.AutoSize = true;
            this.butCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butCancelUpdate.Location = new System.Drawing.Point(343, 33);
            this.butCancelUpdate.Name = "butCancelUpdate";
            this.butCancelUpdate.Size = new System.Drawing.Size(113, 39);
            this.butCancelUpdate.TabIndex = 1;
            this.butCancelUpdate.Text = "Cancel";
            this.butCancelUpdate.Click += new System.EventHandler(this.butCancelUpdate_Click);
            // 
            // butUpdate
            // 
            this.butUpdate.AutoSize = true;
            this.butUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butUpdate.Location = new System.Drawing.Point(147, 33);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(127, 39);
            this.butUpdate.TabIndex = 0;
            this.butUpdate.Text = "Update";
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // butUpdateCompleted
            // 
            this.butUpdateCompleted.AutoSize = true;
            this.butUpdateCompleted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butUpdateCompleted.Location = new System.Drawing.Point(221, 33);
            this.butUpdateCompleted.Name = "butUpdateCompleted";
            this.butUpdateCompleted.Size = new System.Drawing.Size(202, 39);
            this.butUpdateCompleted.TabIndex = 2;
            this.butUpdateCompleted.Text = "Update Completed";
            this.butUpdateCompleted.Visible = false;
            this.butUpdateCompleted.Click += new System.EventHandler(this.butUpdateCompleted_Click);
            // 
            // progressBarInstalling
            // 
            this.progressBarInstalling.Location = new System.Drawing.Point(82, 114);
            this.progressBarInstalling.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarInstalling.Name = "progressBarInstalling";
            this.progressBarInstalling.Size = new System.Drawing.Size(463, 10);
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
            // panelCommandsCenter
            // 
            this.panelCommandsCenter.Controls.Add(this.butShowUpdatePanel);
            this.panelCommandsCenter.Controls.Add(this.butClose);
            this.panelCommandsCenter.Controls.Add(this.butStop);
            this.panelCommandsCenter.Controls.Add(this.butStart);
            this.panelCommandsCenter.Location = new System.Drawing.Point(15, 95);
            this.panelCommandsCenter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelCommandsCenter.Name = "panelCommandsCenter";
            this.panelCommandsCenter.Size = new System.Drawing.Size(417, 174);
            this.panelCommandsCenter.TabIndex = 7;
            // 
            // butShowUpdatePanel
            // 
            this.butShowUpdatePanel.AutoSize = true;
            this.butShowUpdatePanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butShowUpdatePanel.Location = new System.Drawing.Point(178, 103);
            this.butShowUpdatePanel.Name = "butShowUpdatePanel";
            this.butShowUpdatePanel.Size = new System.Drawing.Size(183, 45);
            this.butShowUpdatePanel.TabIndex = 3;
            this.butShowUpdatePanel.Text = "Updates Available";
            this.butShowUpdatePanel.Click += new System.EventHandler(this.butShowUpdatePanel_Click);
            // 
            // butClose
            // 
            this.butClose.AutoSize = true;
            this.butClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butClose.Location = new System.Drawing.Point(36, 103);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(110, 45);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "Close";
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butStop
            // 
            this.butStop.AutoSize = true;
            this.butStop.Enabled = false;
            this.butStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butStop.Location = new System.Drawing.Point(198, 19);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(110, 45);
            this.butStop.TabIndex = 1;
            this.butStop.Text = "Stop";
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // butStart
            // 
            this.butStart.AutoSize = true;
            this.butStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butStart.Location = new System.Drawing.Point(36, 19);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(110, 45);
            this.butStart.TabIndex = 0;
            this.butStart.Text = "Start";
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Controls.Add(this.lblStatusText);
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
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatusText.Location = new System.Drawing.Point(10, 10);
            this.lblStatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(55, 20);
            this.lblStatusText.TabIndex = 0;
            this.lblStatusText.Text = "Satus:";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.butShowHelpPanel);
            this.panelTop.Controls.Add(this.panelTopSpace4);
            this.panelTop.Controls.Add(this.butShowLanguagePanel);
            this.panelTop.Controls.Add(this.panelToSpace3);
            this.panelTop.Controls.Add(this.butShowLoginPanel);
            this.panelTop.Controls.Add(this.panelTopSpace2);
            this.panelTop.Controls.Add(this.butLogoff);
            this.panelTop.Controls.Add(this.panelTopSpace1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1148, 36);
            this.panelTop.TabIndex = 10;
            this.panelTop.Visible = false;
            // 
            // butShowHelpPanel
            // 
            this.butShowHelpPanel.AutoSize = true;
            this.butShowHelpPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.butShowHelpPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butShowHelpPanel.Location = new System.Drawing.Point(133, 0);
            this.butShowHelpPanel.Name = "butShowHelpPanel";
            this.butShowHelpPanel.Size = new System.Drawing.Size(91, 36);
            this.butShowHelpPanel.TabIndex = 1;
            this.butShowHelpPanel.Text = "Help";
            this.butShowHelpPanel.Click += new System.EventHandler(this.butShowHelpPanel_Click);
            // 
            // panelTopSpace4
            // 
            this.panelTopSpace4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopSpace4.Location = new System.Drawing.Point(118, 0);
            this.panelTopSpace4.Name = "panelTopSpace4";
            this.panelTopSpace4.Size = new System.Drawing.Size(15, 36);
            this.panelTopSpace4.TabIndex = 5;
            // 
            // butShowLanguagePanel
            // 
            this.butShowLanguagePanel.AutoSize = true;
            this.butShowLanguagePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.butShowLanguagePanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butShowLanguagePanel.Location = new System.Drawing.Point(15, 0);
            this.butShowLanguagePanel.Name = "butShowLanguagePanel";
            this.butShowLanguagePanel.Size = new System.Drawing.Size(103, 36);
            this.butShowLanguagePanel.TabIndex = 0;
            this.butShowLanguagePanel.Text = "Language";
            this.butShowLanguagePanel.Click += new System.EventHandler(this.butShowLanguagePanel_Click);
            // 
            // panelToSpace3
            // 
            this.panelToSpace3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelToSpace3.Location = new System.Drawing.Point(0, 0);
            this.panelToSpace3.Name = "panelToSpace3";
            this.panelToSpace3.Size = new System.Drawing.Size(15, 36);
            this.panelToSpace3.TabIndex = 5;
            // 
            // butShowLoginPanel
            // 
            this.butShowLoginPanel.AutoSize = true;
            this.butShowLoginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.butShowLoginPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butShowLoginPanel.Location = new System.Drawing.Point(834, 0);
            this.butShowLoginPanel.Name = "butShowLoginPanel";
            this.butShowLoginPanel.Size = new System.Drawing.Size(140, 36);
            this.butShowLoginPanel.TabIndex = 2;
            this.butShowLoginPanel.Text = "Login";
            // 
            // panelTopSpace2
            // 
            this.panelTopSpace2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopSpace2.Location = new System.Drawing.Point(974, 0);
            this.panelTopSpace2.Name = "panelTopSpace2";
            this.panelTopSpace2.Size = new System.Drawing.Size(15, 36);
            this.panelTopSpace2.TabIndex = 5;
            // 
            // butLogoff
            // 
            this.butLogoff.AutoSize = true;
            this.butLogoff.Dock = System.Windows.Forms.DockStyle.Right;
            this.butLogoff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butLogoff.Location = new System.Drawing.Point(989, 0);
            this.butLogoff.Name = "butLogoff";
            this.butLogoff.Size = new System.Drawing.Size(144, 36);
            this.butLogoff.TabIndex = 3;
            this.butLogoff.Text = "Logoff";
            this.butLogoff.Visible = false;
            this.butLogoff.Click += new System.EventHandler(this.butLogoff_Click);
            // 
            // panelTopSpace1
            // 
            this.panelTopSpace1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopSpace1.Location = new System.Drawing.Point(1133, 0);
            this.panelTopSpace1.Name = "panelTopSpace1";
            this.panelTopSpace1.Size = new System.Drawing.Size(15, 36);
            this.panelTopSpace1.TabIndex = 5;
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
            // CSSPDesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 793);
            this.Controls.Add(this.splitContainerFirst);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CSSPDesktopForm";
            this.Text = "CSSP Desktop";
            this.Resize += new System.EventHandler(this.CSSPDesktopForm_Resize);
            this.panelLanguageCenter.ResumeLayout(false);
            this.panelLanguageCenter.PerformLayout();
            this.splitContainerFirst.Panel1.ResumeLayout(false);
            this.splitContainerFirst.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).EndInit();
            this.splitContainerFirst.ResumeLayout(false);
            this.panelLoginEmail.ResumeLayout(false);
            this.panelLoginEmail.PerformLayout();
            this.panelHelp.ResumeLayout(false);
            this.panelHelpTop.ResumeLayout(false);
            this.panelHelpTop.PerformLayout();
            this.panelLoginCenter.ResumeLayout(false);
            this.panelLoginCenter.PerformLayout();
            this.panelUpdateCenter.ResumeLayout(false);
            this.panelUpdateCenter.PerformLayout();
            this.panelCommandsCenter.ResumeLayout(false);
            this.panelCommandsCenter.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLanguageCenter;
        private System.Windows.Forms.SplitContainer splitContainerFirst;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Panel panelCommandsCenter;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Panel panelHelp;
        private System.Windows.Forms.Panel panelHelpTop;
        private System.Windows.Forms.Panel panelUpdateCenter;
        private System.Windows.Forms.ProgressBar progressBarInstalling;
        private System.Windows.Forms.Label lblInstalling;
        private System.Windows.Forms.Panel panelLoginCenter;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLoginEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLoginEmail;
        private System.Windows.Forms.Label lblCSSPWebToolsLoginOneTime;
        private System.Windows.Forms.RichTextBox richTextBoxHelp;
        private System.Windows.Forms.Button butSetLanguageToFrancais;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTopSpace2;
        private System.Windows.Forms.Panel panelTopSpace1;
        private System.Windows.Forms.Panel panelTopSpace4;
        private System.Windows.Forms.Panel panelToSpace3;
        private System.Windows.Forms.Button butSetLanguageToEnglish;
        private System.Windows.Forms.Button butShowLoginPanel;
        private System.Windows.Forms.Button butLogoff;
        private System.Windows.Forms.Button butHideHelpPanel;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Button butCancelUpdate;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butUpdateCompleted;
        private System.Windows.Forms.Button butShowUpdatePanel;
        private System.Windows.Forms.Button butShowHelpPanel;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butShowLanguagePanel;
        private System.Windows.Forms.Panel panelLoginEmail;
        private System.Windows.Forms.Label lblContactLoggedIn;
        private System.Windows.Forms.Panel panelHelpSpace1;
    }
}

