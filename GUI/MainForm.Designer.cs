namespace BoatSheet
{
    partial class BoatSheet
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SaveDay = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_SaveDayAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_LoadDay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_NewBoat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_LoadBoat = new System.Windows.Forms.ToolStripMenuItem();
            this.managerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePricesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_deleteBoat = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btnSavePic = new System.Windows.Forms.Button();
            this.btnNewBoat = new System.Windows.Forms.Button();
            this.btnLockBoat = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.boatToolStripMenuItem,
            this.managerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1090, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_SaveDay,
            this.menu_SaveDayAs,
            this.menu_LoadDay,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menu_SaveDay
            // 
            this.menu_SaveDay.Name = "menu_SaveDay";
            this.menu_SaveDay.Size = new System.Drawing.Size(137, 22);
            this.menu_SaveDay.Text = "Save Day";
            this.menu_SaveDay.Click += new System.EventHandler(this.Click_SaveTab);
            // 
            // menu_SaveDayAs
            // 
            this.menu_SaveDayAs.Name = "menu_SaveDayAs";
            this.menu_SaveDayAs.Size = new System.Drawing.Size(137, 22);
            this.menu_SaveDayAs.Text = "Save Day As";
            this.menu_SaveDayAs.Click += new System.EventHandler(this.Click_SaveTab);
            // 
            // menu_LoadDay
            // 
            this.menu_LoadDay.Name = "menu_LoadDay";
            this.menu_LoadDay.Size = new System.Drawing.Size(137, 22);
            this.menu_LoadDay.Text = "Load Day";
            this.menu_LoadDay.Click += new System.EventHandler(this.Click_LoadDay);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit);
            // 
            // boatToolStripMenuItem
            // 
            this.boatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_NewBoat,
            this.toolStripSeparator1,
            this.menu_LoadBoat});
            this.boatToolStripMenuItem.Name = "boatToolStripMenuItem";
            this.boatToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.boatToolStripMenuItem.Text = "Boat";
            // 
            // menu_NewBoat
            // 
            this.menu_NewBoat.Name = "menu_NewBoat";
            this.menu_NewBoat.Size = new System.Drawing.Size(127, 22);
            this.menu_NewBoat.Text = "New Boat";
            this.menu_NewBoat.Click += new System.EventHandler(this.Event_NewTab);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // menu_LoadBoat
            // 
            this.menu_LoadBoat.Name = "menu_LoadBoat";
            this.menu_LoadBoat.Size = new System.Drawing.Size(127, 22);
            this.menu_LoadBoat.Text = "Load Boat";
            this.menu_LoadBoat.Click += new System.EventHandler(this.Event_NewTab);
            // 
            // managerToolStripMenuItem
            // 
            this.managerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.menu_deleteBoat});
            this.managerToolStripMenuItem.Name = "managerToolStripMenuItem";
            this.managerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.managerToolStripMenuItem.Text = "Manager";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePricesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changePricesToolStripMenuItem
            // 
            this.changePricesToolStripMenuItem.Name = "changePricesToolStripMenuItem";
            this.changePricesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.changePricesToolStripMenuItem.Text = "Change Prices";
            this.changePricesToolStripMenuItem.Click += new System.EventHandler(this.Click_Change_Price);
            // 
            // menu_deleteBoat
            // 
            this.menu_deleteBoat.Name = "menu_deleteBoat";
            this.menu_deleteBoat.Size = new System.Drawing.Size(134, 22);
            this.menu_deleteBoat.Text = "Delete Boat";
            this.menu_deleteBoat.Click += new System.EventHandler(this.DeleteBoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 598);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1090, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(109, 27);
            this.tabControl.MinimumSize = new System.Drawing.Size(969, 568);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(969, 568);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabChanged);
            this.tabControl.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Deselected);
            // 
            // btnSavePic
            // 
            this.btnSavePic.Location = new System.Drawing.Point(12, 85);
            this.btnSavePic.Name = "btnSavePic";
            this.btnSavePic.Size = new System.Drawing.Size(91, 23);
            this.btnSavePic.TabIndex = 8;
            this.btnSavePic.Text = "Save Picture";
            this.btnSavePic.UseVisualStyleBackColor = true;
            this.btnSavePic.Click += new System.EventHandler(this.btnSavePic_Click);
            // 
            // btnNewBoat
            // 
            this.btnNewBoat.Location = new System.Drawing.Point(12, 56);
            this.btnNewBoat.Name = "btnNewBoat";
            this.btnNewBoat.Size = new System.Drawing.Size(91, 23);
            this.btnNewBoat.TabIndex = 7;
            this.btnNewBoat.Text = "New Boat";
            this.btnNewBoat.UseVisualStyleBackColor = true;
            this.btnNewBoat.Click += new System.EventHandler(this.Event_NewTab);
            // 
            // btnLockBoat
            // 
            this.btnLockBoat.Location = new System.Drawing.Point(12, 27);
            this.btnLockBoat.Name = "btnLockBoat";
            this.btnLockBoat.Size = new System.Drawing.Size(91, 23);
            this.btnLockBoat.TabIndex = 6;
            this.btnLockBoat.Text = "Lock Boat";
            this.btnLockBoat.UseVisualStyleBackColor = true;
            this.btnLockBoat.Click += new System.EventHandler(this.LockBoat_Click);
            // 
            // BoatSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 620);
            this.Controls.Add(this.btnSavePic);
            this.Controls.Add(this.btnNewBoat);
            this.Controls.Add(this.btnLockBoat);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1106, 658);
            this.Name = "BoatSheet";
            this.Text = "Electronic Boat Sheet";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripMenuItem managerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_SaveDay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem menu_LoadDay;
        private System.Windows.Forms.ToolStripMenuItem boatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_NewBoat;
        private System.Windows.Forms.ToolStripMenuItem menu_LoadBoat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem changePricesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_deleteBoat;
        private System.Windows.Forms.ToolStripMenuItem menu_SaveDayAs;
        private System.Windows.Forms.Button btnSavePic;
        private System.Windows.Forms.Button btnNewBoat;
        private System.Windows.Forms.Button btnLockBoat;
    }
}

