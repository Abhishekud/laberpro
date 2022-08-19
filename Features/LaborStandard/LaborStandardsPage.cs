using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;


namespace LaborPro.Automation.Features.LaborStandards
{
    public class LaborStandardsPage
    {
        private const string LaborStandardTab = "//a[@href='/kronos/laborstandards']";
        private const string LaborStandardPage = "//*[@class='page-header']//h3[@title='Labor Standards']";
        private const string KronosTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        private const string ExportButton = "//*[@id='export']";
        private const string LaborStandardRecord = "//td[@colspan='1' and @role='gridcell']";
        private const string LaborDriverInput = "//*[@id='laborDriverId']";
        private const string FieldSetDisabled = "//fieldset[@disabled]";
        public static void ClickOnLaborStandardsTab()
        {
            LogWriter.WriteLog("Executing LaborStandardsPage.ClickOnLaborStandardsTab");
            if (WebDriverUtil.GetWebElement(LaborStandardPage, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
                return;
                WebDriverUtil.GetWebElement(LaborStandardTab, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForAWhile();
            
        }
        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("Executing LaborStandardsPage.ClickOnKronosTab");
            if (WebDriverUtil.GetWebElement(KronosTab, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                return;
                WebDriverUtil.GetWebElement(KronosTab, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);       
        }
        public static void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing LaborStandardsPage.VerifyExportOptionIsAvailable");
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            exportButton.Click();
            if (exportButton == null)
                throw new Exception("Export Button is not found but we expect it should be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyEditOptionIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LaborStandardsPage.VerifyEditOptionIsNotAvailable");
            var laborStandardRecord = WebDriverUtil.GetWebElement(LaborStandardRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if(laborStandardRecord != null)
            {
                laborStandardRecord.Click();
                var editTextBox = WebDriverUtil.GetWebElement(LaborDriverInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                if(editTextBox.Enabled)
                    throw new Exception("Edit TextBox is enabled but we expect it should be disabled when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
     


    }
}
