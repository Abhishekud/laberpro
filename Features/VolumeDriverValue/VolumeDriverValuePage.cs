using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;


namespace LaborPro.Automation.Features.VolumeDriverValue
{
    public class VolumeDriverValuePage : SeleniumDriver
    {

        private const string VolumeDriverValuePages = "//*[@class='page volume-driver-values-list-page']//*[@title='Volume Driver Values']";
        private const string VolumeDriverValueTab = "//*[@class='navigation-container']//*[contains(text(),'Volume Driver Values')]";
        private const string AddButton = "//*[@class='header-button btn btn-default']";
        private const string ExportButton = "//*[@class='page volume-driver-values-list-page']//*[@id='export']//*[@class='fa fa-file-excel-o']";
        private const string ExportVolumeDriverValue = "//a[contains(text(),'Download Volume Driver Value Import Template')]";
        private const string VolumeDriverValueTableHeaders = "//table[@role='presentation']//th//*[@class='k-link']";

        public static void ClickOnVolumeDriverValueTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.ClickOnVolumeDriverValueTab");
            if (WebDriverUtil.GetWebElement(VolumeDriverValuePages, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) != null) return;
            WebDriverUtil.GetWebElement(VolumeDriverValueTab, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate volume driver value tab - {VolumeDriverValueTab}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
        }

        public static void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.VerifyExportOptionIsAvailable");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportVolumeDriverValue, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export button is not found but we expect it should be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.VerifyAddButtonIsNotAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static int FindColumnIndex(string headerName)
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.FindColumnIndex");
            IList<IWebElement> headers = Driver().FindElements(By.XPath(VolumeDriverValueTableHeaders));
            var index = 0;
            foreach (var header in headers)
            {
                index++;
                if (headerName.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }
            return index;
        }
    }
}
