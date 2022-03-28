using laborpro.Features.UnitOfMeasure;
using laborpro.pages;
using laborpro.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborpro.Features.Standards
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
            StandardPage.CloseStandardsForm();
            AllowancesPage.ClickOnStandardTab();
            StandardPage.ClickOnStandardsTab();
            AllowancesPage.WaitForAllowanceAlertCloseIfAny();
           

        }

        [Given(@"User add new standards using below input")]
        [When(@"User add new standards using below input")]
        [Then(@"User add new standards using below input")]
        public void AddNewStandard(Table inputdata)
        {
            LogWriter.WriteLog("Executing Step: User add new standards using below input ");
            StandardPage.AddStandardsWihGivenInput(inputdata);
        }

        [Given(@"User verify created standards name ""([^""]*)""")]
        [When(@"User verify created standards name ""([^""]*)""")]
        [Then(@"User verify created standards name ""([^""]*)""")]
        public void VerifyCreatedStandard(string standardName)      
        {
            LogWriter.WriteLog("Executing Step: User verify created standards name" + standardName);
            StandardPage.VerifyCreatedStandard(standardName);
        }

        [Then(@"User Delete created Standards")]
        public void DeleteCreatedStandard()
        {
            LogWriter.WriteLog("Executing Standard: User Delete created Standards");
            StandardPage.DeleteCreatedStandard();
        }

        [Given(@"User clicks New Standard Element")]
        [When(@"User clicks New Standard Element")]
        [Then(@"User clicks New Standard Element")]
        public void ClickNewStandardElement()
        {
            LogWriter.WriteLog("Executing User clicks New Standard Element");
            StandardPage.NewStandardElement();
        }

        [Given(@"User Verify standard element popup by name ""([^""]*)""")]
        [When(@"User Verify standard element popup by name ""([^""]*)""")]
        [Then(@"User Verify standard element popup by name ""([^""]*)""")]
        public void StandardElementPopup(string standardelementText)
        {
            LogWriter.WriteLog("Executing User Verify standard element popup by name " + standardelementText);
            StandardPage.VerifyNewStandardElementPopup(standardelementText);
        }

        [Given(@"User Selects Standard Element type ""([^""]*)""")]
        [When(@"User Selects Standard Element type ""([^""]*)""")]
        [Then(@"User Selects Standard Element type ""([^""]*)""")]
        public void SelectElementType(string elementType)
        {
            LogWriter.WriteLog("Executing User Selects Element type " + elementType);
            StandardPage.selectElementType(elementType);    
        }

        [Given(@"User selects standard by name ""([^""]*)""")]
        [When(@"User selects standard by name ""([^""]*)""")]
        [Then(@"User selects standard by name ""([^""]*)""")]
        public void SelectCreatedStandard(string StandaradByName)
        {
            LogWriter.WriteLog("Executing User selects created standard by name" + StandaradByName);
            StandardPage.selectStandarad(StandaradByName);

        }

        [Given(@"User adds new Standard Element Using Below input")]
        [When(@"User adds new Standard Element Using Below input")]
        [Then(@"User adds new Standard Element Using Below input")]
        public void AddNewStandardElement(Table inputData)
        {
            LogWriter.WriteLog("Executing User adds new Standard Element Using Below input " + inputData);
            StandardPage.AddStandardElementwithGivenInput(inputData);
        }

         [Given(@"User verify standard element by name ""([^""]*)""")]
         [When(@"User verify standard element by name ""([^""]*)""")]
         [Then(@"User verify standard element by name ""([^""]*)""")]
         public void VerifyStandardElement(string standardElement)
        {
            LogWriter.WriteLog("Executing User verify standard element by name" + standardElement);
            StandardPage.VerifyCreatedStandardElement(standardElement);
        }

        [Given(@"User delete standard element")]
        [When(@"User delete standard element")]
        [Then(@"User delete standard element")]
        public void DeleteStandardElement()
        {
            LogWriter.WriteLog("Executing User delete standard element ");
            StandardPage.DeleteStandardElement();
        }
        [Then(@"User delete UOM by name ""([^""]*)""")]
        public void DeleteUOMByName(string UOM)
        {
            LogWriter.WriteLog("Executing User delete UOM by name" + UOM);
            UnitsOfMeasurePage.DeleteUnitOfMeasureByName(UOM);
        }
        [When(@"User search standard by name ""([^""]*)""")]
        public void searchstandard(string standardName)
        {
            LogWriter.WriteLog("Executing User search standard by name" + standardName);
            StandardPage.ClearAllFilter();
            StandardPage.SearchStandard(standardName);
        }

        [Then(@"User Verify Frequency is empty")]
        public void VerifyFrequencyInStandardElement()
        {
            LogWriter.WriteLog("Executing User Verify Frequency is empty");
            StandardPage.VerifyFrequencyIsEmpty();
        }

        [Then(@"User Verify Unit Of measure in DropDown ""([^""]*)""")]
        public void VerifyUOMInDropDown(string UOM)
        {
            LogWriter.WriteLog("Executing User Verify Unit Of measure in DropDown" + UOM);
            StandardPage.VerifyUOMInDropDown(UOM);
        }
    }
}
