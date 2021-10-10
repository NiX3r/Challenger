using Challenger.Instances;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Utils
{
    class FileUtils
    {

        public static bool CheckDataJsonExists()
        {
            if (File.Exists("data.json"))
                return true;

            File.Create("data.json");
            return false;

        }

        public static void LoadData()
        {

            StreamReader sr = new StreamReader("data.json");
            string json = sr.ReadToEnd();
            sr.Close();

            ProgramVariables.Data = JsonConvert.DeserializeObject<DataInstance>(json);

        }

        public static void SaveData()
        {

            string json = JsonConvert.SerializeObject(ProgramVariables.Data, Formatting.Indented);

            StreamWriter sw = new StreamWriter("data.json");
            sw.Write(json);
            sw.Flush();
            sw.Close();

        }

        public static void CreateTempJson()
        {
            string json = JsonConvert.SerializeObject(ProgramVariables.Data, Formatting.Indented);

            StreamWriter sw = new StreamWriter("temp.json");
            sw.Write(json);
            sw.Flush();
            sw.Close();
        }

    }
}
