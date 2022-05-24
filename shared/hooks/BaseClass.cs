using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using LaborPro.Automation.shared.drivers;
using NUnit.Framework;
using LaborPro.Automation.shared.util;
using LaborPro.Automation.shared.config;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(5)]

namespace LaborPro.Automation.shared.hooks
{
    [Binding]
    public sealed class BaseClass
    {
        const string _ReportDirectory = @"/report/";
        const string _ReportScreenshotDirectory = @"/report/screenshots/";
        const string _DownloadDirectory = @"/downloads";
        const string EMPTY = "";
        private static ThreadLocal<FeatureContext> _featureContext = new ThreadLocal<FeatureContext>();
        private static ThreadLocal<ScenarioContext> _ScenarioContext = new ThreadLocal<ScenarioContext>();
        private static ExtentReports _ExtentsReports;
        private static ExtentHtmlReporter _ExtentHtmlReporter;
        private static ThreadLocal<ExtentTest> _Feature = new ThreadLocal<ExtentTest>();
        private static ThreadLocal<ExtentTest> _Scenario = new ThreadLocal<ExtentTest>();
        public static ThreadLocal<Boolean> _AttachScreenshot = new ThreadLocal<Boolean>();
        public static ThreadLocal<String> _TestData = new ThreadLocal<String>();
        private static Dictionary<string, TestScenario> ScenarioSuiteMapping = new Dictionary<string, TestScenario>();

        public static string GetProjectDirectoryPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine("Project base directory path : {0}", projectDirectory);
            return projectDirectory;
        }
        [BeforeTestRun]
        public static void Init()
        {
            Console.WriteLine("projectDirectory : {0}", GetProjectDirectoryPath());
            ReportDirectoryCleanup(GetProjectDirectoryPath() + _ReportDirectory);
            DownloadDirectoryCleanup(GetProjectDirectoryPath() + _DownloadDirectory);
            LogWriter.LogCleanup();
            _ExtentHtmlReporter = new ExtentHtmlReporter(GetProjectDirectoryPath() + _ReportDirectory + "TestResults.Html");
            _ExtentsReports = new ExtentReports();
            _ExtentsReports.AttachReporter(_ExtentHtmlReporter);
            ScenarioSuiteMapping = TestDataExcelReader.GetScenarioMapping();
        }
        public static void DownloadDirectoryCleanup(string directory)
        {
            if (Directory.Exists(directory))
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        file.Delete();
                    }
                    dir.Delete(true);
                }
                Directory.Delete(directory);
            }
            Directory.CreateDirectory(directory);
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
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        file.Delete();
                    }
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
            string suiteType = Environment.GetEnvironmentVariable("suiteType");
            if (suiteType == null)
                suiteType = TestDataExcelReader.REGRESSION_TEST;
            string featureFolderPath = featureContext.FeatureInfo.FolderPath;
            if (TestDataExcelReader.IsFeatureFileIncluded(featureFolderPath.Substring(featureFolderPath.IndexOf("/")+1) + ".feature", suiteType))
            {
                if (null != featureContext)
                {
                    _featureContext.Value = featureContext;
                    _Feature.Value = _ExtentsReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
                }
            }
            else
            {
                Assert.Ignore(String.Format("Feature file - {0} ignored as per the TestData.xlsx", featureContext.FeatureInfo.Title));
            }
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            string scenarioName = scenarioContext.ScenarioInfo.Title;
            scenarioName  = scenarioName.Substring(scenarioName.IndexOf(".")+1).Trim();    
            string[] tags = scenarioContext.ScenarioInfo.Tags;
            if(!tags.Contains("Setup") && !tags.Contains("Cleanup"))
            {
                string suiteType = Environment.GetEnvironmentVariable("suiteType");
                if (suiteType == null)
                    suiteType = TestDataExcelReader.REGRESSION_TEST;
                TestScenario testScenario = Util.ReadKey(ScenarioSuiteMapping, scenarioName);
                Boolean execute = false;
                if (suiteType.Equals(TestDataExcelReader.REGRESSION_TEST))
                {
                    execute = testScenario.regressionTest;
                }
                else
                {
                    execute = testScenario.smokeTest;
                }
                if (!execute)
                    Assert.Ignore(String.Format("Test scenario - {0} ignored as per the TestData.xlsx", scenarioName));
            }
            
            if (null != scenarioContext)
            {
                _Scenario.Value = _Feature.Value.CreateNode<Scenario>(scenarioName, scenarioContext.ScenarioInfo.Description);
            }
        }
        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            _AttachScreenshot.Value = false;
            _TestData.Value = EMPTY;
        }
        public BaseClass(ScenarioContext scenarioContext) => _ScenarioContext.Value = scenarioContext;
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
                SeleniumDriver.webDriver.Value = null;
            }
        }
        private static void TakeScreenshot(string fileName)
        {
            if(null!= SeleniumDriver.webDriver.Value)
            {
                Screenshot ss = ((ITakesScreenshot)SeleniumDriver.webDriver.Value).GetScreenshot();
                ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            }
        }
        public static void CreateNode<T>() where T : IGherkinFormatterModel 
        {
            string featureName = (_featureContext.Value != null ? _featureContext.Value.FeatureInfo.Title : "").Replace(" ", "").Replace(".", "");
            string scenarioName = _ScenarioContext.Value.ScenarioInfo.Title.Replace(" ", "").Replace(".", "");
            if (scenarioName.Length > 40)
                scenarioName = scenarioName.Substring(0, 40);
            if (_ScenarioContext.Value.TestError!=null)
            {
                long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                string screenshotName = GetProjectDirectoryPath() + _ReportScreenshotDirectory + featureName +"_"+timestamp + "_"+ scenarioName + ".png";
                TakeScreenshot(screenshotName);
                string reportScreenshotPath = "screenshots/" + featureName + "_" + timestamp + "_" + scenarioName + ".png";
                if (_TestData.Value!=null && _TestData.Value.Length>0)
                {
                    string errorMessage = Util.RemoveTagsFromGivenString(_ScenarioContext.Value.TestError.Message);
                    _Scenario.Value.CreateNode<T>(_ScenarioContext.Value.StepContext.StepInfo.Text + "\n" + _TestData.Value)
                        .Fail(errorMessage).AddScreenCaptureFromPath(reportScreenshotPath);
                }
                else
                {
                    string errorMessage = Util.RemoveTagsFromGivenString(_ScenarioContext.Value.TestError.Message);
                    _Scenario.Value.CreateNode<T>(_ScenarioContext.Value.StepContext.StepInfo.Text)
                        .Fail(errorMessage).AddScreenCaptureFromPath(reportScreenshotPath);
                }               
            }
            else
            {
                if(_AttachScreenshot.Value)
                {
                    long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                    string screenshotName = GetProjectDirectoryPath() + _ReportScreenshotDirectory + featureName +"_" + timestamp + "_" + scenarioName + ".png";
                    TakeScreenshot(screenshotName);
                    string reportScreenshotPath = "screenshots/" + featureName + "_" + timestamp + "_" + scenarioName + ".png";
                    if (_TestData.Value != null && _TestData.Value.Length > 0)
                    {
                        _Scenario.Value.CreateNode<T>(_ScenarioContext.Value.StepContext.StepInfo.Text + "\n" + _TestData.Value).Pass("").AddScreenCaptureFromPath(reportScreenshotPath);
                    }
                    else
                    {
                        _Scenario.Value.CreateNode<T>(_ScenarioContext.Value.StepContext.StepInfo.Text).Pass("").AddScreenCaptureFromPath(reportScreenshotPath);
                    }
                } 
                else
                {
                    if (_TestData.Value != null && _TestData.Value.Length > 0)
                    {
                        _Scenario.Value.CreateNode<T>(_ScenarioContext.Value.StepContext.StepInfo.Text + "\n" + _TestData.Value).Pass("");
                    }
                    else
                    {
                        _Scenario.Value.CreateNode<T>(_ScenarioContext.Value.StepContext.StepInfo.Text).Pass("");
                    }
                }
            }
        }
        [AfterStep]
        public void AfterStep()
        {
            ScenarioBlock scenarioBlock = _ScenarioContext.Value.CurrentScenarioBlock;
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
        [AfterTestRun]
        public static void FlushExtentReports()
        {
            _ExtentsReports.Flush();
        }
    }
}
