using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace BoatSheet.Data
{
    [Serializable]
    class WorkDay : ISerializable
    {
        public List<Boat> dailyBoats;

        public DateTime myDate;

        public string myFile;

        public WorkDay()
        {
            dailyBoats = new List<Boat>();
            myFile = null;
            myDate = DateTime.Today;
        }

        #region SERIALIZATION

        public WorkDay(SerializationInfo info, StreamingContext context)
        {
            dailyBoats = (List<Boat>)info.GetValue("dailyBoats", typeof(List<Boat>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("dailyBoats", dailyBoats);
        }

        #endregion

        public void saveDay()
        {
            Serializer.SerializeDay(myFile, this);
        }

        public void addBoat(Boat newBoat)
        {
            dailyBoats.Add(newBoat);
        }
    }
}
