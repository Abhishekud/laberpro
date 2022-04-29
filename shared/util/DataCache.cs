using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborPro.Automation.shared.util
{
    public class DataCache
    {
        private static ThreadLocal<Dictionary<string,string>> cache = new ThreadLocal<Dictionary<string, string>>();
        
        public static void Save(string key, string val)
        {
            cache.Value[key] = val;
        }
        public static string Read(string key) 
        {
            try
            {
                return cache.Value[key];
            } 
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);                      
            }
            return key;
        }
    }
}
