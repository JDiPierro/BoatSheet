namespace BoatSheet
{
    partial class prompt_SailTime
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
            this.txt_SailTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.btnSaveTime = new System.Windows.Forms.Button();
            this.btnBypass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_SailTime
            // 
            this.txt_SailTime.Location = new System.Drawing.Point(106, 35);
            this.txt_SailTime.Name = "txt_SailTime";
            this.txt_SailTime.Size = new System.Drawing.Size(73, 20);
            this.txt_SailTime.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Please enter in a Sail Time before saving:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(47, 38);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(53, 13);
            this.label62.TabIndex = 12;
            this.label62.Text = "Sail Time:";
            // 
            // btnSaveTime
            // 
            this.btnSaveTime.Location = new System.Drawing.Point(50, 61);
            this.btnSaveTime.Name = "btnSaveTime";
            this.btnSaveTime.Size = new System.Drawing.Size(129, 23);
            this.btnSaveTime.TabIndex = 15;
            this.btnSaveTime.Text = "Save";
            this.btnSaveTime.UseVisualStyleBackColor = true;
            this.btnSaveTime.Click += new System.EventHandler(this.btnSaveTime_Click);
            // 
            // btnBypass
            // 
            this.btnBypass.Location = new System.Drawing.Point(50, 90);
            this.btnBypass.Name = "btnBypass";
            this.btnBypass.Size = new System.Drawing.Size(129, 23);
            this.btnBypass.TabIndex = 16;
            this.btnBypass.Text = "Save Without Time";
            this.btnBypass.UseVisualStyleBackColor = true;
            this.btnBypass.Click += new System.EventHandler(this.btnBypass_Click);
            // 
            // prompt_SailTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 128);
            this.Controls.Add(this.btnBypass);
            this.Controls.Add(this.btnSaveTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_SailTime);
            this.Controls.Add(this.label62);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(242, 166);
            this.Name = "prompt_SailTime";
            this.Text = "Sail Time";
            this.Load += new System.EventHandler(this.prompt_SailTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_SailTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Button btnSaveTime;
        private System.Windows.Forms.Button btnBypass;
    }
}