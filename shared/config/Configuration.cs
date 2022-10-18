using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborPro.Automation.shared.config
{
    public class Configuration
    {
        public static string Init(string environment)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string CONFIG_FILE_NAME = $"/resources/config/{environment}.json";
            string configFilePath = projectDirectory + CONFIG_FILE_NAME;
            return configFilePath;
        }
        public static string SetEnvironment()
        {
            string defaultEnvironment = "blankdb_automation";
            string env = Environment.GetEnvironmentVariable("ENV");
            if (env == null)
            {
                env = Environment.GetEnvironmentVariable("env");
            }
            if (env == null)
            {
                env = defaultEnvironment;
                Environment.SetEnvironmentVariable("env", env);
            }
            return env;
        }
    }
}
