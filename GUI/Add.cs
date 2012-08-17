using System;
using System.Windows.Forms;

namespace BoatSheet
{
    public partial class Add : Form
    {
        private NumericUpDown toUpdate;
        public Add(NumericUpDown IN_toUpdate, string name)
        {
            InitializeComponent();
            toUpdate = IN_toUpdate;
            startingAmt.Value = toUpdate.Value;
            lblAddTo.Text = "Add To: " + name;
        }

        private void numToAdd_ValueChanged(object sender, EventArgs e)
        {
            newTotal.Value = startingAmt.Value + numToAdd.Value;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            toUpdate.Value = newTotal.Value;
            this.Close();
        }
    }
}
