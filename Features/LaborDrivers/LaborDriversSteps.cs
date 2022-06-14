using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.LaborDrivers
{
    [Binding]
    public class LaborDriversSteps
    {

        [When(@"User navigates to the LaborDrivers tab")]
        [Given(@"User navigates to the LaborDrivers tab")]
        [Then(@"User navigates to the LaborDrivers tab")]
        public void UserNavigatesToTheLaborDriversTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the LaborDrivers tab  ");
            LaborDriversPage.CloseLaborDriversForm();    
            LaborDriversPage.ClickOnKronosTab();     
            LaborDriversPage.ClickOnLaborDriversTab();  
             
        }

        [Given(@"User create new LaborDrivers with below input if not exist")]
        [When(@"User create new LaborDrivers with below input if not exist")]
        [Then(@"User create new LaborDrivers with below input if not exist")]
        public void AddNewLaborDriversWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new LaborDrivers with below input if not exist - " + inputData);
            LaborDriversPage.AddNewLaborDriversWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User create new LaborDrivers with below input")]
        [When(@"User create new LaborDrivers with below input")]
        [Then(@"User create new LaborDrivers with below input")]
        public void AddNewLaborDriversWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new LaborDrivers with below input "+inputData);
            LaborDriversPage.AddNewLaborDriversWithGivenInput(inputData);
        }
      
        [Given(@"User clicks Add LaborDrivers Button")]
        [When(@"User clicks Add LaborDrivers Button")]
        [Then(@"User clicks Add LaborDrivers Button")]
        public void UserClickAddLaborDriversButton()
        {
            LogWriter.WriteLog("Executing Step User clicks cancel button");
            LaborDriversPage.UserClickAddLaborDriversButton();
        }

        [Given(@"User verify created LaborDrivers ""([^""]*)""")]
        [When(@"User verify created LaborDrivers ""([^""]*)""")]
        [Then(@"User verify created LaborDrivers ""([^""]*)""")]
        public void UserVerifyCreatedLaborDrivers(string laborDriversName) {
            LogWriter.WriteLog("Executing Step User verify created LaborDrivers by name" + laborDriversName);
            LaborDriversPage.VerifyCreatedLaborDrivers(laborDriversName); 
        }

        [Given(@"User verify Add Menu Popup")]
        [When(@"User verify Add Menu Popup")]
        [Then(@"User verify Add Menu Popup")]
        public void UserVerifyAddMenuPopup( ) 
        {
            LogWriter.WriteLog("Executing Step User verify Add Menu Popup" );
            LaborDriversPage.VerifyAddMenuPopup();
        }

        [Given(@"User delete created LaborDrivers ""([^""]*)""")]
        [When(@"User delete created LaborDrivers ""([^""]*)""")]
        [Then(@"User delete created LaborDrivers ""([^""]*)""")]
        public void UserDeleteCreatedLaborDrivers(string laborDriversName)
        {
            LogWriter.WriteLog("Executing Step User delete created LaborDrivers by name" + laborDriversName);
            LaborDriversPage.DeleteCreatedLaborDrivers(laborDriversName);
        }

        [Given(@"User delete LaborDrivers ""([^""]*)"" if exist")]
        [When(@"User delete LaborDrivers ""([^""]*)"" if exist")]
        [Then(@"User delete LaborDrivers ""([^""]*)"" if exist")]
        public void UserDeleteLaborDrivers(string laborDriversName)
        {
            LogWriter.WriteLog("Executing Step User delete created LaborDrivers by name" + laborDriversName);
            LaborDriversPage.DeleteLaborDriversIfExist(laborDriversName);
        }

        [Given(@"Verify add button is not present")]
        [When(@"Verify add button is not present")]
        [Then(@"Verify add button is not present")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step Verify add button is not present ");
            LaborDriversPage.VerifyAddButtonIsNotPresent();
        }
        [Then(@"Verify delete button is not present in  ""(.*)""")]
        [When(@"Verify delete button is not present in  ""(.*)""")]
        [Then(@"Verify delete button is not present in  ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string laborDriversName)
        {
            LogWriter.WriteLog("Executing Step verify Delete button is not present");
            LaborDriversPage.VerifyDeleteButtonIsNotPresent(laborDriversName);
        }
        [Given(@"Verify export option is present")]
        [When(@"Verify export option is present")]
        [Then(@"Verify export option is present")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step Verify Export option is present ");
            LaborDriversPage.VerifyExportOptionIsPresent();
        }
    }
}
