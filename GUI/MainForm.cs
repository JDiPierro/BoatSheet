using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BoatSheet.Data;
using BoatSheet.GUI.Manager;

namespace BoatSheet
{
    public partial class BoatSheet : Form
    {
        private WorkDay today;

        public BoatSheet()
        {
            InitializeComponent();
            today = new WorkDay();
        }

        //EVENT
        private void Event_NewTab(object sender, EventArgs e)
        {
            var objSender = (ToolStripMenuItem)sender;
            
            BoatPage page = newTab();

            if (objSender == menu_LoadBoat || objSender == menu_LoadDay)
            {
                page.loadBoat();
            }
        }

        private void Click_SaveTab(object sender, EventArgs e)
        {
                today.saveDay();
        }

        private BoatPage newTab()
        {
            var newBoat = new Boat();

            today.addBoat(newBoat);

            var tab = new TabPage(String.Format("{0} {1}", newBoat.sailTime, newBoat.boatName));

            var page = new BoatPage(tab, newBoat);
            page.Dock = DockStyle.Fill;

            tab.Controls.Add(page);

            tabControl.TabPages.Add(tab);
            tabControl.SelectedIndex++;

            return page;
        }

        private void LoadDay_NewTab(Boat newBoat)
        {
            var tab = new TabPage(String.Format("{0} {1}", newBoat.sailTime, newBoat.boatName));

            var page = new BoatPage(tab, newBoat);
            page.updateOnLoad();
            page.Dock = DockStyle.Fill;

            tab.Controls.Add(page);

            tabControl.TabPages.Add(tab);
        }

        private void Click_Change_Price(object sender, EventArgs e)
        {
            var cp = new ChangePrice();

            cp.ShowDialog();
        }

        private void Click_LoadDay(object sender, EventArgs e)
        {
            tabControl.TabPages.Clear();

            var fld = new OpenFileDialog();
            fld.AddExtension = true;
            if (Settings.lastSaveLoc == null)
                fld.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                fld.InitialDirectory = Settings.lastSaveLoc;
            fld.DefaultExt = "day";
            fld.Filter = "Day Data (*.day)|*.day|All files (*.*)|*.*";

            string loc;
            if (fld.ShowDialog() == DialogResult.OK)
            {
                loc = fld.FileName;
                today = Serializer.DeSerializeDay(loc);
            }

            int loadedBoats = today.dailyBoats.Count;
            for(int i = 0; i < loadedBoats; i++)
            {
                LoadDay_NewTab(today.dailyBoats[i]);
            }
        }

    }
}
