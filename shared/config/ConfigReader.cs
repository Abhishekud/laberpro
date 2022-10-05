using LaborPro.Automation.shared.util;
using Newtonsoft.Json;

namespace LaborPro.Automation.shared.config
{
    public class ConfigReader
    {
        private static IDictionary<string, IDictionary<string, object>>? ConfigProprties = null;
        public static readonly string DEFAULT_ENV = "blankdb_automation";
        public static readonly string CONFIG_FILE_NAME = @"/resources/config/config.json";
        
        public static void Init()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string configFilePath = projectDirectory + CONFIG_FILE_NAME;
            using StreamReader r = new(configFilePath);
            string json = r.ReadToEnd();
            ConfigProprties = JsonConvert.DeserializeObject<IDictionary<string, IDictionary<string, object>>>(json);

        }
        public static string Read(string key, string subKey="") 
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
                    Environment.SetEnvironmentVariable("env", env);
                }
                if(!string.IsNullOrEmpty(subKey))
                {
                    string prop = ConfigProprties[env.ToLower()][key].ToString();
                    if (prop == null)
                        throw new Exception($"Unable to read property - {key}");
                    IDictionary<string, string> dict = JsonConvert.DeserializeObject<IDictionary<string, string>>(prop);
                    return dict[subKey];
                }
                else
                {
                    return ConfigProprties[env.ToLower()][key].ToString();
                }
                
            } 
            catch (Exception ex)
            {
                LogWriter.WriteLog($"Unable to read property - {key} | {ex.Message}");
            }
            return key;
        }
    }
}
