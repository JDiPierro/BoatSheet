using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BoatSheet
{
    public partial class BoatSheet : Form
    {
        private List<Boat> openBoats; 

        public BoatSheet()
        {
            InitializeComponent();

            openBoats = new List<Boat>();
        }

        //EVENT
        private void Event_NewTab(object sender, EventArgs e)
        {
            var objSender = (ToolStripMenuItem)sender;
            
            BoatPage page = newTab();

            if (objSender == menu_LoadBoat)
            {
                page.loadBoat();
            }
            else if(objSender == menu_SaveBoat)
            {
                page.saveBoat();
            }
        }

        private BoatPage newTab()
        {
            Boat newBoat = new Boat();

            openBoats.Add(newBoat);

            TabPage tab = new TabPage(String.Format("{0} {1}", newBoat.sailTime, newBoat.boatName));

            BoatPage page = new BoatPage(tab, newBoat);
            page.Dock = DockStyle.Fill;

            tab.Controls.Add(page);
            tabControl.TabPages.Add(tab);

            return page;
        }

    }
}
