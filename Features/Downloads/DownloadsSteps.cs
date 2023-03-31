using LaborPro.Automation.Features.VolumeDriverValueSet;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Downloads
{
    [Binding]
    public class DownloadsSteps
    {
        [Given(@"User has requested a export")]
        public void GivenUserHasRequestedExport()
        {
            LogWriter.WriteLog("Executing step 'User has requested a export'");
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
            DownloadsPage.SelectDefaultVolumeDriverValueSet();
            DownloadsPage.RequestExportOfSelectedVolumeDriverValueSet();
        }

        [When(@"User navigates to Downloads tab")]
        public void WhenUserNavigatesToDownloadsTab()
        {
            LogWriter.WriteLog("Executing step 'User navigates to Downloads tab'");
            DownloadsPage.ClickOnAccountTab();
            DownloadsPage.ClickOnDownloadsTab();
        }

        [Then(@"User has export record on downloads page")]
        public void UserHasExportRecordOnDownloadsPage()
        {
            LogWriter.WriteLog("Executing step 'User has export record on downloads page'");
            DownloadsPage.VerifyExportRequestExists();
        }
    }
}
