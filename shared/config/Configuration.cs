namespace LaborPro.Automation.shared.config
{
    public class Configuration
    {
        public static string Init(string environment)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var configFileName = $"/resources/config/{environment}.json";
            var configFilePath = projectDirectory + configFileName;
            return configFilePath;
        }
        public static string SetEnvironment()
        {
            const string defaultEnvironment = "blankdb_automation";
            var env = Environment.GetEnvironmentVariable("ENV") ?? Environment.GetEnvironmentVariable("env");
            if (env != null) return env;
            env = defaultEnvironment;
            Environment.SetEnvironmentVariable("env", env);
            return env;
        }
    }
}
