namespace BoatSheet
{
    partial class AddCC
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
            this.label2 = new System.Windows.Forms.Label();
            this.otherAdd = new System.Windows.Forms.NumericUpDown();
            this.newTotal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddTo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.allIns = new System.Windows.Forms.NumericUpDown();
            this.baseOnly = new System.Windows.Forms.NumericUpDown();
            this.price_AllIn = new System.Windows.Forms.Label();
            this.price_Base = new System.Windows.Forms.Label();
            this.lbl_AllInValue = new System.Windows.Forms.Label();
            this.lbl_BaseValue = new System.Windows.Forms.Label();
            this.lbl_AcrylOnly = new System.Windows.Forms.Label();
            this.price_AcrylicOnly = new System.Windows.Forms.Label();
            this.numAcrylOnly = new System.Windows.Forms.NumericUpDown();
            this.lbl_AcrylicAddOn = new System.Windows.Forms.Label();
            this.price_AcrylicAddOn = new System.Windows.Forms.Label();
            this.numAcrylicAddOn = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.otherAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allIns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAcrylOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAcrylicAddOn)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Other Amount:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // otherAdd
            // 
            this.otherAdd.DecimalPlaces = 2;
            this.otherAdd.Location = new System.Drawing.Point(106, 132);
            this.otherAdd.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.otherAdd.Name = "otherAdd";
            this.otherAdd.Size = new System.Drawing.Size(74, 20);
            this.otherAdd.TabIndex = 5;
            this.otherAdd.ValueChanged += new System.EventHandler(this.otherAdd_ValueChanged);
            // 
            // newTotal
            // 
            this.newTotal.DecimalPlaces = 2;
            this.newTotal.Enabled = false;
            this.newTotal.Location = new System.Drawing.Point(106, 158);
            this.newTotal.Maximum = new decimal(new int[] {
            999999999,
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
            this.label3.Location = new System.Drawing.Point(66, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Total:";
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
            this.btnSave.Location = new System.Drawing.Point(106, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // allIns
            // 
            this.allIns.Location = new System.Drawing.Point(107, 28);
            this.allIns.Name = "allIns";
            this.allIns.Size = new System.Drawing.Size(74, 20);
            this.allIns.TabIndex = 1;
            this.allIns.ValueChanged += new System.EventHandler(this.allIns_ValueChanged);
            // 
            // baseOnly
            // 
            this.baseOnly.Location = new System.Drawing.Point(107, 54);
            this.baseOnly.Name = "baseOnly";
            this.baseOnly.Size = new System.Drawing.Size(74, 20);
            this.baseOnly.TabIndex = 2;
            this.baseOnly.ValueChanged += new System.EventHandler(this.baseOnly_ValueChanged);
            // 
            // price_AllIn
            // 
            this.price_AllIn.AutoSize = true;
            this.price_AllIn.Location = new System.Drawing.Point(60, 30);
            this.price_AllIn.Name = "price_AllIn";
            this.price_AllIn.Size = new System.Drawing.Size(40, 13);
            this.price_AllIn.TabIndex = 26;
            this.price_AllIn.Text = "$00.00";
            this.price_AllIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // price_Base
            // 
            this.price_Base.AutoSize = true;
            this.price_Base.Location = new System.Drawing.Point(60, 56);
            this.price_Base.Name = "price_Base";
            this.price_Base.Size = new System.Drawing.Size(40, 13);
            this.price_Base.TabIndex = 27;
            this.price_Base.Text = "$00.00";
            this.price_Base.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_AllInValue
            // 
            this.lbl_AllInValue.AutoSize = true;
            this.lbl_AllInValue.Location = new System.Drawing.Point(187, 30);
            this.lbl_AllInValue.Name = "lbl_AllInValue";
            this.lbl_AllInValue.Size = new System.Drawing.Size(34, 13);
            this.lbl_AllInValue.TabIndex = 28;
            this.lbl_AllInValue.Text = "$0.00";
            // 
            // lbl_BaseValue
            // 
            this.lbl_BaseValue.AutoSize = true;
            this.lbl_BaseValue.Location = new System.Drawing.Point(187, 56);
            this.lbl_BaseValue.Name = "lbl_BaseValue";
            this.lbl_BaseValue.Size = new System.Drawing.Size(34, 13);
            this.lbl_BaseValue.TabIndex = 29;
            this.lbl_BaseValue.Text = "$0.00";
            // 
            // lbl_AcrylOnly
            // 
            this.lbl_AcrylOnly.AutoSize = true;
            this.lbl_AcrylOnly.Location = new System.Drawing.Point(187, 82);
            this.lbl_AcrylOnly.Name = "lbl_AcrylOnly";
            this.lbl_AcrylOnly.Size = new System.Drawing.Size(34, 13);
            this.lbl_AcrylOnly.TabIndex = 32;
            this.lbl_AcrylOnly.Text = "$0.00";
            // 
            // price_AcrylicOnly
            // 
            this.price_AcrylicOnly.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.price_AcrylicOnly.AutoSize = true;
            this.price_AcrylicOnly.Location = new System.Drawing.Point(60, 82);
            this.price_AcrylicOnly.Name = "price_AcrylicOnly";
            this.price_AcrylicOnly.Size = new System.Drawing.Size(40, 13);
            this.price_AcrylicOnly.TabIndex = 31;
            this.price_AcrylicOnly.Text = "$00.00";
            this.price_AcrylicOnly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numAcrylOnly
            // 
            this.numAcrylOnly.Location = new System.Drawing.Point(106, 80);
            this.numAcrylOnly.Name = "numAcrylOnly";
            this.numAcrylOnly.Size = new System.Drawing.Size(74, 20);
            this.numAcrylOnly.TabIndex = 3;
            this.numAcrylOnly.ValueChanged += new System.EventHandler(this.numAcrylOnly_ValueChanged);
            // 
            // lbl_AcrylicAddOn
            // 
            this.lbl_AcrylicAddOn.AutoSize = true;
            this.lbl_AcrylicAddOn.Location = new System.Drawing.Point(187, 108);
            this.lbl_AcrylicAddOn.Name = "lbl_AcrylicAddOn";
            this.lbl_AcrylicAddOn.Size = new System.Drawing.Size(34, 13);
            this.lbl_AcrylicAddOn.TabIndex = 35;
            this.lbl_AcrylicAddOn.Text = "$0.00";
            // 
            // price_AcrylicAddOn
            // 
            this.price_AcrylicAddOn.AutoSize = true;
            this.price_AcrylicAddOn.Location = new System.Drawing.Point(60, 108);
            this.price_AcrylicAddOn.Name = "price_AcrylicAddOn";
            this.price_AcrylicAddOn.Size = new System.Drawing.Size(40, 13);
            this.price_AcrylicAddOn.TabIndex = 34;
            this.price_AcrylicAddOn.Text = "$00.00";
            this.price_AcrylicAddOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numAcrylicAddOn
            // 
            this.numAcrylicAddOn.Location = new System.Drawing.Point(107, 106);
            this.numAcrylicAddOn.Name = "numAcrylicAddOn";
            this.numAcrylicAddOn.Size = new System.Drawing.Size(74, 20);
            this.numAcrylicAddOn.TabIndex = 4;
            this.numAcrylicAddOn.ValueChanged += new System.EventHandler(this.numAcrylicAddOn_ValueChanged);
            // 
            // AddCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 221);
            this.Controls.Add(this.lbl_AcrylicAddOn);
            this.Controls.Add(this.price_AcrylicAddOn);
            this.Controls.Add(this.numAcrylicAddOn);
            this.Controls.Add(this.lbl_AcrylOnly);
            this.Controls.Add(this.price_AcrylicOnly);
            this.Controls.Add(this.numAcrylOnly);
            this.Controls.Add(this.lbl_BaseValue);
            this.Controls.Add(this.lbl_AllInValue);
            this.Controls.Add(this.price_Base);
            this.Controls.Add(this.price_AllIn);
            this.Controls.Add(this.baseOnly);
            this.Controls.Add(this.allIns);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAddTo);
            this.Controls.Add(this.newTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.otherAdd);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(282, 259);
            this.MinimumSize = new System.Drawing.Size(282, 259);
            this.Name = "AddCC";
            this.Text = "Add a Credit Card Purchase";
            ((System.ComponentModel.ISupportInitialize)(this.otherAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allIns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAcrylOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAcrylicAddOn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown otherAdd;
        private System.Windows.Forms.NumericUpDown newTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAddTo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown allIns;
        private System.Windows.Forms.NumericUpDown baseOnly;
        private System.Windows.Forms.Label price_AllIn;
        private System.Windows.Forms.Label price_Base;
        private System.Windows.Forms.Label lbl_AllInValue;
        private System.Windows.Forms.Label lbl_BaseValue;
        private System.Windows.Forms.Label lbl_AcrylOnly;
        private System.Windows.Forms.Label price_AcrylicOnly;
        private System.Windows.Forms.NumericUpDown numAcrylOnly;
        private System.Windows.Forms.Label lbl_AcrylicAddOn;
        private System.Windows.Forms.Label price_AcrylicAddOn;
        private System.Windows.Forms.NumericUpDown numAcrylicAddOn;
    }
}