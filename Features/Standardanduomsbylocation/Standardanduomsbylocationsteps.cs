using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.StandardsandUomByLocation
{
    [Binding]
    public class StandardAndUomsByLocationSteps
    {
        [Given(@"User navigates to standardsanduomsbylocation tab")]
        public void GivenUserNavigatesToStandardsAndUomsByLocationTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to standardsanduomsbylocation tab");
            StandardAndUomsByLocationPage.ClickOnOutputTab();
            StandardAndUomsByLocationPage.ClickOnStandardAndUomByLocationTab();
            StandardAndUomsByLocationPage.WaitForPageLoad();
            StandardAndUomsByLocationPage.WaitForLoadingSpinnerInvisible();
        }

        [When(@"User search record by name ""([^""]*)""")]
        public void WhenUserSearchRecordByName(string location)
        {
            LogWriter.WriteLog("Executing Step User search record by name");
            StandardAndUomsByLocationPage.WaitForPageLoad();
            StandardAndUomsByLocationPage.ClearAllFilter();
            StandardAndUomsByLocationPage.SearchStandardAndUomByLocation(location);
        }

        [Then(@"User verify standardsanduombylocation ""([^""]*)""")]
        public void ThenUserVerifyStandardsAndUomByLocation(string location)
        {
            LogWriter.WriteLog("User verify standardsanduombylocation");
            StandardAndUomsByLocationPage.VerifyLocationInstandardsAndUomByLocation(location);
        }

    }
}
