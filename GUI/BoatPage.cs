﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoatSheet
{
    public partial class BoatPage : UserControl
    {
        public TabPage myTab;

        public Boat currBoat;

        private string lastSaveLoc;

        public BoatPage(TabPage inTab, Boat inBoat)
        {
            InitializeComponent();
            currBoat = inBoat;
            myTab = inTab;
            sel_BoatSelect.SelectedIndex = (int)currBoat.boatName;

            setName();
        }

        #region Utils

        public void savePicture()
        {
            using (var bmp = new Bitmap(Width, Height))
            {
                DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                SaveFileDialog fld = new SaveFileDialog();
                fld.AddExtension = true;
                if (lastSaveLoc == null)
                    fld.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                else
                    fld.InitialDirectory = lastSaveLoc;
                fld.FileName = String.Format("{2} {1} {0}", currBoat.sailTime,
                                                currBoat.boatName,
                                                currBoat.date.ToString("yyyy.MM.dd"));
                fld.DefaultExt = "jpg";
                fld.Filter = "Jpeg images (*.jpg)|*.jpg|All files (*.*)|*.*";

                string loc;
                if (fld.ShowDialog() == DialogResult.OK)
                {
                    loc = fld.FileName;
                    bmp.Save(loc);
                    lastSaveLoc = loc;
                }
            }
        }

        public void loadBoat(string loc)
        {
            clearSheet();
            currBoat = Serializer.DeSerializeBoat(loc);
            currBoat.updatePackages();
            currBoat.updateTotals();

            updateOnLoad();
        }

        public void updateOnLoad()
        {
            dtp_BoatDate.Value = currBoat.date;
            sel_BoatSelect.SelectedItem = currBoat.boatName;

            txt_SailTime.Text = currBoat.sailTime;
            pkgsOut.Value = currBoat.pkgsOut;
            pkgsNotViewed.Value = currBoat.pkgsNotViewed;
            pkgsViewedNS.Value = currBoat.pkgsViewedNS;

            count_clicker.Value = currBoat.clicker;
            count_labtech.Value = currBoat.headcount;
            count_PAX.Value = currBoat.paxCount;

            bkI_Ones.Value = currBoat.inBank.getOnes();
            bkI_Fives.Value = currBoat.inBank.getFives();
            bkI_Tens.Value = currBoat.inBank.getTens();
            bkI_Twenties.Value = currBoat.inBank.getTwenties();
            bkI_Fifties.Value = currBoat.inBank.getFifties();
            bkI_Hundreds.Value = currBoat.inBank.getHundreds();

            bkI_Ls_Quarters.Value = currBoat.inBank.getNumQuarters();
            bkI_Ls_Nickels.Value = currBoat.inBank.getNumNickels();
            bkI_Ls_Dimes.Value = currBoat.inBank.getNumDimes();
            bkI_Ls_Pennies.Value = currBoat.inBank.getNumPennies();

            bkI_Rl_Quarters.Value = currBoat.inBank.getNumQuarterRolls();
            bkI_Rl_Nickels.Value = currBoat.inBank.getNumNickelRolls();
            bkI_Rl_Dimes.Value = currBoat.inBank.getNumDimeRolls();
            bkI_Rl_Pennies.Value = currBoat.inBank.getNumPennyRolls();

            lbl_CashOnHand.Value = currBoat.inBank.getTotal();

            boatNotes.Text = currBoat.notes;
            txt_Initials.Text = currBoat.employeeInitials;

            decimal depTotal = currBoat.depositBank.getTotal();

            dep_Pulled.Text = String.Format("{0:C}", depTotal);
            dep_Next.Text = String.Format("{0:C}", currBoat.inBank.getTotal() - depTotal);

            updatePkgDisplay();
            refreshCCs();

            if(currBoat.isLocked)
            {
                toggleBoatLock(true);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currBoat.clearBoat();
            clearSheet();
        }

        private void clearSheet()
        {
            currBoat = new Boat((Boat.boatType)sel_BoatSelect.SelectedIndex);
            bkI_Ls_Quarters.Value = 0;
            bkI_Ls_Dimes.Value = 0;
            bkI_Ls_Nickels.Value = 0;
            bkI_Ls_Pennies.Value = 0;

            bkI_Rl_Quarters.Value = 0;
            bkI_Rl_Dimes.Value = 0;
            bkI_Rl_Nickels.Value = 0;
            bkI_Rl_Pennies.Value = 0;

            bkI_Ones.Value = 0;
            bkI_Fives.Value = 0;
            bkI_Tens.Value = 0;
            bkI_Twenties.Value = 0;
            bkI_Fifties.Value = 0;
            bkI_Hundreds.Value = 0;

            pkgsViewedNS.Value = 0;
            pkgsNotViewed.Value = 0;
            pkgsOut.Value = 0;
            count_labtech.Value = 0;
            /*************************/
            sel_BoatSelect.SelectedIndex = 1;

            prd_AllIn.Value = 0;
            prd_Base.Value = 0;
            prd_Acrylic.Value = 0;
            prd_ReprintAllIn.Value = 0;
            prd_Other.Value = 0;
            prd_Other_Price.Text = String.Empty;
            prd_AcrylAdd.Value = 0;

            lbl_Amex.Value = 0;
            lbl_Visa.Value = 0;
            lbl_Mastercard.Value = 0;
            lbl_Discover.Value = 0;
            lbl_DirectBill.Value = 0;
            lbl_Check.Value = 0;

            cbxAllInOver.Checked = false;
            cbxCashOverride.Checked = false;

            boatNotes.Clear();
            txt_SailTime.Clear();
        }

        private void setName()
        {
            //this.Text = String.Format("Electronic Boat Sheet - {0} {1}", currBoat.sailTime, currBoat.boatName);
            if(myTab != null)
                myTab.Text = String.Format("{0} {1}", currBoat.sailTime, currBoat.boatName.ToString());
        }

        #endregion

        #region Bank Logic

        private void bkI_Ls_Quarters_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setQuarters(Convert.ToInt32(bkI_Ls_Quarters.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Rl_Quarters_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setQuarterRolls(Convert.ToInt32(bkI_Rl_Quarters.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Ls_Nickels_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setNickels(Convert.ToInt32(bkI_Ls_Nickels.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Rl_Nickels_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setNickelRolls(Convert.ToInt32(bkI_Rl_Nickels.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Ls_Dimes_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setDimes(Convert.ToInt32(bkI_Ls_Dimes.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Rl_Dimes_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setDimeRolls(Convert.ToInt32(bkI_Rl_Dimes.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Ls_Pennies_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setPennies(Convert.ToInt32(bkI_Ls_Pennies.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Rl_Pennies_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setPennyRolls(Convert.ToInt32(bkI_Rl_Pennies.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Ones_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setOnes(Convert.ToInt32(bkI_Ones.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Fives_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setFives(Convert.ToInt32(bkI_Fives.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Tens_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setTens(Convert.ToInt32(bkI_Tens.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Twenties_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setTwenties(Convert.ToInt32(bkI_Twenties.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Fifties_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setFifties(Convert.ToInt32(bkI_Fifties.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void bkI_Hundreds_ValueChanged(object sender, EventArgs e)
        {
            currBoat.inBank.setHundreds(Convert.ToInt32(bkI_Hundreds.Value));
            currBoat.updateTotals();
            updateStatDisplay();
        }

        #endregion Bank Logic

        #region Add Buttons
        private void add_bkI_Ls_Q_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Ls_Quarters, "Bank In Loose Quarters");
            addTo.ShowDialog();
        }

        private void add_bkI_Rl_Q_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Rl_Quarters, "Bank In Rolled Quarters");
            addTo.ShowDialog();
        }

        private void add_bkI_Ls_D_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Ls_Dimes, "Bank In Loose Dimes");
            addTo.ShowDialog();
        }

        private void add_bkI_Rl_D_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Rl_Dimes, "Bank In Rolled Dimes");
            addTo.ShowDialog();
        }

        private void add_bkI_Ls_N_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Ls_Nickels, "Bank In Loose Nickels");
            addTo.ShowDialog();
        }

        private void add_bkI_Rl_N_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Rl_Nickels, "Bank In Rolled Nickels");
            addTo.ShowDialog();
        }

        private void add_bkI_Ls_P_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Ls_Pennies, "Bank In Loose Pennies");
            addTo.ShowDialog();
        }

        private void add_bkI_Rl_P_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Rl_Pennies, "Bank In Rolled Pennies");
            addTo.ShowDialog();
        }

        private void add_bkI_1_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Ones, "Bank In Ones");
            addTo.ShowDialog();
        }

        private void add_bkI_5_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Fives, "Bank In Fives");
            addTo.ShowDialog();
        }

        private void add_bkI_10_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Tens, "Bank In Tens");
            addTo.ShowDialog();
        }

        private void add_bkI_20_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Twenties, "Bank In Twenties");
            addTo.ShowDialog();
        }

        private void add_bkI_50_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Fifties, "Bank In Fifties");
            addTo.ShowDialog();
        }

        private void add_bkI_100_Click(object sender, EventArgs e)
        {
            Add addTo = new Add(bkI_Hundreds, "Bank In Hundreds");
            addTo.ShowDialog();
        }
        #endregion Add Buttons

        #region Add CCs

        private void addCC_Amex_Click(object sender, EventArgs e)
        {
            AddCC addTo = new AddCC(currBoat, "Amex");
            addTo.ShowDialog();
            lbl_Amex.Value = currBoat.amEx.total;
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void addCC_Visa_Click(object sender, EventArgs e)
        {
            AddCC addTo = new AddCC(currBoat, "Visa");
            addTo.ShowDialog();
            lbl_Visa.Value = currBoat.visa.total;
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void addCC_MC_Click(object sender, EventArgs e)
        {
            AddCC addTo = new AddCC(currBoat, "Mastercard");
            addTo.ShowDialog();
            lbl_Mastercard.Value = currBoat.mastercard.total;
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void addCC_Discover_Click(object sender, EventArgs e)
        {
            AddCC addTo = new AddCC(currBoat, "Discover");
            addTo.ShowDialog();
            lbl_Discover.Value = currBoat.discover.total;
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void addCC_DirectBill_Click(object sender, EventArgs e)
        {
            AddCC addTo = new AddCC(currBoat, "Direct Bill to Host");
            addTo.ShowDialog();
            lbl_DirectBill.Value = currBoat.directBill.total;
            currBoat.updateTotals();
            updateStatDisplay();
        }

        private void addCC_Check_Click(object sender, EventArgs e)
        {
            AddCC addTo = new AddCC(currBoat, "Personal Check");
            addTo.ShowDialog();
            lbl_Check.Value = currBoat.personalCheck.total;
            currBoat.updateTotals();
            updateStatDisplay();
        }
        #endregion Add CCs

        #region Passenger Counts

        private void lblHeadcount_ValueChanged(object sender, EventArgs e)
        {
            currBoat.headcount = Convert.ToInt32(count_labtech.Value);
            currBoat.calcPerCap();
            updateStatDisplay();
        }

        private void count_PAX_ValueChanged(object sender, EventArgs e)
        {
            currBoat.paxCount = Convert.ToInt32(count_PAX.Value);
            currBoat.calcPerCap();
            updateStatDisplay();
        }

        private void count_clicker_ValueChanged(object sender, EventArgs e)
        {
            currBoat.clicker = Convert.ToInt32(count_clicker.Value);
            currBoat.calcPerCap();
            updateStatDisplay();
        }

        #endregion Passenger Counts

        #region Overrides

        private void cbx_ovrBankOut_CheckedChanged(object sender, EventArgs e)
        {
            bankOutAmt.Enabled = cbx_ovrBankOut.Checked;
            currBoat.updateTotals();
        }

        private void cbxAllInOver_CheckedChanged(object sender, EventArgs e)
        {
            prd_AllIn.Enabled = cbxAllInOver.Checked;
            if (cbxAllInOver.Checked)
            {
                prd_AllIn.Minimum = 0;
            }
            else
            {
                prd_AllIn.Minimum = -999999.0m;
            }
            currBoat.override_AllInCount = cbxAllInOver.Checked;
            currBoat.updatePackages();
        }

        private void cbxCashOverride_CheckedChanged(object sender, EventArgs e)
        {
            lbl_CashOnHand.Enabled = cbxCashOverride.Checked;
            currBoat.override_CashAmt = cbxCashOverride.Checked;
            currBoat.updateTotals();
        }

        #endregion

        #region Boat Info

        private void prd_BoatSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            currBoat.boatName = (Boat.boatType) sel_BoatSelect.SelectedIndex;
            currBoat.determinePrices(sel_BoatSelect.SelectedIndex);

            bankOutAmt.Value = currBoat.bankOut;
            currBoat.updateTotals();
            updateStatDisplay();

            lbl_allInPrice.Text = String.Format("{0:C}", currBoat.AllInVal);
            lbl_baseOnlyPrice.Text = String.Format("{0:C}", currBoat.BaseVal);
            lbl_AcrylOnlyPrice.Text = String.Format("{0:C}", currBoat.AcrylOnlyVal);

            setName();
        }

        private void dtp_BoatDate_ValueChanged(object sender, EventArgs e)
        {
            currBoat.date = dtp_BoatDate.Value;
        }

        private void txt_Initials_TextChanged(object sender, EventArgs e)
        {
            currBoat.employeeInitials = txt_Initials.Text;
        }
        #endregion Overrides

        #region Money

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Deposit depBox = new Deposit(currBoat);
            depBox.ShowDialog();

            decimal depTotal = currBoat.depositBank.getTotal();

            dep_Pulled.Text = String.Format("{0:C}", depTotal);
            dep_Next.Text = String.Format("{0:C}", currBoat.inBank.getTotal() - depTotal);
        }

        private void bankOutAmt_ValueChanged(object sender, EventArgs e)
        {
            if (bankOutAmt.Enabled)
            {
                currBoat.bankOut = bankOutAmt.Value;
            }
        }

        private void cashChanged(object sender, EventArgs e)
        {
            if (currBoat.override_CashAmt)
            {
                currBoat.updateTotals();
            }
        }

        private void moneyChanged(object sender, EventArgs e)
        {
            currBoat.updateTotals();
            updateStatDisplay();
        }

        #endregion Overrides

        #region Packages

        private void prd_Other_TextChanged(object sender, EventArgs e)
        {
            currBoat.otherPrints = Convert.ToInt32(prd_Other.Value);
            if (prd_Other.Value != 0)
            {
                prd_Other_Price.Enabled = true;
                prd_Other_Price_TextChanged(sender, e);
            }
            else
            {
                prd_Other_Price.Enabled = false;
            }
            currBoat.updatePackages();
            updatePkgDisplay();

        }

        private void prd_Other_Price_TextChanged(object sender, EventArgs e)
        {

            if (prd_Other_Price.Enabled)
            {
                if (prd_Other_Price.Value != 0.00m)
                {
                    currBoat.otherValue = prd_Other_Price.Value;
                    }
                else
                {
                    currBoat.otherValue = 0.0m;
                }
                currBoat.updateTotals();
                updatePkgDisplay();
            }
        }

        private void packages_ValueChanged(object sender, EventArgs e)
        {
            var objSender = (NumericUpDown)sender;
            if (objSender == pkgsOut)
            {
                currBoat.pkgsOut = Convert.ToInt32(pkgsOut.Value);
            }
            else if (objSender == pkgsNotViewed)
            {
                currBoat.pkgsNotViewed = Convert.ToInt32(pkgsNotViewed.Value);
            }
            else
            {
                currBoat.pkgsViewedNS = Convert.ToInt32(pkgsViewedNS.Value);
            }
            currBoat.updatePackages();
            updatePkgDisplay();
        }

        private void prd_AllIn_ValueChanged(object sender, EventArgs e)
        {
            if (currBoat.override_AllInCount)
            {
                currBoat.sold_allIn = Convert.ToInt32(prd_AllIn);
                currBoat.updatePackages();
                updatePkgDisplay();
            }
        }

        private void prd_Base_ValueChanged(object sender, EventArgs e)
        {
            currBoat.sold_baseOnly = Convert.ToInt32(prd_Base.Value);
            currBoat.updatePackages();
            updatePkgDisplay();
        }

        private void prd_Acrylic_ValueChanged(object sender, EventArgs e)
        {
            currBoat.sold_acrylicOnly = Convert.ToInt32(prd_Acrylic.Value);
            currBoat.updatePackages();
            updatePkgDisplay();
        }

        private void prd_ReprintAllIn_ValueChanged(object sender, EventArgs e)
        {
            currBoat.sold_reprint_allIn = Convert.ToInt32(prd_ReprintAllIn.Value);
            currBoat.updatePackages();
            updatePkgDisplay();
        }

        private void prd_ReprintBase_ValueChanged(object sender, EventArgs e)
        {
            currBoat.sold_reprint_Base = Convert.ToInt32(prd_ReprintBase.Value);
            currBoat.updatePackages();
            updatePkgDisplay();
        }

        private void prd_AcrylAdd_ValueChanged(object sender, EventArgs e)
        {
            currBoat.sold_acrylicAddOn = Convert.ToInt32(prd_AcrylAdd.Value);
            currBoat.updatePackages();
            updatePkgDisplay();
        }
        #endregion Packages

        #region Update GUI

        private void updatePkgDisplay()
        {
            prd_AllIn.Value = currBoat.sold_allIn;
            prd_Base.Value = currBoat.sold_baseOnly;
            prd_Acrylic.Value = currBoat.sold_acrylicOnly;
            prd_ReprintAllIn.Value = currBoat.sold_reprint_allIn;
            prd_ReprintBase.Value = currBoat.sold_reprint_Base;
            prd_Other.Value = currBoat.otherPrints;
            prd_AcrylAdd.Value = currBoat.sold_acrylicAddOn;

            updateStatDisplay();
        }

        private void updateStatDisplay()
        {
            lbl_CashOnHand.Value = currBoat.inBank.getTotal();
            if (currBoat.sold_reprint_allIn + currBoat.sold_reprint_Base == 0)
            {
                stat_pkgsSold.Text = currBoat.pkgsSold.ToString();
            }
            else
            {
                stat_pkgsSold.Text = String.Format("{0} + {1} reprints", currBoat.pkgsSold.ToString(),
                                                   currBoat.sold_reprint_allIn + currBoat.sold_reprint_Base);
            }
            stat_pkgsNotSold.Text = currBoat.pkgsNotSold.ToString();
            stat_cashSales.Text = String.Format("{0:C}", currBoat.getCashProfit());
            stat_creditSales.Text = String.Format("{0:C}", currBoat.getCreditTotals());
            stat_expectedTotal.Text = String.Format("{0:C}", currBoat.expectedTotal);
            stat_grossProfit.Text = String.Format("{0:C}", currBoat.grossTotal);
            stat_netProfit.Text = String.Format("{0:C}", currBoat.netProfit);
            stat_perCap.Text = String.Format("{0:C}", currBoat.perCap);

            decimal diff = currBoat.getDiff();
            if (diff > 0)
            {
                lblOverSlip.Text = "Overage:";
            }
            else lblOverSlip.Text = "Slippage:";
            stat_overSlip.Text = String.Format("{0:C}", diff);
        }

        private void refreshCCs()
        {
            lbl_Amex.Value = currBoat.amEx.total;
            lbl_Visa.Value = currBoat.visa.total;
            lbl_Mastercard.Value = currBoat.mastercard.total;
            lbl_Discover.Value = currBoat.discover.total;
            lbl_DirectBill.Value = currBoat.directBill.total;
            lbl_Check.Value = currBoat.personalCheck.total;
        }

        #endregion

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            var objSender = (TextBox) sender;
            if (objSender == boatNotes)
            {
                currBoat.notes = boatNotes.Text;
            }
            else if (objSender == txt_Initials)
            {
                currBoat.employeeInitials = txt_Initials.Text;
            }
            else if (objSender == txt_SailTime)
            {
                currBoat.sailTime = txt_SailTime.Text;
                setName();
            }
        }

        public void toggleBoatLock(bool fromLoad)
        {
            if(!fromLoad)
                currBoat.isLocked = !currBoat.isLocked;

            sel_BoatSelect.Enabled = !sel_BoatSelect.Enabled;
            txt_SailTime.Enabled = !txt_SailTime.Enabled;
            if(cbx_ovrBankOut.Checked)
            {
                cbx_ovrBankOut.Enabled = !cbx_ovrBankOut.Enabled;
                bankOutAmt.Enabled = !bankOutAmt.Enabled;
            }
            else
            {
                cbx_ovrBankOut.Enabled = !cbx_ovrBankOut.Enabled;
            }
            pkgsOut.Enabled = !pkgsOut.Enabled;
            pkgsNotViewed.Enabled = !pkgsNotViewed.Enabled;
            pkgsViewedNS.Enabled = !pkgsViewedNS.Enabled;

            count_clicker.Enabled = !count_clicker.Enabled;
            count_labtech.Enabled = !count_labtech.Enabled;
            count_PAX.Enabled = !count_PAX.Enabled;

            if(cbxAllInOver.Checked)
            {
                cbxAllInOver.Enabled = !cbxAllInOver.Enabled;
                prd_AllIn.Enabled = !prd_AllIn.Enabled;
            }
            else
            {
                cbxAllInOver.Enabled = !cbxAllInOver.Enabled;
            }

            prd_Base.Enabled = !prd_Base.Enabled;
            prd_Acrylic.Enabled = !prd_Acrylic.Enabled;
            prd_ReprintAllIn.Enabled = !prd_ReprintAllIn.Enabled;
            prd_ReprintBase.Enabled = !prd_ReprintBase.Enabled;

            prd_AcrylAdd.Enabled = !prd_AcrylAdd.Enabled;

            bkI_Ones.Enabled = !bkI_Ones.Enabled;
            bkI_Fives.Enabled = !bkI_Fives.Enabled;
            bkI_Tens.Enabled = !bkI_Tens.Enabled;
            bkI_Twenties.Enabled = !bkI_Twenties.Enabled;
            bkI_Fifties.Enabled = !bkI_Fifties.Enabled;
            bkI_Hundreds.Enabled = !bkI_Hundreds.Enabled;

            bkI_Ls_Quarters.Enabled = !bkI_Ls_Quarters.Enabled;
            bkI_Rl_Quarters.Enabled = !bkI_Rl_Quarters.Enabled;
            bkI_Ls_Dimes.Enabled = !bkI_Ls_Dimes.Enabled;
            bkI_Rl_Dimes.Enabled = !bkI_Rl_Dimes.Enabled;
            bkI_Ls_Nickels.Enabled = !bkI_Ls_Nickels.Enabled;
            bkI_Rl_Nickels.Enabled = !bkI_Rl_Nickels.Enabled;
            bkI_Ls_Pennies.Enabled = !bkI_Ls_Pennies.Enabled;
            bkI_Rl_Pennies.Enabled = !bkI_Rl_Pennies.Enabled;

            if(cbxCashOverride.Checked)
            {
                cbxCashOverride.Enabled = !cbxCashOverride.Enabled;
                lbl_CashOnHand.Enabled = !lbl_CashOnHand.Enabled;
            }
            else cbxCashOverride.Enabled = !cbxCashOverride.Enabled;

            txt_Initials.Enabled = !txt_Initials.Enabled;

            //Add Buttons for Bank In:
            add_bkI_1.Enabled = !add_bkI_1.Enabled;
            add_bkI_5.Enabled = !add_bkI_5.Enabled;
            add_bkI_10.Enabled = !add_bkI_10.Enabled;
            add_bkI_20.Enabled = !add_bkI_20.Enabled;
            add_bkI_50.Enabled = !add_bkI_50.Enabled;
            add_bkI_100.Enabled = !add_bkI_100.Enabled;

            add_bkI_Ls_Q.Enabled = !add_bkI_Ls_Q.Enabled;
            add_bkI_Ls_D.Enabled = !add_bkI_Ls_D.Enabled;
            add_bkI_Ls_N.Enabled = !add_bkI_Ls_N.Enabled;
            add_bkI_Ls_P.Enabled = !add_bkI_Ls_P.Enabled;
            //Leave the CC and deposit buttons enabled so you can check the values.
        }

        private void SelectAllText(object sender, EventArgs e)
        {
            try
            {
                var objSender = (NumericUpDown) sender;
                objSender.Select(0, objSender.Text.Length);
            }
            catch
            {

            }

        }

    }
}
