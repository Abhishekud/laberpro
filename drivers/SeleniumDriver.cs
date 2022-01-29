using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace laberpro.drivers
{
    internal class SeleniumDriver
    {
        public static ThreadLocal<IWebDriver> webDriver = new ThreadLocal<IWebDriver>();
    
        public static IWebDriver Setup(string browser)
        {
            if(webDriver.Value==null)
            {
                IWebDriver driver;
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                Console.WriteLine("projectDirectory : {0}", projectDirectory);
                switch (browser.ToLower())
                {
                    case "chrome":
                        driver = new ChromeDriver(projectDirectory + @"/resources/web-drivers/");
                        break;
                    default:
                        driver = new ChromeDriver(projectDirectory + @"/resources/web-drivers/");
                        break;
                }
                webDriver.Value = driver;
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            return webDriver.Value;
        }

        public static IWebDriver driver()
        {
            if (webDriver != null)
                return webDriver.Value;
            else
                return null;
        }

    }
}
