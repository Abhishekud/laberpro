using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborpro.util
{
    public class ConfigReader
    {
        public static Dictionary<string, Dictionary<string, string>>? ConfigProprties = null;
        public static readonly string DEFAULT_ENV = "bits_azure";
        public static readonly string CONFIG_FILE_NAME = @"/resources/config/config.json";
        
        public static void Init()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string configFilePath = projectDirectory + CONFIG_FILE_NAME;
            using (StreamReader r = new StreamReader(configFilePath))
            {
                string json = r.ReadToEnd();
                ConfigProprties = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            }
            
        }
        public static string Read(string key) 
        {
            try
            {
                if (ConfigProprties == null)
                {
                    Init();
                }
                string env = Environment.GetEnvironmentVariable("ENV");
                if(env == null)
                {
                    env = DEFAULT_ENV;
                }
                Console.WriteLine("Reading Configuration Properties - {0} => {1}", key, ConfigProprties[env.ToLower()][key]);
                return ConfigProprties[env][key];
            } 
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
            }
            return key;
        } 
    }
}
