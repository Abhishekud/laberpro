using LaborPro.Automation.shared.util;
using Newtonsoft.Json;

namespace LaborPro.Automation.shared.config
{
    public class ConfigReader
    {
        public static Dictionary<string, Dictionary<string, string>>? ConfigProprties = null;
        public static readonly string DEFAULT_ENV = "uat";
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
                    env = Environment.GetEnvironmentVariable("env");
                }
                if(env == null)
                {
                    env = DEFAULT_ENV;
                }
                Console.WriteLine("Reading Configuration Properties - {0} => {1}", key, ConfigProprties[env.ToLower()][key]);
                return ConfigProprties[env.ToLower()][key];
            } 
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
            }
            return key;
        } 
    }
}
