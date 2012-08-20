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

        public WorkDay()
        {
            dailyBoats = new List<Boat>();
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
            SaveFileDialog fld = new SaveFileDialog();
            fld.AddExtension = true;
            if (Settings.lastSaveLoc == null)
                fld.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                fld.InitialDirectory = Settings.lastSaveLoc;
            fld.FileName = String.Format("{0}", DateTime.Today.ToString("YYYY-mm-dd"));
            fld.DefaultExt = "day";
            fld.Filter = "Day Data (*.day)|*.day|All files (*.*)|*.*";

            string loc;
            if (fld.ShowDialog() == DialogResult.OK)
            {
                loc = fld.FileName;
                Serializer.SerializeDay(loc, this);
                Settings.lastSaveLoc = loc;
            }
        }

        public void addBoat(Boat newBoat)
        {
            dailyBoats.Add(newBoat);
        }
    }
}
