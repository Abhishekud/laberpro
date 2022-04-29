using LaborPro.Automation.shared.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborPro.Automation.Features.StandardsandUomByLocation
{
    [Binding]
    public class StandardAndUomsByLocationSteps
    {
        [Given(@"User navigates to standardsanduomsbylocation tab")]
        public void GivenUserNavigatesToStandardsanduomsbylocationTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to standardsanduomsbylocation tab");
            StandardAndUomsByLocationPage.clickonOutputtab();
            StandardAndUomsByLocationPage.clickonstandardAndUomByLocationTab();
            StandardAndUomsByLocationPage.WaitforPageLoad();
            StandardAndUomsByLocationPage.WaitForRotatorTobeInvisible();
        }

        [When(@"User search record by name ""([^""]*)""")]
        public void WhenUserSearchRecordByName(string location)
        {
            LogWriter.WriteLog("Executing Step User search record by name");
            StandardAndUomsByLocationPage.WaitforPageLoad();
            StandardAndUomsByLocationPage.ClearAllFilter();
            StandardAndUomsByLocationPage.SearchStandardanduombylocation(location);
        }

        [Then(@"User verify standardsanduombylocation ""([^""]*)""")]
        public void ThenUserVerifyStandardsanduombylocation(string location)
        {
            LogWriter.WriteLog("User verify standardsanduombylocation");
            StandardAndUomsByLocationPage.verifyLocationInstandardsanduombyLocation(location);
        }

    }
}
