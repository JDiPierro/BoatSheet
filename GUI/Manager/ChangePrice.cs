using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BoatSheet.Data.Util;

namespace BoatSheet.GUI.Manager
{
    public partial class ChangePrice : Form
    {
        private bool ignoreEvent;

        public ChangePrice()
        {
            InitializeComponent();

            price_AcrylicAddOn.Value = SettingsHelper.GlobalSettings.addOnAcrylVal;

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
                price_AllIn.Value = SettingsHelper.GlobalSettings.saintAllInVal;
                price_BaseOnly.Value = SettingsHelper.GlobalSettings.saintBaseVal;
                price_AcrylicOnly.Value = SettingsHelper.GlobalSettings.saintAcrylOnlyVal;
            }
            else
            {
                price_AllIn.Value = SettingsHelper.GlobalSettings.minmoAllInVal;
                price_BaseOnly.Value = SettingsHelper.GlobalSettings.minmoBaseVal;
                price_AcrylicOnly.Value = SettingsHelper.GlobalSettings.minmoAcrylOnlyVal;
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
                        SettingsHelper.GlobalSettings.saintAllInVal = objSender.Value;
                    }
                    else
                    {
                        SettingsHelper.GlobalSettings.minmoAllInVal = objSender.Value;
                    }
                }
                else if (objSender == price_BaseOnly)
                {
                    if (Boat.boatType.Saint.Equals(boatSelect.SelectedIndex))
                    {
                        SettingsHelper.GlobalSettings.saintBaseVal = objSender.Value;
                    }
                    else
                    {
                        SettingsHelper.GlobalSettings.minmoBaseVal = objSender.Value;
                    }
                }
                else if (objSender == price_AcrylicOnly)
                {
                    if (Boat.boatType.Saint.Equals(boatSelect.SelectedIndex))
                    {
                        SettingsHelper.GlobalSettings.saintAcrylOnlyVal = objSender.Value;
                    }
                    else
                    {
                        SettingsHelper.GlobalSettings.minmoAcrylOnlyVal = objSender.Value;
                    }
                }
                else
                {
                    SettingsHelper.GlobalSettings.addOnAcrylVal = objSender.Value;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Serializer.SerializeSettings(SettingsHelper.SettingsFileName, SettingsHelper.GlobalSettings);
            this.Close();
        }
    }
}
