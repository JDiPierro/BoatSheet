using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BoatSheet
{
    static class Serializer
    {

        public static void SerializeObject(string filename, Boat boatToSave)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, boatToSave);
            stream.Close();
        }

        public static Boat DeSerializeObject(string filename)
        {
            Boat loadedBoat;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            loadedBoat = (Boat)bFormatter.Deserialize(stream);
            stream.Close();
            return loadedBoat;
        }

    }
}
