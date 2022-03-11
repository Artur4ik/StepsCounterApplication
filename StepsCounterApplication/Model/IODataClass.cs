using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsCounterApplication.Model
{
    static internal class IODataClass
    {
        public static List<UserDataClass> ReadDataFromFile(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<UserDataClass> Data = (List<UserDataClass>)serializer.Deserialize(file, typeof(List<UserDataClass>));
                file.Close();
                return Data;
            }
        }
        public static void WriteDataToFile(string path, List<TableUserDataClass> data)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
                file.Close();
            }
        }
    }
}
