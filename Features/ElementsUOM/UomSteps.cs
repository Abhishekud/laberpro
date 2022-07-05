using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.ElementsUOM
{
    [Binding]
    public class UomSteps
    {

        [When(@"User navigates to the UoM page")]
        [Given(@"User navigates to the UoM page")]
        [Then(@"User navigates to the UoM page")]
        public void NavigatesToTheUomTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the UOM tab");
            UomPage.CloseUomForm();
            UomPage.ClickOnMeasurementsTab();
            UomPage.ClickOnListManagementTab();
            UomPage.ClickOnUOM();

        }  
        [Given(@"User create new UOM with below input")]
        [When(@"User create new UOM with below input")]
        [Then(@"User create new UOM with below input")]
        public void AddNewUomWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User create new UOM with below input");
            UomPage.AddNewUomWithGivenInput(inputData);
        } 

        [Given(@"User verify created UOM by name ""([^""]*)""")]
        [When(@"User verify created UOM by name ""([^""]*)""")]
        [Then(@"User verify created UOM by name ""([^""]*)""")]
        public void VerifyCreatedUom(string uomName)
        {
            LogWriter.WriteLog("Executing Step User delete UOM if exist" + uomName);
            UomPage.VerifyCreatedUom(uomName);
        }

        [Given(@"User delete created UOM by name ""([^""]*)""")]
        [When(@"User delete created UOM by name ""([^""]*)""")]
        [Then(@"User delete created UOM by name ""([^""]*)""")]
        public void DeleteCreatedUom(string uomName)
        {
            LogWriter.WriteLog("Executing Step: User delete created UOM by name" + uomName);
            UomPage.DeleteCreatedUom(uomName);
        }  

        [Given(@"User delete UOM ""([^""]*)"" if exist")]
        [When(@"User delete UOM ""([^""]*)"" if exist")]
        [Then(@"User delete UOM ""([^""]*)"" if exist")]
        public void DeleteUomIfExist(string uomName)
        {
            LogWriter.WriteLog("Executing Step User delete UOM if exist" + uomName);
            UomPage.DeleteUomIfExist(uomName);
        }
        [Given(@"User verify add Button is not present")]
        [When(@"User verify add Button is not present")]
        [Then(@"User verify add Button is not present")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step: User verify Add button is not present");
            UomPage.VerifyAddButtonIsNotPresent();
        } 
        [Then(@"User verify delete button is not present in UoM ""(.*)""")]
        [When(@"User verify delete button is not present in UoM ""(.*)""")]
        [Then(@"User verify delete button is not present in UoM ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string uomName)
        {
            LogWriter.WriteLog("Executing Step: User verify Delete button is not present");
            UomPage.VerifyDeleteButtonIsNotPresent(uomName);
        }
        [Then(@"User create new UoM with below input if not exist")]
        [When(@"User create new UoM with below input if not exist")]
        public void ThenUserCreateNewUomWithBelowInputIfNotExist(Table table)
        {
            LogWriter.WriteLog("Executing Step: User create new UOM with below input if not exist" + table);
            UomPage.AddNewUomIfNotExist(table);
        }

    }
}
