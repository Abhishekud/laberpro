using LaborPro.Automation.Features.VolumeDriverValue;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.StandardsandUomByLocation
{
    public class StandardAndUomsByLocationPage
    {
        const string OUTPUT_TAB = "//*[@class='page-body']//*[contains(text(),'Outputs')]";
        const string STANDARD_AND_UOM_BYLOCATION_TAB = "//*[@class='page-body']//*[contains(text(),'Standards & UOMs by Locations')]";
        const string STANDARD_AND_UOM_BYLOCATION_PAGE = "//*[@class='page-title' and text()='Standards & UOMs by Locations']";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string CLEAR_FILTER_BUTTON = "//button[@title='Clear All Filters']";
        const string STANDARD_AND_UOMBYLOCATION_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        const string STANDARD_AND_UOM_BY_LOCATION_LOCATIONINPUT = "//*[@role='presentation']//td[@aria-colindex='{0}' and contains(text(),'{1}')]";
        const string LOAD_SPINNER = "//i[@class='fa fa-spinner fa-spin']";
        const string LOADING_PAGE = "//div[contains(text(),'Loading...')]";
        const string LOCATION_IN_OUTPUT_PAGE = "//*[@role='presentation']//th//*[text()='Location']";
       
        public static void ClickOnOutputTab()
        {
            LogWriter.WriteLog("standardsanduombylocationpage.ClickOnOutputTab");
            if(WebDriverUtil.GetWebElement(OUTPUT_TAB, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(OUTPUT_TAB, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }
        public static void ClickOnStandardAndUomByLocationTab()
        {
            LogWriter.WriteLog("standardsanduombylocationpage.ClickOnStandardAndUomByLocationTab");
            if (WebDriverUtil.GetWebElement(STANDARD_AND_UOM_BYLOCATION_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(STANDARD_AND_UOM_BYLOCATION_TAB, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void SearchStandardAndUomByLocation(String location)
        {
            LogWriter.WriteLog("standardsanduombylocationpage.SearchStandardAndUomByLocation");
            IWebElement locationInOutput = SeleniumDriver.Driver().FindElement(By.XPath(LOCATION_IN_OUTPUT_PAGE));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)SeleniumDriver.Driver();
            js.ExecuteScript(script, locationInOutput);
            String locations = "Location";
            WebDriverUtil.GetWebElement(String.Format(STANDARD_AND_UOMBYLOCATION_FILTER_INPUT, VolumeDriverValuePage.FindColumnIndex(locations)), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate location filter input on STANDARD AND UOM BY LOCATION PAGE - {0}", STANDARD_AND_UOMBYLOCATION_FILTER_INPUT)).SendKeys(location);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();    
        }
        public static void WaitForLoading()
        {
            LogWriter.WriteLog("standardsanduombylocationpage.WaitForLoading");
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("standardsanduombylocationpage.ClearAllFilter");
            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(CLEAR_FILTER_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
        public static void VerifyLocationInstandardsAndUomByLocation(string location)
        {
            LogWriter.WriteLog("standardsanduombylocationpage.VerifyLocationInstandardsAndUomByLocation");
            IWebElement locationInOutput = SeleniumDriver.Driver().FindElement(By.XPath(LOCATION_IN_OUTPUT_PAGE));
            var script = "arguments[0].scrollIntoView(true);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)SeleniumDriver.Driver();
            js.ExecuteScript(script, locationInOutput);
            string locations = "Location";
            if (WebDriverUtil.GetWebElementAndScroll(String.Format(STANDARD_AND_UOM_BY_LOCATION_LOCATIONINPUT, VolumeDriverValuePage.FindColumnIndex(locations), location), WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElementAndScroll(String.Format(STANDARD_AND_UOM_BY_LOCATION_LOCATIONINPUT,VolumeDriverValuePage.FindColumnIndex(locations), location), WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static void WaitForLoadingSpinnerInvisible()
        {
            if (WebDriverUtil.GetWebElement(LOAD_SPINNER, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LOAD_SPINNER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void WaitForPageLoad()
        {
            if (WebDriverUtil.GetWebElement(LOADING_PAGE, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LOADING_PAGE, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
    }
}
