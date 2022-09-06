using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.LaborStandards
{
    [Binding]
    public class LaborStandardSteps
    {
        [Given(@"User navigates to the labor standards page")]
        [When(@"User navigates to the labor standards page")]
        [Then(@"User navigates to the labor standards page")]
        public void NavigatesToLaborStandardsPage()
        {
            LogWriter.WriteLog("Executing Step User navigates to the labor standards page");
            LaborStandardsPage.ClickOnKronosTab();
            LaborStandardsPage.ClickOnLaborStandardsTab();
        }

        [Given(@"User verify export option is available on labor standards page")]
        [When(@"User verify export option is available on labor standards page")]
        [Then(@"User verify export option is available on labor standards page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing Step User navigates to the labor standards page");
            LaborStandardsPage.VerifyExportOptionIsAvailable();
        }
        [Given(@"User verify edit option is not available on labor standards page")]
        [When(@"User verify edit option is not available on labor standards page")]
        [Then(@"User verify edit option is not available on labor standards page")]
        public void VerifyEditOptionIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify edit option is not available on labor standards page");
            LaborStandardsPage.VerifyEditOptionIsNotAvailable();
        }


    }
}
