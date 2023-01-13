﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace prac12
{
    internal class y
    {
        public static T deserialize<T>(string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = "";
            if (File.Exists(desktop + "\\" + FileName))
                json = File.ReadAllText(desktop + "\\" + FileName);
            else
            {
                File.Create(desktop + "\\" + FileName);
                json = File.ReadAllText(desktop + "\\" + FileName);
            }
            T notes = JsonConvert.DeserializeObject<T>(json);
            return notes;
        }
        public static List<Notes> Notes_list = y.deserialize<List<Notes>>("Notes.json");
        public static void serialize<T>(T workers, string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(workers);
            if (File.Exists(desktop + "\\" + FileName))
                File.WriteAllText(desktop + "\\" + FileName, json);
            else
            {
                File.Create(desktop + "\\" + FileName);
                File.WriteAllText(desktop + "\\" + FileName, json);
            }
        }
    }
}
