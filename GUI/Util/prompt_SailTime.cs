using System;
using System.Windows.Forms;

namespace BoatSheet
{
    public partial class prompt_SailTime : Form
    {
        private Boat currBoat;

        public prompt_SailTime(Boat in_Boat)
        {
            InitializeComponent();
            currBoat = in_Boat;
        }

        private void prompt_SailTime_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveTime_Click(object sender, EventArgs e)
        {
            currBoat.sailTime = txt_SailTime.Text;
            Close();
        }

        private void btnBypass_Click(object sender, EventArgs e)
        {
            currBoat.sailTime = "notime";
            Close();
        }
    }
}
