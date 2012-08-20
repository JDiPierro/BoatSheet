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
            Startup();

            today = new WorkDay();
        }

        public void Startup()
        {
            //Check if Settings file exists...
                //Yes: Load settings from file
                //No: Make new Settings file with defaults
            //Check if a file exists for Today in the default save path (Loaded from Settings file)
                //Yes: Load it
                //No: Make a new Day file and open a new boat tab.
        }

        //EVENT
        private void Event_NewTab(object sender, EventArgs e)
        {
            var objSender = (ToolStripMenuItem)sender;


            if (objSender == menu_LoadBoat)
            {
                OpenFileDialog fld = new OpenFileDialog();
                fld.AddExtension = true;
                if (today.myFile == null)
                    fld.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                else
                    fld.InitialDirectory = today.myFile;
                fld.DefaultExt = "boat";
                fld.Filter = "Boat Data (*.boat)|*.boat|All files (*.*)|*.*";

                string loc;
                if (fld.ShowDialog() == DialogResult.OK)
                {
                    loc = fld.FileName;
                    BoatPage page = newTab();
                    page.loadBoat(loc);
                }
            }
            else
            {
                newTab();
            }
        }

        private void Click_SaveTab(object sender, EventArgs e)
        {
            var objSender = (ToolStripMenuItem) sender;

            if (today.dailyBoats.Count > 0)
            {
                if (objSender == menu_SaveDayAs || today.myFile == null)
                {
                    SaveFileDialog fld = new SaveFileDialog();
                    fld.AddExtension = true;
                    if (today.myFile == null)
                        fld.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    else
                        fld.InitialDirectory = today.myFile;
                    fld.FileName = String.Format("{0}", DateTime.Today.ToString("yyyy-MM-dd"));
                    fld.DefaultExt = "day";
                    fld.Filter = "Day Data (*.day)|*.day|All files (*.*)|*.*";

                    string loc;
                    if (fld.ShowDialog() == DialogResult.OK)
                    {
                        loc = fld.FileName;
                        today.myFile = loc;
                        today.saveDay();
                    }
                }
                else
                {
                    today.saveDay();
                }
            }
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
                today.myFile = loc;
            }

            int loadedBoats = today.dailyBoats.Count;
            for(int i = 0; i < loadedBoats; i++)
            {
                LoadDay_NewTab(today.dailyBoats[i]);
            }
        }

        private void tabChanged(object sender, EventArgs e)
        {
            if(today.myFile != null)
            {
                today.saveDay();
            }
        }

        private void exit(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteBoat_Click(object sender, EventArgs e)
        {
            TabPage deleteThis = tabControl.SelectedTab;

            BoatPage page = (BoatPage)deleteThis.Controls[0];

            today.dailyBoats.Remove(page.currBoat);

            tabControl.SelectedIndex++;
            tabControl.TabPages.Remove(deleteThis);
        }
    }
}
