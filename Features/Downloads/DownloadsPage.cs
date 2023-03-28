using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Downloads 
{
    public class DownloadsPage 
    {
        const string ACCOUNT_TAB = "//*[@class='page-body']//*[contains(text(),'Account')]";
        const string DOWNLOADS_TAB = "//*[@class='page-body']//*[contains(text(),'Downloads')]";
        const string KRONOS_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        const string LABOR_STANDARDS_TAB = "//*[@class='page-body']//*[contains(text(),'Labor Standards')]";

        const string LABOR_STANDARD_CHECKBOX = "//td[@colspan='1' and @role='gridcell' and @class='k-grid-edit-cell k-grid-content-sticky']//input[@type='checkbox']";
        const string EXPORT_BUTTON = "//*[@id='export']";
        const string WIM_EXPORT_SELECTION = "//a[contains(text(), 'Export WIM File')]";
        const string WIM_DOWNLOAD_RECORD = "//*[@role='presentation']//tr[@data-grid-row-index='0']//*[text()='LaborPro WIM Export']";

        public static void ClickOnAccountTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnAccountTab");
            if (WebDriverUtil.GetWebElementAndScroll(ACCOUNT_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElementAndScroll(ACCOUNT_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void ClickOnDownloadsTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnDownloadsTab");
            if (WebDriverUtil.GetWebElement(DOWNLOADS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(DOWNLOADS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnKronosTab");
            if (WebDriverUtil.GetWebElement(KRONOS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(KRONOS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void ClickOnLaborStandardsTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnLaborStandardsTab");
            if (WebDriverUtil.GetWebElement(LABOR_STANDARDS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(LABOR_STANDARDS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }

        public static void SelectOneLaborStandard()
        {
            LogWriter.WriteLog("DownloadsPage.SelectOneLaborStandard");
            var laborStandardRecord = WebDriverUtil.GetWebElement(LABOR_STANDARD_CHECKBOX, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            if (laborStandardRecord != null)
            {
                laborStandardRecord.Click();
            }
        }

        public static void RequestWIMExport()
        {
            LogWriter.WriteLog("DownloadsPage.RequestWIMExport");
            var exportButton = WebDriverUtil.GetWebElement(EXPORT_BUTTON, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton != null)
            {
                exportButton.Click();
                var WIMButton = WebDriverUtil.GetWebElement(WIM_EXPORT_SELECTION, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
                if (WIMButton != null)
                {
                    WIMButton.Click();
                    WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
                }
            }
        }

        public static void VerifyWIMExportExists()
        {
            LogWriter.WriteLog("DownloadsPage.VerifyWIMExportExists");
            var WIMRecord = WebDriverUtil.GetWebElement(WIM_DOWNLOAD_RECORD, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);

            if (WIMRecord == null)
            {
                throw new Exception("No record found");
            }

            BaseClass._AttachScreenshot.Value = true;
        }
    }
}
