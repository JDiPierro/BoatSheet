using System;

namespace BoatSheet
{
    static class Settings
    {
        public enum packageType
        {
            ALL_IN,
            BASE_ONLY,
            ACRYLIC_ONLY,
            ACRYLIC_ADDON,
        }

        //TODO: ALL VARIABLES MUST BE INSTANTIATED INSIDE THE CONSTURCTOR FOR SERIALZIATION.

        public static decimal saintAllInVal = 37.45m;
        public static decimal saintBaseVal = 26.75m;
        public static decimal saintAcrylOnlyVal = 32.10m;

        public static decimal minmoAllInVal = 32.10m;
        public static decimal minmoBaseVal = 21.40m;
        public static decimal minmoAcrylOnlyVal = 26.75m;

        public static decimal addOnAcrylVal = 10.70m;

        public static string lastSaveLoc = String.Empty;

        public static string defaultSaveLoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void setPrice(Boat.boatType boat, packageType package, decimal price)
        {
            if(boat == Boat.boatType.NONE)
            {
                if(package == packageType.ACRYLIC_ADDON)
                {
                    addOnAcrylVal = price;
                }
            }
            else if (boat == Boat.boatType.Saint)
            {
                switch(package)
                {
                    case packageType.ALL_IN:
                        saintAllInVal = price;
                        break;
                    case packageType.BASE_ONLY:
                        saintBaseVal = price;
                        break;
                    case packageType.ACRYLIC_ONLY:
                        saintAcrylOnlyVal = price;
                        break;
                }
            }
            else
            {
                switch (package)
                {
                    case packageType.ALL_IN:
                        minmoAllInVal = price;
                        break;
                    case packageType.BASE_ONLY:
                        minmoBaseVal = price;
                        break;
                    case packageType.ACRYLIC_ONLY:
                        minmoAcrylOnlyVal = price;
                        break;
                }
            }
        }

        //TODO: Implement
        public static decimal getPrice(Boat.boatType boat, packageType package)
        {
            //
            return 0.0m;
        }

    }
}
