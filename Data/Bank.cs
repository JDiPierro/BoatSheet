using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BoatSheet
{
    [Serializable]
    public class Bank : ISerializable
    {
        public enum Denomination
        {
            ERROR,
            ONES,
            FIVES,
            TENS,
            TWENTIES,
            FIFTIES,
            HUNDREDS,
            QUARTERS_LOOSE,
            QUARTER_ROLLS,
            NICKELS_LOOSE,
            NICKEL_ROLLS,
            DIMES_LOOSE,
            DIME_ROLLS,
            PENNIES_LOOSE,
            PENNY_ROLLS
        }


        public static decimal taxRate = 0.93m;
        /*******************************************************/
        public static decimal quarterVal = 0.25m;
        public static decimal quarterRollVal = 10.0m;
        public static decimal nickelVal = 0.05m;
        public static decimal nickelRollVal = 2.0m;
        public static decimal dimeVal = 0.10m;
        public static decimal dimeRollVal = 5.0m;
        public static decimal pennyVal = 0.01m;
        public static decimal pennyRollVal = 0.50m;

        public static decimal oneVal = 1.0m;
        public static decimal fiveVal = 5.0m;
        public static decimal tenVal = 10.0m;
        public static decimal twentyVal = 20.0m;
        public static decimal fiftyVal = 50.0m;
        public static decimal hundredVal = 100.0m;

        /********************************************************/

        public static decimal saintAllInVal = 37.45m;
        public static decimal saintBaseVal = 26.75m;
        public static decimal saintAcrylOnlyVal = 32.10m;

        public static decimal minmoAllInVal = 32.10m;
        public static decimal minmoBaseVal = 21.40m;
        public static decimal minmoAcrylOnlyVal = 26.75m;

        public static decimal addOnAcrylVal = 10.70m;

        /*********************************************************/

        private int numQuarters = 0;
        private int numQuarterRolls = 0;
        private int numNickels = 0;
        private int numNickelRolls = 0;
        private int numDimes = 0;
        private int numDimeRolls = 0;
        private int numPennies = 0;
        private int numPennyRolls = 0;

        private int numOnes = 0;
        private int numFives = 0;
        private int numTens = 0;
        private int numTwenties = 0;
        private int numFifties = 0;
        private int numHundreds = 0;

        private decimal totalBank = 0.0m;

        public Bank()
        {

        }

        public Bank(SerializationInfo info, StreamingContext ctxt)
        {
            numQuarters = info.GetInt32("numQuarters");
            numQuarterRolls = info.GetInt32("numQuarterRolls");
            numNickels = info.GetInt32("numNickels");
            numNickelRolls = info.GetInt32("numNickelRolls");
            numDimes = info.GetInt32("numDimes");
            numDimeRolls = info.GetInt32("numDimeRolls");
            numPennies = info.GetInt32("numPennies");
            numPennyRolls = info.GetInt32("numPennyRolls");

            numOnes = info.GetInt32("numOnes");
            numFives = info.GetInt32("numFives");
            numTens = info.GetInt32("numTens");
            numTwenties = info.GetInt32("numTwenties");
            numFifties = info.GetInt32("numFifties");
            numHundreds = info.GetInt32("numHundreds");
            totalBank = info.GetDecimal("totalBank");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("numQuarters", numQuarters);
            info.AddValue("numQuarterRolls", numQuarterRolls);
            info.AddValue("numNickels", numNickels);
            info.AddValue("numNickelRolls", numNickelRolls);
            info.AddValue("numDimes", numDimes);
            info.AddValue("numDimeRolls", numDimeRolls);
            info.AddValue("numPennies", numPennies);
            info.AddValue("numPennyRolls", numPennyRolls);

            info.AddValue("numOnes", numOnes);
            info.AddValue("numFives", numFives);
            info.AddValue("numTens", numTens);
            info.AddValue("numTwenties", numTwenties);
            info.AddValue("numFifties", numFifties);
            info.AddValue("numHundreds", numHundreds);

            info.AddValue("totalBank", totalBank);
        }

        public decimal getTotal()
        {
            return totalBank;
        }

        public void setQuarters(int numQ)
        {
            //Remove the current number of quarters from the bank.
            totalBank -= numQuarters*quarterVal;
            //Change the number of quarters
            numQuarters = numQ;
            //Add those quarters to the bank.
            totalBank += numQuarters*quarterVal;

            //This prevents the bank from adding up.
            //Therefore the total will always represent the amount of coins we have.
        }

        public void setQuarterRolls(int numQR)
        {
            totalBank -= numQuarterRolls*quarterRollVal;
            numQuarterRolls = numQR;
            totalBank += numQuarterRolls*quarterRollVal;
        }

        public void setNickels(int inNick)
        {
            totalBank -= numNickels*nickelVal;
            numNickels = inNick;
            totalBank += numNickels*nickelVal;
        }

        public void setNickelRolls(int inRolls)
        {
            totalBank -= numNickelRolls*nickelRollVal;
            numNickelRolls = inRolls;
            totalBank += numNickelRolls*nickelRollVal;
        }

        public void setDimes(int inDimes)
        {
            totalBank -= numDimes*dimeVal;
            numDimes = inDimes;
            totalBank += numDimes*dimeVal;
        }

        public void setDimeRolls(int inRolls)
        {
            totalBank -= numDimeRolls*dimeRollVal;
            numDimeRolls = inRolls;
            totalBank += numDimeRolls*dimeRollVal;
        }

        public void setPennies(int inPennies)
        {
            totalBank -= numPennies*pennyVal;
            numPennies = inPennies;
            totalBank += numPennies*pennyVal;
        }

        public void setPennyRolls(int inRolls)
        {
            totalBank -= numPennyRolls*pennyRollVal;
            numPennyRolls = inRolls;
            totalBank += numPennyRolls*pennyRollVal;
        }

        public void setOnes(int inOnes)
        {
            totalBank -= numOnes*oneVal;
            numOnes = inOnes;
            totalBank += numOnes*oneVal;
        }

        public void setFives(int inFives)
        {
            totalBank -= numFives*fiveVal;
            numFives = inFives;
            totalBank += numFives*fiveVal;
        }

        public void setTens(int inTens)
        {
            totalBank -= numTens*tenVal;
            numTens = inTens;
            totalBank += numTens*tenVal;
        }

        public void setTwenties(int inTwenties)
        {
            totalBank -= numTwenties*twentyVal;
            numTwenties = inTwenties;
            totalBank += numTwenties*twentyVal;
        }

        public void setFifties(int inFifties)
        {
            totalBank -= numFifties*fiftyVal;
            numFifties = inFifties;
            totalBank += numFifties*fiftyVal;
        }

        public void setHundreds(int inHundreds)
        {
            totalBank -= numHundreds*hundredVal;
            numHundreds = inHundreds;
            totalBank += numHundreds*hundredVal;
        }

        public int getNumQuarters()
        {
            return numQuarters;
        }

        public int getNumQuarterRolls()
        {
            return numQuarterRolls;
        }

        public int getNumNickels()
        {
            return numNickels;
        }

        public int getNumNickelRolls()
        {
            return numNickelRolls;
        }

        public int getNumDimes()
        {
            return numDimes;
        }

        public int getNumDimeRolls()
        {
            return numDimeRolls;
        }

        public int getNumPennies()
        {
            return numPennies;
        }

        public int getNumPennyRolls()
        {
            return numPennyRolls;
        }

        public int getOnes()
        {
            return numOnes;
        }

        public int getFives()
        {
            return numFives;
        }

        public int getTens()
        {
            return numTens;
        }

        public int getTwenties()
        {
            return numTwenties;
        }

        public int getFifties()
        {
            return numFifties;
        }

        public int getHundreds()
        {
            return numHundreds;
        }

        public void setValue(Denomination denom, int value)
        {
            switch(denom)
            {
                case Denomination.QUARTERS_LOOSE:
                    setQuarters(value);
                    break;
                case Denomination.QUARTER_ROLLS:
                    setQuarterRolls(value);
                    break;
                case Denomination.NICKELS_LOOSE:
                    setNickels(value);
                    break;
                case Denomination.NICKEL_ROLLS:
                    setNickelRolls(value);
                    break;
                case Denomination.DIMES_LOOSE:
                    setDimes(value);
                    break;
                case Denomination.DIME_ROLLS:
                    setDimeRolls(value);
                    break;
                case Denomination.PENNIES_LOOSE:
                    setPennies(value);
                    break;
                case Denomination.PENNY_ROLLS:
                    setPennyRolls(value);
                    break;
                case Denomination.ONES:
                    setOnes(value);
                    break;
                case Denomination.FIVES:
                    setFives(value);
                    break;
                case Denomination.TENS:
                    setTens(value);
                    break;
                case Denomination.TWENTIES:
                    setTwenties(value);
                    break;
                case Denomination.FIFTIES:
                    setFifties(value);
                    break;
                case Denomination.HUNDREDS:
                    setHundreds(value);
                    break;
            }//End Switch
        }//End setValue

        public int getValue(Denomination denom)
        {
            switch (denom)
            {
                case Denomination.QUARTERS_LOOSE:
                    return numQuarters;
                case Denomination.QUARTER_ROLLS:
                    return numQuarterRolls;
                case Denomination.NICKELS_LOOSE:
                    return numNickels;
                case Denomination.NICKEL_ROLLS:
                    return numNickelRolls;
                case Denomination.DIMES_LOOSE:
                    return numDimes;
                case Denomination.DIME_ROLLS:
                    return numDimeRolls;
                case Denomination.PENNIES_LOOSE:
                    return numPennies;
                case Denomination.PENNY_ROLLS:
                    return numPennyRolls;
                case Denomination.ONES:
                    return numOnes;
                case Denomination.FIVES:
                    return numFives;
                case Denomination.TENS:
                    return numTens;
                case Denomination.TWENTIES:
                    return numTwenties;
                case Denomination.FIFTIES:
                    return numFifties;
                case Denomination.HUNDREDS:
                    return numHundreds;
                default:
                    return -1;
            }//End Switch
        }//End setValue
    }
}
