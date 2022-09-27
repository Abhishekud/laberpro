using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Downloads
{
    [Binding]
    public class DownloadsSteps
    {
        [Given(@"Kronos is enabled and User has requested a WIM export")]
        public void GivenUserHasRequestedWIM()
        {
            LogWriter.WriteLog("Executing step 'Kronos is enabled and User has requested a WIM export'");
            DownloadsPage.ClickOnKronosTab();
            DownloadsPage.ClickOnLaborStandardsTab();
            DownloadsPage.SelectOneLaborStandard();
            DownloadsPage.RequestWIMExport();
        }

        [When(@"User navigates to Downloads tab")]
        public void WhenUserNavigatesToDownloadsTab()
        {
            LogWriter.WriteLog("Executing step 'User navigates to Downloads tab'");
            DownloadsPage.ClickOnAccountTab();
            DownloadsPage.ClickOnDownloadsTab();
        }

        [Then(@"User has WIM record on Downloads page")]
        public void ThenUserHasWIMRecordOnDownloadsPage()
        {
            LogWriter.WriteLog("Executing step 'User has WIM record on Downloads page'");
            DownloadsPage.VerifyWIMExportExists();
        }
    }
}
