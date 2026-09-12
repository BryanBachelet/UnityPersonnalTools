using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BorsalinoTools
{


    public class JsonWriter
    {
        private Dictionary<string, string> sections = new Dictionary<string, string>();
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

    public enum TypeData
    {
        FLOAT,
        INT,
        STRING,
        ARRAY,
        BOOLEAN,
        OBJECT,
        NULL
    }


    public class JsonData
    {
        public Dictionary<string, JsonData> values = new Dictionary<string, JsonData>();
        public List<JsonData> array = new List<JsonData>();
        public TypeData type;
        public string strValue;
        public float floatValue;
        public int intValue;
        public bool boolValue;

        public JsonData()
        {
        }

        public JsonData(TypeData type)
        {
            this.type = type;
        }


    }

    public class JsonParseTempData
    {
        bool isValue;
        bool isString;
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

        public static void Parse(string jsonData)
        {

            List<JsonData> dataList = new List<JsonData>();
            JsonData data = null;
            int lastSpecialCaseIndex = 0;

            Stack<char> specialCase = new Stack<char>();
            Stack<JsonData> dataStack = new Stack<JsonData>();
            string key = "";
            string strValue;
            bool isValue = false;
            bool inArray = false;
            for (int i = 0; i < jsonData.Length; i++)
            {

                switch (jsonData[i])
                {
                    case '{':

                        if (isValue)
                        {
                            if (inArray)
                            {
                                JsonData tempData = new JsonData(TypeData.OBJECT);
                                data.array.Add(tempData);
                                dataStack.Push(data);
                                isValue = false;
                            }
                            else
                            {
                                JsonData tempData = new JsonData(TypeData.OBJECT);
                                data.values.Add(key, tempData);
                                dataStack.Push(data);
                                data = tempData;

                            }


                            isValue = false;
                        }
                        else
                        {
                            data = new JsonData(TypeData.OBJECT);
                        }
                        break;
                    case '"':

                        if (specialCase.Count != 0 && specialCase.Peek() == '"')
                        {
                            if (isValue)
                            {
                                strValue = jsonData.Substring(lastSpecialCaseIndex, i - lastSpecialCaseIndex);
                                Debug.Log(key + ":" + strValue);
                                JsonData jsValue = new JsonData(TypeData.STRING);
                                jsValue.strValue = strValue;
                                data.values.Add(key, jsValue);
                            }
                            else
                            {
                                key = jsonData.Substring(lastSpecialCaseIndex, i - lastSpecialCaseIndex);
                                Debug.Log(key);
                            }

                            specialCase.Pop();
                        }
                        else
                        {
                            lastSpecialCaseIndex = i;
                            specialCase.Push(jsonData[i]);
                        }

                        break;

                    case ':':
                        isValue = true;
                        specialCase.Push(jsonData[i]);
                        break;

                    case ',':
                        if (specialCase.Peek() == ':')
                        {
                            specialCase.Pop();
                            isValue = false;
                        }
                        else
                        {
                            isValue = true;
                        }
                        break;
                    case '[':

                        JsonData tempArrayData = new JsonData(TypeData.ARRAY);
                        data.values.Add(key, tempArrayData);
                        dataStack.Push(data);
                        data = tempArrayData;

                        inArray = true;

                        break;

                    case ']':
                        inArray = false;
                        break;


                    case '}':
                        if (dataStack.Count != 0)
                        {
                            dataList.Add(data);
                            data = dataStack.Pop();
                        }
                        else
                        {
                            dataList.Add(data);
                        }

                        break;

                    default:
                        break;
                }

            }

            for (int i = 0; i < dataList.Count; i++)
            {
                List<string> list = dataList[i].values.Keys.ToList();
                for (int j = 0; j < list.Count; j++)
                {
                    Debug.Log(list[j] + ":" + dataList[i].values.Values.ToArray()[j].type.ToString());
                }
            }
        }

    }

}