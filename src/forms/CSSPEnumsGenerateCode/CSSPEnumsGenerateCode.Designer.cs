namespace CSSPEnumsGenerateCode
{
    partial class CSSPEnumsGenerateCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSSPEnumsGenerateCode));
            this.butGenerateCode = new System.Windows.Forms.Button();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // butGenerateCode
            // 
            this.butGenerateCode.Location = new System.Drawing.Point(71, 33);
            this.butGenerateCode.Name = "butGenerateCode";
            this.butGenerateCode.Size = new System.Drawing.Size(136, 23);
            this.butGenerateCode.TabIndex = 0;
            this.butGenerateCode.Text = "Generate Code";
            this.butGenerateCode.UseVisualStyleBackColor = true;
            this.butGenerateCode.Click += new System.EventHandler(this.butGenerateCode_Click);
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(71, 83);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(549, 402);
            this.richTextBoxStatus.TabIndex = 1;
            this.richTextBoxStatus.Text = resources.GetString("richTextBoxStatus.Text");
            // 
            // CSSPEnumsGenerateCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 680);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.butGenerateCode);
            this.Name = "CSSPEnumsGenerateCode";
            this.Text = "CSSP Enums Generate Code";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butGenerateCode;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
    }
}

