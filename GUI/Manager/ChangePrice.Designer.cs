namespace BoatSheet.GUI.Manager
{
    partial class ChangePrice
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
            this.boatSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.price_AllIn = new System.Windows.Forms.NumericUpDown();
            this.price_BaseOnly = new System.Windows.Forms.NumericUpDown();
            this.price_AcrylicOnly = new System.Windows.Forms.NumericUpDown();
            this.price_AcrylicAddOn = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.price_AllIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_BaseOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_AcrylicOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_AcrylicAddOn)).BeginInit();
            this.SuspendLayout();
            // 
            // boatSelect
            // 
            this.boatSelect.FormattingEnabled = true;
            this.boatSelect.Items.AddRange(new object[] {
            "Saint",
            "Minne",
            "Mohican"});
            this.boatSelect.Location = new System.Drawing.Point(50, 12);
            this.boatSelect.Name = "boatSelect";
            this.boatSelect.Size = new System.Drawing.Size(129, 21);
            this.boatSelect.TabIndex = 0;
            this.boatSelect.SelectedIndexChanged += new System.EventHandler(this.boatChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Boat:";
            // 
            // price_AllIn
            // 
            this.price_AllIn.DecimalPlaces = 2;
            this.price_AllIn.Location = new System.Drawing.Point(98, 39);
            this.price_AllIn.Name = "price_AllIn";
            this.price_AllIn.Size = new System.Drawing.Size(81, 20);
            this.price_AllIn.TabIndex = 2;
            this.price_AllIn.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // price_BaseOnly
            // 
            this.price_BaseOnly.DecimalPlaces = 2;
            this.price_BaseOnly.Location = new System.Drawing.Point(98, 65);
            this.price_BaseOnly.Name = "price_BaseOnly";
            this.price_BaseOnly.Size = new System.Drawing.Size(81, 20);
            this.price_BaseOnly.TabIndex = 3;
            this.price_BaseOnly.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // price_AcrylicOnly
            // 
            this.price_AcrylicOnly.DecimalPlaces = 2;
            this.price_AcrylicOnly.Location = new System.Drawing.Point(98, 91);
            this.price_AcrylicOnly.Name = "price_AcrylicOnly";
            this.price_AcrylicOnly.Size = new System.Drawing.Size(81, 20);
            this.price_AcrylicOnly.TabIndex = 4;
            this.price_AcrylicOnly.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // price_AcrylicAddOn
            // 
            this.price_AcrylicAddOn.DecimalPlaces = 2;
            this.price_AcrylicAddOn.Location = new System.Drawing.Point(98, 129);
            this.price_AcrylicAddOn.Name = "price_AcrylicAddOn";
            this.price_AcrylicAddOn.Size = new System.Drawing.Size(81, 20);
            this.price_AcrylicAddOn.TabIndex = 5;
            this.price_AcrylicAddOn.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "All In:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Base Only:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Acrylic Only:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Acrylic Add-On:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(98, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ChangePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 185);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.price_AcrylicAddOn);
            this.Controls.Add(this.price_AcrylicOnly);
            this.Controls.Add(this.price_BaseOnly);
            this.Controls.Add(this.price_AllIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boatSelect);
            this.Name = "ChangePrice";
            this.Text = "Manager: Change Prices";
            ((System.ComponentModel.ISupportInitialize)(this.price_AllIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_BaseOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_AcrylicOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_AcrylicAddOn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boatSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown price_AllIn;
        private System.Windows.Forms.NumericUpDown price_BaseOnly;
        private System.Windows.Forms.NumericUpDown price_AcrylicOnly;
        private System.Windows.Forms.NumericUpDown price_AcrylicAddOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
    }
}