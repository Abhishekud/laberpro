using LaborPro.Automation.Features.Locations; 
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.VolumeDriverValue
{
    [Binding]
    public class VolumeDriverSteps
    {
        [Given(@"User navigates to volume driver values tab")]
        [When(@"User navigates to volume driver values tab")]
        [Then(@"User navigates to volume driver values tab")]
        public void GivenUserNavigatesToVolumeDriverValuesTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to volume driver values tab");
            LocationPage.ClickOnProfilingTab();
            VolumeDriverValuePage.ClickOnVolumeDriverValueTab();
        }
      
        [Given(@"User verify add button is not available on volume driver values page")]
        [When(@"User verify add button is not available on volume driver values page")]
        [Then(@"User verify add button is not available on volume driver values page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on volume driver values page");
            VolumeDriverValuePage.VerifyAddButtonIsNotAvailable();
        }

        [Given(@"User verify export option is available on volume driver values page")]
        [When(@"User verify export option is available on volume driver values page")]
        [Then(@"User verify export option is available on volume driver values page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on volume driver values page");
            VolumeDriverValuePage.VerifyExportOptionIsAvailable();
        }

    }
}
