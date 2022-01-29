using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using laberpro.drivers;
using TechTalk.SpecFlow;

namespace laberpro.hooks
{
    [Binding]
    public sealed class BaseClass
    {
        private static string _ReportDirectory = @"/report/";
        private static string _ReportScreenshotDirectory = @"/report/screenshots/";
        private static ScenarioContext _ScenarioContext;
        private static ExtentReports _ExtentsReports;
        private static ExtentHtmlReporter _ExtentHtmlReporter;
        private static ExtentTest _Feature;
        private static ExtentTest _Scenario;
        public static ThreadLocal<Boolean> _AttachScreenshot = new ThreadLocal<Boolean>();

        public static string GetProjectDirectoryPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine("Project base directory path : {0}", projectDirectory);
            return projectDirectory;
        }

        [BeforeTestRun]
        public static void InitExtentReports()
        {
            Console.WriteLine("projectDirectory : {0}", GetProjectDirectoryPath());
            ReportDirectoryCleanup(GetProjectDirectoryPath() + _ReportDirectory);
            _ExtentHtmlReporter = new ExtentHtmlReporter(GetProjectDirectoryPath() + _ReportDirectory + "TestResults.Html");
            _ExtentsReports = new ExtentReports();
            _ExtentsReports.AttachReporter(_ExtentHtmlReporter);

        }

        public static void ReportDirectoryCleanup(String directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                DirectoryInfo di = new DirectoryInfo(directoryPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Directory.Delete(directoryPath);
            }
            Directory.CreateDirectory(directoryPath);
            Directory.CreateDirectory(directoryPath+ "/screenshots");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _Feature = _ExtentsReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _Scenario = _Feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            _AttachScreenshot.Value = false;
        }

        public BaseClass(ScenarioContext scenarioContext) => _ScenarioContext = scenarioContext;

        public static void OpenBrowser(string browser)
        {
            SeleniumDriver.Setup(browser);
        }

        public static void CloseDriver()
        {
            Console.WriteLine("Selenium WebDriver Quit..");
            if (SeleniumDriver.webDriver.Value != null)
            {
                SeleniumDriver.webDriver.Value.Quit();
            }
        }

        public static void TakeScreenshot(string fileName)
        {
            if(null!= SeleniumDriver.webDriver.Value)
            {
                Screenshot ss = ((ITakesScreenshot)SeleniumDriver.webDriver.Value).GetScreenshot();
                ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            }
        }

        public static void CreateNode<T>() where T : IGherkinFormatterModel 
        {
            string scenarioName = _ScenarioContext.ScenarioInfo.Title.Replace(" ", "_").Replace(".", "_");
            if (_ScenarioContext.TestError!=null)
            {
                long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                string screenshotName = GetProjectDirectoryPath() + _ReportScreenshotDirectory + timestamp + "_"+ scenarioName + ".png";
                TakeScreenshot(screenshotName);
                _Scenario.CreateNode<T>(_ScenarioContext.StepContext.StepInfo.Text).Fail
                    (_ScenarioContext.TestError.Message + "\n" + _ScenarioContext.TestError.StackTrace)
                    .AddScreenCaptureFromPath(screenshotName);
            }
            else
            {
                if(_AttachScreenshot.Value)
                {
                    long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                    string screenshotName = GetProjectDirectoryPath() + _ReportScreenshotDirectory + timestamp + "_" + scenarioName + ".png";
                    TakeScreenshot(screenshotName);
                    _Scenario.CreateNode<T>(_ScenarioContext.StepContext.StepInfo.Text).Pass("").AddScreenCaptureFromPath(screenshotName);
                } else
                {
                    _Scenario.CreateNode<T>(_ScenarioContext.StepContext.StepInfo.Text).Pass("");
                }
            }
        }
    
        [AfterStep]
        public void AfterStep()
        {
            ScenarioBlock scenarioBlock = _ScenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;
                default:
                    CreateNode<And>();
                    break;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {

        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {

        }

        [AfterTestRun]
        public static void FlushExtentReports()
        {
            _ExtentsReports.Flush();

        }
    }
}