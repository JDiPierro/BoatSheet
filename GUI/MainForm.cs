using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoatSheet
{
    public partial class BoatSheet : Form
    {
        private Boat currBoat;

        public BoatSheet()
        {
            InitializeComponent();
        }

        private void newBoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boat newBoat = new Boat();

            TabPage tab = new TabPage(String.Format("{0} {1}", newBoat.sailTime, newBoat.boatName));

            BoatPage page = new BoatPage(tab, newBoat);
            page.Dock = DockStyle.Fill;

            tab.Controls.Add(page);
            tabControl.TabPages.Add(tab);
        }

        private void loadBoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boat newBoat = new Boat();

            TabPage tab = new TabPage(String.Format("{0} {1}", newBoat.sailTime, newBoat.boatName));

            BoatPage page = new BoatPage(tab, newBoat);
            page.Dock = DockStyle.Fill;

            tab.Controls.Add(page);
            tabControl.TabPages.Add(tab);

            page.loadBoat();
        }

        private void saveBoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveMe = (BoatPage) tabControl.SelectedTab.Controls[0];

            saveMe.saveBoat();
        }

    }
}
