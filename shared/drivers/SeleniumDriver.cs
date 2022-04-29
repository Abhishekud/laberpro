using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace LaborPro.Automation.shared.drivers
{
    public class SeleniumDriver
    {
        public static readonly string DOWNLOAD_DIRECTORY_PATH = @"\downloads";
        public static readonly string csvFilePath = @"\downloads\Volume-Driver-import-template.csv";
        public static string WorkingDirectory = Environment.CurrentDirectory;
        public static string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
        public static string DownloadDirectory = ProjectDirectory + DOWNLOAD_DIRECTORY_PATH;
        public static string csvFile = ProjectDirectory + csvFilePath;
        public static ThreadLocal<IWebDriver> webDriver = new ThreadLocal<IWebDriver>();
        const string DEFAULT_BROSWER = "chrome";

        public static IWebDriver Setup(string browser)
        {
            if (browser.StartsWith("$"))
            {
                string browserParameter = Environment.GetEnvironmentVariable("browser");
                if (browserParameter == null)
                {
                    browser = DEFAULT_BROSWER;
                }
                else
                {
                    browser = browserParameter;
                }
                Console.WriteLine("Launching browser - {0}", browser);
            }
            if (webDriver.Value == null)
            {
                IWebDriver driver;

                switch (browser.ToLower())
                {
                    case "chrome":
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1200",
         "--ignore-certificate-errors", "--disable-extensions", "--no-sandbox", "--disable-dev-shm-usage");

                        driver = new ChromeDriver(options);
                        break;
                    case "Google_Chrome":
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver(GetChromeOptions());
                        break;
                    case "firefox":
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver(GetFirefoxOptions());
                        break;
                    case "edge":
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver(GetEdgeOptions());
                        break;
                    case "Microsoft_Edge":
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver(GetEdgeOptions());
                        break;
                    default:
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver(GetChromeOptions());
                        break;
                }
                webDriver.Value = driver;
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            }
            return webDriver.Value;
        }

        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            string headless = Environment.GetEnvironmentVariable("headless");
            if (headless != null && headless.ToLower().Equals("true"))
            {
                options.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1200",
                "--ignore-certificate-errors", "--disable-extensions", "--no-sandbox", "--disable-dev-shm-usage");
            }
            options.AddUserProfilePreference("download.default_directory", DownloadDirectory);
            return options;
        }

        public static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions option = new FirefoxOptions();
            string headless = Environment.GetEnvironmentVariable("headless");
            if (headless != null && headless.ToLower().Equals("true"))
            {
                option.AddArgument("--headless");
            }

            return option;
        }


        public static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            string headless = Environment.GetEnvironmentVariable("headless");
            if (headless != null && headless.ToLower().Equals("true"))
            {
                edgeOptions.AddArguments("--headless");
            }
            edgeOptions.AddUserProfilePreference("download.default_directory", DownloadDirectory);
            return edgeOptions;
        }

        public static IWebDriver Driver()
        {
            if (webDriver != null)
                return webDriver.Value;
            else
                return null;
        }

    }
}
