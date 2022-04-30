﻿using LaborPro.Automation.shared.config;

namespace LaborPro.Automation.shared.util
{
    public class Util
    {
        public static Dictionary<string, string> ConvertToDictionary(Table table) 
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
        public static string ReadKey(Dictionary<string, string> dictionary, string key)
        {
            if (dictionary != null)
            {
                try
                {
                    return dictionary[key];
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog(ex.Message);
                }
            }
            return null;
        }
        public static TestScenario ReadKey(Dictionary<string, TestScenario> dictionary, string key)
        {
            if (dictionary != null)
            {
                try
                {
                    return dictionary[key];
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog(ex.Message);
                }
            }
            return null;
        }
        public static string DictionaryToString(Dictionary<string, string> dictionary) 
        {
            var entries = dictionary.Select(d =>
            string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
            return "{" + string.Join(",", entries) + "}";
        }  
        public static string ProcessInputDataString(string input)
        {
            if(input != null && input.StartsWith("$"))
            {
                return ConfigReader.Read(input.Substring(1));
            }
            return input;
        } 
        public static string RemoveTagsFromGivenString(string value)
        {
            if(value != null)
            {
                System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("<[^>]*>");
                value = rx.Replace(value, "\n");
            }
            return value;
        }

    } 
}
