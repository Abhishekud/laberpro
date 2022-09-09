using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Kronos.LaborDrivers
{
    [Binding]
    public class LaborDriversSteps
    {

        [When(@"User navigates to the LaborDrivers tab")]
        [Given(@"User navigates to the LaborDrivers tab")]
        [Then(@"User navigates to the LaborDrivers tab")]
        public void UserNavigatesToTheLaborDriversTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the LaborDrivers tab");
            LaborDriversPage.CloseLaborDriversForm();
            LaborDriversPage.ClickOnKronosTab();
            LaborDriversPage.ClickOnLaborDriversTab();

        }

        [Given(@"User create new LaborDrivers with below input if not exist")]
        [When(@"User create new LaborDrivers with below input if not exist")]
        [Then(@"User create new LaborDrivers with below input if not exist")]
        public void AddNewLaborDriversWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User create new LaborDrivers with below input if not exist - " + inputData);
            LaborDriversPage.AddNewLaborDriversWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User create new LaborDrivers with below input")]
        [When(@"User create new LaborDrivers with below input")]
        [Then(@"User create new LaborDrivers with below input")]
        public void AddNewLaborDriversWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new LaborDrivers with below input - " + inputData);
            LaborDriversPage.AddNewLaborDriversWithGivenInput(inputData);
        }

        [Given(@"User clicks Add LaborDrivers Button")]
        [When(@"User clicks Add LaborDrivers Button")]
        [Then(@"User clicks Add LaborDrivers Button")]
        public void UserClickAddLaborDriversButton()
        {
            LogWriter.WriteLog("Executing Step User clicks Add LaborDrivers Button");
            LaborDriversPage.UserClickAddLaborDriversButton();
        }

        [Given(@"User verify created LaborDrivers ""([^""]*)""")]
        [When(@"User verify created LaborDrivers ""([^""]*)""")]
        [Then(@"User verify created LaborDrivers ""([^""]*)""")]
        public void UserVerifyCreatedLaborDrivers(string laborDriversName)
        {
            LogWriter.WriteLog("Executing Step User verify created LaborDrivers by name" + laborDriversName);
            LaborDriversPage.VerifyCreatedLaborDrivers(laborDriversName);
            LaborDriversPage.CloseLaborDriversDetailSideBar();
        }

        [Given(@"User verify Add Menu Popup")]
        [When(@"User verify Add Menu Popup")]
        [Then(@"User verify Add Menu Popup")]
        public void UserVerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing Step User verify Add Menu Popup");
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

        [Given(@"User verify add button is not available on labor drivers page")]
        [When(@"User verify add button is not available on labor drivers page")]
        [Then(@"User verify add button is not available on labor drivers page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on labor drivers page");
            LaborDriversPage.VerifyAddButtonIsNotPresent();
        }
        [Then(@"User verify delete button is not available on labor driver record ""(.*)""")]
        [When(@"User verify delete button is not available on labor driver record ""(.*)""")]
        [Then(@"User verify delete button is not available on labor driver record ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string laborDriversName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on labor driver record in" + laborDriversName);
            LaborDriversPage.VerifyDeleteButtonIsNotPresent(laborDriversName);
        }
        [Given(@"User verify export option is available on labor drivers page")]
        [When(@"User verify export option is available on labor drivers page")]
        [Then(@"User verify export option is available on labor drivers page")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on labor drivers page");
            LaborDriversPage.VerifyExportOptionIsPresent();
        }
    }
}
