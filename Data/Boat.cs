using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BoatSheet
{
    [Serializable]
    public class Boat : ISerializable
    {
        /**************************/

        public enum boatType
        {
            Saint,
            Minne,
            Mohican,
            NONE
        }

        public enum packageType
        {
            ALL_IN,
            BASE_ONLY,
            ACRYLIC_ONLY,
            ACRYLIC_ADDON,
        }

        [Serializable]
        public struct NonCashAsset
        {
            public int numAllins;
            public int numBaseOnly;
            public int numAcrylicAddOn;
            public int numAcrylicOnly;
            public decimal otherValue;

            public decimal total;
        }

        public DateTime date { get; set;}
        public boatType boatName { get; set;}
        public string sailTime { get; set; }
        public decimal bankOut { get; set; }

        public int pkgsOut { get; set; }
        public int pkgsNotViewed { get; set; }
        public int pkgsViewedNS { get; set; }

        public int clicker { get; set; }
        public int headcount { get; set; }
        public int paxCount { get; set; }

        public decimal AllInVal { get; set; }
        public decimal BaseVal { get; set; }
        public decimal AcrylOnlyVal { get; set; }

        public int sold_allIn { get; set; }
        public int sold_baseOnly { get; set; }
        public int sold_acrylicOnly { get; set; }
        public int sold_reprint_allIn { get; set; }
        public int sold_reprint_Base { get; set; }
        public int sold_acrylicAddOn { get; set; }
        public int missingPackages { get; set; }

        public int pkgsSold { get; set; }
        public int pkgsNotSold { get; set; }

        public int otherPrints { get; set; }
        public decimal otherValue { get; set; }

        public bool override_AllInCount { get; set; }
        public bool override_CashAmt { get; set; }

        public Bank inBank;
        public Bank depositBank;

        public decimal expectedTotal;
        public decimal actualTotal;
        public decimal grossTotal;
        public decimal netProfit;
        public decimal perCap;

        public NonCashAsset amEx;
        public NonCashAsset visa;
        public NonCashAsset mastercard;
        public NonCashAsset discover;
        public NonCashAsset directBill;
        public NonCashAsset personalCheck;

        public string notes;
        public string employeeInitials;

        public bool isLocked;

        public Boat()
        {
            clearBoat();
            inBank = new Bank();
            depositBank = new Bank();
            boatName = boatType.Minne;
            determinePrices(boatName);
            date = DateTime.Today;
        }

        public Boat(boatType inBoat)
        {
            clearBoat();
            inBank = new Bank();
            depositBank = new Bank();

            determinePrices(inBoat);
            date = DateTime.Today;
        }

        #region SERIALIZATION

        public Boat(SerializationInfo info, StreamingContext ctxt)
        {
            date = info.GetDateTime("date");
            boatName = (boatType)info.GetValue("boatName",typeof(boatType));
            sailTime = info.GetString("sailTime");
            bankOut = info.GetDecimal("bankOut");

            pkgsOut = info.GetInt32("pkgsOut");
            pkgsNotViewed = info.GetInt32("pkgsNotViewed");
            pkgsViewedNS = info.GetInt32("pkgsViewedNS");

            clicker = info.GetInt32("clicker");
            headcount = info.GetInt32("headcount");
            paxCount = info.GetInt32("paxCount");

            AllInVal = info.GetDecimal("AllInVal");
            BaseVal = info.GetDecimal("BaseVal");
            AcrylOnlyVal = info.GetDecimal("AcrylOnlyVal");

            sold_allIn = info.GetInt32("sold_allIn");
            sold_baseOnly = info.GetInt32("sold_baseOnly");
            sold_acrylicOnly = info.GetInt32("sold_acrylicOnly");
            sold_reprint_allIn = info.GetInt32("sold_reprint_allIn");
            sold_reprint_Base = info.GetInt32("sold_reprint_Base");
            sold_acrylicAddOn = info.GetInt32("sold_acrylicAddOn");
            missingPackages = info.GetInt32("missingPackages");

            pkgsSold = info.GetInt32("pkgsSold");
            pkgsNotSold = info.GetInt32("pkgsNotSold");

            otherPrints = info.GetInt32("otherPrints");
            otherValue = info.GetDecimal("otherValue");

            override_AllInCount = info.GetBoolean("override_AllInCount");
            override_CashAmt = info.GetBoolean("override_AllInCount");

            inBank = (Bank)info.GetValue("inBank",typeof(Bank));
            depositBank = (Bank)info.GetValue("depositBank", typeof(Bank));

            expectedTotal = info.GetDecimal("expectedTotal");
            actualTotal = info.GetDecimal("actualTotal");
            grossTotal = info.GetDecimal("grossTotal");
            netProfit = info.GetDecimal("netProfit");
            perCap = info.GetDecimal("perCap");
            
            amEx = (NonCashAsset)info.GetValue("amEx",typeof(NonCashAsset));
            visa = (NonCashAsset)info.GetValue("visa", typeof(NonCashAsset));
            mastercard = (NonCashAsset)info.GetValue("mastercard", typeof(NonCashAsset));
            discover = (NonCashAsset)info.GetValue("discover", typeof(NonCashAsset));
            directBill = (NonCashAsset)info.GetValue("directBill", typeof(NonCashAsset));
            personalCheck = (NonCashAsset)info.GetValue("personalCheck", typeof(NonCashAsset));

            notes = info.GetString("notes");
            employeeInitials = info.GetString("employeeInitials");

            isLocked = info.GetBoolean("isLocked");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("date", date);
            info.AddValue("boatName", boatName);
            info.AddValue("sailTime", sailTime);
            info.AddValue("bankOut", bankOut);

            info.AddValue("pkgsOut", pkgsOut);
            info.AddValue("pkgsNotViewed", pkgsNotViewed);
            info.AddValue("pkgsViewedNS", pkgsViewedNS);

            info.AddValue("clicker", clicker);
            info.AddValue("headcount", headcount);
            info.AddValue("paxCount", paxCount);

            info.AddValue("AllInVal", AllInVal);
            info.AddValue("BaseVal", BaseVal);
            info.AddValue("AcrylOnlyVal", AcrylOnlyVal);

            info.AddValue("sold_allIn", sold_allIn);
            info.AddValue("sold_baseOnly", sold_baseOnly);
            info.AddValue("sold_acrylicOnly", sold_acrylicOnly);
            info.AddValue("sold_reprint_allIn", sold_reprint_allIn);
            info.AddValue("sold_reprint_Base", sold_reprint_Base);
            info.AddValue("sold_acrylicAddOn", sold_acrylicAddOn);
            info.AddValue("missingPackages", missingPackages);

            info.AddValue("pkgsSold", pkgsSold);
            info.AddValue("pkgsNotSold", pkgsNotSold);

            info.AddValue("otherPrints", otherPrints);
            info.AddValue("otherValue", otherValue);

            info.AddValue("override_AllInCount", override_AllInCount);
            info.AddValue("override_CashAmt", override_CashAmt);

            info.AddValue("inBank", inBank);
            info.AddValue("depositBank", depositBank);

            info.AddValue("expectedTotal", expectedTotal);
            info.AddValue("actualTotal", actualTotal);
            info.AddValue("grossTotal", grossTotal);
            info.AddValue("netProfit", netProfit);
            info.AddValue("perCap", perCap);
            
            info.AddValue("amEx", amEx);
            info.AddValue("visa", visa);
            info.AddValue("mastercard", mastercard);
            info.AddValue("discover", discover);
            info.AddValue("directBill", directBill);
            info.AddValue("personalCheck", personalCheck);

            info.AddValue("notes", notes);
            info.AddValue("employeeInitials", employeeInitials);

            info.AddValue("isLocked", isLocked);
        }

        #endregion

        public void determinePrices(int inBoat)
        {
            if ((boatType)inBoat == boatType.Saint)
            {
                AllInVal = Settings.GlobalSettings.saintAllInVal;
                BaseVal = Settings.GlobalSettings.saintBaseVal;
                AcrylOnlyVal = Settings.GlobalSettings.saintAcrylOnlyVal;
                bankOut = 150.0m;
            }
            else
            {
                AllInVal = Settings.GlobalSettings.minmoAllInVal;
                BaseVal = Settings.GlobalSettings.minmoBaseVal;
                AcrylOnlyVal = Settings.GlobalSettings.minmoAcrylOnlyVal;
                if ((boatType)inBoat == boatType.Minne)
                    bankOut = 300.0m;
                else bankOut = 150.0m;
            }
            otherValue = 0.0m;
            updateTotals();
        }

        public void lockBoat()
        {
            isLocked = true;
        }

        public void unlockBoat()
        {
            isLocked = false;
        }

        public void determinePrices(boatType inBoat)
        {
            if (inBoat == boatType.Minne)
            {
                AllInVal = Settings.GlobalSettings.saintAllInVal;
                BaseVal = Settings.GlobalSettings.saintBaseVal;
                AcrylOnlyVal = Settings.GlobalSettings.saintAcrylOnlyVal;
                bankOut = 150.0m;
            }
            else
            {
                AllInVal = Settings.GlobalSettings.minmoAllInVal;
                BaseVal = Settings.GlobalSettings.minmoBaseVal;
                AcrylOnlyVal = Settings.GlobalSettings.minmoAcrylOnlyVal;
                if (inBoat == boatType.Minne)
                    bankOut = 300.0m;
                else bankOut = 150.0m;
            }
            otherValue = 0.0m;
            updateTotals();
        }

        /// <summary>
        /// Set all values in the Boat to 0, or their default value.
        /// Also used for initialization.
        /// </summary>
        public void clearBoat()
        {
            date = DateTime.Today;
            boatName = boatType.Minne;
            sailTime = "notime";
            bankOut = 0.0m;

            pkgsOut = 0;
            pkgsNotViewed = 0;
            pkgsViewedNS = 0;

            clicker = 0;
            headcount = 0;
            paxCount = 0;

            AllInVal = 0.0m;
            BaseVal = 0.0m;
            AcrylOnlyVal = 0.0m;

            sold_allIn = 0;
            sold_baseOnly = 0;
            sold_acrylicOnly = 0;
            sold_reprint_allIn = 0;
            sold_reprint_Base = 0;
            sold_acrylicAddOn = 0;
            missingPackages = 0;

            otherPrints = 0;
            otherValue = 0.0m;

            override_AllInCount = false;
            override_CashAmt = false;

            inBank = new Bank();

            expectedTotal = 0.0m;
            actualTotal = 0.0m;
            grossTotal = 0.0m;
            netProfit = 0.0m;
            perCap = 0.0m;

            amEx = new NonCashAsset();
            visa = new NonCashAsset();
            mastercard = new NonCashAsset();
            discover = new NonCashAsset();
            directBill = new NonCashAsset();
            personalCheck = new NonCashAsset();

            notes = String.Empty;
            isLocked = false;
        }

        /*********************UPDATE LOGIC***************/

        public void updateTotals()
        {
            expectedTotal = 0.0m;
            expectedTotal += (sold_allIn + sold_reprint_allIn) * AllInVal;
            expectedTotal += (sold_baseOnly + sold_reprint_Base) * BaseVal;
            expectedTotal += sold_acrylicOnly * AcrylOnlyVal;
            expectedTotal += sold_acrylicAddOn * Settings.GlobalSettings.addOnAcrylVal;
            expectedTotal += otherPrints * otherValue;

            actualTotal = 0.0m;

            actualTotal = inBank.getTotal();
            actualTotal += calcCCTotal(amEx);
            actualTotal += calcCCTotal(visa);
            actualTotal += calcCCTotal(mastercard);
            actualTotal += calcCCTotal(discover);
            actualTotal += calcCCTotal(directBill);
            actualTotal += calcCCTotal(personalCheck);

            grossTotal = actualTotal - bankOut;
            netProfit = grossTotal*Bank.taxRate;

            calcPerCap();
        }

        public void calcPerCap()
        {
            if(paxCount != 0)
            {
                perCap = netProfit/paxCount;
            }
            else if( headcount != 0)
            {
                perCap = netProfit/headcount;
            }
            else if(clicker != 0)
            {
                perCap = netProfit/clicker;
            }
            else
            {
                perCap = 0.0m;
            }
        }

        /// <summary>
        /// If the AllIn manual override is NOT enabled this will count the number of all in packages.
        /// If the AlLin manual override IS enabled this will count the number of missing packages.
        /// 
        /// updateTotal() is called at the end and should not be called manually.
        /// </summary>
        public void updatePackages()
        {
            if (override_AllInCount)
            {
                missingPackages = 0;

                missingPackages = pkgsOut;
                missingPackages -= pkgsNotViewed;
                missingPackages -= pkgsViewedNS;

                missingPackages -= sold_allIn;
                missingPackages -= sold_baseOnly;
                missingPackages -= sold_acrylicOnly;
                missingPackages -= otherPrints;
            }
            else sold_allIn = pkgsOut - pkgsNotViewed - pkgsViewedNS - sold_baseOnly - sold_acrylicOnly - otherPrints;

            pkgsSold = sold_allIn + sold_baseOnly;

            pkgsNotSold = pkgsNotViewed + pkgsViewedNS;

            updateTotals();
        }

        private decimal calcCCTotal(NonCashAsset CC)
        {
            decimal tempTotal = 0.0m;
            tempTotal += CC.numAllins*AllInVal;
            tempTotal += CC.numBaseOnly*BaseVal;
            tempTotal += CC.numAcrylicOnly*AcrylOnlyVal;
            tempTotal += CC.numAcrylicAddOn * Settings.GlobalSettings.addOnAcrylVal;
            tempTotal += CC.otherValue;

            return tempTotal;
        }

        public decimal getCreditTotals()
        {
            decimal tempTotal = 0.0m;

            tempTotal += calcCCTotal(amEx);
            tempTotal += calcCCTotal(visa);
            tempTotal += calcCCTotal(mastercard);
            tempTotal += calcCCTotal(discover);

            return tempTotal;
        }

        public decimal getCashProfit()
        {
            return inBank.getTotal() - bankOut;
        }

        public decimal getDiff()
        {
            return actualTotal - expectedTotal - bankOut;
        }
        
    }
}
