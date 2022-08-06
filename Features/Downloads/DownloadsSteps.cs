using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Downloads
{
    [Binding]
    public class DownloadsSteps
    {
        [Given(@"User has not requested any exports")]
        public void GivenUserHasNotRequestedExport()
        {
            LogWriter.WriteLog("Executing step 'User has not requested any exports;");
        }

        [When(@"User navigates to Downloads tab")]
        public void WhenUserNavigatesToDownloadsTab()
        {
            LogWriter.WriteLog("Executing step 'User navigates to Downloads tab'");
            DownloadsPage.ClickOnAccountTab();
            DownloadsPage.ClickOnDownloadsTab();
        }

        [Then(@"User has no records on Downloads page")]
        public void ThenUserHasNoRecordsOnDownloadsPage()
        {
            LogWriter.WriteLog("Executing step 'User has no records on Downloads page");
            DownloadsPage.VerifyNoDownloadsFound();
        }
    }
}
