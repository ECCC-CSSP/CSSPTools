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
            this.butGenerateCode.Location = new System.Drawing.Point(83, 38);
            this.butGenerateCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butGenerateCode.Name = "butGenerateCode";
            this.butGenerateCode.Size = new System.Drawing.Size(159, 27);
            this.butGenerateCode.TabIndex = 0;
            this.butGenerateCode.Text = "Generate Code";
            this.butGenerateCode.UseVisualStyleBackColor = true;
            this.butGenerateCode.Click += new System.EventHandler(this.butGenerateCode_Click);
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(83, 96);
            this.richTextBoxStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(640, 463);
            this.richTextBoxStatus.TabIndex = 1;
            this.richTextBoxStatus.Text = resources.GetString("richTextBoxStatus.Text");
            // 
            // CSSPEnumsGenerateCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 785);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.butGenerateCode);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CSSPEnumsGenerateCode";
            this.Text = "CSSP Enums Generate Code";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butGenerateCode;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
    }
}

