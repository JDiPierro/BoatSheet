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

            price_AcrylicAddOn.Value = Settings.GlobalSettings.addOnAcrylVal;

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
                price_AllIn.Value = Settings.GlobalSettings.saintAllInVal;
                price_BaseOnly.Value = Settings.GlobalSettings.saintBaseVal;
                price_AcrylicOnly.Value = Settings.GlobalSettings.saintAcrylOnlyVal;
            }
            else
            {
                price_AllIn.Value = Settings.GlobalSettings.minmoAllInVal;
                price_BaseOnly.Value = Settings.GlobalSettings.minmoBaseVal;
                price_AcrylicOnly.Value = Settings.GlobalSettings.minmoAcrylOnlyVal;
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
                        Settings.GlobalSettings.saintAllInVal = objSender.Value;
                    }
                    else
                    {
                        Settings.GlobalSettings.minmoAllInVal = objSender.Value;
                    }
                }
                else if (objSender == price_BaseOnly)
                {
                    if (Boat.boatType.Saint.Equals(boatSelect.SelectedIndex))
                    {
                        Settings.GlobalSettings.saintBaseVal = objSender.Value;
                    }
                    else
                    {
                        Settings.GlobalSettings.minmoBaseVal = objSender.Value;
                    }
                }
                else if (objSender == price_AcrylicOnly)
                {
                    if (Boat.boatType.Saint.Equals(boatSelect.SelectedIndex))
                    {
                        Settings.GlobalSettings.saintAcrylOnlyVal = objSender.Value;
                    }
                    else
                    {
                        Settings.GlobalSettings.minmoAcrylOnlyVal = objSender.Value;
                    }
                }
                else
                {
                    Settings.GlobalSettings.addOnAcrylVal = objSender.Value;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Serializer.SerializeSettings(Settings.SettingsFileName, Settings.GlobalSettings);
            this.Close();
        }
    }
}
