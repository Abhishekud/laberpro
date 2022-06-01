using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.ElementsUOM_ViewOnly
{
    [Binding]
    public class UomSteps
    {

        [When(@"User navigates to the UOM tab")]
        [Given(@"User navigates to the UOM tab")]
        [Then(@"User navigates to the UOM tab")]
        public void NavigatesToTheUomTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the UOM tab");
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
            LogWriter.WriteLog("Executing Step User create new UOM with below input");
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
            LogWriter.WriteLog("Executing Step User delete created UOM by name" + uomName);
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
        [Given(@"User verify Add Button is not Present in UOM")]
        [When(@"User verify Add Button is not Present in UOM")]
        [Then(@"User verify Add Button is not Present in UOM")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not present");
            UomPage.VerifyAddButtonIsNotPresent();
        } 
        [Then(@"User verify Delete Button is not Present in UOM ""(.*)""")]
        [When(@"User verify Delete Button is not Present in UOM ""(.*)""")]
        [Then(@"User verify Delete Button is not Present in UOM ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string uomName)
        {
            LogWriter.WriteLog("Executing Step User verify Delete button is not present");
            UomPage.VerifyDeleteButtonIsNotPresent(uomName);
        } 
    }
}
