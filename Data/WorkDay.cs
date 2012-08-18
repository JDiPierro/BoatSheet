using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BoatSheet.Data
{
    [Serializable]
    class WorkDay : ISerializable
    {
        public List<Boat> dailyBoats;

        public WorkDay()
        {
            dailyBoats = new List<Boat>;
        }

        #region SERIALIZATION

        public WorkDay(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("dailyBoats", dailyBoats);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            dailyBoats = (List<Boat>)info.GetValue("dailyBoats",typeof(List<Boat>);
        }

        #endregion

        public void addBoat(Boat newBoat)
        {
            dailyBoats.Add(newBoat);
        }
    }
}
