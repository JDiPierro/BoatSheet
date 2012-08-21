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
        }

        public void Startup()
        {
            //Check if Settings file exists...
                //Yes: Load settings from file
                //No: Make new Settings file with defaults
            loadSettings();

            string defaultFilePath = Settings.GlobalSettings.defaultSaveLoc + "\\LG Daily Worksheets\\";
            loadToday(ref defaultFilePath);
            updateLockButton();
        }

        private void loadToday(ref string defaultFilePath)
        {
            //Check if a file exists for Today in the default save path (Loaded from Settings file)
            if (System.IO.Directory.Exists(defaultFilePath))
            {
                defaultFilePath = defaultFilePath + DateTime.Today.ToString("yyyy-MM-dd.day");
                if (System.IO.File.Exists(defaultFilePath))
                {
                    //Yes: Load the day
                    today = Serializer.DeSerializeDay(defaultFilePath);
                    today.myFile = defaultFilePath;

                    int loadedBoats = today.dailyBoats.Count;
                    for (int i = 0; i < loadedBoats; i++)
                    {
                        LoadDay_NewTab(today.dailyBoats[i]);
                    }
                }
                else
                {
                    //No: Make a new day and save it.
                    today = new WorkDay();
                    today.myFile = defaultFilePath;
                    today.saveDay();
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(defaultFilePath);
                //Yaay recursive :D
                loadToday(ref defaultFilePath);
            }
        }

        private void loadSettings()
        {
            if (System.IO.File.Exists(Settings.SettingsFileName))
            {
                //Yes: Load the day
                Settings.GlobalSettings = Serializer.DeSerializeSettings(Settings.SettingsFileName);
            }
            else
            {
                var newSettings = new Settings();
                Settings.GlobalSettings = newSettings;
                Serializer.SerializeSettings(Settings.SettingsFileName, Settings.GlobalSettings);
            }
        }

        //EVENT
        private void Event_NewTab(object sender, EventArgs e)
        {
            try
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
            catch
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
            tabControl.SelectedIndex = tabControl.TabPages.IndexOf(tab);

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
            if (Settings.GlobalSettings.lastSaveLoc == null)
                fld.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                fld.InitialDirectory = Settings.GlobalSettings.lastSaveLoc;
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
            updateLockButton();
        }

        private void exit(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteBoat_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count > 0)
            {
                TabPage deleteThis = tabControl.SelectedTab;

                BoatPage page = (BoatPage) deleteThis.Controls[0];

                if (!page.currBoat.isLocked)
                {
                    today.dailyBoats.Remove(page.currBoat);

                    if (tabControl.SelectedIndex == tabControl.TabCount - 1)
                        tabControl.SelectedIndex--;
                    else
                        tabControl.SelectedIndex++;
                    tabControl.TabPages.Remove(deleteThis);
                }
                else
                {
                    MessageBox.Show("Please unlock the boat before deleting it.");
                }
            }
        }

        private void LockBoat_Click(object sender, EventArgs e)
        {
            var currPage = (BoatPage)tabControl.TabPages[tabControl.SelectedIndex].Controls[0];

            currPage.toggleBoatLock(false);

            updateLockButton();
            today.saveDay();
        }

        private void updateLockButton()
        {
            if (tabControl.TabCount > 0)
            {
                var currPage = (BoatPage) tabControl.SelectedTab.Controls[0];

                if (currPage.currBoat.isLocked)
                {
                    btnLockBoat.Text = "Unlock Boat";
                }
                else btnLockBoat.Text = "Lock Boat";
            }
        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            var currPage = (BoatPage)tabControl.SelectedTab.Controls[0];

            currPage.savePicture();
        }

        private void tabControl_Deselected(object sender, TabControlEventArgs e)
        {
            var page = (BoatPage)tabControl.SelectedTab.Controls[0];

            if (!page.currBoat.isLocked)
            {
                page.toggleBoatLock(false);
            }
        }
    }
}
