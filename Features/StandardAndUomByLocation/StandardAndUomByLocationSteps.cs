using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.StandardAndUomByLocation
{
    [Binding]
    public class StandardAndUomByLocationSteps
    {
        [Given(@"User navigates to standardsanduomsbylocation tab")]
        public void GivenUserNavigatesToStandardsAndUomsByLocationTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to standardsanduomsbylocation tab");
            StandardAndUomByLocationPage.ClickOnOutputTab();
            StandardAndUomByLocationPage.ClickOnStandardAndUomByLocationTab();
            StandardAndUomByLocationPage.WaitForPageLoad();
            StandardAndUomByLocationPage.WaitForLoadingSpinnerInvisible();
        }

        [When(@"User search record by name ""([^""]*)""")]
        public void WhenUserSearchRecordByName(string location)
        {
            LogWriter.WriteLog("Executing Step User search record by name");
            StandardAndUomByLocationPage.WaitForPageLoad();
            StandardAndUomByLocationPage.ClearAllFilter();
            StandardAndUomByLocationPage.SearchStandardAndUomByLocation(location);
        }

        [Then(@"User verify standardsanduombylocation ""([^""]*)""")]
        public void ThenUserVerifyStandardsAndUomByLocation(string location)
        {
            LogWriter.WriteLog("User verify standardsanduombylocation");
            StandardAndUomByLocationPage.VerifyLocationInstandardsAndUomByLocation(location);
        }

    }
}
