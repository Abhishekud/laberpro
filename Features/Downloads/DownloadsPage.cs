using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Downloads 
{
    public class DownloadsPage 
    {
        const string AccountTab = "//*[@class='page-body']//*[contains(text(),'Account')]";
        const string DownloadsTab = "//*[@class='page-body']//*[contains(text(),'Downloads')]";
        const string KronosTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        const string LaborStandardTab = "//*[@class='page-body']//*[contains(text(),'Labor Standards')]";
        const string LaborStandardCheckbox = "//td[@colspan='1' and @role='gridcell' and @class='k-grid-edit-cell k-grid-content-sticky']//input[@type='checkbox']";
        const string ExportButton = "//button[@id='export-volume-driver-value-sets']";
        const string WimExportSelection = "//a[contains(text(), 'Export WIM File')]";
        const string ExportDownloadRecord = "//*[@role='presentation']//tr[@data-grid-row-index='0']";
        private const string VolumeDriverValueSetPageTitle = "//*[@class='page-title' and contains( text(),'Volume Driver Value Sets')]";
        private const string VolumeDriverValueSetDefaultRecord = "//td[@colspan='1' and @role='gridcell']//input[@type='checkbox']";
        private const string VolumeDriverValueSetDefaultRecordExport = "//*[@class='dropdown-menu dropdown-menu-right']//*[text()='Export Production Location Standards for Selected Volume Driver Value Sets ']";
        private const string ExportVolumeDriverValueSetsModal = "//*[@class='modal-content']//*[text()='Export Volume Driver Value Sets']";
        private const string ExportModalExportButton = "//*[@class='modal-content']//*[text()='Export']";
        private const string NameInput = "//*[@id='fileName']";
        private const string RecordName = "VDVSET";
        public static void ClickOnAccountTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnAccountTab");
            if (WebDriverUtil.GetWebElementAndScroll(AccountTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElementAndScroll(AccountTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void ClickOnDownloadsTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnDownloadsTab");
            if (WebDriverUtil.GetWebElement(DownloadsTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(DownloadsTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnKronosTab");
            if (WebDriverUtil.GetWebElement(KronosTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(KronosTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            }
        }

        public static void ClickOnLaborStandardsTab()
        {
            LogWriter.WriteLog("DownloadsPage.ClickOnLaborStandardsTab");
            if (WebDriverUtil.GetWebElement(LaborStandardTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(LaborStandardTab, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }

        public static void SelectOneLaborStandard()
        {
            LogWriter.WriteLog("DownloadsPage.SelectOneLaborStandard");
            var laborStandardRecord = WebDriverUtil.GetWebElement(LaborStandardCheckbox, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            if (laborStandardRecord != null)
            {
                laborStandardRecord.Click();
            }
        }

        public static void RequestWIMExport()
        {
            LogWriter.WriteLog("DownloadsPage.RequestWIMExport");
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton != null)
            {
                exportButton.Click();
                var WIMButton = WebDriverUtil.GetWebElement(WimExportSelection, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
                if (WIMButton != null)
                {
                    WIMButton.Click();
                    WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
                }
            }
        }

        public static void VerifyExportRequestExists()
        {
            LogWriter.WriteLog("DownloadsPage.VerifyExportRequestExists");
            var Record = WebDriverUtil.GetWebElement(ExportDownloadRecord, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);

            if (Record == null)
            {
                throw new Exception("No record found");
            }

            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectDefaultVolumeDriverValueSet()
        {
            LogWriter.WriteLog("Executing DownloadsPage.SelectDefaultVolumeDriverValueSet");
            if (WebDriverUtil.GetWebElement(VolumeDriverValueSetPageTitle, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                return; 
            WebDriverUtil.GetWebElement(VolumeDriverValueSetDefaultRecord, WebDriverUtil.NO_WAIT,
            $"Unable to locate volume driver value set record on volume driver value set page - {VolumeDriverValueSetDefaultRecord}").Click();
        }
        public static void RequestExportOfSelectedVolumeDriverValueSet()
        {
            LogWriter.WriteLog("Executing DownloadsPage.RequestExportOfSelectedVolumeDriverValueSet");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(VolumeDriverValueSetDefaultRecordExport, WebDriverUtil.NO_WAIT,
            $"Unable to locate volume driver value set export button on volume driver value set page " +
            $"- {VolumeDriverValueSetDefaultRecordExport}").Click();
            if (WebDriverUtil.GetWebElement(ExportVolumeDriverValueSetsModal, WebDriverUtil.TWO_SECOND_WAIT,
              WebDriverUtil.NO_MESSAGE) == null) return;
            WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
               $"Unable to locate name input on create volume driver set page - {NameInput}")
                   .SendKeys(Util.ProcessInputData(RecordName));
            WebDriverUtil.GetWebElement(ExportModalExportButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
        }
    }
}
