using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BorsalinoTools
{


    public class JsonWriter
    {
        private Dictionary<string,string> sections   = new Dictionary<string,string>();
        public JsonWriter()
        {

        }

        public void AddSection(string key, string value)
        {
            sections.Add(key, value);
        }

        public void WriteData()
        {

        }
    }

    public class JsonLoader
    {
        private Dictionary<string, string> sections = new Dictionary<string, string>();
        private string allString;

        public string GetSection(string key)
        {
            return sections[key];
        }

        public void LoadData()
        {

        }
    }

}