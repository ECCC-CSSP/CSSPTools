namespace CSSPDesktopUpdate
{
    partial class CSSPDesktopUpdateForm
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
            this.components = new System.ComponentModel.Container();
            this.progressBarDownloading = new System.Windows.Forms.ProgressBar();
            this.lblDownloadingUpdate = new System.Windows.Forms.Label();
            this.progressBarInstalling = new System.Windows.Forms.ProgressBar();
            this.lblInstallingUpdate = new System.Windows.Forms.Label();
            this.lblCSSPDesktopRestart = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.timerCSSPDesktopUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBarDownloading
            // 
            this.progressBarDownloading.Location = new System.Drawing.Point(64, 103);
            this.progressBarDownloading.Name = "progressBarDownloading";
            this.progressBarDownloading.Size = new System.Drawing.Size(597, 15);
            this.progressBarDownloading.TabIndex = 0;
            // 
            // lblDownloadingUpdate
            // 
            this.lblDownloadingUpdate.AutoSize = true;
            this.lblDownloadingUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDownloadingUpdate.Location = new System.Drawing.Point(64, 79);
            this.lblDownloadingUpdate.Name = "lblDownloadingUpdate";
            this.lblDownloadingUpdate.Size = new System.Drawing.Size(168, 21);
            this.lblDownloadingUpdate.TabIndex = 1;
            this.lblDownloadingUpdate.Text = "Downloading update ...";
            // 
            // progressBarInstalling
            // 
            this.progressBarInstalling.Location = new System.Drawing.Point(64, 168);
            this.progressBarInstalling.Name = "progressBarInstalling";
            this.progressBarInstalling.Size = new System.Drawing.Size(597, 16);
            this.progressBarInstalling.TabIndex = 0;
            // 
            // lblInstallingUpdate
            // 
            this.lblInstallingUpdate.AutoSize = true;
            this.lblInstallingUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInstallingUpdate.Location = new System.Drawing.Point(64, 144);
            this.lblInstallingUpdate.Name = "lblInstallingUpdate";
            this.lblInstallingUpdate.Size = new System.Drawing.Size(138, 21);
            this.lblInstallingUpdate.TabIndex = 1;
            this.lblInstallingUpdate.Text = "Installing update ...";
            // 
            // lblCSSPDesktopRestart
            // 
            this.lblCSSPDesktopRestart.AutoSize = true;
            this.lblCSSPDesktopRestart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCSSPDesktopRestart.Location = new System.Drawing.Point(64, 214);
            this.lblCSSPDesktopRestart.Name = "lblCSSPDesktopRestart";
            this.lblCSSPDesktopRestart.Size = new System.Drawing.Size(597, 21);
            this.lblCSSPDesktopRestart.TabIndex = 2;
            this.lblCSSPDesktopRestart.Text = "CSSP Desktop Application will be automatically restarted once updating is complet" +
    "ed";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(64, 251);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(80, 21);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "[No Error]";
            // 
            // timerCSSPDesktopUpdate
            // 
            this.timerCSSPDesktopUpdate.Enabled = true;
            this.timerCSSPDesktopUpdate.Interval = 1000;
            this.timerCSSPDesktopUpdate.Tick += new System.EventHandler(this.timerCSSPDesktopUpdate_Tick);
            // 
            // CSSPDesktopUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 349);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblCSSPDesktopRestart);
            this.Controls.Add(this.lblInstallingUpdate);
            this.Controls.Add(this.progressBarInstalling);
            this.Controls.Add(this.lblDownloadingUpdate);
            this.Controls.Add(this.progressBarDownloading);
            this.Name = "CSSPDesktopUpdateForm";
            this.Text = "CSSP Desktop Update Application / Application de bureau PCCSM mise à jour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarDownloading;
        private System.Windows.Forms.Label lblDownloadingUpdate;
        private System.Windows.Forms.ProgressBar progressBarInstalling;
        private System.Windows.Forms.Label lblInstallingUpdate;
        private System.Windows.Forms.Label lblCSSPDesktopRestart;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Timer timerCSSPDesktopUpdate;
    }
}

