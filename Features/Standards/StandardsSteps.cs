using LaborPro.Automation.Features.UnitOfMeasure;
using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Standards
{
    [Binding]
    public class StandardsSteps
    {
        [Given(@"User navigates to the standards tab")]
        [When(@"User navigates to the standards tab")]
        [Then(@"User navigates to the standards tab")]
        public void NavigatesToStandardsTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the standards tab");
            StandardsPage.CloseStandardsForm();
            AllowancePage.ClickOnStandardTab();
            StandardsPage.ClickOnStandardsTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
        }

        [Given(@"User add new standards using below input")]
        [When(@"User add new standards using below input")]
        [Then(@"User add new standards using below input")]
        public void AddNewStandard(Table inputdata)
        {
            LogWriter.WriteLog("Executing Step: User add new standards using below input ");
            StandardsPage.AddStandardsWihGivenInput(inputdata);
        }

        [Given(@"User verify created standards name ""([^""]*)""")]
        [When(@"User verify created standards name ""([^""]*)""")]
        [Then(@"User verify created standards name ""([^""]*)""")]
        public void VerifyCreatedStandard(string standardName)      
        {
            LogWriter.WriteLog("Executing Step: User verify created standards name" + standardName);
            StandardsPage.VerifyCreatedStandard(standardName);
        }

        [Then(@"User Delete created Standards")]
        public void DeleteCreatedStandard()
        {
            LogWriter.WriteLog("Executing Standard: User Delete created Standards");
            StandardsPage.DeleteCreatedStandard();
        }

        [Given(@"User clicks New Standard Element")]
        [When(@"User clicks New Standard Element")]
        [Then(@"User clicks New Standard Element")]
        public void ClickNewStandardElement()
        {
            LogWriter.WriteLog("Executing User clicks New Standard Element");
            StandardsPage.NewStandardElement();
        }

        [Given(@"User Verify standard element popup by name ""([^""]*)""")]
        [When(@"User Verify standard element popup by name ""([^""]*)""")]
        [Then(@"User Verify standard element popup by name ""([^""]*)""")]
        public void StandardElementPopup(string standardelementText)
        {
            LogWriter.WriteLog("Executing User Verify standard element popup by name " + standardelementText);
            StandardsPage.VerifyNewStandardElementPopup(standardelementText);
        }

        [Given(@"User Selects Standard Element type ""([^""]*)""")]
        [When(@"User Selects Standard Element type ""([^""]*)""")]
        [Then(@"User Selects Standard Element type ""([^""]*)""")]
        public void SelectElementType(string elementType)
        {
            LogWriter.WriteLog("Executing User Selects Element type " + elementType);
            StandardsPage.SelectElementType(elementType);    
        }

        [Given(@"User selects standard by name ""([^""]*)""")]
        [When(@"User selects standard by name ""([^""]*)""")]
        [Then(@"User selects standard by name ""([^""]*)""")]
        public void SelectCreatedStandard(string standaradByName)
        {
            LogWriter.WriteLog("Executing User selects created standard by name" + standaradByName);
            StandardsPage.SelectStandarad(standaradByName);

        }

        [Given(@"User adds new Standard Element Using Below input")]
        [When(@"User adds new Standard Element Using Below input")]
        [Then(@"User adds new Standard Element Using Below input")]
        public void AddNewStandardElement(Table inputData)
        {
            LogWriter.WriteLog("Executing User adds new Standard Element Using Below input " + inputData);
            StandardsPage.AddStandardElementWithGivenInput(inputData);
        }

        [Given(@"User verify standard element by name ""([^""]*)""")]
        [When(@"User verify standard element by name ""([^""]*)""")]
        [Then(@"User verify standard element by name ""([^""]*)""")]
        public void VerifyStandardElement(string standardElement)
        {
            LogWriter.WriteLog("Executing User verify standard element by name" + standardElement);
            StandardsPage.VerifyCreatedStandardElement(standardElement);
        }

        [Given(@"User delete standard element")]
        [When(@"User delete standard element")]
        [Then(@"User delete standard element")]
        public void DeleteStandardElement()
        {
            LogWriter.WriteLog("Executing User delete standard element ");
            StandardsPage.DeleteStandardElement();
        }

        [Then(@"User delete UOM by name ""([^""]*)""")]
        public void DeleteUnitOfMeasureByName(string uom)
        {
            LogWriter.WriteLog("Executing User delete UOM by name" + uom);
            UnitsOfMeasurePage.DeleteUnitOfMeasureByName(uom);
        }

        [When(@"User search standard by name ""([^""]*)""")]
        [Then(@"User search standard by name ""([^""]*)""")]
        public void Searchstandard(string standardName)
        {
            LogWriter.WriteLog("Executing User search standard by name" + standardName);
            StandardsPage.ClearAllFilter();
            StandardsPage.SearchStandard(standardName);
        }

        [Then(@"User Verify Frequency is empty")]
        public void VerifyFrequencyInStandardElement()
        {
            LogWriter.WriteLog("Executing User Verify Frequency is empty");
            StandardsPage.VerifyFrequencyIsEmpty();
        }

        [Then(@"User Verify Unit Of measure in DropDown ""([^""]*)""")]
        public void VerifyUOMInDropDown(string UOM)
        {
            LogWriter.WriteLog("Executing User Verify Unit Of measure in DropDown" + UOM);
            StandardsPage.VerifyUomInDropDown(UOM);
        }

        [Given(@"User delete Standard ""([^""]*)"" if exist")]
        [When(@"User delete Standard ""([^""]*)"" if exist")]
        [Then(@"User delete Standard ""([^""]*)"" if exist")]
        public void UserDeleteStandard(string standardName)
        {
            LogWriter.WriteLog("Executing Step User delete created Standard by name" + standardName);
            StandardsPage.DeleteStandardIfExist(standardName);
        }
        [Then(@"User verify add button is not available on standard page")]
        public void ThenUserVerifyAddButtonIsNotAvailableOnStandardPage()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on standard page");
            StandardsPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify edit button is not available on standard details page")]
        public void ThenUserVerifyEditButtonIsNotAvailableOnStandardDetailsPage()
        {
            LogWriter.WriteLog("Executing Step User verify edit button is not available on standard details page");
            StandardsPage.VerifyEditButtonIsNotPresent();
        }

        [Then(@"User verify export option is available on standard page")]
        public void ThenUserVerifyExportOptionIsAvailableOnStandardPage()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on standard page");
            StandardsPage.VerifyExportOptionIsPresent();
        }

        [Then(@"User verify download report option is available")]
        public void ThenUserVerifyDownloadReportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify download report option is available");
            StandardsPage.VerifyReportOptionIsPresent();
        }

        [Then(@"User verify add button is not available for standard element on standard details page")]
        public void ThenUserVerifyAddButtonIsNotAvailableForStandardElementOnStandardDetailsPage()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available for standard element on standard details page");
            StandardsPage.VerifyAddButtonIsNotAvailableInStandardElement();
        }

        [Then(@"User verify add option is not available for standard group on standard details page")]
        public void ThenUserVerifyAddOptionIsNotAvailableForStandardGroupOnStandardDetailsPage()
        {
            LogWriter.WriteLog("Executing Step User verify add option is not available for standard group on standard details page");
            StandardsPage.VerifyAddOptionIsNotAvailableInStandardGroup();
        }

        [Then(@"User verify tick option in existing standard element is not available")]
        public void ThenUserVerifyAddOptionInExistingStandardElementIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify tick option in existing standard element is not available");
            StandardsPage.VerifyTickOptionIsNotAvailable();
        }

        [When(@"User selects standard in standard listing")]
        public void WhenUserSelectsStandardInStandardListing()
        {
            LogWriter.WriteLog("Executing Step User selects standard in standard listing");
            StandardsPage.SelectStandardInListing();
        }

    }
}
