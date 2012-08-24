namespace BoatSheet.GUI.Manager
{
    partial class Options
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
            this.fldSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.txt_DayPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeDayLoc = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_DayPath
            // 
            this.txt_DayPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DayPath.Location = new System.Drawing.Point(148, 12);
            this.txt_DayPath.Name = "txt_DayPath";
            this.txt_DayPath.Size = new System.Drawing.Size(299, 20);
            this.txt_DayPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Daily Workbook Location:";
            // 
            // btnChangeDayLoc
            // 
            this.btnChangeDayLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeDayLoc.Location = new System.Drawing.Point(458, 9);
            this.btnChangeDayLoc.Name = "btnChangeDayLoc";
            this.btnChangeDayLoc.Size = new System.Drawing.Size(75, 23);
            this.btnChangeDayLoc.TabIndex = 2;
            this.btnChangeDayLoc.Text = "Change";
            this.btnChangeDayLoc.UseVisualStyleBackColor = true;
            this.btnChangeDayLoc.Click += new System.EventHandler(this.btnChangeDayLoc_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(15, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 75);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChangeDayLoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_DayPath);
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fldSelect;
        private System.Windows.Forms.TextBox txt_DayPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeDayLoc;
        private System.Windows.Forms.Button btnSave;
    }
}