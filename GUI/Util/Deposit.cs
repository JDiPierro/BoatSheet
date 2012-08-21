using System;
using System.Windows.Forms;

namespace BoatSheet
{
    public partial class Deposit : Form
    {
        private Boat currBoat;
        private Bank depBank;

        public Deposit(Boat in_currBoat)
        {
            this.InitializeComponent();
            currBoat = in_currBoat;
            depBank = currBoat.depositBank;

            disp_cashToPull.Text = String.Format("{0:C}", currBoat.getCashProfit());
            dep_Total.Text = String.Format("{0:C}", depBank.getTotal());

            next_Total.Text = String.Format("{0:C}", currBoat.inBank.getTotal() - depBank.getTotal());

            for(int i = 0; i < 15; i++)
            {
                switch((Bank.Denomination)i)
                {
                    case Bank.Denomination.QUARTERS_LOOSE:
                        loadDisplay((Bank.Denomination)i, next_Ls_Quarters, dep_Ls_Quarters);
                        break;
                    case Bank.Denomination.QUARTER_ROLLS:
                        loadDisplay((Bank.Denomination)i, next_Rl_Quarters, dep_Rl_Quarters);
                        break;
                    case Bank.Denomination.NICKELS_LOOSE:
                        loadDisplay((Bank.Denomination)i, next_Ls_Nickels, dep_Ls_Nickels);
                        break;
                    case Bank.Denomination.NICKEL_ROLLS:
                        loadDisplay((Bank.Denomination)i, next_Rl_Nickels, dep_Rl_Nickels);
                        break;
                    case Bank.Denomination.DIMES_LOOSE:
                        loadDisplay((Bank.Denomination)i, next_Ls_Dimes, dep_Ls_Dimes);
                        break;
                    case Bank.Denomination.DIME_ROLLS:
                        loadDisplay((Bank.Denomination)i, next_Rl_Dimes, dep_Rl_Dimes);
                        break;
                    case Bank.Denomination.PENNIES_LOOSE:
                        loadDisplay((Bank.Denomination)i, next_Ls_Pennies, dep_Ls_Pennies);
                        break;
                    case Bank.Denomination.PENNY_ROLLS:
                        loadDisplay((Bank.Denomination)i, next_Rl_Pennies, dep_Rl_Pennies);
                        break;
                    case Bank.Denomination.ONES:
                        loadDisplay((Bank.Denomination)i, next_Ones, dep_Ones);
                        break;
                    case Bank.Denomination.FIVES:
                        loadDisplay((Bank.Denomination)i, next_Fives, dep_Fives);
                        break;
                    case Bank.Denomination.TENS:
                        loadDisplay((Bank.Denomination)i, next_Tens, dep_Tens);
                        break;
                    case Bank.Denomination.TWENTIES:
                        loadDisplay((Bank.Denomination)i, next_Twenties, dep_Twenties);
                        break;
                    case Bank.Denomination.FIFTIES:
                        loadDisplay((Bank.Denomination)i, next_Fifties, dep_Fifties);
                        break;
                    case Bank.Denomination.HUNDREDS:
                        loadDisplay((Bank.Denomination)i, next_Hundreds, dep_Hundreds);
                        break;
                }//End DEnom Switch

                if(currBoat.isLocked)
                {
                    toggleLock();
                }
            }//End For loop
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event called when the value is changed in a text-box.
        /// Will determine the denomination of the NumericUpDown triggering the event and update the bank accordingly.
        /// </summary>
        /// <param name="sender">Auto-sent by system. The object triggering the event.</param>
        /// <param name="e">Event Args... no idea!</param>
        private void cash_ValueChanged(object sender, EventArgs e)
        {
            Bank.Denomination denom;
            NumericUpDown objSender = (NumericUpDown)sender;
            NumericUpDown objUpdate = null;

            switch(objSender.Name)
            {
                case "dep_Ones":
                    denom = Bank.Denomination.ONES;
                    objUpdate = next_Ones;
                    break;
                case "dep_Fives":
                    denom = Bank.Denomination.FIVES;
                    objUpdate = next_Fives;
                    break;
                case "dep_Tens":
                    denom = Bank.Denomination.TENS;
                    objUpdate = next_Tens;
                    break;
                case "dep_Twenties":
                    denom = Bank.Denomination.TWENTIES;
                    objUpdate = next_Twenties;
                    break;
                case "dep_Fifties":
                    denom = Bank.Denomination.FIFTIES;
                    objUpdate = next_Fifties;
                    break;
                case "dep_Hundreds":
                    denom = Bank.Denomination.HUNDREDS;
                    objUpdate = next_Hundreds;
                    break;
                case "dep_Ls_Quarters":
                    denom = Bank.Denomination.QUARTERS_LOOSE;
                    objUpdate = next_Ls_Quarters;
                    break;
                case "dep_Rl_Quarters":
                    denom = Bank.Denomination.QUARTER_ROLLS;
                    objUpdate = next_Rl_Quarters;
                    break;
                case "dep_Ls_Dimes":
                    denom = Bank.Denomination.DIMES_LOOSE;
                    objUpdate = next_Ls_Dimes;
                    break;
                case "dep_Rl_Dime":
                    denom = Bank.Denomination.DIME_ROLLS;
                    objUpdate = next_Rl_Dimes;
                    break;
                case "dep_Ls_Nickels":
                    denom = Bank.Denomination.NICKELS_LOOSE;
                    objUpdate = next_Ls_Nickels;
                    break;
                case "dep_Rl_Nickels":
                    denom = Bank.Denomination.NICKEL_ROLLS;
                    objUpdate = next_Rl_Nickels;
                    break;
                case "dep_Ls_Pennies":
                    denom = Bank.Denomination.PENNIES_LOOSE;
                    objUpdate = next_Ls_Pennies;
                    break;
                case "dep_Rl_Pennies":
                    denom = Bank.Denomination.PENNY_ROLLS;
                    objUpdate = next_Rl_Pennies;
                    break;
                default:
                    denom = Bank.Denomination.ERROR;
                    break;
            }
            if (currBoat.inBank.getValue(denom) - objSender.Value < 0)
            {
                objSender.Value--;
            }
            else
            {
                updateNextBank(denom, (Int32) objSender.Value, objUpdate);
            }
        }

        /// <summary>
        /// Updates the value of the given denomination in the depBank Bank object.
        /// Also updates the text display of the corresponding NumericUpDown.
        /// </summary>
        /// <param name="denom">The denomination to be updated.</param>
        /// <param name="value">The value to save.</param>
        /// <param name="toUpdate">The corresponding display.</param>
        private void updateNextBank(Bank.Denomination denom, int value, NumericUpDown toUpdate)
        {
            depBank.setValue(denom, value);
            toUpdate.Value = currBoat.inBank.getValue(denom) - value;

            dep_Total.Text = String.Format("{0:C}", depBank.getTotal());
            next_Total.Text = String.Format("{0:C}", currBoat.inBank.getTotal() - depBank.getTotal());
        }

        private void loadDisplay(Bank.Denomination denom, NumericUpDown nextUpdate, NumericUpDown depUpdate)
        {
            nextUpdate.Value = currBoat.inBank.getValue(denom) - depBank.getValue(denom);
            depUpdate.Value = depBank.getValue(denom);
        }

        private void toggleLock()
        {
            dep_Ones.Enabled = !dep_Ones.Enabled;
            dep_Fives.Enabled = !dep_Fives.Enabled;
            dep_Tens.Enabled = !dep_Tens.Enabled;
            dep_Twenties.Enabled = !dep_Twenties.Enabled;
            dep_Fifties.Enabled = !dep_Fifties.Enabled;
            dep_Hundreds.Enabled = !dep_Hundreds.Enabled;

            dep_Ls_Quarters.Enabled = !dep_Ls_Quarters.Enabled;
            dep_Rl_Quarters.Enabled = !dep_Rl_Quarters.Enabled;
            dep_Ls_Dimes.Enabled = !dep_Ls_Dimes.Enabled;
            dep_Rl_Dimes.Enabled = !dep_Rl_Dimes.Enabled;
            dep_Ls_Nickels.Enabled = !dep_Ls_Nickels.Enabled;
            dep_Rl_Nickels.Enabled = !dep_Rl_Nickels.Enabled;
            dep_Ls_Pennies.Enabled = !dep_Ls_Pennies.Enabled;
            dep_Rl_Pennies.Enabled = !dep_Rl_Pennies.Enabled;
        }
    }
}
