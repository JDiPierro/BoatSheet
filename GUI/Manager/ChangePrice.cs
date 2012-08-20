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
    public partial class ChangePrice : Form
    {
        private bool ignoreEvent;

        public ChangePrice()
        {
            InitializeComponent();

            price_AcrylicAddOn.Value = Settings.addOnAcrylVal;

            boatSelect.SelectedIndex = 1;
        }

        private void boatChanged(Object sender, EventArgs e)
        {
            getPrices();
        }

        private void getPrices()
        {
            ignoreEvent = true;
            if (boatSelect.SelectedIndex == (int)Boat.boatType.Saint)
            {
                price_AllIn.Value = Settings.saintAllInVal;
                price_BaseOnly.Value = Settings.saintBaseVal;
                price_AcrylicOnly.Value = Settings.saintAcrylOnlyVal;
            }
            else
            {
                price_AllIn.Value = Settings.minmoAllInVal;
                price_BaseOnly.Value = Settings.minmoBaseVal;
                price_AcrylicOnly.Value = Settings.minmoAcrylOnlyVal;
            }
            ignoreEvent = false;
        }

        private void valueChanged(Object sender, EventArgs e)
        {
            if (!ignoreEvent)
            {
                var objSender = (NumericUpDown) sender;

                if (objSender == price_AllIn)
                {
                    if (Boat.boatType.Saint.Equals(boatSelect.SelectedIndex))
                    {
                        Settings.saintAllInVal = objSender.Value;
                    }
                    else
                    {
                        Settings.minmoAllInVal = objSender.Value;
                    }
                }
                else if (objSender == price_BaseOnly)
                {
                    if (Boat.boatType.Saint.Equals(boatSelect.SelectedIndex))
                    {
                        Settings.saintBaseVal = objSender.Value;
                    }
                    else
                    {
                        Settings.minmoBaseVal = objSender.Value;
                    }
                }
                else if (objSender == price_AcrylicOnly)
                {
                    if (Boat.boatType.Saint.Equals(boatSelect.SelectedIndex))
                    {
                        Settings.saintAcrylOnlyVal = objSender.Value;
                    }
                    else
                    {
                        Settings.minmoAcrylOnlyVal = objSender.Value;
                    }
                }
                else
                {
                    Settings.addOnAcrylVal = objSender.Value;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
