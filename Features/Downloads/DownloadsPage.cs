using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.Downloads 
{
    public class DownloadsPage 
    {
        const string ACCOUNT_TAB = "//*[@class='page-body']//*[contains(text(),'Account')]";
        const string DOWNLOADS_TAB = "//*[@class='page-body']//*[contains(text(),'Downloads')]";
        const string DOWNLOADS_PAGE = "//*[@class='page-title' and text()='Downloads']";
        const string NO_RECORDS = "//*[@role='presentation']//tr[@class='k-grid-norecords']//*[text()='No records available']";
        
        public static void ClickOnAccountTab() 
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnAccountTab");
            if(WebDriverUtil.GetWebElement(ACCOUNT_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(ACCOUNT_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void ClickOnDownloadsTab() 
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnDownloadsTab");
            if(WebDriverUtil.GetWebElement(DOWNLOADS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(DOWNLOADS_TAB, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void VerifyNoDownloadsFound() 
        {
            LogWriter.WriteLog("DownloadsPage.VerifyNoDownloadsFound");
            IWebElement noRecordsFoundMessage = WebDriverUtil.GetWebElement(NO_RECORDS, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);

            if (noRecordsFoundMessage == null) {
              throw new Exception("Records present");
            }

            BaseClass._AttachScreenshot.Value = true;
        }
    }
}
