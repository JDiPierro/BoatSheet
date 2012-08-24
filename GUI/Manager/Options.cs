using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoatSheet.GUI.Manager
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            txt_DayPath.Text = Settings.GlobalSettings.defaultSaveLoc;
        }

        private void btnChangeDayLoc_Click(object sender, EventArgs e)
        {
            if(fldSelect.ShowDialog() == DialogResult.OK)
            {
                Settings.GlobalSettings.defaultSaveLoc = fldSelect.SelectedPath + "\\";
                txt_DayPath.Text = Settings.GlobalSettings.defaultSaveLoc;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Serializer.SerializeSettings(Settings.SettingsFileName, Settings.GlobalSettings);
            Close();
        }
    }
}
