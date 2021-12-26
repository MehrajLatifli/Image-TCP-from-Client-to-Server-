using Files_ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileHelper_ClassLibrary
{
    public static class FileHelper
    {

        public static object BinaryDeSerialize()
        {

            if (!System.IO.File.Exists("../../../Files/files.bin")) { throw new NotImplementedException(); }

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream fStream = File.OpenRead("../../../Files/files.bin"))
            {
                return formatter.Deserialize(fStream);
            }

        }

        public static void BinarySerialize(ObservableCollection<Files> files)
        {
            if (!Directory.Exists("../../../Files/"))
            {
                Directory.CreateDirectory("../../../Files");
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream fStream = new FileStream("../../../Files/files.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fStream, files);
            }


        }

        public static void JsonSerialize(ObservableCollection<Files> files)
        {
           
                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter("../../../Files/files.json", true))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                        serializer.Serialize(jw, files);
                    }
                }
          
        }

        public static void JsonDeSerialize(ObservableCollection<Files> files)
        {
            files = null;
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader("../../../Files/files.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    files = serializer.Deserialize<ObservableCollection<Files>>(jr);
                }

                foreach (var item in files)
                {
                    Console.WriteLine(item);
                }
            }
        }

       
    }
}
