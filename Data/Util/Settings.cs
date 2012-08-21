using System;
using System.Runtime.Serialization;

namespace BoatSheet
{
    [Serializable]
    class Settings : ISerializable
    {
        public decimal saintAllInVal;
        public decimal saintBaseVal;
        public decimal saintAcrylOnlyVal;

        public decimal minmoAllInVal;
        public decimal minmoBaseVal;
        public decimal minmoAcrylOnlyVal;

        public decimal addOnAcrylVal;

        public string lastSaveLoc;

        public string defaultSaveLoc;

        public Settings()
        {
            saintAllInVal = 37.45m;
            saintBaseVal = 26.75m;
            saintAcrylOnlyVal = 32.10m;

            minmoAllInVal = 32.10m;
            minmoBaseVal = 21.40m;
            minmoAcrylOnlyVal = 26.75m;

            addOnAcrylVal = 10.70m;

            lastSaveLoc = String.Empty;

            defaultSaveLoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public Settings(SerializationInfo info, StreamingContext context)
        {
            saintAllInVal = info.GetDecimal("saintAllInVal");
            saintBaseVal = info.GetDecimal("saintBaseVal");
            saintAcrylOnlyVal = info.GetDecimal("saintAcrylOnlyVal");

            minmoAllInVal = info.GetDecimal("minmoAllInVal");
            minmoBaseVal = info.GetDecimal("minmoBaseVal");
            minmoAcrylOnlyVal = info.GetDecimal("minmoAcrylOnlyVal");

            addOnAcrylVal = info.GetDecimal("addOnAcrylVal");

            lastSaveLoc = info.GetString("lastSaveLoc");

            defaultSaveLoc = info.GetString("defaultSaveLoc");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("saintAllInVal", saintAllInVal);
            info.AddValue("saintBaseVal", saintBaseVal);
            info.AddValue("saintAcrylOnlyVal", saintAcrylOnlyVal);

            info.AddValue("minmoAllInVal", minmoAllInVal);
            info.AddValue("minmoBaseVal", minmoBaseVal);
            info.AddValue("minmoAcrylOnlyVal", minmoAcrylOnlyVal);

            info.AddValue("addOnAcrylVal", addOnAcrylVal);

            info.AddValue("lastSaveLoc", lastSaveLoc);

            info.AddValue("defaultSaveLoc", defaultSaveLoc);
        }

        public void setPrice(Boat.boatType boat, Boat.packageType package, decimal price)
        {
            if(boat == Boat.boatType.NONE)
            {
                if(package == Boat.packageType.ACRYLIC_ADDON)
                {
                    addOnAcrylVal = price;
                }
            }
            else if (boat == Boat.boatType.Saint)
            {
                switch(package)
                {
                    case Boat.packageType.ALL_IN:
                        saintAllInVal = price;
                        break;
                    case Boat.packageType.BASE_ONLY:
                        saintBaseVal = price;
                        break;
                    case Boat.packageType.ACRYLIC_ONLY:
                        saintAcrylOnlyVal = price;
                        break;
                }
            }
            else
            {
                switch (package)
                {
                    case Boat.packageType.ALL_IN:
                        minmoAllInVal = price;
                        break;
                    case Boat.packageType.BASE_ONLY:
                        minmoBaseVal = price;
                        break;
                    case Boat.packageType.ACRYLIC_ONLY:
                        minmoAcrylOnlyVal = price;
                        break;
                }
            }
        }

        //TODO: Implement
        public decimal getPrice(Boat.boatType boat, Boat.packageType package)
        {
            if (boat == Boat.boatType.NONE)
            {
                if (package == Boat.packageType.ACRYLIC_ADDON)
                {
                    return addOnAcrylVal;
                }
            }
            else if (boat == Boat.boatType.Saint)
            {
                switch (package)
                {
                    case Boat.packageType.ALL_IN:
                        return saintAllInVal;
                    case Boat.packageType.BASE_ONLY:
                        return saintBaseVal;
                    case Boat.packageType.ACRYLIC_ONLY:
                        return saintAcrylOnlyVal;
                }
            }
            else
            {
                switch (package)
                {
                    case Boat.packageType.ALL_IN:
                        return minmoAllInVal;
                    case Boat.packageType.BASE_ONLY:
                        return minmoBaseVal;;
                    case Boat.packageType.ACRYLIC_ONLY:
                        return minmoAcrylOnlyVal;
                }
            }
            return -999.0m;
        }

        
    }
}
