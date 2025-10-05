using System;
using System.IO;
using System.Text;

namespace BorsalinoTools
{

    public struct CsvMetaInfo
    {
        public string path;
        public char sepearator;
        public bool hasColumnName;
        public bool hasId;
        public bool hasRowNames;
    }

    [System.Serializable]
    public struct CsvInfo
    {
        public string[][] elements;
        public bool hasColumnName;
        public bool hasId;
        public bool hasRowNames;
    }


    public static class CsvTools
    {
        public static CsvInfo ReadCSVFile(CsvMetaInfo csvMetaInfo)
        {
           
            if (!File.Exists(csvMetaInfo.path))
            {
                throw new FileNotFoundException("The file doesnt exist");
            }

            string extension = Path.GetExtension(csvMetaInfo.path);
            if (extension != ".csv")
            {
                throw new FileNotFoundException("The file isn't a csv file");
            }
            CsvInfo csvInfo = new CsvInfo();
            string allText = File.ReadAllText(csvMetaInfo.path);


            string[] lines = allText.Split("\r\n");

            csvInfo.elements = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                csvInfo.elements[i] = lines[i].Split(csvMetaInfo.sepearator);
            }

            csvInfo.hasId = csvMetaInfo.hasId;
            csvInfo.hasColumnName = csvMetaInfo.hasColumnName;
            csvInfo.hasRowNames = csvMetaInfo.hasRowNames;

            return csvInfo;

        }

        public static string[] GetColumnName(CsvInfo info)
        {
            if (info.elements == null) { throw new NullReferenceException("Empty CSV file"); }

            if (!info.hasColumnName) return null;

            return info.elements[0];
        }

        public static string[] GetColumnValue(string columnName, CsvInfo info)
        {
            if (info.elements == null) { throw new NullReferenceException("Empty CSV file"); }

            for (int i = 0; i < info.elements[0].Length; i++)
            {
                if (info.elements[0][i] == columnName)
                    return _GetColumnValue(i, info);
            }


            throw new Exception("Couldnt file the column name");
            return null;
        }

        public static string[] GetColumnValue(int indexColumn, CsvInfo info)
        {
            if (info.elements == null) 
            { throw new NullReferenceException("Empty CSV file"); }

            if (indexColumn >= info.elements[0].Length ) 
            { throw new Exception("Index column outside the array"); }
            
            return _GetColumnValue(indexColumn, info);
        }


        private static string[] _GetColumnValue(int index, CsvInfo info)
        {
            int startingIndex = info.hasColumnName ? 1 : 0;
            string[] columnElement = new string[info.elements.Length - startingIndex];
            for (int i = startingIndex; i < (columnElement.Length+ startingIndex); i++)
            {
                columnElement[i-1] = info.elements[i][index];
            }

            return columnElement;
        }


        private static string[] GetRowValue(string rowName, CsvInfo info, int indexRowName = 0)
        {

            if (info.elements == null) { throw new NullReferenceException("Empty CSV file"); }

            for (int i = 0; i < info.elements[0].Length; i++)
            {
                if (info.elements[i][indexRowName] == rowName)
                    return _GetRowValues(i, info);
            }

            throw new Exception("Couldnt file the row name");
            return null;

        }

        private static string[] GetRowValue(int index, CsvInfo info)
        {
            if (info.elements == null)
                throw new NullReferenceException("Empty CSV file");

            return _GetRowValues(index, info);
        }


        private static string[] _GetRowValues(int index, CsvInfo info)
        {
            return info.elements[index];
        }
    }


}