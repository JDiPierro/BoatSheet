using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BoatSheet.Data;

namespace BoatSheet
{
    static class Serializer
    {

        public static void SerializeBoat(string filename, Boat boatToSave)
        {
            Stream stream = File.Open(filename, FileMode.Create);

            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, boatToSave);

            stream.Close();
        }

        public static void SerializeDay(string filename, WorkDay dayToSave)
        {
            Stream stream = File.Open(filename, FileMode.Create);

            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, dayToSave);

            stream.Close();
        }

        public static Boat DeSerializeBoat(string filename)
        {
            Stream stream = File.Open(filename, FileMode.Open);

            var bFormatter = new BinaryFormatter();
            Boat loadedBoat = (Boat)bFormatter.Deserialize(stream);

            stream.Close();

            return loadedBoat;
        }

        public static WorkDay DeSerializeDay(string filename)
        {
            Stream stream = File.Open(filename, FileMode.Open);

            var bFormatter = new BinaryFormatter();
            WorkDay loadedDay = (WorkDay)bFormatter.Deserialize(stream);

            stream.Close();

            return loadedDay;
        }
    }
}
