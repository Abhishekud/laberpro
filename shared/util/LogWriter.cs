using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LaborPro.Automation.shared.util
{
    public class LogWriter
    {
        private static ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();
        const string LOG_FILE_PATH = @"/report/log.txt";
        private static string logFilePath = null;
        public static void WriteLog(string logMessage)
        {
            try
            {
                lock_.EnterWriteLock();
                using (StreamWriter w = File.AppendText(logFilePath))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0} {1} -> {2} : {3}", 
                    DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString(), 
                    Thread.CurrentThread.Name, 
                    logMessage);
                Console.WriteLine("{0} {1} -> {2} : {3}",
                    DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString(),
                    Thread.CurrentThread.Name,
                    logMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void LogCleanup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            logFilePath = projectDirectory + LOG_FILE_PATH;
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }
            File.Create(logFilePath);
        }
    }
}
