namespace CSSPTaskRunner
{
    partial class CSSPTaskRunnerForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblLastAppTaskCheckDate = new System.Windows.Forms.Label();
            this.lblLastAppTaskCheck = new System.Windows.Forms.Label();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.timerCheckTask = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblLastAppTaskCheckDate);
            this.splitContainer1.Panel1.Controls.Add(this.lblLastAppTaskCheck);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxStatus);
            this.splitContainer1.Size = new System.Drawing.Size(1343, 813);
            this.splitContainer1.SplitterDistance = 81;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblLastAppTaskCheckDate
            // 
            this.lblLastAppTaskCheckDate.AutoSize = true;
            this.lblLastAppTaskCheckDate.Location = new System.Drawing.Point(154, 15);
            this.lblLastAppTaskCheckDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastAppTaskCheckDate.Name = "lblLastAppTaskCheckDate";
            this.lblLastAppTaskCheckDate.Size = new System.Drawing.Size(49, 15);
            this.lblLastAppTaskCheckDate.TabIndex = 1;
            this.lblLastAppTaskCheckDate.Text = "[empty]";
            // 
            // lblLastAppTaskCheck
            // 
            this.lblLastAppTaskCheck.AutoSize = true;
            this.lblLastAppTaskCheck.Location = new System.Drawing.Point(15, 15);
            this.lblLastAppTaskCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastAppTaskCheck.Name = "lblLastAppTaskCheck";
            this.lblLastAppTaskCheck.Size = new System.Drawing.Size(118, 15);
            this.lblLastAppTaskCheck.TabIndex = 0;
            this.lblLastAppTaskCheck.Text = "Last AppTask Check: ";
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(1343, 727);
            this.richTextBoxStatus.TabIndex = 0;
            this.richTextBoxStatus.Text = "";
            // 
            // timerCheckTask
            // 
            this.timerCheckTask.Interval = 1000;
            this.timerCheckTask.Tick += new System.EventHandler(this.timerCheckTask_Tick);
            // 
            // CSSPTaskRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 813);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CSSPTaskRunnerForm";
            this.Text = "CSSP Web Tools Task Runner";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Timer timerCheckTask;
        private System.Windows.Forms.Label lblLastAppTaskCheckDate;
        private System.Windows.Forms.Label lblLastAppTaskCheck;
    }
}

