namespace BoatSheet
{
    partial class Add
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startingAmt = new System.Windows.Forms.NumericUpDown();
            this.numToAdd = new System.Windows.Forms.NumericUpDown();
            this.newTotal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddTo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startingAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Add: ";
            // 
            // startingAmt
            // 
            this.startingAmt.Enabled = false;
            this.startingAmt.Location = new System.Drawing.Point(106, 31);
            this.startingAmt.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.startingAmt.Name = "startingAmt";
            this.startingAmt.Size = new System.Drawing.Size(74, 20);
            this.startingAmt.TabIndex = 17;
            // 
            // numToAdd
            // 
            this.numToAdd.Location = new System.Drawing.Point(106, 57);
            this.numToAdd.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numToAdd.Name = "numToAdd";
            this.numToAdd.Size = new System.Drawing.Size(74, 20);
            this.numToAdd.TabIndex = 18;
            this.numToAdd.ValueChanged += new System.EventHandler(this.numToAdd_ValueChanged);
            // 
            // newTotal
            // 
            this.newTotal.Enabled = false;
            this.newTotal.Location = new System.Drawing.Point(106, 83);
            this.newTotal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.newTotal.Name = "newTotal";
            this.newTotal.Size = new System.Drawing.Size(74, 20);
            this.newTotal.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "New Total:";
            // 
            // lblAddTo
            // 
            this.lblAddTo.AutoSize = true;
            this.lblAddTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTo.Location = new System.Drawing.Point(15, 9);
            this.lblAddTo.Name = "lblAddTo";
            this.lblAddTo.Size = new System.Drawing.Size(52, 13);
            this.lblAddTo.TabIndex = 21;
            this.lblAddTo.Text = "Add To ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(186, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(186, 80);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 23;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 115);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAddTo);
            this.Controls.Add(this.newTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numToAdd);
            this.Controls.Add(this.startingAmt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(288, 153);
            this.MinimumSize = new System.Drawing.Size(288, 153);
            this.Name = "Add";
            this.Text = "Add";
            ((System.ComponentModel.ISupportInitialize)(this.startingAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown startingAmt;
        private System.Windows.Forms.NumericUpDown numToAdd;
        private System.Windows.Forms.NumericUpDown newTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAddTo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button Cancel;
    }
}