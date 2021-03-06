﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
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

        public static void SerializeSettings(string filename, Settings dayToSave)
        {
            Stream stream = File.Open(filename, FileMode.Create);

            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, dayToSave);

            stream.Close();
        }

        public static Boat DeSerializeBoat(string filename)
        {
            try
            {
                Stream stream = File.Open(filename, FileMode.Open);

                var bFormatter = new BinaryFormatter();
                var loadedBoat = (Boat) bFormatter.Deserialize(stream);

                stream.Close();

                return loadedBoat;
            }
            catch
            {

            }
            return null;
        }

        public static WorkDay DeSerializeDay(string filename)
        {
            try
            {
                Stream stream = File.Open(filename, FileMode.Open);

                var bFormatter = new BinaryFormatter();
                var loadedDay = (WorkDay) bFormatter.Deserialize(stream);

                stream.Close();

                return loadedDay;
            }
            catch
            {
                
            }
            return null;
        }

        public static Settings DeSerializeSettings(string filename)
        {
            try
            {
                Stream stream = File.Open(filename, FileMode.Open);

                var bFormatter = new BinaryFormatter();
                var loadedDay = (Settings)bFormatter.Deserialize(stream);

                stream.Close();

                return loadedDay;
            }
            catch
            {

            }
            return null;
        }
    }
}
