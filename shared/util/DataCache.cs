namespace LaborPro.Automation.shared.util
{
    public class DataCache
    {
        private static ThreadLocal<Dictionary<string, string>> cache = new ThreadLocal<Dictionary<string, string>>();

        public static void Save(string key, string val)
        {
            if (cache.Value == null)
            {
                cache.Value = new Dictionary<string, string>();
            }
            cache.Value.Add(key, val);
        }
        public static string Read(string key)
        {
            try
            {
                if (cache.Value.ContainsKey(key))
                    return cache.Value[key];
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
            }
            return key;
        }

        public static string SaveWithAppendedRandomString(string value)
        {
            var appender = Path.GetRandomFileName();
            var updatedValue = $"{value} {appender}";
            Save(value, updatedValue);
            return updatedValue;
        }
    }
}
