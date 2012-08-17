using System;
using System.Windows.Forms;

namespace BoatSheet
{
    public partial class AddCC : Form
    {
        private Boat currBoat;
        private Boat.NonCashAsset card;

        private string name;

        public AddCC(Boat in_currBoat, string name)
        {
            InitializeComponent();
            currBoat = in_currBoat;
            lblAddTo.Text = "Add To: " + name;
            this.name = name;
            switch (name)
            {
                case "Amex":
                    card = currBoat.amEx;
                    break;
                case "Visa":
                    card = currBoat.visa;
                    break;
                case "Mastercard":
                    card = currBoat.mastercard;
                    break;
                case "Discover":
                    card = currBoat.discover;
                    break;
                case "Direct Bill to Host":
                    card = currBoat.directBill;
                    break;
                case "Personal Check":
                    card = currBoat.personalCheck;
                    break;
            }

            price_AllIn.Text = String.Format("{0:C}", currBoat.AllInVal);
            price_Base.Text = String.Format("{0:C}", currBoat.BaseVal);
            price_AcrylicOnly.Text = String.Format("{0:C}", currBoat.AcrylOnlyVal);
            price_AcrylicAddOn.Text = String.Format("{0:C}", Bank.addOnAcrylVal);

            getStartValues();
        }

        private void getStartValues()
        {
            allIns.Value = card.numAllins;
            baseOnly.Value = card.numBaseOnly;
            numAcrylOnly.Value = card.numAcrylicOnly;
            numAcrylicAddOn.Value = card.numAcrylicAddOn;
            otherAdd.Value = card.otherValue;

            updateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(name)
            {
            case "Amex":
                currBoat.amEx = card;
                break;
            case "Visa":
                currBoat.visa = card;
                break;
            case "Mastercard":
                currBoat.mastercard = card;
                break;
            case "Discover":
                currBoat.discover = card;
                break;
            case "Direct Bill to Host":
                currBoat.directBill = card;
                break;
            case "Personal Check":
                currBoat.personalCheck = card;
                break;
            }
            this.Close();
        }

        private void allIns_ValueChanged(object sender, EventArgs e)
        {
            card.numAllins = Convert.ToInt32(allIns.Value);
            lbl_AllInValue.Text = string.Format("{0:C}", card.numAllins * currBoat.AllInVal);
            updateTotal();
        }

        private void baseOnly_ValueChanged(object sender, EventArgs e)
        {
            card.numBaseOnly = Convert.ToInt32(baseOnly.Value);
            lbl_BaseValue.Text = string.Format("{0:C}", card.numBaseOnly * currBoat.BaseVal);
            updateTotal();
        }

        private void numAcrylOnly_ValueChanged(object sender, EventArgs e)
        {
            card.numAcrylicOnly = Convert.ToInt32(numAcrylOnly.Value);
            lbl_AcrylOnly.Text = string.Format("{0:C}", card.numAcrylicOnly * currBoat.AcrylOnlyVal);
            updateTotal();
        }

        private void numAcrylicAddOn_ValueChanged(object sender, EventArgs e)
        {
            card.numAcrylicAddOn = Convert.ToInt32(numAcrylicAddOn.Value);
            lbl_AcrylicAddOn.Text = string.Format("{0:C}", card.numAcrylicAddOn * Bank.addOnAcrylVal);
            updateTotal();
        }

        private void otherAdd_ValueChanged(object sender, EventArgs e)
        {
            card.otherValue = otherAdd.Value;
            updateTotal();
        }

        private void updateTotal()
        {
            card.total = 0.0m;
            card.total += card.numAllins * currBoat.AllInVal;
            card.total += card.numBaseOnly * currBoat.BaseVal;
            card.total += card.numAcrylicOnly * currBoat.AcrylOnlyVal;
            card.total += card.numAcrylicAddOn * Bank.addOnAcrylVal;
            card.total += card.otherValue;

            newTotal.Value = card.total;
        }

        

    }
}
